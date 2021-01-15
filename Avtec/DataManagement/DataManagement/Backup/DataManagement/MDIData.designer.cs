namespace DataManagement
{
    partial class MDIData
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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPM = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGraphs = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExcel,
            this.mnuGen,
            this.mnuPM,
            this.mnuGraphs,
            this.closeToolStripMenuItem,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1910, 26);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuExcel
            // 
            this.mnuExcel.Name = "mnuExcel";
            this.mnuExcel.Size = new System.Drawing.Size(111, 22);
            this.mnuExcel.Text = "Excel formates";
            this.mnuExcel.Click += new System.EventHandler(this.mnuExcel_Click);
            // 
            // mnuGen
            // 
            this.mnuGen.Name = "mnuGen";
            this.mnuGen.Size = new System.Drawing.Size(117, 22);
            this.mnuGen.Text = "Global Data File";
            this.mnuGen.Click += new System.EventHandler(this.mnuGen_Click);
            // 
            // mnuPM
            // 
            this.mnuPM.Name = "mnuPM";
            this.mnuPM.Size = new System.Drawing.Size(97, 22);
            this.mnuPM.Text = "PM Data File";
            this.mnuPM.Visible = false;
            this.mnuPM.Click += new System.EventHandler(this.mnuPM_Click);
            // 
            // mnuGraphs
            // 
            this.mnuGraphs.Enabled = false;
            this.mnuGraphs.Name = "mnuGraphs";
            this.mnuGraphs.Size = new System.Drawing.Size(63, 22);
            this.mnuGraphs.Text = "Graphs";
            //this.mnuGraphs.Click += new System.EventHandler(this.mnuGraphs_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(54, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(50, 22);
            this.mnuHelp.Text = "HELP";
            this.mnuHelp.Click += new System.EventHandler(this.mnuHelp_Click);
            // 
            // MDIData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1910, 1028);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.Name = "MDIData";
            this.Text = "DATA  Applications";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuExcel;
        private System.Windows.Forms.ToolStripMenuItem mnuGen;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuGraphs;
        private System.Windows.Forms.ToolStripMenuItem mnuPM;
    }
}



