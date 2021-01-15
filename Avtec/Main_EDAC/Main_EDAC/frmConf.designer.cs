namespace Logger
{
    partial class frmConf
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("InPut Parameters");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("ECU-Channels Inputs", new System.Windows.Forms.TreeNode[] {
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Serial Inputs");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("ADAM-MODULE : 01");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("ADAM-MODULE : 02");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("ADAM-MODULE : 03");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("ADAM-MODULE : 04");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("ADAM-MODULE : 05");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Module Inputs", new System.Windows.Forms.TreeNode[] {
            treeNode22,
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26});
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Analog Inputs");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Modbus Inputs");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Channel Inputs", new System.Windows.Forms.TreeNode[] {
            treeNode21,
            treeNode27,
            treeNode28,
            treeNode29});
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Digital Inputs");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("Digital Outputs");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("Digital In/Out", new System.Windows.Forms.TreeNode[] {
            treeNode31,
            treeNode32});
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("SetPoint - 1");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("SetPoint - 2");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("Set Points", new System.Windows.Forms.TreeNode[] {
            treeNode34,
            treeNode35});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tmrDigIn = new System.Windows.Forms.Timer(this.components);
            this.ContextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu4018 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu4017 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.mnu4015 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EngineRPMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu05000 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu010000 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.EngineTorqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu0100Nm = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu0200Nm = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu0500Nm = new System.Windows.Forms.ToolStripMenuItem();
            this.nmu01000Nm = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.TemperatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu0200C = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu0400C = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu0600C = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu01000C = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.PressuresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu010bar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu025bar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu0812bar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu025025bar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu004bar = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.FuelWeightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu0200g = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu0400g = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.FuelTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.LambdaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.NotProgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrDi = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DGIn = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDOSave = new System.Windows.Forms.Button();
            this.btnDISave = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.DGDo = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button3 = new System.Windows.Forms.Button();
            this.treeView4 = new System.Windows.Forms.TreeView();
            this.treeView3 = new System.Windows.Forms.TreeView();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape5 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.cmbEUnit = new System.Windows.Forms.ComboBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNa = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DgModule = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InGrid = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.cmbunit = new System.Windows.Forms.ComboBox();
            this.txtshname = new System.Windows.Forms.TextBox();
            this.txtmaxval = new System.Windows.Forms.TextBox();
            this.txtminval = new System.Windows.Forms.TextBox();
            this.txtparaname = new System.Windows.Forms.TextBox();
            this.txtchno = new System.Windows.Forms.TextBox();
            this.Label22 = new System.Windows.Forms.Label();
            this.Label23 = new System.Windows.Forms.Label();
            this.Label24 = new System.Windows.Forms.Label();
            this.Label35 = new System.Windows.Forms.Label();
            this.Label36 = new System.Windows.Forms.Label();
            this.Label37 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContextMenuStrip1.SuspendLayout();
            this.ContextMenuStrip2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGIn)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGDo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrDigIn
            // 
            this.tmrDigIn.Tick += new System.EventHandler(this.tmrDigIn_Tick);
            // 
            // ContextMenuStrip1
            // 
            this.ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu4018,
            this.ToolStripSeparator4,
            this.mnu4017,
            this.ToolStripSeparator7,
            this.mnu4015,
            this.ToolStripSeparator10,
            this.mnuDelete});
            this.ContextMenuStrip1.Name = "ContextMenuStrip1";
            this.ContextMenuStrip1.Size = new System.Drawing.Size(124, 110);
            // 
            // mnu4018
            // 
            this.mnu4018.Name = "mnu4018";
            this.mnu4018.Size = new System.Drawing.Size(123, 22);
            this.mnu4018.Text = "+4018 * 8";
            // 
            // ToolStripSeparator4
            // 
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(120, 6);
            // 
            // mnu4017
            // 
            this.mnu4017.Name = "mnu4017";
            this.mnu4017.Size = new System.Drawing.Size(123, 22);
            this.mnu4017.Text = "+4017 * 8";
            // 
            // ToolStripSeparator7
            // 
            this.ToolStripSeparator7.Name = "ToolStripSeparator7";
            this.ToolStripSeparator7.Size = new System.Drawing.Size(120, 6);
            // 
            // mnu4015
            // 
            this.mnu4015.Name = "mnu4015";
            this.mnu4015.Size = new System.Drawing.Size(123, 22);
            this.mnu4015.Text = "  4015 * 6";
            // 
            // ToolStripSeparator10
            // 
            this.ToolStripSeparator10.Name = "ToolStripSeparator10";
            this.ToolStripSeparator10.Size = new System.Drawing.Size(120, 6);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(123, 22);
            this.mnuDelete.Text = "Delete";
            // 
            // ContextMenuStrip2
            // 
            this.ContextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EngineRPMToolStripMenuItem,
            this.ToolStripSeparator2,
            this.EngineTorqueToolStripMenuItem,
            this.ToolStripSeparator3,
            this.TemperatureToolStripMenuItem,
            this.ToolStripSeparator5,
            this.PressuresToolStripMenuItem,
            this.ToolStripSeparator6,
            this.FuelWeightToolStripMenuItem,
            this.ToolStripSeparator8,
            this.FuelTimeToolStripMenuItem,
            this.ToolStripSeparator9,
            this.LambdaToolStripMenuItem,
            this.ToolStripSeparator1,
            this.NotProgToolStripMenuItem});
            this.ContextMenuStrip2.Name = "ContextMenuStrip2";
            this.ContextMenuStrip2.Size = new System.Drawing.Size(150, 222);
            // 
            // EngineRPMToolStripMenuItem
            // 
            this.EngineRPMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu05000,
            this.mnu010000});
            this.EngineRPMToolStripMenuItem.Name = "EngineRPMToolStripMenuItem";
            this.EngineRPMToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.EngineRPMToolStripMenuItem.Text = "Engine RPM";
            // 
            // mnu05000
            // 
            this.mnu05000.Enabled = false;
            this.mnu05000.Name = "mnu05000";
            this.mnu05000.Size = new System.Drawing.Size(140, 22);
            this.mnu05000.Text = "0-5000 rpm";
            // 
            // mnu010000
            // 
            this.mnu010000.Name = "mnu010000";
            this.mnu010000.Size = new System.Drawing.Size(140, 22);
            this.mnu010000.Text = "0-10000 rpm";
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(146, 6);
            // 
            // EngineTorqueToolStripMenuItem
            // 
            this.EngineTorqueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu0100Nm,
            this.mnu0200Nm,
            this.mnu0500Nm,
            this.nmu01000Nm});
            this.EngineTorqueToolStripMenuItem.Name = "EngineTorqueToolStripMenuItem";
            this.EngineTorqueToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.EngineTorqueToolStripMenuItem.Text = "Engine Torque";
            // 
            // mnu0100Nm
            // 
            this.mnu0100Nm.Name = "mnu0100Nm";
            this.mnu0100Nm.Size = new System.Drawing.Size(132, 22);
            this.mnu0100Nm.Text = "0-100 Nm";
            this.mnu0100Nm.Click += new System.EventHandler(this.mnu0100Nm_Click);
            // 
            // mnu0200Nm
            // 
            this.mnu0200Nm.Name = "mnu0200Nm";
            this.mnu0200Nm.Size = new System.Drawing.Size(132, 22);
            this.mnu0200Nm.Text = "0-200 Nm";
            this.mnu0200Nm.Click += new System.EventHandler(this.mnu0200Nm_Click);
            // 
            // mnu0500Nm
            // 
            this.mnu0500Nm.Name = "mnu0500Nm";
            this.mnu0500Nm.Size = new System.Drawing.Size(132, 22);
            this.mnu0500Nm.Text = "0-500 Nm";
            this.mnu0500Nm.Click += new System.EventHandler(this.mnu0500Nm_Click);
            // 
            // nmu01000Nm
            // 
            this.nmu01000Nm.Name = "nmu01000Nm";
            this.nmu01000Nm.Size = new System.Drawing.Size(132, 22);
            this.nmu01000Nm.Text = "0-1000 Nm";
            this.nmu01000Nm.Click += new System.EventHandler(this.nmu01000Nm_Click);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(146, 6);
            // 
            // TemperatureToolStripMenuItem
            // 
            this.TemperatureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu0200C,
            this.mnu0400C,
            this.mnu0600C,
            this.mnu01000C});
            this.TemperatureToolStripMenuItem.Name = "TemperatureToolStripMenuItem";
            this.TemperatureToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.TemperatureToolStripMenuItem.Text = "Temperature";
            // 
            // mnu0200C
            // 
            this.mnu0200C.Name = "mnu0200C";
            this.mnu0200C.Size = new System.Drawing.Size(125, 22);
            this.mnu0200C.Text = "0-200 °C";
            this.mnu0200C.Click += new System.EventHandler(this.mnu0200C_Click);
            // 
            // mnu0400C
            // 
            this.mnu0400C.Enabled = false;
            this.mnu0400C.Name = "mnu0400C";
            this.mnu0400C.Size = new System.Drawing.Size(125, 22);
            this.mnu0400C.Text = "0-400 °C";
            // 
            // mnu0600C
            // 
            this.mnu0600C.Enabled = false;
            this.mnu0600C.Name = "mnu0600C";
            this.mnu0600C.Size = new System.Drawing.Size(125, 22);
            this.mnu0600C.Text = "0-600 °C";
            // 
            // mnu01000C
            // 
            this.mnu01000C.Name = "mnu01000C";
            this.mnu01000C.Size = new System.Drawing.Size(125, 22);
            this.mnu01000C.Text = "0-1000 °C";
            this.mnu01000C.Click += new System.EventHandler(this.mnu01000C_Click);
            // 
            // ToolStripSeparator5
            // 
            this.ToolStripSeparator5.Name = "ToolStripSeparator5";
            this.ToolStripSeparator5.Size = new System.Drawing.Size(146, 6);
            // 
            // PressuresToolStripMenuItem
            // 
            this.PressuresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu010bar,
            this.mnu025bar,
            this.mnu0812bar,
            this.mnu025025bar,
            this.mnu004bar});
            this.PressuresToolStripMenuItem.Name = "PressuresToolStripMenuItem";
            this.PressuresToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.PressuresToolStripMenuItem.Text = "Pressures";
            // 
            // mnu010bar
            // 
            this.mnu010bar.Name = "mnu010bar";
            this.mnu010bar.Size = new System.Drawing.Size(149, 22);
            this.mnu010bar.Text = "0~10 bar";
            this.mnu010bar.Click += new System.EventHandler(this.mnu010bar_Click);
            // 
            // mnu025bar
            // 
            this.mnu025bar.Name = "mnu025bar";
            this.mnu025bar.Size = new System.Drawing.Size(149, 22);
            this.mnu025bar.Text = "0~2.5 bar";
            this.mnu025bar.Click += new System.EventHandler(this.mnu025bar_Click);
            // 
            // mnu0812bar
            // 
            this.mnu0812bar.Name = "mnu0812bar";
            this.mnu0812bar.Size = new System.Drawing.Size(149, 22);
            this.mnu0812bar.Text = "0.8~1.2 bar";
            this.mnu0812bar.Click += new System.EventHandler(this.mnu0812bar_Click);
            // 
            // mnu025025bar
            // 
            this.mnu025025bar.Name = "mnu025025bar";
            this.mnu025025bar.Size = new System.Drawing.Size(149, 22);
            this.mnu025025bar.Text = "-0.25~0.25 bar";
            this.mnu025025bar.Click += new System.EventHandler(this.mnu025025bar_Click);
            // 
            // mnu004bar
            // 
            this.mnu004bar.Name = "mnu004bar";
            this.mnu004bar.Size = new System.Drawing.Size(149, 22);
            this.mnu004bar.Text = "0~0.4 bar";
            this.mnu004bar.Click += new System.EventHandler(this.mnu004bar_Click);
            // 
            // ToolStripSeparator6
            // 
            this.ToolStripSeparator6.Name = "ToolStripSeparator6";
            this.ToolStripSeparator6.Size = new System.Drawing.Size(146, 6);
            // 
            // FuelWeightToolStripMenuItem
            // 
            this.FuelWeightToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu0200g,
            this.mnu0400g});
            this.FuelWeightToolStripMenuItem.Name = "FuelWeightToolStripMenuItem";
            this.FuelWeightToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.FuelWeightToolStripMenuItem.Text = "Fuel Weight";
            // 
            // mnu0200g
            // 
            this.mnu0200g.Enabled = false;
            this.mnu0200g.Name = "mnu0200g";
            this.mnu0200g.Size = new System.Drawing.Size(116, 22);
            this.mnu0200g.Text = "0~200 g";
            // 
            // mnu0400g
            // 
            this.mnu0400g.Name = "mnu0400g";
            this.mnu0400g.Size = new System.Drawing.Size(116, 22);
            this.mnu0400g.Text = "0~400 g";
            this.mnu0400g.Click += new System.EventHandler(this.mnu0400g_Click);
            // 
            // ToolStripSeparator8
            // 
            this.ToolStripSeparator8.Name = "ToolStripSeparator8";
            this.ToolStripSeparator8.Size = new System.Drawing.Size(146, 6);
            // 
            // FuelTimeToolStripMenuItem
            // 
            this.FuelTimeToolStripMenuItem.Name = "FuelTimeToolStripMenuItem";
            this.FuelTimeToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.FuelTimeToolStripMenuItem.Text = "Fuel Time";
            this.FuelTimeToolStripMenuItem.Click += new System.EventHandler(this.FuelTimeToolStripMenuItem_Click);
            // 
            // ToolStripSeparator9
            // 
            this.ToolStripSeparator9.Name = "ToolStripSeparator9";
            this.ToolStripSeparator9.Size = new System.Drawing.Size(146, 6);
            // 
            // LambdaToolStripMenuItem
            // 
            this.LambdaToolStripMenuItem.Name = "LambdaToolStripMenuItem";
            this.LambdaToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.LambdaToolStripMenuItem.Text = "Parameter";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(146, 6);
            // 
            // NotProgToolStripMenuItem
            // 
            this.NotProgToolStripMenuItem.Name = "NotProgToolStripMenuItem";
            this.NotProgToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.NotProgToolStripMenuItem.Text = "Not_Prog";
            this.NotProgToolStripMenuItem.Click += new System.EventHandler(this.NotProgToolStripMenuItem_Click);
            // 
            // tmrDi
            // 
            this.tmrDi.Tick += new System.EventHandler(this.tmrDi_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightGray;
            this.groupBox2.Controls.Add(this.DGIn);
            this.groupBox2.Controls.Add(this.btnDOSave);
            this.groupBox2.Controls.Add(this.btnDISave);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.DGDo);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox2.Location = new System.Drawing.Point(11, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(869, 728);
            this.groupBox2.TabIndex = 67;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Digital  I / O   &&  Analog  OutPuts. ";
            // 
            // DGIn
            // 
            this.DGIn.AllowUserToAddRows = false;
            this.DGIn.AllowUserToDeleteRows = false;
            this.DGIn.AllowUserToResizeColumns = false;
            this.DGIn.AllowUserToResizeRows = false;
            this.DGIn.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.DGIn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGIn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.DGIn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGIn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGIn.DefaultCellStyle = dataGridViewCellStyle14;
            this.DGIn.Enabled = false;
            this.DGIn.EnableHeadersVisualStyles = false;
            this.DGIn.Location = new System.Drawing.Point(6, 25);
            this.DGIn.Margin = new System.Windows.Forms.Padding(4);
            this.DGIn.Name = "DGIn";
            this.DGIn.RowHeadersVisible = false;
            this.DGIn.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DGIn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGIn.Size = new System.Drawing.Size(295, 392);
            this.DGIn.TabIndex = 65;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "No";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "State";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 40;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Digital Inputs";
            this.Column3.Name = "Column3";
            this.Column3.Width = 180;
            // 
            // btnDOSave
            // 
            this.btnDOSave.BackColor = System.Drawing.Color.LightGray;
            this.btnDOSave.Enabled = false;
            this.btnDOSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnDOSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDOSave.ForeColor = System.Drawing.Color.Teal;
            this.btnDOSave.Location = new System.Drawing.Point(673, 270);
            this.btnDOSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnDOSave.Name = "btnDOSave";
            this.btnDOSave.Size = new System.Drawing.Size(139, 34);
            this.btnDOSave.TabIndex = 64;
            this.btnDOSave.Text = "&Save_DO";
            this.btnDOSave.UseVisualStyleBackColor = false;
            // 
            // btnDISave
            // 
            this.btnDISave.BackColor = System.Drawing.Color.LightGray;
            this.btnDISave.Enabled = false;
            this.btnDISave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnDISave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDISave.ForeColor = System.Drawing.Color.Teal;
            this.btnDISave.Location = new System.Drawing.Point(673, 125);
            this.btnDISave.Margin = new System.Windows.Forms.Padding(4);
            this.btnDISave.Name = "btnDISave";
            this.btnDISave.Size = new System.Drawing.Size(139, 34);
            this.btnDISave.TabIndex = 63;
            this.btnDISave.Text = "&Save_DI";
            this.btnDISave.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.trackBar1);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(6, 456);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(631, 149);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Analog OutPut  . . . . ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(581, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Position In  %";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "0";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBox1.Location = new System.Drawing.Point(209, 34);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(160, 32);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "00.0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(32, 73);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(571, 49);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // DGDo
            // 
            this.DGDo.AllowUserToAddRows = false;
            this.DGDo.AllowUserToDeleteRows = false;
            this.DGDo.AllowUserToResizeColumns = false;
            this.DGDo.AllowUserToResizeRows = false;
            this.DGDo.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.DGDo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGDo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.DGDo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGDo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGDo.DefaultCellStyle = dataGridViewCellStyle16;
            this.DGDo.Enabled = false;
            this.DGDo.EnableHeadersVisualStyles = false;
            this.DGDo.Location = new System.Drawing.Point(343, 25);
            this.DGDo.Margin = new System.Windows.Forms.Padding(4);
            this.DGDo.Name = "DGDo";
            this.DGDo.RowHeadersVisible = false;
            this.DGDo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DGDo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGDo.Size = new System.Drawing.Size(295, 392);
            this.DGDo.TabIndex = 66;
            this.DGDo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGDo_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "State";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Digital OutPuts";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 180;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.treeView4);
            this.splitContainer1.Panel1.Controls.Add(this.treeView3);
            this.splitContainer1.Panel1.Controls.Add(this.treeView2);
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel1.Controls.Add(this.shapeContainer1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1370, 749);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.SplitterWidth = 15;
            this.splitContainer1.TabIndex = 68;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(71, 662);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(137, 35);
            this.button3.TabIndex = 5;
            this.button3.Text = "Close";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // treeView4
            // 
            this.treeView4.AllowDrop = true;
            this.treeView4.BackColor = System.Drawing.SystemColors.Control;
            this.treeView4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView4.HotTracking = true;
            this.treeView4.LineColor = System.Drawing.Color.DarkSlateGray;
            this.treeView4.Location = new System.Drawing.Point(16, 540);
            this.treeView4.Margin = new System.Windows.Forms.Padding(4);
            this.treeView4.Name = "treeView4";
            treeNode19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            treeNode19.Name = "Node1";
            treeNode19.Text = "InPut Parameters";
            treeNode20.ForeColor = System.Drawing.Color.Gray;
            treeNode20.Name = "Node0";
            treeNode20.Text = "ECU-Channels Inputs";
            this.treeView4.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode20});
            this.treeView4.Size = new System.Drawing.Size(264, 78);
            this.treeView4.TabIndex = 4;
            this.treeView4.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView4_AfterSelect);
            // 
            // treeView3
            // 
            this.treeView3.AllowDrop = true;
            this.treeView3.BackColor = System.Drawing.SystemColors.Control;
            this.treeView3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView3.HotTracking = true;
            this.treeView3.LineColor = System.Drawing.Color.DarkSlateGray;
            this.treeView3.Location = new System.Drawing.Point(15, 281);
            this.treeView3.Margin = new System.Windows.Forms.Padding(4);
            this.treeView3.Name = "treeView3";
            treeNode21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            treeNode21.Name = "Node1";
            treeNode21.Text = "Serial Inputs";
            treeNode22.ForeColor = System.Drawing.Color.Navy;
            treeNode22.Name = "Node3";
            treeNode22.Text = "ADAM-MODULE : 01";
            treeNode23.ForeColor = System.Drawing.Color.Navy;
            treeNode23.Name = "Node4";
            treeNode23.Text = "ADAM-MODULE : 02";
            treeNode24.ForeColor = System.Drawing.Color.Navy;
            treeNode24.Name = "Node5";
            treeNode24.Text = "ADAM-MODULE : 03";
            treeNode25.ForeColor = System.Drawing.Color.Navy;
            treeNode25.Name = "Node6";
            treeNode25.Text = "ADAM-MODULE : 04";
            treeNode26.ForeColor = System.Drawing.Color.Navy;
            treeNode26.Name = "Node7";
            treeNode26.Text = "ADAM-MODULE : 05";
            treeNode27.ForeColor = System.Drawing.Color.Gray;
            treeNode27.Name = "Node2";
            treeNode27.Text = "Module Inputs";
            treeNode28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            treeNode28.Name = "Node1";
            treeNode28.Text = "Analog Inputs";
            treeNode29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            treeNode29.Name = "Node2";
            treeNode29.Text = "Modbus Inputs";
            treeNode30.BackColor = System.Drawing.SystemColors.Control;
            treeNode30.ForeColor = System.Drawing.Color.Gray;
            treeNode30.Name = "Node0";
            treeNode30.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode30.Text = "Channel Inputs";
            this.treeView3.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode30});
            this.treeView3.Size = new System.Drawing.Size(264, 227);
            this.treeView3.TabIndex = 2;
            this.treeView3.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView3_AfterSelect);
            // 
            // treeView2
            // 
            this.treeView2.AllowDrop = true;
            this.treeView2.BackColor = System.Drawing.SystemColors.Control;
            this.treeView2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView2.HotTracking = true;
            this.treeView2.LineColor = System.Drawing.Color.Teal;
            this.treeView2.Location = new System.Drawing.Point(15, 148);
            this.treeView2.Margin = new System.Windows.Forms.Padding(4);
            this.treeView2.Name = "treeView2";
            treeNode31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            treeNode31.Name = "Node1";
            treeNode31.Text = "Digital Inputs";
            treeNode32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            treeNode32.Name = "Node3";
            treeNode32.Text = "Digital Outputs";
            treeNode33.BackColor = System.Drawing.SystemColors.Control;
            treeNode33.ForeColor = System.Drawing.Color.Gray;
            treeNode33.Name = "Node0";
            treeNode33.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode33.Text = "Digital In/Out";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode33});
            this.treeView2.Size = new System.Drawing.Size(264, 102);
            this.treeView2.TabIndex = 1;
            this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.BackColor = System.Drawing.SystemColors.Control;
            this.treeView1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.HotTracking = true;
            this.treeView1.LineColor = System.Drawing.Color.Teal;
            this.treeView1.Location = new System.Drawing.Point(15, 13);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.Name = "treeView1";
            treeNode34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            treeNode34.Name = "Node1";
            treeNode34.Text = "SetPoint - 1";
            treeNode35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            treeNode35.Name = "Node3";
            treeNode35.Text = "SetPoint - 2";
            treeNode36.BackColor = System.Drawing.SystemColors.Control;
            treeNode36.Checked = true;
            treeNode36.ForeColor = System.Drawing.Color.Gray;
            treeNode36.Name = "Node0";
            treeNode36.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode36.Text = "Set Points";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode36});
            this.treeView1.Size = new System.Drawing.Size(264, 102);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape5,
            this.lineShape4,
            this.lineShape3,
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(296, 745);
            this.shapeContainer1.TabIndex = 3;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape5
            // 
            this.lineShape5.BorderColor = System.Drawing.Color.DarkBlue;
            this.lineShape5.Name = "lineShape5";
            this.lineShape5.X1 = -50;
            this.lineShape5.X2 = 346;
            this.lineShape5.Y1 = 521;
            this.lineShape5.Y2 = 521;
            // 
            // lineShape4
            // 
            this.lineShape4.BorderColor = System.Drawing.Color.DarkBlue;
            this.lineShape4.Name = "lineShape4";
            this.lineShape4.X1 = -1;
            this.lineShape4.X2 = 398;
            this.lineShape4.Y1 = 798;
            this.lineShape4.Y2 = 798;
            // 
            // lineShape3
            // 
            this.lineShape3.BorderColor = System.Drawing.Color.DarkBlue;
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = -1;
            this.lineShape3.X2 = 396;
            this.lineShape3.Y1 = 632;
            this.lineShape3.Y2 = 632;
            // 
            // lineShape2
            // 
            this.lineShape2.BorderColor = System.Drawing.Color.DarkBlue;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = -1;
            this.lineShape2.X2 = 395;
            this.lineShape2.Y1 = 265;
            this.lineShape2.Y2 = 265;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 0;
            this.lineShape1.X2 = 396;
            this.lineShape1.Y1 = 129;
            this.lineShape1.Y2 = 129;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Controls.Add(this.textBox5);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.dataGridView2);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Controls.Add(this.checkBox2);
            this.groupBox4.Controls.Add(this.cmbEUnit);
            this.groupBox4.Controls.Add(this.textBox6);
            this.groupBox4.Controls.Add(this.textBox7);
            this.groupBox4.Controls.Add(this.textBox8);
            this.groupBox4.Controls.Add(this.textBox9);
            this.groupBox4.Controls.Add(this.textBox10);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox4.Location = new System.Drawing.Point(11, 15);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(1256, 731);
            this.groupBox4.TabIndex = 74;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ECU - Parameter  Inputs  .......";
            // 
            // button4
            // 
            this.button4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button4.BackColor = System.Drawing.Color.Silver;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Maroon;
            this.button4.Location = new System.Drawing.Point(436, 185);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 30);
            this.button4.TabIndex = 71;
            this.button4.Text = "&Not Prog";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(363, 120);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 70;
            this.label5.Text = "Min. Value :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Navy;
            this.textBox2.Location = new System.Drawing.Point(151, 113);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(203, 27);
            this.textBox2.TabIndex = 69;
            this.textBox2.Text = "0";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.ForeColor = System.Drawing.Color.Navy;
            this.textBox5.Location = new System.Drawing.Point(436, 112);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(83, 27);
            this.textBox5.TabIndex = 68;
            this.textBox5.Text = "10";
            this.textBox5.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(87, 121);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 15);
            this.label8.TabIndex = 67;
            this.label8.Text = "Address :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(406, 23);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 36);
            this.label9.TabIndex = 64;
            this.label9.Text = "000";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridView2.ColumnHeadersHeight = 35;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewCheckBoxColumn2,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13});
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.GridColor = System.Drawing.Color.LightGray;
            this.dataGridView2.Location = new System.Drawing.Point(21, 275);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(868, 371);
            this.dataGridView2.TabIndex = 62;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseClick);
            // 
            // button5
            // 
            this.button5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button5.BackColor = System.Drawing.Color.Silver;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Maroon;
            this.button5.Location = new System.Drawing.Point(436, 228);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(83, 30);
            this.button5.TabIndex = 61;
            this.button5.Text = "&Save";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.Green;
            this.checkBox2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.ForeColor = System.Drawing.Color.Yellow;
            this.checkBox2.Location = new System.Drawing.Point(265, 51);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(85, 23);
            this.checkBox2.TabIndex = 56;
            this.checkBox2.Text = "Unselect";
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // cmbEUnit
            // 
            this.cmbEUnit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbEUnit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEUnit.ForeColor = System.Drawing.Color.Navy;
            this.cmbEUnit.Items.AddRange(new object[] {
            "°C",
            "°F",
            "bar",
            "mbar",
            "kg/cm^2",
            "mmHg",
            "kPa",
            "Nm",
            "kgm",
            "kg",
            "g",
            "sec"});
            this.cmbEUnit.Location = new System.Drawing.Point(151, 217);
            this.cmbEUnit.Margin = new System.Windows.Forms.Padding(4, 4, 15, 4);
            this.cmbEUnit.Name = "cmbEUnit";
            this.cmbEUnit.Size = new System.Drawing.Size(203, 27);
            this.cmbEUnit.TabIndex = 54;
            this.cmbEUnit.Text = "r/min";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.ForeColor = System.Drawing.Color.Navy;
            this.textBox6.Location = new System.Drawing.Point(151, 183);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(203, 27);
            this.textBox6.TabIndex = 53;
            this.textBox6.Text = "Short Name";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.ForeColor = System.Drawing.Color.Navy;
            this.textBox7.Location = new System.Drawing.Point(436, 147);
            this.textBox7.Margin = new System.Windows.Forms.Padding(4);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(83, 27);
            this.textBox7.TabIndex = 52;
            this.textBox7.Text = "10000";
            this.textBox7.Visible = false;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.ForeColor = System.Drawing.Color.Navy;
            this.textBox8.Location = new System.Drawing.Point(151, 147);
            this.textBox8.Margin = new System.Windows.Forms.Padding(4);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(203, 27);
            this.textBox8.TabIndex = 51;
            this.textBox8.Text = "0";
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.ForeColor = System.Drawing.Color.Navy;
            this.textBox9.Location = new System.Drawing.Point(151, 78);
            this.textBox9.Margin = new System.Windows.Forms.Padding(4);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(203, 27);
            this.textBox9.TabIndex = 50;
            this.textBox9.Text = "ECU-Parameter";
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox10.Enabled = false;
            this.textBox10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.ForeColor = System.Drawing.Color.Navy;
            this.textBox10.Location = new System.Drawing.Point(151, 48);
            this.textBox10.Margin = new System.Windows.Forms.Padding(4);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(27, 27);
            this.textBox10.TabIndex = 49;
            this.textBox10.Text = "00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(59, 190);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 18);
            this.label10.TabIndex = 48;
            this.label10.Text = "Short Name:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(111, 226);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 15);
            this.label11.TabIndex = 47;
            this.label11.Text = "Unit:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(363, 152);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 15);
            this.label12.TabIndex = 46;
            this.label12.Text = "Max. Value:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label12.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(11, 154);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(133, 18);
            this.label13.TabIndex = 45;
            this.label13.Text = "Multification Factor :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(27, 85);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 18);
            this.label14.TabIndex = 44;
            this.label14.Text = "Parameter Name:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(62, 49);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 18);
            this.label15.TabIndex = 43;
            this.label15.Text = "Channel no.";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(1340, 265);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 37);
            this.button1.TabIndex = 73;
            this.button1.Text = "Help";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightGray;
            this.button2.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button2.Location = new System.Drawing.Point(1340, 310);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 37);
            this.button2.TabIndex = 72;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightGray;
            this.groupBox1.Controls.Add(this.btnNa);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DgModule);
            this.groupBox1.Controls.Add(this.InGrid);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.CheckBox1);
            this.groupBox1.Controls.Add(this.cmbunit);
            this.groupBox1.Controls.Add(this.txtshname);
            this.groupBox1.Controls.Add(this.txtmaxval);
            this.groupBox1.Controls.Add(this.txtminval);
            this.groupBox1.Controls.Add(this.txtparaname);
            this.groupBox1.Controls.Add(this.txtchno);
            this.groupBox1.Controls.Add(this.Label22);
            this.groupBox1.Controls.Add(this.Label23);
            this.groupBox1.Controls.Add(this.Label24);
            this.groupBox1.Controls.Add(this.Label35);
            this.groupBox1.Controls.Add(this.Label36);
            this.groupBox1.Controls.Add(this.Label37);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(11, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1256, 731);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameter  Inputs  .......";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnNa
            // 
            this.btnNa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNa.BackColor = System.Drawing.Color.Silver;
            this.btnNa.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnNa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNa.ForeColor = System.Drawing.Color.Maroon;
            this.btnNa.Location = new System.Drawing.Point(409, 161);
            this.btnNa.Margin = new System.Windows.Forms.Padding(4);
            this.btnNa.Name = "btnNa";
            this.btnNa.Size = new System.Drawing.Size(83, 30);
            this.btnNa.TabIndex = 71;
            this.btnNa.Text = "&Not Prog";
            this.btnNa.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnNa.UseVisualStyleBackColor = false;
            this.btnNa.Click += new System.EventHandler(this.btnNa_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(218, 120);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 19);
            this.label7.TabIndex = 70;
            this.label7.Text = "~";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.Navy;
            this.textBox3.Location = new System.Drawing.Point(141, 113);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(71, 27);
            this.textBox3.TabIndex = 69;
            this.textBox3.Text = "0";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.Navy;
            this.textBox4.Location = new System.Drawing.Point(243, 112);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(71, 27);
            this.textBox4.TabIndex = 68;
            this.textBox4.Text = "10";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(90, 118);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 15);
            this.label6.TabIndex = 67;
            this.label6.Text = "Range:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(335, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 36);
            this.label4.TabIndex = 64;
            this.label4.Text = "000";
            // 
            // DgModule
            // 
            this.DgModule.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgModule.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.DgModule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgModule.ColumnHeadersVisible = false;
            this.DgModule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column15});
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgModule.DefaultCellStyle = dataGridViewCellStyle21;
            this.DgModule.Location = new System.Drawing.Point(421, 16);
            this.DgModule.Margin = new System.Windows.Forms.Padding(4);
            this.DgModule.MultiSelect = false;
            this.DgModule.Name = "DgModule";
            this.DgModule.ReadOnly = true;
            this.DgModule.RowHeadersVisible = false;
            this.DgModule.RowTemplate.Height = 20;
            this.DgModule.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DgModule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgModule.Size = new System.Drawing.Size(256, 134);
            this.DgModule.TabIndex = 63;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Add";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 30;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Module";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "Range";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Width = 120;
            // 
            // InGrid
            // 
            this.InGrid.AllowUserToAddRows = false;
            this.InGrid.AllowUserToDeleteRows = false;
            this.InGrid.AllowUserToResizeColumns = false;
            this.InGrid.AllowUserToResizeRows = false;
            this.InGrid.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.InGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.InGrid.ColumnHeadersHeight = 40;
            this.InGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.InGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14});
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.InGrid.DefaultCellStyle = dataGridViewCellStyle23;
            this.InGrid.EnableHeadersVisualStyles = false;
            this.InGrid.GridColor = System.Drawing.Color.LightGray;
            this.InGrid.Location = new System.Drawing.Point(21, 275);
            this.InGrid.Margin = new System.Windows.Forms.Padding(4);
            this.InGrid.MultiSelect = false;
            this.InGrid.Name = "InGrid";
            this.InGrid.ReadOnly = true;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.InGrid.RowHeadersVisible = false;
            this.InGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InGrid.Size = new System.Drawing.Size(743, 371);
            this.InGrid.TabIndex = 62;
            this.InGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InGrid_CellContentClick);
            this.InGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.InGrid_CellMouseClick);
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Pn";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 40;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "ParameterName";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 150;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Min";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 60;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Max";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 80;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Unit";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "ShortName";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 120;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Mrk";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column12.Width = 40;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "MinP";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Width = 60;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "MaxP";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 80;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdd.BackColor = System.Drawing.Color.Silver;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Maroon;
            this.btnAdd.Location = new System.Drawing.Point(409, 230);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 30);
            this.btnAdd.TabIndex = 61;
            this.btnAdd.Text = "&Save";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.BackColor = System.Drawing.Color.Green;
            this.CheckBox1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBox1.ForeColor = System.Drawing.Color.Yellow;
            this.CheckBox1.Location = new System.Drawing.Point(208, 51);
            this.CheckBox1.Margin = new System.Windows.Forms.Padding(4);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(85, 23);
            this.CheckBox1.TabIndex = 56;
            this.CheckBox1.Text = "Unselect";
            this.CheckBox1.UseVisualStyleBackColor = false;
            // 
            // cmbunit
            // 
            this.cmbunit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmbunit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbunit.ForeColor = System.Drawing.Color.Navy;
            this.cmbunit.Items.AddRange(new object[] {
            "°C",
            "°F",
            "bar",
            "mbar",
            "kg/cm^2",
            "mmHg",
            "kPa",
            "Nm",
            "kgm",
            "kg",
            "g",
            "sec"});
            this.cmbunit.Location = new System.Drawing.Point(138, 217);
            this.cmbunit.Margin = new System.Windows.Forms.Padding(4, 4, 15, 4);
            this.cmbunit.Name = "cmbunit";
            this.cmbunit.Size = new System.Drawing.Size(82, 27);
            this.cmbunit.TabIndex = 54;
            this.cmbunit.Text = "r/min";
            // 
            // txtshname
            // 
            this.txtshname.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtshname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtshname.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtshname.ForeColor = System.Drawing.Color.Navy;
            this.txtshname.Location = new System.Drawing.Point(141, 183);
            this.txtshname.Margin = new System.Windows.Forms.Padding(4);
            this.txtshname.Name = "txtshname";
            this.txtshname.Size = new System.Drawing.Size(178, 27);
            this.txtshname.TabIndex = 53;
            this.txtshname.Text = "Short Name";
            // 
            // txtmaxval
            // 
            this.txtmaxval.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtmaxval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmaxval.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmaxval.ForeColor = System.Drawing.Color.Navy;
            this.txtmaxval.Location = new System.Drawing.Point(296, 147);
            this.txtmaxval.Margin = new System.Windows.Forms.Padding(4);
            this.txtmaxval.Name = "txtmaxval";
            this.txtmaxval.Size = new System.Drawing.Size(56, 27);
            this.txtmaxval.TabIndex = 52;
            this.txtmaxval.Text = "10000";
            // 
            // txtminval
            // 
            this.txtminval.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtminval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtminval.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtminval.ForeColor = System.Drawing.Color.Navy;
            this.txtminval.Location = new System.Drawing.Point(141, 147);
            this.txtminval.Margin = new System.Windows.Forms.Padding(4);
            this.txtminval.Name = "txtminval";
            this.txtminval.Size = new System.Drawing.Size(51, 27);
            this.txtminval.TabIndex = 51;
            this.txtminval.Text = "0";
            // 
            // txtparaname
            // 
            this.txtparaname.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtparaname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtparaname.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtparaname.ForeColor = System.Drawing.Color.Navy;
            this.txtparaname.Location = new System.Drawing.Point(141, 78);
            this.txtparaname.Margin = new System.Windows.Forms.Padding(4);
            this.txtparaname.Name = "txtparaname";
            this.txtparaname.Size = new System.Drawing.Size(211, 27);
            this.txtparaname.TabIndex = 50;
            this.txtparaname.Text = "Engine Revolutions";
            // 
            // txtchno
            // 
            this.txtchno.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtchno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtchno.Enabled = false;
            this.txtchno.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtchno.ForeColor = System.Drawing.Color.Navy;
            this.txtchno.Location = new System.Drawing.Point(141, 48);
            this.txtchno.Margin = new System.Windows.Forms.Padding(4);
            this.txtchno.Name = "txtchno";
            this.txtchno.Size = new System.Drawing.Size(27, 27);
            this.txtchno.TabIndex = 49;
            this.txtchno.Text = "00";
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label22.ForeColor = System.Drawing.Color.Black;
            this.Label22.Location = new System.Drawing.Point(41, 183);
            this.Label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(85, 18);
            this.Label22.TabIndex = 48;
            this.Label22.Text = "Short Name:";
            this.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label23.ForeColor = System.Drawing.Color.Black;
            this.Label23.Location = new System.Drawing.Point(99, 225);
            this.Label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(33, 15);
            this.Label23.TabIndex = 47;
            this.Label23.Text = "Unit:";
            this.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label24
            // 
            this.Label24.AutoSize = true;
            this.Label24.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label24.ForeColor = System.Drawing.Color.Black;
            this.Label24.Location = new System.Drawing.Point(224, 152);
            this.Label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(70, 15);
            this.Label24.TabIndex = 46;
            this.Label24.Text = "Max. Value:";
            this.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label35
            // 
            this.Label35.AutoSize = true;
            this.Label35.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label35.ForeColor = System.Drawing.Color.Black;
            this.Label35.Location = new System.Drawing.Point(48, 147);
            this.Label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(78, 18);
            this.Label35.TabIndex = 45;
            this.Label35.Text = "Min. Value:";
            this.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label36
            // 
            this.Label36.AutoSize = true;
            this.Label36.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label36.ForeColor = System.Drawing.Color.Black;
            this.Label36.Location = new System.Drawing.Point(9, 78);
            this.Label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label36.Name = "Label36";
            this.Label36.Size = new System.Drawing.Size(117, 18);
            this.Label36.TabIndex = 44;
            this.Label36.Text = "Parameter Name:";
            this.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label37
            // 
            this.Label37.AutoSize = true;
            this.Label37.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label37.ForeColor = System.Drawing.Color.Black;
            this.Label37.Location = new System.Drawing.Point(44, 48);
            this.Label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(82, 18);
            this.Label37.TabIndex = 43;
            this.Label37.Text = "Channel no.";
            this.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Pn";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 40;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "ParameterName";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn8.HeaderText = "Address";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Mulfactor ";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "ShortName";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 120;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.HeaderText = "Mrk";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn2.Width = 40;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "Min";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 60;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "Max";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 80;
            // 
            // frmConf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Book Antiqua", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConf";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input / Output Configuration";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConf_Load);
            this.ContextMenuStrip1.ResumeLayout(false);
            this.ContextMenuStrip2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGIn)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGDo)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrDigIn;
        internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem mnu4018;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator4;
        internal System.Windows.Forms.ToolStripMenuItem mnu4017;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator7;
        internal System.Windows.Forms.ToolStripMenuItem mnu4015;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator10;
        internal System.Windows.Forms.ToolStripMenuItem mnuDelete;
        internal System.Windows.Forms.ContextMenuStrip ContextMenuStrip2;
        internal System.Windows.Forms.ToolStripMenuItem EngineRPMToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mnu05000;
        internal System.Windows.Forms.ToolStripMenuItem mnu010000;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        internal System.Windows.Forms.ToolStripMenuItem EngineTorqueToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mnu0100Nm;
        internal System.Windows.Forms.ToolStripMenuItem mnu0200Nm;
        internal System.Windows.Forms.ToolStripMenuItem mnu0500Nm;
        internal System.Windows.Forms.ToolStripMenuItem nmu01000Nm;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        internal System.Windows.Forms.ToolStripMenuItem TemperatureToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mnu0200C;
        internal System.Windows.Forms.ToolStripMenuItem mnu0400C;
        internal System.Windows.Forms.ToolStripMenuItem mnu0600C;
        internal System.Windows.Forms.ToolStripMenuItem mnu01000C;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator5;
        internal System.Windows.Forms.ToolStripMenuItem PressuresToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mnu010bar;
        internal System.Windows.Forms.ToolStripMenuItem mnu025bar;
        internal System.Windows.Forms.ToolStripMenuItem mnu0812bar;
        internal System.Windows.Forms.ToolStripMenuItem mnu025025bar;
        internal System.Windows.Forms.ToolStripMenuItem mnu004bar;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator6;
        internal System.Windows.Forms.ToolStripMenuItem FuelWeightToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem mnu0200g;
        internal System.Windows.Forms.ToolStripMenuItem mnu0400g;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator8;
        internal System.Windows.Forms.ToolStripMenuItem FuelTimeToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator9;
        internal System.Windows.Forms.ToolStripMenuItem LambdaToolStripMenuItem;
        internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        internal System.Windows.Forms.ToolStripMenuItem NotProgToolStripMenuItem;
        private System.Windows.Forms.Timer tmrDi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button btnDOSave;
        private System.Windows.Forms.Button btnDISave;
        private System.Windows.Forms.DataGridView DGIn;
        private System.Windows.Forms.DataGridView DGDo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.TreeView treeView3;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DgModule;
        private System.Windows.Forms.DataGridView InGrid;
        private System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.CheckBox CheckBox1;
        internal System.Windows.Forms.ComboBox cmbunit;
        internal System.Windows.Forms.TextBox txtshname;
        internal System.Windows.Forms.TextBox txtmaxval;
        internal System.Windows.Forms.TextBox txtminval;
        internal System.Windows.Forms.TextBox txtparaname;
        internal System.Windows.Forms.TextBox txtchno;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.Label Label24;
        internal System.Windows.Forms.Label Label35;
        internal System.Windows.Forms.Label Label36;
        internal System.Windows.Forms.Label Label37;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox textBox3;
        internal System.Windows.Forms.TextBox textBox4;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.Button btnNa;
        private System.Windows.Forms.TreeView treeView4;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button4;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox textBox2;
        internal System.Windows.Forms.TextBox textBox5;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button5;
        internal System.Windows.Forms.CheckBox checkBox2;
        internal System.Windows.Forms.ComboBox cmbEUnit;
        internal System.Windows.Forms.TextBox textBox6;
        internal System.Windows.Forms.TextBox textBox7;
        internal System.Windows.Forms.TextBox textBox8;
        internal System.Windows.Forms.TextBox textBox9;
        internal System.Windows.Forms.TextBox textBox10;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label label13;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
	}
}