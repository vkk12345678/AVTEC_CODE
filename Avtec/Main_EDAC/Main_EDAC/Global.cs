using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using Automation.BDaq;
using System.Globalization;
using System.IO.Ports;
using System.IO;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Windows.Forms;



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
        public static string[] bin0 = new string[8] { "0", "0", "0", "0", "0", "0", "0", "0" };
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
       
        public static String[] EcuNo = new String[60];
        public static String[] EcuName = new String[60];
        public static String[] EcuAdds = new String[60];
        public static String[] EcuMFa = new String[60];
        public static String[] EcuUnit = new String[60];
        public static String[] EcuSName = new String[60];
        public static String[] EcuMin = new String[60];
        public static String[] EcuMax = new String[60];
        public static String[] EcuMark = new String[60];
        

        public static int[] LimNo = new int[100];
        public static String[] PNo = new String[150];
        public static String[] PName = new String[150];
        public static String[] PSName = new String[150];
        public static String[] PUnit = new String[150];
        public static String[] PMin = new String[150];
        public static String[] PMax = new String[150];
        public static String[] PMark = new String[150];
        public static String[] GenData = new String[150];
        public static String[] ECUGenData = new String[150];
        public static String[] PmData = new String[20];

        public static string[] st1 = new string[8];
        public static string[] st2 = new string[8];

        //public static String[] EcuNo = new String[200];
        //public static String[] EcuName = new String[200];
        //public static String[] EcuSName = new String[200];
        //public static String[] EcuUnit = new String[200];
        //public static String[] EcuMin = new String[200];
        //public static String[] EcuMax = new String[200];
        //public static String[] EcuPMark = new String[150];


        public static string smkbuffer;
        public static String[] arr = new String[50];
        public static String CStrtTm;
        public static String CStopTm;
        public static String Log_Data;


        public static String[] ECUData = new String[150];
        public static String[] Data = new String[150];
        public static String[] fData = new String[130];
        public static String[] ArrData = new String[130];
        public static String[] PmArr = new String[150];
        public static String[] Arr = new String[5];

        public static Boolean flg_SMOKE_COM = false;

        public static SerialPort MSPort = new SerialPort();
        public static SerialPort RTPort = new SerialPort();
        public static SerialPort ADPortG1 = new SerialPort();
        public static SerialPort ADPortG2 = new SerialPort();


        public static SerialPort PIDPort = new SerialPort();
        public static SerialPort BlPort = new SerialPort();
        public static SerialPort mbPort = new SerialPort();
        public static SerialPort scPort = new SerialPort();
        public static SerialPort smkPort = new SerialPort();
        public static int cntlist = 0;

        public static Boolean flg_fstart = false;
        public static Boolean flg_fstop = false;

        public static Boolean flg_OffLim = true;
        public static Boolean flg_IdleLim = true;
        public static Boolean flg_AlarmLim = false;



        public static Automation.BDaq.InstantDoCtrl InstantDO = new InstantDoCtrl();
        public static Automation.BDaq.InstantDiCtrl InstantDI = new InstantDiCtrl();
        public static Automation.BDaq.InstantAoCtrl InstantAO = new InstantAoCtrl();
        public static Automation.BDaq.InstantAiCtrl InstantAI = new InstantAiCtrl();
        //public static Automation.BDaq.FreqMeterCtrl InstantFrq = new FreqMeterCtrl(); 

        public static int smk = 1;
        public static int ISn = 0;
        public static int smkCn = 1;
        public static Double Ex_Bk = 1;

        public static int SnT = 0;

        public static int S_Rpm = 800;
        //public static int I_Rpm = 0;
        //public static int F_Rpm = 0;
        //public static Double Max_Pow = 0;
        //public static Double Pow_RPM = 0;
        //public static Double Max_Trq = 0;
        //public static Double Trq_RPM = 0;

        public static Double MinPow = 00.0;
        public static Double MaxSmoke = 75.0;
        public static Double MaxFD = 99.99;
        public static Double SPARE_1 = 00.00;
        public static Double SPARE_2 = 00.00;
        public static Double SPARE_3 = 00.00;
        public static Double SPARE_4 = 00.00;
        public static Double SPARE_5 = 00.00;
        public static Boolean flg_PassLim = false;
        public static Boolean flg_DoOut1 = false;
        public static Boolean flg_DoOut2 = false;
        public static Boolean flg_DoOut3 = false;



        public static String SetPtTc = "0";
        public static String SetPtDc = "0";
        public static String AOvar = "0";





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

        public static String StpComm;


        public static readonly Random random = new Random();


        public static int loopcount = 0;
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

        public static int[] vId = new int[20];
        public static String[] vIdName = new string[20];
        public static int vIdNo = 0;
        public static int L_Cn = 0;


        public static Boolean flg_EngStart = false;
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
        public static double[] m_data = new double[16];
        public static string[] GetData = new string[16];
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
        public static String[] arrIdle_1 = new String[15];
        public static String[] arrIdle_2 = new String[15];
        public static String[] arrIdle_3 = new String[15];




        public static String SFC_Msg_from_Inst = "";
        public static String SFC_Status = "";
        public static string modcnt;
        public static Double E_Pow;
        public static Boolean Flg_AList = true;

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


        public static string adamBuf1 = "";


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

        public static Int16 ADAMCnt = 1;
        public static Int16 ChnCnt = -1;
        public static int stopid;

        public static int LogCnt = 0;

        public static String S_Out = "00";
        public static Int16 R_Add = 0;
        public static Int16 I_Add = 0;
        public static Int16 S_Add = 0;
        public static String A_Out = "00";
        public static Int16 A_Add = 0;
        public static string EngType = "";
        public static string TestTyp = "";
        public static string Turbo_No = "";

        public static int Sn = 0;
        public static int Ecn = 0;

        public static int ErrSn = 0;
        public static int LogTm = 0;
        public static int LTm = 0;


        public static string Bor = "100";
        public static string NCyl = "2";
        public static string Strk = "100";
        public static string Svol = "1.5";
        public static string SGrv = "0.835";
        public static string FuelType = "";
        public static String EngNo;        
        public static String EngineNo;

        public static string Inj_01;
        public static string Inj_02;
        public static string Inj_03;
        public static string Inj_04;


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
        public static Int16 LogCounter;
        public static string cumhours = "0000:00:00";

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
        public static String Log_Time;


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



        public static Double AnaOut1 = 0.01;
        public static Double AnaOut2 = 0.01;
        public static Double LastAna1 = 0;
        public static Double LastAna2 = 0;
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
        public static String Eng_ECU_FileNm;
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
        public static int StpN = 1;
        public static string[] ChkLim = new string[10];

        public static int cntDSafty = 0;
        public static Boolean flg_ChlLim = false;

        public static Boolean flg_smokeStart = false;
        public static String[] scrn_Par = new String[80];


        // For Passout Limits............//
        public static Double[] passoutMin = new Double[10];
        public static Double[] passoutMax = new Double[10];

        // Passout limits storing In Database //
        public static string[] Tb_passoutMin = new string[10];
        public static string[] Tb_passoutMax = new string[10];

       // public static frmMain main = new frmMain();

       /// public static frmMain main = new frmMain(); 

        public static Boolean flg_frmManual = false;
        public static Boolean flg_NewFile = false;
        public static Boolean flg_OldFile = false;
        public static Boolean flg_DataSave = false;
        public static string MySqlPW;

        public static SerialPort ComPort = new SerialPort();
        public static Parity P;
        public static string comn;
        public static int Bd = 9600;
        public static int Addr;
        public static int cnt = 0;
        public static StopBits stopbt; 
        // public static void Rd_Pwd()
        //{

        //    // string path = "C:\\";
        //    //File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Normal);
        //    FileStream fs2 = new FileStream("C:\\edac.txt", FileMode.Open, FileAccess.Read);
        //    StreamReader reader = new StreamReader(fs2);
        //    String InPut = reader.ReadToEnd();
        //    int pos1 = 1;
        //    int pos2 = 1;
        //    pos1 = InPut.IndexOf("@", 0);
        //    pos2 = InPut.IndexOf("@", (pos1 + 1));
        //    MySqlPW = InPut.Substring(pos1 + 1, (pos2 - pos1 - 1));
        //    reader.Close();

        //    //File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);

        //}

        public static void ConfigDevice()
        {

            if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1) System.Diagnostics.Process.GetCurrentProcess().Kill();
            string deviceinfo = sysIn[3];
            int deviceNo = int.Parse(sysIn[3].Substring(13));
            try
            {
                InstantAO.SelectedDevice = new DeviceInformation(deviceNo, deviceinfo, AccessMode.ModeWrite, 0);
                InstantAO.Channels[0].ValueRange = ValueRange.V_0To10;
                InstantAO.Channels[1].ValueRange = ValueRange.V_0To10;
                //***********************
                InstantDI.SelectedDevice = new Automation.BDaq.DeviceInformation(deviceNo, deviceinfo, AccessMode.ModeRead, 0);

                //InstantDI.SelectedDevice = new DeviceInformation(deviceNo, "PCI-1716,BID#1", AccessMode.ModeWrite, 0);

                //InstantDI.SelectedDevice = new Automation.BDaq.DeviceInformation(deviceNo);

                ///***********************************
                InstantDO.SelectedDevice = new Automation.BDaq.DeviceInformation(deviceNo, deviceinfo, AccessMode.ModeWrite, 0);

                ///************************************
                InstantAI.SelectedDevice = new DeviceInformation(deviceNo, deviceinfo, AccessMode.ModeRead, 0);
                Global.Create_OnLog("DEVICE READ SUCCESSFULLY", "Normal");
            }
            catch (Exception ex)
            {
                DialogResult result1 =
                     MessageBox.Show("ERROR : ..." + "\n\n" +
                                     "1.Invalid Device No ........!" + "\n\n" +
                                     "OR 2.Decive is Not available...." + "\n\n" +
                                     "OR 3 Already Application Is running", "SYSTEM ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
                if (result1 == DialogResult.OK)
                {
                    //Login frm = new Login();
                    //frm.ShowDialog();
                    //frm.Dispose();
                    if (Global.flg_Log_service == true)
                    {
                        //frmSysPara frm1 = new frmSysPara();
                        // frm1.ShowDialog();
                        //frm1.Dispose();
                    }
                    return;
                }


            }
        }

        //public static void Rd_SerialPort_RT()
        //{
        //    String buffer = "";
        //    try
        //    {
        //        buffer = (RTPort.ReadExisting());
        //        bufftss4 = buffer;

        //        char[] chars = buffer.ToCharArray();
        //        for (int i = 0; i < buffer.Length; i++)
        //        {
        //            int code;
        //            code = Convert.ToInt16(chars[i]);
        //            if (!(((code <= 57) && (code >= 48)) || (code == 46) || (code == 42) || (code == 88) || (code == 43) || (code == 37) || (code == 45)))
        //            {
        //                buffer = buffer + chars[i];
        //                return;
        //            }
        //        }

        //        if ((buffer != "") && (buffer.Length >= 10) && (buffer.Substring(5, 5) != "XXXXX"))
        //        {
        //            Int16 pos;
        //            pos = Convert.ToInt16(buffer.IndexOf("X", 1)); //InStr(1, Buffer, "X")
        //            int L = int.Parse(buffer.Substring(pos - 2, 2));
        //            if (L == 2)
        //                SFC_Msg_from_Inst = buffer.Substring(0, 6);

        //            S_Out = (buffer.Substring(1, 2));
        //            Global.GenData[int.Parse(S_Out)] = buffer.Substring(5, 5);
        //        }
        //        else if ((buffer != "") && (buffer.Length >= 10) && (buffer.Substring(5, 5) == "XXXXX"))
        //        {
        //            S_Out = (buffer.Substring(1, 2));
        //            Global.GenData[int.Parse(S_Out)] = "88888";
        //        }
        //        RTPort.DiscardInBuffer();
        //        if (I_Add > 6) I_Add = 0; else I_Add += 1;
        //        switch (I_Add)
        //        {
        //            case 0:
        //                RTPort.Write("*00T%");
        //                break;
        //            case 1:
        //                //case 2:
        //                RTPort.Write("*01T%");
        //                break;
        //            case 2:
        //                if ((Global.SFC_Reset == true) && (Global.GenData[2] == "11111")) //(SFC_Msg_from_Inst == "*02X11"))
        //                {
        //                    RTPort.Write("*02R%");
        //                    Global.flg_SFCReset = false;
        //                    SFC_Status = "SFC RESET";
        //                    Global.flg_SFCStart = true;
        //                    Global.SFC_Reset = false;
        //                }
        //                else
        //                {
        //                    RTPort.Write("*02T%");
        //                }

        //                break;
        //            case 3:
        //                RTPort.Write("*03T%");
        //                break;
        //            case 4:
        //                RTPort.Write("*04T%");
        //                break;
        //            case 5:
        //                RTPort.Write("*05T%");
        //                break;
        //        }
        //    }
        //    catch
        //    {
        //        //RTPort.Write("*00T%");
        //        Global.Create_OnLog(" :  Rd_SerialPort()....", "Alert");
        //        return;
        //        //MessageBox.Show("read serial Port String Not proper: "+ I_Add +":-" + buffer );
        //    }

        //}



        //public static void Rd_SerialPort_RT()
        //{
        //    String buffer = "";
        //    try
        //    {  
        //        buffer = (RTPort.ReadExisting());
        //        bufftss8 = buffer;

        //        //char[] chars = buffer.ToCharArray();
        //        //for (int i = 0; i < buffer.Length; i++)
        //        //{
        //        //    int code;
        //        //    code = Convert.ToInt16(chars[i]);
        //        //    if (!(((code <= 57) && (code >= 48)) || (code == 46) || (code == 42) || (code == 88) || (code == 43) || (code == 37) || (code == 45)))
        //        //    {
        //        //        buffer = buffer + chars[i];
        //        //        //return;
        //        //    }
        //        //}
        //        if ((buffer != "") && (buffer.Length >= 10) && (buffer.Substring(5, 5) != "XXXXX"))
        //        {
        //            Int16 pos;
        //            pos = Convert.ToInt16(buffer.IndexOf("X", 1)); //InStr(1, Buffer, "X")
        //            int L = int.Parse(buffer.Substring(pos - 2, 2));
        //            //int L = I_Add; 
        //            if (L == 2)
        //            {

        //                pos = Convert.ToInt16(buffer.IndexOf("*", 1));
        //                SFC_Msg_from_Inst = buffer.Substring(0, 6);
        //                GenData[2] = SFC_Msg_from_Inst;

        //            }
        //            else if (L == 0)
        //            {
        //                double M = Convert.ToDouble(buffer.Substring(5, 5));
        //                Global.varRPM = (Int16)M;
        //                GenData[0] = varRPM.ToString("0000");
        //            }
        //            else if (L == 1)
        //            {
        //                Double N = Convert.ToDouble(buffer.Substring(5, 5));
        //                GenData[1] = N.ToString("000.0");
        //                varTRQ = N;
        //            }
        //            else if (L == 3)
        //            {
        //                double M = Convert.ToDouble(buffer.Substring(5, 5));
        //                //Global.varRPM = (Int16)M;
        //                GenData[3] = M.ToString("000.0");
        //            }
        //            else if (L == 4)
        //            {
        //                Double N = Convert.ToDouble(buffer.Substring(5, 5));
        //                GenData[4] = N.ToString("000.0");
        //                //varTRQ = N;
        //            }
        //            else if (L == 5)
        //            {
        //                Double N = Convert.ToDouble(buffer.Substring(5, 5));
        //                GenData[5] = N.ToString("000.0");
        //                //varTRQ = N;
        //            }

        //            ////else if (L == 10)
        //            ////{
        //            ////    Double N = Convert.ToDouble(buffer.Substring(5, 5));
        //            ////    GenData[8] = (N * 1000).ToString("0000");
        //            ////    //varLUB = N;
        //            ////}
        //            //else if (L == 14)
        //            //{
        //            //    Double N = Convert.ToDouble(buffer.Substring(5, 5));
        //            //    GenData[9] = N.ToString("0.000");
        //            //    varLUB = N;
        //            //}
        //            else
        //            {
        //                //if (buffer.Substring(4, 1) == "+")
        //                //{
        //                //    S_Out = (buffer.Substring(1, 2));
        //                //    Global.GenData[int.Parse(S_Out)] = buffer.Substring(5, 5);
        //                //}
        //                //else
        //                //{
        //                //    S_Out = (buffer.Substring(1, 2));
        //                //    Global.GenData[int.Parse(S_Out)] = buffer.Substring(4, 6);
        //                //}
        //            }

        //            //S_Out = (buffer.Substring(1, 2));
        //            bufftss8 = buffer;

        //        }
        //        else if ((buffer != "") && (buffer.Length >= 10) && (buffer.Substring(5, 5) == "XXXXX"))
        //        {
        //            S_Out = (buffer.Substring(1, 2));
        //            Global.GenData[int.Parse(S_Out)] = "88888";
        //        }

        //        if (R_Add >= 7) R_Add = 0; else R_Add += 1;
        //        RTPort.DiscardInBuffer();
        //        switch (R_Add)
        //        {
        //            case 0:
        //                RTPort.Write("*00T%");
        //                break;
        //            case 1:
        //                RTPort.Write("*01T%");
        //                break;
        //            case 2:
        //                if ((Global.SFC_Reset == true) && (SFC_Msg_from_Inst == "*02X11"))
        //                {
        //                    RTPort.Write("*02R%");
        //                    System.Threading.Thread.Sleep(500); // Global.DelayMs(30);
        //                    SFC_Status = "SFC RESET";
        //                    Global.flg_SFCStart = true;
        //                    Global.SFC_Reset = false;
        //                    Global.Auto_SFC = false;
        //                }
        //                else
        //                {
        //                    RTPort.Write("*02T%");
        //                }
        //                break;
        //                if ((Global.SFC_Reset == true) && (SFC_Msg_from_Inst == "_OVER_"))
        //                {
        //                    RTPort.Write("*02R%");
        //                    Thread.Sleep(500); 
        //                    SFC_Status = "SFC RESET";
        //                    Global.SFC_Reset = false;
        //                    Global.flg_SFCStart = true;
        //                    Global.Auto_SFC = false;                           
        //                }
        //                else
        //                {
        //                    RTPort.Write("*02T%");                           
        //                }
        //                break;
        //            case 3:
        //                RTPort.Write("*03T%");
        //                break;
        //            case 4:
        //                RTPort.Write("*04T%");
        //                break;
        //            case 5:
        //                RTPort.Write("*05T%");
        //                break;
        //            //case 6:
        //            //    RTPort.Write("*10T%");
        //            //    break;
        //            case 6:
        //                RTPort.Write("*14T%");
        //                break;
        //            //case 7:
        //            //    RTPort.Write("*07T%");
        //            //    break;
        //            //case 8:
        //            //    RTPort.Write("*10T%");
        //            //    break;
        //            //case 9:
        //            //    RTPort.Write("*14T%");
        //            //    break;


        //        }

        //        //msPort.DiscardInBuffer();

        //    }
        //    catch
        //    {
        //        Global.Create_OnLog( " :  Rd_SerialPort()....", "Alart");  
        //        return;
        //        //msPort.Write("*" + I_Add + "%");
        //        //if (I_Add >= 24) I_Add = 0; 
        //        //MessageBox.Show("read serial Port String Not proper: " + I_Add + ":-" + buffer);
        //    }

        //}


        //***************************************




        //public static void Rd_SerialPort()
        //{
        //    String buffer = "";
        //    try
        //    {
        //        buffer = (msPort.ReadExisting());
        //        //bufftss4 = buffer;

        //        char[] chars = buffer.ToCharArray();
        //        for (int i = 0; i < buffer.Length; i++)
        //        {
        //            int code;
        //            code = Convert.ToInt16(chars[i]);
        //            if (!(((code <= 57) && (code >= 48)) || (code == 46) || (code == 42) || (code == 88) || (code == 43) || (code == 37) || (code == 45)))
        //            {
        //                buffer = buffer + chars[i];
        //                //return;
        //            }
        //        }
        //        if ((buffer != "") && (buffer.Length >= 10) && (buffer.Substring(5, 5) != "XXXXX"))
        //        {
        //            Int16 pos;
        //            pos = Convert.ToInt16(buffer.IndexOf("X", 1)); //InStr(1, Buffer, "X")
        //            int L = int.Parse(buffer.Substring(pos - 2, 2));                   
        //            if (L == 2)
        //            {
        //                pos = Convert.ToInt16(buffer.IndexOf("*", 1));
        //                SFC_Msg_from_Inst = buffer.Substring(0, 6);
        //                GenData[2] = SFC_Msg_from_Inst;

        //            }
        //            else if (L == 0)
        //            {
        //                double M = Convert.ToDouble(buffer.Substring(5, 5));
        //                Global.varRPM = (Int16)M;
        //                GenData[0] = varRPM.ToString("0000");
        //            }
        //            else if (L == 1)
        //            {
        //                Double N = Convert.ToDouble(buffer.Substring(5, 5));
        //                GenData[1] = N.ToString("000.0");
        //                varTRQ = N;
        //            }
        //            else
        //            {
        //                if (buffer.Substring(4, 1) == "+")
        //                {
        //                    S_Out = (buffer.Substring(1, 2));
        //                    Global.GenData[int.Parse(S_Out)] = buffer.Substring(5, 5);
        //                }
        //                else
        //                {
        //                    S_Out = (buffer.Substring(1, 2));
        //                    Global.GenData[int.Parse(S_Out)] = buffer.Substring(4, 6);
        //                }
        //            }

        //            S_Out = (buffer.Substring(1, 2));
        //            bufftss4 = buffer;

        //        }
        //        else if ((buffer != "") && (buffer.Length >= 10) && (buffer.Substring(5, 5) == "XXXXX"))
        //        {
        //            S_Out = (buffer.Substring(1, 2));
        //            Global.GenData[int.Parse(S_Out)] = "88888";
        //        }
        //        //msPort.DiscardInBuffer();
        //        if (I_Add >= 20) I_Add = 0; else I_Add += 1;
        //        msPort.DiscardInBuffer();
        //        switch (I_Add)
        //        {
        //            case 0:
        //                msPort.Write("*00T%");
        //                break;
        //            case 1:                       
        //                msPort.Write("*01T%");
        //                break;
        //            case 2:
        //                if ((Global.SFC_Reset == true) && (SFC_Msg_from_Inst == "*02X11"))
        //                {
        //                    msPort.Write("*02R%");
        //                    Global.flg_SFCReset = false;
        //                    SFC_Status = "SFC RESET";
        //                    SFC_msg = "SFC RESET";
        //                    Global.flg_SFCStart = true;
        //                    Global.SFC_Reset = false;
        //                    //Global.Auto 
        //                }
        //                else
        //                {
        //                    msPort.Write("*02T%");
        //                    ////SFC_msg = "SFC STATUS";
        //                }
        //                break;
        //            case 3:
        //                msPort.Write("*03T%");
        //                break;
        //            case 4:
        //                msPort.Write("*04T%");
        //                break;
        //            case 5:
        //                msPort.Write("*05T%");
        //                break;
        //            case 6:
        //                msPort.Write("*06T%");
        //                break;
        //            case 7:
        //                msPort.Write("*07T%");
        //                break;                   
        //            case 8:
        //                msPort.Write("*10T%");
        //                break;
        //            case 9:
        //                msPort.Write("*11T%");    //("*11T%");//
        //                break;
        //            case 10:
        //                msPort.Write("*102T%");  //("*12T%");
        //                break;
        //            case 11:
        //                msPort.Write("*13T%"); //("*13T%");
        //                break;
        //            case 12:
        //                msPort.Write("*16T%"); //("*16T%");
        //                break;
        //            case 13:
        //                msPort.Write("*17T%"); //("*17T%");
        //                break;
        //            case 14:
        //                msPort.Write("*18T%"); //("*18T%");
        //                break;
        //            case 15:
        //                msPort.Write("*20T%"); //("*19T%");
        //                break;
        //            case 16:
        //                msPort.Write("*21T%"); //("*20T%");
        //                break;
        //            case 17:
        //                msPort.Write("*22T%"); //("*21T%");
        //                break;
        //            case 18:
        //                msPort.Write("*23T%"); //("*22T%");
        //                break;
        //            //case 19:
        //            //    msPort.Write("*23T%"); //("*23T%");
        //            //    break;

        //        }

        //        //msPort.DiscardInBuffer();

        //    }
        //    catch
        //    {
        //        return;
        //        //msPort.Write("*" + I_Add + "%");
        //        //if (I_Add >= 24) I_Add = 0; 
        //        //MessageBox.Show("read serial Port String Not proper: " + I_Add + ":-" + buffer);
        //    }

        //}

        public static void Rd_SerialPort()
        {
            String buffer = "";
            try
            {

                //buffer = (MSPort.ReadExisting());
                //bufftss4 = buffer;

                //char[] chars = buffer.ToCharArray();
                //for (int i = 0; i < buffer.Length; i++)
                //{
                //    int code;
                //    code = Convert.ToInt16(chars[i]);
                //    if (!(((code <= 57) && (code >= 48)) || (code == 46) || (code == 42) || (code == 88) || (code == 43) || (code == 37) || (code == 45)))
                //    {
                //        buffer = buffer + chars[i];
                //        //return;
                //    }
                //}



                //if ((buffer.Substring(3, 1) == "X") && (buffer.Substring(10, 1) == "%"))
                //{
                //    bufftss4 = buffer;
                //    //char[] chars = buffer.ToCharArray();
                //    for (int i = 0; i <= 15; i++) // buffer.Length; i++)
                //    //for (int i = 0; i <= buffer.Length; i++) 
                //    {
                //        int code;
                //        code = Convert.ToInt16(chars[i]);
                //        //if (code == 
                //        if (!(((code <= 57) && (code >= 47)) || (code == 46) || (code == 42) || (code == 88) || (code == 43) || (code == 37) || (code == 45)))
                //        {
                //            buffer = buffer + chars[i];
                //            return;
                //        }
                //    }
                //}
                //if ((buffer != "") && (buffer.Length >= 10) && (buffer.Substring(5, 5) != "XXXXX"))
                //{
                //    Int16 pos;
                //    pos = Convert.ToInt16(buffer.IndexOf("X", 1));
                //    int L = int.Parse(buffer.Substring(pos - 2, 2));

                //    if (buffer.Substring(4, 1) == "+")
                //    {
                //        S_Out = (buffer.Substring(1, 2));
                //        Global.GenData[int.Parse(S_Out)] = buffer.Substring(5, 5);
                //    }
                //    else
                //    {
                //        S_Out = (buffer.Substring(1, 2));
                //        Global.GenData[int.Parse(S_Out)] = buffer.Substring(4, 6);
                //    }
                //}
                //else if ((buffer != "") && (buffer.Length >= 10) && (buffer.Substring(5, 5) == "XXXXX") && (buffer.Substring(1, 1) == "*"))
                //{

                //    S_Out = (buffer.Substring(1, 2));
                //    //if (S_Out == "07") Global.GenData[int.Parse(S_Out)] = Simul_1.ToString();
                //    //else if (S_Out == "10") Global.GenData[int.Parse(S_Out)] = Simul_2.ToString();
                //    //else if (S_Out == "13") Global.GenData[int.Parse(S_Out)] = Simul_3.ToString();
                //    //else
                //    Global.GenData[int.Parse(S_Out)] = "88888";
                //}




                MSPort.Close();
                ////msPort.DiscardInBuffer();
                if (!Global.MSPort.IsOpen == true) Global.MSPort.Open();

                MSPort.Write("*00T%");

                System.Threading.Thread.Sleep(40);

                buffer = (MSPort.ReadExisting());
                bufftss4 = buffer;

               
                 Global.GenData[0] = buffer.Substring(5, 5);
                 SnT = 1;
                 ADAMCnt = 1;

                //GenData[0] =  

                //if (I_Add >= 16) I_Add = 0; else I_Add += 1;
                //switch (I_Add)
                //{

                //    case 0:
                //        MSPort.Write("*06T%");
                //        break;
                //    case 1:
                //        MSPort.Write("*07T%");
                //        break;
                //    case 2:
                //        MSPort.Write("*10T%");
                //        break;
                //    case 3:
                //        MSPort.Write("*11T%");
                //        break;
                //    case 4:
                //        MSPort.Write("*12T%");
                //        break;
                //    case 5:
                //        MSPort.Write("*13T%");
                //        break;
                //    case 6:
                //        MSPort.Write("*16T%");
                //        break;
                //    case 7:
                //        MSPort.Write("*17T%");
                //        break;
                //    case 8:
                //        MSPort.Write("*18T%");
                //        break;
                //    case 9:
                //    //MSPort.Write("*19T%");
                //    //break;
                //    case 10:
                //        MSPort.Write("*20T%");
                //        break;
                //    case 11:
                //        MSPort.Write("*21T%");
                //        break;
                //    case 12:
                //        MSPort.Write("*22T%");
                //        break;
                //    case 13:
                //        MSPort.Write("*23T%");
                //        break;
                //    case 14:
                //        MSPort.Write("*24T%");
                //        break;
                //}
            }
            catch (Exception ex)
            {

                //MSPort.Write("*00T%");
                //if (I_Add >= 21) I_Add = 0; else I_Add += 1;
                //I_Add += 1;
                Global.Create_OnLog(ex.Message + " :  Read SerialPort()....", "Alert");
                return;
                //MessageBox.Show("read serial Port String Not proper: " + I_Add + ":-" + buffer);
            }

        }

        public static double RandomNumberBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();
            return minValue + (next * (maxValue - minValue));
        }

        public static void ReadRPM()
        {
            //Automation.BDaq.ErrorCode err;
            //err = InstantFrq.Read(0, f_data);
            //Global.GenData[0]  = f_data[0].ToString() ; 
        }

        public static void Read_ModbusValues()
        {
            try
            {
                string[] PIDArr = new string[8];

                string path1 = Application.StartupPath;
                FileStream fs2 = new FileStream(path1 + "\\ModBus.txt", FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader reader = new StreamReader(fs2);
                String InPut = reader.ReadToEnd();
                reader.Close();
                //PIDArr[0] = InPut;
                GenData[69] = InPut;
                //string pattern = @"(,)";
                //Regex regex = new Regex(pattern);
                //int x = 0;
                //foreach (string result in regex.Split(InPut))
                //{
                //    if (result != ",")
                //    {
                //        PIDArr[x] = result;
                //        x++;
                //    }
                //}
                //reader.Close();
                //Global.GenData[87] = PIDArr[0];
                //Global.GenData[88] = PIDArr[1];
                //Global.GenData[89] = PIDArr[2];
                //Global.GenData[90] = PIDArr[3];
                //Global.GenData[91] = PIDArr[4];




            }
            catch (Exception ex)
            {
                return;
            }
        }


        public static void ReadAnalog()
        {
            try
            {
                Automation.BDaq.ErrorCode err;

                int D;

                Double Range = 0.0;
                for (int i = 0; i < 7; i++)
                {
                    double Mn = 0.0;
                    Double Mx = 0.0;
                    Double l = 0.0;

                    D = 61 + i;
                    err = InstantAI.Read(0, 8, m_data);
                    Mn = Double.Parse(PMin[D]);
                    Mx = Double.Parse(PMax[D]);
                    Range = (Mx - Mn);
                    l = m_data[i] * Range / 10;
                    //if (i == 2)
                    //{
                    //    Double X = (l * double.Parse(Global.GenData[31]) * 100000 * 60) / (287 * (273.15 + double.Parse(Global.GenData[43])));
                    //    GenData[D] = X.ToString("000.00");
                    //}
                    //else
                    GenData[D] = l.ToString("000.00");
                }


            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Read Analog Value  .....", "Alert");

                ////MessageBox.Show("Error Code:- 15003", ex.Message);
            }
        }

        public static void Make_mdb(String mdbPath)
        {
            try
            {
                Global.Data_Dir = DateTime.Now.ToString("MMMyy");
                //Global.OnLog_Data = "OnLog_" + DateTime.Now.ToString("ddMMMyy");
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
                if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\ECU_Data") == false)
                {
                    System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\ECU_Data");
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error:Problem in creating data base ...");
                Create_OnLog("Problem In Creating DataBase ........MakeMDB..", "Alert");
            }

        }

        public static void Create_OnLog(string Msg, String state)//,int Icon)
        {
            try
            {
                Global.Data_Dir = DateTime.Now.ToString("MMMyy");
                //string OnLog_Data = System.DateTime.Now.ToString() + "_OnLogData";
                 OnLog_Data = "OnLog_Data_" + DateTime.Now.ToString("ddMMMyy");

                Global.I_Tm = System.DateTime.Now.ToString(); // ("hh:mm:ss tt");

                if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\") == false)
                {
                    System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir);
                }
                if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Log_Data") == false)
                {
                    System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Log_Data");
                }
                if (System.IO.File.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Log_Data\\" +  OnLog_Data + ".csv") == false)
                {
                    System.IO.File.Create("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Log_Data\\" +  OnLog_Data + ".csv");
                }


                String strData = I_Tm + ",      " + Global.EngNo + ",     " + StNo + ",     " + varRPM + ",     " + Msg + ",     " + state;
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

        //public static void Create_OnLog(string Msg)
        //{
        //    try
        //    {
        //        if (Global.flg_CylStart == true)
        //        {
        //            SnEr++;
        //            Global.I_Tm = System.DateTime.Now.ToString("hh:mm:ss tt");
        //            String strData = Global.EngNo + ", " + Global.StNo + ", " + Global.varRPM + ", " + Msg + ", " + Global.I_Tm + ", " + Global.SnEr + ",\n";

        //            var filePath = Global.DataPath + "Error_Data\\" + Global.Eng_Error_FileNm + ".csv";
        //            using (var wr = new StreamWriter(filePath, true))
        //            {
        //                var row = new List<string> { strData.Substring(0, strData.Length - 1) };
        //                var sb = new StringBuilder();
        //                foreach (string value in row)
        //                {
        //                    if (sb.Length > 0)
        //                        sb.Append(",");
        //                    sb.Append(value);
        //                }
        //                wr.WriteLine(sb.ToString());
        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error Code:- 15007", ex.Message);
        //    }

        //}


        public static void Open_PMConn(String db, String cPm)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection("server = localhost; user id = root; password = dynalec; database =" + db);
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
                Global.Create_OnLog(ex.Message + " :  Open PM Connecton....", "Alert");
                //MessageBox.Show("Error Code:-15013", ex.Message);
            }
        }

        public static void Open_LogConn(String db, String cNm)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection("server = localhost; user id = root; password = dynalec; database =" + db);
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
                Global.Create_OnLog("Data log Connection......", "Alert");
            }
        }
        public static void Open_DataConn(String db, String cNm)
        {
            try
            {
                //OleDbConnection cn = new OleDbConnection("PROVIDER=Microsoft.Jet.OLEDB.4.0; Data Source=" + Global.DataPath + db + ".accdb");
                MySqlConnection cn = new MySqlConnection("server = localhost; user id = root; password = dynalec; database =" + db);
                cn.Open();

                if (cNm == "conData")
                {
                    if (cn.State == System.Data.ConnectionState.Open)
                    {
                        conData.Close();
                        conData = cn;
                    }
                }
                MySqlConnection fcn = new MySqlConnection("server = localhost; user id = root; password = dynalec; database =" + db);
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
                Global.Create_OnLog("Data Connection .......", "Alert");
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
                MessageBox.Show("ErrorCode :- 2002" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
               // MessageBox.Show("Error Code:- 15008", ex.Message);
            }

        }

        public static void Read_DigIn()
        {
            try
            {

                Automation.BDaq.ErrorCode err;
                //InstantDI.SelectedDevice = new Automation.BDaq.DeviceInformation(1, "PCI-1716,BID#1", AccessMode.ModeWrite, 0);
                //txtDi.Text = "";
                byte dIportData = 0;
                err = InstantDI.Read(1, out dIportData);
                string dIbinaryval = "";
                dIbinaryval = Convert.ToString(Convert.ToInt32(dIportData.ToString("X2"), 16), 2);
                long Sr1 = Convert.ToUInt32(dIbinaryval);
                String S1 = Sr1.ToString("00000000");

                dIbinaryval = "";
                err = InstantDI.Read(0, out dIportData);
                dIbinaryval = Convert.ToString(Convert.ToInt32(dIportData.ToString("X2"), 16), 2);
                long Sr2 = Convert.ToUInt32(dIbinaryval);
                String S2 = Sr2.ToString("00000000");
                String S = S1 + S2;

                for (int i = 0; i <= S.Length - 1; i++)
                {
                    DigIn[i] = int.Parse(S.Substring((S.Length - i) - 1, 1));
                }

            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Tb_DigIn ", "Alert");
                //MessageBox.Show("Error Code:- 15009" +ex.Message );
                return;
            }
        }

        public static void Dig_OutBit(int port, int Bt, Boolean State)
        {

            try
            {
                Automation.BDaq.ErrorCode err;
                string str = "";
                if (port == 0)
                {
                    if (State == true) bin0[Bt] = "1"; else bin0[Bt] = "0";
                    for (int i = 7; i >= 0; i--)
                    {
                        str = str + bin0[i];
                        DigOut[i] = bin0[i];
                    }
                    Ds1 = str;
                    string output = "";
                    for (int i = 0; i <= str.Length - 4; i += 4)
                    {
                        output += string.Format("{0:X}", Convert.ToByte(str.Substring(i, 4), 2));
                    }
                    int state = Int32.Parse(output, NumberStyles.AllowHexSpecifier);

                    err = InstantDO.Write(port, (byte)state);
                }
                else if (port == 1)
                {
                    if (State == true) bin1[Bt] = "1"; else bin1[Bt] = "0";
                    for (int i = 7; i >= 0; i--)
                    {
                        str = str + bin1[i];
                        DigOut[i + 8] = bin1[i];
                    }
                    Ds2 = str;
                    string output = "";
                    for (int i = 0; i <= str.Length - 4; i += 4)
                    {
                        output += string.Format("{0:X}", Convert.ToByte(str.Substring(i, 4), 2));
                    }
                    int state = Int32.Parse(output, NumberStyles.AllowHexSpecifier);
                    err = InstantDO.Write(port, (byte)state);
                }

            }
            catch (Exception ex)
            {
                Global.Create_OnLog("DG_OUT", "Alert");
            }

        }
        public static void Mode_Out(int DOutA, int DOutB, int DOutC)
        {
            if (DOutA == 1) Dig_OutBit(0, 3, true); else Dig_OutBit(0, 3, false);
            if (DOutB == 1) Dig_OutBit(0, 4, true); else Dig_OutBit(0, 4, false);
            if (DOutC == 1) Dig_OutBit(0, 5, true); else Dig_OutBit(0, 5, false);
        }

        public static void Rd_ECU_Confg()
        {
            try
            {
                Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_ecu ORDER BY ParameterNo", con);
                MySqlDataReader Rd = cmd.ExecuteReader();
                int x = 0;
                while (Rd.Read())
                {
                    EcuNo[x] = Rd.GetValue(0).ToString();
                    EcuName[x] = Rd.GetValue(1).ToString();
                    EcuAdds[x] = Rd.GetValue(2).ToString();
                    EcuMFa[x] = Rd.GetValue(3).ToString();
                    EcuUnit[x] = Rd.GetValue(4).ToString();
                    EcuSName[x] = Rd.GetValue(5).ToString();
                    EcuMark[x] = Rd.GetValue(6).ToString();
                    EcuMin[x] = Rd.GetValue(7).ToString();
                    EcuMax[x] = Rd.GetValue(8).ToString();
                    x += 1;
                }
                Rd.Close();
                Global.Create_OnLog("tb_ecu", "Normal");
            }
            catch (Exception ex)
            {
                return;
            }

        }
        public static void Rd_Confg()
        {
            try
            {
                Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_std ORDER BY ParameterNo", con);
                MySqlDataReader Rd = cmd.ExecuteReader();
                int x = 0;
                while (Rd.Read())
                {
                    PNo[x] = Rd.GetValue(0).ToString();
                    PName[x] = Rd.GetValue(1).ToString();
                    PMin[x] = Rd.GetValue(2).ToString();
                    PMax[x] = Rd.GetValue(3).ToString();
                    PUnit[x] = Rd.GetValue(4).ToString();
                    PSName[x] = Rd.GetValue(5).ToString();
                    PMark[x] = Rd.GetValue(6).ToString();
                    x += 1;
                }
                Rd.Close();
                Global.Create_OnLog("Tb_Std", "Normal");

                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM Tb_Fixed ORDER BY N", con);
                MySqlDataReader Rd1 = cmd1.ExecuteReader();
                x = 0;
                while (Rd1.Read())
                {
                    fxd[x] = Convert.ToInt16(Rd1.GetValue(1));
                    x += 1;
                }
                Rd1.Close();
                Global.Create_OnLog("Tb_Fixed", "Normal");


                MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM Tb_PM ORDER BY N", con);
                MySqlDataReader Rd2 = cmd2.ExecuteReader();
                x = 0;
                while (Rd2.Read())
                {
                    Pm_PNo[x] = Convert.ToInt16(Rd2.GetValue(1));
                    x += 1;
                }
                Rd2.Close();
                Global.Create_OnLog("Tb_PM", "Normal");

                MySqlCommand cmd3 = new MySqlCommand("SELECT * FROM Tb_View ORDER BY N", con);
                MySqlDataReader Rd3 = cmd3.ExecuteReader();
                x = 0;
                while (Rd3.Read())
                {
                    vId[x] = int.Parse(Rd3.GetValue(1).ToString());
                    //vName[x] = Convert.ToInt16(Rd.GetValue(2));
                    //vUnit[x] = Convert.ToInt16(Rd.GetValue(3));
                    x += 1;
                }
                vIdNo = x;
                Rd3.Close();

                Global.Create_OnLog("Tb_View", "Normal");
                Global.con.Close();

            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Configuration Failed", "Alert");
                //MessageBox.Show("Error Code:- 15013", ex.Message);
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
                DataSet ds = new DataSet();
                dap.Fill(ds);
                for (x = 0; x <= ds.Tables[0].Columns.Count - 1; x++) AdamG1[x] = ds.Tables[0].Rows[0].ItemArray[x].ToString();
                //for (x = 0; x <= ds.Tables[0].Columns.Count - 1; x++) AdamG2[x] = ds.Tables[0].Rows[0].ItemArray[x].ToString();
                for (x = 0; x <= ds.Tables[0].Columns.Count - 1; x++) sysIn[x] = ds.Tables[0].Rows[7].ItemArray[x].ToString();


                Global.con.Close();

                //MD1 = "4017*8";
                //MD2 = "4015*6";
                //MD3 = "4018*8";
                //MD4 = "4017*8";


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
                Global.Create_OnLog("Tb_Sys .....", "Alert");
                //MessageBox.Show("Error Code:- 15014", ex.Message); 
            }
        }

        public static void Read_ADAMValues()
        {
            try
            {
                string Buf = "";
                Buf = Global.MSPort.ReadExisting();
          
               // Buf = c.ReadExisting();
                bufftss8 = Buf;

                if (Buf != "")
                    Transfer_Adam_Values(ADAM.Module, Buf, ADAM.Indx);
                else
                    goto a;

            a: switch (ADAMCnt)
                {
                    case 1:
                        if (MD1 != "NONE")
                        {
                            Buf = "";
                            if (ChnCnt >= 7)
                            {
                                ChnCnt = -1;
                                ADAMCnt = 2;
                            }
                            else
                            {
                                ChnCnt += 1;
                            }

                            MSPort.DiscardInBuffer();
                            ADAM.Module = "4015"; // Global.MD1;
                            ADAM.Indx = T;
                            if (ChnCnt >= 0) MSPort.Write("#01" + ChnCnt + "\r");// adPort.Write("$" + ChnCnt.ToString("X2") + "M" + "\r");// 
                        }
                        else
                        {
                            ADAM.Module = "";
                            ADAM.Indx = 0;
                            ChnCnt = -1;
                            ADAMCnt = 2;
                        }
                        break;
                    case 2:
                        if (MD2 != "NONE")
                        {
                            Buf = "";
                            if (ChnCnt >= 7)
                            {
                                ChnCnt = -1;
                                ADAMCnt = 3;
                            }
                            else
                            {
                                ChnCnt += 1;
                            }
                            MSPort.DiscardInBuffer();
                            ADAM.Module = "4017"; //Global.MD2;
                            ADAM.Indx = U;
                            if (ChnCnt >= 0) MSPort.Write("#02" + ChnCnt + "\r");// adPort.Write("$" + ChnCnt.ToString("X2") + "M" + "\r");//
                        }
                        else
                        {
                            ADAM.Module = "";
                            ADAM.Indx = 0;
                            ChnCnt = -1;
                            ADAMCnt = 3;
                        }
                        break;
                    case 3:
                        if (MD3 != "NONE")
                        {
                            Buf = "";
                            if (ChnCnt >= 7)
                            {
                                ChnCnt = -1;
                                ADAMCnt = 4;
                                SnT = 0;
                            }
                            else
                            {
                                ChnCnt += 1;
                            }
                            MSPort.DiscardInBuffer();
                            ADAM.Module = "4018"; //Global.MD3;
                            ADAM.Indx = V;
                            if (ChnCnt >= 0) MSPort.Write("#03" + ChnCnt + "\r");// adPort.Write("$" + ChnCnt.ToString("X2") + "M" + "\r"); // 
                        }
                        else
                        {
                            SnT = 0;
                            ADAM.Module = "";
                            ADAM.Indx = 0;
                            ChnCnt = -1;
                            ADAMCnt = 4;
                        }
                        break;
                    case 4:
                        Rd_SerialPort();
                        break;

                //        if (MD4 != "NONE")
                //        {
                //            Buf = "";
                //            if (ChnCnt >= 7)
                //            {
                //                ChnCnt = -1;
                //                ADAMCnt = 5;
                //            }
                //            else
                //            {
                //                ChnCnt += 1;
                //            }
                //            MSPort.DiscardInBuffer();
                //            ADAM.Module = Global.MD4;
                //            ADAM.Indx = W;
                //            if (ChnCnt >= 0) MSPort.Write("#04" + ChnCnt + "\r");// adPort.Write("$" + ChnCnt.ToString("X2") + "M" + "\r");
                //        }
                //        else
                //        {
                //            ADAM.Module = "";
                //            ADAM.Indx = 0;
                //            ChnCnt = -1;
                //            ADAMCnt = 5;
                //        }
                //        break;
                //    case 5:
                //        if (MD5 != "NONE")
                //        {
                //            Buf = "";
                //            if (ChnCnt >= 7)
                //            {
                //                ChnCnt = -1;
                //                ADAMCnt = 1;
                //            }
                //            else
                //            {
                //                ChnCnt += 1;
                //            }
                //            MSPort.DiscardInBuffer();
                //            ADAM.Module = Global.MD5;
                //            ADAM.Indx = X;
                //            if (ChnCnt >= 0) MSPort.Write("#05" + ChnCnt + "\r");//adPort.Write("$" + ChnCnt.ToString("X2") + "M" + "\r");
                //        }
                //        else
                //        {
                //            ADAM.Module = "";
                //            ADAM.Indx = 0;
                //            ChnCnt = -1;
                //            ADAMCnt = 1;
                //        }
                //        break;
                }
                if ((ADAMCnt >= 5) || (ADAMCnt <= 0)) ADAMCnt = 1;
            }
            catch (Exception ex)
            {
                ADAM.Module = "";
                            ADAM.Indx = 0;
                            ChnCnt = -1;
                            ADAMCnt = 1;
                            return;
                //MessageBox.Show("Error Code :- 15005" +'\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                //MessageBoxButtons.OK, MessageBoxIcon.Error); 
               // MessageBox.Show("Error Code :- 15005", ex.Message);
            }
        }




        public struct ADAM
        {
            public static String Module;
            public static Int16 Indx;
        }
        public static void Transfer_Adam_Values(String Module, String Buf1, int dx)
        {
            try
            {

                Int16 pos = Convert.ToInt16(Buf1.IndexOf("+", 1));
                if (pos == -1) pos = Convert.ToInt16(Buf1.IndexOf("-", 1));
                //pos = Convert.ToInt16(Buf1.IndexOf("-",1));
                if (pos != -1) Buf1 = Buf1.Substring(pos); else Buf1 = "0000.00";
                //GenData[59] = "0000.25";
                switch (Module.Substring(0, 4))
                {

                    case "4017":
                        if ((pos != -1) && (PSName[ChnCnt + dx] != "Not_Prog"))
                        {
                            Double Temp = ((Double.Parse(PMax[ChnCnt + dx]) - Double.Parse(PMin[ChnCnt + dx])) / 16);
                            GenData[ChnCnt + dx] = (((Double.Parse(Buf1.Substring(pos, 7)) - 4) * Temp) + Double.Parse(PMin[ChnCnt + dx])).ToString();
                            int c = ChnCnt + dx;
                            //if (c == 59)
                            //{
                            //    Temp = ((Double.Parse(PMax[ChnCnt + dx]) - Double.Parse(PMin[ChnCnt + dx])));
                            //    GenData[ChnCnt + dx] = (((Double.Parse(Buf1.Substring(pos, 7))-4) * Temp) + Double.Parse(PMin[ChnCnt + dx])).ToString();
                            //}
                            if (c == 28)
                            {
                                Temp = ((Double.Parse(PMax[ChnCnt + dx]) - Double.Parse(PMin[ChnCnt + dx])) / 16);
                                GenData[ChnCnt + dx] = (((Double.Parse(Buf1.Substring(pos, 7)) - 4) * Temp) + Double.Parse(PMin[ChnCnt + dx])).ToString("####.#####");
                            }
                            //if (PUnit[ChnCnt + dx] == "mbar")
                            //{
                            //    GenData[ChnCnt + dx] = (double.Parse(GenData[ChnCnt + dx]) * 1000).ToString("0000.00");
                            //    double max1 = (Double.Parse(Global.PMax[ChnCnt + dx]) * 1000);
                            //   double  min1 = (double.Parse(Global.PMin[ChnCnt + dx]) * 1000);
                            //}
                            //if (PUnit[ChnCnt + dx] == "mmHg")
                            //{
                            //    GenData[ChnCnt + dx] = (double.Parse(GenData[ChnCnt + dx]) * 750.0617).ToString("000.0");

                            //    max = (Double.Parse(Global.PMax[ChnCnt + dx]) * 750.0617);
                            //    min = (double.Parse(Global.PMin[ChnCnt + dx]) * 750.0617);
                            //}
                            //if (PUnit[ChnCnt + dx] == "mmH2O")
                            //{
                            //    GenData[ChnCnt + dx] = (double.Parse(GenData[ChnCnt + dx]) * 10197.1636).ToString("00000.0");
                            //    max = (Double.Parse(Global.PMax[ChnCnt + dx]) * 10197.1636);
                            //    min = (double.Parse(Global.PMin[ChnCnt + dx]) * 10197.1636);
                            //}
                            //if (ChnCnt == 7)
                            //{
                            //    Temp = ((Double.Parse(PMax[ChnCnt + dx]) - Double.Parse(PMin[ChnCnt + dx])));
                            //    GenData[ChnCnt + dx] = (((Double.Parse(Buf1.Substring(pos, 7)) / 10) * Temp) + Double.Parse(PMin[ChnCnt + dx])).ToString();
                            //}
                        }
                        else
                        {
                            GenData[ChnCnt + dx] = "0.0";
                        }
                        break;

                    case "4018":
                    case "4015":
                        if (PSName[ChnCnt + dx] != "Not_Prog")
                            Global.GenData[ChnCnt + dx] = Buf1.Substring(pos, 6);  // , 6);
                        else
                            Global.GenData[ChnCnt + dx] = "0.0";
                        break;
                }
                int D = (ChnCnt + dx);
                Double l = Double.Parse(GenData[ChnCnt + dx]);
                Double max = Double.Parse(Global.PMax[ChnCnt + dx]);
                Double min = Double.Parse(Global.PMin[ChnCnt + dx]);

                //if ((l >= 5000) && (l <= -5000))
                //{
                //    l = double.Parse(Global.PMax[ChnCnt + dx]);
                //    GenData[D] = l.ToString();
                //}
                //else if (l <= -5000)
                //{
                //    l = double.Parse(Global.PMin[ChnCnt + dx]);
                //    GenData[D] = l.ToString();
                //}

                if (l >= max)
                {
                    GenData[D] = max.ToString();

                }
                else if (l <= min)
                {
                    GenData[D] = min.ToString();
                }
                else if (l >= 10000) GenData[D] = "9999.9";
                else
                {
                    if (PMax[D].Substring(1, 1) == ".")
                    {
                        GenData[D] = l.ToString("0.0");

                    }
                    else if (PMax[D].Substring(2, 1) == ".")
                    {
                        GenData[D] = l.ToString("00.0");

                    }
                    else if (PMax[D].Substring(3, 1) == ".")
                    {
                        GenData[D] = l.ToString("0000.0");
                    }
                    else
                    {
                        GenData[D] = l.ToString("0000");
                    }
                    //if (PUnit[ChnCnt + dx] == "mmHg")
                    //{
                    //    GenData[ChnCnt + dx] = (double.Parse(GenData[ChnCnt + dx])).ToString("000");

                    //    //max = (Double.Parse(Global.PMax[ChnCnt + dx]) * 750);
                    //    //min = (Double.Parse(Global.PMin[ChnCnt + dx]) * 750);
                    //}
                    //if (PUnit[ChnCnt + dx] == "mmH2O")
                    //{
                    //    GenData[ChnCnt + dx] = (double.Parse(GenData[ChnCnt + dx]) * 10197.1636).ToString("00000.0");
                    //    max = (Double.Parse(Global.PMax[ChnCnt + dx]) * 10197.1636);
                    //    min = (Double.Parse(Global.PMin[ChnCnt + dx]) * 10197.1636);
                    //}

                }


                //if (PUnit[ChnCnt + dx] == "mbar")
                //{
                //    GenData[ChnCnt + dx] = (double.Parse(GenData[ChnCnt + dx]) * 1000).ToString("0000");
                //    max = (Double.Parse(Global.PMax[ChnCnt + dx]) * 1000);
                //    min = (double.Parse(Global.PMin[ChnCnt + dx]) * 1000);
                //}

            }
            catch
            {
                // MessageBox.Show("Error Transfer adam value : " + ex.Message);
                return;
                //adPort.Write("#05" + ChnCnt + "\r");
            }
        }

        //public static void Rd_ADAMConf()
        //{
        //    try
        //    {
        //        int x = 0;
        //        Open_Connection("gen_db", "con");
        //        MySqlDataAdapter dap = new MySqlDataAdapter("SELECT * FROM tbsys", con);
        //        DataSet ds = new DataSet();
        //        dap.Fill(ds);
        //        for (x = 0; x <= ds.Tables[0].Columns.Count - 1; x++) AdamG1[x] = ds.Tables[0].Rows[0].ItemArray[x].ToString();
        //        for (x = 0; x <= ds.Tables[0].Columns.Count - 1; x++) AdamG2[x] = ds.Tables[0].Rows[0].ItemArray[x].ToString();
        //        for (x = 0; x <= ds.Tables[0].Columns.Count - 1; x++) sysIn[x] = ds.Tables[0].Rows[7].ItemArray[x].ToString();


        //        Global.con.Close();

        //        T_CellNo = sysIn[9];
        //        if (sysIn[14] == "TRUE") flg_VolActive = 1; else flg_VolActive = 0;
        //        RcrOn = sysIn[15];
        //        TcrOn = sysIn[16];
        //        flg_RecorsPmData = Convert.ToBoolean(sysIn[17]);
        //        flg_LoginRPM = Convert.ToBoolean(sysIn[18]);
        //        flg_simulateRPM = Convert.ToBoolean(sysIn[19]);
        //        Data_Dir = DateTime.Now.ToString("MMMyy");
        //        DataPath = "D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\";
        //        Global.Create_OnLog("Tb_Sys", "Normal");
        //    }

        //    catch (Exception ex)
        //    {
        //        Global.Create_OnLog("Tb_Sys .....", "Alert");
        //        //MessageBox.Show("Error Code:- 15014", ex.Message); 
        //    }
        //}






        /// <summary>
        /// Read Comports Configuration.......
        /// </summary>
        /// <param name="Read Comports Configuration......."></param>
        /// <returns></returns>

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

                //if (Sr_Port1[9] == "True") Init_RtPort();
                //if (Sr_Port2[9] == "True") Init_SrPort();
                //if (Ad_Port1[9] == "True") Init_ADAMG1Port();
                //if (Ad_Port2[9] == "True") Init_ADAMG2Port();
                //if (Smk_Port[9] == "True") Init_SmokePort();
                //if (Bl_Port[9] == "True") Init_BlowByPort();
                //if (sc_Port[9] == "True") Init_BarcodeScanner();

                // Serail port 1 Initialization //
                if (Sr_Port1[9] == "True") Init_Port(Global.Sr_Port1[2], int.Parse(Global.Sr_Port1[3]), 8, (Parity)Enum.Parse(typeof(Parity), Global.Sr_Port1[4]), (StopBits)Enum.Parse(typeof(StopBits), "One"));

                // Serail port 2 Initialization //

                if (Sr_Port2[9] == "True") Init_Port(Global.Sr_Port2[2], int.Parse(Global.Sr_Port2[3]), 8, (Parity)Enum.Parse(typeof(Parity), Global.Sr_Port2[4]), (StopBits)Enum.Parse(typeof(StopBits), "One"));



                // Adam Port 1 Initialization //

                if (Ad_Port1[9] == "True") Init_Port(Global.Ad_Port1[2], int.Parse(Global.Ad_Port1[3]), 8, (Parity)Enum.Parse(typeof(Parity), Global.Ad_Port1[4]), (StopBits)Enum.Parse(typeof(StopBits), "One"));


                // Adam Port 2 Initialization //

                if (Ad_Port2[9] == "True") Init_Port(Global.Ad_Port2[2], int.Parse(Global.Ad_Port2[3]), 8, (Parity)Enum.Parse(typeof(Parity), Global.Ad_Port2[4]), (StopBits)Enum.Parse(typeof(StopBits), "One"));

                // Smoke Port Initialization 

                if (Smk_Port[9] == "True") Init_Port(Global.Smk_Port[2], int.Parse(Global.Smk_Port[3]), 8, (Parity)Enum.Parse(typeof(Parity), Global.Smk_Port[4]), (StopBits)Enum.Parse(typeof(StopBits), "One"));


                //  Blow By Port Initialization 

                if (Bl_Port[9] == "True") Init_Port(Global.Bl_Port[2], int.Parse(Global.Bl_Port[3]), 8, (Parity)Enum.Parse(typeof(Parity), Global.Bl_Port[4]), (StopBits)Enum.Parse(typeof(StopBits), "One"));
                // BarCode Scanner Port Initialization

                if (sc_Port[9] == "True") Init_Port(Global.sc_Port[2], int.Parse(Global.sc_Port[3]), 8, (Parity)Enum.Parse(typeof(Parity), Global.sc_Port[4]), (StopBits)Enum.Parse(typeof(StopBits), "One"));

            }
            catch (Exception)
            {
                Global.Create_OnLog("COM ports are not  read successfully    ", "Alart");
            }
        }
        public static void Init_Port(string com, int bud, int datab, Parity p, StopBits stpb)
        {
            try
            {
                ComPort.PortName = com;
                if (ComPort.IsOpen == true) ComPort.Dispose();
                ComPort.BaudRate = bud;
                ComPort.DataBits = datab;
                ComPort.Parity = p;
                ComPort.StopBits = stpb;
                if (ComPort.IsOpen == false)
                {
                    ComPort.Dispose();
                    ComPort.PortName = com;
                    ComPort.Open();
                }
               // return true;
            }
            catch
            {

                return ;
            }
        }

        public static void Init_RtPort()
        {
            try
            {
                RTPort.PortName = "COM10";  // Global.Sr_Port1[2];
                if (RTPort.IsOpen == true) RTPort.Dispose();
                RTPort.BaudRate = 9600; // int.Parse(Global.Sr_Port1[3]);
                RTPort.DataBits = 8; // int.Parse("8");
                RTPort.Parity = (Parity)Enum.Parse(typeof(Parity), "None"); //Global.Sr_Port1[4]);
                RTPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                if (RTPort.IsOpen == false)
                {
                    RTPort.Dispose();
                    RTPort.PortName = "COM10";   // Global.Sr_Port1[2];
                    RTPort.Open();
                    Global.Create_OnLog("RTPort Opened ", "Normal");
                    Er_Serial = true; ;
                }
            }
            catch
            {
                Global.Create_OnLog("RTport Opened .....", "Alert");
                Er_Serial = false;
                return;
            }
        }

      

        public static void Init_SrPort()
        {
            try
            {
                Global.MSPort.PortName = "COM1"; // Global.Sr_Port2[2];
                if (MSPort.IsOpen == true) MSPort.Dispose();
                MSPort.BaudRate = 9600; // int.Parse(Global.Sr_Port2[3]);
                MSPort.DataBits = int.Parse("8");
                MSPort.Parity = (Parity)Enum.Parse(typeof(Parity),"None");
                MSPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                if (MSPort.IsOpen == false)
                {
                    MSPort.Dispose();
                    MSPort.PortName = "COM1"; //Global.Sr_Port2[2];
                    MSPort.Open();
                    Global.Create_OnLog("MSPort Opened ", "Normal");
                }
            }
            catch
            {
                Global.Create_OnLog("MSPort Opened .....", "Alert");
                return;
            }
        }

        //public static void Init_ADAMG1Port()
        //{
        //    try
        //    {
        //        Global.ADPortG1.PortName = Global.Ad_Port1[2];
        //        if (ADPortG1.IsOpen == true) ADPortG1.Dispose();
        //        ADPortG1.BaudRate = int.Parse(Global.Ad_Port1[3]);
        //        ADPortG1.DataBits = int.Parse("8");
        //        ADPortG1.Parity = (Parity)Enum.Parse(typeof(Parity), Global.Ad_Port1[4]);
        //        ADPortG1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
        //        if (ADPortG1.IsOpen == false)
        //        {
        //            ADPortG1.Dispose();
        //            ADPortG1.PortName = Global.Ad_Port1[2];
        //            ADPortG1.Open();
        //            Global.Create_OnLog("ADPortG1 Opened ", "Normal");
        //            Er_ADAM = true;
        //        }
        //    }
        //    catch
        //    {
        //        Global.Create_OnLog("ADportG1 Opened .....", "Alart");
        //        Er_ADAM = false;
        //        return;
        //    }
        //}

        //public static void Init_ADAMG2Port()
        //{
        //    try
        //    {
        //        Global.ADPortG2.PortName = Global.Ad_Port2[2];
        //        if (ADPortG2.IsOpen == true) ADPortG2.Dispose();
        //        ADPortG2.BaudRate = int.Parse(Global.Ad_Port2[3]);
        //        ADPortG2.DataBits = int.Parse("8");
        //        ADPortG2.Parity = (Parity)Enum.Parse(typeof(Parity), Global.Ad_Port2[4]);
        //        ADPortG2.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
        //        if (ADPortG2.IsOpen == false)
        //        {
        //            ADPortG2.Dispose();
        //            ADPortG2.PortName = Global.Ad_Port2[2];
        //            ADPortG2.Open();
        //            Global.Create_OnLog("ADPortG2 Opened ", "Normal");
        //        }
        //    }
        //    catch
        //    {
        //        Global.Create_OnLog("ADporG2t Opened .....", "Alart");
        //        return;
        //    }
        //}

        public static void Init_PIDPort()
        {
            try
            {
                Global.PIDPort.PortName = "COM1"; //Global.Bl_Port[2];
                if (PIDPort.IsOpen == true) PIDPort.Dispose();
                PIDPort.BaudRate = 9600;      //int.Parse(Global.Bl_Port[3]);
                PIDPort.DataBits = 8;   // int.Parse("8");
                PIDPort.Parity = (Parity)Enum.Parse(typeof(Parity), "None"); // Global.Bl_Port[4]);
                PIDPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                if (PIDPort.IsOpen == false)
                {
                    PIDPort.Dispose();
                    PIDPort.PortName = "COM1";     //Global.Bl_Port[2];
                    PIDPort.Open();
                    Global.Create_OnLog("PIDPort Port Opened ", "Normal");
                }
            }
            catch
            {
                Global.Create_OnLog("PIDPort Port Opened .....", "Alert");
                return;
            }
        }






        public static void Init_BlowByPort()
        {
            try
            {
                Global.BlPort.PortName = Global.Bl_Port[2];
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
                Global.Create_OnLog("Blow By Port Opened .....", "Alert");
                return;
            }
        }

        public static void Init_BarcodeScanner()
        {
            try
            {
                Global.scPort.PortName = Global.sc_Port[2];
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
                Global.Create_OnLog("Bar Code Scanner,Port Opened .....", "Alert");
                return;
            }
        }
        //public static void Read_ECU_Names()
        //{
        //    try
        //    {
        //        Open_Connection("gen_db", "con");
        //        MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_ecu ORDER BY ParameterNo", con);
        //        MySqlDataReader Rd = cmd.ExecuteReader();
        //        int x = 0;
        //        while (Rd.Read())
        //        {
        //            EcuNo[x] = Rd.GetValue(0).ToString();
        //            EcuName[x] = Rd.GetValue(1).ToString();
        //            EcuMin[x] = Rd.GetValue(2).ToString();
        //            EcuMax[x] = Rd.GetValue(3).ToString();
        //            EcuUnit[x] = Rd.GetValue(4).ToString();
        //            EcuSName[x] = Rd.GetValue(5).ToString();
        //            EcuPMark[x] = Rd.GetValue(6).ToString();
                    
        //            x += 1;
        //        }
        //        Rd.Close();
        //    }
        //    catch(Exception ex)
        //    {
        //        return;
        //    }
        //}


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
                Global.Create_OnLog("Smk_Port Opened .....", "Alert");

            }
        }

        public static void SMOKE_REMOTE_SETTING()
        {
            //smkPort.Write("SRES\r");
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
                    Global.SmkError = "SMOKE METRT NOT CONNECTED : Error";
                    Global.flg_SMOKE_COM = false;
                    Global.SmkEr1 = "Not Ready";
                }
                if (Buf.Substring(5, 1) == "0")
                {
                    Global.SmkError = " SMOKE METRT IN REMOTE MODE.... : Error:  0";
                    Global.flg_SMOKE_COM = false;
                    Global.SmkEr2 = "Remote";
                    Global.flg_SMOKE_COM = true;
                }
                else if (Buf.Substring(5, 1) == "1")
                {
                    Global.SmkError = " NOT SMOKE METRT REMOTE.. : Error:  1";
                    Global.SmkEr2 = "Manual";
                }
                Global.SmkError = "Smoke Meter Remote...";
                //smkPort.Write("SEX1" + "\r");
                //Thread.Sleep(200);
                //Buf = smkPort.ReadExisting();
                //if (Buf.Substring(5, 1) == "0")
                //{
                //    Global.SmkError = " CONNECTOR 1 SELECTED.... : Error:  0";
                //    Global.flg_SMOKE_COM = false;
                //    Global.SmkEr5 = "Connector1";
                //}
                //else if (Buf.Substring(5, 1) == "1")
                //{
                //    smkPort.Write("SEX2" + "\r");
                //    if (Buf.Substring(5, 1) == "0")
                //    {
                //        Global.SmkError = " CONNECTOR 2 SELECTED.... : Error:  0";
                //        Global.SmkEr5 = "Connector2";
                //    }

                //    else
                //    {
                //        Global.SmkError = " CHECK CONNECTOR . : Error:  1";
                //        Global.SmkEr5 = "Chk Conn.";
                //    }
                //}
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

                Global.Create_OnLog(ex.Message, "Alert");


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




        //public static void SMOKE_REMOTE_SETTING ()
        //{


        //    smkPort.Write(" SRES");
        //    Thread.Sleep(200);
        //    var smkBuffer = smkPort.ReadExisting();

        //    if (smkBuffer.Substring(7, 1) == "0")
        //    {
        //        smkPort.Write(" SREM");
        //        Thread.Sleep(200);
        //        smkBuffer = smkPort.ReadExisting();
        //        if (string.IsNullOrEmpty(smkBuffer))  smkBuffer = "Smoke Meter Not Connected.....";

        //        //if (smkBuffer.Substring(7, 1) == "0")
        //        //{
        //        //    smkPort.Write(" SEX1");
        //        //    Thread.Sleep(200);
        //        //    smkBuffer = smkPort.ReadExisting();
        //        //}
        //        //if (smkBuffer.Substring(7, 1) == "0")
        //        //{
        //        //    smkPort.Write(" ASTZ");
        //        //    Thread.Sleep(200);
        //        //    smkBuffer = smkPort.ReadExisting();
        //        //}
        //       if (smkBuffer.Substring(7, 1) == "0")
        //       {
        //            //if (smokeBase == "VolumeBase")
        //                smkPort.Write(" EMZY Z 6.0 1"); //    "EMZY V 100.0 1" + "\r");                   
        //            //else if (smokeBase == "TimeBase")
        //            //        smkPort.Write("EMZY Z" + volumeortime + "1" + "\r");
        //                    Thread.Sleep(200);
        //                    smkPort.Write(" SMES");
        //                    if (!smkBuffer.Contains(" SRDY")) smkBuffer = "Smoke Meter is Eady for sampling...";
        //                    else  MessageBox.Show("Smoke Meter is busy");
        //            smkPort.Write(" AFSN");
        //            Thread.Sleep(200);
        //            smkBuffer = smkPort.ReadExisting();

        //            while (true)
        //            {
        //                if (!smkBuffer.Contains(" AFSN")) continue;
        //                smkPort.Write(" AFSN");
        //                Thread.Sleep(200);
        //                smkBuffer = smkPort.ReadExisting();
        //                if (string.IsNullOrEmpty(smkBuffer)) continue;
        //                else MessageBox.Show("Smoke Meter Is Disconnected...");

        //                //if (smkBuffer.Substring(7, 1) != sample) continue;
        //                var b = smkBuffer.Split('\n');
        //                //if (b.Length != 2) continue;
        //                SmkVal = Convert.ToDouble(b[0].Substring(9, 5));
        //                break;
        //            }
        //       }
        //       else if (smkBuffer.Substring (5,1) == "1")
        //       {
        //           smkPort.Write(" SEX2");
        //           smkBuffer = smkBuffer.Substring(5, 1) == "0" ? "Connector 2 is selected" : "Check Connector...";
        //       }
        //       else if (smkBuffer.Substring(5,1) == "1") smkBuffer = "Smoke Meter is In manual mode  ......";
        //    }


        //}


        //****************************


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
                MessageBox.Show("Error Code:- 15015" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //MessageBox.Show("Error Code:- 15015", ex.Message);
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
                MessageBox.Show("Error Code:- 15016" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //MessageBox.Show("Error Code:- 15016", ex.Message);
            }
            return System.DateTime.Now;

        }
        ////********************** All Data
        //public static void Capture_fData()     //
        //{
        //    try
        //    {
        //        int I = 0;

        //        string s = DateTime.Now.ToString("hh:mm:ss  tt");
        //        Global.fData[0] = s.ToString();
        //        Global.fData[1] = Global.GenData[0];
        //        Global.fData[2] = Global.GenData[1];
        //        for (I = 0; I <= 50; I++)
        //        {
        //            fData[I + 3] = GenData[I + 10];
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //}


        // ////*****************



        //public static void Capture_fData()     // Only Gantner
        //{
        //    try
        //    {
        //        int I = 0;

        //        string s = DateTime.Now.ToString("hh:mm:ss tt");
        //        //Global.Data[0] = s.ToString();        //      
        //        for (I = 0; I <= 22; I++)
        //        {
        //            fData[I + 1] = GenData[I + 26];
        //        }
        //        Global.GenData[21] = Global.GenData[71];
        //        Global.GenData[22] = Global.GenData[72];
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //}

       public static void Capture_ECU_Data()
        {
            try
            {
                int I = 0;
                ECUData[0] = DateTime.Now.ToString("hh:mm:ss tt "); ;

                for (I = 1; I <= 55; I++)
                {
                    if (Global.ECUGenData[I] == null) Global.ECUGenData[I] = "0.0";
                    ECUData[I] = Global.ECUGenData[I]; // GenData[I + 20];
                }
            }
            catch (Exception ex)
            {
                Global.Create_OnLog(ex.Message + " :  Capture ECU Data....", "Alert");
                return;
            }
        }
       public static void LogECUData()
       {
           try
           {
               if (Global.Eng_FileNm == "") Global.Eng_FileNm = "Man";
               int i = 0;
               Global.Capture_ECU_Data();
               Global.Ecn += 1;
               String strData = String.Empty;
               String strData1 = String.Empty;
               String strData2 = String.Empty;
               String strData3 = String.Empty;
               Global.StpTm = DateTime.Now.ToString("hh:mm:ss tt ");
               strData1 = Global.StpTm + ", ";
               for (i = 1; i <= 55; i++)
               {
                   if (Global.ECUData[i] == null) Global.ECUData[i] = "000.000";
                   strData1 = strData1  + Global.ECUData[i] + ", ";
               }

               strData = strData1; // +strData2 + strData3;



               strData = strData + Global.Ecn + ",\n";      // Global.StrAlarm + ", " +
               var filePath = Global.DataPath + "ECU_Data\\" + Global.Eng_ECU_FileNm + ".csv";
               using (var wr = new StreamWriter(filePath, true))
               {
                   var row = new List<string> { strData.Substring(0, strData.Length - 1) };
                   var sb = new StringBuilder();
                   foreach (string value in row)
                   {
                       if (sb.Length > 0)
                           sb.Append(",");
                       sb.Append(value);
                   }
                   wr.WriteLine(sb.ToString());
               }
               ////*****************************

               //flg_SaveData = false;


               //MessageBox.Show("ECU Data Logged..", "Dynalec Control Pvt Ltd.",
               //MessageBoxButtons.OK, MessageBoxIcon.Information);
           }
           catch (Exception ex)
           {
               //MessageBox.Show("Error in LogData() :" + ex.Message);
               MessageBox.Show("ECU Data Log Problem.." + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
               Global.Create_OnLog("ECU Data Log Problem... ", "Alert");
               Global.flg_SFCStart = false;
           }

       }

        //*********************************************

        ////***********************************

        /// <summary>
       ///  //public void Log_InstData()
       //{
       //    try
       //    {               
       //        int t1 = 0;
       //        if (Global.Eng_Inst_FileNm == "") Global.Eng_Inst_FileNm = "Inst_Man";
       //        int i = 0;
       //        Global.Capture_Data(); // Capture_Data(Global.flg_SFCStart);
       //        Global.ISn += 1;
       //        String InstData = null;


       //        InstData = IData[0] = DateTime.Now.ToString() + ", "; ;

       //        //for (i = 0; i <= Global.vIdNo; i++)
       //        //{
       //        //    t1 = Global.vId[i];
       //        //    IData[i + 1] = Global.GenData[t1];
       //        //    if (IData[i + 1] == null) IData[i + 1] = "0.0";
       //        //    InstData = InstData  +  IData[i + 1] + ", ";
       //        //}
       //         //for (i = 0; i < 144; i++)
       //        for (i = 0; i < 50; i++)
       //        {
       //            if (Global.Data[i] == null) Global.Data[i] = "000.000";
       //            InstData = InstData + Global.Data[i] + ", ";
       //        }

       //         //strData = strData; // +strData2 + strData3;

       //         InstData = InstData + Global.StrAlarm + ", " + Global.ISn + ",\n";
       //         var filePath = Global.DataPath + "InstLog_Data\\" + Global.Eng_Inst_FileNm + ".csv";
       //        using (var wr = new StreamWriter(filePath, true))
       //        {
       //            var row = new List<string> { InstData.Substring(0, InstData.Length - 1) };
       //            var sb = new StringBuilder();
       //            foreach (string value in row)
       //            {
       //                if (sb.Length > 0)
       //                    sb.Append(",");
       //                sb.Append(value);
       //            }
       //            wr.WriteLine(sb.ToString());
       //        }
       //    }
       //    catch (Exception ex)
       //    {
       //        MessageBox.Show("Error in Inst_LogData() :" + ex.Message);
       //    }
       //}

        /// </summary>
        /// 
       public static void RecordPMData()
       {
           int i = 0;
           Global.CapturePMData();
           String Str = String.Empty;
           String Str1 = String.Empty;
           for (i = 0; i <= 12; i++)
           {
               if (PmData[i] == null)
               {
                   PmData[i] = "0.0";
               }
               Str = Str + PmData[i] + ", ";

           }
           Str = Str + Global.StrAlarm + ",\n";
           var filePath = Global.DataPath + "PM_Data\\" + Global.Eng_PMFileNm + ".csv";

           using (var wr = new StreamWriter(filePath, true))
           {
               var row = new List<string> { Str.Substring(0, Str.Length - 1) };
               var sb = new StringBuilder();
               foreach (string value in row)
               {
                   if (sb.Length > 0)
                       sb.Append(",");
                   sb.Append(value);
               }
               wr.WriteLine(sb.ToString());
           }
           int linecount = File.ReadAllLines(filePath).Count();
           if (linecount >= 120)
           {
               var file = new List<string>(System.IO.File.ReadAllLines(filePath));
               file.RemoveAt(1);
               File.WriteAllLines(filePath, file.ToArray());
           }
       }

       public static void CapturePMData()
       {
           try
           {
               int i = 0;
               int t = 0;
               PmData[0] = DateTime.Now.ToString("hh:mm:ss tt");
               //PmData[1] = Global.varRPM.ToString();

               for (i = 0; i <= 12; i++)
               {
                   t = Global.Pm_PNo[i];
                   PmData[i + 1] = Global.GenData[t];
               }
               if ((Global.StrAlarm == null) || (Global.StrAlarm == "")) PmData[13] = "****"; else PmData[13] = Global.StrAlarm;

           }
           catch (Exception ex)
           {
               MessageBox.Show("PM Data Not Captured" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
               Global.Create_OnLog("PM Data Not Captured.....", "Alert");
               return;

               //MessageBox.Show("Error in CapturePMData():" + ex.Message);
           }
       }
        public static void Capture_Data()
        {
            try
            {
                int t = 0;
                int I = 0;
                t = 100;
                StpTm = DateTime.Now.ToString("hh:mm:ss tt ");

                EngHrs = "11:22:00";
                for (I = 0; I <= 100; I++)
                {
                    if (Global.GenData[I] == null) Global.GenData[I] = "0.0";
                    Data[I] = GenData[I];
                }
               
                Global.Data[3] = GenData[3];
                Global.Data[4] = GenData[4];
                if (SmkVal == null) SmkVal = 0.00;
                Global.Data[t + 1] = SmkVal.ToString();
                Global.Data[t + 2] = BlBy.ToString();
                Global.Data[t + 3] = SFCwt.ToString(); // .ArrData[11].ToString();
                Global.Data[t + 4] = SFCTm.ToString(); // .ArrData[12].ToString();                       
                Global.Data[t + 5] = Corfact.ToString("0.00000");
                Global.Data[t + 6] = varTRQ.ToString("00.0");
                Global.Data[t + 7] = VarPowkW.ToString("00.0");
                Global.Data[t + 8] = SFCValkW.ToString("000.0");
                Global.Data[t + 9] = Bi_Val.ToString("00.0");
                Global.Data[t + 10] = GenData[110];  //Global.varTRQ.ToString("00.0");
                Global.Data[t + 11] = GenData[111];
                Global.Data[t + 12] = (Convert.ToDouble(Global.Data[108]) * Global.Corfact).ToString("00.0");
                Global.Data[t + 13] = GenData[113];   // (Convert.ToDouble(double.Parse(Global.Data[103]) / double.Parse(Global.Data[104])) * 3.6).ToString("0.00");
                Global.Data[t + 14] = "00.00";  //(Convert.ToDouble((double.Parse(Global.Data[103]) / double.Parse(Global.Data[104])) * 3.6) / 0.835).ToString("0.00");
                Global.Data[t + 15] = VarPowHp.ToString("00.0");
                Global.Data[t + 16] = GenData[116];
                Global.Data[t + 17] = (SFCValPs).ToString("000.0");
                Global.Data[t + 18] = GenData[118];
                Global.Data[t + 19] = Global.varbmep.ToString("0.000");
                Global.Data[t + 20] = "0.0";               

                //*********************
                Global.Data[121] = Global.TestTyp;               
                Global.Data[122] = System.DateTime.Now.ToString("hh:mm:ss tt");
                Global.Data[123] = Global.S_StartTime;
                Global.Data[124] = clsFun.cummbuff;
                if (Global.StrAlarm == String.Empty) Global.StrAlarm = "*****";
                Global.Data[125] = Global.StrAlarm;
               


            }
            catch (Exception ex)
            {
                Global.Create_OnLog(ex.Message + " :  Capture Data....", "Alert");
                return;
                //MessageBox.Show("Error Code:- 1517", ex.Message);
            }
        }


       
        public static void Read_Vol()
        {
            if (DigIn[3] == 1) Vol = VolB;
            else if (DigIn[4] == 1) Vol = VolC;
            else Vol = VolA;
        }

        public static void Mode_to_Mode()
        {
            try
            {
                if (flg_even_Mode == true)
                {
                    if (L_Mode != C_Mode)
                        Global.Mode_Out(0, 1, 1);
                    else
                    {
                        switch (int.Parse(Global.C_Mode))
                        {
                            case 1:
                                Global.Mode_Out(1, 0, 0);
                                break;
                            case 2:
                                Global.Mode_Out(0, 1, 0);
                                break;
                            case 3:
                                Global.Mode_Out(1, 1, 0);
                                break;
                            case 4:
                                Global.Mode_Out(0, 0, 1);
                                break;
                            case 5:
                                Global.Mode_Out(1, 0, 1);
                                break;
                            case 6:
                                Global.Mode_Out(0, 1, 1);
                                break;
                        }
                    }

                    if (Global.Diff1 > 0)
                    {
                        if (Global.AnaOut1 >= Double.Parse(Global.SetPtOut1))
                        {
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                            Global.Diff1 = 0;
                        }
                    }
                    else if (Global.Diff1 < 0)
                    {
                        if (Global.AnaOut1 <= Double.Parse(Global.SetPtOut1))
                        {
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                            Global.Diff1 = 0;
                        }
                    }
                    if (Global.Diff2 > 0)
                    {
                        if (Global.AnaOut2 > Double.Parse(Global.SetPtOut2))
                        {
                            Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                            Global.Diff2 = 0;
                        }
                    }
                    else if (Global.Diff2 < 0)
                    {
                        if (Global.AnaOut2 <= Double.Parse(Global.SetPtOut2))
                        {
                            Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                            Global.Diff2 = 0;
                        }
                    }
                    Global.AnaOut1 = Global.AnaOut1 + Global.Diff1;
                    Global.AnaOut2 = Global.AnaOut2 + Global.Diff2;
                }
            }
            catch (Exception ex)
            {
                Global.Create_OnLog(ex.Message + " :  Mode to mode....", "Alert");
                //MessageBox.Show("Error Code:- 15018", ex.Message);
            }
        }
        //public static void Mode_Not_Mode()
        //{
        //    try
        //    {
        //        if (flg_even_Mode == false)
        //        {
        //            if (Global.MDiff > 0)    //+ve
        //            {
        //                if (Global.LastAna2 > Global.LastAna1)
        //                    flg_even_Mode = true;
        //            }
        //            else if (Global.MDiff < 0)    //-ve
        //            {
        //                if (Global.LastAna2 < Global.LastAna1)
        //                    flg_even_Mode = true;
        //            }
        //            Global.LastAna2 = Global.LastAna2 + Global.MDiff;
        //        }
        //    }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error Code:- 16019", ex.Message);
        //        }
        //    }

        //public static void Read_Limfl()
        //{
        //    try
        //    {
        //        Global.Open_Connection("lim_db", "conLim");
        //        MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + Prj[3], Global.conLim);
        //        MySqlDataReader Rd = cmd.ExecuteReader();
        //        Int16 x = 0;
        //        while (Rd.Read())
        //        {
        //            Global.LL1[x] = Rd.GetValue(2).ToString();
        //            Global.L1[x] = Rd.GetValue(3).ToString();
        //            Global.H1[x] = Rd.GetValue(4).ToString();
        //            Global.HH1[x] = Rd.GetValue(5).ToString();
        //            x += 1;
        //        }
        //        Rd.Close();
        //        Global.con.Close();
        //        Global.Create_OnLog("Limit file Read Successfully .....", "Normal"); 

        //    }
        //    catch (Exception ex)
        //    {
        //        Global.Create_OnLog("Limit file not Read Successfully .....", "Alart"); 

        //        //MessageBox.Show("Error Code:-15019", ex.Message); 
        //    }
        //}
        //public static void Read_LimtStandby()
        //{
        //    try
        //    {
        //        Global.Open_Connection("lim_db", "conLim");
        //        MySqlCommand cmd = new MySqlCommand("SELECT * FROM LIM_STANDBY", Global.conLim);
        //        MySqlDataReader Rd = cmd.ExecuteReader();
        //        Int16 x = 0;
        //        while (Rd.Read())
        //        {

        //            Global.Ls[x] = Rd.GetValue(3).ToString();
        //            Global.Hs[x] = Rd.GetValue(4).ToString();

        //            x += 1;
        //        }
        //        Rd.Close();
        //        Global.con.Close();
        //        Global.Create_OnLog("Limit Standard file Read Successfully .....", "Normal"); 

        //    }
        //    catch (Exception ex)
        //    {
        //        Global.Create_OnLog("Limit Standard file not Read Successfully .....", "Alart"); 

        //        //MessageBox.Show("Error Code:-15019", ex.Message);
        //    }
        //}
        public static void Read_Eng()
        {
            try
            {
                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand("select * from tblEngine where EngineFile='" + Global.Prj[1] + "'  ", Global.con);
                MySqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {

                    EngType = rd.GetValue(1).ToString();
                    Bor = rd.GetValue(2).ToString();
                    NCyl = rd.GetValue(3).ToString();
                    Strk = rd.GetValue(4).ToString();
                    Svol = rd.GetValue(5).ToString();
                    SGrv = rd.GetValue(6).ToString();

                }
                rd.Close();
                Global.con.Close();
                Global.Create_OnLog("Engine file Read Successfully .....", "Normal");

            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Engine file not Read Successfully .....", "Alert");

                //MessageBox.Show("Error Code:- 15020", ex.Message); 
            }

        }
        //***************** 

    }

}
