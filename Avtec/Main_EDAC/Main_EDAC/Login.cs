using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Web;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Logger
{
    public partial class Login : Form
    {
        private string str = "";
        public Login()
        {
            InitializeComponent();
        }
        private void fillcombo()
        {
            try
            {
                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand("Select TokenNo from Sec", Global.con);
                //cmd.ExecuteNonQuery();
                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    comboBox1.Items.Add(rd.GetValue(0));
                }

                Global.con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 16001" + '\n'+ ex.Message , "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
               // MessageBox.Show("Error Code:- 16001", ex.Message);
                Global.Create_OnLog("Login Failed.....", "Alert");
            }
        }
        private void Login_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            this.Left = 400;
            timer1.Start(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand("Select Passw from Sec where TokenNo= '" + comboBox1.Text + "'", Global.con);
                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    str = rd.GetValue(0).ToString();
                }
                Global.con.Close();
                if ((str == textBox1.Text.Trim()) && (comboBox1.Text.Trim() == "Supervisor"))
                {
                    Global.flg_Log_supervisor = true;
                    this.Close();
                }
                else if ((str == textBox1.Text.Trim()) && (comboBox1.Text.Trim() == "Service"))
                {
                    Global.flg_Log_service = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password is wrong", "Dynalec Controls Pvt Ltd.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //MessageBox.Show("Password is wrong ");
                    textBox1.Text = "";
                    comboBox1.Text = "";
                    comboBox1.Focus();
                    Global.flg_Log_supervisor = false;
                    Global.flg_Log_service = false;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error Code:- 16002", ex.Message);
                MessageBox.Show("Error Code:- 16002" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Global.Create_OnLog("Check Password", "Alert"); //  button1_Click");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close ();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            { /////////////////////P 27/2/2013//////////////
                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand("Select Passw from Sec where TokenNo= '" + comboBox1.Text + "'", Global.con);
                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    str = rd.GetValue(0).ToString();
                }
                Global.con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Global.Create_OnLog(": comboBox1_SelectedIndex", "Alert");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            /////////////////////P 27/2/2013//////////////
            if (str != textBox1.Text)
            {
                textBox1.BackColor = Color.Red;
                textBox1.ForeColor = Color.White;
            }
            else
            {              
                textBox1.BackColor = Color.Green;
                textBox1.ForeColor = Color.White;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Width < 400) this.Width += 5; else timer1.Stop();   
        }
    }
}
