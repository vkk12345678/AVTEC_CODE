using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace Logger
{
    public partial class frmAbout : Form
    {
        string str = "";
        
        public frmAbout()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmAbout_Load(object sender, EventArgs e)
        {

            pictureBox1.Image = Image.FromFile(Global.PATH + "Logo_With ISO.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
         
            //this.Left = 350;
            //timer1.Start();
            //Global.Open_Connection("gen_db", "con");
            //MySqlCommand cmd = new MySqlCommand("Select Passw from Sec where TokenNo = 'LogApp'", Global.con);
            //MySqlDataReader rd = cmd.ExecuteReader();

            //while (rd.Read())
            //{
            //    str = rd.GetValue(0).ToString();
            //}
            //Global.con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {               
                //if (str == textBox1.Text.Trim())
                //{
                //    frmMain frm = new frmMain();
                //    frm.ShowDialog(this);
                //    frm.Dispose();
                //    this.Close();                   
                //}                
                //else
                //{
                //    MessageBox.Show("Password is Wrong", "Dynalec Controls Pvt Ltd.",
                //    MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //   // MessageBox.Show("Password is wrong ");
                //    textBox1.Text = "";
                //    textBox1.Focus();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 16002" + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //MessageBox.Show("Error Code:- 16002", ex.Message);
                Global.Create_OnLog(ex.Message + ": button1_Click", "Alert");
            }

        }   
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    if (this.Width < 570) this.Width += 5; else timer1.Stop();
        //    textBox1.Focus(); 
        //}

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    if (str == textBox1.Text)
        //    {
        //        textBox1.BackColor = Color.Green;
        //        textBox1.ForeColor = Color.White;
        //        frmMain frm = new frmMain();
        //        frm.ShowDialog(this);
        //        frm.Dispose();
        //        this.Close();       
        //    }
        //    else
        //    {
        //        textBox1.BackColor = Color.Red;
        //        textBox1.ForeColor = Color.White;
        //    }
           
        //}
    }
}
