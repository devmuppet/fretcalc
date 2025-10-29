using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiGen.StringedInstruments.Layout;
using SiGen.Utilities;
using SiGen.Measuring;
using SiGen.Resources;

namespace SiGen.UI.Controls.LayoutEditors
{
    public partial class StringSpacingEditor : LayoutPropertyEditor
    {
        public StringSpacingEditor()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateComboboxes();
        }

        private void UpdateComboboxes(bool preserveValues = false)
        {
            using (FlagManager.UseFlag("UpdateComboboxes"))
            {
                var alignmentList = new List<EnumHelper.EnumItem>();

                alignmentList.Add(new EnumHelper.EnumItem(StringSpacingAlignment.OuterStrings, 
                    Localizations.StringSpacingAlignment_OuterStrings));

                if (CurrentLayout == null || CurrentLayout.NumberOfStrings % 2 == 0)
                    alignmentList.Add(new EnumHelper.EnumItem(StringSpacingAlignment.MiddleString,
                        Localizations.StringSpacingAlignment_MiddleStringEven));
                else
                    alignmentList.Add(new EnumHelper.EnumItem(StringSpacingAlignment.MiddleString,
                        Localizations.StringSpacingAlignment_MiddleStringOdd));

                alignmentList.Add(new EnumHelper.EnumItem(StringSpacingAlignment.FingerboardEdges,
                    Localizations.StringSpacingAlignment_FingerboardEdges));

                cboNutSpacingAlignment.ValueMember = EnumHelper.EnumItem.ValueMember;
                cboNutSpacingAlignment.DisplayMember = EnumHelper.EnumItem.DisplayMember;
                cboBridgeSpacingAlignment.ValueMember = EnumHelper.EnumItem.ValueMember;
                cboBridgeSpacingAlignment.DisplayMember = EnumHelper.EnumItem.DisplayMember;

                cboNutSpacingAlignment.DataSource = alignmentList;
                cboBridgeSpacingAlignment.DataSource = alignmentList.ToList();//Clone

                var spacingModeList = new List<EnumHelper.EnumItem>();
                spacingModeList.Add(new EnumHelper.EnumItem(StringSpacingMethod.EqualDistance,
                    Localizations.StringSpacingMethod_EqualDistance));
                spacingModeList.Add(new EnumHelper.EnumItem(StringSpacingMethod.EqualSpacing,
                    Localizations.StringSpacingMethod_EqualSpacing));

                cboNutSpacingMethod.ValueMember = EnumHelper.EnumItem.ValueMember;
                cboNutSpacingMethod.DisplayMember = EnumHelper.EnumItem.DisplayMember;
                cboBridgeSpacingMethod.ValueMember = EnumHelper.EnumItem.ValueMember;
                cboBridgeSpacingMethod.DisplayMember = EnumHelper.EnumItem.DisplayMember;

                cboNutSpacingMethod.DataSource = spacingModeList;
                cboBridgeSpacingMethod.DataSource = spacingModeList.ToList();//Clone

                // Setup StringSpacingType dropdown
                var spacingTypeList = new List<EnumHelper.EnumItem>();
                spacingTypeList.Add(new EnumHelper.EnumItem(StringSpacingType.Simple,
                    "Simple"));
                spacingTypeList.Add(new EnumHelper.EnumItem(StringSpacingType.Manual,
                    "Manual"));
                spacingTypeList.Add(new EnumHelper.EnumItem(StringSpacingType.FixedWidth,
                    "Fixed Width"));

                cboStringSpacingType.ValueMember = EnumHelper.EnumItem.ValueMember;
                cboStringSpacingType.DisplayMember = EnumHelper.EnumItem.DisplayMember;
                cboStringSpacingType.DataSource = spacingTypeList;

                if (preserveValues && CurrentLayout != null)
                {
                    cboStringSpacingType.SelectedValue = CurrentLayout.StringSpacingMode;
                    cboNutSpacingMethod.SelectedValue = CurrentLayout.SimpleStringSpacing.NutSpacingMode;
                    cboNutSpacingAlignment.SelectedValue = CurrentLayout.SimpleStringSpacing.NutAlignment;

                    cboBridgeSpacingMethod.SelectedValue = CurrentLayout.SimpleStringSpacing.BridgeSpacingMode;
                    cboBridgeSpacingAlignment.SelectedValue = CurrentLayout.SimpleStringSpacing.BridgeAlignment;
                }
                else
                {
                    cboStringSpacingType.SelectedValue = StringSpacingType.Simple;
                    cboNutSpacingAlignment.SelectedValue = StringSpacingAlignment.OuterStrings;
                    cboBridgeSpacingAlignment.SelectedValue = StringSpacingAlignment.OuterStrings;

                    cboNutSpacingMethod.SelectedValue = StringSpacingMethod.EqualDistance;
                    cboBridgeSpacingMethod.SelectedValue = StringSpacingMethod.EqualDistance;
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }

        protected override void ReadLayoutProperties()
        {
            base.ReadLayoutProperties();
            tlpNutSpacingAuto.Enabled = (CurrentLayout != null);
            tlpBridgeSpacingAuto.Enabled = (CurrentLayout != null);
            tlpFixedWidthControls.Enabled = (CurrentLayout != null);
            
            if (CurrentLayout != null)
            {
                UpdateComboboxes();
                cboStringSpacingType.SelectedValue = CurrentLayout.StringSpacingMode;
                
                // Show/hide controls based on StringSpacingMode
                UpdateControlsForSpacingMode();
                
                if (CurrentLayout.StringSpacingMode == StringSpacingType.FixedWidth)
                {
                    // Show FixedWidth specific controls
                    mtbNutSpacing.Value = CurrentLayout.FixedWidthStringSpacing.FixedNutWidth;
                    mtbNutSpread.Value = CurrentLayout.FixedWidthStringSpacing.StringSpreadAtNut;

                    // For FixedWidth, show average bridge spacing (use first spacing as representative)
                    var bridgeSpacing = CurrentLayout.FixedWidthStringSpacing.BridgeSpacing;
                    if (bridgeSpacing.Length > 0)
                    {
                        // Show first bridge spacing as representative
                        mtbBridgeSpacing.Value = bridgeSpacing[0];
                    }
                    mtbBridgeSpread.Value = CurrentLayout.FixedWidthStringSpacing.StringSpreadAtBridge;
                    
                    // TODO: Add individual bridge spacing controls here
                }
                else
                {
                    // Show Simple/Manual string spacing controls
                    mtbNutSpacing.Value = CurrentLayout.SimpleStringSpacing.StringSpacingAtNut;
                    mtbNutSpread.Value = CurrentLayout.SimpleStringSpacing.StringSpreadAtNut;

                    mtbBridgeSpacing.Value = CurrentLayout.SimpleStringSpacing.StringSpacingAtBridge;
                    mtbBridgeSpread.Value = CurrentLayout.SimpleStringSpacing.StringSpreadAtBridge;

                    cboNutSpacingMethod.SelectedValue = CurrentLayout.SimpleStringSpacing.NutSpacingMode;
                    cboNutSpacingAlignment.SelectedValue = CurrentLayout.SimpleStringSpacing.NutAlignment;

                    cboBridgeSpacingMethod.SelectedValue = CurrentLayout.SimpleStringSpacing.BridgeSpacingMode;
                    cboBridgeSpacingAlignment.SelectedValue = CurrentLayout.SimpleStringSpacing.BridgeAlignment;
                }

                mtbNutSpacing.AllowEmptyValue = mtbNutSpread.AllowEmptyValue = false;
                mtbBridgeSpacing.AllowEmptyValue = mtbBridgeSpread.AllowEmptyValue = false;
            }
            else
            {
                mtbNutSpacing.AllowEmptyValue = mtbNutSpread.AllowEmptyValue = true;
                mtbNutSpacing.Value = Measure.Empty;
                mtbNutSpread.Value = Measure.Empty;

                mtbBridgeSpacing.AllowEmptyValue = mtbBridgeSpread.AllowEmptyValue = true;
                mtbBridgeSpacing.Value = Measure.Empty;
                mtbBridgeSpread.Value = Measure.Empty;

                cboNutSpacingMethod.SelectedItem = null;
                cboNutSpacingAlignment.SelectedItem = null;
                cboBridgeSpacingMethod.SelectedItem = null;
                cboBridgeSpacingAlignment.SelectedItem = null;
            }
        }

        protected override void OnNumberOfStringsChanged()
        {
            base.OnNumberOfStringsChanged();

            using (FlagManager.UseFlag("UpdateSpacing"))
            {
                UpdateComboboxes(true);
                mtbNutSpread.Value = CurrentLayout.SimpleStringSpacing.StringSpreadAtNut;
                mtbBridgeSpread.Value = CurrentLayout.SimpleStringSpacing.StringSpreadAtBridge;
                
                // Rebuild individual bridge spacing controls if in FixedWidth mode
                if (CurrentLayout.StringSpacingMode == StringSpacingType.FixedWidth)
                {
                    RebuildIndividualBridgeSpacingControls();
                }
            }
        }

        #region Simple Nut Spacing Events

        private void mtbNutSpacing_ValueChanged(object sender, EventArgs e)
        {
            if (!IsLoading && CurrentLayout != null && !FlagManager["UpdateSpacing"])
            {
                if (CurrentLayout.StringSpacingMode == StringSpacingType.FixedWidth)
                {
                    CurrentLayout.FixedWidthStringSpacing.FixedNutWidth = mtbNutSpacing.Value;
                    using (FlagManager.UseFlag("UpdateSpacing"))
                        mtbNutSpread.Value = CurrentLayout.StringSpacing.StringSpreadAtNut;
                }
                else
                {
                    CurrentLayout.SimpleStringSpacing.StringSpacingAtNut = mtbNutSpacing.Value;
                    using (FlagManager.UseFlag("UpdateSpacing"))
                        mtbNutSpread.Value = CurrentLayout.StringSpacing.StringSpreadAtNut;
                }
                CurrentLayout.RebuildLayout();
            }
        }

        private void mtbNutSpread_ValueChanged(object sender, EventArgs e)
        {
            if (!IsLoading && CurrentLayout != null && !FlagManager["UpdateSpacing"])
            {
                CurrentLayout.SimpleStringSpacing.StringSpreadAtNut = mtbNutSpread.Value;
                using (FlagManager.UseFlag("UpdateSpacing"))
                    mtbNutSpacing.Value = CurrentLayout.SimpleStringSpacing.StringSpacingAtNut;
                CurrentLayout.RebuildLayout();
            }
        }

        private void cboNutSpacingMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsLoading && CurrentLayout != null && !FlagManager["UpdateComboboxes"])
            {
                CurrentLayout.SimpleStringSpacing.NutSpacingMode = (StringSpacingMethod)cboNutSpacingMethod.SelectedValue;
                CurrentLayout.RebuildLayout();
            }
            if (cboNutSpacingMethod.SelectedItem != null && !FlagManager["UpdateComboboxes"])
            {
                if ((StringSpacingMethod)cboNutSpacingMethod.SelectedValue == StringSpacingMethod.EqualSpacing)
                    lblNutStringSpacing.Text = Text_AvgSpacing;
                else
                    lblNutStringSpacing.Text = Text_Spacing;
            }
        }

        private void cboNutSpacingAlignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsLoading && CurrentLayout != null && !FlagManager["UpdateComboboxes"])
            {
                CurrentLayout.SimpleStringSpacing.NutAlignment = (StringSpacingAlignment)cboNutSpacingAlignment.SelectedValue;
                CurrentLayout.RebuildLayout();
            }
        }

        #endregion

        #region Simple Bridge Spacing Events

        private void mtbBridgeSpacing_ValueChanged(object sender, EventArgs e)
        {
            if (!IsLoading && CurrentLayout != null && !FlagManager["UpdateSpacing"])
            {
                // Only allow editing in Simple mode, not in FixedWidth mode
                if (CurrentLayout.StringSpacingMode != StringSpacingType.FixedWidth)
                {
                    CurrentLayout.SimpleStringSpacing.StringSpacingAtBridge = mtbBridgeSpacing.Value;
                    using (FlagManager.UseFlag("UpdateSpacing"))
                        mtbBridgeSpread.Value = CurrentLayout.StringSpacing.StringSpreadAtBridge;
                    CurrentLayout.RebuildLayout();
                }
            }
        }

        private void mtbBridgeSpread_ValueChanged(object sender, EventArgs e)
        {
            if (!IsLoading && CurrentLayout != null && !FlagManager["UpdateSpacing"])
            {
                CurrentLayout.SimpleStringSpacing.StringSpreadAtBridge = mtbBridgeSpread.Value;
                using (FlagManager.UseFlag("UpdateSpacing"))
                    mtbBridgeSpacing.Value = CurrentLayout.SimpleStringSpacing.StringSpacingAtBridge;
                CurrentLayout.RebuildLayout();
            }
        }

        private void cboBridgeSpacingMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsLoading && CurrentLayout != null && !FlagManager["UpdateComboboxes"])
            {
                CurrentLayout.SimpleStringSpacing.BridgeSpacingMode = (StringSpacingMethod)cboBridgeSpacingMethod.SelectedValue;
                CurrentLayout.RebuildLayout();
            }
            if (cboBridgeSpacingMethod.SelectedItem != null)
            {
                if ((StringSpacingMethod)cboBridgeSpacingMethod.SelectedValue == StringSpacingMethod.EqualSpacing)
                    lblBridgeStringSpacing.Text = Text_AvgSpacing;
                else
                    lblBridgeStringSpacing.Text = Text_Spacing;
            }
        }

        private void cboBridgeSpacingAlignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsLoading && CurrentLayout != null && !FlagManager["UpdateComboboxes"])
            {
                CurrentLayout.SimpleStringSpacing.BridgeAlignment = (StringSpacingAlignment)cboBridgeSpacingAlignment.SelectedValue;
                CurrentLayout.RebuildLayout();
            }
        }


        #endregion

        private void mtbSpacings_ValueChanging(object sender, MeasureTextbox.ValueChangingEventArgs e)
        {
            if((e.NewValue.IsEmpty && e.UserChange) || (!e.NewValue.IsEmpty && e.NewValue.NormalizedValue < 0.1))
            {
                e.Cancel = true;
                System.Media.SystemSounds.Exclamation.Play();
            }
        }

        private void cboStringSpacingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsLoading && CurrentLayout != null && !FlagManager["UpdateComboboxes"])
            {
                CurrentLayout.StringSpacingMode = (StringSpacingType)cboStringSpacingType.SelectedValue;
                UpdateControlsForSpacingMode();
                CurrentLayout.RebuildLayout();
            }
        }

        private void UpdateControlsForSpacingMode()
        {
            if (CurrentLayout == null) return;

            if (CurrentLayout.StringSpacingMode == StringSpacingType.FixedWidth)
            {
                // Show FixedWidth mode: change labels to indicate fixed width behavior
                lblNutStringSpacing.Text = "Fixed Nut Width";
                lblBridgeStringSpacing.Text = "Fixed Bridge Width";
                
                // Make bridge spacing read-only (shows sum of individual spacings)
                mtbBridgeSpacing.ReadOnly = true;
                mtbBridgeSpacing.BackColor = System.Drawing.SystemColors.Control;
                
                // Hide Total Spread fields - not needed in FixedWidth mode
                lblNutTotalSpread.Visible = false;
                mtbNutSpread.Visible = false;
                lblBridgeTotalSpread.Visible = false;
                mtbBridgeSpread.Visible = false;
                
                // Hide alignment controls that don't apply to FixedWidth mode
                cboNutSpacingAlignment.Visible = false;
                lblNutSpacingAlignment.Visible = false;
                cboBridgeSpacingAlignment.Visible = false;
                lblBridgeSpacingAlignment.Visible = false;
                
                // Hide method controls that don't apply to FixedWidth mode
                cboNutSpacingMethod.Visible = false;
                lblNutSpacingMethod.Visible = false;
                cboBridgeSpacingMethod.Visible = false;
                lblBridgeSpacingMethod.Visible = false;
                
                // Show FixedWidth-specific controls
                tlpFixedWidthControls.Visible = true;
                
                // Update fixed width values from layout
                using (FlagManager.UseFlag("UpdateSpacing"))
                {
                    mtbNutSpacing.Value = CurrentLayout.FixedWidthStringSpacing.FixedNutWidth;
                    // Bridge width is sum of individual spacings, shown as read-only info
                    var bridgeSpacing = CurrentLayout.FixedWidthStringSpacing.BridgeSpacing;
                    Measure totalBridgeWidth = Measure.Zero;
                    foreach (var spacing in bridgeSpacing)
                    {
                        totalBridgeWidth += spacing;
                    }
                    mtbBridgeSpacing.Value = totalBridgeWidth;
                }
                
                // Rebuild individual bridge spacing controls
                RebuildIndividualBridgeSpacingControls();
            }
            else
            {
                // Show Simple/Manual mode: restore original labels and controls
                lblNutStringSpacing.Text = Text_Spacing;
                lblBridgeStringSpacing.Text = Text_Spacing;
                
                // Make bridge spacing editable again
                mtbBridgeSpacing.ReadOnly = false;
                mtbBridgeSpacing.BackColor = System.Drawing.SystemColors.Window;
                
                // Show Total Spread fields
                lblNutTotalSpread.Visible = true;
                mtbNutSpread.Visible = true;
                lblBridgeTotalSpread.Visible = true;
                mtbBridgeSpread.Visible = true;
                
                // Show alignment controls
                cboNutSpacingAlignment.Visible = true;
                lblNutSpacingAlignment.Visible = true;
                cboBridgeSpacingAlignment.Visible = true;
                lblBridgeSpacingAlignment.Visible = true;
                
                // Show method controls
                cboNutSpacingMethod.Visible = true;
                lblNutSpacingMethod.Visible = true;
                cboBridgeSpacingMethod.Visible = true;
                lblBridgeSpacingMethod.Visible = true;
                
                // Hide FixedWidth-specific controls
                tlpFixedWidthControls.Visible = false;
            }
        }

        private void RebuildIndividualBridgeSpacingControls()
        {
            if (CurrentLayout == null) return;
            
            // Clear existing controls
            tlpIndividualBridgeSpacing.Controls.Clear();
            tlpIndividualBridgeSpacing.RowStyles.Clear();
            
            int numStrings = CurrentLayout.NumberOfStrings;
            int numGaps = numStrings - 1;
            
            if (numGaps <= 0) return;
            
            // Set up rows
            tlpIndividualBridgeSpacing.RowCount = numGaps;
            for (int i = 0; i < numGaps; i++)
            {
                tlpIndividualBridgeSpacing.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            }
            
            // Get bridge spacing array
            var bridgeSpacing = CurrentLayout.FixedWidthStringSpacing.BridgeSpacing;
            
            // Create controls for each gap
            // String order matches String Configuration table: 1=treble (top), n=bass (bottom)
            for (int i = 0; i < numGaps; i++)
            {
                // Label for the gap (e.g., "String 1-2:")
                var label = new System.Windows.Forms.Label();
                label.Text = string.Format("String {0}-{1}:", i + 1, i + 2);
                label.Dock = System.Windows.Forms.DockStyle.Fill;
                label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                label.AutoSize = false;
                
                // TextBox for the spacing value
                var textbox = new SiGen.UI.Controls.MeasureTextbox();
                textbox.Dock = System.Windows.Forms.DockStyle.Fill;
                textbox.Tag = i; // Store the index
                
                // Set the value from the array
                if (i < bridgeSpacing.Length)
                {
                    using (FlagManager.UseFlag("UpdateSpacing"))
                    {
                        textbox.Value = bridgeSpacing[i];
                    }
                }
                
                // Add event handler
                textbox.ValueChanged += IndividualBridgeSpacing_ValueChanged;
                
                // Add to table
                tlpIndividualBridgeSpacing.Controls.Add(label, 0, i);
                tlpIndividualBridgeSpacing.Controls.Add(textbox, 1, i);
            }
        }

        private string GetStringName(int stringIndex)
        {
            if (CurrentLayout == null || stringIndex < 0 || stringIndex >= CurrentLayout.NumberOfStrings)
                return (stringIndex + 1).ToString();
            
            var str = CurrentLayout.Strings[stringIndex];
            if (str != null && str.Tuning != null)
            {
                return str.Tuning.Note.NoteName.ToString();
            }
            
            // Fallback to string number
            return (stringIndex + 1).ToString();
        }

        private void IndividualBridgeSpacing_ValueChanged(object sender, EventArgs e)
        {
            if (!IsLoading && CurrentLayout != null && !FlagManager["UpdateSpacing"])
            {
                var textbox = sender as SiGen.UI.Controls.MeasureTextbox;
                if (textbox != null && textbox.Tag is int)
                {
                    int index = (int)textbox.Tag;
                    var bridgeSpacing = CurrentLayout.FixedWidthStringSpacing.BridgeSpacing;
                    
                    if (index >= 0 && index < bridgeSpacing.Length)
                    {
                        bridgeSpacing[index] = textbox.Value;
                        CurrentLayout.RebuildLayout();
                        
                        // Update the total bridge width display
                        using (FlagManager.UseFlag("UpdateSpacing"))
                        {
                            Measure totalBridgeWidth = Measure.Zero;
                            foreach (var spacing in bridgeSpacing)
                            {
                                totalBridgeWidth += spacing;
                            }
                            mtbBridgeSpacing.Value = totalBridgeWidth;
                        }
                    }
                }
            }
        }
    }
}
