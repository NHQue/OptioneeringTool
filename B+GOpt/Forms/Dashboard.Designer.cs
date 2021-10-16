
using Rhino;

namespace B_GOpt.Forms
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        public string documentName = RhinoDoc.ActiveDoc.Name;


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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.lblProjectName = new System.Windows.Forms.Label();
            this.btnCalculate = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblFloorHeight = new System.Windows.Forms.Label();
            this.lblSpacX = new System.Windows.Forms.Label();
            this.lblSpacY = new System.Windows.Forms.Label();
            this.lblFloorHeightValue = new System.Windows.Forms.Label();
            this.tbarSpacX = new ComponentFactory.Krypton.Toolkit.KryptonTrackBar();
            this.tbarSpacY = new ComponentFactory.Krypton.Toolkit.KryptonTrackBar();
            this.tbarFloorHeight = new ComponentFactory.Krypton.Toolkit.KryptonTrackBar();
            this.lblSpacYValue = new System.Windows.Forms.Label();
            this.lblMat = new System.Windows.Forms.Label();
            this.panelMat = new System.Windows.Forms.Panel();
            this.btnSelectBuilding = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSelectCore = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.picBG = new System.Windows.Forms.PictureBox();
            this.lblRes = new System.Windows.Forms.Label();
            this.lblSrfArea = new System.Windows.Forms.Label();
            this.lblCO2 = new System.Windows.Forms.Label();
            this.lblSpacXValue = new System.Windows.Forms.Label();
            this.chartCO2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblFAR = new System.Windows.Forms.Label();
            this.lblCosts = new System.Windows.Forms.Label();
            this.lblProgramm = new System.Windows.Forms.Label();
            this.lblStructSystem = new System.Windows.Forms.Label();
            this.lblUI = new System.Windows.Forms.Label();
            this.lblFarValue = new System.Windows.Forms.Label();
            this.lblSurfaceValue = new System.Windows.Forms.Label();
            this.lblCostsValue = new System.Windows.Forms.Label();
            this.lblCO2Value = new System.Windows.Forms.Label();
            this.panelProgramm = new System.Windows.Forms.Panel();
            this.panelStructSystem = new System.Windows.Forms.Panel();
            this.rbtnSlabSystem = new B_GOpt.CustomControls.CustomRadioButton();
            this.rbtnGirderSystem = new B_GOpt.CustomControls.CustomRadioButton();
            this.rbtnIndustrial = new B_GOpt.CustomControls.CustomRadioButton();
            this.rbtnOffice = new B_GOpt.CustomControls.CustomRadioButton();
            this.rbtnResidential = new B_GOpt.CustomControls.CustomRadioButton();
            this.rbtnTimberMat = new B_GOpt.CustomControls.CustomRadioButton();
            this.rbtnConcreteMat = new B_GOpt.CustomControls.CustomRadioButton();
            this.rbtnSteelMat = new B_GOpt.CustomControls.CustomRadioButton();
            this.panelMat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCO2)).BeginInit();
            this.panelProgramm.SuspendLayout();
            this.panelStructSystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.ButtonSpecs.FormClose.Image = global::B_GOpt.Properties.Resources.mc_red;
            this.kryptonPalette1.ButtonSpecs.FormClose.ImageStates.ImagePressed = global::B_GOpt.Properties.Resources.sign_error_icon;
            this.kryptonPalette1.ButtonSpecs.FormClose.ImageStates.ImageTracking = global::B_GOpt.Properties.Resources.sign_error_icon;
            this.kryptonPalette1.ButtonSpecs.FormMax.Image = global::B_GOpt.Properties.Resources.mc_green;
            this.kryptonPalette1.ButtonSpecs.FormMax.ImageStates.ImagePressed = global::B_GOpt.Properties.Resources.sign_add_icon;
            this.kryptonPalette1.ButtonSpecs.FormMax.ImageStates.ImageTracking = global::B_GOpt.Properties.Resources.sign_add_icon;
            this.kryptonPalette1.ButtonSpecs.FormMin.Image = global::B_GOpt.Properties.Resources.mc_yellw;
            this.kryptonPalette1.ButtonSpecs.FormMin.ImageStates.ImagePressed = global::B_GOpt.Properties.Resources.sign_minus_icon;
            this.kryptonPalette1.ButtonSpecs.FormMin.ImageStates.ImageTracking = global::B_GOpt.Properties.Resources.sign_minus_icon;
            this.kryptonPalette1.ButtonSpecs.FormRestore.Image = global::B_GOpt.Properties.Resources.mc_green;
            this.kryptonPalette1.ButtonSpecs.FormRestore.ImageStates.ImagePressed = global::B_GOpt.Properties.Resources.mc_yellw;
            this.kryptonPalette1.ButtonSpecs.FormRestore.ImageStates.ImageTracking = global::B_GOpt.Properties.Resources.mc_green;
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateNormal.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateNormal.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateNormal.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateNormal.Border.Width = 0;
            this.kryptonPalette1.ButtonStyles.ButtonForm.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StatePressed.Border.Width = 0;
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonForm.StateTracking.Border.Width = 0;
            this.kryptonPalette1.ButtonStyles.ButtonFormClose.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonFormClose.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonFormClose.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonFormClose.StatePressed.Border.Width = 0;
            this.kryptonPalette1.ButtonStyles.ButtonFormClose.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonFormClose.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.ButtonStyles.ButtonFormClose.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.ButtonStyles.ButtonFormClose.StateTracking.Border.Width = 0;
            this.kryptonPalette1.FormStyles.FormCommon.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.FormStyles.FormCommon.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.FormStyles.FormCommon.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.FormStyles.FormCommon.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.None;
            this.kryptonPalette1.FormStyles.FormCommon.StateCommon.Border.Rounding = 12;
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.FormStyles.FormMain.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.ButtonEdgeInset = 10;
            this.kryptonPalette1.HeaderStyles.HeaderForm.StateCommon.Content.Padding = new System.Windows.Forms.Padding(10, -1, -1, -1);
            // 
            // lblProjectName
            // 
            this.lblProjectName.Font = new System.Drawing.Font("Lato", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblProjectName.Location = new System.Drawing.Point(0, 9);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(334, 50);
            this.lblProjectName.TabIndex = 1;
            this.lblProjectName.Text = "Project: xx.xx";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCalculate.Location = new System.Drawing.Point(6, 699);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnCalculate.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnCalculate.OverrideDefault.Back.ColorAngle = 45F;
            this.btnCalculate.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnCalculate.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnCalculate.OverrideDefault.Border.ColorAngle = 45F;
            this.btnCalculate.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCalculate.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCalculate.OverrideDefault.Border.Rounding = 20;
            this.btnCalculate.OverrideDefault.Border.Width = 1;
            this.btnCalculate.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnCalculate.Size = new System.Drawing.Size(123, 43);
            this.btnCalculate.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnCalculate.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnCalculate.StateCommon.Back.ColorAngle = 45F;
            this.btnCalculate.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnCalculate.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnCalculate.StateCommon.Border.ColorAngle = 45F;
            this.btnCalculate.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCalculate.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCalculate.StateCommon.Border.Rounding = 20;
            this.btnCalculate.StateCommon.Border.Width = 1;
            this.btnCalculate.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.White;
            this.btnCalculate.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.White;
            this.btnCalculate.StateCommon.Content.ShortText.Font = new System.Drawing.Font("IBM Plex Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnCalculate.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnCalculate.StatePressed.Back.ColorAngle = 135F;
            this.btnCalculate.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnCalculate.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnCalculate.StatePressed.Border.ColorAngle = 135F;
            this.btnCalculate.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCalculate.StatePressed.Border.Rounding = 20;
            this.btnCalculate.StatePressed.Border.Width = 1;
            this.btnCalculate.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnCalculate.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnCalculate.StateTracking.Back.ColorAngle = 45F;
            this.btnCalculate.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnCalculate.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnCalculate.StateTracking.Border.ColorAngle = 45F;
            this.btnCalculate.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnCalculate.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnCalculate.StateTracking.Border.Rounding = 20;
            this.btnCalculate.StateTracking.Border.Width = 1;
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.Values.Text = "Calculate";
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lblFloorHeight
            // 
            this.lblFloorHeight.Font = new System.Drawing.Font("Lato", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFloorHeight.ForeColor = System.Drawing.Color.Black;
            this.lblFloorHeight.Location = new System.Drawing.Point(2, 290);
            this.lblFloorHeight.Name = "lblFloorHeight";
            this.lblFloorHeight.Size = new System.Drawing.Size(117, 26);
            this.lblFloorHeight.TabIndex = 9;
            this.lblFloorHeight.Text = "Floor Height";
            // 
            // lblSpacX
            // 
            this.lblSpacX.Font = new System.Drawing.Font("Lato", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpacX.ForeColor = System.Drawing.Color.Black;
            this.lblSpacX.Location = new System.Drawing.Point(4, 316);
            this.lblSpacX.Name = "lblSpacX";
            this.lblSpacX.Size = new System.Drawing.Size(188, 26);
            this.lblSpacX.TabIndex = 10;
            this.lblSpacX.Text = "Spacing in x-Direction";
            // 
            // lblSpacY
            // 
            this.lblSpacY.Font = new System.Drawing.Font("Lato", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpacY.ForeColor = System.Drawing.Color.Black;
            this.lblSpacY.Location = new System.Drawing.Point(4, 350);
            this.lblSpacY.Name = "lblSpacY";
            this.lblSpacY.Size = new System.Drawing.Size(188, 26);
            this.lblSpacY.TabIndex = 11;
            this.lblSpacY.Text = "Spacing in y-Direction";
            // 
            // lblFloorHeightValue
            // 
            this.lblFloorHeightValue.Font = new System.Drawing.Font("Lato", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFloorHeightValue.ForeColor = System.Drawing.Color.Black;
            this.lblFloorHeightValue.Location = new System.Drawing.Point(194, 287);
            this.lblFloorHeightValue.Name = "lblFloorHeightValue";
            this.lblFloorHeightValue.Size = new System.Drawing.Size(71, 26);
            this.lblFloorHeightValue.TabIndex = 13;
            this.lblFloorHeightValue.Text = "3,00  m";
            this.lblFloorHeightValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbarSpacX
            // 
            this.tbarSpacX.AutoSize = false;
            this.tbarSpacX.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.tbarSpacX.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbarSpacX.DrawBackground = true;
            this.tbarSpacX.LargeChange = 100;
            this.tbarSpacX.Location = new System.Drawing.Point(317, 316);
            this.tbarSpacX.Maximum = 1400;
            this.tbarSpacX.Minimum = 200;
            this.tbarSpacX.Name = "tbarSpacX";
            this.tbarSpacX.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.tbarSpacX.Size = new System.Drawing.Size(200, 26);
            this.tbarSpacX.StateCommon.Position.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.tbarSpacX.StateCommon.Position.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbarSpacX.StateCommon.Position.Color3 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbarSpacX.StateCommon.Position.Color4 = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.tbarSpacX.StateCommon.Position.Color5 = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.tbarSpacX.StateCommon.Tick.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarSpacX.StateCommon.Tick.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarSpacX.StateCommon.Tick.Color3 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarSpacX.StateCommon.Tick.Color4 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarSpacX.StateCommon.Tick.Color5 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarSpacX.StateCommon.Track.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarSpacX.StateCommon.Track.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarSpacX.StateCommon.Track.Color3 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarSpacX.StateCommon.Track.Color4 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarSpacX.StateCommon.Track.Color5 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarSpacX.TabIndex = 15;
            this.tbarSpacX.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarSpacX.TrackBarSize = ComponentFactory.Krypton.Toolkit.PaletteTrackBarSize.Small;
            this.tbarSpacX.Value = 600;
            this.tbarSpacX.ValueChanged += new System.EventHandler(this.tbarSpacX_ValueChanged);
            // 
            // tbarSpacY
            // 
            this.tbarSpacY.AutoSize = false;
            this.tbarSpacY.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.tbarSpacY.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbarSpacY.DrawBackground = true;
            this.tbarSpacY.LargeChange = 100;
            this.tbarSpacY.Location = new System.Drawing.Point(317, 348);
            this.tbarSpacY.Maximum = 1400;
            this.tbarSpacY.Minimum = 200;
            this.tbarSpacY.Name = "tbarSpacY";
            this.tbarSpacY.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.tbarSpacY.Size = new System.Drawing.Size(200, 26);
            this.tbarSpacY.StateCommon.Position.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.tbarSpacY.StateCommon.Position.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbarSpacY.StateCommon.Position.Color3 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbarSpacY.StateCommon.Position.Color4 = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.tbarSpacY.StateCommon.Position.Color5 = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.tbarSpacY.StateCommon.Tick.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarSpacY.StateCommon.Tick.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarSpacY.StateCommon.Tick.Color3 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarSpacY.StateCommon.Tick.Color4 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarSpacY.StateCommon.Tick.Color5 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarSpacY.StateCommon.Track.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarSpacY.StateCommon.Track.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarSpacY.StateCommon.Track.Color3 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarSpacY.StateCommon.Track.Color4 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarSpacY.StateCommon.Track.Color5 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarSpacY.TabIndex = 18;
            this.tbarSpacY.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarSpacY.TrackBarSize = ComponentFactory.Krypton.Toolkit.PaletteTrackBarSize.Small;
            this.tbarSpacY.Value = 600;
            this.tbarSpacY.ValueChanged += new System.EventHandler(this.tbarSpacY_ValueChanged);
            // 
            // tbarFloorHeight
            // 
            this.tbarFloorHeight.AutoSize = false;
            this.tbarFloorHeight.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.tbarFloorHeight.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbarFloorHeight.DrawBackground = true;
            this.tbarFloorHeight.LargeChange = 100;
            this.tbarFloorHeight.Location = new System.Drawing.Point(317, 287);
            this.tbarFloorHeight.Maximum = 800;
            this.tbarFloorHeight.Minimum = 200;
            this.tbarFloorHeight.Name = "tbarFloorHeight";
            this.tbarFloorHeight.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.tbarFloorHeight.Size = new System.Drawing.Size(200, 26);
            this.tbarFloorHeight.StateCommon.Position.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbarFloorHeight.StateCommon.Position.Color3 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbarFloorHeight.StateCommon.Position.Color4 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbarFloorHeight.StateCommon.Position.Color5 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbarFloorHeight.StateCommon.Tick.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarFloorHeight.StateCommon.Tick.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarFloorHeight.StateCommon.Tick.Color3 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarFloorHeight.StateCommon.Tick.Color4 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarFloorHeight.StateCommon.Tick.Color5 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarFloorHeight.StateCommon.Track.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarFloorHeight.StateCommon.Track.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarFloorHeight.StateCommon.Track.Color3 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarFloorHeight.StateCommon.Track.Color4 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarFloorHeight.StateCommon.Track.Color5 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbarFloorHeight.TabIndex = 19;
            this.tbarFloorHeight.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarFloorHeight.TrackBarSize = ComponentFactory.Krypton.Toolkit.PaletteTrackBarSize.Small;
            this.tbarFloorHeight.Value = 300;
            this.tbarFloorHeight.ValueChanged += new System.EventHandler(this.tbarFloorHeight_ValueChanged);
            // 
            // lblSpacYValue
            // 
            this.lblSpacYValue.Font = new System.Drawing.Font("Lato", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpacYValue.ForeColor = System.Drawing.Color.Black;
            this.lblSpacYValue.Location = new System.Drawing.Point(199, 348);
            this.lblSpacYValue.Name = "lblSpacYValue";
            this.lblSpacYValue.Size = new System.Drawing.Size(65, 26);
            this.lblSpacYValue.TabIndex = 20;
            this.lblSpacYValue.Text = "6,00  m";
            this.lblSpacYValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMat
            // 
            this.lblMat.Font = new System.Drawing.Font("Lato", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMat.ForeColor = System.Drawing.Color.Black;
            this.lblMat.Location = new System.Drawing.Point(2, 209);
            this.lblMat.Name = "lblMat";
            this.lblMat.Size = new System.Drawing.Size(83, 26);
            this.lblMat.TabIndex = 3;
            this.lblMat.Text = "Material";
            // 
            // panelMat
            // 
            this.panelMat.BackColor = System.Drawing.Color.Transparent;
            this.panelMat.CausesValidation = false;
            this.panelMat.Controls.Add(this.rbtnTimberMat);
            this.panelMat.Controls.Add(this.rbtnConcreteMat);
            this.panelMat.Controls.Add(this.rbtnSteelMat);
            this.panelMat.Location = new System.Drawing.Point(273, 199);
            this.panelMat.Margin = new System.Windows.Forms.Padding(0);
            this.panelMat.Name = "panelMat";
            this.panelMat.Size = new System.Drawing.Size(250, 36);
            this.panelMat.TabIndex = 0;
            this.panelMat.Visible = false;
            // 
            // btnSelectBuilding
            // 
            this.btnSelectBuilding.Location = new System.Drawing.Point(-8, 83);
            this.btnSelectBuilding.Name = "btnSelectBuilding";
            this.btnSelectBuilding.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnSelectBuilding.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnSelectBuilding.OverrideDefault.Back.ColorAngle = 45F;
            this.btnSelectBuilding.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnSelectBuilding.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSelectBuilding.OverrideDefault.Border.ColorAngle = 45F;
            this.btnSelectBuilding.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSelectBuilding.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSelectBuilding.OverrideDefault.Border.Rounding = 8;
            this.btnSelectBuilding.OverrideDefault.Border.Width = 2;
            this.btnSelectBuilding.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSelectBuilding.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnSelectBuilding.Size = new System.Drawing.Size(181, 34);
            this.btnSelectBuilding.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnSelectBuilding.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnSelectBuilding.StateCommon.Back.ColorAngle = 45F;
            this.btnSelectBuilding.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnSelectBuilding.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSelectBuilding.StateCommon.Border.ColorAngle = 45F;
            this.btnSelectBuilding.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSelectBuilding.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSelectBuilding.StateCommon.Border.Rounding = 8;
            this.btnSelectBuilding.StateCommon.Border.Width = 1;
            this.btnSelectBuilding.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSelectBuilding.StateCommon.Content.ShortText.Font = new System.Drawing.Font("IBM Plex Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectBuilding.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnSelectBuilding.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnSelectBuilding.StatePressed.Back.ColorAngle = 135F;
            this.btnSelectBuilding.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnSelectBuilding.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnSelectBuilding.StatePressed.Border.ColorAngle = 135F;
            this.btnSelectBuilding.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSelectBuilding.StatePressed.Border.Rounding = 8;
            this.btnSelectBuilding.StatePressed.Border.Width = 2;
            this.btnSelectBuilding.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSelectBuilding.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnSelectBuilding.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnSelectBuilding.StateTracking.Back.ColorAngle = 45F;
            this.btnSelectBuilding.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnSelectBuilding.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSelectBuilding.StateTracking.Border.ColorAngle = 45F;
            this.btnSelectBuilding.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSelectBuilding.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSelectBuilding.StateTracking.Border.Rounding = 8;
            this.btnSelectBuilding.StateTracking.Border.Width = 1;
            this.btnSelectBuilding.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSelectBuilding.TabIndex = 27;
            this.btnSelectBuilding.Values.Text = "Select Your Building";
            this.btnSelectBuilding.Click += new System.EventHandler(this.btnSelectBuilding_Click_1);
            // 
            // btnSelectCore
            // 
            this.btnSelectCore.Location = new System.Drawing.Point(179, 83);
            this.btnSelectCore.Name = "btnSelectCore";
            this.btnSelectCore.OverrideDefault.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnSelectCore.OverrideDefault.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnSelectCore.OverrideDefault.Back.ColorAngle = 45F;
            this.btnSelectCore.OverrideDefault.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnSelectCore.OverrideDefault.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSelectCore.OverrideDefault.Border.ColorAngle = 45F;
            this.btnSelectCore.OverrideDefault.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSelectCore.OverrideDefault.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSelectCore.OverrideDefault.Border.Rounding = 8;
            this.btnSelectCore.OverrideDefault.Border.Width = 2;
            this.btnSelectCore.OverrideDefault.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSelectCore.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnSelectCore.Size = new System.Drawing.Size(203, 34);
            this.btnSelectCore.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnSelectCore.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnSelectCore.StateCommon.Back.ColorAngle = 45F;
            this.btnSelectCore.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnSelectCore.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSelectCore.StateCommon.Border.ColorAngle = 45F;
            this.btnSelectCore.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSelectCore.StateCommon.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSelectCore.StateCommon.Border.Rounding = 8;
            this.btnSelectCore.StateCommon.Border.Width = 1;
            this.btnSelectCore.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSelectCore.StateCommon.Content.ShortText.Font = new System.Drawing.Font("IBM Plex Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectCore.StatePressed.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnSelectCore.StatePressed.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnSelectCore.StatePressed.Back.ColorAngle = 135F;
            this.btnSelectCore.StatePressed.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(145)))), ((int)(((byte)(198)))));
            this.btnSelectCore.StatePressed.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(121)))), ((int)(((byte)(206)))));
            this.btnSelectCore.StatePressed.Border.ColorAngle = 135F;
            this.btnSelectCore.StatePressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSelectCore.StatePressed.Border.Rounding = 8;
            this.btnSelectCore.StatePressed.Border.Width = 2;
            this.btnSelectCore.StatePressed.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSelectCore.StateTracking.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnSelectCore.StateTracking.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.btnSelectCore.StateTracking.Back.ColorAngle = 45F;
            this.btnSelectCore.StateTracking.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(174)))), ((int)(((byte)(244)))));
            this.btnSelectCore.StateTracking.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSelectCore.StateTracking.Border.ColorAngle = 45F;
            this.btnSelectCore.StateTracking.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSelectCore.StateTracking.Border.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSelectCore.StateTracking.Border.Rounding = 8;
            this.btnSelectCore.StateTracking.Border.Width = 1;
            this.btnSelectCore.StateTracking.Content.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(142)))), ((int)(((byte)(254)))));
            this.btnSelectCore.TabIndex = 28;
            this.btnSelectCore.Values.Text = "Select the Building Core";
            // 
            // picBG
            // 
            this.picBG.Image = global::B_GOpt.Properties.Resources.B_G;
            this.picBG.Location = new System.Drawing.Point(479, 0);
            this.picBG.Name = "picBG";
            this.picBG.Size = new System.Drawing.Size(41, 38);
            this.picBG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBG.TabIndex = 2;
            this.picBG.TabStop = false;
            // 
            // lblRes
            // 
            this.lblRes.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRes.ForeColor = System.Drawing.Color.Black;
            this.lblRes.Location = new System.Drawing.Point(4, 392);
            this.lblRes.Name = "lblRes";
            this.lblRes.Size = new System.Drawing.Size(83, 26);
            this.lblRes.TabIndex = 29;
            this.lblRes.Text = "RESULTS";
            // 
            // lblSrfArea
            // 
            this.lblSrfArea.Font = new System.Drawing.Font("Lato", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSrfArea.ForeColor = System.Drawing.Color.Black;
            this.lblSrfArea.Location = new System.Drawing.Point(4, 428);
            this.lblSrfArea.Name = "lblSrfArea";
            this.lblSrfArea.Size = new System.Drawing.Size(117, 26);
            this.lblSrfArea.TabIndex = 30;
            this.lblSrfArea.Text = "Surface Area";
            // 
            // lblCO2
            // 
            this.lblCO2.Font = new System.Drawing.Font("Lato", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCO2.ForeColor = System.Drawing.Color.Black;
            this.lblCO2.Location = new System.Drawing.Point(4, 517);
            this.lblCO2.Name = "lblCO2";
            this.lblCO2.Size = new System.Drawing.Size(135, 26);
            this.lblCO2.TabIndex = 33;
            this.lblCO2.Text = "Embodied CO2";
            // 
            // lblSpacXValue
            // 
            this.lblSpacXValue.Font = new System.Drawing.Font("Lato", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpacXValue.ForeColor = System.Drawing.Color.Black;
            this.lblSpacXValue.Location = new System.Drawing.Point(195, 313);
            this.lblSpacXValue.Name = "lblSpacXValue";
            this.lblSpacXValue.Size = new System.Drawing.Size(69, 26);
            this.lblSpacXValue.TabIndex = 16;
            this.lblSpacXValue.Text = "6,00  m";
            this.lblSpacXValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chartCO2
            // 
            chartArea1.Name = "ChartArea1";
            this.chartCO2.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartCO2.Legends.Add(legend1);
            this.chartCO2.Location = new System.Drawing.Point(232, 550);
            this.chartCO2.Name = "chartCO2";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "CO2";
            this.chartCO2.Series.Add(series1);
            this.chartCO2.Size = new System.Drawing.Size(262, 135);
            this.chartCO2.TabIndex = 34;
            this.chartCO2.Text = "chart1";
            // 
            // lblFAR
            // 
            this.lblFAR.Font = new System.Drawing.Font("Lato", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFAR.ForeColor = System.Drawing.Color.Black;
            this.lblFAR.Location = new System.Drawing.Point(4, 460);
            this.lblFAR.Name = "lblFAR";
            this.lblFAR.Size = new System.Drawing.Size(117, 26);
            this.lblFAR.TabIndex = 35;
            this.lblFAR.Text = "FAR";
            // 
            // lblCosts
            // 
            this.lblCosts.Font = new System.Drawing.Font("Lato", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCosts.ForeColor = System.Drawing.Color.Black;
            this.lblCosts.Location = new System.Drawing.Point(4, 489);
            this.lblCosts.Name = "lblCosts";
            this.lblCosts.Size = new System.Drawing.Size(169, 26);
            this.lblCosts.TabIndex = 36;
            this.lblCosts.Text = "Construction Costs";
            // 
            // lblProgramm
            // 
            this.lblProgramm.Font = new System.Drawing.Font("Lato", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgramm.ForeColor = System.Drawing.Color.Black;
            this.lblProgramm.Location = new System.Drawing.Point(2, 257);
            this.lblProgramm.Name = "lblProgramm";
            this.lblProgramm.Size = new System.Drawing.Size(117, 26);
            this.lblProgramm.TabIndex = 37;
            this.lblProgramm.Text = "Programm";
            // 
            // lblStructSystem
            // 
            this.lblStructSystem.Font = new System.Drawing.Font("Lato", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStructSystem.ForeColor = System.Drawing.Color.Black;
            this.lblStructSystem.Location = new System.Drawing.Point(2, 163);
            this.lblStructSystem.Name = "lblStructSystem";
            this.lblStructSystem.Size = new System.Drawing.Size(152, 26);
            this.lblStructSystem.TabIndex = 38;
            this.lblStructSystem.Text = "Strucutural System";
            // 
            // lblUI
            // 
            this.lblUI.Font = new System.Drawing.Font("Lato", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUI.ForeColor = System.Drawing.Color.Black;
            this.lblUI.Location = new System.Drawing.Point(2, 129);
            this.lblUI.Name = "lblUI";
            this.lblUI.Size = new System.Drawing.Size(137, 26);
            this.lblUI.TabIndex = 39;
            this.lblUI.Text = "USER INPUT";
            // 
            // lblFarValue
            // 
            this.lblFarValue.Font = new System.Drawing.Font("Lato", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFarValue.ForeColor = System.Drawing.Color.Black;
            this.lblFarValue.Location = new System.Drawing.Point(199, 460);
            this.lblFarValue.Name = "lblFarValue";
            this.lblFarValue.Size = new System.Drawing.Size(117, 26);
            this.lblFarValue.TabIndex = 40;
            this.lblFarValue.Text = "-";
            // 
            // lblSurfaceValue
            // 
            this.lblSurfaceValue.Font = new System.Drawing.Font("Lato", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurfaceValue.ForeColor = System.Drawing.Color.Black;
            this.lblSurfaceValue.Location = new System.Drawing.Point(199, 428);
            this.lblSurfaceValue.Name = "lblSurfaceValue";
            this.lblSurfaceValue.Size = new System.Drawing.Size(117, 26);
            this.lblSurfaceValue.TabIndex = 41;
            this.lblSurfaceValue.Text = "-";
            // 
            // lblCostsValue
            // 
            this.lblCostsValue.Font = new System.Drawing.Font("Lato", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostsValue.ForeColor = System.Drawing.Color.Black;
            this.lblCostsValue.Location = new System.Drawing.Point(199, 489);
            this.lblCostsValue.Name = "lblCostsValue";
            this.lblCostsValue.Size = new System.Drawing.Size(117, 26);
            this.lblCostsValue.TabIndex = 42;
            this.lblCostsValue.Text = "-";
            // 
            // lblCO2Value
            // 
            this.lblCO2Value.Font = new System.Drawing.Font("Lato", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCO2Value.ForeColor = System.Drawing.Color.Black;
            this.lblCO2Value.Location = new System.Drawing.Point(199, 517);
            this.lblCO2Value.Name = "lblCO2Value";
            this.lblCO2Value.Size = new System.Drawing.Size(117, 26);
            this.lblCO2Value.TabIndex = 43;
            this.lblCO2Value.Text = "-";
            // 
            // panelProgramm
            // 
            this.panelProgramm.Controls.Add(this.rbtnIndustrial);
            this.panelProgramm.Controls.Add(this.rbtnOffice);
            this.panelProgramm.Controls.Add(this.rbtnResidential);
            this.panelProgramm.Location = new System.Drawing.Point(273, 243);
            this.panelProgramm.Name = "panelProgramm";
            this.panelProgramm.Size = new System.Drawing.Size(244, 38);
            this.panelProgramm.TabIndex = 44;
            // 
            // panelStructSystem
            // 
            this.panelStructSystem.Controls.Add(this.rbtnSlabSystem);
            this.panelStructSystem.Controls.Add(this.rbtnGirderSystem);
            this.panelStructSystem.Location = new System.Drawing.Point(273, 151);
            this.panelStructSystem.Name = "panelStructSystem";
            this.panelStructSystem.Size = new System.Drawing.Size(244, 38);
            this.panelStructSystem.TabIndex = 45;
            // 
            // rbtnSlabSystem
            // 
            this.rbtnSlabSystem.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnSlabSystem.AutoSize = true;
            this.rbtnSlabSystem.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtnSlabSystem.BackgorundColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtnSlabSystem.BorderColor = System.Drawing.Color.White;
            this.rbtnSlabSystem.BorderRadius = 20;
            this.rbtnSlabSystem.BorderSize = 0;
            this.rbtnSlabSystem.FlatAppearance.BorderSize = 0;
            this.rbtnSlabSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnSlabSystem.Font = new System.Drawing.Font("Lato", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSlabSystem.ForeColor = System.Drawing.Color.Black;
            this.rbtnSlabSystem.Location = new System.Drawing.Point(125, 5);
            this.rbtnSlabSystem.Name = "rbtnSlabSystem";
            this.rbtnSlabSystem.Size = new System.Drawing.Size(88, 26);
            this.rbtnSlabSystem.TabIndex = 2;
            this.rbtnSlabSystem.TabStop = true;
            this.rbtnSlabSystem.Text = "Slab System";
            this.rbtnSlabSystem.TextColor = System.Drawing.Color.Black;
            this.rbtnSlabSystem.UseVisualStyleBackColor = false;
            // 
            // rbtnGirderSystem
            // 
            this.rbtnGirderSystem.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnGirderSystem.AutoSize = true;
            this.rbtnGirderSystem.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtnGirderSystem.BackgorundColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtnGirderSystem.BorderColor = System.Drawing.Color.White;
            this.rbtnGirderSystem.BorderRadius = 20;
            this.rbtnGirderSystem.BorderSize = 0;
            this.rbtnGirderSystem.FlatAppearance.BorderSize = 0;
            this.rbtnGirderSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnGirderSystem.Font = new System.Drawing.Font("Lato", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnGirderSystem.ForeColor = System.Drawing.Color.Black;
            this.rbtnGirderSystem.Location = new System.Drawing.Point(3, 4);
            this.rbtnGirderSystem.Name = "rbtnGirderSystem";
            this.rbtnGirderSystem.Size = new System.Drawing.Size(101, 26);
            this.rbtnGirderSystem.TabIndex = 0;
            this.rbtnGirderSystem.TabStop = true;
            this.rbtnGirderSystem.Text = "Girder System";
            this.rbtnGirderSystem.TextColor = System.Drawing.Color.Black;
            this.rbtnGirderSystem.UseVisualStyleBackColor = false;
            // 
            // rbtnIndustrial
            // 
            this.rbtnIndustrial.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnIndustrial.AutoSize = true;
            this.rbtnIndustrial.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtnIndustrial.BackgorundColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtnIndustrial.BorderColor = System.Drawing.Color.White;
            this.rbtnIndustrial.BorderRadius = 20;
            this.rbtnIndustrial.BorderSize = 0;
            this.rbtnIndustrial.FlatAppearance.BorderSize = 0;
            this.rbtnIndustrial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnIndustrial.Font = new System.Drawing.Font("Lato", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnIndustrial.ForeColor = System.Drawing.Color.Black;
            this.rbtnIndustrial.Location = new System.Drawing.Point(146, 5);
            this.rbtnIndustrial.Name = "rbtnIndustrial";
            this.rbtnIndustrial.Size = new System.Drawing.Size(72, 26);
            this.rbtnIndustrial.TabIndex = 2;
            this.rbtnIndustrial.TabStop = true;
            this.rbtnIndustrial.Text = "Industrial";
            this.rbtnIndustrial.TextColor = System.Drawing.Color.Black;
            this.rbtnIndustrial.UseVisualStyleBackColor = false;
            // 
            // rbtnOffice
            // 
            this.rbtnOffice.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnOffice.AutoSize = true;
            this.rbtnOffice.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtnOffice.BackgorundColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtnOffice.BorderColor = System.Drawing.Color.White;
            this.rbtnOffice.BorderRadius = 20;
            this.rbtnOffice.BorderSize = 0;
            this.rbtnOffice.FlatAppearance.BorderSize = 0;
            this.rbtnOffice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnOffice.Font = new System.Drawing.Font("Lato", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnOffice.ForeColor = System.Drawing.Color.Black;
            this.rbtnOffice.Location = new System.Drawing.Point(90, 5);
            this.rbtnOffice.Name = "rbtnOffice";
            this.rbtnOffice.Size = new System.Drawing.Size(52, 26);
            this.rbtnOffice.TabIndex = 1;
            this.rbtnOffice.TabStop = true;
            this.rbtnOffice.Text = "Office";
            this.rbtnOffice.TextColor = System.Drawing.Color.Black;
            this.rbtnOffice.UseVisualStyleBackColor = false;
            // 
            // rbtnResidential
            // 
            this.rbtnResidential.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnResidential.AutoSize = true;
            this.rbtnResidential.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtnResidential.BackgorundColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtnResidential.BorderColor = System.Drawing.Color.White;
            this.rbtnResidential.BorderRadius = 20;
            this.rbtnResidential.BorderSize = 0;
            this.rbtnResidential.FlatAppearance.BorderSize = 0;
            this.rbtnResidential.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnResidential.Font = new System.Drawing.Font("Lato", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnResidential.ForeColor = System.Drawing.Color.Black;
            this.rbtnResidential.Location = new System.Drawing.Point(3, 4);
            this.rbtnResidential.Name = "rbtnResidential";
            this.rbtnResidential.Size = new System.Drawing.Size(81, 26);
            this.rbtnResidential.TabIndex = 0;
            this.rbtnResidential.TabStop = true;
            this.rbtnResidential.Text = "Residential";
            this.rbtnResidential.TextColor = System.Drawing.Color.Black;
            this.rbtnResidential.UseVisualStyleBackColor = false;
            // 
            // rbtnTimberMat
            // 
            this.rbtnTimberMat.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnTimberMat.AutoSize = true;
            this.rbtnTimberMat.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtnTimberMat.BackgorundColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtnTimberMat.BorderColor = System.Drawing.Color.White;
            this.rbtnTimberMat.BorderRadius = 20;
            this.rbtnTimberMat.BorderSize = 0;
            this.rbtnTimberMat.FlatAppearance.BorderSize = 0;
            this.rbtnTimberMat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnTimberMat.Font = new System.Drawing.Font("Lato", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTimberMat.ForeColor = System.Drawing.Color.Black;
            this.rbtnTimberMat.Location = new System.Drawing.Point(155, 7);
            this.rbtnTimberMat.Name = "rbtnTimberMat";
            this.rbtnTimberMat.Size = new System.Drawing.Size(59, 26);
            this.rbtnTimberMat.TabIndex = 5;
            this.rbtnTimberMat.TabStop = true;
            this.rbtnTimberMat.Text = "Timber";
            this.rbtnTimberMat.TextColor = System.Drawing.Color.Black;
            this.rbtnTimberMat.UseVisualStyleBackColor = false;
            // 
            // rbtnConcreteMat
            // 
            this.rbtnConcreteMat.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnConcreteMat.AutoSize = true;
            this.rbtnConcreteMat.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtnConcreteMat.BackgorundColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtnConcreteMat.BorderColor = System.Drawing.Color.White;
            this.rbtnConcreteMat.BorderRadius = 20;
            this.rbtnConcreteMat.BorderSize = 0;
            this.rbtnConcreteMat.FlatAppearance.BorderSize = 0;
            this.rbtnConcreteMat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnConcreteMat.Font = new System.Drawing.Font("Lato", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnConcreteMat.ForeColor = System.Drawing.Color.Black;
            this.rbtnConcreteMat.Location = new System.Drawing.Point(71, 7);
            this.rbtnConcreteMat.Name = "rbtnConcreteMat";
            this.rbtnConcreteMat.Size = new System.Drawing.Size(71, 26);
            this.rbtnConcreteMat.TabIndex = 4;
            this.rbtnConcreteMat.TabStop = true;
            this.rbtnConcreteMat.Text = "Concrete";
            this.rbtnConcreteMat.TextColor = System.Drawing.Color.Black;
            this.rbtnConcreteMat.UseVisualStyleBackColor = false;
            // 
            // rbtnSteelMat
            // 
            this.rbtnSteelMat.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnSteelMat.AutoSize = true;
            this.rbtnSteelMat.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtnSteelMat.BackgorundColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtnSteelMat.BorderColor = System.Drawing.Color.White;
            this.rbtnSteelMat.BorderRadius = 20;
            this.rbtnSteelMat.BorderSize = 0;
            this.rbtnSteelMat.FlatAppearance.BorderSize = 0;
            this.rbtnSteelMat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnSteelMat.Font = new System.Drawing.Font("Lato", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSteelMat.ForeColor = System.Drawing.Color.Black;
            this.rbtnSteelMat.Location = new System.Drawing.Point(4, 7);
            this.rbtnSteelMat.Name = "rbtnSteelMat";
            this.rbtnSteelMat.Size = new System.Drawing.Size(47, 26);
            this.rbtnSteelMat.TabIndex = 3;
            this.rbtnSteelMat.TabStop = true;
            this.rbtnSteelMat.Text = "Steel";
            this.rbtnSteelMat.TextColor = System.Drawing.Color.Black;
            this.rbtnSteelMat.UseVisualStyleBackColor = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(532, 754);
            this.Controls.Add(this.panelStructSystem);
            this.Controls.Add(this.panelProgramm);
            this.Controls.Add(this.lblCO2Value);
            this.Controls.Add(this.lblCostsValue);
            this.Controls.Add(this.lblSurfaceValue);
            this.Controls.Add(this.lblFarValue);
            this.Controls.Add(this.lblUI);
            this.Controls.Add(this.lblStructSystem);
            this.Controls.Add(this.lblProgramm);
            this.Controls.Add(this.lblCosts);
            this.Controls.Add(this.lblFAR);
            this.Controls.Add(this.chartCO2);
            this.Controls.Add(this.lblCO2);
            this.Controls.Add(this.lblSrfArea);
            this.Controls.Add(this.lblRes);
            this.Controls.Add(this.btnSelectCore);
            this.Controls.Add(this.btnSelectBuilding);
            this.Controls.Add(this.panelMat);
            this.Controls.Add(this.lblSpacYValue);
            this.Controls.Add(this.tbarFloorHeight);
            this.Controls.Add(this.tbarSpacY);
            this.Controls.Add(this.lblSpacXValue);
            this.Controls.Add(this.tbarSpacX);
            this.Controls.Add(this.lblFloorHeightValue);
            this.Controls.Add(this.lblSpacY);
            this.Controls.Add(this.lblSpacX);
            this.Controls.Add(this.lblFloorHeight);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lblMat);
            this.Controls.Add(this.picBG);
            this.Controls.Add(this.lblProjectName);
            this.Name = "Form2";
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.ShowIcon = false;
            this.Text = "B+GOpt";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panelMat.ResumeLayout(false);
            this.panelMat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCO2)).EndInit();
            this.panelProgramm.ResumeLayout(false);
            this.panelProgramm.PerformLayout();
            this.panelStructSystem.ResumeLayout(false);
            this.panelStructSystem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.PictureBox picBG;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCalculate;
        private System.Windows.Forms.Label lblFloorHeight;
        private System.Windows.Forms.Label lblSpacX;
        private System.Windows.Forms.Label lblSpacY;
        private System.Windows.Forms.Label lblFloorHeightValue;
        private ComponentFactory.Krypton.Toolkit.KryptonTrackBar tbarSpacX;
        private ComponentFactory.Krypton.Toolkit.KryptonTrackBar tbarSpacY;
        private ComponentFactory.Krypton.Toolkit.KryptonTrackBar tbarFloorHeight;
        private System.Windows.Forms.Label lblSpacYValue;
        private System.Windows.Forms.Label lblMat;
        private System.Windows.Forms.Panel panelMat;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSelectBuilding;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSelectCore;
        private System.Windows.Forms.Label lblRes;
        private System.Windows.Forms.Label lblSrfArea;
        private System.Windows.Forms.Label lblCO2;
        private System.Windows.Forms.Label lblSpacXValue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCO2;
        private System.Windows.Forms.Label lblFAR;
        private System.Windows.Forms.Label lblCosts;
        private System.Windows.Forms.Label lblProgramm;
        private System.Windows.Forms.Label lblStructSystem;
        private System.Windows.Forms.Label lblUI;
        private System.Windows.Forms.Label lblFarValue;
        private System.Windows.Forms.Label lblSurfaceValue;
        private System.Windows.Forms.Label lblCostsValue;
        private System.Windows.Forms.Label lblCO2Value;
        private System.Windows.Forms.Panel panelProgramm;
        private CustomControls.CustomRadioButton rbtnIndustrial;
        private CustomControls.CustomRadioButton rbtnOffice;
        private CustomControls.CustomRadioButton rbtnResidential;
        private System.Windows.Forms.Panel panelStructSystem;
        private CustomControls.CustomRadioButton rbtnSlabSystem;
        private CustomControls.CustomRadioButton rbtnGirderSystem;
        private CustomControls.CustomRadioButton rbtnTimberMat;
        private CustomControls.CustomRadioButton rbtnConcreteMat;
        private CustomControls.CustomRadioButton rbtnSteelMat;
    }
}