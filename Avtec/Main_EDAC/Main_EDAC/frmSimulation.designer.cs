namespace Logger
{
    partial class frmSimulation
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
            this.textBox39 = new System.Windows.Forms.TextBox();
            this.textBox38 = new System.Windows.Forms.TextBox();
            this.textBox37 = new System.Windows.Forms.TextBox();
            this.textBox36 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox39
            // 
            this.textBox39.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox39.ForeColor = System.Drawing.Color.Blue;
            this.textBox39.Location = new System.Drawing.Point(132, 131);
            this.textBox39.Name = "textBox39";
            this.textBox39.ReadOnly = true;
            this.textBox39.Size = new System.Drawing.Size(100, 29);
            this.textBox39.TabIndex = 523;
            this.textBox39.Text = "86.0";
            // 
            // textBox38
            // 
            this.textBox38.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox38.ForeColor = System.Drawing.Color.Blue;
            this.textBox38.Location = new System.Drawing.Point(132, 93);
            this.textBox38.Name = "textBox38";
            this.textBox38.Size = new System.Drawing.Size(100, 29);
            this.textBox38.TabIndex = 522;
            this.textBox38.Text = "1.000";
            this.textBox38.Leave += new System.EventHandler(this.textBox38_Leave);
            // 
            // textBox37
            // 
            this.textBox37.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox37.ForeColor = System.Drawing.Color.Blue;
            this.textBox37.Location = new System.Drawing.Point(132, 55);
            this.textBox37.Name = "textBox37";
            this.textBox37.Size = new System.Drawing.Size(100, 29);
            this.textBox37.TabIndex = 521;
            this.textBox37.Text = "27.0";
            this.textBox37.Leave += new System.EventHandler(this.textBox37_Leave);
            // 
            // textBox36
            // 
            this.textBox36.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox36.ForeColor = System.Drawing.Color.Blue;
            this.textBox36.Location = new System.Drawing.Point(132, 17);
            this.textBox36.Name = "textBox36";
            this.textBox36.Size = new System.Drawing.Size(100, 29);
            this.textBox36.TabIndex = 520;
            this.textBox36.Text = "33.0";
            this.textBox36.Leave += new System.EventHandler(this.textBox36_Leave);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(21, 130);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(105, 20);
            this.label26.TabIndex = 519;
            this.label26.Text = "Rel.Hum (%):";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(34, 94);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(92, 20);
            this.label25.TabIndex = 518;
            this.label25.Text = "Atms (bar) :";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(8, 58);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(118, 20);
            this.label24.TabIndex = 517;
            this.label24.Text = "Wet Bulb (ºC ) :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(10, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(116, 20);
            this.label22.TabIndex = 516;
            this.label22.Text = "Dry Bulb (ºC ) :";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.button1.Location = new System.Drawing.Point(127, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 27);
            this.button1.TabIndex = 524;
            this.button1.Text = "&OK/Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 240);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox39);
            this.Controls.Add(this.textBox38);
            this.Controls.Add(this.textBox37);
            this.Controls.Add(this.textBox36);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label22);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmSimulation";
            this.Text = "Values Editor :";
            this.Load += new System.EventHandler(this.frmSimulation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox39;
        private System.Windows.Forms.TextBox textBox38;
        private System.Windows.Forms.TextBox textBox37;
        private System.Windows.Forms.TextBox textBox36;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button button1;
    }
}