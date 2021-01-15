using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Logger
{
    
    public partial class frmConf : Form
    {

        System.Windows.Forms.Label[] ArrNo = new
        System.Windows.Forms.Label[15];
        public static Boolean flg_Serial = false;
        public static Boolean flg_Adam = false;
        public static Boolean flg_Analog = false;
        public static Boolean flg_Modbus = false;


        int EcuRn = 0;
        int Echn = 0;
        int i = 0;
        int Rn = 0;
        int chn = 0;
        MySqlDataAdapter Adp = new MySqlDataAdapter();
        DataSet ds = new DataSet();
        string NodeT;
        
        public frmConf()
        {
            InitializeComponent();
        }
        private void Load_DataGrid(int str, int stp)
        {
            try
            {
                if (Global.con.State == ConnectionState.Closed) Global.Open_Connection("gen_db", "con");
                Adp = new MySqlDataAdapter("SELECT * FROM Tb_Std WHERE ParameterNo BETWEEN " + str + " AND " + stp + " ORDER BY ParameterNo", Global.con);
                ds = new DataSet();
                Adp.Fill(ds);
                InGrid.Rows.Clear();    
                InGrid.Refresh();  
                InGrid.RowCount = ds.Tables[0].Rows.Count;
                for (i = 0; i <= InGrid.RowCount - 1; i++)
                {
                    InGrid[0, i].Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    InGrid[1, i].Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    InGrid[2, i].Value = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    InGrid[3, i].Value = ds.Tables[0].Rows[i].ItemArray[3].ToString();
                    InGrid[4, i].Value = ds.Tables[0].Rows[i].ItemArray[4].ToString();
                    InGrid[5, i].Value = ds.Tables[0].Rows[i].ItemArray[5].ToString();
                    InGrid[6, i].Value = ds.Tables[0].Rows[i].ItemArray[6].ToString();
                    InGrid[7, i].Value = ds.Tables[0].Rows[i].ItemArray[7].ToString();
                    InGrid[8, i].Value = ds.Tables[0].Rows[i].ItemArray[8].ToString();
                }
                Global.con.Close();
                Load_Incell(); 
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Error in frmconf",ex.Message);
                MessageBox.Show("Error in frmconf "+ ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                Global.Create_OnLog(ex.Message, "Alert");
            }
        }
        private void Show_Modules()
        {
            DgModule.RowCount = 5;
            DgModule[0, 0].Value = Global.AdamG1[1];
            DgModule[1, 0].Value = Global.AdamG1[2];  // "ADAM-4017";
            DgModule[2, 0].Value = Global.AdamG1[3];  // "K-Type";
            DgModule[0, 1].Value = Global.AdamG1[4];
            DgModule[1, 1].Value = Global.AdamG1[5];
			DgModule[2, 1].Value = Global.AdamG1[6];
            DgModule[0, 2].Value = Global.AdamG1[7];
			DgModule[1, 2].Value = Global.AdamG1[8];
            DgModule[2, 2].Value = Global.AdamG1[9];
            DgModule[0, 3].Value = Global.AdamG1[10];
            DgModule[1, 3].Value = Global.AdamG1[11];
            DgModule[2, 3].Value = Global.AdamG1[12];
            DgModule[0, 4].Value = Global.AdamG1[13];
            DgModule[1, 4].Value = Global.AdamG1[14];
            DgModule[2, 4].Value = Global.AdamG1[15];

		}


      

        private void Load_GridDI()
        {
            try
            {
                if (Global.con.State == ConnectionState.Closed) Global.Open_Connection("gen_db", "con");
                MySqlDataAdapter Adp = new MySqlDataAdapter("SELECT * FROM TbSys WHERE FileName = '03_DigInputs'", Global.con);
                DataSet ds = new DataSet();
                Adp.Fill(ds);
                DGIn.RowCount = 16;
                DGIn.ColumnCount = 3;

                for (i = 0; i <= 15; i++)
                {
                    DGIn[0, i].Value = i;
                    DGIn[2, i].Value = ds.Tables[0].Rows[0].ItemArray[i + 1].ToString();
                }
                Adp.Dispose();
                ds.Dispose();
                Global.con.Close();
                Global.Read_DigIn();
                for (i = 0; i <= 15; i++)
                {
                    if (Global.DigIn[i] == 1)
                    {                       
                        DGIn[1, i].Value = 1;
                        Global.DigIn[i] = 1;
                    }
                    else
                    {                        
                        DGIn[1, i].Value = 0;
                        Global.DigIn[i] = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmconf " + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //MessageBox.Show("Error in frmconf", ex.Message);
                Global.Create_OnLog(ex.Message, "Alert");
            }

        }

        private void Load_GridDo()
        {
            try
            {

                if (Global.con.State == ConnectionState.Closed) Global.Open_Connection("gen_db", "con");
                MySqlDataAdapter Adp = new MySqlDataAdapter("SELECT * FROM TbSys WHERE FileName = '04_DigOutPuts'", Global.con);
                DataSet ds = new DataSet();
                Adp.Fill(ds);
                DGDo.RowCount = 16;
                DGDo.ColumnCount = 3;
                for (i = 0; i <= 15; i++)
                {
                    DGDo.Rows[i].Cells[0].Value = i;
                    DGDo.Rows[i].Cells[2].Value = ds.Tables[0].Rows[0].ItemArray[i + 1].ToString();
                }
                Adp.Dispose();
                ds.Dispose();
                Global.con.Close();
                tmrDigIn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmconf " + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
               // MessageBox.Show("Error in frmconf", ex.Message);
                Global.Create_OnLog(ex.Message, "Alert");
            }
        }

       
        private string mid(string p, int p_2, int p_3)
        {
            throw new NotImplementedException();
        }

        private void tmrDigIn_Tick(object sender, EventArgs e)
        {
            try
            {
                chn = int.Parse(InGrid.Rows[Rn].Cells[0].Value.ToString());
                if (Global.GenData[chn] == null)
                    label4.Text = "0.0";
                else
                    label4.Text = Global.GenData[chn].ToString();
                //lblValue.Text = Global.GenData[chn].ToString(); 
            }
            catch (Exception ex)
            {
                return;              
            }
        }

        private void Save_Para()
        {
            try
            {
                int Rn = int.Parse(txtchno.Text);
                chn = int.Parse(InGrid.Rows[Rn].Cells[0].Value.ToString());
                Double l = Convert.ToDouble(txtmaxval.Text);
                if (l < 10) txtmaxval.Text = l.ToString("0.000");
                else if (l < 100) txtmaxval.Text = l.ToString("00.00");
                else if (l < 1000) txtmaxval.Text = l.ToString("000.0");
                else txtmaxval.Text = l.ToString("0000");
                InGrid.Rows[Rn].Cells[2].Value = txtminval.Text;
                InGrid.Rows[Rn].Cells[3].Value = txtmaxval.Text;
                InGrid.Rows[Rn].Cells[4].Value = cmbunit.Text;
                InGrid.Rows[Rn].Cells[5].Value = txtshname.Text;
                if (CheckBox1.Checked == true)InGrid.Rows[Rn].Cells[6].Value = true;  else InGrid.Rows[Rn].Cells[6].Value = false;
                InGrid.Rows[Rn].Cells[7].Value = txtminval.Text;   //textBox3.Text;
                InGrid.Rows[Rn].Cells[8].Value = txtmaxval.Text;  //textBox4.Text;

                if (Global.con.State == ConnectionState.Closed) Global.Open_Connection("gen_db", "con");
                MySqlCommand ccd = new MySqlCommand("UPDATE Tb_Std SET " +
                     "ParameterName = '" + txtparaname.Text + "'," +
                     "MinVal = '" + txtminval.Text + "'," +
                     "MaxVal = '" + txtmaxval.Text + "'," +
                     "Unit= '" + cmbunit.Text + "'," +
                     "ShortName = '" + txtshname.Text + "'," +
                     "Minip = '" + txtminval.Text + "'," + //'" + textBox3.Text + "'," +
                     "Maxip = '" + txtmaxval.Text + "'," + //'" + textBox4.Text + "'," +
                     "Marked = " + (InGrid.Rows[Rn].Cells[6].Value.ToString()) + " WHERE ParameterNo =" + chn, Global.con);                    
                ccd.ExecuteNonQuery();
                Global.con.Close();
                MessageBox.Show("Updated", "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Information); 
               // MessageBox.Show("UPDAT"); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmconf " + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //MessageBox.Show("Error in frmconf", ex.Message);
                Global.Create_OnLog(ex.Message, "Alert");
            }      
            
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            
        } 
       
       
        private void mnu010000_Click(object sender, EventArgs e)
        {
           txtminval.Text = "0";
           txtmaxval.Text = "9999";
           cmbunit.Text = "rpm";
           txtshname.Text = "E_Speed";       
        }

        private void mnu0100Nm_Click(object sender, EventArgs e)
        {
            txtminval.Text = "0";
            txtmaxval.Text = "100.0";
            cmbunit.Text = "Nm";
            txtshname.Text = "E_Torque";
        }

        private void mnu0200Nm_Click(object sender, EventArgs e)
        {
            txtminval.Text = "0";
            txtmaxval.Text = "200.0";
            cmbunit.Text = "Nm";
            txtshname.Text = "E_Torque";
        }

        private void mnu0500Nm_Click(object sender, EventArgs e)
        {
            txtminval.Text = "0";
            txtmaxval.Text = "500.0";
            cmbunit.Text = "Nm";
            txtshname.Text = "E_Torque";
        }

        private void nmu01000Nm_Click(object sender, EventArgs e)
        {
            txtminval.Text = "0";
            txtmaxval.Text = "1000.0";
            cmbunit.Text = "Nm";
            txtshname.Text = "E_Torque";
        }

        private void mnu0200C_Click(object sender, EventArgs e)
        {
            txtminval.Text = "0";
            txtmaxval.Text = "200.0";
            cmbunit.Text = "°C";
            txtshname.Text = "T_" + txtchno.Text;
        }

        private void mnu01000C_Click(object sender, EventArgs e)
        {
            txtminval.Text = "0";
            txtmaxval.Text = "1000.0";
            cmbunit.Text = "°C";
            txtshname.Text = "T_" + txtchno.Text;
        }

        private void mnu010bar_Click(object sender, EventArgs e)
        {
            txtminval.Text = "0";
            txtmaxval.Text = "10";
            cmbunit.Text = "bar";
            txtshname.Text = "P_" + txtchno.Text;
           
        }

        private void mnu025bar_Click(object sender, EventArgs e)
        {
            txtminval.Text = "0";
            txtmaxval.Text = "2.500";
            cmbunit.Text = "bar";
            txtshname.Text = "P_" + txtchno.Text;
        }

        private void mnu0812bar_Click(object sender, EventArgs e)
        {
            txtminval.Text = "0.800";
            txtmaxval.Text = "1.200";
            cmbunit.Text = "bar";
            txtshname.Text = "P_" + txtchno.Text;
        }

        private void mnu025025bar_Click(object sender, EventArgs e)
        {
            txtminval.Text = "-0.250";
            txtmaxval.Text = "0.250";
            cmbunit.Text = "bar";
            txtshname.Text = "P_" + txtchno.Text;
        }

        private void mnu004bar_Click(object sender, EventArgs e)
        {
            txtminval.Text = "0";
            txtmaxval.Text = "0.400";
            cmbunit.Text = "bar";
            txtshname.Text = "P_" + txtchno.Text;
        }

        private void mnu0400g_Click(object sender, EventArgs e)
        {
            txtminval.Text = "0";
            txtmaxval.Text = "400.0";
            cmbunit.Text = "g";
            txtshname.Text = "P_" + txtchno.Text;
        }

        private void FuelTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtminval.Text = "0";
            txtmaxval.Text = "200.0";
            cmbunit.Text = "s";
            txtshname.Text = "P_" + txtchno.Text;
        }

        private void NotProgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtminval.Text = "0";
            txtmaxval.Text = "1000";
            cmbunit.Text = "Unit";
            txtshname.Text = "Not_Prog";
        }

        //private void Update_Module(int Strt_Pno, int Stop_Pno, String Typ, String Modl, int Mark)
        //{
        //    try
        //    {
        //        int x = 0;

        //        if (Mark == 1)
        //        {
        //            for (x = Strt_Pno; x <= Stop_Pno; x++)
        //            {
        //                switch (Typ)
        //                {
        //                    case "4018 * 8":
        //                        InGrid[2, x].Value = "0";
        //                        InGrid[3, x].Value = "200.0";
        //                        InGrid[4, x].Value = "°C";
        //                        InGrid[5, x].Value = Convert.ToString("T_" + (Modl) + "_" + ((x - Strt_Pno) + 1));
        //                        InGrid[6, x].Value = true;
        //                        break;
        //                    case "4017 * 8":
        //                        InGrid[2, x].Value = "0";
        //                        InGrid[3, x].Value = "10.0";
        //                        InGrid[4, x].Value = "bar";
        //                        InGrid[5, x].Value = Convert.ToString("P_" + (Modl) + "_" + ((x - Strt_Pno) + 1));
        //                        InGrid[6, x].Value = true;
        //                        break;
        //                    case "4015 * 6":
        //                        InGrid[2, x].Value = "0";
        //                        InGrid[3, x].Value = "200.0";
        //                        InGrid[4, x].Value = "°C";
        //                        InGrid[5, x].Value = Convert.ToString("RTD_" + (Modl) + "_" + ((x - Strt_Pno) + 1));
        //                        InGrid[6, x].Value = true;
        //                        break;
        //                }
        //            }
        //            //Load_TreeView(); 
        //        }
        //        else
        //        {
        //            for (x = Strt_Pno; x <= Stop_Pno; x++)
        //            {
        //                InGrid[2, x].Value = "0";
        //                InGrid[3, x].Value = "100.0";
        //                InGrid[4, x].Value = "Unit";
        //                InGrid[5, x].Value = "Not_Prog";
        //                InGrid[6, x].Value = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error in frmconf", ex.Message);
        //    }
        //}


        //private void mnu4018_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        switch (TV.SelectedNode.Text.Substring(7, 1))
        //        {
        //            case "1":
        //                Update_Module(31, 38, "4018 * 8", "1", 1);
        //                break;
        //            case "2":
        //                Update_Module(39, 46, "4018 * 8", "2", 1);
        //                break;
        //            case "3":
        //                Update_Module(47, 54, "4018 * 8", "3", 1);
        //                break;
        //            case "4":
        //                Update_Module(45, 62, "4018 * 8", "4", 1);
        //                break;
        //            case "5":
        //                Update_Module(63, 70, "4018 * 8", "5", 1);
        //                break;
        //        }
        //        //TV.SelectedNode.Text = TV.SelectedNode.Text.Substring(0, 8) + "4018*8";
        //        Adp.Update(ds.Tables[0]);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error in frmconf", ex.Message);
        //    }
        //}

        //private void mnu4017_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //switch (TV.SelectedNode.Text.Substring(7, 1))
        //        {
        //            case "1":
        //                Update_Module(31, 38, "4017 * 8", "1", 1);
        //                break;
        //            case "2":
        //                Update_Module(39, 46, "4017 * 8", "2", 1);
        //                break;
        //            case "3":
        //                Update_Module(47, 54, "4017 * 8", "3", 1);
        //                break;
        //            case "4":
        //                Update_Module(55, 62, "4017 * 8", "4", 1);
        //                break;
        //            case "5":
        //                Update_Module(63, 70, "4017 * 8", "5", 1);
        //                break;
        //        }
        //        TV.SelectedNode.Text = TV.SelectedNode.Text.Substring(0, 8) + ":4017*8";
        //        Adp.Update(ds.Tables[0]);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error in frmconf", ex.Message);
        //    }
        //}

        //private void mnu4015_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        switch (TV.SelectedNode.Text.Substring(7, 1))
        //        {
        //            case "1":
        //                Update_Module(31, 38, "4015 * 6", "1", 1);
        //                break;
        //            case "2":
        //                Update_Module(39, 46, "4015 * 6", "2", 1);
        //                break;
        //            case "3":
        //                Update_Module(47, 54, "4015 * 6", "3", 1);
        //                break;
        //            case "4":
        //                Update_Module(55, 62, "4015 * 6", "4", 1);
        //                break;
        //            case "5":
        //                Update_Module(63, 70, "4015 * 6", "5", 1);
        //                break;
        //        }
        //        TV.SelectedNode.Text = TV.SelectedNode.Text.Substring(0, 8) + ":4015*6";
        //        Adp.Update(ds.Tables[0]);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error in frmconf", ex.Message);
        //    }
        //}

        // private void mnuDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        switch (TV.SelectedNode.Text.Substring(7, 1))
        //        {
        //            case "1":
        //                Update_Module(31, 38, "NONE", "1", 0);
        //                break;
        //            case "2":
        //                Update_Module(39, 46, "NONE", "2", 0);
        //                break;
        //            case "3":
        //                Update_Module(47, 54, "NONE", "3", 0);
        //                break;
        //            case "4":
        //                Update_Module(55, 62, "NONE", "4", 0);
        //                break;
        //            case "5":
        //                Update_Module(63, 70, "NONE", "5", 0);
        //                break;
        //        }
        //        TV.SelectedNode.Text = TV.SelectedNode.Text.Substring(0, 8) + ":NONE";
        //        Adp.Update(ds.Tables[0]);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error in frmconf", ex.Message);
        //    }
        //}

         private void tmrDi_Tick(object sender, EventArgs e)
         {
             try
             {
                 int i = 0;
                 //Global.Rd_DiInPut();
                 for (i = 0; i <= 15; i++)
                 {
                     if (Global.DigIn[i] == 1)
                     {
                         //DGIn[2, i].Style.BackColor = Color.DodgerBlue;
                         //DGIn[2, i].Style.ForeColor = Color.White;
                         DGIn[1, i].Style.BackColor = Color.DodgerBlue;
                         //DGIn[0, i].Style.BackColor = Color.DodgerBlue;

                         DGIn[1, i].Value = 1;
                     }
                     else
                     {
                         //DGIn[2, i].Style.BackColor = Color.White;
                         //DGIn[2, i].Style.ForeColor = Color.DodgerBlue;
                         DGIn[1, i].Style.BackColor = Color.White;
                         //DGIn[0, i].Style.BackColor = Color.White;
                         DGIn[1, i].Value = 0;
                     }
                 }
                 
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error in frmconf" + ex.Message, "Dynalec Controls Pvt Ltd.",
                 MessageBoxButtons.OK, MessageBoxIcon.Error); 
                // MessageBox.Show("Error in frmconf", ex.Message);
                 Global.Create_OnLog(ex.Message, "Alert");
             }
         }        
    
         private void txtmaxval_Leave(object sender, EventArgs e)
         {      
             Double l = Convert.ToDouble(txtmaxval.Text);
             if (l < 10)        txtmaxval.Text = l.ToString("0.000");                
            
             else if (l < 100)  txtmaxval.Text = l.ToString("00.00");
                
             else if (l < 1000) txtmaxval.Text = l.ToString("000.0"); 
           
             else               txtmaxval.Text = l.ToString("0000");               
               
         }


         private void frmConf_Load(object sender, EventArgs e)
         {
             treeView1.ExpandAll();
             treeView2.ExpandAll();
             treeView3.ExpandAll();
             treeView4.ExpandAll(); 

 
             Load_GridDI();
             Load_GridDo();          
         }

         private void btnDISave_Click(object sender, EventArgs e)
         {
             try
             {
                 if (Global.con.State == ConnectionState.Closed) Global.Open_Connection("gen_db", "con");
                 MySqlCommand cmd = new MySqlCommand();
                 cmd.CommandText = "UPDATE TbSys SET " +
                                  "CH1 = '" + DGIn[2, 0].Value.ToString() + "'," +
                                  "CH2 = '" + DGIn[2, 1].Value.ToString() + "'," +
                                  "CH3 = '" + DGIn[2, 2].Value.ToString() + "'," +
                                  "CH4 = '" + DGIn[2, 3].Value.ToString() + "'," +
                                  "CH5 = '" + DGIn[2, 4].Value.ToString() + "'," +
                                  "CH6 = '" + DGIn[2, 5].Value.ToString() + "'," +
                                  "CH7 = '" + DGIn[2, 6].Value.ToString() + "'," +
                                  "CH8 = '" + DGIn[2, 7].Value.ToString() + "'," +
                                  "CH9 = '" + DGIn[2, 8].Value.ToString() + "'," +
                                  "CH10 = '" + DGIn[2, 9].Value.ToString() + "'," +
                                  "CH11 = '" + DGIn[2, 10].Value.ToString() + "'," +
                                  "CH12 = '" + DGIn[2, 11].Value.ToString() + "'," +
                                  "CH13 = '" + DGIn[2, 12].Value.ToString() + "'," +
                                  "CH14 = '" + DGIn[2, 13].Value.ToString() + "'," +
                                  "CH15 = '" + DGIn[2, 14].Value.ToString() + "'," +
                                  "CH16 = '" + DGIn[2, 15].Value.ToString() + "'" +
                                  " WHERE FileName = '03_DigInputs'";
                 cmd.Connection = Global.con;
                 cmd.ExecuteNonQuery();
                 MessageBox.Show("Record Updated", "Dynalec Controls Pvt Ltd.",
                 MessageBoxButtons.OK, MessageBoxIcon.Information); 
                // MessageBox.Show("Record Updated .......");
                 Global.con.Close();  
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error in FrmConf" + ex.Message , "Dynalec Controls Pvt Ltd.",
                 MessageBoxButtons.OK, MessageBoxIcon.Error); 
                 //MessageBox.Show("Error in FrmConf ",ex.Message);
                 Global.Create_OnLog(ex.Message, "Alert");
             }
         }

         private void btnDOSave_Click(object sender, EventArgs e)
         {
             try
             {
                 if (Global.con.State == ConnectionState.Closed) Global.Open_Connection("gen_db", "con");
                 MySqlCommand cmd = new MySqlCommand();
                 cmd.CommandText = "UPDATE TbSys SET " +
                                  "CH1 = '" + DGDo[2, 0].Value.ToString() + "'," +
                                  "CH2 = '" + DGDo[2, 1].Value.ToString() + "'," +
                                  "CH3 = '" + DGDo[2, 2].Value.ToString() + "'," +
                                  "CH4 = '" + DGDo[2, 3].Value.ToString() + "'," +
                                  "CH5 = '" + DGDo[2, 4].Value.ToString() + "'," +
                                  "CH6 = '" + DGDo[2, 5].Value.ToString() + "'," +
                                  "CH7 = '" + DGDo[2, 6].Value.ToString() + "'," +
                                  "CH8 = '" + DGDo[2, 7].Value.ToString() + "'," +
                                  "CH9 = '" + DGDo[2, 8].Value.ToString() + "'," +
                                  "CH10 = '" + DGDo[2, 9].Value.ToString() + "'," +
                                  "CH11 = '" + DGDo[2, 10].Value.ToString() + "'," +
                                  "CH12 = '" + DGDo[2, 11].Value.ToString() + "'," +
                                  "CH13 = '" + DGDo[2, 12].Value.ToString() + "'," +
                                  "CH14 = '" + DGDo[2, 13].Value.ToString() + "'," +
                                  "CH15 = '" + DGDo[2, 14].Value.ToString() + "'," +
                                  "CH16 = '" + DGDo[2, 15].Value.ToString() + "'" +
                                  " WHERE FileName = '04_DigOutputs'";
                 cmd.Connection = Global.con;
                 cmd.ExecuteNonQuery();
                 MessageBox.Show("Record Updated", "Dynalec Controls Pvt Ltd.",
                 MessageBoxButtons.OK, MessageBoxIcon.Information); 
                 MessageBox.Show("Record Updated .......");
                 Global.con.Close();   
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error in FrmConf" + ex.Message, "Dynalec Controls Pvt Ltd.",
                 MessageBoxButtons.OK, MessageBoxIcon.Error); 
                 Global.Create_OnLog(ex.Message, "Alert");
             }
         }     

         private void tbsSetPt2_Click(object sender, EventArgs e)
         {
             groupBox1.SendToBack(); 
             groupBox2.BringToFront();
             groupBox3.Enabled = true;
             groupBox3.Text = "Set Point - 2 ";
             label2.Text = "Current Position : (%)";
             label3.Text = "6 Amps";
             DGDo.Enabled = false;
             btnDOSave.Enabled = false;
             DGIn.Enabled = false;
             btnDISave.Enabled = false;
             DGIn.ForeColor = Color.Gray;
             DGDo.ForeColor = Color.Gray;
             tmrDi.Enabled = true;
             frmMain frm = new frmMain();
             frm.Activate();
             Global.Dig_OutBit(0, 3, true);
             frm.Dispose();
         }

         private void tbsDigIn_Click(object sender, EventArgs e)
         {
             groupBox1.SendToBack();
             groupBox2.BringToFront();
             groupBox3.Enabled = false;
             groupBox3.Text = "Set Point - 1 ";
             DGDo.Enabled = false;
             btnDOSave.Enabled = false;
             DGIn.Enabled = true;
             btnDISave.Enabled = true;
             DGIn.ForeColor = Color.Blue;
             DGDo.ForeColor = Color.Gray;
             tmrDi.Enabled = true;
         }

         private void tbsDigOut_Click(object sender, EventArgs e)
         {
             groupBox1.SendToBack();
             groupBox2.BringToFront();
             groupBox3.Enabled = false;
             groupBox3.Text = "Set Point - 1 ";
             DGDo.Enabled = true;
             btnDOSave.Enabled = true;
             DGIn.Enabled = false;
             btnDISave.Enabled = false;
             DGIn.ForeColor = Color.Gray;
             DGDo.ForeColor = Color.Blue;
             tmrDi.Enabled = true;
         }

         private void tbsSerial_Click(object sender, EventArgs e)
         {
             groupBox2.SendToBack();
             groupBox1.BringToFront();
             btnDISave.Enabled = false;
             btnDOSave.Enabled = false;
             Load_DataGrid(0, 30);
             DgModule.Visible = false; 
         }

         private void tbsMD01_Click(object sender, EventArgs e)
         {            
             groupBox2.SendToBack();
             groupBox1.BringToFront();
             btnDISave.Enabled = false;
             btnDOSave.Enabled = false;
             Load_DataGrid(31, 38);
             DgModule.Visible = true;
             DgModule.Rows[0].Selected = true;
         }

         private void tbsMD02_Click(object sender, EventArgs e)
         {
             groupBox2.SendToBack();
             groupBox1.BringToFront();
             btnDISave.Enabled = false;
             btnDOSave.Enabled = false;
             Load_DataGrid(39, 46);
             DgModule.Visible = true;
             Show_Modules();
             DgModule.Rows[1].Selected = true;

         }

         private void tbsMD03_Click(object sender, EventArgs e)
         {
             groupBox2.SendToBack();
             groupBox1.BringToFront();
             btnDISave.Enabled = false;
             btnDOSave.Enabled = false;
             Load_DataGrid(47, 54);
             Show_Modules();
             DgModule.Visible = true;
             DgModule.Rows[2].Selected = true;
         }

         private void tbsMD04_Click(object sender, EventArgs e)
         {
             groupBox2.SendToBack();
             groupBox1.BringToFront();
             btnDISave.Enabled = false;
             btnDOSave.Enabled = false;
             Load_DataGrid(55, 62);
             DgModule.Visible = true;
             Show_Modules();
             DgModule.Rows[3].Selected = true;
         }

         private void tbsMD05_Click(object sender, EventArgs e)
         {
             groupBox2.SendToBack();
             groupBox1.BringToFront();
             btnDISave.Enabled = false;
             btnDOSave.Enabled = false;
             Load_DataGrid(63, 70);
             Show_Modules();
             DgModule.Visible = true;
             DgModule.Rows[4].Selected = true;
         }
         private void tbsModbus_Click(object sender, EventArgs e)
         {
             groupBox2.SendToBack();
             groupBox1.BringToFront();
             btnDISave.Enabled = false;
             btnDOSave.Enabled = false;
             Load_DataGrid(87, 90);
             Show_Modules();
             DgModule.Visible = false;
         }
         private void tbsDig_Click(object sender, EventArgs e)
         {
             groupBox1.SendToBack();
             groupBox2.BringToFront();
         }

      
         private void tbsClose_Click(object sender, EventArgs e)
         {
             Global.flg_Log_service = false;
             this.Close();          
         }

         private void tbsAdam_Click(object sender, EventArgs e)
         {
             Show_Modules(); 
             DgModule.Visible = true;
         }

         private void tbsAnalog_Click(object sender, EventArgs e)
         {
             groupBox2.SendToBack();
             groupBox1.BringToFront();
             btnDISave.Enabled = false;
             btnDOSave.Enabled = false;
             Load_DataGrid(71, 86);
             Show_Modules();
             DgModule.Visible = false;
         }

         private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
         {
             groupBox1.SendToBack();
             groupBox2.BringToFront();
             NodeT = treeView1.SelectedNode.Text;
             if (NodeT == "SetPoint - 1")
             {
                 groupBox1.SendToBack();
                 groupBox2.BringToFront();
                 groupBox3.Enabled = true;
                 groupBox3.Text = "Set Point - 1 ";
                 label2.Text = "Throttle Position : (%)";
                 label3.Text = "100 %";
                 DGDo.Enabled = false;
                 btnDOSave.Enabled = false;
                 DGIn.Enabled = false;
                 btnDISave.Enabled = false;
                 DGIn.ForeColor = Color.Gray;
                 DGDo.ForeColor = Color.Gray;
                 tmrDi.Enabled = true;
                 frmMain frm = new frmMain();
                 frm.Activate();
                 Global.Dig_OutBit(0, 3, true);
                 frm.Dispose();
             }
             else if (NodeT == "SetPoint - 2")
             {
                 groupBox1.SendToBack();
                 groupBox2.BringToFront();
                 groupBox3.Enabled = true;
                 groupBox3.Text = "Set Point - 2 ";
                 label2.Text = "Current Position : (%)";
                 label3.Text = "6 Amp";
                 DGDo.Enabled = false;
                 btnDOSave.Enabled = false;
                 DGIn.Enabled = false;
                 btnDISave.Enabled = false;
                 DGIn.ForeColor = Color.Gray;
                 DGDo.ForeColor = Color.Gray;
                 tmrDi.Enabled = true;
                 frmMain frm = new frmMain();
                 frm.Activate();
                 Global.Dig_OutBit(0, 3, true);
                 frm.Dispose();
             }
             else
             {
                 groupBox1.SendToBack();
                 groupBox2.BringToFront();
             }
         }

         private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
         {
             groupBox1.SendToBack();
             groupBox2.BringToFront();
             NodeT = treeView2.SelectedNode.Text;
             if (NodeT == "Digital Inputs")
             {
                 groupBox1.SendToBack();
                 groupBox2.BringToFront();
                 groupBox3.Enabled = false;
                 groupBox3.Text = "Set Point - 1 ";
                 DGDo.Enabled = false;
                 btnDOSave.Enabled = false;
                 DGIn.Enabled = true;
                 btnDISave.Enabled = true;
                 DGIn.ForeColor = Color.Blue;
                 DGDo.ForeColor = Color.Gray;
                 tmrDi.Enabled = true;
             }
             else if (NodeT == "Digital Outputs")
             {
                 groupBox1.SendToBack();
                 groupBox2.BringToFront();
                 groupBox3.Enabled = false;
                 groupBox3.Text = "Set Point - 1 ";
                 DGDo.Enabled = true;
                 btnDOSave.Enabled = true;
                 DGIn.Enabled = false;
                 btnDISave.Enabled = false;
                 DGIn.ForeColor = Color.Gray;
                 DGDo.ForeColor = Color.Blue;
                 tmrDi.Enabled = true;

             }
             else
             {
                 groupBox1.SendToBack();
                 groupBox2.BringToFront();
             }
         }
         //private void Load_Arr()
         //{
         //    int i = 0;
         //    ArrNo[0] = lno1;
         //    ArrNo[1] = lno2;
         //    ArrNo[2] = lno3;
         //    ArrNo[3] = lno4;
         //    ArrNo[4] = lno5;
         //    ArrNo[5] = lno6;
         //    ArrNo[6] = lno7;
         //    ArrNo[7] = lno8;
         //    ArrNo[8] = lno9;
         //    ArrNo[9] = lno10;
         //    ArrNo[10] = lno11;

         //    for (i = 0; i <= 10; i++)
         //    {
         //        ArrNo[i].Text = (20 * i).ToString();
         //    }
         //}
         //private void LoadIn_Array()
         //{
         //    if (chn >= 0 && chn <= 20) flg_Serial = true; else flg_Serial = false;
         //    if (chn >= 21 && chn <= 60) flg_Adam = true; else flg_Adam = false;

         //    Double l = Convert.ToDouble(Global.PMax[chn]);
         //    Double m = Math.Abs(Convert.ToDouble(Global.PMin[chn]));
         //    Double n = Convert.ToDouble(Global.GenData[chn]);
         //    Double d = Convert.ToDouble(Global.PMin[chn]);

         //    //DGView[0, 0].Value = label19.Text;
         //    for (int i = 0; i <= 10; i++)
         //    {
         //        if (Global.PMax[chn].Substring(1, 1) == ".")
         //            ArrNo[i].Text = ((((l - d) / 10) * i) + d).ToString("0.000");    //10                 
         //        else if (Global.PMax[chn].Substring(2, 1) == ".")                   //
         //            ArrNo[i].Text = ((((l - d) / 10) * i) + d).ToString("00.00");
         //        else if (Global.PMax[chn].Substring(3, 1) == ".")
         //            ArrNo[i].Text = ((((l - d) / 10) * i) + d).ToString("000.0");  //10                  
         //        else
         //            ArrNo[i].Text = ((((l - d) / 10) * i) + d).ToString("0000"); //10

         //        //DGView[0, i + 1].Value = ArrNo[i].Text;
         //    }
         //}

         private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
         {
             groupBox2.SendToBack();
             groupBox1.BringToFront();
             btnDISave.Enabled = false;
             btnDOSave.Enabled = false;
             //Load_Arr();
             Load_DataGrid(0, 20);
             Show_Modules();
             DgModule.Visible = false;
             NodeT = treeView3.SelectedNode.Text;           
             switch (NodeT)
             {
                 case "Channel Inputs":
                     {
                         groupBox2.SendToBack();
                         groupBox1.BringToFront();
                         btnDISave.Enabled = false;
                         btnDOSave.Enabled = false;
                         Load_DataGrid(0, 20);
                         Show_Modules();
                         DgModule.Visible = false;
                         break;
                     }
                 case "Serial Inputs":
                     {
                         groupBox2.SendToBack();
                         groupBox1.BringToFront();
                         btnDISave.Enabled = false;
                         btnDOSave.Enabled = false;
                         Load_DataGrid(0, 20);
                         Show_Modules();
                         DgModule.Visible = false;
                         break;
                     }
                 case "Module Inputs":
                     {
                         groupBox2.SendToBack();
                         groupBox1.BringToFront();
                         btnDISave.Enabled = false;
                         btnDOSave.Enabled = false;
                         Load_DataGrid(21, 28);
                         DgModule.Visible = true;
                         Show_Modules();
                         DgModule.Rows[0].Selected = true;                        
                         DgModule.Visible = true;
                         break;
                     }
                 case "ADAM-MODULE : 01":				
					 {
                         groupBox2.SendToBack();
                         groupBox1.BringToFront();
                         btnDISave.Enabled = false;
                         btnDOSave.Enabled = false;
                         Load_DataGrid(21, 28);
                         DgModule.Visible = true;
                         Show_Modules();
                         DgModule.Rows[0].Selected = true;                         
                         DgModule.Visible = true;
                         break;
                     }
                 case "ADAM-MODULE : 02":
                     {
                         groupBox2.SendToBack();
                         groupBox1.BringToFront();
                         btnDISave.Enabled = false;
                         btnDOSave.Enabled = false;
                         Load_DataGrid(29, 36);
                         DgModule.Visible = true;
                         Show_Modules();
                         DgModule.Rows[1].Selected = true;                         
                         DgModule.Visible = true;
                         break;
                     }
                 case "ADAM-MODULE : 03":
                     {
                         groupBox2.SendToBack();
                         groupBox1.BringToFront();
                         btnDISave.Enabled = false;
                         btnDOSave.Enabled = false;
                         Load_DataGrid(37, 44);
                         DgModule.Visible = true;
                         Show_Modules();
                         DgModule.Rows[2].Selected = true;                        
                         DgModule.Visible = true;
                         break;
                     }
                 case "ADAM-MODULE : 04":
                     {
                         groupBox2.SendToBack();
                         groupBox1.BringToFront();
                         btnDISave.Enabled = false;
                         btnDOSave.Enabled = false;
                         Load_DataGrid(45, 52);
                         DgModule.Visible = true;
                         Show_Modules();
                         DgModule.Rows[3].Selected = true;                         
                         DgModule.Visible = true;
                         break;
                     }
                 case "ADAM-MODULE : 05":
                     {
                         groupBox2.SendToBack();
                         groupBox1.BringToFront();
                         btnDISave.Enabled = false;
                         btnDOSave.Enabled = false;
                         Load_DataGrid(53, 60);
                         DgModule.Visible = true;
                         Show_Modules();
                         DgModule.Rows[4].Selected = true;                         
                         DgModule.Visible = true;
                         break;
                     }
                 case "Analog Inputs":
                     {
                         groupBox2.SendToBack();
                         groupBox1.BringToFront();
                         btnDISave.Enabled = false;
                         btnDOSave.Enabled = false;
                         Load_DataGrid(61, 68);
                         DgModule.Visible = false;
                         break;
                     }
                 case "Modbus Inputs":
                     {
                         groupBox2.SendToBack();
                         groupBox1.BringToFront();
                         btnDISave.Enabled = false;
                         btnDOSave.Enabled = false;
                         Load_DataGrid(69, 74);
                         DgModule.Visible = false;
                         break;
                     }
             }
         }

         private void button2_Click(object sender, EventArgs e)
         {
             Global.flg_Log_service = false;
             this.Close(); 
         }

         private void trackBar1_Scroll(object sender, EventArgs e)
         {
             textBox1.Text = trackBar1.Value.ToString();    
         }

         private void DGDo_CellClick(object sender, DataGridViewCellEventArgs e)
         {
             int port = 0;
             int c = DGDo.CurrentRow.Index;
             if (c >= 8) port = 1; else port = 0;

             if (Convert.ToBoolean(DGDo[1, c].Value) == true)
             {
                 DGDo[1, c].Value = 0;
                 Global.Dig_OutBit(port, c, false);
             }
             else
             {
                 DGDo[1, c].Value = 1;
                 Global.Dig_OutBit(port, c, true);
             }
             //if (DGDo[1, c].Value == "0")
             //{
             //    //DGDo[2, c].Style.BackColor = Color.White; ;
             //    //DGDo[2, c].Style.ForeColor = Color.DodgerBlue;
             //}
             //else
             //{
             //    DGDo[2, c].Style.BackColor = Color.DodgerBlue;
             //    DGDo[2, c].Style.ForeColor = Color.White;
             //}
            
         }

         private void textBox1_TextChanged(object sender, EventArgs e)
         {
             try
             {
                 frmMain frm = new frmMain();
                 frm.Activate();
                 Global.Dig_OutBit(0, 3, true);


                 if (label2.Text == "Throttle Position : (%)")
                 {
                     Global.AnaOut1 = (Double.Parse(textBox1.Text) / 10);
                     frm.Tss6.Text = Global.AnaOut1.ToString("0.000");                     
                 }
                 else
                 {
                     Global.AnaOut2 = (Double.Parse(textBox1.Text) / 10);
                     frm.Tss7.Text = Global.AnaOut2.ToString("0.000");                     
                 }
                 frm.Dispose();

             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error in FrmConf" + ex.Message, "Dynalec Controls Pvt Ltd.",
                 MessageBoxButtons.OK, MessageBoxIcon.Error); 
                // MessageBox.Show("Error in frmConf:" + ex.Message);
                 Global.Create_OnLog(ex.Message, "Alert");
             }
         }

        private void InGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDISave.Enabled = false;
            btnDOSave.Enabled = false;
           
            Load_Incell();
            tmrDigIn.Start(); 
        }
        private void Load_Incell()
        {
            Rn = InGrid.CurrentRow.Index;
            if (Global.con.State == ConnectionState.Closed) Global.Open_Connection("gen_db", "con");
             String strQuery = "select * from Tb_Std where ParameterNo = " + Rn;
             MySqlDataAdapter adp = new MySqlDataAdapter(strQuery, Global.con);
             DataSet ds = new DataSet();
             adp.Fill(ds);
             String St;
             //String l = Convert.ToString(sn);
             chn = int.Parse(InGrid.Rows[Rn].Cells[0].Value.ToString()); 
             txtchno.Text = Rn.ToString();
             
             txtparaname.Text = InGrid.Rows[Rn].Cells[1].Value.ToString();
             txtminval.Text = InGrid.Rows[Rn].Cells[2].Value.ToString();

             txtmaxval.Text = InGrid.Rows[Rn].Cells[3].Value.ToString();
             cmbunit.Text = InGrid.Rows[Rn].Cells[4].Value.ToString();
             txtshname.Text = InGrid.Rows[Rn].Cells[5].Value.ToString();
             St = ds.Tables[0].Rows[0].ItemArray[6].ToString();

             if (St == "True")
             {
                 CheckBox1.Checked = true;
                 CheckBox1.Text = "Selected";
             }
             else
             {
                 CheckBox1.Checked = false;
                 CheckBox1.Text = "Not Selected";
             }
             Global.con.Close();
             //label26.Text = Global.PSName[chn] + "    (" + Global.PUnit[chn] + ")";
         }

         private void btnAdd_Click(object sender, EventArgs e)
         {
             Save_Para();
             Global.Rd_Confg();  
         }

        private void InGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnDISave.Enabled = false;
            btnDOSave.Enabled = false;
           
           Load_Incell();
           //LoadIn_Array();
           //Load_DgView();                     
        }
        //private void Load_DgView()
        //{
        //    DGView.RowCount = 2;
        //    DGView[0, 0].Value = "Actual reading";
        //    DGView[0, 1].Value = "Observed reading";

        //    if (Rn >= 0 && Rn <= 20) flg_Serial = true; else flg_Serial = false;
        //    if (Rn >= 21 && Rn <= 60) flg_Adam = true; else flg_Adam = false;

        //    Double l = Convert.ToDouble(Global.PMax[Rn]);
        //    Double m = Math.Abs(Convert.ToDouble(Global.PMin[Rn]));
        //    Double n = Convert.ToDouble(Global.GenData[Rn]);
        //    Double d = Convert.ToDouble(Global.PMin[Rn]);

        //    //DGView[0, 0].Value = label19.Text;
        //    for (int i = 0; i <= 10; i++)
        //    {
        //        if (Global.PMax[Rn].Substring(1, 1) == ".")
        //            ArrNo[i].Text = ((((l - d) / 10) * i) + d).ToString("0.000");    //10                 
        //        else if (Global.PMax[Rn].Substring(2, 1) == ".")                   //
        //            ArrNo[i].Text = ((((l - d) / 10) * i) + d).ToString("00.00");
        //        else if (Global.PMax[Rn].Substring(3, 1) == ".")
        //            ArrNo[i].Text = ((((l - d) / 10) * i) + d).ToString("000.0");  //10                  
        //        else
        //            ArrNo[i].Text = ((((l - d) / 10) * i) + d).ToString("0000"); //10

        //        DGView[i+1 ,0 ].Value = ArrNo[i].Text;
        //    }


        //}
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNa_Click(object sender, EventArgs e)
        {
            textBox3.Text = "0";
            textBox4.Text = "10";
            txtminval.Text = "0";
            txtmaxval.Text = "1000";
            txtshname.Text = "Not_Prog";
            cmbunit.Text = "Unit";
            CheckBox1.Checked = false; 
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }


        private void Load_InECUcell()
        {
            EcuRn = dataGridView2.CurrentRow.Index;
            if (Global.con.State == ConnectionState.Closed) Global.Open_Connection("gen_db", "con");
            String strQuery = "select * from tb_ecu where ParameterNo = " + EcuRn;
            MySqlDataAdapter adp = new MySqlDataAdapter(strQuery, Global.con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            String St;

            Echn = int.Parse(dataGridView2.Rows[EcuRn].Cells[0].Value.ToString());
            textBox10.Text = EcuRn.ToString();

            textBox9.Text = dataGridView2.Rows[EcuRn].Cells[1].Value.ToString();
            textBox2.Text = dataGridView2.Rows[EcuRn].Cells[2].Value.ToString();
            textBox8.Text = dataGridView2.Rows[EcuRn].Cells[3].Value.ToString();
            cmbEUnit.Text = dataGridView2.Rows[EcuRn].Cells[4].Value.ToString();
            textBox6.Text = dataGridView2.Rows[EcuRn].Cells[5].Value.ToString();           
            textBox5.Text = dataGridView2.Rows[EcuRn].Cells[7].Value.ToString();
            St = ds.Tables[0].Rows[0].ItemArray[6].ToString();

            if (St == "True")
            {
                checkBox2.Checked = true;
                checkBox2.Text = "Selected";
            }
            else
            {
                checkBox2.Checked = false;
                checkBox2.Text = "Not Selected";
            }
            Global.con.Close();
        }

        private void Load_InECUGrid()
        {
            groupBox4.BringToFront();
            dataGridView2.RowCount = 56;
            Global.Rd_ECU_Confg();
            for (int x = 0; x <= 55; x++)
            {
                dataGridView2[0, x].Value = Global.EcuNo[x];
                dataGridView2[1, x].Value = Global.EcuName[x];
                dataGridView2[2, x].Value = Global.EcuAdds[x];
                dataGridView2[3, x].Value = Global.EcuMFa[x];
                dataGridView2[4, x].Value = Global.EcuUnit[x];
                dataGridView2[5, x].Value = Global.EcuSName[x];
                dataGridView2[6, x].Value = Global.EcuMark[x];
                dataGridView2[7, x].Value = Global.EcuMin[x];
                dataGridView2[8, x].Value = Global.EcuMax[x];
                ////x += 1;
            }


        }


        private void treeView4_AfterSelect(object sender, TreeViewEventArgs e)
        {
            groupBox4.BringToFront();
            dataGridView2.RowCount = 56;
            Global.Rd_ECU_Confg(); 
            for (int x = 0; x <= 55; x++)
            {
                dataGridView2[0, x].Value = Global.EcuNo[x];
                dataGridView2[1, x].Value = Global.EcuName[x];
                dataGridView2[2, x].Value = Global.EcuAdds[x];
                dataGridView2[3, x].Value = Global.EcuMFa[x]; 
                dataGridView2[4, x].Value = Global.EcuUnit[x];
                dataGridView2[5, x].Value = Global.EcuSName[x];
                dataGridView2[6, x].Value = Global.EcuMark[x];
                dataGridView2[7, x].Value = Global.EcuMin[x];
                dataGridView2[8, x].Value = Global.EcuMax[x];               
            }               
            Global.Create_OnLog("tb_ecu Opened....", "Normal");            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Load_InECUcell();
            
  
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Load_InECUcell();            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Save_ECUPara();            
            Load_InECUGrid(); 

        }

       private void Save_ECUPara()
        {
            try
            {
                int ERn = int.Parse(textBox10.Text);
                Echn = int.Parse(dataGridView2.Rows[ERn].Cells[0].Value.ToString());
                Double l = Convert.ToDouble(textBox7.Text);
                if (l < 10) textBox7.Text = l.ToString("0.000");
                else if (l < 100) textBox7.Text = l.ToString("00.00");
                else if (l < 1000) textBox7.Text = l.ToString("000.0");
                else textBox7.Text = l.ToString("0000");
                dataGridView2.Rows[Rn].Cells[2].Value = textBox2.Text;
                dataGridView2.Rows[Rn].Cells[3].Value = textBox8.Text;
                dataGridView2.Rows[Rn].Cells[4].Value = cmbEUnit.Text;
                dataGridView2.Rows[Rn].Cells[5].Value = textBox6.Text;
                if (checkBox2.Checked == true) dataGridView2.Rows[Rn].Cells[6].Value = true; else dataGridView2.Rows[Rn].Cells[6].Value = false;
                dataGridView2.Rows[Rn].Cells[7].Value = textBox5.Text;   //textBox3.Text;
                dataGridView2.Rows[Rn].Cells[8].Value = textBox7.Text;  //textBox4.Text;

                if (Global.con.State == ConnectionState.Closed) Global.Open_Connection("gen_db", "con");
                MySqlCommand ccd = new MySqlCommand("UPDATE tb_ecu SET " +
                     "ParameterName = '" + textBox9.Text + "'," +
                     "Addresshex = '" + textBox2.Text + "'," +
                     "MultFactor = '" + textBox8.Text + "'," +
                     "Unit= '" + cmbEUnit.Text + "'," +
                     "ShortName = '" + textBox6.Text + "'," +
                     "Minip = '" + textBox5.Text + "'," +
                     "Maxip = '" + textBox7.Text + "'," +
                     "Marked = " + (dataGridView2.Rows[Rn].Cells[6].Value.ToString()) + " WHERE ParameterNo =" + Echn, Global.con);
                ccd.ExecuteNonQuery();
                Global.con.Close();
                MessageBox.Show("Updated", "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                // MessageBox.Show("UPDAT"); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmconf " + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Error in frmconf", ex.Message);
                Global.Create_OnLog(ex.Message, "Alert");
            }      
           


        }

       
		
	}
       
}
