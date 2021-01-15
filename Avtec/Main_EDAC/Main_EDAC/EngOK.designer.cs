namespace Logger
{
    partial class EngOK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EngOK));
            this.lblDfMatrix = new System.Windows.Forms.TextBox();
            this.lblTMLPCERROR = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.prgT = new ExtendedDotNET.Controls.Progress.ProgressBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblDfMatrix
            // 
            this.lblDfMatrix.Font = new System.Drawing.Font("Book Antiqua", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDfMatrix.ForeColor = System.Drawing.Color.Navy;
            this.lblDfMatrix.Location = new System.Drawing.Point(12, 50);
            this.lblDfMatrix.Name = "lblDfMatrix";
            this.lblDfMatrix.Size = new System.Drawing.Size(412, 27);
            this.lblDfMatrix.TabIndex = 1;
            this.lblDfMatrix.Text = "Engine OK";
            // 
            // lblTMLPCERROR
            // 
            this.lblTMLPCERROR.Font = new System.Drawing.Font("Book Antiqua", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTMLPCERROR.ForeColor = System.Drawing.Color.Navy;
            this.lblTMLPCERROR.Location = new System.Drawing.Point(30, 53);
            this.lblTMLPCERROR.Name = "lblTMLPCERROR";
            this.lblTMLPCERROR.ReadOnly = true;
            this.lblTMLPCERROR.Size = new System.Drawing.Size(386, 21);
            this.lblTMLPCERROR.TabIndex = 2;
            this.lblTMLPCERROR.Text = "No PLC Alarm";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(298, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // prgT
            // 
            this.prgT.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.prgT.AutoScroll = true;
            this.prgT.BackColor = System.Drawing.Color.White;
            this.prgT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.prgT.BarOffset = 0;
            this.prgT.Caption = "Wait Data  for Transfer . . . . . .  ";
            this.prgT.CaptionColor = System.Drawing.Color.Navy;
            this.prgT.CaptionMode = ExtendedDotNET.Controls.Progress.ProgressCaptionMode.Custom;
            this.prgT.CaptionShadowColor = System.Drawing.Color.Transparent;
            this.prgT.ChangeByMouse = false;
            this.prgT.DashSpace = 4;
            this.prgT.DashWidth = 8;
            this.prgT.Edge = ExtendedDotNET.Controls.Progress.ProgressBarEdge.Rounded;
            this.prgT.EdgeColor = System.Drawing.Color.Red;
            this.prgT.EdgeLightColor = System.Drawing.Color.LightSteelBlue;
            this.prgT.EdgeWidth = 1;
            this.prgT.FloodPercentage = 0.9F;
            this.prgT.FloodStyle = ExtendedDotNET.Controls.Progress.ProgressFloodStyle.Standard;
            this.prgT.Font = new System.Drawing.Font("Book Antiqua", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prgT.ForeColor = System.Drawing.Color.Coral;
            this.prgT.Invert = false;
            this.prgT.Location = new System.Drawing.Point(12, 14);
            this.prgT.MainColor = System.Drawing.Color.Cyan;
            this.prgT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.prgT.Maximum = 100;
            this.prgT.Minimum = 0;
            this.prgT.Name = "prgT";
            this.prgT.Orientation = ExtendedDotNET.Controls.Progress.ProgressBarDirection.Horizontal;
            this.prgT.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.prgT.ProgressBarStyle = ExtendedDotNET.Controls.Progress.ProgressStyle.Dashed;
            this.prgT.SecondColor = System.Drawing.Color.Red;
            this.prgT.Shadow = false;
            this.prgT.ShadowOffset = 1;
            this.prgT.Size = new System.Drawing.Size(418, 25);
            this.prgT.Step = 1;
            this.prgT.TabIndex = 107;
            this.prgT.TextAntialias = true;
            this.prgT.Value = 10;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(53, 103);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(147, 23);
            this.checkBox1.TabIndex = 108;
            this.checkBox1.Text = "No Noise . . . . . . .";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(53, 137);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(174, 23);
            this.checkBox2.TabIndex = 109;
            this.checkBox2.Text = "No Leakages . . . . . . .";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.Location = new System.Drawing.Point(53, 183);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(177, 23);
            this.checkBox3.TabIndex = 110;
            this.checkBox3.Text = "Engine Passed . . . . . . ";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // EngOK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 262);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.prgT);
            this.Controls.Add(this.lblDfMatrix);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTMLPCERROR);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EngOK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manual Observation. . . . . . . .  .";
            this.Load += new System.EventHandler(this.EngOK_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox lblDfMatrix;
        private System.Windows.Forms.TextBox lblTMLPCERROR;
        private System.Windows.Forms.Button button1;
        private ExtendedDotNET.Controls.Progress.ProgressBar prgT;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
    }
}