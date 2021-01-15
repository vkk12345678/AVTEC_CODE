using System;
using System.Data; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;   
using System.Data.OleDb;
//using Automation.BDaq;
using System.Globalization; 
using System.IO.Ports ;
using System.IO;
using System.Threading; 
using MySql.Data.MySqlClient;
//using Main_EDAC; 

 
namespace Logger     //WindowsFormsApplication1
{
    public class Global
    {
        public static string PATH = Application.StartupPath + "\\";
        public static string HelpPATH = "C:\\Windows\\Help\\DynalecHelp\\";
        public static string Data_Dir;
        public static string OnLog_Data;
        public static string CDate = DateTime.Now.ToString("MMMyy");  
        public static string DataPath; // = "D:\\TestCell_" + T_CellNo + "\\" & Data_Dir & "\\";
        public static  string[] bin0 = new string[8] { "0", "0", "0", "0", "0", "0", "0", "0" };
        public static string[] bin1 = new string[8] { "0", "0", "0", "0", "0", "0", "0", "0" };
        public static MySqlConnection con = new MySqlConnection();
        public static MySqlConnection conLim = new MySqlConnection();
        public static MySqlConnection conSeq = new MySqlConnection();
        public static MySqlConnection conData = new MySqlConnection();
        public static MySqlConnection fconData = new MySqlConnection();
        public static MySqlConnection conMES = new MySqlConnection();
        public static MySqlConnection conLog = new MySqlConnection();
        public static MySqlConnection conPM = new MySqlConnection();



        public static String[] Sr_Port1 = new String[10];
        public static String[] Sr_Port2 = new String[10];
        public static String[] Ad_Port1 = new String[10];
        public static String[] Ad_Port2 = new String[10];       
        public static String[] Smk_Port = new String[10];
        public static String[] Bl_Port = new String[10];
        public static String[] sc_Port = new String[10];
        public static String[] P4_Port1 = new String[10];
        public static String[] P2_Port1 = new String[10];
        public static String[] P2_Port2 = new String[10];
        public static String[] P2_Port3 = new String[10];
        public static String[] P2_Port4 = new String[10];
        public static String[] P2_Port5 = new String[10];
        public static String[] Fl_Port = new String[10];
        //public static String[] Sr_Port1 = new String[10];


        public static int[]LimNo = new int[100];
        public static String[] PNo = new String[150];
        public static String[] PName = new String[150];
        public static String[] PSName = new String[150];
        public static String[] PUnit = new String[150];
        public static String[] PMin = new String[150];
        public static String[] PMax = new String[150];
        public static String[] PMark = new String[150];
        public static String[] GenData = new String[150];
        public static string[] st1 = new string[8];
        public static string[] st2 = new string[8];

        public static string smkbuffer;
        public static String[] arr = new String[50];
        public static String CStrtTm;
        public static String CStopTm;

        public static String[] Data = new String[130];
        public static String[] fData = new String[130];
        public static String[] ArrData = new String[130];
        public static String[] PmArr = new String[150];
        public static String[] Arr = new String[5];

        public static Boolean flg_SMOKE_COM = false;

        public static SerialPort MSPort = new SerialPort();
        public static SerialPort RTPort = new SerialPort();
        public static SerialPort ADPortG1 = new SerialPort();
        public static SerialPort ADPortG2 = new SerialPort();

        public static SerialPort BlPort = new SerialPort();
        public static SerialPort mbPort = new SerialPort();
        public static SerialPort scPort = new SerialPort();
        public static SerialPort smkPort = new SerialPort();
        public static int cntlist=0;

        public static Boolean flg_fstart = false;
        public static Boolean flg_fstop = false; 
        
       

		public static int smk = 1;
        public static int ISn = 0;
        public static int smkCn = 1;
        public static Double Ex_Bk = 1;

        public static int S_Rpm = 0;
      

        public static Double MinPow = 00.0;
        public static Double MaxSmoke = 75.0;
        public static Double MaxFD = 99.99;
        public static Double SPARE_1 = 00.00;
        public static Double SPARE_2 = 00.00;
        public static Double SPARE_3 = 00.00;
        public static Double SPARE_4 = 00.00;
        public static Double SPARE_5 = 00.00;
        public static Boolean flg_PassLim = false;



        public static string ADM_Val_buffer;
        public static int Adm_id = 01;
        public static Int16 T = 21;
        public static Int16 U = 29;
        public static Int16 V = 37;
        public static Int16 W = 45;
        public static Int16 X = 53;
        public static Int16 Y = 61;


        public static Double Simul_1 = 1.5;
        public static Double Simul_2 = 83;
        public static Double Simul_3 = 560;
        
        public static String Ds1 = "00000000";
        public static String Ds2 = "00000000";


		public  static readonly Random random = new Random();


		public static int loopcount=0;
        public static String[] RpArr = new String[75];
        public static String[] Prj = new String[20];
        public static String[] AdamG1 = new String[75];
        public static String[] AdamG2 = new String[75];
        public static int[] DigIn = new int[20];
        public static string[] DigOut = new string[20];

        public static String[] sysIn = new String[75];
        public static String[] paraName = new String[75];

        public static int[] fxd = new int[60];
        public static int[] Pm_PNo = new int[20];

        public static int[] vId = new int[130];
        public static String[] vIdName = new string[130];
        public static int vIdNo = 0;
        public static int  L_Cn = 0;

      
        public static Boolean flg_EngStart = false ;       
        public static Boolean flg_SFCStart = false;
        public static Boolean flg_Module1 = false;
        public static Boolean flg_Module2 = false;
        public static Boolean flg_Module3 = false;

        public static Boolean flg_Smt_Changeover = false;
        public static Boolean flg_Std_Changeover = false;

        public static Boolean flg_Manual = false;
        public static Boolean flg_Auto = false;
        public static Boolean flg_even_Mode = false;
        public static Boolean flg_CycleStarted = false;
		public static Boolean flg_fastlog = false;
        public static Boolean flg_flog = false;


		public static double[] f_data = new double[2];
		public static  double  [] m_data = new double[16];
        public static  string[] GetData = new string[16];
        public static String[] L1 = new String[105];
        public static String[] LL1 = new String[105];
        public static String[] H1 = new String[105];
        public static String[] HH1 = new String[105];
        public static String[] Hs = new String[105];
        public static String[] Ls = new String[105];
        
        public static Double SmkVal;
        public static String SmkError;
        public static String SmkEr1;
        public static String SmkEr2;
        public static String SmkEr3;
        public static String SmkEr4;
        public static String SmkEr5;
        public static String StpLimFl;

        public static String E_setpt1 = "0";
        public static String E_setpt2 = "0";
        public static String E_setpt3 = "0";
        public static String E_setpt4 = "0";
        public static String E_setpt5 = "0";
        public static String E_setpt6 = "0";
        public static String E_setpt7 = "0";
        public static String E_setpt8 = "0";
        public static String E_setpt9 = "0";



        public static String[] L2 = new String[105];
        public static String[] LL2 = new String[105];
        public static String[] H2 = new String[105];
        public static String[] HH2 = new String[105];
        public static String[] BufLim = new String[105];
        public static String[] arrLim = new String[105];

        
                          
        public static String SFC_Msg_from_Inst = "";
        public static String SFC_Status = "";
        public static string modcnt;
        public static Double E_Pow;
       public static  Boolean Flg_AList = true;

        public static Boolean SFC_Reset = false;
        public static Boolean Mx_Trq = false;
        public static Int16 RealRPM;
        public static Int16 varRPM;
        public static double varTRQ;
        public static double varLUB;
        public static double varbmep;
        public static double varWtr;


        public static Boolean Er_Serial = false;
        public static Boolean Er_Gantner = false;
        public static Boolean Er_ADAM = false;
        public static Boolean Er_SmkMeter = false; 





        public static int log_freq = 100;

        public static string RBuffer = "0";
        public static string TBuf_old = "0";
        public static string TBuf_New = "0";

        public static String StpTm;  
        public static String EngHrs;
        public static String SFC_msg;
        public static string bufftss4;
        public static string bufftss8;
        public static string wrongbuf;
        public static string HAlarm;
        public static String SED; 

        public static int VolA = 100;
        public static int VolB = 200;
        public static int VolC = 300;
        public static int Vol = 100;
        public static int StNo = 1;
        public static Boolean flg_LogM = false;

      public static   Int16 ADAMCnt = 1;
      public static   Int16 ChnCnt = -1;
      public static  int stopid ;
    
     public static int LogCnt = 0;

      public static  String S_Out = "00";
      public static Int16 R_Add = 0;
      public static Int16 I_Add = 0;
      public static Int16 S_Add = 0;
      public static String A_Out = "00";
      public static Int16 A_Add = 0;
      public static string EngType="";
      public static string TestTyp = "";
      public static int Sn = 0;
      public static int ErrSn = 0;
      public static int LogTm = 0;
      public static int LTm = 0;


        public static string Bor="100";
        public static string NCyl="2";
        public static string Strk="100";
        public static string Svol="1.5";
        public static string SGrv="0.835";
        public static string FuelType="";
        public static String EngNo;
        public static String EngineNo;

        public static string Dt;
        public static String PrjNm;
        public static String EnginerNm;
        public static String OperatorNm;
        public static String TestNo;
        public static String TestRef;
        public static String RedFlgItem;
        public static String JobOrdNo;
        public static String ExOn;
        public static String FanOn;
        public static String ACSOn;
        public static String T_Date;
        public static String I_Tm;
        public static String Shift;
        public static String HzLog;
        public static String FipNo;
        public static String EngMd;
        public static String TKnNo;
        public static Double Rel_Hum;
        public static int Dly_cnt = 1000;


       


        public static String SFCStatus;
        public static Int16  LogCounter;
        public static string  cumhours="0000:00:00";

        public static Boolean flg_prjOn = false;
        public static Boolean Flg_Ready = false;
        public static Boolean flg_LimitON = false; 
         public static Boolean flg_SMK437 = false;
         public static Boolean flg_SMK415 = false;
         public static Boolean flg_SMK415_S = false;
         public static Boolean flg_ManPC = false;
         public static Boolean flg_AutoPC = false;
         public static Boolean Auto_SFC = false;
         public static Boolean flg_Man_Perf = true;
         public static Boolean flg_UpdateViewData = false;
         public static string StepTime;
         public static String S_StartTime;

         public static Boolean flg_smk = false;
         public static Boolean flg_Radiator = false;
         public static Boolean flg_Fan = false;
         public static Boolean flg_AirCln = false;
         public static Boolean flg_Silincer = false;
         

         public static Boolean flg_SFC = false;
         public static Boolean flg_SFCReset = false;
         public static Boolean flg_SFCON = false;
         public static Boolean flg_SFCOVER = false;
         public static Boolean flg_rdMod = false;
         public static Boolean flg_LoginRPM = false;
         public static Boolean flg_RecorsPmData = false;
         public static Boolean flg_simulateRPM = false;
         public static Boolean flg_Log_service = false;
         public static Boolean flg_Log_supervisor = false;         
         public static int flg_VolActive = 1;
         public static Boolean flg_RunStart = false;
         public static Boolean flg_RLoop = false;
         public static Boolean flg_Semi_Auto = false;

        public static Double Diff1; 
        public static Double Diff2;
        public static Double Diff3;
        public static Double Diff4;
        public static Double MDiff;

        public static Double Edif1;
        public static Double Edif2;

        public static Double LastRPM = 0;
        public static Double LastTrq = 0;

        
 
        public static Double AnaOut1= 0.01;
        public static Double AnaOut2= 0.01;
        public static Double LastAna1= 0;
        public static Double LastAna2= 0;
        public static Double LastT = 0;
        public static Double LastD = 0;
 
        public static String SetPtOut1 = "0";
        public static String SetPtOut2 = "0";
        public static String L_SetPtOut1 = "0";
        public static String L_SetPtOut2 = "0"; 
        public static String C_Mode = "1";
        public static String L_Mode = "1";
        public static Double L_Error1 = 0;
        public static Double L_Error2 = 0;

        public static string RcrOn = "FALSE";
        public static string TcrOn = "FALSE";
       
        public static String Eng_FileNm;
        public static String Eng_PMFileNm;
        public static String Eng_Error_FileNm;
		public static String Eng_fData_FileNm;
		public static String Eng_Inst_FileNm;
        public static String Eng_FLog_FileNm;
        public static Boolean flg_CylStart = false;

        public static string T_CellNo;
        public static Double SFCwt;
        public static Double SFCTm;
        //public static string SmkVal;
        public static Double BlBy;
        public static long SnEr = 0;
        public static Double S_pt1 = 0;
        public static Double S_pt2 = 0;
        public static Double AvgPowPs;
        public static Double AvgPowkW;                  
        public static Double AvgRpm;
        public static Double AvgTrq;
        public static Double SFCValkW;
        public static Double SFCValPs;
        public static Double C_SFCValkW;
        public static Double C_SFCValPs;
        public static Double Bi_Val;
        public static Double fl_Rate;
        public static Double Corfact;
        //public static Double VarTrq;
        public static Double VarPowkW;
        public static Double VarPowHp;
        public static Double C_VarPowkW;
        public static Double C_VarPowHp; 
       
        public static String StrAlarm = "Alarm Status...";
        //public static String RunStatus;
        public static String ErrorMatrix;
        public static String MD1, MD2, MD3, MD4, MD5, MD6;
        public static Double Drb = 33.0;
        public static Double Web = 27.0;
        public static Double Atp = 1.013;
        public static Double C_bmep; 
        public static String SetRPM;
        public static String SetTRQ;
        public static int StpN = 0;
        public static string[] ChkLim = new string[10];

        public static int cntDSafty = 0;
        public static Boolean flg_ChlLim = false;

        public static Boolean flg_smokeStart = false;
		public static String[] scrn_Par = new String[80];


		//public static frmMain main = new frmMain();
        public static Boolean flg_frmManual = false;
        public static Boolean flg_NewFile = false;
        public static Boolean flg_OldFile = false;
        public static Boolean flg_DataSave = false;

        public static string MySqlPW;



        public static void Rd_Pwd()
        {

            string path = "C:\\";
            //File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Normal);
            FileStream fs2 = new FileStream("C:\\edac.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs2);
            String InPut = reader.ReadToEnd();
            int pos1 = 1;
            int pos2 = 1;
            pos1 = InPut.IndexOf("@", 0);
            pos2 = InPut.IndexOf("@", (pos1 + 1));
            MySqlPW = InPut.Substring(pos1 + 1, (pos2 - pos1 - 1));
            reader.Close();

            //File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);

        }

       

      public static void Make_mdb(String mdbPath)
      {
			try
			{
				Global.Data_Dir = DateTime.Now.ToString("MMMyy");
                Global.OnLog_Data = "OnLog_" + DateTime.Now.ToString("ddMMMyy");
				if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo) == false)
				{
					System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo);
				}
				if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir) == false)
				{
					System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir);
				}
				if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Gen_Data") == false)
				{
					System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Gen_Data");
				}

				if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\PM_Data") == false)
				{
					System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\PM_Data");
				}
				if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\FastLog_Data") == false)
				{
					System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\FastLog_Data");
				}

			}
          catch (Exception ex)
          {
				//MessageBox.Show(ex.Message, "Error:Problem in creating data base ...");
				Create_OnLog("Problem In Creating DataBase ........MakeMDB..", "Alart"); 
          }

      }

      public static void Create_OnLog(string Msg, String  state)//,int Icon)
      {
          try
          {
              Global.Data_Dir = DateTime.Now.ToString("MMMyy");
              string OnLog_Data = System.DateTime.Now.ToString() + "_OnLogData"; 
              
              Global.I_Tm = System.DateTime.Now.ToString("hh:mm:ss tt");
              
              if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\") == false)
              {
                  System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir);
              }
              if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Log_Data") == false)
              {
                  System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Log_Data");
              }
              if (System.IO.File.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Log_Data\\" + OnLog_Data + ".csv") == false)
              {
                  System.IO.File.Create("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Log_Data\\" + OnLog_Data + ".csv");
              }

             
              String strData = I_Tm + ",      " + EngineNo + ",     " + StNo + ",     " + varRPM + ",     " + Msg + ",     "  +  state;
              String filePath1 = "D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Log_Data\\" + OnLog_Data + ".csv";
             
              using (StreamWriter sw = File.AppendText(filePath1))
                  sw.WriteLine(strData); ;
          }
          catch (Exception ex)
          {
              return;
              //Global.Create_OnLog(ex.Message + " :  Load In Cell....", false);  
              //MessageBox.Show("Error Code:- 15007", ex.Message);
          }

      }

       

        public static void Open_PMConn(String db, String cPm)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection("server = localhost; user id = root; password =" + Global.MySqlPW + "; database =" + db);
                cn.Open();

                if (cPm == "conPM")
                {
                    if (cn.State == System.Data.ConnectionState.Open)
                    {
                        conPM.Close();
                        conPM = cn;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.Create_OnLog(ex.Message + " :  Open PM Connecton....", "Alart");
                //MessageBox.Show("Error Code:-15013", ex.Message);
            }
        }

        public static void Open_LogConn(String db, String cNm)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection("server = localhost; user id = root; password = " + Global.MySqlPW + "; database =" + db);
                // OleDbConnection cn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0; Data Source= D:\\TestCell_" + T_CellNo + "\\" + db + "\\" + "Log.accdb;Jet OLEDB:DATABASE Password = gen.edac");
                //OleDbConnection cn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source= D:\\TestCell_" + T_CellNo + "\\" + db + "\\" + "Log.accdb");
                cn.Open();

                if (cNm == "conLog")
                {
                    if (cn.State == System.Data.ConnectionState.Open)
                    {
                        conLog.Close();
                        conLog = cn;
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error Code:-15012", ex.Message);    
                Global.Create_OnLog("Data log Connection......", "Alart");
            }
        }
        public static void Open_DataConn(String db, String cNm)
        {
            try
            {
                //OleDbConnection cn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0; Data Source=" + Global.DataPath + db + ".accdb");
                MySqlConnection cn = new MySqlConnection("server = localhost; user id = root; password = " + Global.MySqlPW + "; database =" + db);
                cn.Open();

                if (cNm == "conData")
                {
                    if (cn.State == System.Data.ConnectionState.Open)
                    {
                        conData.Close();
                        conData = cn;
                    }
                }
                MySqlConnection fcn = new MySqlConnection("server = localhost; user id = root; password = " + Global.MySqlPW + "; database =" + db);
                fcn.Open();

                if (cNm == "fconData")
                {
                    if (fcn.State == System.Data.ConnectionState.Open)
                    {
                        fconData.Close();
                        fconData = fcn;
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error Code:- 15011", ex.Message);  
                Global.Create_OnLog("Data Connection .......", "Alart");
            }

        }

        //**************************
        public static void Read_SqlTable(string TbNm, string ColNm, string flNm)
        {
            for (int i = 0; i <= 199; i++) Global.arr[i] = null;
            Global.Open_Connection("gen_db", "con");
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + TbNm + " where " + ColNm + " = '" + flNm + "'", Global.con);
            MySqlDataReader Rd = cmd.ExecuteReader();


            Int16 x = 0;
            while (Rd.Read())
            {
                for (x = 0; x <= (Rd.FieldCount - 1); x++)
                {
                    Global.arr[x] = Rd.GetValue(x).ToString();
                }
            }
            cmd.Dispose();
            Global.con.Close();
        }
        public static void Del_SqlTable(string TbNm, string flNm)
        {
            MySqlCommand cDelete = new MySqlCommand();
            cDelete.CommandText = "DELETE FROM " + TbNm + " where FileName = '" + flNm + "'";
            Global.Open_Connection("gen_db", "con");
            cDelete.Connection = Global.con;
            cDelete.ExecuteNonQuery();
        }



        //******************************

        public static void Open_Connection(String db, String conNm)
        {
            try
            {
                //MySqlConnection conn = new MySqlConnection("server = localhost; user id = root; password = " + Global.MySqlPW + "; database =" + db);
                MySqlConnection conn = new MySqlConnection("server = localhost; user id = root; password = dynalec; database =" + db);

                conn.Open();

                if (conNm == "con")
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        con.Close();
                        con = conn;
                    }
                }
                if (conNm == "conLim")
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conLim.Close();
                        conLim = conn;
                    }
                }
                if (conNm == "conSeq")
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conSeq.Close();
                        conSeq = conn;
                    }
                }
                if (conNm == "conMES")
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conMES.Close();
                        conMES = conn;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15008", ex.Message);
            }

        }

        
        
        /// <summary>
        /// read system Files & Com Configuration
        /// </summary>
        public static void Rd_System()
        {
            try
            {
                int x = 0;
                Open_Connection("gen_db", "con");
                MySqlDataAdapter dap = new MySqlDataAdapter("SELECT * FROM tbsys", con);
                DataSet ds = new DataSet() ;
                dap.Fill(ds);
                for (x = 0; x <= ds.Tables[0].Columns.Count - 1; x++) AdamG1[x] = ds.Tables[0].Rows[0].ItemArray[x].ToString();
                for (x = 0; x <= ds.Tables[0].Columns.Count - 1; x++) AdamG2[x] = ds.Tables[0].Rows[0].ItemArray[x].ToString();
                for (x = 0; x <= ds.Tables[0].Columns.Count - 1; x++) sysIn[x] = ds.Tables[0].Rows[7].ItemArray [x].ToString();
            

                 Global.con.Close();

                T_CellNo = sysIn[9];
                if (sysIn[14] == "TRUE") flg_VolActive = 1; else flg_VolActive = 0;
                RcrOn = sysIn[15];
                TcrOn = sysIn[16];
                flg_RecorsPmData = Convert.ToBoolean(sysIn[17]);
                flg_LoginRPM = Convert.ToBoolean(sysIn[18]);
                flg_simulateRPM = Convert.ToBoolean(sysIn[19]);
                Data_Dir = DateTime.Now.ToString("MMMyy");
                DataPath = "D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\";
                Global.Create_OnLog("Tb_Sys", "Normal");
            }
            
            catch (Exception ex)
            {
                Global.Create_OnLog("Tb_Sys .....", "Alart");
                //MessageBox.Show("Error Code:- 15014", ex.Message); 
            }
        }



        /// <summary>
        /// Read Comports Configuration.......
        /// </summary>
        /// <param name="Read Comports Configuration......."></param>
        /// <returns></returns>
        /// 
        public static void Rd_COM_Confg()
        {
            try
            {
                int x = 0;
                Open_Connection("gen_db", "con");
                MySqlDataAdapter Dap = new MySqlDataAdapter("SELECT * FROM tb_comports ORDER BY Sn", Global.con);
                DataSet ds = new DataSet();
                Dap.Fill(ds);
                for (x = 0; x < 10; x++) Sr_Port1[x] = ds.Tables[0].Rows[0].ItemArray[x].ToString();
                for (x = 0; x < 10; x++) Ad_Port1[x] = ds.Tables[0].Rows[1].ItemArray[x].ToString();
                for (x = 0; x < 10; x++) Ad_Port2[x] = ds.Tables[0].Rows[2].ItemArray[x].ToString();
                for (x = 0; x < 10; x++) sc_Port[x] = ds.Tables[0].Rows[3].ItemArray[x].ToString();
                for (x = 0; x < 10; x++) Smk_Port[x] = ds.Tables[0].Rows[4].ItemArray[x].ToString();
                for (x = 0; x < 10; x++) Bl_Port[x] = ds.Tables[0].Rows[5].ItemArray[x].ToString();
                for (x = 0; x < 10; x++) Fl_Port[x] = ds.Tables[0].Rows[6].ItemArray[x].ToString();
                for (x = 0; x < 10; x++) P4_Port1[x] = ds.Tables[0].Rows[7].ItemArray[x].ToString();
                for (x = 0; x < 10; x++) P2_Port1[x] = ds.Tables[0].Rows[8].ItemArray[x].ToString();
                for (x = 0; x < 10; x++) P2_Port2[x] = ds.Tables[0].Rows[9].ItemArray[x].ToString();
                for (x = 0; x < 10; x++) P2_Port3[x] = ds.Tables[0].Rows[10].ItemArray[x].ToString();
                for (x = 0; x < 10; x++) P2_Port4[x] = ds.Tables[0].Rows[11].ItemArray[x].ToString();
                for (x = 0; x < 10; x++) P2_Port5[x] = ds.Tables[0].Rows[12].ItemArray[x].ToString();
                for (x = 0; x < 10; x++) Sr_Port2[x] = ds.Tables[0].Rows[13].ItemArray[x].ToString();
                Global.Create_OnLog("COM ports are read successfully    ", "Normal");

                if (Sr_Port1[9] == "True")    Init_RtPort();
                if (Sr_Port2[9] == "True")    Init_SrPort();
                if (Ad_Port1[9] == "True")    Init_ADAMG1Port();
                if (Ad_Port2[9] == "True")    Init_ADAMG1Port();
                if (Smk_Port[9] == "True")    Init_SmokePort();
                if (Bl_Port[9] == "True")     Init_BlowByPort();
                if (sc_Port[9] == "True")     Init_BarcodeScanner();
            }
            catch (Exception)
            {               
                Global.Create_OnLog("COM ports are not read successfully    ", "Alart");
            }
        }

        public static void Init_RtPort()
        {
            try
            {
                RTPort.PortName = Global.Sr_Port1[2];
                if (RTPort.IsOpen == true) RTPort.Dispose(); 
                RTPort.BaudRate = int.Parse(Global.Sr_Port1[3]);
                RTPort.DataBits = int.Parse("8");
                RTPort.Parity = (Parity)Enum.Parse(typeof(Parity), Global.Sr_Port1[4]);
                RTPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                if (RTPort.IsOpen == false)
                {
                    RTPort.Dispose();
                    RTPort.PortName = Global.Sr_Port1[2];
                    RTPort.Open();
                    Global.Create_OnLog("RTPort Opened ", "Normal");
                    Er_Serial = true; ;
                }
            }
            catch
            {
                Global.Create_OnLog("RTport Opened .....", "Alart");
                Er_Serial = false;
                return;
            }
        }



        public static void Init_SrPort()
        {
            try
            {
                Global.MSPort.PortName = Global.Sr_Port2[2];
                if (MSPort.IsOpen == true) MSPort.Dispose();
                MSPort.BaudRate = int.Parse(Global.Sr_Port2[3]);
                MSPort.DataBits = int.Parse("8");
                MSPort.Parity = (Parity)Enum.Parse(typeof(Parity), Global.Sr_Port2[4]);
                MSPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                if (MSPort.IsOpen == false)
                {
                    MSPort.Dispose();
                    MSPort.PortName = Global.Sr_Port2[2];
                    MSPort.Open();
                    Global.Create_OnLog("MSPort Opened ", "Normal");
                }
            }
            catch
            {
                Global.Create_OnLog("MSPort Opened .....", "Alart");
                return;
            }
        }

        public static void Init_ADAMG1Port()
        {
            try
            {
                Global.ADPortG1.PortName = Global.Ad_Port1[2];
                if (ADPortG1.IsOpen == true) ADPortG1.Dispose();
                ADPortG1.BaudRate = int.Parse(Global.Ad_Port1[3]);
                ADPortG1.DataBits = int.Parse("8");
                ADPortG1.Parity = (Parity)Enum.Parse(typeof(Parity), Global.Ad_Port1[4]);
                ADPortG1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                if (ADPortG1.IsOpen == false)
                {
                    ADPortG1.Dispose();
                    ADPortG1.PortName = Global.Ad_Port1[2];
                    ADPortG1.Open();
                    Global.Create_OnLog("ADPortG1 Opened ", "Normal");

                }
            }
            catch
            {
                Global.Create_OnLog("ADportG1 Opened .....", "Alart");
                return;
            }
        }

        public static void Init_ADAMG2Port()
        {
            try
            {
                Global.ADPortG2.PortName = Global.Ad_Port2[2];
                if (ADPortG2.IsOpen == true) ADPortG2.Dispose();
                ADPortG2.BaudRate = int.Parse(Global.Ad_Port2[3]);
                ADPortG2.DataBits = int.Parse("8");
                ADPortG2.Parity = (Parity)Enum.Parse(typeof(Parity), Global.Ad_Port2[4]);
                ADPortG2.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                if (ADPortG2.IsOpen == false)
                {
                    ADPortG2.Dispose();
                    ADPortG2.PortName = Global.Ad_Port2[2];
                    ADPortG2.Open();
                    Global.Create_OnLog("ADPortG2 Opened ", "Normal");
                }
            }
            catch
            {
                Global.Create_OnLog("ADporG2t Opened .....", "Alart");
                return;
            }
        }
        public static void Init_SmokePort()
        {
            try
            {
                if (smkPort.IsOpen == true) smkPort.Dispose();
                smkPort.PortName = Global.Smk_Port[2]; 
                //Global.smkPort.PortName = Global.Smk_Port[2];
                
                //smkPort.BaudRate = int.Parse(Global.smkPort[3]);
                smkPort.DataBits = int.Parse("8");
                smkPort.Parity = (Parity)Enum.Parse(typeof(Parity), Global.Smk_Port[4]);
                smkPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                if (smkPort.IsOpen == false)
                {
                    smkPort.Dispose();
                    smkPort.PortName = Global.Smk_Port[2];
                    smkPort.Open();
                    Global.Create_OnLog("Smk_Port Opened ", "Normal");
                   
                    SMOKE_REMOTE_SETTING();
                }
            }
            catch
            {
                Global.Create_OnLog("Smk_Port Opened .....", "Alart");
              
            }
        }

        public static void SMOKE_REMOTE_SETTING()
        {
           
            String Buf;
            try
            {

                smkPort.Write(" SREM");
                Buf = "";
                Thread.Sleep(200);
                Buf = smkPort.ReadExisting();
                SmkEr4 = Buf;
                if (Buf == "")
                {
                    Global.Er_SmkMeter = false;
                    Global.SmkError = "SMOKE METER NOT CONNECTED : Error";
                    Global.flg_SMOKE_COM = false;
                    Global.SmkEr1 = "Not Ready";
                }
                if (Buf.Substring(5, 1) == "0")
                {
                    Global.SmkError = " SMOKE METER IN REMOTE MODE.... : Error:  0";
                    Global.flg_SMOKE_COM = false;
                    Global.SmkEr2 = "Remote";
                    Global.flg_SMOKE_COM = true;
                }
                else if (Buf.Substring(5, 1) == "1")
                {
                    Global.SmkError = " NOT SMOKE METER REMOTE.. : Error:  1";
                    Global.SmkEr2 = "Manual";
                }
                Global.SmkError = "Smoke Meter Remote...";
               
                Thread.Sleep(200);
                smkPort.Write(" ASTZ");
                Buf = "";
                Thread.Sleep(200);
                Buf = smkPort.ReadExisting();
                SmkEr4 = Buf;
                if (Buf.Substring(5, 1) == "0")
                {
                    Global.SmkError = " READY FOR SAMPLING. : Error:  0";
                    Global.SmkEr4 = "Ready";
                }
                else if (Buf.Substring(5, 1) == "1")
                {
                    Global.SmkError = " NOT READY FOR SAMPLING. : Error:  1";
                    Global.SmkEr4 = "Not Ready";
                }

                smkPort.Write(" EMZY Z 6.0 1"); // ("EMZY Z 6.0 1\r");

                Global.SmkEr3 = "Z  6.0   1";

                Buf = "";
                Thread.Sleep(200);
                Buf = smkPort.ReadExisting();
                SmkEr4 = Buf;
                if (Buf == "")
                {
                    Global.SmkError = "SMOKE METRT NOT READY. : Error";
                    Global.SmkEr1 = "Not Ready";
                }
                if (Buf.Substring(5, 1) == "0")
                    Global.SmkError = " READY FOR SAMPLING. : Error:  0";
                else if (Buf.Substring(5, 1) == "1")
                    Global.SmkError = " NOT READY FOR SAMPLING. : Error:  1";
                smkPort.Write(" SRDY");

                Buf = ""; ;
                Thread.Sleep(200);
                Buf = smkPort.ReadExisting();
                SmkEr4 = Buf;
                if (Buf.Substring(5, 1) == "0")
                {
                    Global.SmkError = " READY FOR SAMPLING. : Error:  0";
                    Global.SmkEr1 = "Ready";
                }

                else if (Buf.Substring(5, 1) == "1")
                {
                    Global.SmkError = " NOT READY FOR SAMPLING. : Error:  1";
                    Global.SmkEr1 = " Not Ready";
                }
               

            }
            catch (Exception ex)
            {
                
                Global.Create_OnLog(ex.Message, "Alart");


            }

        }

        public static void Rd_smkPort()
        {
            String buffer = "";
            try
            {
               
                    Global.flg_smokeStart = false;
                    Global.smkPort.Write(" AFSN");
                    Thread.Sleep(500); 
                    buffer = (smkPort.ReadExisting());
                    smkbuffer = buffer;
                    //SmkError = "SMOKE TEST OVER ......";
                    //Global.flg_smokeStart = false;
                    //Global.main.AddListItem("SMOKE TEST OVER ......", "Normal");
                   if (smkbuffer != "")
                    {
                        Global.flg_smokeStart = false;
                        Global.GenData[101] = buffer.Substring((buffer.Length - 7), 6);
                        SmkVal = Double.Parse(Global.GenData[101]);
                        Global.SmkError = "READING OVER ......";
                        S_Add = 0;
                    }
                //}
                //else
                //{
                //    S_Add += 1;5
                //    Global.SmkError = "SAMPLING STARTED ......";

                //}
                if (I_Add >= 20)
                {
                    I_Add = 0;
                    SmkError = "NO SMOKE Reading ......";
                    Global.flg_smokeStart = false;
                }

            }
            catch
            {
                smkPort.Write(" SMES");
                Global.SmkError = "SAMPLING......";
                //MessageBox.Show("read serial Port String Not proper: "+ I_Add +":-" + buffer );
            }
        }



       

        public static void Init_BlowByPort()
        {
            try
            {
                Global.BlPort .PortName = Global.Bl_Port[2];
                if (BlPort.IsOpen == true) BlPort.Dispose();
                BlPort.BaudRate = int.Parse(Global.Bl_Port[3]);
                BlPort.DataBits = int.Parse("8");
                BlPort.Parity = (Parity)Enum.Parse(typeof(Parity), Global.Bl_Port[4]);
                BlPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                if (BlPort.IsOpen == false)
                {
                    BlPort.Dispose();
                    BlPort.PortName = Global.Bl_Port[2];
                    BlPort.Open();
                    Global.Create_OnLog("Blow By Port Opened ", "Normal");
                }
            }
            catch
            {
                Global.Create_OnLog("Blow By Port Opened .....", "Alart");
                return;
            }
        }

        public static void Init_BarcodeScanner()
     {
            try
            {
                Global.scPort .PortName = Global.sc_Port[2];
                if (scPort.IsOpen == true) scPort.Dispose();
                scPort.BaudRate = int.Parse(Global.sc_Port[3]);
                scPort.DataBits = int.Parse("8");
                scPort.Parity = (Parity)Enum.Parse(typeof(Parity), Global.sc_Port[4]);
                scPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                if (scPort.IsOpen == false)
                {
                    scPort.Dispose();
                    scPort.PortName = Global.sc_Port[2];
                    scPort.Open();
                    Global.Create_OnLog("Barcode Scanner Port Opened ", "Normal");
                }
            }
            catch
            {
                Global.Create_OnLog("Bar Code Scanner    Port Opened .....", "Alart");
                return;
            }
        }



        
       
    }
    
}
