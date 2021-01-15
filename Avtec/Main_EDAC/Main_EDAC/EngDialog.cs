using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb; 
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace Logger
{
    public partial class EngDialog : Form
    {
        private Boolean f_Found = false;

        public static String buff_barcode = "";

        private frmMain main = new frmMain();

        public EngDialog(frmMain main)
        {
            InitializeComponent();
            this.main = main;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Global.flg_prjOn = true; 
            this.Close();
        }
        private void EngDialog_Load(object sender, EventArgs e)
        {
            try
            
            {
                //Sn = 0;               


                TextBox1.Text = String.Empty;
                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM TbSys WHERE FileName = '05_EngNo'", Global.con);
                MySqlDataReader Rd1 = cmd1.ExecuteReader();

                while (Rd1.Read())
                {

                    TextBox1.Text = DateTime.Now.ToString("dd_MM_yyyy"); //Rd1.GetValue(1).ToString();
                    TextBox2.Text = Rd1.GetValue(2).ToString();
                    TextBox3.Text = Rd1.GetValue(3).ToString();
                    TextBox4.Text = Rd1.GetValue(4).ToString();
                    TextBox5.Text = Rd1.GetValue(5).ToString();
                    TextBox6.Text = Rd1.GetValue(6).ToString();
                    PrjCombo.Text = Rd1.GetValue(7).ToString();
                   

                    
                    if (Rd1.GetValue(9).ToString() == "True") checkBox1.CheckState = CheckState.Checked; else checkBox1.CheckState = CheckState.Unchecked;
                    if (Rd1.GetValue(10).ToString() == "True") checkBox2.CheckState = CheckState.Checked; else checkBox2.CheckState = CheckState.Unchecked;
                    if (Rd1.GetValue(11).ToString() == "True") checkBox3.CheckState = CheckState.Checked; else checkBox3.CheckState = CheckState.Unchecked;
                    if (Rd1.GetValue(12).ToString() == "True") checkBox4.CheckState = CheckState.Checked; else checkBox4.CheckState = CheckState.Unchecked;
                    if (Rd1.GetValue(13).ToString() == "True") checkBox5.CheckState = CheckState.Checked; else checkBox5.CheckState = CheckState.Unchecked;

                    if (Rd1.GetValue(14).ToString() == "True") rd_New.Checked = true;  else rd_New.Checked = false;
                    if (Rd1.GetValue(15).ToString() == "True") rd_Last.Checked = true; else rd_Last.Checked = false;

                    TextBox7.Text = Rd1.GetValue(16).ToString();
                    txtInj2.Text = Rd1.GetValue(17).ToString();
                    txtInj3.Text = Rd1.GetValue(18).ToString();
                    txtInj4.Text = Rd1.GetValue(19).ToString();


                    TextBox9.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    string ST = (Global.sysIn[10]);
                    long Mn = (Convert.ToInt32(ST.Substring(0, 1)) * 60) + Convert.ToInt32(ST.Substring(2));
                    long Tm;
                    Tm = (Convert.ToInt16(DateTime.Now.Hour.ToString()) * 60) + Convert.ToInt16(DateTime.Now.Minute.ToString());

                    if ((Tm > Mn) && (Tm <= (Mn + 480))) TextBox10.Text = "A";
                    else if ((Tm > (Mn + 480)) && (Tm <= (Mn + 960))) TextBox10.Text = "B";
                    else TextBox10.Text = "C";


                }
                Global.con.Close();
                Fill_Combo();
             
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error - 1001" + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //MessageBox.Show("Error - 1001",ex.Message); 
            }
        }

        private void Fill_Combo()
        {
            try
            {
                //Sn = 0;
                //PrjCombo.Enabled = true;
                PrjCombo.Items.Clear();
                PrjCombo.BackColor = Color.Green;
                PrjCombo.ForeColor = Color.Yellow;
                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblProject", Global.con);
                MySqlDataReader Rd = cmd.ExecuteReader();
                while (Rd.Read())
                {
                    PrjCombo.Items.Add(Rd.GetValue(0).ToString());
                }
                Global.con.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in EngDialog: Fill_Combo:" + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
               // MessageBox.Show("Error in EngDialog: Fill_Combo:  " + ex.Message);
            }
        }

        private void CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
          
                if (checkBox1.CheckState == CheckState.Checked)
                {
                    checkBox1.CheckState = CheckState.Checked;                   
                }
                else
                {
                    checkBox1.CheckState = CheckState.Unchecked;                   
                }
           
           
        }


		//private void Read_Project()
		//{
		//    try
		//    {
		//        Global.Open_Connection("gen_db", "con");
		//        MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblProject Where ProjectFile = '" + Global.PrjNm + "'", Global.con);
		//        MySqlDataReader Rd = cmd.ExecuteReader();
		//        while (Rd.Read())
		//        {
		//            frmMain.Prj[0] = Rd.GetValue(0).ToString();
		//            frmMain.Prj[1] = Rd.GetValue(1).ToString();
		//            frmMain.Prj[2] = Rd.GetValue(2).ToString();
		//            //frmMain.Prj[3] = Rd.GetValue(3).ToString();
		//            frmMain.Prj[4] = Rd.GetValue(4).ToString();
		//            Global.NCyl = Rd.GetValue(4).ToString();
		//            frmMain.Prj[5] = Rd.GetValue(5).ToString();
		//            frmMain.Prj[6] = Rd.GetValue(6).ToString();
		//            Global.EngMd = frmMain.Prj[6].Trim();
		//        }
		//        Global.con.Close();
		//    }
		//    catch (Exception ex)
		//    {
		//        MessageBox.Show("Error in Rd_Project : ", ex.Message);
		//        Global.Create_OnLog(ex.Message);
		//    }

		//}

		//private void Check_File_Validation()
		//{
		//    try
		//    {

		//        if (Global.EngNo == String.Empty)
		//            MessageBox.Show("Engine No. Not Entered ......., ");
		//        else
		//        {
		//            Global.Open_Connection("gen_db", "con");
		//            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblProject WHERE ProjectFile = '" + Global.PrjNm + "'", Global.con);
		//            MySqlDataReader Rd = cmd.ExecuteReader();
		//            int x = 0;
		//            while (Rd.Read())
		//            {
		//                for (x = 0; x < (Rd.FieldCount - 1); x++) Global.Prj[x] = Rd.GetValue(x).ToString();
		//            }

		//            Global.cumhours = "0000.00.00";
		//            Global.TestTyp = Global.Prj[5];
		//            Global.Open_Connection("gen_db", "con");
		//            MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM tblEngine", Global.con);
		//            MySqlDataReader Rd1 = cmd1.ExecuteReader();
		//            x = 0;
		//            while (Rd1.Read())
		//            {
		//                if (Global.Prj[1] == Rd1.GetValue(0).ToString())
		//                {
		//                    f_Found = true;
		//                    break;
		//                }
		//                x += 1;
		//            }
		//            if (f_Found == false)
		//            {
		//                MessageBox.Show("Engine File  Not Found ....... ");
		//                return;
		//            }
		//            Global.con.Close(); 
		//            //  **************************
		//            Global.Open_Connection("lim_db", "conLim");
		//            DataTable dt = Global.conLim.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
		//            for (int i = 0; i < dt.Rows.Count; i++)
		//            {
		//                if (Global.Prj[3] == dt.Rows[i]["TABLE_NAME"].ToString())
		//                {
		//                    f_Found = true;
		//                    break;
		//                }
		//                x += 1;
		//            }
		//            if (f_Found == false)
		//            {
		//                MessageBox.Show("Limit File  Not Found ....... ");
		//                return;
		//            }
		//            //    **************************

		//            Global.Open_Connection("Sequence", "conSeq");
		//            dt = Global.conSeq.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
		//            for (int i = 0; i < dt.Rows.Count; i++)
		//            {
		//                if (Global.Prj[2] == dt.Rows[i]["TABLE_NAME"].ToString())
		//                {
		//                    f_Found = true;
		//                    break;
		//                }
		//                x += 1;
		//            }
		//            if (f_Found == false)
		//            {
		//                MessageBox.Show("Sequence File  Not Found ....... ");
		//                return;
		//            }
		//            //     **************************

		//        }
		//    }
		//    catch (Exception ex)
		//    {
		//        MessageBox.Show("Error in Check File validation:" + ex.Message);
		//    }

		//}

		private void Check_File_Validation()
		{
			try
			{

                if (Global.EngNo == String.Empty)
                    MessageBox.Show("Engine No. Not Entered", "Dynalec Controls Pvt Ltd.",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
					//MessageBox.Show("Engine No. Not Entered ......., ");
				else
				{
                    Global.Open_Connection("gen_db", "con");
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblProject WHERE ProjectFile = '" + Global.PrjNm + "'", Global.con);
					MySqlDataReader Rd = cmd.ExecuteReader();
					int x = 0;
					while (Rd.Read())
					{
                        for (x = 0; x < (Rd.FieldCount - 1); x++) Global.Prj[x] = Rd.GetValue(x).ToString();
					}


                    Global.TestTyp = Global.Prj[5];
                    if (Global.TestTyp == "ENDURANCE")

                        clsFun.cummbuff = Global.Prj[14];
                    else

                    Global.cumhours = "0000.00.00";
                    Global.S_Rpm = int.Parse(Global.Prj[12]);
                    Global.Open_Connection("gen_db", "con");
                    MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM tblEngine", Global.con);
					MySqlDataReader Rd1 = cmd1.ExecuteReader();
					x = 0;
					while (Rd1.Read())
					{
                        if (Global.Prj[1] == Rd1.GetValue(0).ToString())
						{
							f_Found = true;
							break;
						}
						x += 1;
						Rd1.Close();

					}
					if (f_Found == false)
					{
                        MessageBox.Show("Engine File Not Found ", "Dynalec Controls Pvt Ltd.",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
						//MessageBox.Show("Engine File  Not Found ....... ");
						return;
					}
                    Global.con.Close();
					//  **************************
                    //x = 0;
                    //Global.Open_Connection("lim_db", "conLim");
                    //MySqlCommand cmd2 = new MySqlCommand("SELECT TABLE_NAME FROM lim_db.INFORMATION_SCHEMA.TABLES", Global.conLim);
                    //using (MySqlDataReader reader = cmd2.ExecuteReader())
                    //{
                    //    if (Global.Prj[3] == ((string)reader["TABLE_NAME"]))
                    //    {
                    //        f_Found = true;
                    //    }
                    //    x += 1;
                    //    reader.Close();
                    //}
                    //if (f_Found == false)
                    //{
                    //    MessageBox.Show("Limit File  Not Found ....... ");
                    //    return;
                    //}

                    //cmd2.Dispose();
                    //Global.conLim.Close();
					//********************************** 
					x = 0;
                    //Global.Open_Connection("seq_db", "conSeq");
                 
                    //MySqlCommand cmd3 = new MySqlCommand("SELECT * FROM tbsys", Global.con);
                    //MySqlDataReader reader = cmd3.ExecuteReader();
                    //x = 0;
                    //while (reader.Read())
                    //{
                    //    if (Global.Prj[2] == reader.GetValue(0).ToString())
                    //    {
                    //        f_Found = true;
                    //        break;
                    //    }
                    //    x += 1;
                    //    reader.Close();

                    //}
                    Global.Open_Connection("seq_db", "conSeq");
                    MySqlCommand cmd3 = new MySqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='seq_db'", Global.conSeq);
                    MySqlDataReader reader = cmd3.ExecuteReader();
                       while(reader.Read())
                    {
                        if (Global.Prj[2] == ((string)reader["TABLE_NAME"]))
                        {
                            f_Found = true;
                        }
                        x += 1;
                    
                    }
                         reader.Close();
                    cmd3.Dispose();
                    Global.conSeq.Close();
					if (f_Found == false)
					{
                        MessageBox.Show("Sequence File  Not Found", "Dynalec Controls Pvt Ltd.",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
						//MessageBox.Show("Sequence File  Not Found ....... ");
						return;
					}
				
				}
			}
	   
            catch (Exception ex)
			{
                Global.Create_OnLog(ex.Message + " :  Check Validation EngDialog....", "False"); 
			}

		}



		private void btnMSave_Click(object sender, EventArgs e)
       {
           try
           {
               Global.JobOrdNo = "***";
               Process[] prs = Process.GetProcesses();
               foreach (Process pr in prs)
               {
                   //if (pr.ProcessName == "ModbusPollCS") pr.Kill();
                   if (pr.ProcessName == "Editors") pr.Kill();
                   if (pr.ProcessName == "Dataappliacation") pr.Kill();
               }
               Erp1.Clear();
 
               if (TextBox1.Text == String.Empty) // "")
               {
                   Erp1.SetError(TextBox1, "Please Type Engine No.....");
                   MessageBox.Show("Please type Engine no.", "Dynalec Controls Pvt Ltd.",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   //MessageBox.Show("Please Type Engine No. ...... ");
                   TextBox1.Focus();
               }
               else if (PrjCombo.Text == String.Empty)
               {
                   Erp1.SetError(PrjCombo, "Please Select Project.....");
                   MessageBox.Show("Please Select Project.", "Dynalec Controls Pvt Ltd.",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   //MessageBox.Show("Please Select Project. ...... ");
                   PrjCombo.Focus();
               }              
               else
               {

                   Global.EngNo = TextBox1.Text;
                   Global.EngType = TextBox2.Text;
                   Global.TestRef = TextBox3.Text;
                   Global.OperatorNm = TextBox4.Text;
                   Global.EnginerNm = TextBox5.Text;
                   Global.Turbo_No = TextBox6.Text;
                   Global.FipNo = TextBox7.Text;
                   Global.PrjNm = PrjCombo.Text;
                   Global.T_Date = TextBox9.Text;
                   Global.Shift = TextBox10.Text;
                   //Global.Inj_01 = TextBox7.Text;
                   //Global.Inj_02 = txtInj2.Text;
                   //Global.Inj_03 = txtInj3.Text;
                   //Global.Inj_04 = txtInj4.Text;                   if (checkBox1.CheckState == CheckState.Checked) Global.flg_smk = true; else Global.flg_smk = false;
                   if (checkBox2.CheckState == CheckState.Checked) Global.flg_Radiator = true; else Global.flg_Radiator = false;
                   if (checkBox3.CheckState == CheckState.Checked) Global.flg_Fan = true; else Global.flg_Fan = false;
                   if (checkBox4.CheckState == CheckState.Checked) Global.flg_AirCln = true; else Global.flg_AirCln = false;
                   if (checkBox5.CheckState == CheckState.Checked) Global.flg_Silincer = true; else Global.flg_Silincer = false;
                   if (rd_New.Checked == true) Global.flg_NewFile = true; else Global.flg_NewFile = false;
                   if (rd_Last.Checked == true) Global.flg_OldFile = true; else Global.flg_OldFile = false;


                   Global.Open_Connection("gen_db", "con");
                   MySqlCommand cmd = new MySqlCommand("UPDATE tbsys SET " +
                                " CH1 = '" + Global.EngNo + "'," +
                                " CH2 = '" + Global.EngType + "'," +
                                " CH3 = '" + Global.TestRef + "'," +
                                " CH4 = '" + Global.OperatorNm + "'," +
                                " CH5 = '" + Global.EnginerNm + "'," +
                                " CH6 = '" + Global.Turbo_No + "'," +
                                " CH7 = '" + Global.FipNo + "'," +
                                " CH8 = '" + Global.PrjNm + "'," +
                                " CH9 = '" + Global.flg_smk + "'," +
                                " CH10 = '" + Global.flg_Radiator + "'," +
                                " CH11 = '" + Global.flg_Fan + "'," +
                                " CH12 = '" + Global.flg_AirCln + "'," +
                                " CH13 = '" + Global.flg_Silincer + "'," +
                                " CH14 = '" + Global.flg_NewFile + "'," +
                                " CH15 = '" + Global.flg_OldFile + "'" +
                       //" CH16 = '" + Global.Inj_01 + "'," +
                       //" CH17 = '" + Global.Inj_02 + "'," +
                       //" CH18 = '" + Global.Inj_03 + "'," +
                       //" CH19 = '" + Global.Inj_04 + "'" +
                                " WHERE FileName = '05_EngNo'", Global.con);
                   cmd.ExecuteNonQuery();
                   Global.con.Close();
                   Global.Rd_System();
                   Global.PrjNm = PrjCombo.Text;
                   Check_File_Validation();
                   Global.flg_Auto = false;
                   Global.flg_Semi_Auto = true;
                   Global.Read_Eng();
                   clsLimit.Read_Limfl();
                   Global.Flg_Ready = true;
                   main.Btn22.Enabled = true;
                   main.Btn21.Enabled = false;
                   main.BtnSA.Enabled = true;
                   this.Close();
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show("ErrorCode- 1002" + ex.Message , "Dynalec Controls Pvt Ltd.",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
               //MessageBox.Show("ErrorCode- 1002", ex.Message);
           }

       }

      
       private void btnASave_Click(object sender, EventArgs e)
       {
           try
           {
               Global.JobOrdNo = "***";
               Process[] prs = Process.GetProcesses();
               foreach (Process pr in prs)
               {                   
                   if (pr.ProcessName == "Editors") pr.Kill();
                   if (pr.ProcessName == "Dataappliacation") pr.Kill();
               }
               Erp1.Clear(); 
               if (TextBox1.Text == String.Empty) 
               {
                   Erp1.SetError(TextBox1, "Please Type Engine No.....");
                   MessageBox.Show("Please type Engine no.", "Dynalec Controls Pvt Ltd.",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 //  MessageBox.Show("Please Type Engine No. ...... ");
                   TextBox1.Focus();
               }
               else if (PrjCombo.Text == String.Empty)
               {
                   Erp1.SetError(PrjCombo, "Please Select Project.....");
                   MessageBox.Show("Please Select Project", "Dynalec Controls Pvt Ltd.",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   //MessageBox.Show("Please Select Project. ...... ");
                   PrjCombo.Focus();
               }
              
               else
               {
                   Global.EngNo = TextBox1.Text;
                   Global.EngType  = TextBox2.Text;
                   Global.TestRef = TextBox3.Text;
                   Global.OperatorNm = TextBox4.Text;
                   Global.EnginerNm = TextBox5.Text;
                   Global.Turbo_No  = TextBox6.Text;
                   Global.FipNo  = TextBox7.Text;
                   Global.PrjNm = PrjCombo.Text;
                   Global.T_Date = TextBox9.Text;
                   Global.Shift = TextBox10.Text;
                   //Global.Inj_01 = TextBox7.Text;
                   //Global.Inj_02 = txtInj2.Text;
                   //Global.Inj_03 = txtInj3.Text;
                   //Global.Inj_04 = txtInj4.Text;
                   if (checkBox1.CheckState == CheckState.Checked) Global.flg_smk = true; else Global.flg_smk = false;
                   if (checkBox2.CheckState == CheckState.Checked) Global.flg_Radiator = true; else Global.flg_Radiator = false;
                   if (checkBox3.CheckState == CheckState.Checked) Global.flg_Fan = true; else Global.flg_Fan = false;
                   if (checkBox4.CheckState == CheckState.Checked) Global.flg_AirCln = true; else Global.flg_AirCln = false;
                   if (checkBox5.CheckState == CheckState.Checked) Global.flg_Silincer = true; else Global.flg_Silincer = false;
                   if (rd_New.Checked == true) Global.flg_NewFile = true; else Global.flg_NewFile = false;
                   if (rd_Last.Checked == true) Global.flg_OldFile = true; else Global.flg_OldFile = false;
                    


                   Global.Open_Connection("gen_db", "con");
                   MySqlCommand cmd = new MySqlCommand("UPDATE tbsys SET " +
                                " CH1 = '" + Global.EngNo + "'," +
                                " CH2 = '" + Global.EngType + "'," +
                                " CH3 = '" + Global.TestRef + "'," +
                                " CH4 = '" + Global.OperatorNm + "'," +
                                " CH5 = '" + Global.EnginerNm + "'," +
                                " CH6 = '" + Global.Turbo_No + "'," +
                                " CH7 = '" + Global.FipNo + "'," +
                                " CH8 = '" + Global.PrjNm + "'," +
                                " CH9 = '" + Global.flg_smk + "'," +
                                " CH10 = '" + Global.flg_Radiator + "'," +
                                " CH11 = '" + Global.flg_Fan + "'," +
                                " CH12 = '" + Global.flg_AirCln + "'," +
                                " CH13 = '" + Global.flg_Silincer + "'," +
                                " CH14 = '" + Global.flg_NewFile + "'," +
                                " CH15 = '" + Global.flg_OldFile + "'" +
                                //" CH16 = '" + Global.Inj_01 + "'," +
                                //" CH17 = '" + Global.Inj_02 + "'," +
                                //" CH18 = '" + Global.Inj_03 + "'," +
                                //" CH19 = '" + Global.Inj_04 + "'" +
                                " WHERE FileName = '05_EngNo'", Global.con);
                   cmd.ExecuteNonQuery();
                   Global.con.Close();
                   Global.Rd_System();


                   Global.PrjNm = PrjCombo.Text;

                   //switch (Global.EngMd)
                   //{



                   //    case "FPY505829":
                   //        {

                   //            //Global.model_on_screen = "NEF TCI 2.6L BSIII";
                   //        }
                   //        break;

                   //    case "GPY106354":
                   //        break;
                   //}



                   Check_File_Validation();
                   Global.flg_Auto = true;
                   Global.flg_Manual = false;
                   Global.Read_Eng();
                   clsLimit.Read_Limfl();
                   Global.Flg_Ready = true;
                   main.Btn22.Enabled = false;
                   main.Btn21.Enabled = true;
                   main.BtnSA.Enabled = false;
                   //clsECU.Init_ECU();
                   this.Close();

               }
              
           }
           catch (Exception ex)
           {
               MessageBox.Show("ErrorCode- 1002" + ex.Message, "Dynalec Controls Pvt Ltd.",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
               //MessageBox.Show("ErrorCode- 1002", ex.Message);
           }

       }

       private void textBox11_Leave(object sender, EventArgs e)
       {
           try
           {

               buff_barcode = textBox11.Text;
               //buff_barcode.Substring(14, 10);
               TextBox3.Text = buff_barcode.Substring(0, 9); //buff_barcode.Substring(0, 13);
               int x, y;
               x = TextBox3.Text.Length;
               TextBox1.Text = buff_barcode.Substring(x, 12);
               y = TextBox1.Text.Length;
               String pos;
               int pos1 = 1;
               // pos = buff_barcode.IndexOf(" ", 1);
               //pos1 = pos - TextBox3.Text.Length;

               //pos = buff_barcode.Substring(x + 2 * y);
               //pos1 = pos.Length;
              
              
           }
           catch (Exception ex)
           {
               MessageBox.Show("Please scan proper Barcode" + ex.Message, "Dynalec Controls Pvt Ltd.",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
               //MessageBox.Show("Please scan proper Barcode");
               //textBox11.Text = "";
               //textBox11.Focus();
               this.Close();
               return;
           }


           try
           {
               //Sn = 0;
               //PrjCombo.Enabled = true;
               PrjCombo.Items.Clear();
               PrjCombo.BackColor = Color.Green;
               PrjCombo.ForeColor = Color.Yellow;
               Global.Open_Connection("gen_db", "con");
               MySqlCommand cmd4 = new MySqlCommand("SELECT * FROM tblProject where ProjectFile LIKE  '" + "Prj_" + TextBox3.Text + "%'", Global.con);
              
               MySqlDataReader Rd4 = cmd4.ExecuteReader();
               while (Rd4.Read())
               {
                   PrjCombo.Items.Add(Rd4.GetValue(0).ToString());
               }
               Global.con.Close();
               //PrjCombo.SelectedIndex = 0;
               //Global.Selected_proj = PrjCombo.Text;
           }
           catch (Exception ex)
           {
               MessageBox.Show("Error in EngDialog: Fill_Combo" + ex.Message, "Dynalec Controls Pvt Ltd.",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
               //MessageBox.Show("Error in EngDialog: Fill_Combo:  " + ex.Message);
           }


       }

       private void TextBox1_Leave(object sender, EventArgs e)
       {
           //if (TextBox1.Text != "")
           //{
           //    if ((TextBox1.Text.Length > 3) && (TextBox1.Text.Length < 12))
           //    {
           //       // EP.SetError(TextBox1, "Number should be 12 Digits");
           //        TextBox1.Focus();

           //        //TextBox3.Text.ToString.Clear();
           //        //cmbproject.Items.Clear();
           //        //btnSave.Enabled = false;
           //        //cmbproject.Enabled = false;
           //        //cmbEngMd.Enabled = false;
           //    }
           //    else
           //    {
           //        btnASave.Enabled = true;
           //        Fill_Combo();
           //    }
           //}
           //else
           //{
           //    TextBox1.Focus();
           //    btnASave.Enabled = false;
           //}
           //try
           // {

           //     TextBox3.Text = "";
           //     buff_barcode = textBox11.Text;
           //     //buff_barcode.Substring(14, 10);
           //     TextBox3.Text = buff_barcode.Substring(0, 9); //buff_barcode.Substring(0, 13);
           //     int x, y;
           //     x = TextBox3.Text.Length;
           //     TextBox1.Text = buff_barcode.Substring(x, 12);
           //     y = TextBox1.Text.Length;
           //     //String pos;
           //     //int pos1 = 1;
           //     // pos = buff_barcode.IndexOf(" ", 1);
           //     //pos1 = pos - TextBox3.Text.Length;

           //     //pos = buff_barcode.Substring(x + 2 * y);
           //     //pos1 = pos.Length;
           //     //if (pos1 >= 12)
           //     //{
           //     //    int n = pos1 / 4;

           //         //txtInj1.Text = pos.Substring(0, n);
           //         //txtInj2.Text = pos.Substring(n, n);
           //         //txtInj3.Text = pos.Substring(2 * n, n);
           //         //txtInj4.Text = pos.Substring(3 * n, n);
           //         //Global.INJ1 = txtInj1.Text;
           //         //Global.INJ2 = txtInj2.Text;
           //         //Global.INJ3 = txtInj3.Text;
           //         //Global.INJ4 = txtInj4.Text;
           //         ////buff_barcode.Substring();
           //     //    textBox11.ReadOnly = true;
           //         //if ((Global.INJ1.Length != n) || (Global.INJ2.Length != n) || (Global.INJ4.Length != n) || (Global.INJ4.Length != n))
           //         //{
           //         //    MessageBox.Show("Injector Flashing is not correct..");

           //         //}
           //     //}
           //     ////string inj;

           //     //else
           //     //{

           //     //    MessageBox.Show("Please scan proper Barcode");
           //     //    this.Close();
           //     //    //textBox11.Text = "";
           //     //    //textBox11.Focus();
           //     //}


           // }
           // catch (Exception ex)
           // {
           //     MessageBox.Show("Please scan proper Barcode");
           //     //textBox11.Text = "";
           //     //textBox11.Focus();
           //     this.Close();
           //     return;
           // }


           // try
           // {
           //     //Sn = 0;
           //     //PrjCombo.Enabled = true;
           //     PrjCombo.Items.Clear();
           //     PrjCombo.BackColor = Color.Green;
           //     PrjCombo.ForeColor = Color.Yellow;
           //     Global.Open_Connection("gen_db", "con");
           //     MySqlCommand cmd4 = new MySqlCommand("SELECT * FROM tblProject where ProjectFile LIKE  '" + "Prj_" + TextBox3.Text + "%'", Global.con);
           //    MySqlDataReader Rd4 = cmd4.ExecuteReader();
             
           //     while (Rd4.Read())
           //     {
           //         PrjCombo.Items.Add(Rd4.GetValue(0).ToString());
           //     }
           //     Global.con.Close();
           //     PrjCombo.SelectedIndex = 0;
           //     //Global.Selected_proj = PrjCombo.Text;
           // }
           // catch (Exception ex)
           // {
           //     MessageBox.Show("Error in EngDialog: Fill_Combo:  " + ex.Message);
           // }


        }

       private void textBox11_TextChanged(object sender, EventArgs e)
       {

       }

       private void PrjCombo_SelectedIndexChanged(object sender, EventArgs e)
       {

       }

       private void PrjCombo_DropDownClosed(object sender, EventArgs e)
       {
           Global.EngMd = TextBox3.Text;
           switch (Global.EngMd)
           {
               // ECU1 for prevoius models & default BS 4
               case "FPY505829":
                   break;
               case "GPY106354":
              // case "0301BAC01470N":
              // case "0301BC0230N":
             //  case "0301BC0250N":
               //case "0301BC0570N":
               //case "0301BC0510N":
               //case "03000C0130N":
               //case "0301BC0870N":
               //case "0301BC1170N":
               //case "0301BC1180N":
               //case "0301BC1190N":
               //case "0301BC1200N":
               //case "0301BAC01330N":
               //case "0301BAC04540N":
               //case "0301BAC01660N":
               //case "0301BAC04420N":
               //case "0301BAC04600N":
               //case "0301BAC04740N":
               //case "0301BC0700N":
               //case "0301BC0940N":
               //case "0301BC1040N":
               //case "0301BAC01310N":
               //case "0301BC0270N":
               //case "0301BC0180N":
               //case "0301BC0400N":
               //case "0301BC0470N":
               //case "0301BC0410N":
               //case "0301BAC01350N":
               //case "0301BAC01450N":
               //case "0301BAC01520N":
               //case "0301BAC01480N":
               //case "0301BAC01510N":
               //case "0301BC0800N":
                   
                    
                       break;
                   

              
               default:
                   {
                       break;
                   }
           }
       }

       private void Panel1_Paint(object sender, PaintEventArgs e)
       {

       }

       private void textBox13_TextChanged(object sender, EventArgs e)
       {

       }

       }
      


      
      
        //***************
    }

