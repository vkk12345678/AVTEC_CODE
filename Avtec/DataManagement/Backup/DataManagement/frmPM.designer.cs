namespace DataManagement
{
    partial class frmPM
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PBar1 = new ExtendedDotNET.Controls.Progress.ProgressBar();
            this.button3 = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TVPM = new System.Windows.Forms.TreeView();
            this.gridview1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridview1)).BeginInit();
            this.SuspendLayout();
            // 
            // PBar1
            // 
            this.PBar1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.PBar1.AutoScroll = true;
            this.PBar1.BackColor = System.Drawing.Color.White;
            this.PBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PBar1.BarOffset = 0;
            this.PBar1.Caption = "Wait Data  for Transfer . . . . . .  ";
            this.PBar1.CaptionColor = System.Drawing.Color.Navy;
            this.PBar1.CaptionMode = ExtendedDotNET.Controls.Progress.ProgressCaptionMode.Custom;
            this.PBar1.CaptionShadowColor = System.Drawing.Color.Transparent;
            this.PBar1.ChangeByMouse = false;
            this.PBar1.DashSpace = 4;
            this.PBar1.DashWidth = 8;
            this.PBar1.Edge = ExtendedDotNET.Controls.Progress.ProgressBarEdge.Rounded;
            this.PBar1.EdgeColor = System.Drawing.Color.Red;
            this.PBar1.EdgeLightColor = System.Drawing.Color.LightSteelBlue;
            this.PBar1.EdgeWidth = 1;
            this.PBar1.FloodPercentage = 0.9F;
            this.PBar1.FloodStyle = ExtendedDotNET.Controls.Progress.ProgressFloodStyle.Standard;
            this.PBar1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PBar1.ForeColor = System.Drawing.Color.Coral;
            this.PBar1.Invert = false;
            this.PBar1.Location = new System.Drawing.Point(301, 13);
            this.PBar1.MainColor = System.Drawing.Color.Cyan;
            this.PBar1.Margin = new System.Windows.Forms.Padding(4);
            this.PBar1.Maximum = 100;
            this.PBar1.Minimum = 0;
            this.PBar1.Name = "PBar1";
            this.PBar1.Orientation = ExtendedDotNET.Controls.Progress.ProgressBarDirection.Horizontal;
            this.PBar1.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.PBar1.ProgressBarStyle = ExtendedDotNET.Controls.Progress.ProgressStyle.Dashed;
            this.PBar1.SecondColor = System.Drawing.Color.Red;
            this.PBar1.Shadow = false;
            this.PBar1.ShadowOffset = 1;
            this.PBar1.Size = new System.Drawing.Size(524, 23);
            this.PBar1.Step = 1;
            this.PBar1.TabIndex = 109;
            this.PBar1.TextAntialias = true;
            this.PBar1.Value = 10;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button3.Location = new System.Drawing.Point(332, 48);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(21, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "S";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Purple;
            this.txtSearch.Location = new System.Drawing.Point(127, 50);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(201, 23);
            this.txtSearch.TabIndex = 8;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(15, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Search File Name :";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(301, 41);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(396, 89);
            this.panel2.TabIndex = 107;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.Red;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(127, 8);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(201, 23);
            this.comboBox1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(72, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "&Month : ";
            // 
            // TVPM
            // 
            this.TVPM.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TVPM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.TVPM.LineColor = System.Drawing.Color.Red;
            this.TVPM.Location = new System.Drawing.Point(-3, 30);
            this.TVPM.Margin = new System.Windows.Forms.Padding(4);
            this.TVPM.Name = "TVPM";
            this.TVPM.Size = new System.Drawing.Size(292, 593);
            this.TVPM.TabIndex = 110;
            this.TVPM.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TVPM_AfterSelect_1);
            // 
            // gridview1
            // 
            this.gridview1.BackgroundColor = System.Drawing.Color.LightGray;
            this.gridview1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridview1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridview1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridview1.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridview1.EnableHeadersVisualStyles = false;
            this.gridview1.GridColor = System.Drawing.Color.LightGray;
            this.gridview1.Location = new System.Drawing.Point(301, 138);
            this.gridview1.Margin = new System.Windows.Forms.Padding(4);
            this.gridview1.Name = "gridview1";
            this.gridview1.RowHeadersVisible = false;
            this.gridview1.RowHeadersWidth = 4;
            this.gridview1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridview1.Size = new System.Drawing.Size(827, 485);
            this.gridview1.TabIndex = 111;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(735, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 39);
            this.button1.TabIndex = 112;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(833, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 113;
            this.label1.Text = "label1";
            // 
            // frmPM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 658);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gridview1);
            this.Controls.Add(this.TVPM);
            this.Controls.Add(this.PBar1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPM";
            this.Text = "frmPM";
            this.Load += new System.EventHandler(this.frmPM_Load_1);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridview1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ExtendedDotNET.Controls.Progress.ProgressBar PBar1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView TVPM;
        private System.Windows.Forms.DataGridView gridview1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}