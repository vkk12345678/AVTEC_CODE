namespace Logger
{
    partial class frmRStatus
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRStatus));
            this.GridGen = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuGen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPM = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInst = new System.Windows.Forms.ToolStripMenuItem();
            this.RunStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClose = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.GridGen)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridGen
            // 
            this.GridGen.AllowUserToAddRows = false;
            this.GridGen.AllowUserToDeleteRows = false;
            this.GridGen.AllowUserToResizeRows = false;
            this.GridGen.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridGen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridGen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridGen.DefaultCellStyle = dataGridViewCellStyle2;
            this.GridGen.EnableHeadersVisualStyles = false;
            this.GridGen.Location = new System.Drawing.Point(12, 45);
            this.GridGen.Name = "GridGen";
            this.GridGen.RowHeadersWidth = 4;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.SteelBlue;
            this.GridGen.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.GridGen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridGen.Size = new System.Drawing.Size(1155, 555);
            this.GridGen.TabIndex = 5;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGen,
            this.mnuPM,
            this.mnuInst,
            this.RunStatus,
            this.mnuClose});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1187, 29);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuGen
            // 
            this.mnuGen.AutoSize = false;
            this.mnuGen.BackColor = System.Drawing.Color.Gainsboro;
            this.mnuGen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuGen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.mnuGen.Name = "mnuGen";
            this.mnuGen.Size = new System.Drawing.Size(80, 25);
            this.mnuGen.Text = "GenData";
            this.mnuGen.Click += new System.EventHandler(this.mnuGen_Click);
            // 
            // mnuPM
            // 
            this.mnuPM.AutoSize = false;
            this.mnuPM.BackColor = System.Drawing.Color.Gainsboro;
            this.mnuPM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuPM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.mnuPM.Name = "mnuPM";
            this.mnuPM.Size = new System.Drawing.Size(80, 25);
            this.mnuPM.Text = "PMData";
            this.mnuPM.Click += new System.EventHandler(this.mnuPM_Click);
            // 
            // mnuInst
            // 
            this.mnuInst.AutoSize = false;
            this.mnuInst.BackColor = System.Drawing.Color.Gainsboro;
            this.mnuInst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuInst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.mnuInst.Name = "mnuInst";
            this.mnuInst.Size = new System.Drawing.Size(80, 25);
            this.mnuInst.Text = "ECUlogData";
            this.mnuInst.Click += new System.EventHandler(this.mnuInst_Click);
            // 
            // RunStatus
            // 
            this.RunStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.RunStatus.Name = "RunStatus";
            this.RunStatus.Size = new System.Drawing.Size(69, 25);
            this.RunStatus.Text = "StatusList";
            this.RunStatus.Click += new System.EventHandler(this.RunStatus_Click);
            // 
            // mnuClose
            // 
            this.mnuClose.AutoSize = false;
            this.mnuClose.BackColor = System.Drawing.Color.Gainsboro;
            this.mnuClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.mnuClose.Name = "mnuClose";
            this.mnuClose.Size = new System.Drawing.Size(80, 25);
            this.mnuClose.Text = "Close";
            this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
            // 
            // frmRStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 612);
            this.Controls.Add(this.GridGen);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRStatus";
            this.Text = "Runnung Status ....... && PM Data .............. ";
            this.Load += new System.EventHandler(this.frmRStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridGen)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridGen;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuGen;
        private System.Windows.Forms.ToolStripMenuItem mnuPM;
        private System.Windows.Forms.ToolStripMenuItem mnuInst;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
        private System.Windows.Forms.ToolStripMenuItem RunStatus;
    }
}