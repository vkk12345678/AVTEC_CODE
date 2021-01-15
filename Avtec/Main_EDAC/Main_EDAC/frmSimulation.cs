using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using MySql.Data.MySqlClient;
using MySql.Web;
using System.Text;
using System.Windows.Forms;

namespace Logger
{
    public partial class frmSimulation : Form
    {
        public frmSimulation()
        {
            InitializeComponent();
        }              
        private void textBox36_Leave(object sender, EventArgs e)
        {
            Double l = Convert.ToDouble(textBox36.Text);

            if (l >= 55)
            {
                MessageBox.Show("DryT Bulb Temp. Entered Is wrong .It Should Be between 10  to 55", "Simulation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
               // MessageBox.Show("DryT bulb Temp. Entered Is worng It Should Be bet' 10  to 55");
                textBox36.Focus();
            }
            else
            {
                textBox36.Text = l.ToString("00.0");
                Global.Drb = l;
                textBox39.Text = Global.Rel_Hum.ToString();  
            }
        }
     
        private void textBox37_Leave(object sender, EventArgs e)
        {
            Double L = Convert.ToDouble(textBox37.Text);

            if (L >= 55)
            {
                MessageBox.Show("WetT bulb temp. entered is wrong .It Should Be between 10  to 55", "Simulation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //MessageBox.Show("WetT Bulb Temp. Entered Is worng It Should Be bet' 10  to 55");
                textBox37.Focus();
            }
            else
            {
                textBox37.Text = L.ToString("00.0");
                Global.Web = L;
                textBox39.Text = Global.Rel_Hum.ToString();    
            }

        }

        private void textBox38_Leave(object sender, EventArgs e)
        {
            Double l = Convert.ToDouble(textBox38.Text);

            if ((l >= 1.100) || (l <= 0.900))
            {
                MessageBox.Show("Atms Pressure Entered Is wrong . It Should Be between' 0.900  to 1.1000", "Simulation",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //MessageBox.Show("Atms Pressure Entered Is worng It Should Be bet' 0.900  to 1.1000");
                textBox38.Focus();
            }
            else
            {
                textBox38.Text = l.ToString("0.000");
                Global.Atp = l;
                textBox39.Text = Global.Rel_Hum.ToString();    
            }

        }
              

        private void button1_Click(object sender, EventArgs e)
        {
            Global.Open_Connection("gen_db", "con");            
            MySqlCommand cmd = new MySqlCommand("Update TbSys SET CH18 = '" + textBox36.Text + "', " +
                                                                 "CH19 = '" + textBox37.Text + "', " +
                                                                 "CH20 = '" + textBox38.Text + "', " +
                                                                 "CH21 = '" + textBox39.Text + "' " +
                                                                 " WHERE FileName = 'EngNo'", Global.con);
            cmd.ExecuteNonQuery();
            Global.con.Close();
            this.Close(); 
        }

        private void frmSimulation_Load(object sender, EventArgs e)
        {
            try
            {
                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM TbSys WHERE FileName = 'EngNo'", Global.con);
                MySqlDataReader Rd1 = cmd1.ExecuteReader();

                while (Rd1.Read())
                {
                    textBox36.Text = Rd1.GetValue(18).ToString();
                    textBox37.Text = Rd1.GetValue(19).ToString();
                    textBox38.Text = Rd1.GetValue(20).ToString();
                    textBox39.Text = Rd1.GetValue(21).ToString();
                }
                Global.con.Close();             

             }
            catch (Exception ex)
            {
                Global.Create_OnLog(ex.Message + " : Simulation....", "Alert");  
                //MessageBox.Show("Error - 1001", ex.Message);
            }


        }

       




    }
}
