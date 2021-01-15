using System;
using System.Data; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;   
using System.Data.OleDb;
using System.Globalization; 
using System.IO.Ports ;

 
namespace DataManagement    //WindowsFormsApplication1
{
    public class Global
    {
        public static string PATH = Application.StartupPath + "\\";
        public static string HelpPATH = "C:\\Windows\\Help\\DynalecHelp\\";//"C:\\DYNALEC_EDAC\\Logger\\bin\\Debug\\";
        public static string Data_Dir;
        public static string DataPath; // = "D:\\TestCell_" + T_CellNo + "\\" & Data_Dir & "\\";
        public static  string[] bin0 = new string[8] { "0", "0", "0", "0", "0", "0", "0", "0" };
        public static string[] bin1 = new string[8] { "0", "0", "0", "0", "0", "0", "0", "0" };   
        public static OleDbConnection con = new OleDbConnection();
        public static OleDbConnection conLim = new OleDbConnection();
        public static OleDbConnection conSeq = new OleDbConnection();
        public static OleDbConnection conData = new OleDbConnection();
        public static OleDbConnection conMES = new OleDbConnection();
        public static OleDbConnection conLog = new OleDbConnection();
        public static int[]LimNo = new int[100];
        public static String[] PNo = new String[130];
        public static String[] PName = new String[130];
        public static String[] PSName = new String[130];
        public static String[] PUnit = new String[130];
        public static String[] PMin = new String[130];
        public static String[] PMax = new String[130];
        public static String[] PMark = new String[130];
        public static String[] GenData = new String[130];
        public static String[] GenPara = new String[20];
        

        public static String[] arr = new String[50];
        public static String CStrtTm;
        public static String CStopTm;

        public static String[] Data = new String[130];
        public static String[] ArrData = new String[130];
        public static String[] PmArr = new String[150];
        public static String[] Arr = new String[5];

      
        public static String[] sysIn = new String[80];
        public static int[] fxd = new int[60];
        public static int[] Pm_PNo = new int[20];       

        public static int[] vId = new int[130];
        public static Boolean flg_EngStart = false ;
       
        public static Boolean flg_SFCStart = false;
        public static Boolean flg_Module1 = false;
        public static Boolean flg_Module2 = false;
        public static Boolean flg_Module3 = false;

        public static  double  [] m_data = new double[16];
        public static  string[] GetData = new string[16];
        public static String[] L1 = new String[105];
        public static String[] LL1 = new String[105];
        public static String[] H1 = new String[105];
        public static String[] HH1 = new String[105];
        public static String[] Hs = new String[105];
        public static String[] Ls = new String[105];

        public static string L;

        public static Boolean flg_PMCHK = false;
        public static Boolean flg_ProdChk = false;
        public static Boolean flg_Multichk = false;
        public static Boolean flg_Perf = false;
        public static Boolean flg_Endu = false;

        public static Boolean flg_delete = false;
        public static Boolean flg_MESchk = false;
        public static Boolean flg_Genchoice = false;
        public static Boolean flg_Enduchoice = false;
        public static Boolean flg_Perfchoice = false;

        public static string Test_cyl = "GENERAL";
        public static long Rstart, Rstop;

        public static string NodeT;
        public static int M;
        public static int N;



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

        public static int VolA = 100;
        public static int VolB = 200;
        public static int VolC = 300;
        public static int Vol = 100;
        public static int StNo = 1;

      public static   Int16 ADAMCnt = 1;
      public static   Int16 ChnCnt = -1;
      public static  int stopid ;
     public static  Int16 t = 31;
     public static Int16 U = 39;
     public static Int16 V = 47;
     public static Int16 W = 55;
     public static Int16 X = 63;

      public static  String S_Out = "00";
      public static  Int16 I_Add = 0;
        public static string EngType="";
        public static string TestTyp = "";

        public static string Bor="100";
        public static string NCyl="2";
        public static string Strk="100";
        public static string Svol="1.5";
        public static string SGrv="0.835";
        public static string FuelType="";
        public static String EngNo;
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
        public static String Shift;
        public static String FipNo;
        public static String EngMd;
        public static String TKnNo;
        public static Double Rel_Hum;


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

         public static Boolean flg_smk = false;
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

        public static Double Diff1; 
        public static Double Diff2;
        public static Double Edif1;
        public static Double Edif2;
 
        public static Double AnaOut1= 0.01;
        public static Double AnaOut2= 0.01;
        public static Double LastAna1= 0;
        public static Double LastAna2= 0; 
        public static String SetPtOut1 = "0";
        public static String SetPtOut2 = "0";
        public static String L_SetPtOut1 = "0";
        public static String L_SetPtOut2 = "0"; 
        public static String C_Mode = "1";
        public static String L_Mode = "1";
        public static string RcrOn = "FALSE";
        public static string TcrOn = "FALSE";
        public static String Eng_FileNm;
        public static String Eng_PMFileNm;
        public static string T_CellNo;
        public static Double SFCwt;
        public static Double SFCTm;
        public static Double SmkVal;
        public static Double BlBy;
        public static Double AvgPowPs;
        public static Double AvgPowkW;
        public static Double AvgRpm;
        public static Double AvgTrq;
        public static Double SFCVal;
        public static Double Bi_Val;
        public static Double fl_Rate;
        public static Double Corfact;
        //public static Double VarTrq;
        public static Double VarPowkW;
        public static Double VarPowPs;        
        public static String StrAlarm = "Alarm Status...";
        //public static String RunStatus;
        public static String ErrorMatrix;
        public static String MD1, MD2, MD3, MD4, MD5;

       
    
   
        public static void Create_OnLog(string Msg)
        {
            try
            {
                string CMnth = DateTime.Now.ToString("MMMyy");
                Open_LogConn(CMnth, "conLog");
                OleDbCommand cmd = new OleDbCommand("Insert into Tb_ONLog(EngNo,StepNo,RPM,Message,Dt,Tm) Values ('" + EngNo + "','" + StNo + "','" + varRPM + "','" + Msg + "','" + System.DateTime.Now.ToString("dd/MM/yy") + "','" + System.DateTime.Now.ToString("hh:mm:ss") + "')", conLog);
                cmd.ExecuteNonQuery();
                conLog.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15007",ex.Message);
            }
        }
       
       
       
        public static void Open_Connection(String db, String conNm)
        {
            try
            {
              //  OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0; Data Source=" + Global.PATH + db + ".accdb");
              ////OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source=" + Global.PATH + db + ".accdb");
              //  conn.Open();
                OleDbConnection conn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0; Data Source=" + Global.PATH + db + ".accdb; jet OLEDB:DATABASE Password = gen.edac ");
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
    
        public static void Open_DataConn(String db, String cNm)
        {
            try
            {
                OleDbConnection cn = new OleDbConnection("PROVIDER=Microsoft.JET.OLEDB.4.0; Data Source=" + Global.DataPath + db + ".accdb");
               
                cn.Open();

                if (cNm == "conData")
                {
                    if (cn.State == System.Data.ConnectionState.Open)
                    {
                        conData.Close();
                        conData = cn;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15011", ex.Message);  
            }

        }

        public static void Open_LogConn(String db, String cNm)
        {
            try
            {
                OleDbConnection cn = new OleDbConnection("PROVIDER=Microsoft.JET.OLEDB.4.0; Data Source= D:\\TestCell_" + T_CellNo + "\\" + "\\" + db + "\\" + "Log.accdb");
                //OleDbConnection cn = new OleDbConnection("PROVIDER=Microsoft.ACE.OLEDB.12.0; Data Source= D:\\TestCell_" + T_CellNo + "\\" + "\\" + db + "\\" + "Log.accdb");
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
                MessageBox.Show("Error Code:-15012", ex.Message);    
            }
        }

        public static void  Rd_Confg()
        {
            try
            {
                Open_Connection("General", "con");
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Tb_Std ORDER BY ID", con);
                OleDbDataReader Rd = cmd.ExecuteReader();
                int x = 0;
                while (Rd.Read())
                {
                    PNo[x] = Rd.GetValue(0).ToString();
                    PName[x] = Rd.GetValue(1).ToString();
                    PMin[x] = Rd.GetValue(3).ToString();
                    PMax[x] = Rd.GetValue(4).ToString();
                    PUnit[x] = Rd.GetValue(5).ToString();
                    PSName[x] = Rd.GetValue(6).ToString();
                    PMark[x] = Rd.GetValue(7).ToString();
                    x += 1;
                }

                OleDbCommand cmd1 = new OleDbCommand("SELECT * FROM Tb_Fixed ORDER BY N", con);
                OleDbDataReader Rd1 = cmd1.ExecuteReader();
                x = 0;
                while (Rd1.Read())
                {
                    fxd[x] = Convert.ToInt16(Rd1.GetValue(1));
                    x += 1;
                }


                OleDbCommand cmd2 = new OleDbCommand("SELECT * FROM Tb_PM ORDER BY N", con);
                OleDbDataReader Rd2 = cmd2.ExecuteReader();
                x = 0;
                while (Rd2.Read())
                {
                    Pm_PNo[x] = Convert.ToInt16(Rd2.GetValue(1)) ;
                    x += 1;
                }


                OleDbCommand cmd3 = new OleDbCommand("SELECT * FROM Tb_View ORDER BY N", con);
                OleDbDataReader Rd3 = cmd3.ExecuteReader();
                x = 0;
                while (Rd3.Read())
                {
                    vId[x] = Convert.ToInt16(Rd3.GetValue(1));
                    //vName[x] = Convert.ToInt16(Rd.GetValue(2));
                    //vUnit[x] = Convert.ToInt16(Rd.GetValue(3));
                    x += 1;
                }
                Global.con.Close();  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15013", ex.Message);
            }
        }
        public static void Rd_System()
        {
            try
            {
                Open_Connection("General", "con");
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM TbSys WHERE FileName = 'SystemPara'", con);
                OleDbDataReader Rd = cmd.ExecuteReader();
                Int16 x = 0;
                while (Rd.Read())
                {
                    for (x = 0; x <= (Rd.FieldCount - 1); x++)
                    {
                        sysIn[x] = Rd.GetValue(x).ToString();
                    }
                }
                Global.con.Close();   
                    MD1 = sysIn[22];
                    MD2 = sysIn[25];
                    MD3 = sysIn[28];
                    MD4 = sysIn[31];
                    MD5 = sysIn[34];
                    //if (sysIn[16] == "TRUE") flg_VolActive = 1; else flg_VolActive = 0;
                    //flg_rdMod = Convert.ToBoolean(sysIn[61]);
                    //flg_LoginRPM = Convert.ToBoolean(sysIn[64]);
                    //flg_RecorsPmData = Convert.ToBoolean(sysIn[15]);
                    //flg_simulateRPM = Convert.ToBoolean(sysIn[65]);
                    T_CellNo = sysIn[9];
                    Data_Dir = DateTime.Now.ToString("MMMyy");
                    DataPath = "D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15014", ex.Message); 
            }
        }
        public static DateTime DelayMs(int nMs)
        {
            try
            {

                System.DateTime ThisMoment = System.DateTime.Now;
                System.TimeSpan duration = new System.TimeSpan(0, 0, 0, 0, nMs);
                System.DateTime AfterWards = ThisMoment.Add(duration);
                while (AfterWards >= ThisMoment)
                {
                    System.Windows.Forms.Application.DoEvents();
                    ThisMoment = System.DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15015", ex.Message);
            }
                return System.DateTime.Now;            
            
        }
        ///////////////////////////////////////////////////////////////////////////////

       public static DateTime DelaySc(int nSeconds)
        {
            try
            {
                System.DateTime ThisMoment = System.DateTime.Now;
                System.TimeSpan duration = new System.TimeSpan(0, 0, 0, nSeconds, 0);
                System.DateTime AfterWards = ThisMoment.Add(duration);
                while (AfterWards >= ThisMoment)
                {
                    System.Windows.Forms.Application.DoEvents();
                    ThisMoment = System.DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15016", ex.Message);
            }
                return System.DateTime.Now;           
           
        }     

             //***************** 

    }
    
}
