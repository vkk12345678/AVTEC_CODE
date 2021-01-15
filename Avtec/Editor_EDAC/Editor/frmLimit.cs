using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace Editor
{
    public partial class frmLimit : Form
    {
        private int Rn = 0;
        private Boolean file_Exist = true;
        private MySqlDataAdapter dAdapter = new MySqlDataAdapter();
        private DataSet ds = new DataSet();
        private MySqlCommandBuilder cBuilder = new MySqlCommandBuilder();
        private DataTable dTable = new DataTable();

        private int Tnt = 0;

        public frmLimit()
        {
            InitializeComponent();
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Close();
        }

        private void Check_Validation()
        {
            
            int x = 0;

            Common.Open_Connection("lim_db", "conlim");
            MySqlCommand cmd2 = new MySqlCommand("SELECT TABLE_NAME FROM lim_db.INFORMATION_SCHEMA.TABLES", Common.conLim);
            using (MySqlDataReader reader = cmd2.ExecuteReader())
            {
                if (LimCombo.Text == ((string)reader["TABLE_NAME"]))
                {
                    file_Exist = true;
                }
                else
                {
                    file_Exist = false;
                    return;
                }
                x += 1;
                reader.Close();
            }
           

            cmd2.Dispose();
            Common.conLim.Close();
        }



        private void mnuUpdate_Click(object sender, EventArgs e)
        {
            mnuNew.Enabled = true;
            mnuDelete.Enabled = true;

            Chk_Name();
            
            Cursor.Current = Cursors.WaitCursor;  

            if (file_Exist == false)
            {
                try
                {
                    if (LimCombo.Text == "")
                    {
                        MessageBox.Show("Give the Name for New File.", "Limit File",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                      //  MessageBox.Show("Give the Name for New File....");
                        LimCombo.Focus();
                        return;
                    }
                    Common.Open_Connection("lim_db", "conLim");
                    MySqlCommand cmdTb = new MySqlCommand();
                    String StrTb = " Pn Float Primary Key,ParameterName VARCHAR(30)," +
                                   " Lower1 VARCHAR(8), Low1 VARCHAR(8),High1 VARCHAR(8),Higher1 VARCHAR(8)," +
                                   " MinV VARCHAR(8),MaxV VARCHAR(8),Unit VARCHAR(10)";

                    cmdTb.CommandText = "CREATE TABLE " + LimCombo.Text.ToLower()  + "(" + StrTb + ")";
                    cmdTb.Connection = Common.conLim;
                    cmdTb.ExecuteNonQuery();
                    Common.conLim.Close();

                    int i = 0;
                    Common.Open_Connection("lim_db", "conLim");
                    MySqlCommand cmd = new MySqlCommand();
                    for (i = 0; i < limDGV.RowCount - 1; i++)
                    {
                        cmd.CommandText = "INSERT INTO " + LimCombo.Text.ToLower() + " VALUES ('" +
                            limDGV[0, i].Value.ToString() + "','" +
                            limDGV[1, i].Value.ToString() + "','" +
                            limDGV[2, i].Value.ToString() + "','" +
                            limDGV[3, i].Value.ToString() + "','" +
                            limDGV[4, i].Value.ToString() + "','" +
                            limDGV[5, i].Value.ToString() + "','" +
                            limDGV[6, i].Value.ToString() + "','" +
                            limDGV[7, i].Value.ToString() + "','" +
                            limDGV[8, i].Value.ToString() + "')";
                        cmd.Connection = Common.conLim;
                        cmd.ExecuteNonQuery();

                    }
                    //Common.conLim.Close();                   
                    Global.Create_OffLog("Normal", "New Limit File created.");
                    MessageBox.Show("New File Created.", "Limit File",
                    MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    //MessageBox.Show("File Saved .....");
                    mnuUpdate.Enabled = false;
                    Cursor.Current = Cursors.Default;  
                    Fill_comboBox();
                }
                catch (Exception ex)
                {
                    //Global.Create_OffLog("Error In mnuUpdate Click....");
                    MessageBox.Show("mnuUpdate_Click New file @ Error Code:-12012" + '\n' + ex.Message, "Limit File",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); 
                   // MessageBox.Show("mnuUpdate_Click New file @ Error Code:-12012" + ex.Message);
                }

            }
            else if (file_Exist == true)
            {
                try
                {
                    int Rw = 0;
                    Common.Open_Connection("lim_db", "conLim");
                    MySqlCommand cmd = new MySqlCommand();

                    for (Rw = 0; Rw <= (limDGV.RowCount - 2); Rw++)
                    {
                        int x = Convert.ToInt16(limDGV.Rows[Rw].Cells[0].Value);
                        cmd.CommandText ="UPDATE " + LimCombo.Text.ToLower()  + " SET" +
                                  " Lower1 = '" + limDGV.Rows[Rw].Cells[2].Value.ToString() + "'," +
                                  " Low1 = '" + limDGV.Rows[Rw].Cells[3].Value.ToString() + "'," +
                                  " High1 = '" + limDGV.Rows[Rw].Cells[4].Value.ToString() + "'," +
                                  " Higher1 = '" + limDGV.Rows[Rw].Cells[5].Value.ToString() + "'" +
                                  " WHERE Pn = " + x;
                        cmd.Connection = Common.conLim;
                        cmd.ExecuteNonQuery();
                    }
                    Common.conLim.Close();
                    Global.Create_OffLog("Normal", "Limit File Saved.");
                    MessageBox.Show("New Changes are saved.", "Limit File",
                    MessageBoxButtons.OK, MessageBoxIcon.Information); 
                   // MessageBox.Show("New Changes are saved.");
                    Fill_comboBox();
                }
                catch (Exception ex)

                {
                    //Global.Create_OffLog("Error File Not saved.....");
                    MessageBox.Show("File Not Saved" + ex.Message, "Limit File",
                    MessageBoxButtons.OK, MessageBoxIcon.Error); 
                   // MessageBox.Show("File Not Saved......." , ex.Message);
                }
            }

        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            try
            {
                file_Exist = false;
                LimCombo.Text = "";
                LoadNew();
                mnuUpdate.Enabled = true; 

            }
            catch (Exception ex)
            {
                Global.Create_OffLog("Alert", "New File Not Created.....");
                MessageBox.Show("New File not Created." + '\n' + ex.Message, "Limit File",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //MessageBox.Show("New file not created.... " + ex.Message);
            }

        }

        public void LoadNew()
        {
            limDGV.Refresh();
            limDGV.RowCount = 1;


            try
            {              

                Common.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Tb_Std ORDER BY ParameterNo", Common.con);

                MySqlDataReader Rd = cmd.ExecuteReader();
               
                int Rw = 0;

                if (Rd != null)
                {
                    int X = 0;
                    while (Rd.Read())
                    {
                        X += 1;
                        if (X <= 99)                       
                        {
                            limDGV.RowCount += 1;
                            limDGV[0, Rw].Value = Rd.GetValue(0).ToString();//no
                            limDGV[1, Rw].Value = Rd.GetString(5);//Name
                            limDGV[2, Rw].Value = "N";
                            limDGV[3, Rw].Value = "N";
                            limDGV[4, Rw].Value = "N";
                            limDGV[5, Rw].Value = "N";
                            limDGV[6, Rw].Value = Rd.GetString(2);//min
                            limDGV[7, Rw].Value = Rd.GetString(3);//max
                            limDGV[8, Rw].Value = Rd.GetString(4);//unit
                            //if (Rd.GetString(5) == "Not_Prog")
                            //{
                            //    limDGV.Rows[Rw].Visible = false;
                            //}
                            //else
                            //{
                            //    limDGV.Rows[Rw].Visible = true;
                            //}
                            Rw += 1;
                        }
                           
                    }
                        TextBox1.Text = "";
                        TextBox2.Text = "";
                        TextBox3.Text = "";
                        TextBox4.Text = "";
                        //******************************************
                        if (LimCombo.Text == "")
                        {
                            MessageBox.Show("Give the Name for New File.", "Limit File",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            LimCombo.Focus();
                            return;
                        }

                    ////******************   
                    //    Common.Open_Connection("lim_db", "conLim");
                    //    MySqlCommand cmdTb = new MySqlCommand();
                    //    String StrTb = " Pn Float Primary Key,ParameterName VARCHAR(30)," +
                    //                   " Lower1 VARCHAR(8), Low1 VARCHAR(8),High1 VARCHAR(8),Higher1 VARCHAR(8)," +
                    //                   " MinV VARCHAR(8),MaxV VARCHAR(8),Unit VARCHAR(10)";

                    //    cmdTb.CommandText = "CREATE TABLE " + LimCombo.Text.ToLower() + "(" + StrTb + ")";
                    //    cmdTb.Connection = Common.conLim;
                    //    cmdTb.ExecuteNonQuery();
                    //    Common.conLim.Close();
                    //    mnuUpdate.Enabled = false; 

                        }
                Rd.Dispose();
                cmd.Dispose();
                Common.con.Close();
            }
            catch (Exception ex)
            {
                Global.Create_OffLog("Alert", "LoadNew file @ Error...");
                MessageBox.Show("LoadNew file @ Error Code:- 7002" + '\n' + ex.Message, "Limit File",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //MessageBox.Show("LoadNew file @ Error Code:- 7002" + ex.Message);
            }
        }
        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result1 = MessageBox.Show("Do you Want to Delete ?", "Important Question", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result1 == DialogResult.Yes)
                {
                    Common.Open_Connection("lim_db", "limCon"); 
                    string S = LimCombo.Text.Trim();
                    Common.Del_limTable(S, "Common.conLim");
                    Global.Create_OffLog("Normal", "frmLimit  File deleted Manually.....");
                    MessageBox.Show("File Deleted","Limit File",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
                    //MessageBox.Show("Deleted");
                }
                else
                {
                    Global.Create_OffLog("Alert", "file not Deleted...");
                    MessageBox.Show("File not Deleted", "Limit File",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show("File Not Deleted"); 
                }

                Fill_comboBox();
            }
            catch (Exception ex)
            {
                //Common01.Create_OffLog("Alert", "file not Deleted...");
                MessageBox.Show("mnuDelete_Click @ Error Code:- 7014" + '\n' + ex.Message, "Limit File",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
               // MessageBox.Show("mnuDelete_Click @ Error Code:- 7014", ex.Message);
            }

        }

        private void mnuHelp_Click(object sender, EventArgs e)
        {
            string helpFilepath = @"" + Global.HelpPath + "Engine.chm";
            if (File.Exists(helpFilepath))
            {
                Process.Start(helpFilepath);
            }
            else
            {
                MessageBox.Show("File not Found" + '\n' + helpFilepath, "Limit File",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("file not Found" + helpFilepath);
            }

        }

        private void Load_Grid()
        {
            try
            {
                label1.Text = LimCombo.Text.ToLower();
                Common.Open_Connection("lim_db", "conLim");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + LimCombo.Text.ToLower() + " ORDER BY Pn", Common.conLim);
                MySqlDataReader Rd = cmd.ExecuteReader();
                int Rw = 0;

                if (Rd != null)
                {
                    limDGV.RowCount = 1;
                    int X = 0;
                    //int Y = 0;
                    while (Rd.Read())
                    {
                        X += 1;
                        if (X <= 99)
                        {
                            limDGV.RowCount += 1;
                            limDGV[0, Rw].Value = Rd.GetValue(0).ToString();
                            limDGV[1, Rw].Value = Rd.GetValue(1).ToString();
                            limDGV[2, Rw].Value = Rd.GetValue(2).ToString();
                            limDGV[3, Rw].Value = Rd.GetValue(3).ToString();
                            limDGV[4, Rw].Value = Rd.GetValue(4).ToString();
                            limDGV[5, Rw].Value = Rd.GetValue(5).ToString();
                            limDGV[6, Rw].Value = Rd.GetValue(6).ToString();
                            limDGV[7, Rw].Value = Rd.GetValue(7).ToString();
                            limDGV[8, Rw].Value = Rd.GetValue(8).ToString();                          
                            Rw += 1;
                        }

                    }

                }
                Rd.Dispose();
                cmd.Dispose();
                Common.conLim.Close();

                Label10.Text = limDGV[7, Rn].Value.ToString();
                Label11.Text = limDGV[6, Rn].Value.ToString();
                Label12.Text = limDGV[1, Rn].Value.ToString();
                Label9.Text = limDGV[8, Rn].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load_Grid @ Error Code:-7003" + '\n' + ex.Message, "Limit File",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //Common01.Create_OffLog("Alert", "Load_Grid Error...");
               // MessageBox.Show("Load_Grid @ Error Code:-7003 " + ex.Message);
            }

        }


        private void Fill_comboBox()
        {
            try
            {

                Common.Open_Connection("lim_db", "conLim");
                MySqlCommand cmd = new MySqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='lim_db'", Common.conLim);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    LimCombo.Items.Clear();
                    while (reader.Read())
                    {
                        LimCombo.Items.Add((string)reader["TABLE_NAME"]);
                    }
                    reader.Dispose();
                }

                cmd.Dispose();
                Common.con.Close();
                if (label1.Text == "") LimCombo.SelectedIndex = 0;
                else LimCombo.Text = label1.Text;

                //LimCombo.Text = label1.Text; //.SelectedIndex = 0;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Fill_comboBox @ Error Code: 12004 " + '\n' + ex.Message, "Limit File",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //Common01.Create_OffLog("Alert", "Fill_comboBox @ Error...");
               // MessageBox.Show("Fill_comboBox @ Error Code 12004 : " + ex.Message);
            }
        }

        private void frmLimit_Load(object sender, EventArgs e)
        {
            Fill_comboBox();
            Load_Grid();
        }

        private void LimCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Grid();
        }

        private void timer1_Tick(object sender, EventArgs e)

        {
            
            if (TextBox1.Text == "") TextBox1.BackColor = Color.LightGray; else TextBox1.BackColor = Color.WhiteSmoke;
            if (TextBox2.Text == "") TextBox2.BackColor = Color.LightGray; else TextBox2.BackColor = Color.WhiteSmoke;
            if (TextBox3.Text == "") TextBox3.BackColor = Color.LightGray; else TextBox3.BackColor = Color.WhiteSmoke;
            if (TextBox4.Text == "") TextBox4.BackColor = Color.LightGray; else TextBox4.BackColor = Color.WhiteSmoke;
            
        }
       private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem.Text == "No Alarm")
                {
                    if (TextBox2.ContainsFocus == true) TextBox2.Text = "";
                    if (TextBox3.ContainsFocus == true) TextBox3.Text = "";
                }
                else if (e.ClickedItem.Text == "Only Alarm")
                {
                    if ((TextBox2.ContainsFocus == true) && (TextBox2.BackColor != Color.LightGray))                      // Decimal X = Convert.ToDecimal(Tx);                     
                    {
                        if (TextBox2.Text.Substring(0, 1) == "A") TextBox2.Text = "A"; else TextBox2.Text = "A" + TextBox2.Text;
                    }
                    if ((TextBox3.ContainsFocus == true) && (TextBox3.BackColor != Color.LightGray))
                    {
                        if (TextBox3.Text.Substring(0, 1) == "A") TextBox3.Text = "A"; else TextBox3.Text = "A" + TextBox3.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:-12005" + '\n' + ex.Message, "Limit File",
                MessageBoxButtons.OK, MessageBoxIcon.Error);  
                //MessageBox.Show("Error Code:-12005", ex.Message);
            }

        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem.Text == "No Alarm")
                {
                    if (TextBox1.ContainsFocus == true) TextBox1.Text = "";
                    if (TextBox4.ContainsFocus == true) TextBox4.Text = "";
                }

                if (e.ClickedItem.Text == "Engine To Idle")
                {
                    if ((TextBox1.ContainsFocus == true) && (TextBox1.BackColor != Color.LightGray))
                    {
                        if (TextBox1.Text.Substring(0, 1) == "I") TextBox1.Text = "I"; else TextBox1.Text = "I" + TextBox1.Text;
                    }
                    if ((TextBox4.ContainsFocus == true) && (TextBox4.BackColor != Color.LightGray))
                    {
                        if (TextBox4.Text.Substring(0, 1) == "I") TextBox4.Text = "I"; else TextBox4.Text = "I" + TextBox4.Text;
                    }

                }
                if (e.ClickedItem.Text == "Engine Shut 'OFF'")
                {
                    if ((TextBox1.ContainsFocus == true) && (TextBox1.BackColor != Color.LightGray))
                    {
                        if (TextBox1.Text.Substring(0, 1) == "O") TextBox1.Text = "O"; else TextBox1.Text = "O" + TextBox1.Text;
                    }
                    if ((TextBox4.ContainsFocus == true) && (TextBox4.BackColor != Color.LightGray))
                    {
                        if (TextBox4.Text.Substring(0, 1) == "O") TextBox4.Text = "O"; else TextBox4.Text = "O" + TextBox4.Text;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:-12006:" + '\n' + ex.Message, "Limit File",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
              //  MessageBox.Show("Error Code:-12006:", ex.Message);
            }

        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            Check_AlarmStatus();
            TextBox1.SelectAll();
        }

        //private void TextBox2_Leave(object sender, EventArgs e)
        //{
        //    Check_AlarmStatus();
        //    TextBox2.SelectAll();
        //}

        //private void TextBox3_Leave(object sender, EventArgs e)
        //{
        //    Check_AlarmStatus();
        //    TextBox3.SelectAll();
        //}

        //private void TextBox4_Leave(object sender, EventArgs e)
        //{
        //    Check_AlarmStatus();
        //    TextBox4.SelectAll();
        //}


        private void Check_AlarmStatus()
        {
            try
            {
                if (TextBox1.BackColor != Color.LightGray)
                {
                    if ((TextBox1.Text.Substring(0, 1).ToUpper() != "I") && (TextBox1.Text.Substring(0, 1).ToUpper() != "O"))
                    {
                        MessageBox.Show("Please select the \'Alarm\' Status for Lower set Low !", "Limit File",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                       // MessageBox.Show("Please select the \'Alarm\' Status for Lower set Low !");
                        TextBox1.ContextMenuStrip = contextMenuStrip2;
                        TextBox1.Focus();
                        TextBox1.ContextMenuStrip.Show(TextBox1, new Point(0, TextBox1.Height)); //, ToolStripDropDownDirection.BelowRight);
                        return;
                    }
                }

                if (TextBox4.BackColor != Color.LightGray)
                {
                    if ((TextBox4.Text.Substring(0, 1).ToUpper() != "I") && (TextBox4.Text.Substring(0, 1).ToUpper() != "O"))
                    {
                        MessageBox.Show("Please select the \'Alarm\' Status for Lower set Low !", "Limit File",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //MessageBox.Show("Please select the \'Alarm\' Status for Lower set Low !");
                        TextBox4.ContextMenuStrip = contextMenuStrip2;
                        TextBox4.Focus();
                        TextBox4.ContextMenuStrip.Show(TextBox4, new Point(0, TextBox4.Height)); //, ToolStripDropDownDirection.BelowRight);
                        return;

                    }
                }

                // ******************//Check Alarm Status.... A

                if (TextBox2.BackColor != Color.LightGray)
                {
                    if (TextBox2.Text.Substring(0, 1).ToUpper() != "A")
                    {
                        MessageBox.Show("Please select the \'Alarm\' Status for Lower set Low !", "Limit File",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       // MessageBox.Show("Please select the \'Alarm\' Status for Lower set Low !");                   
                        TextBox2.ContextMenuStrip = contextMenuStrip2;
                        TextBox2.Focus();
                        TextBox2.ContextMenuStrip.Show(TextBox2, new Point(0, TextBox2.Height)); //, ToolStripDropDownDirection.BelowRight);
                        return;

                    }
                }
                if (TextBox3.BackColor != Color.LightGray)
                {
                    if (TextBox3.Text.Substring(0, 1).ToUpper() != "A")
                    {
                        MessageBox.Show("Please select the \'Alarm\' Status for Lower set Low !", "Limit File",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // MessageBox.Show("Please select the \'Alarm\' Status for Lower set Low !");                        
                        TextBox3.ContextMenuStrip = contextMenuStrip2;
                        TextBox3.Focus();
                        TextBox3.ContextMenuStrip.Show(TextBox3, new Point(0, TextBox2.Height)); //, ToolStripDropDownDirection.BelowRight);
                        return;
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Check_AlarmStatus @ Error Code:-7007" + '\n' + ex.Message, "Limit File",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
              //  MessageBox.Show("Check_AlarmStatus @ Error Code:-7007 " + ex.Message);
            }
        }

        private void CheckFormats()
        {
            try
            {
                String Str = Label10.Text;
                int pos = 0;
                pos = Label10.Text.IndexOf(".", 0);
                if (pos == 3)
                {
                    if ((TextBox1.BackColor != Color.LightGray))
                    {
                        Decimal X = Convert.ToDecimal(TextBox1.Text.Substring(1, (TextBox1.Text.Length - 1)));
                        TextBox1.Text = (TextBox1.Text.Substring(0, 1) + X.ToString("000.0"));
                    }
                    else
                    {
                        TextBox1.Text = "";
                    }

                    //*************************
                    if ((TextBox2.BackColor != Color.LightGray))
                    {
                        Decimal X = Convert.ToDecimal(TextBox2.Text.Substring(1, (TextBox2.Text.Length - 1)));
                        TextBox2.Text = (TextBox2.Text.Substring(0, 1) + X.ToString("000.0"));
                    }
                    else
                    {
                        TextBox2.Text = "";
                    }
                    //*************************
                    if ((TextBox3.BackColor != Color.LightGray))
                    {
                        Decimal X = Convert.ToDecimal(TextBox3.Text.Substring(1, (TextBox3.Text.Length - 1)));
                        TextBox3.Text = (TextBox3.Text.Substring(0, 1) + X.ToString("000.0"));
                    }
                    else
                    {
                        TextBox3.Text = "";
                    }
                    //*************************
                    if ((TextBox4.BackColor != Color.LightGray))
                    {
                        Decimal X = Convert.ToDecimal(TextBox4.Text.Substring(1, (TextBox4.Text.Length - 1)));
                        TextBox4.Text = (TextBox4.Text.Substring(0, 1) + X.ToString("000.0"));
                    }
                    else
                    {
                        TextBox4.Text = "";
                    }
                    //*************************

                }
                if (pos == 2)
                {
                    if ((TextBox1.BackColor != Color.LightGray))
                    {
                        Decimal X = Convert.ToDecimal(TextBox1.Text.Substring(1, (TextBox1.Text.Length - 1)));
                        TextBox1.Text = (TextBox1.Text.Substring(0, 1) + X.ToString("00.00"));
                    }
                    else
                    {
                        TextBox1.Text = "";
                    }

                    //*************************
                    if ((TextBox2.BackColor != Color.LightGray))
                    {
                        Decimal X = Convert.ToDecimal(TextBox2.Text.Substring(1, (TextBox2.Text.Length - 1)));
                        TextBox2.Text = (TextBox2.Text.Substring(0, 1) + X.ToString("00.00"));
                    }
                    else
                    {
                        TextBox2.Text = "";
                    }
                    //*************************
                    if ((TextBox3.BackColor != Color.LightGray))
                    {
                        Decimal X = Convert.ToDecimal(TextBox3.Text.Substring(1, (TextBox3.Text.Length - 1)));
                        TextBox3.Text = (TextBox3.Text.Substring(0, 1) + X.ToString("00.00"));
                    }
                    else
                    {
                        TextBox3.Text = "";
                    }
                    //*************************
                    if ((TextBox4.BackColor != Color.LightGray))
                    {
                        Decimal X = Convert.ToDecimal(TextBox4.Text.Substring(1, (TextBox4.Text.Length - 1)));
                        TextBox4.Text = (TextBox4.Text.Substring(0, 1) + X.ToString("00.00"));
                    }
                    else
                    {
                        TextBox4.Text = "";
                    }
                    //*************************                  
                }

                if (pos == 1)
                {
                    if ((TextBox1.BackColor != Color.LightGray))
                    {
                        Decimal X = Convert.ToDecimal(TextBox1.Text.Substring(1, (TextBox1.Text.Length - 1)));
                        TextBox1.Text = (TextBox1.Text.Substring(0, 1) + X.ToString("0.000"));
                    }
                    else
                    {
                        TextBox1.Text = "";
                    }

                    //*************************
                    if ((TextBox2.BackColor != Color.LightGray))
                    {
                        Decimal X = Convert.ToDecimal(TextBox2.Text.Substring(1, (TextBox2.Text.Length - 1)));
                        TextBox2.Text = (TextBox2.Text.Substring(0, 1) + X.ToString("0.000"));
                    }
                    else
                    {
                        TextBox2.Text = "";
                    }
                    //*************************
                    if ((TextBox3.BackColor != Color.LightGray))
                    {
                        Decimal X = Convert.ToDecimal(TextBox3.Text.Substring(1, (TextBox3.Text.Length - 1)));
                        TextBox3.Text = (TextBox3.Text.Substring(0, 1) + X.ToString("0.000"));
                    }
                    else
                    {
                        TextBox3.Text = "";
                    }
                    //*************************
                    if ((TextBox4.BackColor != Color.LightGray))
                    {
                        Decimal X = Convert.ToDecimal(TextBox4.Text.Substring(1, (TextBox4.Text.Length - 1)));
                        TextBox4.Text = (TextBox4.Text.Substring(0, 1) + X.ToString("0.000"));
                    }
                    else
                    {
                        TextBox4.Text = "";
                    }
                    //*************************
                }
                if ((pos == 0) || (pos >= 4))
                {
                    if ((TextBox1.BackColor != Color.LightGray))
                    {
                        Decimal X = Convert.ToDecimal(TextBox1.Text.Substring(1, (TextBox1.Text.Length - 1)));
                        TextBox1.Text = (TextBox1.Text.Substring(0, 1) + X.ToString("0000"));
                    }
                    else
                    {
                        TextBox1.Text = "";
                    }

                    //*************************
                    if ((TextBox2.BackColor != Color.LightGray))
                    {
                        Decimal X = Convert.ToDecimal(TextBox2.Text.Substring(1, (TextBox2.Text.Length - 1)));
                        TextBox2.Text = (TextBox2.Text.Substring(0, 1) + X.ToString("0000"));
                    }
                    else
                    {
                        TextBox2.Text = "";
                    }
                    //*************************
                    if ((TextBox3.BackColor != Color.LightGray))
                    {
                        Decimal X = Convert.ToDecimal(TextBox3.Text.Substring(1, (TextBox3.Text.Length - 1)));
                        TextBox3.Text = (TextBox3.Text.Substring(0, 1) + X.ToString("0000"));
                    }
                    else
                    {
                        TextBox3.Text = "";
                    }
                    //*************************
                    if ((TextBox4.BackColor != Color.LightGray))
                    {
                        Decimal X = Convert.ToDecimal(TextBox4.Text.Substring(1, (TextBox4.Text.Length - 1)));
                        TextBox4.Text = (TextBox4.Text.Substring(0, 1) + X.ToString("0000"));
                    }
                    else
                    {
                        TextBox4.Text = "";
                    }
                    //*************************                 
                }
            }

            catch (Exception ex)
            {
                //Create_OffLog("Error In CheckFormats");
               // MessageBox.Show("CheckFormats @ Error Code:-12008 : " + ex.Message);
                MessageBox.Show("CheckFormats @ Error Code:-12008" + '\n' + ex.Message, "Limit File",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                mnuNew.Enabled = false;
                mnuDelete.Enabled = false;

                Rn = limDGV.CurrentRow.Index;

                // ****************Checkiing for Alarm Status
                Check_AlarmStatus();
                //******************* Checking Formats.... 
                CheckFormats();
                //******************* Checking Validation Status.... 
                Validation_Status();

                Rn = limDGV.CurrentRow.Index;
                // '***********Add Modified Parameters To the Grid

                if (TextBox1.BackColor != Color.LightGray) limDGV[2, Rn].Value = TextBox1.Text; else limDGV[2, Rn].Value = "N";
                if (TextBox2.BackColor != Color.LightGray) limDGV[3, Rn].Value = TextBox2.Text; else limDGV[3, Rn].Value = "N";
                if (TextBox3.BackColor != Color.LightGray) limDGV[4, Rn].Value = TextBox3.Text; else limDGV[4, Rn].Value = "N";
                if (TextBox4.BackColor != Color.LightGray) limDGV[5, Rn].Value = TextBox4.Text; else limDGV[5, Rn].Value = "N";
                //dAdapter.Update(dTable);

                Save_Fields();

            }
            catch (Exception ex)
            {
                //Create_OffLog("Alert", "Error In btnAdd");
                MessageBox.Show("btnadd @ Error Code:-7009" + '\n' + ex.Message, "Limit File",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
               // MessageBox.Show("btnadd @ Error Code:-7009", ex.Message);
            }
        }
        private void Save_Fields()
        {
            try
            {
                int Rw = limDGV.CurrentRow.Index; // 0;
                Common.Open_Connection("lim_db", "conLim");
                MySqlCommand cmd = new MySqlCommand();

                //for (Rw = 0; Rw <= (limDGV.RowCount - 2); Rw++)
                //{
                    int x = Convert.ToInt16(limDGV.Rows[Rw].Cells[0].Value);
                    cmd.CommandText = "UPDATE " + LimCombo.Text.ToLower() + " SET" +
                              " Lower1 = '" + limDGV.Rows[Rw].Cells[2].Value.ToString() + "'," +
                              " Low1 = '" + limDGV.Rows[Rw].Cells[3].Value.ToString() + "'," +
                              " High1 = '" + limDGV.Rows[Rw].Cells[4].Value.ToString() + "'," +
                              " Higher1 = '" + limDGV.Rows[Rw].Cells[5].Value.ToString() + "'" +
                              " WHERE Pn = " + x;
                    cmd.Connection = Common.conLim;
                    cmd.ExecuteNonQuery();
                //}
                Common.conLim.Close();
                Global.Create_OffLog("Normal", "Limit File Saved.");
                MessageBox.Show("New Changes are saved.", "Limit File",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                // MessageBox.Show("New Changes are saved.");
                //Fill_comboBox();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void Validation_Status()
        {
            try
            {

                Double str1 = Convert.ToDouble(Label11.Text);
                Double str2 = Convert.ToDouble(Label10.Text);
                Double LL1 = str1;
                Double L1 = 0;
                Double H1 = 0;
                Double HH1 = str2;
              

                if ((TextBox1.BackColor != Color.LightGray)) LL1 = Convert.ToDouble(TextBox1.Text.Substring(1, (TextBox1.Text.Length - 1)));
                if ((TextBox2.BackColor != Color.LightGray)) L1 = Convert.ToDouble(TextBox2.Text.Substring(1, (TextBox2.Text.Length - 1)));
                if ((TextBox3.BackColor != Color.LightGray)) H1 = Convert.ToDouble(TextBox3.Text.Substring(1, (TextBox3.Text.Length - 1)));
                if ((TextBox4.BackColor != Color.LightGray)) HH1 = Convert.ToDouble(TextBox4.Text.Substring(1, (TextBox4.Text.Length - 1)));

                if (((LL1 < str1) || (LL1 > str2)) && (TextBox1.BackColor != Color.LightGray))
                {
                    MessageBox.Show("L-Low1 'Limit' value must be between Parameter Min and Max Value!", "Limit File",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //MessageBox.Show("L-Low1 'Limit' value must be between Parameter Min and Max Value. !! ");
                    TextBox1.Focus();
                    return;
                }
                if ((LL1 > L1) && (TextBox2.BackColor != Color.LightGray))
                {
                    MessageBox.Show("L-Low1 'Limit' value must be Less then Low1 'Limit' value!", "Limit File",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //MessageBox.Show("L-Low1 'Limit' value must be Less then Low1 'Limit' value !!");
                    TextBox1.Focus();
                    return;
                }
                if (((L1 < str1) || (L1 > str2)) && (TextBox2.BackColor != Color.LightGray))
                {
                    MessageBox.Show("Low1 'Limit' value must be between Parameter Min and Max Value.!", "Limit File",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //MessageBox.Show("Low1 'Limit' value must be between Parameter Min and Max Value. !! ");
                    TextBox2.Focus();
                    return;
                }
                if ((L1 > H1) && (TextBox3.BackColor != Color.LightGray))
                {
                    MessageBox.Show("Low1 'Limit' value must be Less then High1 'Limit' value!", "Limit File",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //MessageBox.Show("Low1 'Limit' value must be Less then High1 'Limit' value !!");
                    TextBox2.Focus();
                    return;
                }

                if (((H1 < str1) || (H1 > str2)) && (TextBox3.BackColor != Color.LightGray))
                {
                    MessageBox.Show("High1 'Limit' value must be between Parameter Min and Max Value. !", "Limit File",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //MessageBox.Show("High1 'Limit' value must be between Parameter Min and Max Value. !! ");
                    TextBox3.Focus();
                    return;
                }
                if ((H1 > HH1) && (TextBox4.BackColor != Color.LightGray))
                {
                    MessageBox.Show("High1 'Limit' value must be Less then H-High1 'Limit' value!", "Limit File",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   // MessageBox.Show("High1 'Limit' value must be Less then H-High1 'Limit' value !!");
                    TextBox3.Focus();
                    return;
                }
                if (((HH1 < str1) || (HH1 > str2)) && (TextBox4.BackColor != Color.LightGray))
                {
                    MessageBox.Show("H-High1 'Limit' value must be between Parameter Min and Max Value.!", "Limit File",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //MessageBox.Show("H-High1 'Limit' value must be between Parameter Min and Max Value. !! ");
                    TextBox4.Focus();
                    return;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Validation_Status @ Error Code:7019" + '\n' + ex.Message, "Limit File",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Validation_Status @ Error Code:7019" + ex.Message);
            }
        }
       
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Common.Key_Validation(e.KeyChar);
        }
        private void TextBox1_Validating(object sender, CancelEventArgs e)
        {
            Validation_Status();
        }
        private void TextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                TextBox1.ContextMenuStrip = contextMenuStrip1;  
                TextBox1.Focus();
                TextBox1.ContextMenuStrip.Show(TextBox1, new Point(0, TextBox1.Height)); //, ToolStripDropDownDirection.BelowRight);
            }

        }

        private void limDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Rn = limDGV.CurrentRow.Index;   //      = e.RowIndex;    // limDGV.CurrentRow.Index;


                Label10.Text = limDGV[7, Rn].Value.ToString();
                Label11.Text = limDGV[6, Rn].Value.ToString();
                Label12.Text = limDGV[1, Rn].Value.ToString();
                Label9.Text = limDGV[8, Rn].Value.ToString();


                if (limDGV[2, Rn].Value.ToString() != "N") TextBox1.Text = limDGV[2, Rn].Value.ToString(); else TextBox1.Text = "";
                if (limDGV[3, Rn].Value.ToString() != "N") TextBox2.Text = limDGV[3, Rn].Value.ToString(); else TextBox2.Text = "";
                if (limDGV[4, Rn].Value.ToString() != "N") TextBox3.Text = limDGV[4, Rn].Value.ToString(); else TextBox3.Text = "";
                if (limDGV[5, Rn].Value.ToString() != "N") TextBox4.Text = limDGV[5, Rn].Value.ToString(); else TextBox4.Text = "";

                if ((Rn == 2) || (Rn == 3) || (Rn == 4) || (Rn == 5))
                {
                    MessageBox.Show("Limits Not allowed for this Parameter", "Limit File", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    TextBox1.Enabled = false;
                    TextBox2.Enabled = false;
                    TextBox3.Enabled = false;
                    TextBox4.Enabled = false;
                }
                else
                {
                    TextBox1.Enabled = true;
                    TextBox2.Enabled = true;
                    TextBox3.Enabled = true;
                    TextBox4.Enabled = true;
                }
                if (limDGV[1, Rn].Value.ToString() == "Not_Prog")
                {
                    MessageBox.Show("Limits Not allowed, As This parameter is 'NOT PROGRAMMED'....", "Limit File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TextBox1.Enabled = false;
                    TextBox2.Enabled = false;
                    TextBox3.Enabled = false;
                    TextBox4.Enabled = false;
                }
                else
                {
                    TextBox1.Enabled = true;
                    TextBox2.Enabled = true;
                    TextBox3.Enabled = true;
                    TextBox4.Enabled = true;
                }


            }
            catch (Exception ex)
            {
                //Create_OffLog("Alert", "Error In limDGV_CellClick");
                MessageBox.Show("limDGV_CellClick @ Error Code7011" + '\n' + ex.Message, "Limit File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("limDGV_CellClick @ Error Code7011", ex.Message);
            }

        }
        private void TextBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                TextBox2.ContextMenuStrip = contextMenuStrip2;
                TextBox2.Focus();
                TextBox2.ContextMenuStrip.Show(TextBox2, new Point(0, TextBox2.Height)); //, ToolStripDropDownDirection.BelowRight);
            }

        }

        private void TextBox4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                TextBox4.ContextMenuStrip = contextMenuStrip1;
                TextBox4.Focus();
                TextBox4.ContextMenuStrip.Show(TextBox4, new Point(0, TextBox4.Height)); //, ToolStripDropDownDirection.BelowRight);
            }
        }

        private void TextBox3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                TextBox3.ContextMenuStrip = contextMenuStrip2;
                TextBox3.Focus();
                TextBox3.ContextMenuStrip.Show(TextBox3, new Point(0, TextBox1.Height)); //, ToolStripDropDownDirection.BelowRight);
            }
        }
        private void Chk_Name()
        {
            try
            {
                Common.FormatCombo(LimCombo);
                if (LimCombo.Text.Length <= 0)
                {
                    EP.SetError(LimCombo, "Type the File Name First...");
                    LimCombo.Focus();
                    return;
                }
                else if (LimCombo.Text.Length <= 5)
                {
                    EP.SetError(LimCombo, "The name should be More than 5 Letters...");
                    LimCombo.Focus();
                }
                else if (((LimCombo.Text.Substring(0, 4)) == "Lim_") || ((LimCombo.Text.Substring(0, 4)) == "LIM_") || ((LimCombo.Text.Substring(0, 4)) == "lim_"))
                {
                    LimCombo.Text = "lim_" + (LimCombo.Text.Substring(4)).ToLower();
                    EP.Clear();
                }
                else
                {
                    LimCombo.Text = "lim_" + LimCombo.Text.ToLower();
                    EP.Clear();
                }
                label1.Text = LimCombo.Text.ToLower();
            }
            catch (Exception ex)
            {
                MessageBox.Show("LimCombo_Leave @ Error Code:-7013 " + '\n' + ex.Message, "Limit File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LimCombo_Leave(object sender, EventArgs e)
        {
            Chk_Name(); 
            //try
            //{
            //    Common.FormatCombo(LimCombo);
            //    if (LimCombo.Text.Length <= 0)
            //    {
            //        EP.SetError(LimCombo, "Type the File Name First...");
            //        LimCombo.Focus();
            //        return;
            //    }
            //    else if (LimCombo.Text.Length <= 5)
            //    {
            //        EP.SetError(LimCombo, "The name should be More than 5 Letters...");
            //        LimCombo.Focus();
            //    }
            //    else if (((LimCombo.Text.Substring(0, 4)) == "Lim_") || ((LimCombo.Text.Substring(0, 4)) == "LIM_") || ((LimCombo.Text.Substring(0, 4)) == "lim_"))
            //    {
            //        LimCombo.Text = "lim_" + (LimCombo.Text.Substring(4)).ToLower();
            //        EP.Clear();
            //    }
            //    else
            //    {
            //        LimCombo.Text = "lim_" + LimCombo.Text.ToLower();
            //        EP.Clear();
            //    }               
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("LimCombo_Leave @ Error Code:-7013 " + '\n' + ex.Message, "Limit File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void limDGV_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void Label6_Click(object sender, System.EventArgs e)
        {

        }       
    }
    
}
