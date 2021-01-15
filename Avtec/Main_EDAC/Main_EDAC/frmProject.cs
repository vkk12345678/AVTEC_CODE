using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Logger
{
    public partial class frmProject : Form
    {
        Boolean flg_New = false;
        MySqlDataAdapter Adp = new MySqlDataAdapter();
        DataSet ds = new DataSet();
        int Rw = 0;
        public frmProject()
        {
            InitializeComponent();
        }

        private void frmProject_Load(object sender, EventArgs e)
        {
            try
            {
                ComboBox1.Items.Clear();
                ComboBox2.Items.Clear();
                ComboBox3.Items.Clear();
                ComboBox4.Items.Clear();

                DGPrj.RowCount = 10;
                DGPrj.RowTemplate.Height = 30;
                foreach (DataGridViewColumn colm in DGPrj.Columns)
                {
                    colm.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                DGPrj[0, 0].Value = "Engine Rated Power (kW):";
                DGPrj[0, 1].Value = "@ Engine rpm :";
                DGPrj[0, 2].Value = "Engine Rated Torque (Nm):";
                DGPrj[0, 3].Value = "@ Engine rpm :";
                DGPrj[0, 4].Value = "Engine Flyup RPM:";
                DGPrj[0, 5].Value = "Engine Idle RPM:";
                DGPrj[0, 6].Value = "Engine Start RPM:";
                DGPrj[0, 7].Value = "Engine Start plus Duration(s)";
                DGPrj[0, 8].Value = "Engine Cummulative (hr.mm):";
                DGPrj[0, 9].Value = "Log PM' Data After Eng.OFF(secs)";
                DGPrj.Columns[1].DefaultCellStyle.ForeColor = Color.Red;

                ComboBox3.Items.Clear();
                ComboBox3.Refresh();

                Global.Open_Connection("seq_db", "conSeq");
                MySqlCommand cmd = new MySqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='seq_db'", Global.conSeq);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    ComboBox3.Items.Clear();
                    while (reader.Read())
                    {
                        ComboBox3.Items.Add((string)reader["TABLE_NAME"]);
                    }
                    reader.Dispose();
                }


                cmd.Dispose();
                Global.conSeq.Close();
                ComboBox3.SelectedIndex = 0;

                //----------------------------------

                ComboBox4.Items.Clear();
                ComboBox4.Refresh();
                Global.Open_Connection("lim_db", "conLim");
                MySqlCommand cmd1 = new MySqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'lim_db'", Global.conLim);
                using (MySqlDataReader reader = cmd1.ExecuteReader())
                {
                    ComboBox4.Items.Clear();
                    while (reader.Read())
                    {
                        ComboBox4.Items.Add((string)reader["TABLE_NAME"]);
                    }
                    reader.Close();
                }
                cmd1.Dispose();

                Global.conLim.Close();
                ComboBox4.SelectedIndex = 0;



                Global.Open_Connection("gen_db", "con");
                Adp = new MySqlDataAdapter("SELECT * FROM tblEngine", Global.con);
                ds = new DataSet();
                Adp.Fill(ds);

                int x = 0;
                ComboBox2.Items.Clear();
                for (x = 0; x <= (ds.Tables[0].Rows.Count - 1); x++)
                {
                    ComboBox2.Items.Add(ds.Tables[0].Rows[x].ItemArray[0]);
                }
                ds.Dispose();
                Adp.Dispose();

                Global.Open_Connection("gen_db", "con");
                Adp = new MySqlDataAdapter("Select * from tblProject", Global.con);
                ds = new DataSet();
                Adp.Fill(ds);
                PrjGV.DataSource = ds.Tables[0];
                PrjGV.Columns[0].Width = 100;
                PrjGV.Columns[1].Width = 100;
                PrjGV.Columns[2].Width = 100;
                PrjGV.Columns[3].Width = 100;
                PrjGV.Columns[4].Width = 100;
                PrjGV.Columns[5].Width = 100;
                PrjGV.Columns[6].Width = 60;
                PrjGV.Columns[7].Width = 60;
                PrjGV.Columns[8].Width = 60;
                PrjGV.Columns[9].Width = 60;
                PrjGV.Columns[10].Width = 60;
                PrjGV.Columns[11].Width = 60;
                PrjGV.Columns[12].Width = 60;
                PrjGV.Columns[13].Width = 60;
                PrjGV.Columns[14].Width = 60;
                PrjGV.Columns[15].Width = 60;
                foreach (DataGridViewColumn colm in PrjGV.Columns)
                {
                    colm.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                Adp.Update(ds.Tables[0]);
                Load_InCell();

            }

            catch (Exception ex)
            {

                Global.Create_OnLog("ex.Message .........", "Alert");
                return;
                //MessageBox.Show ("Error Code:-11001  " + ex.Message); 
            }
        }
        private void Load_InCell()
        {
            try
            {
                int x = 0;
                Rw = PrjGV.CurrentRow.Index;
                ComboBox1.Text = PrjGV[0, Rw].Value.ToString();
                ComboBox2.Text = PrjGV[1, Rw].Value.ToString();
                ComboBox3.Text = PrjGV[2, Rw].Value.ToString();
                ComboBox4.Text = PrjGV[3, Rw].Value.ToString();
                ComboBox5.Text = PrjGV[4, Rw].Value.ToString();
                ComboBox6.Text = PrjGV[5, Rw].Value.ToString();
                for (x = 0; x < 10; x++)
                {
                    DGPrj[1, x].Value = PrjGV[(x + 6), Rw].Value.ToString();
                }
                Global.Open_Connection("gen_db", "con");
                Adp.Update(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                Global.Create_OnLog(ex.Message + " :  Load In Cell....", "Alert");
                //MessageBox.Show("Error Code:-11002 " + ex.Message);
            }
        }

        private void Load_DataGrid()
        {
            try
            {
                Adp = new MySqlDataAdapter("SELECT * FROM tblProject", Global.con);
                ds = new DataSet();
                Adp.Fill(ds);
                MySqlCommandBuilder cBuilder = new MySqlCommandBuilder(Adp);
                BindingSource bSource = new BindingSource();
                bSource.DataSource = ds.Tables[0];
                PrjGV.DataSource = bSource;

                int x = 0;
                for (x = 0; x < (PrjGV.RowCount - 1); x++)
                {
                    ComboBox1.Items.Add(PrjGV[0, x].Value);
                }
                ComboBox1.SelectedIndex = 0;
                Load_InCell();
                Adp.Update(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                Global.Create_OnLog(ex.Message + " :  Load GridData....","Alert");
                //MessageBox.Show("Error Code:-11003" + ex.Message); 
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Global.flg_Log_supervisor = false;
            this.Close();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_InCell();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            try
            {
                int X = 0;
                if (ComboBox1.Text == "")
                {
                    Ep.SetError(ComboBox1, "Please select/Enter fileName.....");
                    ComboBox1.Focus();
                    return;
                }
                if (ComboBox2.Text == "")
                {
                    Ep.SetError(ComboBox2, "Please select Engine File.....");
                    ComboBox2.Focus();
                    return;
                }
                if (ComboBox3.Text == "")
                {
                    Ep.SetError(ComboBox3, "Please select Sequence File.....");
                    ComboBox3.Focus();
                    return;
                }

                if (ComboBox4.Text == "")
                {
                    Ep.SetError(ComboBox4, "Please select Limit File.....");
                    ComboBox4.Focus();
                    return;
                }

                if (ComboBox5.Text == "")
                {
                    Ep.SetError(ComboBox5, "Please select Correction Standard.....");
                    ComboBox5.Focus();
                    return;
                }
                if (ComboBox6.Text == "")
                {
                    Ep.SetError(ComboBox6, "Please Test Type Standard.....");
                    ComboBox6.Focus();
                    return;
                }

                for (X = 1; X < (DGPrj.RowCount); X++)
                {
                    if (DGPrj[1, X].Value == null)
                    {
                        Ep.SetError(DGPrj, "Please Enter the Value .....");
                        DGPrj.Focus();
                        return;
                    }
                    else
                    {
                        Ep.Clear();
                    }

                }
                Format_Cells();
                X = 0;
                flg_New = true;
                while (X < PrjGV.RowCount - 1)
                {
                    if (ComboBox1.Text == PrjGV[0, X].Value.ToString())
                    {
                        flg_New = false;
                        Rw = PrjGV.CurrentRow.Index;
                        break;
                    }
                    else
                    {
                        flg_New = true;
                    }
                    X++;
                }

                Rw = PrjGV.CurrentRow.Index;

                if (flg_New == false)
                {
                    Global.Open_Connection("gen_db", "con");
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "UPDATE tblProject SET " +
                         " EngFile  = '" + ComboBox2.Text + "'," +
                         " ProgFile  = '" + ComboBox3.Text + "'," +
                         " LimitFile  = '" + ComboBox4.Text + "'," +
                         " CorrFile  = '" + ComboBox5.Text + "'," +
                         " Test_Type  = '" + ComboBox6.Text + "'," +
                         " R_power  = '" + DGPrj[1, 0].Value.ToString() + "'," +
                         " R_rpm  = '" + DGPrj[1, 1].Value.ToString() + "'," +
                         " MT_Torque  = '" + DGPrj[1, 2].Value.ToString() + "'," +
                         " MT_rpm  = '" + DGPrj[1, 3].Value.ToString() + "'," +
                         " Fly_rpm  = '" + DGPrj[1, 4].Value.ToString() + "'," +
                         " Idle_rpm  = '" + DGPrj[1, 5].Value.ToString() + "'," +
                         " E_Strpm  = '" + DGPrj[1, 6].Value.ToString() + "'," +
                         " T_Crank  = '" + DGPrj[1, 7].Value.ToString() + "'," +
                         " C_Time  = '" + DGPrj[1, 8].Value.ToString() + "'," +
                         " PM_Log  = '" + DGPrj[1, 9].Value.ToString() + "'" +
                         " WHERE ProjectFile = '" + ComboBox1.Text + "'";
                    cmd.Connection = Global.con;
                    cmd.ExecuteNonQuery();
                    Load_DataGrid();
                    //MessageBox.Show("Error Code:-11003" + ex.Message); 
                    MessageBox.Show("File Updated", "Project Editor",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);      
                    //MessageBox.Show("File Updated .....");
                }
                else if (flg_New == true)
                {
                    Global.Open_Connection("gen_db", "con");
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "INSERT INTO tblProject VALUES ('" +
                                       ComboBox1.Text + "','" +
                                       ComboBox2.Text + "','" +
                                       ComboBox3.Text + "','" +
                                       ComboBox4.Text + "','" +
                                       ComboBox5.Text + "','" +
                                       ComboBox6.Text + "','" +
                                       DGPrj[1, 0].Value + "','" +
                                       DGPrj[1, 1].Value + "','" +
                                       DGPrj[1, 2].Value + "','" +
                                       DGPrj[1, 3].Value + "','" +
                                       DGPrj[1, 4].Value + "','" +
                                       DGPrj[1, 5].Value + "','" +
                                       DGPrj[1, 6].Value + "','" +
                                       DGPrj[1, 7].Value + "','" +
                                       DGPrj[1, 8].Value + "','" +
                                       DGPrj[1, 9].Value + "')";
                    cmd.Connection = Global.con;
                    cmd.ExecuteNonQuery();
                    Load_DataGrid();
                    MessageBox.Show("File Saved", "Project Editor",
                    MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    //MessageBox.Show("File Saved .....");
                }
            }
            catch (Exception ex)
            {
                Global.Create_OnLog(ex.Message + " :  File Save....", "Alert");
                //MessageBox.Show("Error Code:- 11004" + ex.Message );  
            }
        }


        private void PrjGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Rw = e.RowIndex;
            Load_InCell();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ComboBox1.Text = ""; flg_New = true; ComboBox1.Focus();
        }

        private void ComboBox1_Leave(object sender, EventArgs e)
        {
            if (ComboBox1.Text.Length <= 4)
            {
                Ep.SetError(ComboBox1, "Type the File Name First..." +
                                       "Name Should Be More Than 5 Characters");
                ComboBox1.Focus();
                ComboBox1.Text = "";
                return;
            }

            string l = ComboBox1.Text.Substring(0, 4).ToString();
            if ((l == "PRJ_") || (l == "prj_") || (l == "Prj_"))
            {
                ComboBox1.Text = "Prj_" + (ComboBox1.Text.ToUpper().Substring(4));
                Ep.Clear();
                return;
            }
            else
            {
                ComboBox1.Text = "Prj_" + ComboBox1.Text.ToUpper();
                Ep.Clear();
            }

        }

        private void Format_Cells()
        {
            try
            {
                Double l = new double();
                int M = DGPrj.CurrentRow.Index;
                for (M = 0; M <= 9; M++)
                {
                    switch (M)
                    {
                        case 0:
                            if (DGPrj[1, M].Value.ToString() == "") DGPrj[1, M].Value = "0";
                            l = Convert.ToDouble(DGPrj[1, M].Value);
                            DGPrj[1, M].Value = l.ToString("000.0");
                            break;
                        case 2:
                            if (DGPrj[1, M].Value.ToString() == "") DGPrj[1, M].Value = "0";
                            l = Convert.ToDouble(DGPrj[1, M].Value);
                            DGPrj[1, M].Value = l.ToString("000.0");
                            break;
                        case 1:
                        case 3:
                        case 4:
                            if (DGPrj[1, M].Value.ToString() == "") DGPrj[1, M].Value = "0";
                            l = Convert.ToDouble(DGPrj[1, M].Value);
                            DGPrj[1, M].Value = l.ToString("0000");
                            break;

                        case 5:
                            if (DGPrj[1, M].Value.ToString() == "") DGPrj[1, M].Value = "600";
                            l = Convert.ToDouble(DGPrj[1, M].Value);
                            if ((l >= 1210) || (l <= 540))
                            {
                                MessageBox.Show("Error: Idle rpm of Engine should be bet' 800 to 1200.", "Project Editor",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);  
                               // MessageBox.Show("Error: Idle rpm of Engine should be bet' 800 to 1200....");
                                DGPrj[1, M].Value = "550";
                            }
                            break;
                        case 6:
                            if (DGPrj[1, M].Value.ToString() == "") DGPrj[1, M].Value = "600";
                            l = Convert.ToDouble(DGPrj[1, M].Value);
                            if ((l >= 1210) || (l <= 540))
                            {
                                MessageBox.Show("Error: Min Rpm To start the Engine should be bet' 550 to 1200.", "Project Editor",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //MessageBox.Show("Error: Min Rpm To start the Engine should be bet' 550 to 1200....");
                                DGPrj[1, M].Value = "550";
                            }
                            break;
                        case 7:
                            if (DGPrj[1, M].Value.ToString() == "") DGPrj[1, M].Value = "0";
                            l = Convert.ToDouble(DGPrj[1, M].Value);

                            if ((l > 2))
                            {
                                DGPrj[1, M].Value = 2;
                            }

                            break;
                        case 8:
                            if (DGPrj[1, M].Value.ToString() == "") DGPrj[1, M].Value = "0";
                            l = Convert.ToDouble(DGPrj[1, M].Value);
                            DGPrj[1, M].Value = l.ToString("0000.00");
                            break;
                        case 9:
                            if (DGPrj[1, M].Value.ToString() == "") DGPrj[1, M].Value = "0";
                            l = Convert.ToDouble(DGPrj[1, M].Value);
                            if (l > 60) DGPrj[1, M].Value = "60";
                            if (l < 2) DGPrj[1, M].Value = "02";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.Create_OnLog(ex.Message + " :  Format Cell.", "Alert");
                // MessageBox.Show("Error Code:- 11005", ex.Message); 

            }

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result1 = MessageBox.Show("Do you Want to Delete ?", "Important Question", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result1 == DialogResult.Yes)
                {
                    MySqlCommand cdelete = new MySqlCommand();
                    cdelete.CommandText = "Delete from tblProject where ProjectFile= '" + ComboBox1.Text + "'";
                    Global.Open_Connection("gen_db", "con");
                    cdelete.Connection = Global.con;
                    cdelete.ExecuteNonQuery();
                    Load_DataGrid();
                }
                else
                {
                    //Editors_DLL.Global.Create_OffLog("Alert", "file not Deleted...");
                    MessageBox.Show("File not Deleted", "Project File",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show("File Not Deleted"); 
                }
            }
            catch (Exception ex)
            {
                //Global.Create_OnLog(ex.Message + " :  Load In Cell....", false);  
                MessageBox.Show("Error Code:- 11006" + ex.Message, "Project Editor",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Error Code:- 11006 " + ex.Message);
            }

        }

        private void ComboBox2_Leave(object sender, EventArgs e)
        {
            if (ComboBox2.Text != "") Ep.Clear();
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox2.Text != "") Ep.Clear();
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox3.Text != "") Ep.Clear();
        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox4.Text != "") Ep.Clear();
        }

        private void ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox6.Text != "") Ep.Clear();
        }

        private void DGPrj_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DGPrj_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int M = DGPrj.CurrentRow.Index;
                string str = DGPrj[1, M].Value.ToString();
                if (!(string.IsNullOrEmpty(str)))
                {

                    char[] chars = str.ToCharArray();

                    for (int i = 0; i < str.Length; i++)
                    {
                        int code;
                        code = Convert.ToInt16(chars[i]);

                        if (!((!(code > 57 || code < 48)) || (code == 46)))
                        {
                            DGPrj[1, M].Value = str.Remove(i, 1);
                        }

                    }

                }
            }
            catch
            {
                DGPrj.Focus();
            }

        }

        private void DGPrj_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {


        }

        private void DGPrj_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PrjGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string helpFilepath = @"" + Global.HelpPATH + "Project.chm";
            if (File.Exists(helpFilepath))
            {
                Process.Start(helpFilepath);
            }
            else
            {
                MessageBox.Show("File not Found" +'\n'+ helpFilepath, "Project Editor",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("file not Found" + helpFilepath);
            }
        }


        //********************  
    }
}
