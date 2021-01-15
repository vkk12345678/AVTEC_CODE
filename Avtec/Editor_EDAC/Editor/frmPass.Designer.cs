namespace Editor
{
    partial class frmPass
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btndelete = new System.Windows.Forms.Button();
            this.txtConfPass_Opr = new System.Windows.Forms.TextBox();
            this.txtNewpass_Opr = new System.Windows.Forms.TextBox();
            this.txtOLDPass_Opr = new System.Windows.Forms.TextBox();
            this.txtOpNm_Opr = new System.Windows.Forms.TextBox();
            this.txtSupPass_OPR = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuNewUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExisting = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSupClose = new System.Windows.Forms.Button();
            this.btnsupSave = new System.Windows.Forms.Button();
            this.txtConfPass_SUP = new System.Windows.Forms.TextBox();
            this.txtNewPass_SUP = new System.Windows.Forms.TextBox();
            this.txtOldPass_SUP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnserclose = new System.Windows.Forms.Button();
            this.btnserSave = new System.Windows.Forms.Button();
            this.txtOldPass_Ser = new System.Windows.Forms.TextBox();
            this.txtNewPass_Ser = new System.Windows.Forms.TextBox();
            this.txtConfPass_Ser = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(327, 100);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(360, 362);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Validating += new System.ComponentModel.CancelEventHandler(this.tabControl1_Validating);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.btnclose);
            this.tabPage1.Controls.Add(this.btnsave);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.btndelete);
            this.tabPage1.Controls.Add(this.txtConfPass_Opr);
            this.tabPage1.Controls.Add(this.txtNewpass_Opr);
            this.tabPage1.Controls.Add(this.txtOLDPass_Opr);
            this.tabPage1.Controls.Add(this.txtOpNm_Opr);
            this.tabPage1.Controls.Add(this.txtSupPass_OPR);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.menuStrip1);
            this.tabPage1.ForeColor = System.Drawing.Color.Navy;
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(352, 328);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Operator";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnclose
            // 
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.ForeColor = System.Drawing.Color.Navy;
            this.btnclose.Location = new System.Drawing.Point(256, 281);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 29);
            this.btnclose.TabIndex = 16;
            this.btnclose.Text = "&Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.Navy;
            this.btnsave.Location = new System.Drawing.Point(40, 281);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 29);
            this.btnsave.TabIndex = 15;
            this.btnsave.Text = "&Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(166, 86);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(123, 26);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btndelete
            // 
            this.btndelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.Color.Navy;
            this.btndelete.Location = new System.Drawing.Point(148, 281);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 29);
            this.btndelete.TabIndex = 14;
            this.btndelete.Text = "&Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // txtConfPass_Opr
            // 
            this.txtConfPass_Opr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfPass_Opr.Location = new System.Drawing.Point(167, 222);
            this.txtConfPass_Opr.Name = "txtConfPass_Opr";
            this.txtConfPass_Opr.PasswordChar = '*';
            this.txtConfPass_Opr.Size = new System.Drawing.Size(122, 24);
            this.txtConfPass_Opr.TabIndex = 10;
            this.txtConfPass_Opr.TextChanged += new System.EventHandler(this.txtConfPass_Opr_TextChanged);
            // 
            // txtNewpass_Opr
            // 
            this.txtNewpass_Opr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewpass_Opr.Location = new System.Drawing.Point(167, 176);
            this.txtNewpass_Opr.Name = "txtNewpass_Opr";
            this.txtNewpass_Opr.PasswordChar = '*';
            this.txtNewpass_Opr.Size = new System.Drawing.Size(122, 24);
            this.txtNewpass_Opr.TabIndex = 9;
            // 
            // txtOLDPass_Opr
            // 
            this.txtOLDPass_Opr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOLDPass_Opr.Location = new System.Drawing.Point(167, 130);
            this.txtOLDPass_Opr.Name = "txtOLDPass_Opr";
            this.txtOLDPass_Opr.PasswordChar = '*';
            this.txtOLDPass_Opr.Size = new System.Drawing.Size(122, 24);
            this.txtOLDPass_Opr.TabIndex = 8;
            // 
            // txtOpNm_Opr
            // 
            this.txtOpNm_Opr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOpNm_Opr.Location = new System.Drawing.Point(165, 86);
            this.txtOpNm_Opr.Name = "txtOpNm_Opr";
            this.txtOpNm_Opr.Size = new System.Drawing.Size(122, 24);
            this.txtOpNm_Opr.TabIndex = 7;
            // 
            // txtSupPass_OPR
            // 
            this.txtSupPass_OPR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSupPass_OPR.Location = new System.Drawing.Point(167, 36);
            this.txtSupPass_OPR.Name = "txtSupPass_OPR";
            this.txtSupPass_OPR.Size = new System.Drawing.Size(122, 24);
            this.txtSupPass_OPR.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(20, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "Confirm  Password :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(45, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "New Password :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(50, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 18);
            this.label3.TabIndex = 3;
            this.label3.Tag = "Old";
            this.label3.Text = "Old Password :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(38, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = " Operator Name :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(5, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Supervisor Password :";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SkyBlue;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewUser,
            this.mnuExisting,
            this.deleteUserToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(344, 26);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuNewUser
            // 
            this.mnuNewUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuNewUser.Name = "mnuNewUser";
            this.mnuNewUser.Size = new System.Drawing.Size(86, 22);
            this.mnuNewUser.Text = "New User";
            this.mnuNewUser.Click += new System.EventHandler(this.mnuNewUser_Click);
            // 
            // mnuExisting
            // 
            this.mnuExisting.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuExisting.Name = "mnuExisting";
            this.mnuExisting.Size = new System.Drawing.Size(107, 22);
            this.mnuExisting.Text = "Existing User";
            this.mnuExisting.Click += new System.EventHandler(this.mnuExisting_Click);
            // 
            // deleteUserToolStripMenuItem
            // 
            this.deleteUserToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteUserToolStripMenuItem.Name = "deleteUserToolStripMenuItem";
            this.deleteUserToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.deleteUserToolStripMenuItem.Text = "Delete User";
            this.deleteUserToolStripMenuItem.Click += new System.EventHandler(this.deleteUserToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSupClose);
            this.tabPage2.Controls.Add(this.btnsupSave);
            this.tabPage2.Controls.Add(this.txtConfPass_SUP);
            this.tabPage2.Controls.Add(this.txtNewPass_SUP);
            this.tabPage2.Controls.Add(this.txtOldPass_SUP);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(352, 328);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Supervisor";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSupClose
            // 
            this.btnSupClose.BackColor = System.Drawing.Color.Transparent;
            this.btnSupClose.ForeColor = System.Drawing.Color.Navy;
            this.btnSupClose.Location = new System.Drawing.Point(220, 180);
            this.btnSupClose.Name = "btnSupClose";
            this.btnSupClose.Size = new System.Drawing.Size(75, 38);
            this.btnSupClose.TabIndex = 20;
            this.btnSupClose.Text = "&Close";
            this.btnSupClose.UseVisualStyleBackColor = false;
            this.btnSupClose.Click += new System.EventHandler(this.btnSupClose_Click);
            // 
            // btnsupSave
            // 
            this.btnsupSave.BackColor = System.Drawing.Color.Transparent;
            this.btnsupSave.ForeColor = System.Drawing.Color.Navy;
            this.btnsupSave.Location = new System.Drawing.Point(83, 182);
            this.btnsupSave.Name = "btnsupSave";
            this.btnsupSave.Size = new System.Drawing.Size(81, 34);
            this.btnsupSave.TabIndex = 19;
            this.btnsupSave.Text = "&Save";
            this.btnsupSave.UseVisualStyleBackColor = false;
            this.btnsupSave.Click += new System.EventHandler(this.btnsupSave_Click);
            // 
            // txtConfPass_SUP
            // 
            this.txtConfPass_SUP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfPass_SUP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfPass_SUP.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtConfPass_SUP.Location = new System.Drawing.Point(175, 119);
            this.txtConfPass_SUP.Name = "txtConfPass_SUP";
            this.txtConfPass_SUP.PasswordChar = '*';
            this.txtConfPass_SUP.Size = new System.Drawing.Size(122, 31);
            this.txtConfPass_SUP.TabIndex = 17;
            // 
            // txtNewPass_SUP
            // 
            this.txtNewPass_SUP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPass_SUP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPass_SUP.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtNewPass_SUP.Location = new System.Drawing.Point(175, 73);
            this.txtNewPass_SUP.Name = "txtNewPass_SUP";
            this.txtNewPass_SUP.PasswordChar = '*';
            this.txtNewPass_SUP.Size = new System.Drawing.Size(122, 31);
            this.txtNewPass_SUP.TabIndex = 16;
            // 
            // txtOldPass_SUP
            // 
            this.txtOldPass_SUP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOldPass_SUP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPass_SUP.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtOldPass_SUP.Location = new System.Drawing.Point(175, 27);
            this.txtOldPass_SUP.Name = "txtOldPass_SUP";
            this.txtOldPass_SUP.PasswordChar = '*';
            this.txtOldPass_SUP.Size = new System.Drawing.Size(122, 31);
            this.txtOldPass_SUP.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(9, 123);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(144, 18);
            this.label11.TabIndex = 14;
            this.label11.Text = "Confirm  Password :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Navy;
            this.label12.Location = new System.Drawing.Point(34, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 18);
            this.label12.TabIndex = 13;
            this.label12.Text = "New Password :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(39, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 18);
            this.label13.TabIndex = 12;
            this.label13.Tag = "Old";
            this.label13.Text = "Old Password :";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnserclose);
            this.tabPage3.Controls.Add(this.btnserSave);
            this.tabPage3.Controls.Add(this.txtOldPass_Ser);
            this.tabPage3.Controls.Add(this.txtNewPass_Ser);
            this.tabPage3.Controls.Add(this.txtConfPass_Ser);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(352, 328);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Service";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnserclose
            // 
            this.btnserclose.ForeColor = System.Drawing.Color.Navy;
            this.btnserclose.Location = new System.Drawing.Point(180, 184);
            this.btnserclose.Name = "btnserclose";
            this.btnserclose.Size = new System.Drawing.Size(75, 33);
            this.btnserclose.TabIndex = 27;
            this.btnserclose.Text = "&Close";
            this.btnserclose.UseVisualStyleBackColor = true;
            this.btnserclose.Click += new System.EventHandler(this.btnserclose_Click);
            // 
            // btnserSave
            // 
            this.btnserSave.ForeColor = System.Drawing.Color.Navy;
            this.btnserSave.Location = new System.Drawing.Point(76, 184);
            this.btnserSave.Name = "btnserSave";
            this.btnserSave.Size = new System.Drawing.Size(75, 33);
            this.btnserSave.TabIndex = 26;
            this.btnserSave.Text = "&Save";
            this.btnserSave.UseVisualStyleBackColor = true;
            this.btnserSave.Click += new System.EventHandler(this.btnserSave_Click);
            // 
            // txtOldPass_Ser
            // 
            this.txtOldPass_Ser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOldPass_Ser.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtOldPass_Ser.Location = new System.Drawing.Point(169, 20);
            this.txtOldPass_Ser.Name = "txtOldPass_Ser";
            this.txtOldPass_Ser.PasswordChar = '*';
            this.txtOldPass_Ser.Size = new System.Drawing.Size(122, 24);
            this.txtOldPass_Ser.TabIndex = 22;
            // 
            // txtNewPass_Ser
            // 
            this.txtNewPass_Ser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPass_Ser.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtNewPass_Ser.Location = new System.Drawing.Point(169, 66);
            this.txtNewPass_Ser.Name = "txtNewPass_Ser";
            this.txtNewPass_Ser.PasswordChar = '*';
            this.txtNewPass_Ser.Size = new System.Drawing.Size(122, 24);
            this.txtNewPass_Ser.TabIndex = 23;
            // 
            // txtConfPass_Ser
            // 
            this.txtConfPass_Ser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfPass_Ser.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtConfPass_Ser.Location = new System.Drawing.Point(169, 112);
            this.txtConfPass_Ser.Name = "txtConfPass_Ser";
            this.txtConfPass_Ser.PasswordChar = '*';
            this.txtConfPass_Ser.Size = new System.Drawing.Size(122, 24);
            this.txtConfPass_Ser.TabIndex = 24;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Navy;
            this.label14.Location = new System.Drawing.Point(8, 112);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(149, 20);
            this.label14.TabIndex = 21;
            this.label14.Text = "Confirm  Password :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Navy;
            this.label15.Location = new System.Drawing.Point(31, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(121, 20);
            this.label15.TabIndex = 20;
            this.label15.Text = "New Password :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Navy;
            this.label16.Location = new System.Drawing.Point(36, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(114, 20);
            this.label16.TabIndex = 19;
            this.label16.Tag = "Old";
            this.label16.Text = "Old Password :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Location = new System.Drawing.Point(300, 20);
            this.Name = "frmPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.frmPass_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.TextBox txtConfPass_Opr;
        private System.Windows.Forms.TextBox txtNewpass_Opr;
        private System.Windows.Forms.TextBox txtOLDPass_Opr;
        private System.Windows.Forms.TextBox txtOpNm_Opr;
        private System.Windows.Forms.TextBox txtSupPass_OPR;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuNewUser;
        private System.Windows.Forms.ToolStripMenuItem mnuExisting;
        private System.Windows.Forms.ToolStripMenuItem deleteUserToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSupClose;
        private System.Windows.Forms.Button btnsupSave;
        private System.Windows.Forms.TextBox txtConfPass_SUP;
        private System.Windows.Forms.TextBox txtNewPass_SUP;
        private System.Windows.Forms.TextBox txtOldPass_SUP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnserclose;
        private System.Windows.Forms.Button btnserSave;
        private System.Windows.Forms.TextBox txtOldPass_Ser;
        private System.Windows.Forms.TextBox txtNewPass_Ser;
        private System.Windows.Forms.TextBox txtConfPass_Ser;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}