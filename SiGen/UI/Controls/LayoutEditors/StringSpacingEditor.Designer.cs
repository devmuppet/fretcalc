namespace SiGen.UI.Controls.LayoutEditors
{
    partial class StringSpacingEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StringSpacingEditor));
            this.mtbNutSpacing = new SiGen.UI.Controls.MeasureTextbox();
            this.mtbNutSpread = new SiGen.UI.Controls.MeasureTextbox();
            this.mtbBridgeSpacing = new SiGen.UI.Controls.MeasureTextbox();
            this.mtbBridgeSpread = new SiGen.UI.Controls.MeasureTextbox();
            this.lblNutStringSpacing = new System.Windows.Forms.Label();
            this.cboStringSpacingType = new System.Windows.Forms.ComboBox();
            this.lblStringSpacingType = new System.Windows.Forms.Label();
            this.cboNutSpacingMethod = new System.Windows.Forms.ComboBox();
            this.lblNutSpacingMethod = new System.Windows.Forms.Label();
            this.lblNutTotalSpread = new System.Windows.Forms.Label();
            this.lblBridgeTotalSpread = new System.Windows.Forms.Label();
            this.lblBridgeStringSpacing = new System.Windows.Forms.Label();
            this.tlpNutSpacingAuto = new System.Windows.Forms.TableLayoutPanel();
            this.lblNutSpacing = new System.Windows.Forms.Label();
            this.cboNutSpacingAlignment = new System.Windows.Forms.ComboBox();
            this.lblNutSpacingAlignment = new System.Windows.Forms.Label();
            this.tlpBridgeSpacingAuto = new System.Windows.Forms.TableLayoutPanel();
            this.cboBridgeSpacingAlignment = new System.Windows.Forms.ComboBox();
            this.cboBridgeSpacingMethod = new System.Windows.Forms.ComboBox();
            this.lblBridgeSpacingMethod = new System.Windows.Forms.Label();
            this.lblBridgeSpacing = new System.Windows.Forms.Label();
            this.lblBridgeSpacingAlignment = new System.Windows.Forms.Label();
            this.tlpFixedWidthControls = new System.Windows.Forms.TableLayoutPanel();
            this.lblIndividualBridgeSpacing = new System.Windows.Forms.Label();
            this.tlpIndividualBridgeSpacing = new System.Windows.Forms.TableLayoutPanel();
            this.LocStrings = new SiGen.Localization.LocalizableStringList(this.components);
            this.Text_Spacing = new SiGen.Localization.LocalizableString(this.components);
            this.Text_AvgSpacing = new SiGen.Localization.LocalizableString(this.components);
            this.tlpNutSpacingAuto.SuspendLayout();
            this.tlpBridgeSpacingAuto.SuspendLayout();
            this.tlpFixedWidthControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // mtbNutSpacing
            // 
            resources.ApplyResources(this.mtbNutSpacing, "mtbNutSpacing");
            this.mtbNutSpacing.Name = "mtbNutSpacing";
            this.mtbNutSpacing.ValueChanging += new System.EventHandler<SiGen.UI.Controls.MeasureTextbox.ValueChangingEventArgs>(this.mtbSpacings_ValueChanging);
            this.mtbNutSpacing.ValueChanged += new System.EventHandler(this.mtbNutSpacing_ValueChanged);
            // 
            // mtbNutSpread
            // 
            resources.ApplyResources(this.mtbNutSpread, "mtbNutSpread");
            this.mtbNutSpread.Name = "mtbNutSpread";
            this.mtbNutSpread.ValueChanging += new System.EventHandler<SiGen.UI.Controls.MeasureTextbox.ValueChangingEventArgs>(this.mtbSpacings_ValueChanging);
            this.mtbNutSpread.ValueChanged += new System.EventHandler(this.mtbNutSpread_ValueChanged);
            // 
            // mtbBridgeSpacing
            // 
            resources.ApplyResources(this.mtbBridgeSpacing, "mtbBridgeSpacing");
            this.mtbBridgeSpacing.Name = "mtbBridgeSpacing";
            this.mtbBridgeSpacing.ValueChanging += new System.EventHandler<SiGen.UI.Controls.MeasureTextbox.ValueChangingEventArgs>(this.mtbSpacings_ValueChanging);
            this.mtbBridgeSpacing.ValueChanged += new System.EventHandler(this.mtbBridgeSpacing_ValueChanged);
            // 
            // mtbBridgeSpread
            // 
            resources.ApplyResources(this.mtbBridgeSpread, "mtbBridgeSpread");
            this.mtbBridgeSpread.Name = "mtbBridgeSpread";
            this.mtbBridgeSpread.ValueChanging += new System.EventHandler<SiGen.UI.Controls.MeasureTextbox.ValueChangingEventArgs>(this.mtbSpacings_ValueChanging);
            this.mtbBridgeSpread.ValueChanged += new System.EventHandler(this.mtbBridgeSpread_ValueChanged);
            // 
            // lblNutStringSpacing
            // 
            resources.ApplyResources(this.lblNutStringSpacing, "lblNutStringSpacing");
            this.lblNutStringSpacing.Name = "lblNutStringSpacing";
            // 
            // lblStringSpacingType
            // 
            this.lblStringSpacingType.AutoSize = true;
            this.lblStringSpacingType.Location = new System.Drawing.Point(6, 9);
            this.lblStringSpacingType.Name = "lblStringSpacingType";
            this.lblStringSpacingType.Size = new System.Drawing.Size(95, 13);
            this.lblStringSpacingType.TabIndex = 0;
            this.lblStringSpacingType.Text = "String Spacing Type:";
            // 
            // cboStringSpacingType
            // 
            this.cboStringSpacingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStringSpacingType.FormattingEnabled = true;
            this.cboStringSpacingType.Location = new System.Drawing.Point(107, 6);
            this.cboStringSpacingType.Name = "cboStringSpacingType";
            this.cboStringSpacingType.Size = new System.Drawing.Size(121, 21);
            this.cboStringSpacingType.TabIndex = 1;
            this.cboStringSpacingType.SelectedIndexChanged += new System.EventHandler(this.cboStringSpacingType_SelectedIndexChanged);
            // 
            // cboNutSpacingMethod
            // 
            resources.ApplyResources(this.cboNutSpacingMethod, "cboNutSpacingMethod");
            this.tlpNutSpacingAuto.SetColumnSpan(this.cboNutSpacingMethod, 2);
            this.cboNutSpacingMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNutSpacingMethod.FormattingEnabled = true;
            this.cboNutSpacingMethod.Name = "cboNutSpacingMethod";
            this.cboNutSpacingMethod.SelectedIndexChanged += new System.EventHandler(this.cboNutSpacingMethod_SelectedIndexChanged);
            // 
            // lblNutSpacingMethod
            // 
            resources.ApplyResources(this.lblNutSpacingMethod, "lblNutSpacingMethod");
            this.lblNutSpacingMethod.Name = "lblNutSpacingMethod";
            // 
            // lblNutTotalSpread
            // 
            resources.ApplyResources(this.lblNutTotalSpread, "lblNutTotalSpread");
            this.lblNutTotalSpread.Name = "lblNutTotalSpread";
            // 
            // lblBridgeTotalSpread
            // 
            resources.ApplyResources(this.lblBridgeTotalSpread, "lblBridgeTotalSpread");
            this.lblBridgeTotalSpread.Name = "lblBridgeTotalSpread";
            // 
            // lblBridgeStringSpacing
            // 
            resources.ApplyResources(this.lblBridgeStringSpacing, "lblBridgeStringSpacing");
            this.lblBridgeStringSpacing.Name = "lblBridgeStringSpacing";
            // 
            // tlpNutSpacingAuto
            // 
            resources.ApplyResources(this.tlpNutSpacingAuto, "tlpNutSpacingAuto");
            this.tlpNutSpacingAuto.Location = new System.Drawing.Point(0, 35); // Move down to make room for StringSpacingType controls
            this.tlpNutSpacingAuto.Controls.Add(this.lblStringSpacingType, 0, 0);
            this.tlpNutSpacingAuto.Controls.Add(this.cboStringSpacingType, 1, 0);
            this.tlpNutSpacingAuto.Controls.Add(this.lblNutSpacingMethod, 0, 3);
            this.tlpNutSpacingAuto.Controls.Add(this.lblNutSpacing, 0, 2);
            this.tlpNutSpacingAuto.Controls.Add(this.cboNutSpacingMethod, 1, 3);
            this.tlpNutSpacingAuto.Controls.Add(this.mtbNutSpacing, 1, 2);
            this.tlpNutSpacingAuto.Controls.Add(this.mtbNutSpread, 2, 2);
            this.tlpNutSpacingAuto.Controls.Add(this.lblNutTotalSpread, 2, 1);
            this.tlpNutSpacingAuto.Controls.Add(this.lblNutStringSpacing, 1, 1);
            this.tlpNutSpacingAuto.Controls.Add(this.cboNutSpacingAlignment, 1, 4);
            this.tlpNutSpacingAuto.Controls.Add(this.lblNutSpacingAlignment, 0, 4);
            this.tlpNutSpacingAuto.Name = "tlpNutSpacingAuto";
            // 
            // lblNutSpacing
            // 
            resources.ApplyResources(this.lblNutSpacing, "lblNutSpacing");
            this.lblNutSpacing.Name = "lblNutSpacing";
            // 
            // cboNutSpacingAlignment
            // 
            resources.ApplyResources(this.cboNutSpacingAlignment, "cboNutSpacingAlignment");
            this.tlpNutSpacingAuto.SetColumnSpan(this.cboStringSpacingType, 2);
            this.tlpNutSpacingAuto.SetColumnSpan(this.cboNutSpacingAlignment, 2);
            this.cboNutSpacingAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNutSpacingAlignment.FormattingEnabled = true;
            this.cboNutSpacingAlignment.Name = "cboNutSpacingAlignment";
            this.cboNutSpacingAlignment.SelectedIndexChanged += new System.EventHandler(this.cboNutSpacingAlignment_SelectedIndexChanged);
            // 
            // lblNutSpacingAlignment
            // 
            resources.ApplyResources(this.lblNutSpacingAlignment, "lblNutSpacingAlignment");
            this.lblNutSpacingAlignment.Name = "lblNutSpacingAlignment";
            // 
            // tlpBridgeSpacingAuto
            // 
            resources.ApplyResources(this.tlpBridgeSpacingAuto, "tlpBridgeSpacingAuto");
            this.tlpBridgeSpacingAuto.Location = new System.Drawing.Point(0, 128); // Move down to make room for StringSpacingType controls (93 + 35 offset)
            this.tlpBridgeSpacingAuto.Controls.Add(this.cboBridgeSpacingAlignment, 1, 3);
            this.tlpBridgeSpacingAuto.Controls.Add(this.cboBridgeSpacingMethod, 1, 2);
            this.tlpBridgeSpacingAuto.Controls.Add(this.lblBridgeSpacingMethod, 0, 2);
            this.tlpBridgeSpacingAuto.Controls.Add(this.lblBridgeSpacing, 0, 1);
            this.tlpBridgeSpacingAuto.Controls.Add(this.mtbBridgeSpacing, 1, 1);
            this.tlpBridgeSpacingAuto.Controls.Add(this.lblBridgeStringSpacing, 1, 0);
            this.tlpBridgeSpacingAuto.Controls.Add(this.mtbBridgeSpread, 2, 1);
            this.tlpBridgeSpacingAuto.Controls.Add(this.lblBridgeTotalSpread, 2, 0);
            this.tlpBridgeSpacingAuto.Controls.Add(this.lblBridgeSpacingAlignment, 0, 3);
            this.tlpBridgeSpacingAuto.Name = "tlpBridgeSpacingAuto";
            // 
            // cboBridgeSpacingAlignment
            // 
            resources.ApplyResources(this.cboBridgeSpacingAlignment, "cboBridgeSpacingAlignment");
            this.tlpBridgeSpacingAuto.SetColumnSpan(this.cboBridgeSpacingAlignment, 2);
            this.cboBridgeSpacingAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBridgeSpacingAlignment.FormattingEnabled = true;
            this.cboBridgeSpacingAlignment.Name = "cboBridgeSpacingAlignment";
            this.cboBridgeSpacingAlignment.SelectedIndexChanged += new System.EventHandler(this.cboBridgeSpacingAlignment_SelectedIndexChanged);
            // 
            // cboBridgeSpacingMethod
            // 
            resources.ApplyResources(this.cboBridgeSpacingMethod, "cboBridgeSpacingMethod");
            this.tlpBridgeSpacingAuto.SetColumnSpan(this.cboBridgeSpacingMethod, 2);
            this.cboBridgeSpacingMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBridgeSpacingMethod.FormattingEnabled = true;
            this.cboBridgeSpacingMethod.Name = "cboBridgeSpacingMethod";
            this.cboBridgeSpacingMethod.SelectedIndexChanged += new System.EventHandler(this.cboBridgeSpacingMethod_SelectedIndexChanged);
            // 
            // lblBridgeSpacingMethod
            // 
            resources.ApplyResources(this.lblBridgeSpacingMethod, "lblBridgeSpacingMethod");
            this.lblBridgeSpacingMethod.Name = "lblBridgeSpacingMethod";
            // 
            // lblBridgeSpacing
            // 
            resources.ApplyResources(this.lblBridgeSpacing, "lblBridgeSpacing");
            this.lblBridgeSpacing.Name = "lblBridgeSpacing";
            // 
            // lblBridgeSpacingAlignment
            // 
            resources.ApplyResources(this.lblBridgeSpacingAlignment, "lblBridgeSpacingAlignment");
            this.lblBridgeSpacingAlignment.Name = "lblBridgeSpacingAlignment";
            // 
            // LocStrings
            // 
            this.LocStrings.Items.Add(this.Text_Spacing);
            this.LocStrings.Items.Add(this.Text_AvgSpacing);
            // 
            // Text_Spacing
            // 
            resources.ApplyResources(this.Text_Spacing, "Text_Spacing");
            // 
            // Text_AvgSpacing
            // 
            resources.ApplyResources(this.Text_AvgSpacing, "Text_AvgSpacing");
            // 
            // tlpFixedWidthControls
            // 
            this.tlpFixedWidthControls.ColumnCount = 2;
            this.tlpFixedWidthControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpFixedWidthControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFixedWidthControls.Controls.Add(this.lblIndividualBridgeSpacing, 0, 0);
            this.tlpFixedWidthControls.Controls.Add(this.tlpIndividualBridgeSpacing, 0, 1);
            this.tlpFixedWidthControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpFixedWidthControls.Location = new System.Drawing.Point(0, 200);
            this.tlpFixedWidthControls.Name = "tlpFixedWidthControls";
            this.tlpFixedWidthControls.RowCount = 2;
            this.tlpFixedWidthControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpFixedWidthControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpFixedWidthControls.Size = new System.Drawing.Size(400, 100);
            this.tlpFixedWidthControls.TabIndex = 20;
            this.tlpFixedWidthControls.Visible = false;
            // 
            // lblIndividualBridgeSpacing
            // 
            this.lblIndividualBridgeSpacing.AutoSize = true;
            this.lblIndividualBridgeSpacing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFixedWidthControls.SetColumnSpan(this.lblIndividualBridgeSpacing, 2);
            this.lblIndividualBridgeSpacing.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblIndividualBridgeSpacing.Location = new System.Drawing.Point(3, 3);
            this.lblIndividualBridgeSpacing.Name = "lblIndividualBridgeSpacing";
            this.lblIndividualBridgeSpacing.Size = new System.Drawing.Size(394, 14);
            this.lblIndividualBridgeSpacing.TabIndex = 0;
            this.lblIndividualBridgeSpacing.Text = "Individual Bridge Spacing:";
            this.lblIndividualBridgeSpacing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpIndividualBridgeSpacing
            // 
            this.tlpIndividualBridgeSpacing.AutoSize = true;
            this.tlpIndividualBridgeSpacing.ColumnCount = 2;
            this.tlpFixedWidthControls.SetColumnSpan(this.tlpIndividualBridgeSpacing, 2);
            this.tlpIndividualBridgeSpacing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpIndividualBridgeSpacing.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpIndividualBridgeSpacing.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpIndividualBridgeSpacing.Location = new System.Drawing.Point(3, 23);
            this.tlpIndividualBridgeSpacing.Name = "tlpIndividualBridgeSpacing";
            this.tlpIndividualBridgeSpacing.RowCount = 1;
            this.tlpIndividualBridgeSpacing.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpIndividualBridgeSpacing.Size = new System.Drawing.Size(394, 26);
            this.tlpIndividualBridgeSpacing.TabIndex = 1;
            // 
            // StringSpacingEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpFixedWidthControls);
            this.Controls.Add(this.tlpBridgeSpacingAuto);
            this.Controls.Add(this.tlpNutSpacingAuto);
            this.Name = "StringSpacingEditor";
            this.tlpNutSpacingAuto.ResumeLayout(false);
            this.tlpNutSpacingAuto.PerformLayout();
            this.tlpBridgeSpacingAuto.ResumeLayout(false);
            this.tlpBridgeSpacingAuto.PerformLayout();
            this.tlpFixedWidthControls.ResumeLayout(false);
            this.tlpFixedWidthControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MeasureTextbox mtbNutSpacing;
        private MeasureTextbox mtbNutSpread;
        private MeasureTextbox mtbBridgeSpacing;
        private MeasureTextbox mtbBridgeSpread;
        private System.Windows.Forms.Label lblNutStringSpacing;
        private System.Windows.Forms.Label lblNutTotalSpread;
        private System.Windows.Forms.Label lblBridgeTotalSpread;
        private System.Windows.Forms.Label lblBridgeStringSpacing;
        private System.Windows.Forms.ComboBox cboNutSpacingMethod;
        private System.Windows.Forms.Label lblNutSpacingMethod;
        private System.Windows.Forms.TableLayoutPanel tlpNutSpacingAuto;
        private System.Windows.Forms.ComboBox cboNutSpacingAlignment;
        private System.Windows.Forms.Label lblNutSpacing;
        private System.Windows.Forms.Label lblNutSpacingAlignment;
        private System.Windows.Forms.TableLayoutPanel tlpBridgeSpacingAuto;
        private System.Windows.Forms.ComboBox cboBridgeSpacingMethod;
        private System.Windows.Forms.Label lblBridgeSpacingMethod;
        private System.Windows.Forms.Label lblBridgeSpacing;
        private System.Windows.Forms.ComboBox cboBridgeSpacingAlignment;
        private System.Windows.Forms.Label lblBridgeSpacingAlignment;
        private Localization.LocalizableStringList LocStrings;
        private Localization.LocalizableString Text_Spacing;
        private Localization.LocalizableString Text_AvgSpacing;
        private System.Windows.Forms.ComboBox cboStringSpacingType;
        private System.Windows.Forms.Label lblStringSpacingType;
        private System.Windows.Forms.TableLayoutPanel tlpFixedWidthControls;
        private System.Windows.Forms.Label lblIndividualBridgeSpacing;
        private System.Windows.Forms.TableLayoutPanel tlpIndividualBridgeSpacing;
    }
}
