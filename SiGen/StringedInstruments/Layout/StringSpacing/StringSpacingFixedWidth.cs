using SiGen.Measuring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SiGen.StringedInstruments.Layout
{
    /// <summary>
    /// String spacing manager that allows for:
    /// 1. Fixed nut width that doesn't change with dual scale or other factors
    /// 2. Individual bridge spacing per string gap
    /// 3. Configurable fingerboard margins at nut and bridge
    /// </summary>
    public class StringSpacingFixedWidth : StringSpacingManager
    {
        private Measure _FixedNutWidth;
        private StringSpacingMethod _NutSpacingMode;
        private Measure[] _BridgeSpacing;
        
        // Fingerboard margins
        private Measure _NutMargin;
        private Measure _BridgeMargin;
        
        // For nut spacing when using equal spacing mode (considering string gauge)
        private Measure[] AdjustedNutSpacings;
        
        // Individual spacing between each pair of strings at the nut (similar to bridge)
        private Measure[] _NutSpacing;
        
        // Store user input values separately from compensated values to ensure UI shows exact inputs
        private Measure _UserInputNutWidth;
        private Measure[] _UserInputBridgeSpacing;

        public override StringSpacingType Type
        {
            get { return StringSpacingType.FixedWidth; }
        }

        /// <summary>
        /// Fixed total width at the nut (e.g., 38mm). This width remains constant.
        /// </summary>
        public Measure FixedNutWidth
        {
            get => _FixedNutWidth;
            set => SetPropertyValue(ref _FixedNutWidth, value);
        }

        /// <summary>
        /// How to distribute strings within the fixed nut width
        /// </summary>
        public StringSpacingMethod NutSpacingMode
        {
            get => _NutSpacingMode;
            set => SetPropertyValue(ref _NutSpacingMode, value);
        }

        /// <summary>
        /// Individual spacing between each pair of strings at the bridge (e.g., [17mm, 18mm, 18mm])
        /// </summary>
        public Measure[] BridgeSpacing 
        { 
            get 
            {
                // Ensure arrays are properly sized
                if (_BridgeSpacing.Length != Math.Max(0, Layout.NumberOfStrings - 1))
                    InitializeBridgeSpacing();
                
                return _BridgeSpacing;
            }
        }

        /// <summary>
        /// Individual spacing between each pair of strings at the nut
        /// </summary>
        public Measure[] NutSpacing 
        { 
            get 
            {
                // Ensure array is properly sized
                if (_NutSpacing == null || _NutSpacing.Length != Math.Max(0, Layout.NumberOfStrings - 1))
                    InitializeNutSpacing();
                return _NutSpacing;
            }
        }

        /// <summary>
        /// Margin at the nut (subtracted from total fretboard width)
        /// </summary>
        public Measure NutMargin
        {
            get => _NutMargin;
            set => SetPropertyValue(ref _NutMargin, value);
        }

        /// <summary>
        /// Margin at the bridge (added to the total bridge spacing)
        /// </summary>
        public Measure BridgeMargin
        {
            get => _BridgeMargin;
            set => SetPropertyValue(ref _BridgeMargin, value);
        }

        public StringSpacingFixedWidth(SILayout layout) : base(layout)
        {
            // Initialize all measures with valid defaults first - NEVER use empty measures
            _FixedNutWidth = Measure.Mm(38); // Default 38mm as requested
            _UserInputNutWidth = Measure.Mm(38); // Initialize user input to same value
            _NutSpacingMode = StringSpacingMethod.EqualDistance;
            AdjustedNutSpacings = new Measure[0];
            
            // Initialize margins with defaults - NEVER leave empty
            _NutMargin = Measure.Mm(3);    // Default 3mm nut margin
            _BridgeMargin = Measure.Mm(7); // Default 7mm bridge margin
            
            // Initialize with empty arrays first, proper sizing happens when NumberOfStrings is available
            _BridgeSpacing = new Measure[0];
            _NutSpacing = new Measure[0];
            _UserInputBridgeSpacing = new Measure[0];
            
            // If we already know the number of strings, initialize the arrays
            if (layout != null && layout.NumberOfStrings > 1)
            {
                InitializeBridgeSpacing();
                InitializeNutSpacing();
            }
        }

        protected override void OnStringsChanged()
        {
            InitializeBridgeSpacing();
            InitializeNutSpacing();
            AdjustedNutSpacings = new Measure[0]; // Reset adjusted spacings
        }

        private void InitializeBridgeSpacing()
        {
            // Don't initialize if NumberOfStrings isn't set yet (during layout loading)
            if (Layout.NumberOfStrings <= 1)
            {
                _BridgeSpacing = new Measure[0];
                _UserInputBridgeSpacing = new Measure[0];
                return;
            }

            var requiredLength = Layout.NumberOfStrings - 1;
            
            if (_BridgeSpacing != null && _BridgeSpacing.Length > 0)
            {
                var oldBridge = _BridgeSpacing;
                _BridgeSpacing = new Measure[requiredLength];

                for (int i = 0; i < requiredLength; i++)
                {
                    if (i < oldBridge.Length)
                        _BridgeSpacing[i] = oldBridge[i];
                    else
                        _BridgeSpacing[i] = oldBridge.Length > 0 ? oldBridge[oldBridge.Length - 1] : Measure.Mm(10);
                }
            }
            else
            {
                _BridgeSpacing = new Measure[requiredLength];
                // Set default bridge spacing values: 17mm, 18mm, 18mm
                var defaultSpacings = new[] { Measure.Mm(17), Measure.Mm(18), Measure.Mm(18) };
                for (int i = 0; i < requiredLength; i++)
                {
                    _BridgeSpacing[i] = i < defaultSpacings.Length ? defaultSpacings[i] : Measure.Mm(18);
                }
            }
        }

        private void InitializeNutSpacing()
        {
            // Don't initialize if NumberOfStrings isn't set yet (during layout loading)
            if (Layout.NumberOfStrings <= 1)
            {
                _NutSpacing = new Measure[0];
                return;
            }

            var requiredLength = Layout.NumberOfStrings - 1;
            
            if (_NutSpacing != null && _NutSpacing.Length > 0)
            {
                var oldNut = _NutSpacing;
                _NutSpacing = new Measure[requiredLength];

                for (int i = 0; i < requiredLength; i++)
                {
                    if (i < oldNut.Length && oldNut[i] != Measure.Empty)
                        _NutSpacing[i] = oldNut[i];
                    else
                    {
                        var fixedWidth = !_FixedNutWidth.IsEmpty ? _FixedNutWidth : Measure.Mm(38);
                        var nutMargin = !_NutMargin.IsEmpty ? _NutMargin : Measure.Mm(3);
                        var usableWidth = fixedWidth - (nutMargin * 2);
                        if (usableWidth.Value <= 0)
                            usableWidth = Measure.Mm(32);
                        _NutSpacing[i] = usableWidth / requiredLength;
                    }
                }
            }
            else
            {
                _NutSpacing = new Measure[requiredLength];
                
                var fixedWidth = !_FixedNutWidth.IsEmpty ? _FixedNutWidth : Measure.Mm(38);
                var nutMargin = !_NutMargin.IsEmpty ? _NutMargin : Measure.Mm(3);
                var usableWidth = fixedWidth - (nutMargin * 2);
                if (usableWidth.Value <= 0)
                    usableWidth = Measure.Mm(32);
                    
                var equalSpacing = usableWidth / requiredLength;
                for (int i = 0; i < requiredLength; i++)
                {
                    _NutSpacing[i] = equalSpacing;
                }
            }
        }

        public override Measure StringSpreadAtNut
        {
            get 
            {
                // If individual nut spacings are set, use their sum
                if (_NutSpacing != null && _NutSpacing.Length > 0)
                {
                    Measure total = Measure.Mm(0);
                    for (int i = 0; i < _NutSpacing.Length; i++)
                    {
                        if (_NutSpacing[i] != Measure.Empty)
                            total += _NutSpacing[i];
                    }
                    if (total.Value > 0)
                        return total;
                }
                
                var fixedWidth = !_FixedNutWidth.IsEmpty ? _FixedNutWidth : Measure.Mm(38);
                var nutMargin = !_NutMargin.IsEmpty ? _NutMargin : Measure.Mm(3);
                var usableWidth = fixedWidth - (nutMargin * 2);
                
                return usableWidth.Value > 0 ? usableWidth : Measure.Mm(32);
            }
            set 
            { 
                if (_NutMargin == Measure.Empty)
                    _NutMargin = Measure.Mm(3);
                
                if (_FixedNutWidth == Measure.Empty)
                    _FixedNutWidth = value + (_NutMargin * 2);
                
                if (_NutSpacing != null && _NutSpacing.Length > 0)
                {
                    var fixedWidth = !_FixedNutWidth.IsEmpty ? _FixedNutWidth : Measure.Mm(38);
                    var nutMargin = !_NutMargin.IsEmpty ? _NutMargin : Measure.Mm(3);
                    var availableWidth = fixedWidth - (nutMargin * 2);
                    if (availableWidth.Value > 0 && _NutSpacing.Length > 0)
                    {
                        var equalSpacing = availableWidth / _NutSpacing.Length;
                        for (int i = 0; i < _NutSpacing.Length; i++)
                        {
                            _NutSpacing[i] = equalSpacing;
                        }
                    }
                }
            }
        }

        public override Measure StringSpreadAtBridge
        {
            get 
            {
                if (_BridgeSpacing == null || _BridgeSpacing.Length == 0)
                    return Measure.Mm(0);
                
                Measure total = Measure.Mm(0);
                for (int i = 0; i < _BridgeSpacing.Length; i++)
                {
                    total += _BridgeSpacing[i];
                }
                return total;
            }
            set 
            {
                if (Layout.NumberOfStrings > 1)
                {
                    var spacingPerGap = value / (Layout.NumberOfStrings - 1);
                    InitializeBridgeSpacing();
                    for (int i = 0; i < _BridgeSpacing.Length; i++)
                    {
                        _BridgeSpacing[i] = spacingPerGap;
                    }
                }
            }
        }

        public override Measure GetSpacing(int index, FingerboardEnd side)
        {
            if (side == FingerboardEnd.Nut)
            {
                if (_NutSpacing != null && index >= 0 && index < _NutSpacing.Length && _NutSpacing[index] != Measure.Empty)
                {
                    return _NutSpacing[index];
                }
                else
                {
                    var spread = StringSpreadAtNut;
                    if (spread.Value > 0 && Layout.NumberOfStrings > 1)
                        return spread / (Layout.NumberOfStrings - 1);
                    else
                        return Measure.Mm(8);
                }
            }
            else // Bridge
            {
                if (index >= 0 && index < _BridgeSpacing.Length && _BridgeSpacing[index] != Measure.Empty)
                {
                    return _BridgeSpacing[index];
                }
                return Measure.Mm(18);
            }
        }

        public override void SetSpacing(FingerboardEnd side, int index, Measure value)
        {
            if (side == FingerboardEnd.Nut)
            {
                if (_NutSpacing == null)
                    InitializeNutSpacing();
                    
                if (index >= 0 && index < _NutSpacing.Length)
                {
                    SetFieldValue(ref _NutSpacing, index, value, nameof(_NutSpacing));
                }
            }
            else // Bridge
            {
                if (index >= 0 && index < _BridgeSpacing.Length)
                {
                    SetFieldValue(ref _BridgeSpacing, index, value, nameof(_BridgeSpacing));
                }
            }
        }

        public override XElement Serialize(string elemName)
        {
            var elem = new XElement(elemName,
                new XAttribute("Mode", "FixedWidth"),
                new XAttribute("NutAlignment", NutAlignment),
                new XAttribute("BridgeAlignment", BridgeAlignment),
                new XAttribute("NutSpacingMode", NutSpacingMode),
                FixedNutWidth.SerializeAsAttribute("FixedNutWidth"),
                NutMargin.SerializeAsAttribute("NutMargin"),
                BridgeMargin.SerializeAsAttribute("BridgeMargin"));

            for (int i = 0; i < NumberOfStrings - 1; i++)
            {
                elem.Add(new XElement("Spacing",
                    new XAttribute("Index", i),
                    GetSpacing(i, FingerboardEnd.Nut).SerializeAsAttribute("Nut"),
                    GetSpacing(i, FingerboardEnd.Bridge).SerializeAsAttribute("Bridge")));
            }

            return elem;
        }

        public override void Deserialize(XElement elem)
        {
            base.Deserialize(elem);
            
            if (elem.ContainsAttribute("FixedNutWidth"))
            {
                var nutWidth = Measure.ParseInvariant(elem.Attribute("FixedNutWidth").Value);
                FixedNutWidth = nutWidth;
                _UserInputNutWidth = nutWidth;
            }

            if (elem.ContainsAttribute("NutSpacingMode"))
                NutSpacingMode = EnumHelper.Parse<StringSpacingMethod>(elem.Attribute("NutSpacingMode").Value);

            if (elem.ContainsAttribute("NutMargin"))
                NutMargin = Measure.ParseInvariant(elem.Attribute("NutMargin").Value);

            if (elem.ContainsAttribute("BridgeMargin"))
                BridgeMargin = Measure.ParseInvariant(elem.Attribute("BridgeMargin").Value);

            InitializeBridgeSpacing();
            InitializeNutSpacing();

            foreach (var spacingElem in elem.Elements("Spacing"))
            {
                int spacingIndex = spacingElem.ReadAttribute<int>("Index");
                if (spacingIndex >= 0 && spacingIndex < _BridgeSpacing.Length)
                {
                    var bridgeValue = spacingElem.ReadAttribute("Bridge", Measure.Mm(10));
                    _BridgeSpacing[spacingIndex] = bridgeValue;
                }
                if (spacingIndex >= 0 && spacingIndex < _NutSpacing.Length)
                {
                    _NutSpacing[spacingIndex] = spacingElem.ReadAttribute("Nut", _NutSpacing[spacingIndex]);
                }
            }
        }
    }
}
