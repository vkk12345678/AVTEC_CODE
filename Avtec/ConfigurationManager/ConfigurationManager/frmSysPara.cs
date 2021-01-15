using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Logger
{
    public partial class frmSysPara : Form
    {
        String[] SyspArr = new string[75];
        public frmSysPara()
        {
            InitializeComponent();
        }

        private void frmSysPara_Load(object sender, EventArgs e)
        {
            Load_File();
        }

       
        private void Load_File()
        {
            try
            {
                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "SELECT * FROM TbSys WHERE FileName = '08_SystemPara'";
                int I = 0;
                MySqlDataAdapter Dap = new MySqlDataAdapter("SELECT * FROM TbSys WHERE FileName = '08_SystemPara'", Global.con);
                DataSet ds = new DataSet();
                Dap.Fill(ds);

                for (I = 0; I < (ds.Tables[0].Columns.Count - 1); I++)
                {
                    SyspArr[I] = ds.Tables[0].Rows[0].ItemArray[I + 1].ToString();
                }


                ds.Dispose();
                Dap.Dispose();
                Global.con.Close();

                TextBox1.Text = SyspArr[0];
                TextBox2.Text = SyspArr[1];
                ComboBox1.Text = SyspArr[2];
                TextBox3.Text = SyspArr[3];
                TextBox4.Text = SyspArr[4];
                TextBox5.Text = SyspArr[5];
                TextBox6.Text = SyspArr[6];
                TextBox7.Text = SyspArr[7];
                TextBox8.Text = SyspArr[8];
                TextBox9.Text = SyspArr[9];     // shift start//

                ComboBox2.Text = SyspArr[10];        // RPM Meter;
                ComboBox3.Text = SyspArr[11];          // Torque Meter;
                ComboBox4.Text = SyspArr[12];       // PLC Safety;
                ComboBox5.Text = SyspArr[13];        // dynasafety;


                if (SyspArr[14] == "TRUE") CheckBox1.Checked = true; else CheckBox1.Checked = false;   // rpm Correction
                if (SyspArr[15] == "TRUE") CheckBox2.Checked = true; else CheckBox2.Checked = false;  // Torque Correction 
                if (SyspArr[16] == "TRUE") CheckBox3.Checked = true; else CheckBox3.Checked = false;  //Record PM Dxata   
                if (SyspArr[17] == "TRUE") CheckBox4.Checked = true; else CheckBox4.Checked = false;  // record Data In Ramp
                if (SyspArr[18] == "TRUE") CheckBox5.Checked = true; else CheckBox5.Checked = false;  // Simulation 


                if (SyspArr[19] == "TRUE") CheckBox6.Checked = true; else CheckBox6.Checked = false;      //  fuel press
                TextBox10.Text = SyspArr[20];
                TextBox11.Text = SyspArr[21];

                if (SyspArr[22] == "TRUE") CheckBox7.Checked = true; else CheckBox7.Checked = false;      //  Oill press
                TextBox12.Text = SyspArr[23];
                TextBox13.Text = SyspArr[24];

                if (SyspArr[25] == "TRUE") CheckBox8.Checked = true; else CheckBox8.Checked = false;      // Water Press
                TextBox14.Text = SyspArr[26];
                TextBox15.Text = SyspArr[27];

                if (SyspArr[28] == "TRUE") CheckBox9.Checked = true; else CheckBox9.Checked = false;     //  LubOil Temp
                TextBox16.Text = SyspArr[29];
                TextBox17.Text = SyspArr[30];


                if (SyspArr[31] == "TRUE") CheckBox10.Checked = true; else CheckBox10.Checked = false;     //  Water Temp
                TextBox18.Text = SyspArr[32];
                TextBox19.Text = SyspArr[33];
            }
        

            catch(Exception ex)
            {
                MessageBox.Show("Error Code:- 14002" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //MessageBox.Show("Error Code:- 14001 ", ex.Message);
                Global.Create_OnLog("SYSTEM PARAMETER FILE COULD NOT LOAD....", "Alert");
            }
        }

        private void Update_File()
        {
            try
            {
                //String str;
                String[] SaveArr = new String[75];

                SaveArr[0] = TextBox1.Text;
                SaveArr[1] = TextBox2.Text;
                SaveArr[2] = ComboBox1.Text;
                SaveArr[3] = TextBox3.Text;
                SaveArr[4] = TextBox4.Text;
                SaveArr[5] = TextBox5.Text;
                SaveArr[6] = TextBox6.Text;
                SaveArr[7] = TextBox7.Text;
                SaveArr[8] = TextBox8.Text;
                SaveArr[9] = TextBox9.Text;
                SaveArr[10] = ComboBox2.Text;
                SaveArr[11] = ComboBox3.Text;
                SaveArr[12] = ComboBox4.Text;
                SaveArr[13] = ComboBox5.Text;


                if (CheckBox1.Checked == true) SaveArr[14] = "TRUE"; else SaveArr[14] = "FALSE";
                if (CheckBox2.Checked == true) SaveArr[15] = "TRUE"; else SaveArr[15] = "FALSE";
                if (CheckBox3.Checked == true) SaveArr[16] = "TRUE"; else SaveArr[16] = "FALSE";
                if (CheckBox4.Checked == true) SaveArr[17] = "TRUE"; else SaveArr[17] = "FALSE";
                if (CheckBox5.Checked == true) SaveArr[18] = "TRUE"; else SaveArr[18] = "FALSE";


              
                if (CheckBox6.Checked == true) SaveArr[19] = "TRUE"; else SaveArr[19] = "FALSE";
                SaveArr[20] = TextBox10.Text;
                SaveArr[21] = TextBox11.Text;

                if (CheckBox7.Checked == true) SaveArr[22] = "TRUE"; else SaveArr[22] = "FALSE";
                SaveArr[23] = TextBox12.Text;
                SaveArr[24] = TextBox13.Text;

                if (CheckBox8.Checked == true) SaveArr[25] = "TRUE"; else SaveArr[25] = "FALSE";
                SaveArr[26] = TextBox14.Text;
                SaveArr[27] = TextBox15.Text;

                if (CheckBox9.Checked == true) SaveArr[28] = "TRUE"; else SaveArr[28] = "FALSE";
                SaveArr[29] = TextBox16.Text;
                SaveArr[30] = TextBox17.Text;

                if (CheckBox10.Checked == true) SaveArr[31] = "TRUE"; else SaveArr[31] = "FALSE";

                SaveArr[32] = TextBox18.Text;
                SaveArr[33] = TextBox19.Text;              
                String StrData = "";
                int i = 0;
                Global.Open_Connection("gen_db", "con");
                for (i = 0; i <= 32; i++)
                {
                    StrData = StrData + "CH" + (i + 1) + " = '" + SaveArr[i] + "', ";
                }
                StrData = StrData + "CH34 ='" + SaveArr[33] + "'";
                MySqlCommand cmdInst = new MySqlCommand();
                cmdInst.CommandText = "UPDATE TbSys SET " + StrData + "WHERE FileName = '08_SystemPara'";
                cmdInst.Connection = Global.con;
                cmdInst.ExecuteNonQuery();
                Global.Create_OnLog("System Parameter  New Changes are saved properly...... ", "Normal");
                MessageBox.Show("New Changes are saved ..", "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
               // MessageBox.Show("New Changes are saved .....");
                Global.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 14003" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //MessageBox.Show("Error Code:- 14003", ex.Message);
                Global.Create_OnLog("System Parameter File Not Saved Properly...... ", "Alart");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBox10_Leave(object sender, EventArgs e)
        {
            double l = Convert.ToDouble(TextBox10.Text);
            TextBox10.Text = l.ToString("0.000");
        }
        private void TextBox11_Leave(object sender, EventArgs e)
        {
            double l = Convert.ToDouble(TextBox11.Text);
            TextBox11.Text = l.ToString("0.000");
        }
        private void TextBox12_Leave(object sender, EventArgs e)
        {
            double l = Convert.ToDouble(TextBox12.Text);
            TextBox12.Text = l.ToString("0.000");
        }
        private void TextBox13_Leave(object sender, EventArgs e)
        {
            double l = Convert.ToDouble(TextBox13.Text);
            TextBox13.Text = l.ToString("0.000");
        }
        private void TextBox14_Leave(object sender, EventArgs e)
        {
            double l = Convert.ToDouble(TextBox14.Text);
            TextBox14.Text = l.ToString("0.000");
        }
        private void TextBox15_Leave(object sender, EventArgs e)
        {
            double l = Convert.ToDouble(TextBox15.Text);
            TextBox15.Text = l.ToString("0.000");
        }
        private void TextBox16_Leave(object sender, EventArgs e)
        {
            double l = Convert.ToDouble(TextBox16.Text);
            TextBox16.Text = l.ToString("000.0");
        }
        private void TextBox17_Leave(object sender, EventArgs e)
        {
            double l = Convert.ToDouble(TextBox17.Text);
            TextBox17.Text = l.ToString("000.0");
        }
        private void TextBox18_Leave(object sender, EventArgs e)
        {
            double l = Convert.ToDouble(TextBox18.Text);
            TextBox18.Text = l.ToString("000.0");
        }
        private void TextBox19_Leave(object sender, EventArgs e)
        {
            double l = Convert.ToDouble(TextBox19.Text);
            TextBox19.Text = l.ToString("000.0");
        } 

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update_File();
            Global.Rd_COM_Confg(); 
        }

        private void TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_Leave(object sender, EventArgs e)
        {
          
            //{
            //    double l = Convert.ToDouble(TextBox3.Text);
            //    TextBox3.Text = l.ToString("0.000");
            //}
        

            
        }
    }
}
