
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
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.lblProjectName = new System.Windows.Forms.Label();
            this.btnCalculate = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFloorHeightValue = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbarSpacX = new ComponentFactory.Krypton.Toolkit.KryptonTrackBar();
            this.lblSpacXValue = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbarSpacY = new ComponentFactory.Krypton.Toolkit.KryptonTrackBar();
            this.tbarFloorHeight = new ComponentFactory.Krypton.Toolkit.KryptonTrackBar();
            this.lblSpacYValue = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbtnTimberMat = new System.Windows.Forms.RadioButton();
            this.rbtnConcreteMat = new System.Windows.Forms.RadioButton();
            this.rbtnSteelMat = new System.Windows.Forms.RadioButton();
            this.btnSelectBuilding = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSelectCore = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblSurfaceAreaValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.lblProjectName.Font = new System.Drawing.Font("IBM Plex Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnCalculate.Location = new System.Drawing.Point(6, 586);
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
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("IBM Plex Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(4, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "Floor Height";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("IBM Plex Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(4, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 26);
            this.label4.TabIndex = 10;
            this.label4.Text = "Spacing in x-Direction";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("IBM Plex Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(4, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 26);
            this.label5.TabIndex = 11;
            this.label5.Text = "Spacing in y-Direction";
            // 
            // lblFloorHeightValue
            // 
            this.lblFloorHeightValue.Font = new System.Drawing.Font("IBM Plex Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFloorHeightValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFloorHeightValue.Location = new System.Drawing.Point(191, 222);
            this.lblFloorHeightValue.Name = "lblFloorHeightValue";
            this.lblFloorHeightValue.Size = new System.Drawing.Size(61, 26);
            this.lblFloorHeightValue.TabIndex = 13;
            this.lblFloorHeightValue.Text = "3,00";
            this.lblFloorHeightValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("IBM Plex Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(258, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 26);
            this.label7.TabIndex = 14;
            this.label7.Text = "m";
            // 
            // tbarSpacX
            // 
            this.tbarSpacX.AutoSize = false;
            this.tbarSpacX.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.tbarSpacX.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbarSpacX.DrawBackground = true;
            this.tbarSpacX.LargeChange = 100;
            this.tbarSpacX.Location = new System.Drawing.Point(320, 265);
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
            // lblSpacXValue
            // 
            this.lblSpacXValue.Font = new System.Drawing.Font("IBM Plex Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpacXValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSpacXValue.Location = new System.Drawing.Point(195, 265);
            this.lblSpacXValue.Name = "lblSpacXValue";
            this.lblSpacXValue.Size = new System.Drawing.Size(57, 26);
            this.lblSpacXValue.TabIndex = 16;
            this.lblSpacXValue.Text = "6,00";
            this.lblSpacXValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("IBM Plex Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(258, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 26);
            this.label6.TabIndex = 17;
            this.label6.Text = "m";
            // 
            // tbarSpacY
            // 
            this.tbarSpacY.AutoSize = false;
            this.tbarSpacY.BackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this.tbarSpacY.Cursor = System.Windows.Forms.Cursors.Default;
            this.tbarSpacY.DrawBackground = true;
            this.tbarSpacY.LargeChange = 100;
            this.tbarSpacY.Location = new System.Drawing.Point(320, 306);
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
            this.tbarFloorHeight.Location = new System.Drawing.Point(320, 222);
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
            this.lblSpacYValue.Font = new System.Drawing.Font("IBM Plex Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpacYValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSpacYValue.Location = new System.Drawing.Point(199, 304);
            this.lblSpacYValue.Name = "lblSpacYValue";
            this.lblSpacYValue.Size = new System.Drawing.Size(53, 26);
            this.lblSpacYValue.TabIndex = 20;
            this.lblSpacYValue.Text = "6,00";
            this.lblSpacYValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("IBM Plex Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(258, 306);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(33, 26);
            this.label9.TabIndex = 21;
            this.label9.Text = "m";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("IBM Plex Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(4, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Material";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.rbtnTimberMat);
            this.panel2.Controls.Add(this.rbtnConcreteMat);
            this.panel2.Controls.Add(this.rbtnSteelMat);
            this.panel2.Location = new System.Drawing.Point(232, 146);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(286, 60);
            this.panel2.TabIndex = 26;
            // 
            // rbtnTimberMat
            // 
            this.rbtnTimberMat.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnTimberMat.BackColor = System.Drawing.Color.Transparent;
            this.rbtnTimberMat.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rbtnTimberMat.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.rbtnTimberMat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnTimberMat.Font = new System.Drawing.Font("IBM Plex Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTimberMat.ForeColor = System.Drawing.Color.Black;
            this.rbtnTimberMat.Location = new System.Drawing.Point(165, 17);
            this.rbtnTimberMat.Name = "rbtnTimberMat";
            this.rbtnTimberMat.Size = new System.Drawing.Size(81, 27);
            this.rbtnTimberMat.TabIndex = 27;
            this.rbtnTimberMat.TabStop = true;
            this.rbtnTimberMat.Text = "Timber";
            this.rbtnTimberMat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnTimberMat.UseVisualStyleBackColor = false;
            // 
            // rbtnConcreteMat
            // 
            this.rbtnConcreteMat.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnConcreteMat.BackColor = System.Drawing.Color.Transparent;
            this.rbtnConcreteMat.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rbtnConcreteMat.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.rbtnConcreteMat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnConcreteMat.Font = new System.Drawing.Font("IBM Plex Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnConcreteMat.ForeColor = System.Drawing.Color.Black;
            this.rbtnConcreteMat.Location = new System.Drawing.Point(85, 17);
            this.rbtnConcreteMat.Name = "rbtnConcreteMat";
            this.rbtnConcreteMat.Size = new System.Drawing.Size(81, 27);
            this.rbtnConcreteMat.TabIndex = 26;
            this.rbtnConcreteMat.TabStop = true;
            this.rbtnConcreteMat.Text = "Concrete";
            this.rbtnConcreteMat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnConcreteMat.UseVisualStyleBackColor = false;
            // 
            // rbtnSteelMat
            // 
            this.rbtnSteelMat.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnSteelMat.BackColor = System.Drawing.Color.Transparent;
            this.rbtnSteelMat.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rbtnSteelMat.FlatAppearance.CheckedBackColor = System.Drawing.Color.Silver;
            this.rbtnSteelMat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnSteelMat.Font = new System.Drawing.Font("IBM Plex Sans", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSteelMat.ForeColor = System.Drawing.Color.Black;
            this.rbtnSteelMat.Location = new System.Drawing.Point(5, 17);
            this.rbtnSteelMat.Name = "rbtnSteelMat";
            this.rbtnSteelMat.Size = new System.Drawing.Size(81, 27);
            this.rbtnSteelMat.TabIndex = 25;
            this.rbtnSteelMat.TabStop = true;
            this.rbtnSteelMat.Text = "Steel";
            this.rbtnSteelMat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnSteelMat.UseVisualStyleBackColor = false;
            this.rbtnSteelMat.CheckedChanged += new System.EventHandler(this.rbtnSteelMat_CheckedChanged);
            this.rbtnSteelMat.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButton1_MouseClick);
            this.rbtnSteelMat.MouseHover += new System.EventHandler(this.radioButton1_MouseHover);
            // 
            // btnSelectBuilding
            // 
            this.btnSelectBuilding.Location = new System.Drawing.Point(8, 83);
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
            this.btnSelectCore.Location = new System.Drawing.Point(195, 83);
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::B_GOpt.Properties.Resources.B_G;
            this.pictureBox1.Location = new System.Drawing.Point(479, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("IBM Plex Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(4, 368);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 26);
            this.label8.TabIndex = 29;
            this.label8.Text = "Results";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("IBM Plex Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(4, 404);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 26);
            this.label10.TabIndex = 30;
            this.label10.Text = "Surface Area";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("IBM Plex Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(258, 404);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 26);
            this.label11.TabIndex = 31;
            this.label11.Text = "m²";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // lblSurfaceAreaValue
            // 
            this.lblSurfaceAreaValue.Font = new System.Drawing.Font("IBM Plex Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurfaceAreaValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSurfaceAreaValue.Location = new System.Drawing.Point(141, 402);
            this.lblSurfaceAreaValue.Name = "lblSurfaceAreaValue";
            this.lblSurfaceAreaValue.Size = new System.Drawing.Size(111, 26);
            this.lblSurfaceAreaValue.TabIndex = 32;
            this.lblSurfaceAreaValue.Text = "-";
            this.lblSurfaceAreaValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSurfaceAreaValue.Click += new System.EventHandler(this.lblSurfaceAreaValue_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("IBM Plex Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(2, 458);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 26);
            this.label1.TabIndex = 33;
            this.label1.Text = "Embodied CO2";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(527, 641);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSurfaceAreaValue);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnSelectCore);
            this.Controls.Add(this.btnSelectBuilding);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblSpacYValue);
            this.Controls.Add(this.tbarFloorHeight);
            this.Controls.Add(this.tbarSpacY);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblSpacXValue);
            this.Controls.Add(this.tbarSpacX);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblFloorHeightValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblProjectName);
            this.Name = "Form2";
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.ShowIcon = false;
            this.Text = "B+GOpt";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCalculate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFloorHeightValue;
        private System.Windows.Forms.Label label7;
        private ComponentFactory.Krypton.Toolkit.KryptonTrackBar tbarSpacX;
        private System.Windows.Forms.Label lblSpacXValue;
        private System.Windows.Forms.Label label6;
        private ComponentFactory.Krypton.Toolkit.KryptonTrackBar tbarSpacY;
        private ComponentFactory.Krypton.Toolkit.KryptonTrackBar tbarFloorHeight;
        private System.Windows.Forms.Label lblSpacYValue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbtnSteelMat;
        private System.Windows.Forms.RadioButton rbtnTimberMat;
        private System.Windows.Forms.RadioButton rbtnConcreteMat;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSelectBuilding;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSelectCore;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblSurfaceAreaValue;
        private System.Windows.Forms.Label label1;
    }
}