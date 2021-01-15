namespace Editor
{
    partial class MDIParent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnLogs = new System.Windows.Forms.Button();
            this.btnPassout = new System.Windows.Forms.Button();
            this.btnPrj = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnPassword = new System.Windows.Forms.Button();
            this.btnFormat = new System.Windows.Forms.Button();
            this.btnSequence = new System.Windows.Forms.Button();
            this.btnLimit = new System.Windows.Forms.Button();
            this.btnEngine = new System.Windows.Forms.Button();
            this.tmrLogin = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Panel1.Controls.Add(this.btnLogs);
            this.splitContainer1.Panel1.Controls.Add(this.btnPassout);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrj);
            this.splitContainer1.Panel1.Controls.Add(this.btnClose);
            this.splitContainer1.Panel1.Controls.Add(this.btnHelp);
            this.splitContainer1.Panel1.Controls.Add(this.btnPassword);
            this.splitContainer1.Panel1.Controls.Add(this.btnFormat);
            this.splitContainer1.Panel1.Controls.Add(this.btnSequence);
            this.splitContainer1.Panel1.Controls.Add(this.btnLimit);
            this.splitContainer1.Panel1.Controls.Add(this.btnEngine);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.splitContainer1.Size = new System.Drawing.Size(1370, 749);
            this.splitContainer1.SplitterDistance = 290;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 10;
            // 
            // btnLogs
            // 
            this.btnLogs.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogs.BackColor = System.Drawing.Color.LightGray;
            this.btnLogs.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnLogs.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnLogs.Location = new System.Drawing.Point(14, 130);
            this.btnLogs.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(235, 44);
            this.btnLogs.TabIndex = 19;
            this.btnLogs.Text = "LOGS";
            this.btnLogs.UseVisualStyleBackColor = false;
            this.btnLogs.Visible = false;
            // 
            // btnPassout
            // 
            this.btnPassout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPassout.BackColor = System.Drawing.Color.LightGray;
            this.btnPassout.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnPassout.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPassout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnPassout.Location = new System.Drawing.Point(14, 62);
            this.btnPassout.Margin = new System.Windows.Forms.Padding(4);
            this.btnPassout.Name = "btnPassout";
            this.btnPassout.Size = new System.Drawing.Size(235, 44);
            this.btnPassout.TabIndex = 18;
            this.btnPassout.Text = "PASSOUT_FILE";
            this.btnPassout.UseVisualStyleBackColor = false;
            this.btnPassout.Visible = false;
            this.btnPassout.Click += new System.EventHandler(this.btnPassout_Click);
            // 
            // btnPrj
            // 
            this.btnPrj.BackColor = System.Drawing.Color.LightGray;
            this.btnPrj.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnPrj.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnPrj.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnPrj.Location = new System.Drawing.Point(14, 266);
            this.btnPrj.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrj.Name = "btnPrj";
            this.btnPrj.Size = new System.Drawing.Size(235, 44);
            this.btnPrj.TabIndex = 0;
            this.btnPrj.Text = "PROJECT_FILE";
            this.btnPrj.UseVisualStyleBackColor = false;
            this.btnPrj.Click += new System.EventHandler(this.btnPrj_Click);
            // 
            // btnClose
            // 
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.BackColor = System.Drawing.Color.LightGray;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(14, 674);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(235, 44);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnHelp.BackColor = System.Drawing.Color.LightGray;
            this.btnHelp.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnHelp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnHelp.Location = new System.Drawing.Point(14, 198);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(235, 44);
            this.btnHelp.TabIndex = 15;
            this.btnHelp.Text = "HELP";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnPassword
            // 
            this.btnPassword.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPassword.BackColor = System.Drawing.Color.LightGray;
            this.btnPassword.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnPassword.Location = new System.Drawing.Point(14, 606);
            this.btnPassword.Margin = new System.Windows.Forms.Padding(4);
            this.btnPassword.Name = "btnPassword";
            this.btnPassword.Size = new System.Drawing.Size(235, 44);
            this.btnPassword.TabIndex = 14;
            this.btnPassword.Text = "CHANGE PASSWORD";
            this.btnPassword.UseVisualStyleBackColor = false;
            this.btnPassword.Click += new System.EventHandler(this.btnPassword_Click);
            // 
            // btnFormat
            // 
            this.btnFormat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFormat.BackColor = System.Drawing.Color.Gainsboro;
            this.btnFormat.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnFormat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnFormat.Location = new System.Drawing.Point(14, 538);
            this.btnFormat.Margin = new System.Windows.Forms.Padding(4);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(235, 44);
            this.btnFormat.TabIndex = 13;
            this.btnFormat.Text = "SHOW FILE FORMAT";
            this.btnFormat.UseVisualStyleBackColor = false;
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // btnSequence
            // 
            this.btnSequence.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSequence.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSequence.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnSequence.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSequence.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnSequence.Location = new System.Drawing.Point(14, 470);
            this.btnSequence.Margin = new System.Windows.Forms.Padding(4);
            this.btnSequence.Name = "btnSequence";
            this.btnSequence.Size = new System.Drawing.Size(235, 44);
            this.btnSequence.TabIndex = 12;
            this.btnSequence.Text = "  SEQUENCE   FILE";
            this.btnSequence.UseVisualStyleBackColor = false;
            this.btnSequence.Click += new System.EventHandler(this.btnSequence_Click);
            // 
            // btnLimit
            // 
            this.btnLimit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLimit.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLimit.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnLimit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnLimit.Location = new System.Drawing.Point(14, 402);
            this.btnLimit.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimit.Name = "btnLimit";
            this.btnLimit.Size = new System.Drawing.Size(235, 44);
            this.btnLimit.TabIndex = 11;
            this.btnLimit.Text = "    LIMIT      FILE";
            this.btnLimit.UseVisualStyleBackColor = false;
            this.btnLimit.Click += new System.EventHandler(this.btnLimit_Click);
            // 
            // btnEngine
            // 
            this.btnEngine.AutoEllipsis = true;
            this.btnEngine.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEngine.BackColor = System.Drawing.Color.Gainsboro;
            this.btnEngine.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnEngine.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEngine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnEngine.Location = new System.Drawing.Point(14, 334);
            this.btnEngine.Margin = new System.Windows.Forms.Padding(4);
            this.btnEngine.Name = "btnEngine";
            this.btnEngine.Size = new System.Drawing.Size(235, 44);
            this.btnEngine.TabIndex = 10;
            this.btnEngine.Text = "  ENGINE   FILE";
            this.btnEngine.UseVisualStyleBackColor = false;
            this.btnEngine.Click += new System.EventHandler(this.btnEngine_Click);
            // 
            // tmrLogin
            // 
            this.tmrLogin.Interval = 1000;
            // 
            // MDIParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MDIParent";
            this.Text = "EDAC - Editors";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDIParent_Load);
            this.Shown += new System.EventHandler(this.MDIParent_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnPassout;
        private System.Windows.Forms.Button btnPrj;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnPassword;
        private System.Windows.Forms.Button btnFormat;
        private System.Windows.Forms.Button btnSequence;
        private System.Windows.Forms.Button btnLimit;
        private System.Windows.Forms.Button btnEngine;
        private System.Windows.Forms.Timer tmrLogin;
        private System.Windows.Forms.Button btnLogs;
    }
}



