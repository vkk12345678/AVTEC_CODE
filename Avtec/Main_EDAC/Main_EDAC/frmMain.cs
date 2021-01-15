using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Automation.BDaq; 
using System.Windows.Forms;
using System.Threading.Tasks; 
using System.Threading;
using System.Globalization;
using System.IO.Ports;
using System.Net;
//using canlibCLSNET;
//using Rd_Gantner;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using S7.Net;
namespace Logger
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// /////socket declaration
        //public  Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //public  IPAddress clientIP = IPAddress.Parse("192.168.1.98");
        //public  IPEndPoint clientEP = new IPEndPoint(IPAddress.Parse("192.168.1.98"), 1001);
        /// </summary>
        /// 

        public Plc plc = new Plc(CpuType.S71500, "192.168.1.1", 0, 1);
        public Process p = new Process();
        private int FixHeight =1920, FixWidth = 1080;  //1366, FixWidth = 768; //, FixWidth =  FixWidth = 768;    //1920, FixWidth = 1080;   //
       // public modbus modb = new modbus(); 
        System.Windows.Forms.Button[] ArrBut = new
        System.Windows.Forms.Button[50];
        System.Windows.Forms.TextBox[] ArrVal = new
        System.Windows.Forms.TextBox[50];
        System.Windows.Forms.Label[] ArrUnit = new
        System.Windows.Forms.Label[50];
        private InPutV.IPVal[] InV = new InPutV.IPVal[80];
        private String[] scrn_Cal = new String[80];
        private String[] view = new String[150];
        private string[] ViewNo = new string[22];

        //*****************************
             
        
        double[] dataScaled = new double[2];
        public double stopsec = 20;
       
       
        private String[] EngData = new String[30];

        private double Buf1 = 0;
        private double Buf2 = 0;
        private string OutBuf = "";
        private String TolT = "00:00:00";
        private int R_Cnt = 0;

        private int AdamCnt6018 = 0;
        private int AdamCnt6017 = 0;
        private int iCnt = 0;

      
       

        private String[] IData = new String[151];
        public static SerialPort PIDPORT = new SerialPort();
       
        //********************
        double[] m_frequecy; // selected counter channel' frequency.
        bool m_isCounterReseted = true;
        int m_channelCount = 2;
        int m_index = 1;
        //**********************

        //public Double minLp = 0;
        //public Double maxVal = 10000;
        public int LimCnt = 0;
        private int SockT = 0;
		

		string SFCType = "";

        private Double Lower1, Lower2, Lower3, Lower4, Lower5;
        private Double High1, High2, High3, High4, High5;
        private String Ds_Pos;
        private int cntDSafty = 0;
        private String AMSt = "1";

        //public static Thread FASTLOGThread;
        //public static Thread GantnerThread;
        //public static Thread ADAM6018Thread;
        //public static Thread ADAM6017Thread;

        public static Thread TimeThread;
        private long M_Cmt = 0;



		public static Thread InputValueThread;

		//public static Thread FASTLOGThread;
		//public static Thread RINSTThread_RT;

		private Stopwatch st = new Stopwatch();

        public static  Boolean f_Found = false;

        private Boolean flg_ProgEnd = false;
        private Boolean flg_Showlim = false;
        private Boolean flg_StopInt = false;

        private String MSt = "1";
        private Double RMP1 = 0;
        private Double RMP2 = 0;
        private Double RMP = 0;
        private Boolean flg_M_Ramp = false;
        private Point MouseDownLocation;

        private int Tcnt = 0;
          
        private int wPCnt = 0;
        private int fPCnt = 0;
        private int lPCnt = 0;
        private int wTCnt = 0;
        private int lTCnt = 0;
        private int wrtCnt = 0;
        private int Srloop = 0;
        private int Erloop = 0;
        private int CntReset = 0;
        private int LogCnt = 0;
        public Boolean Auto_SmkRd = false;

       

        
        //public int Sn = 0;
        private Int16 C_Hours;
        private Int16 C_Minutes;
        private Int16 C_Seconds;
        public TimeSpan t;
        public string answer;
       

        private int TmR1 = 0;
        private int TmR = 1;
        //private String SetPt2 = "0";
        private int TmR2 = 0;
        private int Tstb = 0;
        private int Tstd = 0;
        private int Tstp = 0;
        private Boolean flg_SaveData = false;
        private Boolean flg_PerStep = false;
        private Boolean flg_Instat = false;
        private Boolean flg_Avg = false;
        private Boolean flg_flyUp = false;
        private Boolean flg_Idle = false;
        private int LogT = 0;
        private int DataCnt = 5;
        private Boolean flg_Ramp = false;
        private Boolean flg_Stb = false;
        private Boolean flg_Std = false;
        private Boolean flg_ProgOut = false;
        private Boolean flg_AnaOut = false;
        
        private Boolean flg_WtrTemp = false;
        private Boolean flg_WtrPress = false;
        private Boolean flg_OliTemp = false;
        private Boolean flg_OilPress = false;
        private Boolean flg_FuelPress = false;
        private Boolean flg_dynaSafety = false;
        private Boolean flg_addPlCAlarm = true;
        private Boolean flg_addwtrpres = true;
        private Boolean flg_addfuelpres = true;       
        private Boolean flg_addLuboilpres = true;
        private Boolean flg_ChkAlarmON = false;
        private Boolean flg_addwtrtemp = true;
        private Boolean flg_addLuboilTemp = true;
        private Boolean flg_EngRd = false;
        public TimeSpan s;

        public Boolean Auto_Hold = false;        
        //public Double Baro = 1.005;
        //public Double DryT = 31.2;
        //public int rcount = 0;

        private const int DO_portCountShow = 2;
        
        public TextBox[,] Do_TextBox;
        Task t1, t2, t3, t4, t5;
        private String OutBuffer = "";

       
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
        public static Double SmkVal;
        //For Pass Of Limits....//
        private bool flg_chkpass = false;
   

        // For Pass Of Limits Using Array //

        public static String[] minPassOfLim = new String[20];
        public static String[] maxPassOfLim = new String[20];

		//************************
        public static EngOK engOk = new EngOK();
        public static frmSmoke frmsmk = new frmSmoke(); 

		public frmMain()
        {
            InitializeComponent();

          // Global.Rd_Pwd();
            Global.Rd_System();
            //Global.ConfigDevice();
          //  Global.Rd_System();
          //Global.ConfigDevice();     
      
        }

        private void Init_Counter()
        {

            if (m_isCounterReseted == true)
            {
                try
                {
                    if (freqMeterCtrl1.Initialized && freqMeterCtrl1.Channel != -1)
                    {
                        freqMeterCtrl1.Enabled = true;
                    }

                }
                catch (Exception ex)
                {
                    //ShowErrorMessage(ex);
                }
                m_frequecy = new double[0];

            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            //pictureBox1.Image = Image.FromFile(@"C:\Dcpl_EDAC_Bit\Main_EDAC\Main_EDAC\bin\Debug\Logo_With ISO.jpg");
            //pictureBox1.Image = Image.FromFile(Global.PATH + "Logo_With ISO.jpg");
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {  
                //Global.PATH
                      //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                     //this.windowstate = maximized
                      //this.WindowState = FormWindowState.Normal;
                    Resolution.CResolution ChangeRes = new Resolution.CResolution(FixHeight, FixWidth);
                    //this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                    lblLog.BringToFront();
                    AddListItem("Main Function started...", "Normal");
                    Global.Rd_System();
                    //Global.ConfigDevice();
                    //Global.Rd_System(); 
                   // Global.Rd_Confg();

                    Load_Arr();
                    //PBar1.Value = 1;
                    PBar2.Value = 1;
                    PBar3.Value = 1;
                    //Update_Tss1(0);
                   
                  //  Global.Init_PIDPort();  
    
                  Init_Counter();  

                 //Global.Rd_System();
                  Global.SFC_msg = "SFC Status .....";

                    this.Meter1.MinValue = 0;
                    this.Meter1.MaxValue = float.Parse(Global.sysIn[11]);
                    this.Meter1.Range_Idx = 0;
                    this.Meter1.MaxValue = float.Parse(Global.sysIn[11]);
                    this.Meter1.RangeEndValue = float.Parse(Global.sysIn[11]);

                    if (float.Parse(Global.sysIn[11]) <= 2000) Meter1.ScaleLinesMajorStepValue = 200;
                    else if ((float.Parse(Global.sysIn[11]) > 2000) && (float.Parse(Global.sysIn[11]) <= 3000)) Meter1.ScaleLinesMajorStepValue = 300;
                    else if ((float.Parse(Global.sysIn[11]) > 3000) && (float.Parse(Global.sysIn[11]) <= 4000)) Meter1.ScaleLinesMajorStepValue = 400;
                    else if ((float.Parse(Global.sysIn[11]) > 4000) && (float.Parse(Global.sysIn[11]) <= 5000)) Meter1.ScaleLinesMajorStepValue = 500;
                    else if ((float.Parse(Global.sysIn[11]) > 5000) && (float.Parse(Global.sysIn[11]) <= 6000)) Meter1.ScaleLinesMajorStepValue = 600;
                    else  Meter1.ScaleLinesMajorStepValue = 700;
                   
                   
                    //this.Meter2.MinValue = 0;
                    //this.Meter2.MaxValue = float.Parse(Global.sysIn[12]);
                    //this.Meter2.Range_Idx = 0;
                    //this.Meter2.MaxValue = float.Parse(Global.sysIn[12]);
                    //this.Meter2.RangeEndValue = float.Parse(Global.sysIn[12]);

                    //if (float.Parse(Global.sysIn[12]) <= 100) Meter2.ScaleLinesMajorStepValue = 10;
                    //else if ((float.Parse(Global.sysIn[12]) > 200) && (float.Parse(Global.sysIn[12]) <= 300)) Meter2.ScaleLinesMajorStepValue = 30;
                    //else if ((float.Parse(Global.sysIn[12]) > 300) && (float.Parse(Global.sysIn[12]) <= 400)) Meter2.ScaleLinesMajorStepValue = 40;
                    //else if ((float.Parse(Global.sysIn[12]) > 400) && (float.Parse(Global.sysIn[12]) <= 500)) Meter2.ScaleLinesMajorStepValue = 50;
                    //else if ((float.Parse(Global.sysIn[12]) > 500) && (float.Parse(Global.sysIn[12]) <= 600)) Meter2.ScaleLinesMajorStepValue = 60;
                    //else Meter2.ScaleLinesMajorStepValue = 70;




                    Global.Make_mdb(Global.DataPath);                                     
                    flg_AnaOut = true;
                    //////

                    if (Global.sysIn[17].ToString() == "TRUE") Ds_Pos = "1"; else Ds_Pos = "0";
                    Global.flg_prjOn = false;
                    Global.Init_SrPort();
                    Global.Init_RtPort();
                    Global.AnaOut1 = 0.01;
                    Global.AnaOut2 = 0.01;
                    Process[] prs = Process.GetProcesses();
                    foreach (Process pr in prs)
                    {
                        //if (pr.ProcessName == "ModbusPollCS") pr.Kill();
                        if (pr.ProcessName == "Editors") pr.Kill();
                        if (pr.ProcessName == "EXCEL") pr.Kill();
                        if (pr.ProcessName == "Mod_PID.exe") pr.Kill();

                    }
                    init_ReadyStatus();
                    //GridSeq.RowCount = 20;
                    //Load_Gridseq_header();
                    //clsECU.Init_ECU();  
                    LoadDgView(); 
                    tmrWrite.Start(); 
                    ResetOutPut();
                  //  RdAdam.Init_adPort("COM16", 9600, 8, Parity.None, StopBits.One);
                    panel6.Visible = false;
                   
                    p.StartInfo = new ProcessStartInfo(Global.PATH + "Mod_PID.exe");
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.Start();
                    //plc.Open();
                    clsLimit.Read_Limfl();

                    //clsECU.Init_ECU();

                    
				//**********************
			}
			catch (Exception ex)
            {
                return;
                //MessageBox.Show("Error in frmmain _Load" + '\n' + '\n' + '\n'+ "PLEASE CHECK CONNECTION OF KVASER TOOL...", "Dynalec Controls Pvt Ltd.",
                //MessageBoxButtons.OK, MessageBoxIcon.Error);//ex.Message
                //MessageBox.Show("Error in frmmain _Load",ex.Message);
                //Login frm = new Login();
                //frm.ShowDialog();
                //frm.Dispose();
                //if (Global.flg_Log_service == true)
                //{
                //    //frmSysP frm1 = new frmSysP();
                //    //frm1.ShowDialog();
                //    //frm1.Dispose();
                //}
            }
        }

        //****************************

        //private void Init_Gantner()
        //{
        //    int HONLCLIENT = -1, HONLCONNECTION = -1;
        //    int ret = 0;
        //    int ChannelCount = 0;
        //    double info1 = 0;
        //    byte[] baTempInfo = new byte[1024];
        //    string strTempString = "";
        //    double outValue = 0;

        //    string IP = "192.168.1.28";
        //    //*******************
        //    ret = HSP._CD_eGateHighSpeedPort_Init(IP, 5, (int)HSP.CONNECTIONTYPE.Online, 100, ref HONLCLIENT, ref HONLCONNECTION);

        //    ret = HSP._CD_eGateHighSpeedPort_GetDeviceInfo(HONLCONNECTION, (int)HSP.DEVICEINFO.Address, 0, ref info1, baTempInfo);
        //    ConvertZeroTerminatedByteArray2String(out strTempString, baTempInfo);
        //    ret = HSP._CD_eGateHighSpeedPort_GetDeviceInfo(HONLCONNECTION, (int)HSP.DEVICEINFO.Type, 0, ref info1, baTempInfo);
        //    ConvertZeroTerminatedByteArray2String(out strTempString, baTempInfo);
        //    ret = HSP._CD_eGateHighSpeedPort_GetDeviceInfo(HONLCONNECTION, (int)HSP.DEVICEINFO.SampleRate, 0, ref info1, null);

        //    HSP._CD_eGateHighSpeedPort_GetNumberOfChannels(HONLCONNECTION, (int)HSP.DATADIRECTION.InputOutput, ref ChannelCount);

        //}

        //private void Online(string IP)
        //{
        //    try
        //    {
        //        int HONLCLIENT = -1, HONLCONNECTION = -1;
        //        int ret = 0;
        //        double info1 = 0;
        //        byte[] baTempInfo = new byte[1024];

        //        double outValue = -1;

        //        ret = HSP._CD_eGateHighSpeedPort_Init(IP, 5, (int)HSP.CONNECTIONTYPE.Online, 100, ref HONLCLIENT, ref HONLCONNECTION);
        //        HSP._CD_eGateHighSpeedPort_ReadOnline_Single(HONLCONNECTION, ReadChannel, ref outValue);
        //        //Global.GenData[ReadChannel + 26] = ((rand1.Next(((int)outValue - 1), ((int)outValue + 1)))).ToString("000.0000");      //outValue.ToString("##0.0");
        //        Global.GenData[ReadChannel + 26] = (Global.RandomNumberBetween((outValue + 0.5), (outValue - 0.7))).ToString("000.00000");

        //        if (ReadChannel <= 20)               
        //            ReadChannel++; 
        //        else
        //            ReadChannel = 0;

        //        //HSP._CD_eGateHighSpeedPort_ReadOnline_Single(HONLCONNECTION, ReadChannel, ref outValue);
        //        //Global.GenData[ReadChannel + 26] = ((rand1.Next(((int)outValue - 1), ((int)outValue + 1)))).ToString("000.0000");      //outValue.ToString("##0.0");
        //        //Global.GenData[ReadChannel + 26] = outValue.ToString("000.0000");
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //}

        //private static void ConvertZeroTerminatedByteArray2String(out string Destination, byte[] Source)
        //{
        //    int i, MaxIndex;

        //    MaxIndex = Source.GetUpperBound(0);
        //    Destination = "";
        //    i = Source.GetLowerBound(0);
        //    while ((Source[i] != 0) && (i <= MaxIndex))
        //    {
        //        Destination += (char)Source[i];
        //        i++;
        //    }
        //    Destination = Destination.Trim();
        //}


    

        ////****************************

        //public void Init_TCP_Port()
        //{
        //    clsADAM6000.m_bRegister1 = true;        // set to true to read the register, otherwise, read the coil
        //    clsADAM6000.m_bRegister2 = true;       // set to true to read the register, otherwise, read the coil
        //    clsADAM6000.m_IP18 = "192.168.1.241"; // "172.18.3.243";	// modbus slave IP address
        //    clsADAM6000.m_IP17 = "192.168.1.242";  //modbus slave IP address
        //    clsADAM6000.m_iPort = 502;              // modbus TCP port is 502
        //    clsADAM6000.m_iStart1 = 1;              // modbus starting address
        //    clsADAM6000.m_iLength1 = 8;
        //    clsADAM6000.m_iStart2 = 1;              // modbus starting address
        //    clsADAM6000.m_iLength2 = 8; // modbus reading length
        //    clsADAM6000.adamTCP1 = new AdamSocket();
        //    clsADAM6000.adamTCP2 = new AdamSocket();
        //    clsADAM6000.adamTCP1.SetTimeout(1000, 1000, 1000); // set timeout for TCP
        //    clsADAM6000.adamTCP2.SetTimeout(1000, 1000, 1000); // set timeout for TCP

        //}

		private void Init_PIDPORT()
        {
            try
            {
                PIDPORT.PortName = "COM3";
                if (PIDPORT.IsOpen == true) PIDPORT.Dispose(); // .Close();
                PIDPORT.BaudRate = int.Parse("9600");
                PIDPORT.DataBits = int.Parse("8");
                PIDPORT.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                PIDPORT.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                if (PIDPORT.IsOpen == false)
                {
                    PIDPORT.Dispose();
                    PIDPORT.PortName = "COM3";   //sysIn[20];
                    PIDPORT.Open();
                }

            }
            catch
            {
                //MessageBox.Show("Error Code:- 15001 " + ex.Message);
                return;
            }
        }
        //*****************************************
      
            private void Load_Arr()
            {

                int I = 0;

                InV[0] = ipVal1;
                InV[1] = ipVal2;
                InV[2] = ipVal3;
                InV[3] = ipVal4;
                InV[4] = ipVal5;
                InV[5] = ipVal6;
                InV[6] = ipVal7;
                InV[7] = ipVal8;
                InV[8] = ipVal9;
                InV[9] = ipVal10;
                InV[10] = ipVal11;
                InV[11] = ipVal12;
                InV[12] = ipVal13;
                InV[13] = ipVal14;
                InV[14] = ipVal15;
                InV[15] = ipVal16;
                InV[16] = ipVal17;
                InV[17] = ipVal18;
                InV[18] = ipVal19;
                InV[19] = ipVal20;
                InV[20] = ipVal21;
                InV[21] = ipVal22;
                InV[22] = ipVal23;
                InV[23] = ipVal24;
                InV[24] = ipVal25;
                InV[25] = ipVal26;
                InV[26] = ipVal27;
                InV[27] = ipVal28;
                InV[28] = ipVal29;
                InV[29] = ipVal30;

                InV[30] = ipVal31;
                InV[31] = ipVal32;
                InV[32] = ipVal33;
                InV[33] = ipVal34;
                InV[34] = ipVal35;
                InV[35] = ipVal36;
                InV[36] = ipVal29;
                InV[37] = ipVal38;
                InV[38] = ipVal39;
                InV[39] = ipVal40;
                
                InV[40] = ipVal41;
                InV[41] = ipVal42;
                ////// Second Page
                //InV[42] = ipVal43;
                //InV[43] = ipVal44;
                //InV[44] = ipVal45;
                //InV[45] = ipVal46;
                //InV[46] = ipVal47;
                //InV[47] = ipVal48;
                //InV[48] = ipVal49;
                //InV[49] = ipVal50;
                //InV[50] = ipVal51;
                //InV[51] = ipVal52;
                //InV[52] = ipVal53;
                //InV[53] = ipVal54;
                //InV[54] = ipVal55;
                //InV[55] = ipVal56;
                //InV[56] = ipVal57;
                //InV[57] = ipVal58;
                //InV[58] = ipVal59;
                //InV[59] = ipVal60;
                //InV[60] = ipVal61;
                //InV[61] = ipVal62;
                //InV[62] = ipVal63;
                //InV[63] = ipVal64;
                //InV[64] = ipVal65;
                //InV[65] = ipVal66;
                //InV[66] = ipVal67;
                //InV[67] = ipVal68;
                //InV[68] = ipVal69;
                //InV[69] = ipVal70;


                try
                {
                    Global.Rd_Confg();
                    //Global.Configure_Gantner(); 
                    Global.Open_Connection("gen_db", "con");
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_scrn ORDER BY N ", Global.con);
                    MySqlDataReader Rd = cmd.ExecuteReader();

                    int x = 0;
                    while (Rd.Read())
                    {
                        if (x >= 56) break;
                        scrn_Cal[x] = Rd.GetValue(1).ToString();
                        x += 1;
                    }
                    Rd.Close();
                    Global.con.Close();

                    for (I = 0; I <= 55; I++)
                    {
                        InV[I].Invoke(new Action(() => InV[I].P_Name = Global.PSName[int.Parse(scrn_Cal[I])].ToString()));

                        InV[I].Invoke(new Action(() => InV[I].BackColor = Color.Silver)); // DarkGray));
                        InV[I].Invoke(new Action(() => InV[I].P_Color = Color.Navy));
                        InV[I].Invoke(new Action(() => InV[I].U_Color = Color.Black));
                        InV[I].Invoke(new Action(() => InV[I].colFont = new System.Drawing.Font("Book Antiqua", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)))));
                        InV[I].Invoke(new Action(() => InV[I].P_Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))));
                        InV[I].Invoke(new Action(() => InV[I].U_Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))));

                        if (InV[I].P_Name == "Not_Prog")
                        {
                            InV[I].P_Name = "";
                            InV[I].P_Unit = "";
                            InV[I].Invoke(new Action(() => InV[I].colFillColorA = Color.Silver));
                            InV[I].Invoke(new Action(() => InV[I].colForeColor = Color.Silver));
                        }
                        else
                        {
                            InV[I].Invoke(new Action(() => InV[I].P_Name = Global.PSName[int.Parse(scrn_Cal[I])].ToString()));
                            InV[I].Invoke(new Action(() => InV[I].P_Unit = Global.PUnit[int.Parse(scrn_Cal[I])].ToString()));
                            InV[I].Invoke(new Action(() => InV[I].colFillColorA = Color.Teal));  // Color.SteelBlue));
                            InV[I].Invoke(new Action(() => InV[I].colForeColor = Color.White));

                        }

                    }
                    Global.Create_OnLog("Load_Arr()", "Normal ");


                    if (Global.InstantDI.Initialized) tmrWrite.Enabled = true;

                }
                catch (Exception ex)
                {
                    Global.Create_OnLog("Load_Arr()" + I, "Alart");

                }
            }
		
        public int randomvalue(int min,int max)
        {
            Random rnd = new Random();
            return rnd.Next(min,max);

        }
		//*************************

        //private void write_InputValues()
        //{
        //    try
        //    {
        //        string pr;
        //        for (int i = 0; i < 48; i++)
        //        {
        //            pr = Global.scrn_Par[i];                   
        //            frmScrII.InV[i].P_Value = Global.GenData[int.Parse(pr)];  //str;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //}

        //*********************


        private void Cal_Parameters()
        {
           
            try
            {                
                tmrInst.Interval = 1000;
                Global.GenData[105] = Global.Corfact.ToString("0.0000");
                Global.GenData[106] = (Global.varTRQ * Global.Corfact).ToString("000.0");
                Global.GenData[107] = Global.VarPowkW.ToString("00.00");
                Global.GenData[108] = Global.Corfact.ToString("0.0000");
                Global.GenData[109] = Global.Corfact.ToString("0.0000");
                Global.GenData[110] = (Global.Corfact * Global.varTRQ).ToString("0.0000");
                Global.GenData[111] = (Global.VarPowkW * Global.Corfact).ToString("00.00");
                Global.GenData[116] = (Global.VarPowHp * Global.Corfact).ToString("00.0");
                Global.GenData[121] = Global.Data[121];
                Global.GenData[122] = Global.Data[122];
                Global.GenData[123] = Global.Data[123];
                Global.GenData[124] = Global.Data[124];             
               
               Tss5.Text = Global.SmkError;  
            }
            catch (Exception ex)
            {
                return;
            }
        }
        private void DisplayInParameters()
        {
            int i;
            int sg = 0;
            string str;
            for (i = 0; i <= 32; i++)
            {
                sg = int.Parse(scrn_Cal[i]);
                if (Global.GenData[sg] == null) Global.GenData[sg] = "00.0";
                str = Global.GenData[sg];
                InV[i].P_Value = double.Parse(str);   // (string.Format("{0:00.000}", str));     // string.Format("{0:000.000}", str); 

            }
        }

        private void DisplayLimits()
        {
            try
            {
                int i;
                int sg = 0;
                string str;
                for (i = 0; i < 32; i++)
                {
                    sg = int.Parse(scrn_Cal[i]); //    i + 101).ToString();
                    str = Global.GenData[sg];
                    if ((Global.GenData[sg] != null) && (Global.PSName[sg] != "Not_Prog"))
                    {
                        if (Global.GenData[sg] == null) Global.GenData[sg] = "00.0";
                        str = Global.GenData[sg];
                        if ((Global.BufLim[sg] == "O") && (Global.flg_OffLim == true))
                        {
                            InV[i].colFillColorA = Color.Blue;
                            Tss3.Text = Global.StrAlarm;
                            Tss3.BackColor = Color.Red;
                            Tss3.ForeColor = Color.Yellow;
                            AddListItem("Engine Shut-OFF  : " + Global.PSName[sg] + " : O : " + Global.GenData[sg], "Normal");
                            Global.flg_OffLim = false;
                            LogData();
                            Update_ViewData();
                            stopEngine();
                        }
                        else if ((Global.BufLim[sg] == "I") && (Global.flg_IdleLim == true))
                        {
                            if (InV[i].colFillColorA == Color.Teal)
                            {
                                InV[i].colFillColorA = Color.Yellow;
                                InV[i].colForeColor = Color.Red;
                                Tss3.Text = Global.StrAlarm;
                                Tss3.BackColor = Color.Red;
                                Tss3.ForeColor = Color.Yellow;
                                AddListItem("Engine Idle due to : " + Global.PSName[sg] + " :  I  : " + Global.GenData[sg], "Alart");
                                Global.flg_IdleLim = false;
                                LogData();
                                Update_ViewData();
                                IdleEng();
                            }
                            else
                            {
                                InV[i].colFillColorA = Color.Teal;
                                InV[i].colForeColor = Color.White;
                            }
                        }
                        else if ((Global.BufLim[sg] == "A"))
                        {
                            InV[i].Blank_on = true; 
                        }
                        else if ((Global.BufLim[sg] == "N"))
                        {
                            InV[i].Blank_on = false; 
                        }
                            
                        //    //if (InV[i].colFillColorA == Color.Teal)
                        //    //{
                        //    //    InV[i].colFillColorA = Color.Red;
                        //    //    InV[i].colForeColor = Color.Yellow;
                        //    //    Tss3.Text = "Check Alarm .....";

                        //    //}
                        //    //else if (InV[i].colFillColorA == Color.Red)
                        //    //{
                        //    //    InV[i].colFillColorA = Color.Teal;
                        //    //    InV[i].colForeColor = Color.White;
                        //    //}

                        //}

                        else if (Global.flg_AlarmLim == true)
                        {
                            AddListItem("Alarm : " + Global.PSName[sg] + " : " + Global.GenData[sg], "Alart");
                            //AddListItem(Global.StrAlarm , "Alart");    
                            Global.flg_AlarmLim = false;
                        }
                        else if (Global.BufLim[sg] == "N")
                        {
                            InV[i].colFillColorA = Color.Teal;
                            InV[i].colForeColor = Color.White;
                        }
                        else if (sg > 100)
                        {
                            InV[i].colFillColorA = Color.Teal;
                            InV[i].colForeColor = Color.White;
                        }
                        else InV[i].Text = "";
                    }


                }

            }
            catch (Exception ex)
            {
                return;
            }

        }
      
         
        public void servicelog()
        {
            //mnusyspara.Enabled  = true;
        }
        public void supervisorlog()
        {
            mnuEditor.Enabled = true;
            mnuProject.Enabled = true; 
        }
        public void disable_log()
        {
           // mnusyspara.Enabled = false;
            mnuEditor.Enabled = false;
            mnuProject.Enabled = false; 
        }


        private void  tmrWrite_Tick(object sender, EventArgs e)
        {
            try
            {
                //plc.Open();
            //    double plcval = (double)plc.Read("DB100.DBW0");
                if (wrtCnt >= 8) wrtCnt = 0; else wrtCnt += 1;
                //Tss1.Text = Global.SFC_msg;
                flg_AnaOut = true;
                if (flg_AnaOut == true) Fun_AnalogOut_StandardChangeover();
               
                //Cal_Parameters();

                //******************************************
                //Global.flg_simulateRPM = true;

                if (Global.flg_simulateRPM == true)
                {
                    textBox1.Visible = true;
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    textBox4.Visible = true;
                    Global.S_pt1 = (int)(Global.AnaOut1 * 1000);
                    Global.S_pt2 = (int)(Global.AnaOut2 * 50);
                    Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);
                    Tss6.Text = String.Format("{0:0.000}", Global.AnaOut1);
                    if (Global.S_pt1 <= 800) Global.S_pt1 = 800;
                    if (Global.S_pt2 <= 0.10) Global.S_pt2 = 0.1;
                    int t = (int)Global.S_pt1;
                    Global.GenData[0] = RandomNumber(t - 1, t + 1).ToString("0000");
                     Global.varRPM = Convert.ToInt16(Global.GenData[0]);
                    lblRPM.Text = Global.varRPM.ToString("0000");

                    //Double X = (Double)Global.S_pt2;
                    //if (X >= 500) X = 500;
                    //Global.GenData[1] = Global.RandomNumberBetween((X + 0.2), (X - 0.1)).ToString("000.0");
                    //Global.varTRQ = Convert.ToDouble(Global.GenData[1]);
                    ////lblTrq.Text = Global.varTRQ.ToString("000.0");
                    Double X = 00.0;
                    X = 22;
                    Global.GenData[21] = Global.RandomNumberBetween((X + 1), (X - 2)).ToString("0000");
                    X = double.Parse(textBox2.Text); // 4.5;
                    Global.GenData[22] = Global.RandomNumberBetween((X + 0.1), (X - 0.02)).ToString("0.000");
                    X = 535;
                    Global.GenData[23] = Global.RandomNumberBetween((X + 1), (X - 2)).ToString("0000");
                    X = 980;
                    Global.GenData[24] = Global.RandomNumberBetween((X + 1), (X - 2)).ToString("000");
                    X = 1300;
                    Global.GenData[25] = Global.RandomNumberBetween((X + 2), (X - 3)).ToString("0000");
                    X = 800;
                    Global.GenData[26] = Global.RandomNumberBetween((X + 1), (X - 2)).ToString("0000");
                    X = 63;
                    Global.GenData[28] = Global.RandomNumberBetween((X + 0.2), (X - 0.3)).ToString("000.0");
                    X = 77;
                    Global.GenData[29] = Global.RandomNumberBetween((X + 0.1), (X - 0.2)).ToString("000.0");
                    X = 88;
                    Global.GenData[30] = Global.RandomNumberBetween((X + 0.1), (X - 0.2)).ToString("000.0");
                    X = 41;
                    Global.GenData[31] = Global.RandomNumberBetween((X + 0.1), (X - 0.2)).ToString("000.0");
                    X = 88;
                    Global.GenData[32] = Global.RandomNumberBetween((X + 0.1), (X - 0.2)).ToString("000.0");
                    X = double.Parse(textBox2.Text);  //88;
                    Global.GenData[33] = Global.RandomNumberBetween((X + 0.001), (X - 0.002)).ToString("0.000");
                    X = 112;
                    Global.GenData[37] = Global.RandomNumberBetween((X + 0.1), (X - 0.2)).ToString("000.0");
                    X = 605;   // 1322;
                    Global.GenData[38] = Global.RandomNumberBetween((X + 1), (X - 2)).ToString("0000");
                    X = double.Parse(textBox4.Text); // Tcnt * 10;   //        //635;   // 1255;
                    Global.GenData[39] = Global.RandomNumberBetween((X + 1), (X - 2)).ToString("0000");
                    X = 622;
                    Global.GenData[40] = Global.RandomNumberBetween((X + 1), (X - 2)).ToString("0000");
                    X = 450;
                    Global.GenData[41] = Global.RandomNumberBetween((X + 1), (X - 2)).ToString("0000");

                    X = 1352; // 822;
                    Global.GenData[45] = Global.RandomNumberBetween((X + 1), (X - 2)).ToString("0000");
                    X = 1234; // 605;
                    Global.GenData[46] = Global.RandomNumberBetween((X + 1), (X - 2)).ToString("0000");
                    X = 38;
                    Global.GenData[47] = Global.RandomNumberBetween((X + 1), (X - 2)).ToString("0000");
                    X = 5.2;
                    Global.GenData[48] = Global.RandomNumberBetween((X + 1), (X - 2)).ToString("0.000");
                    X = 1.8;
                    Global.GenData[52] = Global.RandomNumberBetween((X + 1), (X - 2)).ToString("0.000");
                    X = 35;
                    Global.GenData[64] = Global.RandomNumberBetween((X + 1), (X - 2)).ToString("0000");

                  
                    double r = double.Parse(Global.GenData[0]);
                    if (Global.GenData[0] != null) lblRPM.Text = r.ToString("0000"); else lblRPM.Text = "0000";
                   
                }
                else
                {
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    textBox3.Visible = false;
                    textBox4.Visible = false;

                    if (Global.GenData[0] != null)
                    {
                        double r = double.Parse(Global.GenData[0]);
                        if (Global.GenData[0] != null) lblRPM.Text = r.ToString("0000"); else lblRPM.Text = "0000";
                        Double l = Double.Parse(Global.GenData[0]);
                        Global.varRPM = Int16.Parse(l.ToString("0000"));
                    }
                    else lblRPM.Text = Global.varRPM.ToString("0000");
                    //if (Global.GenData[1] != null)
                    //{
                    //    double n = double.Parse(Global.GenData[1]);
                    //    if (Global.GenData[1] != null) lblTrq.Text = n.ToString("000.0"); else lblTrq.Text = "000.0";
                    //    Double l = Double.Parse(Global.GenData[1]);
                    //    Global.varTRQ = Math.Abs(Double.Parse(l.ToString("000.0")));
                    //    lblTrq.Text = Global.varTRQ.ToString("000.0");
                    //}
                    //else lblTrq.Text = Global.varTRQ.ToString("000.0");

                }


                //if (Global.ComPort.IsOpen == true) Global.Rd_SerialPort_RT();

                //if ((Global.MSPort.IsOpen == true)) // && (Global.SnT == 0))
                //{
                //    Global.Read_ADAMValues();
                //    //Global.SnT = 1;
                //}
                //else if (((Global.MSPort.IsOpen == true) && (Global.SnT == 1)))
                //{
                //    Global.Rd_SerialPort();
                //    Global.SnT = 0;
                //}
                Tss4.Text = Global.bufftss4;
                Tss5.Text = Global.bufftss8;
                DisplayInParameters();
                //clsECU.ReadFromECU(); 
               

                switch (wrtCnt)
                {
                    case 1:
                        
                        if (Global.Flg_Ready == true)
                        {
                            if (Global.flg_Auto == true)
                            {
                                RdProg();
                                Btn21.Enabled = true;
                                BtnSA.Enabled = false;
                                checkBox13.Text = Global.EngNo;
                                checkBox8.Text = Global.PrjNm;
                                Global.flg_Auto = false;
                                Global.Flg_Ready = false;
                            }
                            else if (Global.flg_Manual == true)
                            {
                                Btn21.Enabled = false;
                                BtnSA.Enabled = true;
                                checkBox13.Text = Global.EngNo;
                                checkBox8.Text = Global.PrjNm;
                                Global.flg_Manual = false;
                                Global.Flg_Ready = false;
                            }
                        }
                        if ((Global.MSPort.IsOpen == true)) // && (Global.SnT == 0))
                        {
                            Global.Read_ADAMValues();
                            //Global.SnT = 1;
                        }
                        //Tss5.Text = RdAdam.AdamBuf;  
                        //Tss8.Text = DateTime.Now.ToString("hh:mm:ss"); // 
                        DisplayLimits();  
                        break;
                    case 2:

                        Check_ReadyDyno(); //.Check_ReadyDyno();

                        if (Global.varRPM >= 650) //&& (Global.flg_CycleStarted == true))
                        {
                            ChkFuelP();
                            ChkLubOilP();
                            ChkWaterP();

                            //ChkLuboilT();
                            ChkWATERT();
                        }
                        break;
                    case 3:
                        if (Global.flg_Log_service == true) servicelog(); else if (Global.flg_Log_supervisor == true) supervisorlog(); else disable_log();

                        Meter1.Value = float.Parse(Global.GenData[0]);
                        //Meter2.Value = float.Parse(Global.GenData[1]);
                       

                        break;
                    case 4:
                        if ((Global.StNo > 1) && (flg_Ramp == false))
                            clsLimit.Check_Limit();
                        else
                            clsLimit.Check_Limit_Standby();
                        string Buff = "";
                        if ((Global.flg_smk = true) && (Global.smkPort.IsOpen == true))
                        {
                            Buff = Global.smkPort.ReadExisting();
                            Tss5.Text = Buff.Substring(7, 1);
                            if (Buff.Substring(7, 1) == "0")
                            {

                                Global.SmkVal = Double.Parse(Global.GenData[101]);  //Convert.ToDouble(Buff.Substring(9, 5)); //Tss5.Text;  
                            }
                        }
                        if ((Global.MSPort.IsOpen == true)) // && (Global.SnT == 0))
                        {
                            Global.Read_ADAMValues();
                            //Global.SnT = 1;
                        }
                        break;
                    case 5:
                        if (Global.varRPM >= 600) ctlLED1.tmron = true; else ctlLED1.tmron = false;
                            C_Hours = Int16.Parse(Tss2.Text.Substring(0, 4));
                            C_Minutes = Int16.Parse(Tss2.Text.Substring(5, 2));
                            C_Seconds = Int16.Parse(Tss2.Text.Substring(8, 2));
                            clsFun.TmCounter(C_Hours, C_Minutes, C_Seconds, true);
                            Tss2.Text = clsFun.cummbuff;
                            if ((Global.MSPort.IsOpen == true)) // && (Global.SnT == 0))
                            {
                                Global.Read_ADAMValues();
                                //Global.SnT = 1;
                            }
                      
                        break;
                    case 6:
                        Global.ReadAnalog();
                        Global.Read_DigIn();
                        if ((Global.flg_Manual == true) && (Global.varRPM >= 600))
                        {
                            M_Cmt++;
                            t = TimeSpan.FromSeconds(M_Cmt);
                            answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                            SS2.Text = answer;
                        }
                     
                        if (Tss3.Text != "SFC Status .....")
                        {
                        }
                        else
                        {
                            Tss3.BackColor = Color.Gainsboro;
                            Tss3.ForeColor = Color.WhiteSmoke;
                        }
                        break;
                    case 7:
                         //DisplayAlarmLimits();
                         //DisplayIdleLimits();

                        if (Global.flg_EngStart == true)
                        {



                        }
                        //if (Global.flg_EngStart == true)
                        //{
                        //   // Tss2.Text = clsFun.cummbuff;
                        //    C_Hours = Int16.Parse(Tss2.Text.Substring(0, 4));

                        //    C_Minutes = Int16.Parse(Tss2.Text.Substring(5, 2));
                        //    C_Seconds = Int16.Parse(Tss2.Text.Substring(8, 2));
                        //    clsFun.TmCounter(C_Hours, C_Minutes, C_Seconds, true);
                        //    Tss2.Text = clsFun.cummbuff;
                        //    Global.cumhours = Tss2.Text;

                        //}
                        if ((Global.MSPort.IsOpen == true)) // && (Global.SnT == 0))
                        {
                            Global.Read_ADAMValues();
                            //Global.SnT = 1;
                        }

                        break;
                    case 8:
                        //Write_Cal_Values();
                        //Tss8.Text = DateTime.Now.ToShortTimeString(); 
                        Global.VarPowkW = clsFun.kW_Power(Global.varRPM, Global.varTRQ);
                        Global.VarPowHp = clsFun.HP_Power(Global.varRPM, Global.varTRQ);

                        Double P1 = Convert.ToDouble( Global.GenData[ Global.fxd[10]]); //Global.Atp; // 
                        Double D1 = Convert.ToDouble( Global.GenData[ Global.fxd[8]]) + 4; //.Global.Drb; //
                        Double W1 = Convert.ToDouble( Global.GenData[ Global.fxd[9]]);  //  Global.Web; // Convert.ToDouble(Global.GenData[Global.fxd[9]]);

                        Global.Rel_Hum = clsFun.Cal_Rel_Humid(P1, D1, W1);
                        Global.GenData[120] = Global.Rel_Hum.ToString("00.0");
                        if (Global.Prj[4] == "CF_DIN")
                            Global.Corfact = clsFun.CF_DIN_70020(D1, P1);
                        else if (Global.Prj[4] == "CF_IS_10003")
                            Global.Corfact = clsFun.CF_IS_10000CS(Global.Rel_Hum, D1, P1);
                        else
                            Global.Corfact = clsFun.CF_DIN_70020(D1, P1);

                        if ((Global.Corfact > 1.2) || (Global.Corfact < 0.8)) Global.Corfact = 1.00000;

                        Global.GenData[105] = Global.Corfact.ToString("0.0000");

                        Global.varbmep = clsFun.Cal_bmep(Global.varTRQ, Double.Parse(Global.Svol));
                        Global.C_VarPowkW = Global.VarPowkW * Global.Corfact;
                        Global.C_VarPowHp = Global.VarPowHp * Global.Corfact;

                        //TextBox2.Text = Global.VarPowHp.ToString();

                        //TextBox3.Text = Global.Corfact.ToString();
                        if ((Global.Corfact > 1.2) && (Global.Corfact < 0.8)) Global.Corfact = 1.01234;

                        if (Global.SmkVal >= 0.01)
                            Global.GenData[101] = Global.SmkVal.ToString(); //     SmkVal;
                        else
                            Global.GenData[101] = "0.01";
                        Global.GenData[102] = Global.GenData[46];
                        Global.GenData[103] = Global.GenData[3];
                        Global.GenData[104] = Global.GenData[4];
                        Global.GenData[105] = Global.Corfact.ToString("0.0000");
                        Global.GenData[106] = Global.varTRQ.ToString("00.0");
                        Global.GenData[107] = Global.VarPowkW.ToString("00.0");
                        Global.GenData[110] = ((Global.varTRQ) * (Global.Corfact)).ToString("00.0");
                        Global.GenData[111] = (Global.VarPowkW).ToString("00.0");
                        Global.GenData[115] = Global.VarPowHp.ToString("00.0");
                        Global.GenData[116] = ((Global.VarPowHp) * (Global.Corfact)).ToString("00.0");
                        Global.GenData[119] = Global.varbmep.ToString();
                        Global.GenData[120] = Global.Rel_Hum.ToString("00.0");
                        Global.GenData[123] = Tss2.Text;
                        break;

                }

            }

            catch (Exception ex)
            {
               // MessageBox.Show("Error in frmMain: tmrWrite_Tick(): " + ex.Message, "Dynalec Control Pvt Ltd.",
               //  MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Error in frmMain: tmrWrite_Tick():  " +  wrtCnt + ex.Message);
                //Global.Create_OnLog(ex.Message);
                return;
            }

        }
        private void init_ReadyStatus()
        {
            try
            {
                if (Global.sysIn[20] == "FALSE")
                {
                    checkBox3.CheckState = CheckState.Unchecked;
                    checkBox3.Text = "ENG.FUEL PRESS NOT CHECKED....." ;                 
                }
                else
                {
                    checkBox3.CheckState = CheckState.Indeterminate;
                    Lower1 = double.Parse(Global.sysIn[21]);
                    High1 = double.Parse(Global.sysIn[22]);
                    checkBox3.Text = "ENG. FUEL PRESS : " + Lower1 + " ~ " + High1;                    
                }


                if (Global.sysIn[23] == "FALSE")
                {
                    checkBox4.CheckState = CheckState.Unchecked;
                    checkBox4.Text = "ENG.LUBOIL PRESS NOT CHECKED.....";                   
                }
                else
                {
                    checkBox4.CheckState = CheckState.Indeterminate;
                    Lower2 = double.Parse(Global.sysIn[24]);
                    High2 = double.Parse(Global.sysIn[25]);
                    checkBox4.Text = "ENG. LUBOIL PRESS : " + Lower2 + " ~ " + High2;                   
                }

                if (Global.sysIn[26] == "FALSE")
                {
                    checkBox5.CheckState = CheckState.Unchecked;
                    checkBox5.Text = "ENG. WATER PRESS NOT CHECKED......";                   
                }
                else
                {
                    checkBox5.CheckState = CheckState.Indeterminate;
                    Lower3 = double.Parse(Global.sysIn[27]);
                    High3 = double.Parse(Global.sysIn[28]);
                    checkBox5.Text = "ENG. WATER PRESS : " + Lower3 + " ~ " + High3;                  
                }

                if (Global.sysIn[29] == "FALSE")
                {
                    checkBox6.CheckState = CheckState.Unchecked;
                    checkBox6.Text = "ENG. LUBOIL TEMP NOT CHECKED....";                   
                }
                else
                {
                    checkBox6.CheckState = CheckState.Indeterminate;
                    Lower4 = double.Parse(Global.sysIn[30]);
                    High4 = double.Parse(Global.sysIn[31]);
                    checkBox6.Text = "ENG LUBOIL TEMP : " + Lower4 + " ~ " + High4;
                    
                }

                if (Global.sysIn[32] == "FALSE")
                {
                    checkBox7.CheckState = CheckState.Unchecked;
                    checkBox7.Text = "ENG. WATER TEMP NOT CHECKED.....";                   
                }
                else
                {
                    checkBox7.CheckState = CheckState.Indeterminate;
                    Lower5 = double.Parse(Global.sysIn[33]);
                    High5 = double.Parse(Global.sysIn[34]);
                    checkBox7.Text = "ENG. WATER TEMP: " + Lower5 + " ~ " + High5;                    
                }
                //if (Global.flg_Radiator == true)
                //{
                //    checkBox16.Text = "REDIATOR CONNECTED ........";
                //    checkBox16.CheckState = CheckState.Indeterminate  ;
                //    checkBox16.ForeColor = Color.MediumBlue; 
                //}
                //else
                //{
                //    checkBox16.Text = "REDIATOR NOT CONNECTED ........";
                //    checkBox16.CheckState = CheckState.Unchecked; 
                //    //checkBox16.ForeColor = Color.Red;  
                //}
                //if (Global.flg_Fan == true)
                //{
                //    checkBox17.Text = "COOLING FAN CONNECTED ........";
                //    checkBox17.CheckState = CheckState.Indeterminate;
                //    //checkBox17.ForeColor = Color.MediumBlue;
                //}
                //else
                //{
                //    checkBox17.Text = "COOLING FAN  NOT CONNECTED ........";
                //    checkBox16.CheckState = CheckState.Unchecked; 
                //    //checkBox17.ForeColor = Color.Red;
                //}
                //if (Global.flg_AirCln == true)
                //{
                //    checkBox18.Text = "AIR CLEANER CONNECTED ........";
                //    checkBox18.CheckState = CheckState.Indeterminate;
                //    //checkBox18.ForeColor = Color.MediumBlue;
                //}
                //else
                //{
                //    checkBox18.Text = "AIR CLEANER NOT CONNECTED ........";
                //    checkBox18.CheckState = CheckState.Unchecked; 
                //    //checkBox18.ForeColor = Color.Red;
                //}
                //if (Global.flg_Silincer == true)
                //{
                //    checkBox19.Text = "SILINCER CONNECTED ........";
                //    checkBox19.CheckState = CheckState.Indeterminate;
                //    //checkBox19.ForeColor = Color.MediumBlue;
                //}
                //else
                //{
                //    checkBox19.Text = "SILINCER NOT CONNECTED ........";
                //    checkBox19.CheckState = CheckState.Unchecked; 
                //    //checkBox19.ForeColor = Color.Red;
                //}


            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: Init_ReadyStatus():", "Alert");
                MessageBox.Show("Error in frmMain: Init_ReadyStatus():" + '\n'+ ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("E""rror in frmMain: Init_ReadyStatus():  " + ex.Message);
            }
        }
               private void Check_ReadyDyno()
        {
            try
            {                
                if (Global.DigIn[4] ==  int.Parse(textBox1.Text)) //       0)  //1)  
                {
                    UpdateCheckBox(checkBox2, 0);
                    checkBox2.Text = " NO SYSTEM - ALARM ....";                
                    cntDSafty = 0;                   
                    flg_ProgEnd = false;
                    flg_dynaSafety = false;                   
                }
                else
                {
                    UpdateCheckBox(checkBox2, 1);
                    Btn21.Enabled = false; 
                    checkBox2.Text = " CHECK SYSTEM-ALARM...ENG. NOT READY";
                    if ((Global.varRPM > 600) && (Global.flg_CycleStarted == true))
                    {
                        
                        if (cntDSafty < 3) cntDSafty += 1;
                        if (cntDSafty == 3)
                        {
                            if (flg_dynaSafety == false)
                            {
                                checkBox2.BackColor = Color.Red;  
                                checkBox2.ForeColor = Color.Yellow;
                                AddListItem("Engine is @ idle due to " + checkBox2.Text + " at RPM :" + Global.varRPM, "Alart");
                                flg_dynaSafety = true;                               
                                flg_ChkAlarmON = true;
                                Btn22.PerformClick();                                
                            }                          
                        }
                    }
                }               
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: Check_ReadyDyno():", "Alert");
            }
       }

              

        private void ChkFuelP()
        {
            try
            {
                //if (checkBox3.Checked == true) Global.DigIn[3] = 1; else Global.DigIn[3] = 0;
                if (checkBox3.CheckState == CheckState.Indeterminate)
                {

                    Double l = Convert.ToDouble(Global.GenData[Global.fxd[3]]);
                    if ((l > Lower1) && (l < High1))
                    {
                        UpdateCheckBox(checkBox3, 0);
                        checkBox3.Text = "ENG. FUEL PRESS : " + Lower1 + "~" + High1;
                        fPCnt = 0; 
                        flg_ProgEnd = false;
                        flg_addfuelpres = true;
                        flg_FuelPress = false;                       
                    }
                    else
                    {

                        flg_addfuelpres = false;
                        UpdateCheckBox(checkBox3, 1);
                        checkBox3.Text = "CHECK ENGINE FUEL PRESSURE...";
                        if (fPCnt <= 3) fPCnt += 1; else fPCnt = 4;
                        if (fPCnt >= 4)
                        {
                            if ((flg_addfuelpres == false) && (flg_FuelPress == false))
                            {
                                checkBox3.BackColor = Color.Red;
                                checkBox3.ForeColor = Color.Yellow;
                                Global.Create_OnLog("Engine is off due to " + checkBox3.Text + " at RPM :" + Global.varRPM, "Alart");
                                flg_FuelPress = true;
                                Btn22.PerformClick();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: Check_FUEL Press():", "Alert");
            }

        }

        private void ChkLubOilP()
        {
            try
            {
                //if (checkBox4.Checked == true) Global.fxd[4] = 1; else Global.fxd[4] = 0;
                if (checkBox4.CheckState == CheckState.Indeterminate)
                {
                    Double l = Convert.ToDouble(Global.GenData[(Global.fxd[4])]);
                    if ((l > Lower2) && (l < High2))
                    {
                        UpdateCheckBox(checkBox4, 0);
                        checkBox4.Text = "ENG. LUBOIL PRESS : " + Lower2 + "~" + High2;
                        lPCnt = 0;
                        flg_ProgEnd = false;
                        flg_addLuboilpres = true;
                        flg_OilPress = false;
                    }
                    else
                    {
                        flg_addLuboilpres = false;
                        UpdateCheckBox(checkBox4, 1);
                        checkBox4.Text = "CHECK ENGINE LUBOIL PRESS...";
                        if (lPCnt <= 3) lPCnt += 1; else lPCnt = 4;
                        if (lPCnt >= 4) 
                        {
                            if ((flg_addLuboilpres == false) && (flg_OilPress == false))
                            {
                                checkBox4.BackColor = Color.Red;
                                checkBox4.ForeColor = Color.Yellow;
                                Global.Create_OnLog("Engine is off due to " + checkBox4.Text + " at RPM :" + Global.varRPM, "Alart");
                                flg_OilPress  = true;
                                Btn22.PerformClick();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: Check LUBOILPress():", "Alart");
                //MessageBox.Show("Error in ChkFuelP(): " + ex.Message);
            }
        }

        private void ChkWaterP()
        {
            try
            {
                if (checkBox5.CheckState == CheckState.Indeterminate)
                {
                    Double l = Convert.ToDouble(Global.GenData[Global.fxd[2]]);
                    if ((l > Lower3) && (l < High3))
                    {
                        UpdateCheckBox(checkBox5, 0);
                        checkBox5.Text = "ENG. WATER PRESS : " + Lower3 + "~" + High3;
                        wPCnt = 0;
                        flg_ProgEnd = false;
                        flg_addwtrpres = true;
                        flg_WtrPress = false;
                    }
                    else
                    {
                        flg_addwtrpres = false;
                        UpdateCheckBox(checkBox5, 1);
                        checkBox5.Text = "Check ENGINE WATER  PRESS...";

                        if (wPCnt <= 3) wPCnt += 1; else wPCnt = 4;
                        if (wPCnt == 4)
                        {
                            if ((flg_WtrPress == false) && (flg_addwtrpres == false))
                            {
                                checkBox5.BackColor = Color.Red;
                                checkBox5.ForeColor = Color.Yellow;
                                AddListItem("Engine is @ idle due to " + checkBox5.Text + " at RPM :" + Global.varRPM, "Alart");
                                flg_WtrPress = true;
                                flg_ChkAlarmON = true;
                                Btn22.PerformClick();
                            } 
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: ChkEATERP():", "Alart");
                //MessageBox.Show("Error in ChkLubP(): " + ex.Message);
            }
        }


      private void ChkLuboilT()
        {
            try
            {

                if (checkBox6.CheckState == CheckState.Indeterminate)
                {
                    Double l = Convert.ToDouble(Global.GenData[Global.fxd[7]]);
                    if ((l > Lower4) && (l < High4))
                    {
                        UpdateCheckBox(checkBox6, 0);
                        checkBox6.Text = "ENG. LUBOIL TEMP : " + Lower4 + "~" + High4;
                        wTCnt  = 0;
                        flg_ProgEnd = false;
                        flg_WtrTemp  = false;
                        flg_addwtrtemp  = true;

                    }
                    else
                    {
                        if (flg_addwtrtemp  == true) UpdateCheckBox(checkBox6, 1);
                        checkBox6.Text = "CHECK ENG> LUBOIL TEMP....";
                        if (wTCnt < 3) wTCnt  += 1; else wTCnt = 4;
                        if (wTCnt  == 3)
                        {
                            if (flg_addwtrtemp  == false)
                            {
                                //AddListItem("Engine is @ idle due to " + checkBox6.Text + " at RPM :" + Global.varRPM, 9);
                                Global.Create_OnLog("Engine is @ idle due to " + checkBox4.Text + " at RPM :" + Global.varRPM, "Alert");
                                flg_addwtrtemp  = true;
                            }

                            if (Global.flg_EngStart == true) tmrEnd.Enabled = true;
                        }
                    }
                }               
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: ChkLUBOILrT():" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Global.Create_OnLog("Error in frmMain: ChkLUBOILrT():", "Alert"); 
                //MessageBox.Show("Error in ChkWtrT(): " + ex.Message);
            }
        }

        private void ChkWATERT()
        {
            try
            {

                if (checkBox7.CheckState == CheckState.Indeterminate)
                {
                    Double l = Convert.ToDouble(Global.GenData[Global.fxd[5]]);
                    if ((l > Lower5) && (l < High5))
                    {
                        UpdateCheckBox(checkBox7, 0);
                        checkBox7.Text = "ENG. WATER TEMP. : " + Lower5 + "~" + High5;
                        lTCnt = 0;
                        flg_ProgEnd = false;
                        flg_WtrTemp = false;
                        flg_addwtrtemp = true;

                    }
                    else
                    {
                        if (flg_addwtrtemp == true) UpdateCheckBox(checkBox7, 1);
                        checkBox7.Text = "CHECK ENGINE WATER TEMP....";
                        if (lTCnt < 3) lTCnt += 1; else lTCnt = 4;
                        if (lTCnt == 3)
                        {
                            if (flg_addwtrtemp == false)
                            {
                                //AddListItem("Engine is @ idle due to " + checkBox7.Text + " at RPM :" + Global.varRPM, 9);
                                Global.Create_OnLog("Engine is @ idle due to " + checkBox7.Text + " at RPM :" + Global.varRPM, "Alert");
                                flg_addwtrtemp = true;
                            }

                            if (Global.flg_EngStart == true) tmrEnd.Enabled = true;

                        }
                    }
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: ChkWATERT():" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Global.Create_OnLog("Error in frmMain: ChkWATERT():", "Alert"); 
                //MessageBox.Show("Error ChkLubT() : " + ex.Message);
            }
        }

        private void Update_Tss1(int Stus)
        {
            try
            {
                if (Stus == 0)
                {
                    Tss1.BackColor = Color.Gainsboro;
                    Tss1.ForeColor = Color.Brown;
                    //Tss1.Text = Global.SFC_msg; 
                }
                //else if (Stus == 1)
                //{
                //    if (Tss1.BackColor == Color.Gainsboro)
                //    {
                //        Tss1.BackColor = Color.Red;
                //        Tss1.ForeColor = Color.Yellow;
                //    }
                //    else if (Tss1.BackColor == Color.Red)
                //    {
                //        Tss1.BackColor = Color.Gainsboro;
                //        Tss1.ForeColor = Color.Brown;
                //    }

                //}
            }
            catch (Exception ex)
            {
                return;//MessageBox.Show("Error in frmMain: update_tss11():  " + ex.Message);
            }
        }

       

        private void Update_Hold(int Stus)
        {
            try
            {
                if (Stus == 0)
                {
                    Tss1.BackColor = Color.Gainsboro;
                    Tss1.ForeColor = Color.Brown;
                }
                else if (Stus == 1)
                {
                    if (Tss1.BackColor == Color.Gainsboro)
                    {
                        Tss1.BackColor = Color.Red;
                        Tss1.ForeColor = Color.Yellow;
                    }
                    else if (Tss1.BackColor == Color.Red)
                    {
                        Tss1.BackColor = Color.Gainsboro;
                        Tss1.ForeColor = Color.Brown;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: update_Hold():" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                 //MessageBox.Show("Error in frmMain: update_Hold():  " + ex.Message);
            }
        }



        private void UpdateCheckBox(CheckBox Chk, int Stt)
        {
            try
            {
                if (Stt == 0)
                {
                    Chk.ForeColor = Color.Navy ;
                    Chk.BackColor = Color.Gainsboro;
                    //groupBox4.SendToBack();  
                }
                else if (Stt == 1)
                {
                    //groupBox4.BringToFront();  
                    switch (Chk.Name)
                    {
                        //case "checkBox1":
                        //    if (checkBox1.BackColor == Color.Gainsboro)
                        //    {
                        //        checkBox1.BackColor = Color.Red;
                        //        checkBox1.ForeColor = Color.Yellow;
                        //    }

                        //    else if (checkBox1.BackColor == Color.Red)
                        //    {
                        //        checkBox1.BackColor = Color.Gainsboro;  //SystemColors.ButtonFace;
                        //        checkBox1.ForeColor = Color.Navy;
                        //    }
                        //    break;
                        case "checkBox2":
                            if (checkBox2.BackColor == Color.Gainsboro)
                            {
                                //flg_addPlCAlarm = false;
                                checkBox2.BackColor = Color.Red;
                                checkBox2.ForeColor = Color.Yellow;
                            }

                            else if (checkBox2.BackColor == Color.Red)
                            {
                                checkBox2.BackColor = Color.Gainsboro;  //
                                checkBox2.ForeColor = Color.Navy;
                            }
                            break;
                        case "checkBox3":
                            if (checkBox3.BackColor == Color.Gainsboro)
                            {
                                flg_addwtrpres = false;
                                checkBox3.BackColor = Color.Red;
                                checkBox3.ForeColor = Color.Yellow;
                            }
                            else if (checkBox3.BackColor == Color.Red)
                            {
                                checkBox3.BackColor = Color.Gainsboro;  //SystemColors.ButtonFace;
                                checkBox3.ForeColor = Color.Navy;
                            }
                            break;
                        case "checkBox4":
                            if (checkBox4.BackColor == Color.Gainsboro)
                            {
                                flg_addfuelpres = false;
                                checkBox4.BackColor = Color.Red;
                                checkBox4.ForeColor = Color.Yellow;

                            }
                            else if (checkBox4.BackColor == Color.Red)
                            {
                                checkBox4.BackColor = Color.Gainsboro;  //SystemColors.ButtonFace;
                                checkBox4.ForeColor = Color.Navy;
                            }

                            break;
                        case "checkBox5":
                            if (checkBox5.BackColor == Color.Gainsboro)
                            {
                                flg_addLuboilpres = false;
                                checkBox5.BackColor = Color.Red;
                                checkBox5.ForeColor = Color.Yellow;
                            }
                            else if (checkBox5.BackColor == Color.Red)
                            {
                                checkBox5.BackColor = Color.Gainsboro;
                                checkBox5.ForeColor = Color.Navy;
                            }
                            break;
                        case "checkBox6":
                            if (checkBox6.BackColor == Color.Gainsboro)  //SystemColors.ButtonFace)
                            {
                                flg_addwtrtemp = false;
                                checkBox6.BackColor = Color.Red;
                                checkBox6.ForeColor = Color.Yellow;
                            }
                            else if (checkBox6.BackColor == Color.Red)
                            {
                                checkBox6.BackColor =Color.Gainsboro;  // SystemColors.ButtonFace;
                                checkBox6.ForeColor = Color.Navy;
                            }
                            break;
                        case "checkBox7":
                            if (checkBox7.BackColor == Color.Gainsboro)
                            {
                                flg_addLuboilTemp = false;
                                checkBox7.BackColor = Color.Red;
                                checkBox7.ForeColor = Color.Yellow;
                            }
                            else if (checkBox7.BackColor == Color.Red)
                            {
                                checkBox7.BackColor = Color.Gainsboro;  //SystemColors.ButtonFace;
                                checkBox7.ForeColor = Color.Navy;
                            }
                            break;

                    }
                }
               
                  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: UpdateChexkbox(): " + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Error in frmMain: UpdateChexkbox():  " + ex.Message);
            }
        }
        private void Show_Dialog()
        {
            if ((flg_WtrPress == true) || (flg_dynaSafety == true) || (flg_WtrTemp == true) || (flg_EngRd == true)
                        || (flg_OliTemp == true) || (flg_FuelPress == true) || (flg_OilPress == true))
            {
               
                panel2.BringToFront();
                panel2.Visible = true;
            }
            else
            {

                panel2.BringToFront();
                panel2.Visible = false;
            }
        }

        
       
           //***********************
        public void Load_ProgStep()
        {
            try
            {
                String T = "0";
                String D = "0";
                String CH = "0";
                Global.SmkVal = 0.00;
                Global.L_Mode = Global.C_Mode;
                Global.StrAlarm = "";
                flg_chkpass = false;

                Global.S_StartTime = System.DateTime.Now.ToString("hh:mm:ss tt"); 
                if (tmrAvg.Enabled == true)
                {
                    tmrAvg.Stop();
                    AddListItem("Averaging Intrrupted for SFC....", "Normal");
                }
                Tss3.Text = "Alarm Status.....";
                Tss3.BackColor = Color.Gainsboro;
             
               Tss3.ForeColor = Color.Red;
                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand("DELETE FROM avgTemp", Global.con);
                cmd.ExecuteNonQuery();
                //checkBox13.Text = Global.StpLimFl; 
                //if (Global.StpN >= 1)
                //{
                //    clsLimit.Read_Limfl();
                //}

                if ((Global.StpN + 1) > (GridSeq1.RowCount - 1))
                {
                    stopEngine();
                    AddListItem("Program Over.....", "Normal");
                }

                AddListItem((Global.StpN + 1) + " : Prog.Step Started", "Alert");
                txtStepNo.Text = String.Format("{0:000}", (Global.StpN + 1));
                Global.flg_RLoop = false;
                Global.StNo = (Global.StpN + 1);
                Global.LastAna1 = Double.Parse(Global.SetPtOut1);
                Global.LastAna2 = Double.Parse(Global.SetPtOut2);

                GridSeq1.Rows[Global.StpN].Selected = true;
                if (Global.StpN >= 3) GridSeq1.FirstDisplayedScrollingRowIndex = (Global.StpN - 1);

                if (GridSeq1[0, Global.StpN].Value != null)
                {
                    Global.C_Mode = GridSeq1.Rows[Global.StpN].Cells[1].Value.ToString();
                    T = GridSeq1.Rows[Global.StpN].Cells[3].Value.ToString();
                    TmR1 = ((int.Parse(T.Substring(0, 2)) * 3600) + (int.Parse(T.Substring(3, 2)) * 60) + int.Parse(T.Substring(6, 2)));
                    if (TmR1 <= 1) TmR1 = 1;
                    T = GridSeq1.Rows[Global.StpN].Cells[5].Value.ToString();
                    TmR2 = ((int.Parse(T.Substring(0, 2)) * 3600) + (int.Parse(T.Substring(3, 2)) * 60) + int.Parse(T.Substring(6, 2)));
                    if (TmR2 <= 1) TmR2 = 1;


                    T = GridSeq1.Rows[Global.StpN].Cells[6].Value.ToString();
                    Tstb = ((int.Parse(T.Substring(0, 2)) * 3600) + (int.Parse(T.Substring(3, 2)) * 60) + int.Parse(T.Substring(6, 2)));

                    T = GridSeq1.Rows[Global.StpN].Cells[7].Value.ToString();
                    Tstd = ((int.Parse(T.Substring(0, 2)) * 3600) + (int.Parse(T.Substring(3, 2)) * 60) + int.Parse(T.Substring(6, 2)));
                    SockT = Tstd;
                    if (TmR1 > TmR2) TmR = TmR1; TmR = TmR2;
                    PBar3.Maximum = TmR + 1;

                    T = GridSeq1.Rows[ Global.StpN].Cells[8].Value.ToString();    //stop
                    Tstp = ((int.Parse(T.Substring(1, 2)) * 60) + int.Parse(T.Substring(4, 2)));


                    //Repeat

                    //LoGdata
                    T = GridSeq1.Rows[Global.StpN].Cells[10].Value.ToString();
                    CH = T.Substring(0, 1);
                    switch (CH)
                    {
                        case "Y":
                            LogT = 5;
                            flg_PerStep = true;
                            flg_Instat = false;
                            flg_Avg = false;
                            flg_SaveData = true;
                            break;
                        case "H":
                            LogT = 5;
                            flg_flyUp = true;
                            flg_PerStep = false;
                            flg_Instat = false;
                            flg_Avg = false;
                            break;
                        case "L":
                            LogT = 5;
                            flg_Idle = true;
                            flg_flyUp = false;
                            flg_PerStep = false;
                            flg_Instat = false;
                            flg_Avg = false;
                            break;
                        case "I":
                            LogT = (int.Parse(T.Substring(1, 2)) * 60) + int.Parse(T.Substring(4, 2));
                            flg_PerStep = false;
                            flg_Instat = true;
                            flg_Avg = false;
                            DataCnt = LogT;
                            break;
                        case "A":
                            LogT = (int.Parse(T.Substring(1, 2)) * 60) + int.Parse(T.Substring(4, 2));
                            flg_PerStep = false;
                            flg_Instat = false;
                            flg_Avg = true;
                            DataCnt = LogT;
                            break;
                        case "N":
                            LogT = 0;
                            flg_PerStep = false;
                            flg_Instat = false;
                            flg_Avg = false;
                            DataCnt = LogT;
                            break;
                        default:
                            LogT = 0;
                            flg_PerStep = false;
                            flg_Instat = false;
                            flg_Avg = false;
                            break;
                    }


                    if (GridSeq1.Rows[Global.StpN].Cells[11].Value.ToString() == "True")                   
                        Global.flg_SMK415_S = true;
                    else
                        Global.flg_SMK415_S = false;
                    

                    if (GridSeq1.Rows[Global.StpN].Cells[12].Value.ToString() == "True")                    
                        flg_chkpass = true;
                    else
                        flg_chkpass = false;

                    if (GridSeq1.Rows[Global.StpN].Cells[13].Value.ToString() == "True")                   
                        Global.Auto_SFC = true;
                    else   
                        Global.Auto_SFC = false;
                    

                    Global.StpComm = GridSeq1.Rows[Global.StpN].Cells[14].Value.ToString();
                    TolT = GridSeq1.Rows[Global.StpN].Cells[15].Value.ToString();

                    if (GridSeq1.Rows[Global.StpN].Cells[16].Value.ToString() == "True")                    
                        Global.flg_DoOut1 = true;
                    else
                        Global.flg_DoOut1 = false;

                    if (GridSeq1.Rows[Global.StpN].Cells[17].Value.ToString() == "True")
                        Global.flg_DoOut2 = true;
                    else
                        Global.flg_DoOut2 = false;

                    if (GridSeq1.Rows[Global.StpN].Cells[18].Value.ToString() == "True")
                        Global.flg_DoOut3 = true;
                    else
                        Global.flg_DoOut3 = false;










                  

                    minPassOfLim[0] = GridSeq1[19, Global.StpN].Value.ToString().Substring(0, GridSeq1[19, Global.StpN].Value.ToString().IndexOf('-'));
                    maxPassOfLim[0] = GridSeq1[19, Global.StpN].Value.ToString().Substring(GridSeq1[19, Global.StpN].Value.ToString().IndexOf('-') + 1);

                    minPassOfLim[1] = GridSeq1[20, Global.StpN].Value.ToString().Substring(0, GridSeq1[20, Global.StpN].Value.ToString().IndexOf('-'));
                    maxPassOfLim[1] = GridSeq1[20, Global.StpN].Value.ToString().Substring(GridSeq1[20, Global.StpN].Value.ToString().IndexOf('-') + 1);

                    minPassOfLim[2] = GridSeq1[21, Global.StpN].Value.ToString().Substring(0, GridSeq1[21, Global.StpN].Value.ToString().IndexOf('-'));
                    maxPassOfLim[2] = GridSeq1[21, Global.StpN].Value.ToString().Substring(GridSeq1[21, Global.StpN].Value.ToString().IndexOf('-') + 1);

                    minPassOfLim[3] = GridSeq1[22, Global.StpN].Value.ToString().Substring(0, GridSeq1[22, Global.StpN].Value.ToString().IndexOf('-'));
                    maxPassOfLim[3] = GridSeq1[22, Global.StpN].Value.ToString().Substring(GridSeq1[22, Global.StpN].Value.ToString().IndexOf('-') + 1);

                    minPassOfLim[4] = GridSeq1[23, Global.StpN].Value.ToString().Substring(0, GridSeq1[23, Global.StpN].Value.ToString().IndexOf('-'));
                    maxPassOfLim[4] = GridSeq1[23, Global.StpN].Value.ToString().Substring(GridSeq1[23, Global.StpN].Value.ToString().IndexOf('-') + 1);

                    minPassOfLim[5] = GridSeq1[24, Global.StpN].Value.ToString().Substring(0, GridSeq1[24, Global.StpN].Value.ToString().IndexOf('-'));
                    maxPassOfLim[5] = GridSeq1[24, Global.StpN].Value.ToString().Substring(GridSeq1[24, Global.StpN].Value.ToString().IndexOf('-') + 1);

                    minPassOfLim[6] = GridSeq1[25, Global.StpN].Value.ToString().Substring(0, GridSeq1[25, Global.StpN].Value.ToString().IndexOf('-'));
                    maxPassOfLim[6] = GridSeq1[25, Global.StpN].Value.ToString().Substring(GridSeq1[25, Global.StpN].Value.ToString().IndexOf('-') + 1);

                    minPassOfLim[7] = GridSeq1[26, Global.StpN].Value.ToString().Substring(0, GridSeq1[26, Global.StpN].Value.ToString().IndexOf('-'));
                    maxPassOfLim[7] = GridSeq1[26, Global.StpN].Value.ToString().Substring(GridSeq1[26, Global.StpN].Value.ToString().IndexOf('-') + 1);

                    minPassOfLim[8] = GridSeq1[27, Global.StpN].Value.ToString().Substring(0, GridSeq1[27, Global.StpN].Value.ToString().IndexOf('-'));
                    maxPassOfLim[8] = GridSeq1[27, Global.StpN].Value.ToString().Substring(GridSeq1[27, Global.StpN].Value.ToString().IndexOf('-') + 1);

                    minPassOfLim[9] = GridSeq1[28, Global.StpN].Value.ToString().Substring(0, GridSeq1[28, Global.StpN].Value.ToString().IndexOf('-'));
                    maxPassOfLim[9] = GridSeq1[28, Global.StpN].Value.ToString().Substring(GridSeq1[28, Global.StpN].Value.ToString().IndexOf('-') + 1);

                   


                    Global.StpLimFl = GridSeq1.Rows[Global.StpN].Cells[29].Value.ToString();
                    clsLimit.Read_Limfl();                   
                    AddListItem(Global.StpLimFl, "Normal");

                    //checkBox13.Text = Global.StpLimFl;
                    //if (Global.StpN >= 1)
                    //{
                    //    clsLimit.Read_Limfl();
                    //}

                    //**********************************
                    int pos1 = 0;
                    string str1 = "";
                    int pos2 = 0;
                    string str2 = "";

                    switch (Global.C_Mode)
                        {
                            case "6":
                                //str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                                //pos1 = str1.IndexOf(" ", 0);
                                //T = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                //label9.Text = "Rpm";
                                //Global.SetPtOut1 = ((Convert.ToDouble(T) * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                                //str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                                //pos2 = str2.IndexOf(" ", 0);
                                //D = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                                //label10.Text = "Nm";
                                //Global.SetPtOut2 = ((Convert.ToDouble(D) * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                                break;
                            case "5":
                                //str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                                //pos1 = str1.IndexOf(" ", 0);
                                //T = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                //label9.Text = "Rpm";
                                //Global.SetPtOut1 = ((Convert.ToDouble(T) * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                                //str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                                //pos2 = str2.IndexOf(" ", 0);
                                //D = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);

                                //label10.Text = "%";
                                //Global.SetPtOut2 = ((Double.Parse(D)) / 10).ToString();
                                break;
                            case "4":
                                //str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                                //pos1 = str1.IndexOf(" ", 0);
                                //D = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                //label9.Text = "Rpm";
                                //Global.SetPtOut1 = ((Convert.ToDouble(D) * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                                //str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                                //pos2 = str2.IndexOf(" ", 0);
                                //T = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                                //label10.Text = "Nm";
                                //Global.SetPtOut2 = ((Convert.ToDouble(T) * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                                break;
                            case "3":
                                //str1 = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString();
                                //pos1 = str1.IndexOf(" ", 0);
                                //D = GridSeq.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                //label9.Text = "%";
                                //Global.SetPtOut1 = ((Double.Parse(D)) / 10).ToString();
                                //str2 = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString();
                                //pos2 = str2.IndexOf(" ", 0);
                                //T = GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                                //label10.Text = "Nm";
                                //Global.SetPtOut2 = ((Convert.ToDouble(T) * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                                break;
                            case "2":
                                str1 = GridSeq1.Rows[Global.StpN].Cells[2].Value.ToString();
                                pos1 = str1.IndexOf(" ", 0);
                                D = GridSeq1.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                label9.Text = "Rpm";
                                Global.SetPtOut1 = ((Convert.ToDouble(D) * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                                str2 = GridSeq1.Rows[Global.StpN].Cells[4].Value.ToString();
                                pos2 = str2.IndexOf(" ", 0);
                                T = "00.00"; //0GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                                //label10.Text = "%";
                                Global.SetPtOut2 = ((Double.Parse(T)) / 10).ToString();
                                break;
                            default:
                                str1 = GridSeq1.Rows[Global.StpN].Cells[2].Value.ToString();
                                pos1 = str1.IndexOf(" ", 0);
                                D = GridSeq1.Rows[Global.StpN].Cells[2].Value.ToString().Substring(0, pos1);
                                label9.Text = "%";
                                Global.SetPtOut1 = ((Double.Parse(D)) / 10).ToString();
                                str2 = GridSeq1.Rows[Global.StpN].Cells[4].Value.ToString();
                                pos2 = str2.IndexOf(" ", 0);
                                T = "00.00";   // GridSeq.Rows[Global.StpN].Cells[4].Value.ToString().Substring(0, pos2);
                                //label10.Text = "%";
                                Global.SetPtOut2 = ((Double.Parse(T)) / 10).ToString();
                                break;

                        }
                    Global.SetPtTc = Global.SetPtOut1;
                    Global.SetPtDc = Global.SetPtOut2;

                    //Global.PIDPort.DiscardOutBuffer();



                    Global.LastT = Convert.ToDouble(T);
                    Global.LastD = Convert.ToDouble(D);
                    if (TmR1 <= 1) TmR1 = 1;
                    if (TmR2 <= 1) TmR2 = 1;

                    if (TmR1 >= TmR2) TmR = TmR1; else TmR = TmR2;

                    //***********************
                    RMP1 = int.Parse(textBox9.Text) * 9;
                    RMP2 = int.Parse(textBox8.Text) * 9;

                    if ((int.Parse(Global.L_Mode) == 5) && (int.Parse(Global.C_Mode) == 6))
                        Global.AnaOut2 = Global.LastAna2;
                    else if ((int.Parse(Global.L_Mode) == 6) && (int.Parse(Global.C_Mode) == 5))
                        Global.AnaOut2 = Global.LastAna2;

                    Global.Diff1 = (Double.Parse(Global.SetPtOut1) - (Global.LastAna1)) / (TmR1 * 9);
                    Global.Diff2 = (Double.Parse(Global.SetPtOut2) - (Global.LastAna2)) / (TmR2 * 9);

                    if ((int.Parse(Global.L_Mode) == 1) && (int.Parse(Global.C_Mode) >= 5))
                    {
                        Global.AnaOut1 = double.Parse(Global.SetPtOut1);
                        TmR1 = 1;
                    }
                    Double TC = Double.Parse(Global.SetPtTc);
                    Double DC = Double.Parse(Global.SetPtDc);
                   
                    ///////////////////// 
                    OutBuffer = "";
                    Global.Create_OnLog("Step Started :" + Global.StNo, "Normal");
                    //PBar1.Maximum = 10000;
                    PBar2.Maximum = 10000;

                    //if (int.Parse(Global.C_Mode) <= 4)
                    OutBuffer = "$,  " + (Global.C_Mode.ToString() + ", " + D + ", " + TmR1.ToString() + ", " + T + ", " + TmR2.ToString() + ",  " + "#");
                    //else
                    //    OutBuffer = "$,  " + (Global.C_Mode.ToString() + ", " + T + ", " + TmR1.ToString() + ", " + D + ", " + TmR2.ToString() + ",  " + "#");
                    
                   Tss10.Text = OutBuffer;

                   //if (Global.PIDPort.IsOpen == true) Global.PIDPort.Write(OutBuffer);
                    
                    //st.Start();

                }
                else
                {
                    Btn22.PerformClick(); // .   stopEngine();
                    Global.flg_CylStart = false;

                }
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: Load_ProgStep():  ", "Alert"); //  + ex.Message);
                MessageBox.Show("Error in frmMain: Load_ProgStep():" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        public  void Load_Gridseq_header()
        {
            try
            {
                GridSeq1.ColumnCount = 20;
                if (GridSeq1.RowCount < 10) GridSeq1.RowCount = 10; 
                foreach (DataGridViewColumn colm in GridSeq1.Columns)
                {
                    colm.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                GridSeq1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                GridSeq1.DefaultCellStyle.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                GridSeq1.Columns[0].Width = 40;
                GridSeq1.Columns[0].HeaderText = "Sn";
                GridSeq1.Columns[1].Width = 40;
                GridSeq1.Columns[1].HeaderText = "MD";
                GridSeq1.Columns[2].Width = 60;  //
                GridSeq1.Columns[2].HeaderText = "SetPt-1  (rpm)";
                GridSeq1.Columns[3].Width = 60;  //
                GridSeq1.Columns[3].HeaderText = "RmT-1  (mm:ss)";
                GridSeq1.Columns[4].Width = 60;  //
                GridSeq1.Columns[4].HeaderText = "SetPt-2 (%)";
                GridSeq1.Columns[5].Width = 60;  //
                GridSeq1.Columns[5].HeaderText = "RmT-2 (mm:ss)";
                GridSeq1.Columns[6].Width = 60;  //
                GridSeq1.Columns[6].HeaderText = "T_Stb  (mm:ss)";
                GridSeq1.Columns[7].Width = 60;  //
                GridSeq1.Columns[7].HeaderText = "T_Std  (mm:ss)";
                GridSeq1.Columns[8].Width = 60;  //
                GridSeq1.Columns[8].HeaderText = "Stop  (mm:ss)";
                GridSeq1.Columns[9].Width = 90;
                GridSeq1.Columns[9].HeaderText = "Repeat   (" + Global.loopcount + " )";
                GridSeq1.Columns[10].Width = 60;  //
                GridSeq1.Columns[10].HeaderText = "LogData     (" + LogT + ")";
                //txtrepeate.Text = Global.loopcount.ToString();
                //txtlog.Text = LogT.ToString();
                GridSeq1.Columns[11].Visible = Visible;
                GridSeq1.Columns[11].Width = 40;  //
                GridSeq1.Columns[11].HeaderText = "SFC  (G/V)";
                GridSeq1.Columns[12].Visible = false;
                GridSeq1.Columns[12].Width = 90;  //
                GridSeq1.Columns[12].HeaderText = "MinLP (bar)";
                GridSeq1.Columns[13].Visible = false;   
                GridSeq1.Columns[13].Width = 90;  //60;
                GridSeq1.Columns[13].HeaderText = "MaxVal ";
                GridSeq1.Columns[14].Visible = false;
                GridSeq1.Columns[14].Width = 90;  //50;
                GridSeq1.Columns[14].HeaderText = "Dwtr";
                GridSeq1.Columns[15].Visible = false;
                GridSeq1.Columns[15].Width = 90;  //50;
                GridSeq1.Columns[15].HeaderText = "D1";
                GridSeq1.Columns[16].Visible = false;
                GridSeq1.Columns[16].Width = 90;  //30;h
                GridSeq1.Columns[16].HeaderText = "D2";
                GridSeq1.Columns[17].Visible = false;
                GridSeq1.Columns[17].Width = 90;  //40;
                GridSeq1.Columns[17].HeaderText = "D3";
                GridSeq1.Columns[18].Width = 60;  //80;
                GridSeq1.Columns[18].HeaderText = "Tm";
                GridSeq1.Columns[19].Width = 235;  //80;
                GridSeq1.Columns[19].HeaderText = "Step Name";

                Global.Create_OnLog("Load _Grid Sequence SuccessFull:  ", "Normal");
                MessageBox.Show("Load _Grid Sequence Successfull:" , "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Load_Gridseq_header(): " + '\n' + ex.Message , "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Global.Create_OnLog("Error in frmMain: Load_Gridseq_header():  ", "Alert");
            }          
        }                
        //public void Check_Limit_Standby()
        //{
        //    try
        //    {
        //        Int16 L = 0;
        //        String B1, C1;
        //        String B2 = "";
        //        String C2 = "";
        //        Double InVal = 0;
        //        int v = 0;

        //        for (L = 0; L <= 95; L++)
        //        {
        //           // v = Convert.ToInt16(Global.LsNo[L]);
        //            B1 = Global.Ls[L].Substring(0, 1);
        //            C1 = Global.Hs[L].Substring(0, 1);
        //            if (Global.Ls[L].Substring(1) != String.Empty) B2 = Global.Ls[L].Substring(1); else B2 = Global.PMin[L];
        //            if (Global.Hs[L].Substring(1) != String.Empty) C2 = Global.Hs[L].Substring(1); else C2 = Global.PMax[L];

        //            InVal = Convert.ToDouble(Global.GenData[v]);
        //            Global.StrAlarm = "";
        //            if (((B1 == "A") && (InVal < double.Parse(B2))) || ((C1 == "A") && (InVal > Double.Parse(C2))))
        //            {
        //                Global.BufLim[v] = "A";
        //                //dGValues[2, v - 14].Style.BackColor = Color.Red;

        //            }
        //            else
        //            {
        //                Global.BufLim[v] = "N";
        //                //dGValues[2, v - 14].Style.BackColor = Color.Gray;
        //            }
        //        }
        //        //if ((Global.StrAlarm != "") || (Global.StrAlarm != " "))
        //        //{
        //        //    label12.Text = Global.StrAlarm;
        //        //    panel2.Visible = true;
        //        //}
        //        //else
        //        //{
        //        //    panel2.Visible = false;
        //        //}
        //    }
        //    catch
        //    {
        //        return;
        //    }
        //}
        //private void Check_Limit()
        //{
        //    Int16 L = 0;
        //    String A1 = "";
        //    String B1 = "";
        //    String C1 = "";
        //    String D1 = "";

        //    String A2 = "";
        //    String B2 = "";
        //    String C2 = "";
        //    String D2 = "";
        //    Double InVal = 0;

        //    try
        //    {
        //        for (L = 0; L <= 95; L++)
        //        {
        //            if (L == 2) L = 6;
        //            if (Global.PSName[L] != "Not_Prog")
        //            {
        //                if (Global.LL1[L] != "") A1 = Global.LL1[L].Substring(0, 1);
        //                if (Global.L1[L] != "") B1 = Global.L1[L].Substring(0, 1);
        //                if (Global.H1[L] != "") C1 = Global.H1[L].Substring(0, 1);
        //                if (Global.HH1[L] != "") D1 = Global.HH1[L].Substring(0, 1);

        //                if (Global.LL1[L].Length > 1) A2 = Global.LL1[L].Substring(1); else A2 = Global.PMin[L];
        //                if (Global.L1[L].Length > 1) B2 = Global.L1[L].Substring(1); else B2 = Global.PMin[L];
        //                if (Global.H1[L].Length > 1) C2 = Global.H1[L].Substring(1); else C2 = Global.PMax[L];
        //                if (Global.HH1[L].Length > 1) D2 = Global.HH1[L].Substring(1); else D2 = Global.PMax[L];

        //                if (Global.GenData[L] != null) InVal = Convert.ToDouble(Global.GenData[L]); else InVal = 0.0;
        //                //Global.StrAlarm = "";
        //                if (((A1 == "O") && (InVal <= Convert.ToDouble(A2))) || ((D1 == "O") && (InVal >= Convert.ToDouble(D2))))
        //                {
        //                    Global.Flg_AList = true;
        //                    if ((Global.Flg_AList == true))
        //                    {
        //                        Global.arrLim[L] = "O : " + Global.PSName[L] + " ";
        //                        Global.BufLim[L] = "O";
        //                        Global.Create_OnLog("IGNITION OFF  : " + Global.PSName[L], "Alert");
        //                        Global.StrAlarm = "Engine 'OFF'" + Global.arrLim[L];
        //                        AddListItem("Engine ShutOFF: " + Global.PSName[L] + " : " + InVal, "Alert");
        //                        LogData();
        //                        stopEngine();
        //                        return;
        //                    }
        //                }
        //                else if (((A1 == "I") && (InVal < Convert.ToDouble(A2))) || ((D1 == "I") && (InVal > Convert.ToDouble(D2))))
        //                {
        //                    Global.Flg_AList = true;

        //                    if (Global.LimNo[L] <= 2)
        //                    {
        //                        Global.LimNo[L] += 1;
        //                        //AddListItem("Engine @ Idle: " + Global.PSName[L] + " : " + InVal + "count :" + Global.LimNo[L], 6);
        //                        Global.Create_OnLog("Engine @ Idle: " + Global.PSName[L] + " : " + InVal, "Alert");
        //                    }
        //                    if (Global.LimNo[L] > 2)
        //                    {
        //                        if ((Global.Flg_AList == true) && (Global.BufLim[L] != "I"))
        //                        {
        //                            Global.arrLim[L] = "I:" + Global.PSName[L] + " ";
        //                            Global.BufLim[L] = "I";
        //                            Global.StrAlarm = "Engine @ Idle " + " : " + InVal;
        //                            AddListItem("Engine @ Idle: " + Global.PSName[L] + " : " + InVal, "Alert");
        //                            LogData();
        //                            IdleEng();
        //                            return;
        //                        }
        //                    }
        //                    //return;
        //                }
        //                else if (((B1 == "A") && (InVal < double.Parse(B2))) || ((C1 == "A") && (InVal > Double.Parse(C2))))
        //                {
        //                    if ((Global.BufLim[L] != "A") && ((InVal < double.Parse(B2)) || ((C1 == "A") && (InVal > Double.Parse(C2)))))
        //                    {
        //                        Global.arrLim[L] = "A : " + Global.PSName[L] + " ";
        //                        Global.Create_OnLog("Alarm  : " + Global.PSName[L], "Normal");
        //                        Global.StrAlarm = Global.StrAlarm + "A : " + Global.PSName[L];
        //                        Global.BufLim[L] = "A";
        //                        Global.Flg_AList = true;
        //                    }
        //                }
        //                else
        //                {
        //                    Global.BufLim[L] = "N";
        //                }
        //                ////Global.StrAlarm = "";
        //                //else if (((B1 == "A") && (InVal < double.Parse(B2))) || ((C1 == "A") && (InVal > Double.Parse(C2))))
        //                //{
        //                //    if (Global.BufLim[L] == "N")
        //                //    {
        //                //        Global.BufLim[L] = "A";
        //                //        Global.arrLim[L] = "A : " + Global.PSName[L] + " ";
        //                //        Global.StrAlarm = "Check Alarm : " + Global.arrLim[L];
        //                //        AddListItem("Alarm  : " + Global.PSName[L] + ": "  + InVal ,  "Alart");
        //                //    }
        //                //}
        //                //else
        //                //{
        //                //    Global.BufLim[L] = "N";
        //                //}
        //            }
        //        }
        //        //for (int k = 0; k <= 95; k++)
        //        //{
        //        //  Global.StrAlarm = Global.StrAlarm + Global.arrLim[k];
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.Create_OnLog("Error in frmMain: Error Check_Limit : " + InVal, "Alert");
        //        MessageBox.Show("Error in frmMain: Error Check_Limit ::" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
        //        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        //Global.Create_OnLog("Error Check_Limit :" + L + " : " + InVal + ex.Message,false);
        //    }
        //}  


        public void AddListItem(string message, string str)
        {
            try
            {
                if (Global.varRPM >= 600)
                {
                    string[] arr = new string[4];
                    ListViewItem itm;


                    arr[0] = Global.L_Cn.ToString("0000");
                    arr[1] = System.DateTime.Now.ToString("hh:mm:ss");
                    arr[2] = message;
                    itm = new ListViewItem(arr);
                    listView1.Items.Add(itm);
                    listView1.EnsureVisible(listView1.Items.Count - 1);

                    if (message.StartsWith(Global.StNo + ": Step Started") == false)
                    {
                        Global.Create_OnLog(message, str);
                    }
                    Global.L_Cn++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: AddListItem():" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Error in frmMain: AddListItem():  " + ex.Message);
            }
        }
        public void Check_Necessary_Files()
        {
            try
            {
                if (System.IO.Directory.Exists(Global.PATH) == false)
                {
                    MessageBox.Show("Folder does not exist! Can not start Application." + '\n' + Global.PATH, "Dynalec Controls Pvt Ltd.",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //MessageBox.Show(Global.PATH + " folder does not exist!!! Can not start Application.");
                }

                if (System.IO.File.Exists(Global.PATH + "General.accdb") == false)
                {
                    MessageBox.Show("General.accdb does not exist! Can not start Application." + '\n' + Global.PATH, "Dynalec Controls Pvt Ltd.",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   // MessageBox.Show(Global.PATH + " General.accdb does not exist!!! Can not start Application.");
                }

                if (System.IO.File.Exists(Global.PATH + "Data.accdb") == false)
                {
                    MessageBox.Show("Data.accdb does not exist! Can not start Application." + '\n' + Global.PATH, "Dynalec Controls Pvt Ltd.",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //MessageBox.Show(Global.PATH + " Data.accdb does not exist!!! Can not start Application.");
                }

                if (System.IO.File.Exists(Global.PATH + "Limit.accdb") == false)
                {
                    MessageBox.Show("Limit.accdb does not exist! Can not start Application." + '\n' + Global.PATH, "Dynalec Controls Pvt Ltd.",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   // MessageBox.Show(Global.PATH + " Limit.accdb does not exist!!! Can not start Application.");
                }

                if (System.IO.File.Exists(Global.PATH + "Sequence.accdb") == false)
                {
                    MessageBox.Show("Sequence.accdb does not exist! Can not start Application." + '\n' + Global.PATH, "Dynalec Controls Pvt Ltd.",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //MessageBox.Show(Global.PATH + " Sequence.accdb does not exist!!! Can not start Application.");

                }

                if (System.IO.File.Exists(Global.PATH + "Log.accdb") == false)
                {
                    MessageBox.Show("Log.accdb does not exist! Can not start Application." + '\n' + Global.PATH, "Dynalec Controls Pvt Ltd.",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //MessageBox.Show(Global.PATH + " Log.accdb does not exist!!! Can not start Application.");
                }
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: Check_Necessary_Files() : ", "Alert");
                MessageBox.Show("Error in frmMain: Check_Necessary_Files():" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Error in frmMain: Check_Necessary_Files():  " + ex.Message);
                
            }
        }

        private void Fun_ProgOut()
        {
            string str;
            try
            {

                if (TmR > 0)
                {
                    //lblStatus.Text = "RAMP TIME:";
                    PBar3.Caption = "RAMP TIME:";
                    PBar3.MainColor = Color.Red;  
                    GridSeq1.Enabled = false;
                    flg_Ramp = true;
                    flg_Stb = false;
                    flg_Std = false;
                    //lblStatus.ForeColor = Color.Red; 
                    TmR = TmR - 1;
                    if (TmR1 > 0) TmR1 = (TmR1 - 1);
                    if (TmR2 > 0) TmR2 = (TmR2 - 1);
                    if (TmR1 <= 0)
                    {
                        TmR1 = 0;
                        Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                        if ((Global.C_Mode == "1") || (Global.C_Mode == "3"))
                            txtSetpt1.Text = (Global.AnaOut1 * 10).ToString("0000");
                        else
                            txtSetpt1.Text = (Global.AnaOut1 * (Convert.ToDouble(Global.sysIn[5])) / 10).ToString("0000");
                    }
                    if (TmR2 <= 0)
                    {
                        TmR2 = 0;
                        //Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                        //if ((Global.C_Mode == "1") || (Global.C_Mode == "2") || (Global.C_Mode == "5"))
                        //    txtSetpt2.Text = (Global.AnaOut2 * 10).ToString("000.0");
                        //else
                        //    txtSetpt2.Text = (Global.AnaOut2 * (Convert.ToDouble(Global.sysIn[4])) / 10).ToString("000.0");
                    }
                    t = TimeSpan.FromSeconds(TmR);
                   
                    answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                    txtPStatus.Text = answer;
                    // txtPStatus.Text = string.Format("{0:0000}", TmR);
                    settimefor_gridseq();
                    PBar3.Value = TmR;

                    if (TmR <= 0)
                    {
                        TmR = 0;
                        //Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                        //Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                        //lblStatus.Text = "STABILISATION TIME:";
                        PBar3.Caption = "STABILISATION TIME:";
                        PBar3.MainColor = Color.Blue;
                        GridSeq1.Enabled = true;
                        //lblStatus.ForeColor = Color.Green;
                        t = TimeSpan.FromSeconds(Tstb);
                        answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                        txtPStatus.Text = answer;
                        //txtPStatus.Text = string.Format("{0:0000}", Tstb);
                        settimefor_gridseq();
                        PBar3.Maximum = Tstb;
                        flg_Ramp = false;
                        flg_Stb = true;
                        flg_Std = false;

                    }
                }
                else if (Tstb > 0)
                {
                    Tstb = (Tstb - 1);
                    t = TimeSpan.FromSeconds(Tstb);
                    answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                    txtPStatus.Text = answer;
                    settimefor_gridseq();
                    PBar3.Value = Tstb;
                    if (Tstb <= 0)
                    {
                        Tstb = 0;                       
                        PBar3.Caption = "STEADY TIME:";
                        PBar3.MainColor = Color.Green;
                        GridSeq1.Enabled = true;
                        //lblStatus.ForeColor = Color.Blue;
                        t = TimeSpan.FromSeconds(Tstb);
                        answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                        txtPStatus.Text = answer;
                        // txtPStatus.Text = string.Format("{0:0000}", Tstb);
                        settimefor_gridseq();

                        if (PBar3.Caption == "STEADY TIME:")                       
                            PBar3.Maximum = Tstd;
                        if (Global.flg_smokeStart == true)
                        {
                            //Global.flg_smokeStart = true;
                            Global.S_Add = 0;
                            tmrSmk.Start(); 
                            //frmsmk.button3.PerformClick();
                            //Global.flg_smokeStart = false;
                        }
                        if (Global.Auto_SFC == true)
                        {
                            Global.flg_SFC = false;
                            Global.SFC_Reset = true;
                            Global.flg_SFCStart = true;
                            Global.Auto_SFC = false;
                            Global.SFC_msg = "SFC RESET.....";
                            AddListItem("SFC Reseted ......", "Normal"); 
                        }
                        flg_Ramp = false;
                        flg_Stb = false;
                        flg_Std = true;                      
                    }
                }
                else if (Tstd > 0)
                {
                    Tstd = Tstd - 1;
                    t = TimeSpan.FromSeconds(Tstd);
                    answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds );
                    txtPStatus.Text = answer;
                    // txtPStatus.Text = string.Format("{0:0000}", Tstd);  
                    settimefor_gridseq();
                    if (Global.Auto_SFC == true)
                    {
                        Global.flg_SFC = false;
                        Global.SFC_Reset = true;
                        Global.flg_SFCStart = true;
                        Global.flg_DataSave = true;
                    }
                    PBar3.Value = Tstd;
                    if (Tstd <= 0)
                    {
                        Tstd = 0;
                        PBar3.Caption = "RAMP TIME:";
                        GridSeq1.Enabled = false;
                        //IdleEng();
                        //Global.Dig_OutBit(0, 7, false);  //Ingnition on
 
                        ////////////////////////////////////////////////////////

                        str = GridSeq1.Rows[Global.StpN].Cells[8].Value.ToString();
                        Tstp = ((int.Parse(str.Substring(1, 2)) * 60) + int.Parse(str.Substring(4, 2)));
                        
                        /////////////////////////////////

                        if (GridSeq1.Rows[Global.StpN].Cells[9].Value != DBNull.Value)
                        {
                            str = GridSeq1.Rows[Global.StpN].Cells[9].Value.ToString();
                            if (str.Substring(3, 1).ToString() == "R")
                            {
                                Global.flg_RLoop = true;
                                Srloop = int.Parse(str.Substring(0, 3).ToString());
                                Erloop = int.Parse(str.Substring(4).ToString());
                                if ((Global.flg_RLoop == true) && (Erloop > Global.loopcount))// (int.Parse(str.Substring(pos + 1)))))
                                {
                                    Global.loopcount += 1;
                                    Global.Create_OnLog("Repeat  (" + Global.loopcount + ")", "Normal");
                                    GridSeq1.Columns[9].HeaderText = "Repeat  (" + Global.loopcount + ")";
                                    Global.StpN = Srloop - 1;// int.Parse(str.Substring(0, pos)) - 1;
                                    Global.StNo = Global.StpN + 1;
                                }
                                else
                                {
                                    Global.loopcount = 0;
                                    GridSeq1.Columns[9].HeaderText = "Repeat  (" + Global.loopcount + ")";

                                    Global.StpN = Global.StpN + 1;
                                    txtStepNo.Text = String.Format("{0:000}", (Global.StpN + 1));
                                    Global.StNo = (Global.StpN + 1);
                                }
                            }
                            else
                            {
                                Global.flg_RLoop = false;
                                Global.StpN = Global.StpN + 1;
                                Global.StNo = (Global.StpN + 1);

                            }
                        }

                       if ((flg_StopInt == true) && (Tstp > 0) && (Tstd <= 0))
                       {
                           Global.Dig_OutBit(0, 7, false);  //Ingnition on
                           Tstp--;
                           Tss1.Text = "Engine Stopped ...... : " + Tstp.ToString();
                           if (Tstp <= 0)
                           {
                               //a  
                               Tstp = 0;
                               Global.Dig_OutBit(0, 7, true);  //Ingnition on
                               Thread.Sleep(500);
                               Global.Dig_OutBit(1, 0, true);  //Eng start Pulse
                               Thread.Sleep(500);
                               Global.Dig_OutBit(1, 0, false);//Eng start Pulse false

                               if (Global.varRPM >= 600)
                               {
                                   Global.flg_RLoop = false;
                                   Global.StpN++;
                                   Global.StNo++;
                                   Load_ProgStep();
                                   flg_Ramp = true;
                                   flg_Stb = false;
                                   flg_Std = false;
                                   flg_StopInt = false;
                                   Tss1.Text = "Engine Re-Started.....";
                               }
                          
                           }
                       }

                        /*//////////////////////////////////////////Auto /Stop Engine 
                        ElseIf Mid(lblSPtime.Caption, 1, 1) = "S" And Val(Mid(lblSPtime.Caption, 2, Len(lblSPtime.Caption))) > 1 Then
        lblStatus.Caption = "Stop Time"
        '    lblTime.Caption = lblSTBtime.Caption
        '    lblTime.Caption = Val(Mid(lblSPtime.Caption, 2, Len(lblSPtime.Caption))) - 1
        lblSPtime.Caption = "S" & Val(Mid(lblSPtime.Caption, 2, Len(lblSPtime.Caption))) - 1
        '    lblMessage.Caption = "Engine Stopped"
        lblCurMode.Caption = "Engine Stopped"
        Flg_AnaOut = False
        Diff1 = -LastAna1 / 40
        Diff2 = -LastAna2 / 40

        ModeToMode
        Mode_Out 1, 0, 0
'        frmGlobal.Dig_OutBit 3, True
'        frmGlobal.Dig_OutBit 4, False
'        frmGlobal.Dig_OutBit 5, False
        '            frmGlobal.txtDo(3).Text = "1"   '"0"
        '            frmGlobal.txtDo(4).Text = "0"
        '            frmGlobal.txtDo(5).Text = "0"
        'Off the ignition


        Dig_OutBit 8, False
        '            frmGlobal.txtDo(8).Text = "0" ' Ignition off

        DoEvents
        txtAnaOut2.Text = 0 'For DC

        Flg_AnaOut = True
        Flg_ProgOut = True
        ' End If

        '************************************************************************
    ElseIf Mid(lblSPtime.Caption, 1, 1) = "S" And Val(Mid(lblSPtime.Caption, 2, Len(lblSPtime.Caption))) <= 1 Then
        'tmrProg.Enabled = False
        'tmrAnaOut.Enabled = False

        lblSPtime.Caption = "N0"

        lblCurMode.Caption = "Wait For Engine to Start"
        Dim RetVal As Boolean
        RetVal = Start_Engine(Val(HT_On), Val(ST_On))

        If RetVal = True Then 'If Engine Started
            Flg_AnaOut = True
            Flg_ProgOut = True
            lblCurMode.Caption = " "
        Else
            lblCurMode.Caption = "Engine Cannot Started"
            tmrEnd.Enabled = True
        End If

        DoEvents
        'Exit Sub


                      ///////////////////////////////////////////////*/

                        //StpN = StpN + 1;
                        Load_ProgStep();
                        flg_Ramp = true;
                        flg_Stb = false;
                        flg_Std = false;
                      
                    }
                }
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: ChFun_ProgOut() : ", "Alert");
                MessageBox.Show("Error in frmMain: Fun_ProgOut():" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Error in frmMain: Fun_ProgOut():  " + ex.Message);
            }
           
        }
        private void Hold_Cycle(Boolean flg_Hold)
        {
            try
            {
                if (flg_Hold == true) 
                {
                    Auto_Hold = false;
                    if (Btn24.Text  == "F7 - Cycle_Hold")
                   {
                        Btn24.Text = "F7 - Cycle_Resume";
                        Global.Create_OnLog("Cycle Hold.....", "Normal"); 
                        flg_ProgOut = false;
                        Tss1.Text  = "Cycle Is on Hold ...";
                        Update_Hold(1); 
                   }
                    else if (Btn24.Text == "F7 - Cycle_Resume")
                   {
                       Btn24.Text = "F7 - Cycle_Hold";
                        Global.Create_OnLog("Cycle Resume.....", "Normal");
                        //Update_Tss1(0);
                        Tss1.Text = "Cycle Is Running...";
                        flg_ProgOut = true;
                        flg_AnaOut = true; 
                        Auto_Hold = false;
                        Global.Auto_SFC = false;
                        Update_Hold(0); 
                   }
                }
                if (Btn24.Text == "Step_Resume")
                {
                    Load_ProgStep();
                    Btn24.Text = "Cycle_Hold";
                    flg_ProgOut = true;
                    flg_AnaOut = true; 
                    for (int i = 0; i <30 ; i++)
                    {
                        InV[i].colFillColorA = Color.Teal;
                        InV[i].colForeColor = Color.White;
                    }
                }
            }                           
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Hold_Cycle():" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                //MessageBox.Show("Error in frmMain: Hold_Cycle():  " + ex.Message);
            }
        }

        public void Create_FileName(String ENo)
        {
            try
            {
                String Str = null;
                int pos1 = 1;
                int pos2 = 2;
                int pos3 = 1;
                String Dt = DateTime.Now.ToString("ddMMMyyyy");
                ENo = Global.EngNo;
                ENo = Global.EngNo.Replace(" ", "");
                ENo = ENo.Replace(".", "");
                ENo = ENo.Replace("!", "");
                ENo = ENo.Replace("'", "");
                ENo = ENo.Replace("[]", "");
                ENo = ENo.Replace("_", "");
                ENo = ENo.Replace("-", "");

                //******************************
                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblLastFl", Global.con);
                MySqlDataReader Rd = cmd.ExecuteReader();
                while (Rd.Read())
                {
                    Str = Rd.GetValue(0).ToString();
                }
                Rd.Close();
                Global.con.Close();
                if (Global.flg_NewFile == true)
                {
                    pos1 = Str.IndexOf("_", 0);
                    pos2 = Str.IndexOf("_", (pos1 + 1));
                    pos3 = Str.IndexOf("_", (pos2 + 1));

                    int T = int.Parse(Str.Substring(pos3 + 1)) + 1;
                    String Ct = T.ToString("00");
                    String Tp = "";
                    if (Global.TestTyp == "PERFORMANCE") Tp = "Perf_";
                    else if (Global.TestTyp == "ENDURANCE") Tp = "Endu_";
                    else if (Global.TestTyp == "PRODUCTION") Tp = "Prod_";


                    if (Dt == Str.Substring(pos1 + 1, 9))
                    {
                        Global.Eng_FileNm = Tp + Dt + "_" + ENo + "_" + Ct;
                    }
                    else
                    {
                        Global.Eng_FileNm = Tp + Dt + "_" + ENo + "_01";
                    }
                    if (Global.Eng_FileNm == String.Empty) Global.Eng_FileNm = Tp + "Manual_Data";


                    Global.Open_Connection("gen_db", "con");
                    cmd = new MySqlCommand("Update tblLastFl SET " +
                        " AutoFile = '" + Global.Eng_FileNm + "'", Global.con);
                    cmd.ExecuteNonQuery();
					//*******************************
                    //Global.Eng_ECU_FileNm = "ECU" + (Global.Eng_FileNm.Substring(4));
                    Global.Eng_PMFileNm = "PM" + (Global.Eng_FileNm.Substring(4));

                    checkBox1.Text = Global.Eng_FileNm;
                    checkBox8.Text = Global.PrjNm;

                    for (int x = 0; x <= 14; x++)
                    {
                        Global.arrIdle_1[x] = "0";
                        Global.arrIdle_2[x] = "0";
                        Global.arrIdle_3[x] = "0"; 
                    }


                        Create_Table();
                    //Create_ECU_File();

                    if (Global.flg_RecorsPmData == true) Create_PMTable();                   

                }
                else if (Global.flg_OldFile == true)
                {
                    Global.Eng_FileNm = Str;

                    //Global.Eng_ECU_FileNm = "ECU_" + (Global.Eng_FileNm.Substring(4));
                    Global.Eng_PMFileNm = "PM" + (Global.Eng_FileNm.Substring(4));



                    //checkBox13.Text = Global.EngNo;
                    //checkBox15.Text = Global.Eng_FileNm;
                    checkBox8.Text = Global.PrjNm;
                    //checkBox15.Text = Global.Eng_FileNm;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Create_FileName():" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Error in frmMain: Create_FileName():  " + ex.Message);
            }
        }

      

        private void Create_Table()
        {
            try
            {
                int i = 0;
                String StrTb = null;
                for (i = 0; i <= 125; i++)   //124
                {
                    Global.PSName[i] = Global.PSName[i].Replace(" ", "");
                    Global.PSName[i] = Global.PSName[i].Replace(".", "");
                    Global.PSName[i] = Global.PSName[i].Replace("!", "");
                    Global.PSName[i] = Global.PSName[i].Replace("'", "");
                    Global.PSName[i] = Global.PSName[i].Replace("[]", "");
                    StrTb = StrTb + i.ToString("000") + Global.PSName[i] + " TEXT, ";
                }
                              

                if (System.IO.File.Exists(Global.DataPath + "Gen_Data\\" + Global.Eng_FileNm + ".csv") == false)    //".csv"    "D:\\SERVER\\" + Global.T_CellNo + "\\" + C_Mnt + "\\" + t_day + "\\TestCell_Data.csv") == false)
                {
                    string Dpath = Global.DataPath + "Gen_Data\\" + Global.Eng_FileNm + ".csv";
                    using (StreamWriter sw = File.CreateText(Dpath))
                    {
                        var row = new List<string> { StrTb };
                        var sb = new StringBuilder();
                        foreach (string value in row)
                        {
                            if (sb.Length > 0)
                                sb.Append(",");
                            sb.Append(value);
                        }
                        sw.WriteLine(sb.ToString());
                    }

                }


            }

            catch (Exception ex)
            {

                MessageBox.Show("Error in frmMain: Create_Table():" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
               // MessageBox.Show("Error in frmMain: Create_Table():  " + ex.Message);
                Global.Create_OnLog("Alert", ex.Message + ": Create_Table");
            }
        }
        private void Create_ECU_File()
        {
            try
            {
                int i = 0;
                String StrTb = "Time ,"; // null;
                for (i = 0; i <= 55; i++)   // 124
                {
                    Global.EcuSName[i] = Global.EcuSName[i].Replace(" ", "");
                    Global.EcuSName[i] = Global.EcuSName[i].Replace(".", "");
                    Global.EcuSName[i] = Global.EcuSName[i].Replace("!", "");
                    Global.EcuSName[i] = Global.EcuSName[i].Replace("'", "");
                    Global.EcuSName[i] = Global.EcuSName[i].Replace("[]", "");
                    StrTb = StrTb + (i + 1).ToString("000") + Global.EcuSName[i] + " TEXT, ";
                }

                if (System.IO.File.Exists(Global.DataPath + "ECU_Data\\" + Global.Eng_ECU_FileNm + ".csv") == false)    //".csv"    "D:\\SERVER\\" + Global.T_CellNo + "\\" + C_Mnt + "\\" + t_day + "\\TestCell_Data.csv") == false)
                {
                    string Dpath = Global.DataPath + "ECU_Data\\" + Global.Eng_ECU_FileNm + ".csv";
                    using (StreamWriter sw = File.CreateText(Dpath))
                    {
                        var row = new List<string> { StrTb };
                        var sb = new StringBuilder();
                        foreach (string value in row)
                        {
                            if (sb.Length > 0)
                                sb.Append(",");
                            sb.Append(value);
                        }
                        sw.WriteLine(sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Create_ECU_Table():" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Error in frmMain: Create_Inst_Table():  " + ex.Message);
                Global.Create_OnLog("Alert", ex.Message + ": Create_ECU_Table");
            }
        }
                 
        private void Create_fLogData_Table()
        {
            try
            {
                int i = 0;
                String StrTb = null;
                StrTb = "000 Time" + ",";
                //StrTb = StrTb + "001 RPM" + ",";
                //StrTb = StrTb + "002 Torque" + ",";

                for (i = 0; i <= 19; i++)
                {
                    //Global.PSName[i] = Global.PSName[i].Replace(" ", "");
                    //Global.PSName[i] = Global.PSName[i].Replace(".", "");
                    //Global.PSName[i] = Global.PSName[i].Replace("!", "");
                    //Global.PSName[i] = Global.PSName[i].Replace("'", "");
                    //Global.PSName[i] = Global.PSName[i].Replace("[]", "");
                    StrTb = StrTb + ((i + 1).ToString("000")) + Global.PSName[i+26] + "," ; // + " TEXT, ";
                }
                StrTb = StrTb + "Blowby_Value" + "," + "Turbospeed" + "," + "Air_Flow" + "," + "A_speed" + "," + "A_Torqie" + "," + "Analog_6" + "," + "Analog_7" + "," + "Analog_8" + ",";


                if (System.IO.File.Exists(Global.DataPath + "FastLog_Data\\" + Global.Eng_fData_FileNm + ".csv") == false)    //".csv"    "D:\\SERVER\\" + Global.T_CellNo + "\\" + C_Mnt + "\\" + t_day + "\\TestCell_Data.csv") == false)
                {
                    string Dpath = Global.DataPath + "FastLog_Data\\" + Global.Eng_fData_FileNm + ".csv";
                    using (StreamWriter sw = File.CreateText(Dpath))
                    {
                        var row = new List<string> { StrTb };
                        var sb = new StringBuilder();
                        foreach (string value in row)
                        {
                            if (sb.Length > 0)
                                sb.Append(",");
                            sb.Append(value);
                        }
                        sw.WriteLine(sb.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Create_Table():" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Error in frmMain: Create_Table():  " + ex.Message);
                Global.Create_OnLog("Alert", ex.Message + ": Create_Table");
            }
        }


		private void Create_PMTable()
        {
            try
            {
                int i = 0;
                Boolean flg_Filefound = false;
                String StrTb = null;

                for (i = 0; i <= 125; i++)
                {
                    Global.PSName[i] = Global.PSName[i].Replace(" ", "");
                    Global.PSName[i] = Global.PSName[i].Replace(".", "");
                    Global.PSName[i] = Global.PSName[i].Replace("!", "");
                    Global.PSName[i] = Global.PSName[i].Replace("'", "");
                    Global.PSName[i] = Global.PSName[i].Replace("[]", "");
                    Global.PSName[i] = Global.PSName[i].Replace("-", "");
                    //StrTb = StrTb + i.ToString("000") + Global.PSName[i] + " TEXT, ";
                }

                StrTb = "TM Date ***, 00RPM rpm, ";
                for (i = 1; i <= 11; i++)
                {
                    //string X = i.ToString("000");
                    StrTb += Global.PSName[Global.Pm_PNo[i]] + " " + Global.PUnit[Global.Pm_PNo[i]] + ", ";
                }
                StrTb = StrTb + "Alarm,";
                if (System.IO.File.Exists(Global.DataPath + "PM_Data\\" + Global.Eng_PMFileNm + ".csv") == false)    //".csv"    "D:\\SERVER\\" + Global.T_CellNo + "\\" + C_Mnt + "\\" + t_day + "\\TestCell_Data.csv") == false)
                {
                    string Dpath = Global.DataPath + "PM_Data\\" + Global.Eng_PMFileNm + ".csv";
                    using (StreamWriter sw = File.CreateText(Dpath))
                    {
                        var row = new List<string> { StrTb };
                        var sb = new StringBuilder();
                        foreach (string value in row)
                        {
                            if (sb.Length > 0)
                                sb.Append(",");
                            sb.Append(value);
                        }
                        sw.WriteLine(sb.ToString());
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Create_PMTable():" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message, "Error in frmMain: Create_PMTable():  ");
            }
        }


        //public void Make_mdb(String mdbPath)
        //{
        //    try
        //    {
        //        Global.Data_Dir = DateTime.Now.ToString("MMMyy");
        //        String OnLog_Data = "OnLog_" + DateTime.Now.ToString("ddMMMyy");
        //        if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo) == false)
        //        {
        //            System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo);
        //        }
        //        if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir) == false)
        //        {
        //            System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir);
        //        }
        //        if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Gen_Data") == false)
        //        {
        //            System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Gen_Data");
        //        }
        //        //if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Inst_Data") == false)
        //        //{
        //        //    System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Inst_Data");
        //        //}
        //        if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Log_Data") == false)
        //        {
        //            System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Log_Data");
        //        }
        //        if (System.IO.File.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Log_Data" + OnLog_Data + ".txt") == false)
        //        {
        //            System.IO.File.Create("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Log_Data\\" + OnLog_Data + ".txt");
        //        }
        //        if (System.IO.Directory.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\PM_Data") == false)
        //        {
        //            System.IO.Directory.CreateDirectory("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\PM_Data");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error:Problem in creating data base ...");
        //    }

        //}

       
       
        //public void LogfData()
        //{
        //    try
        //    {				
        //        int i = 0;
        //        Global.Capture_fData();				
        //        String strData = null;               
        //        for (i = 0; i <= 44; i++)
        //        {
        //            if (Global.Data[i] == null) Global.Data[i] = "0.0";
        //            //Global.Data[i] = Global.GenData[i]; 
        //            strData = strData +  Global.Data[i] + ", ";
        //        }
        //        strData = strData +  Global.Data[45] + "\n";
				
        //        var filePath = Global.DataPath + "FastLog_Data\\" + Global.Eng_fData_FileNm + ".csv";
        //        using (var wr = new StreamWriter(filePath, true))
        //        {
        //            var row = new List<string> { strData.Substring(0, strData.Length - 1) };
        //            var sb = new StringBuilder();
        //            foreach (string value in row)
        //            {
        //                if (sb.Length > 0)
        //                    sb.Append(",");
        //                sb.Append(value);
        //            }
        //            wr.WriteLine(sb.ToString());
        //        }
        //        //*****************************
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.Create_OnLog("Data fast Log Problem... ", "Alart");
        //        Global.flg_SFCStart = false;
        //    }

        //}

        //public  void Capture_Data(Boolean flgSFC)
        //{
        //    try
        //    {
        //        int t = 0;
        //        int I = 0;
        //        t = 100;
        //        StpTm = DateTime.Now.ToString("hh:mm:ss tt ");

        //        EngHrs = "11:22:00";
        //        for (I = 0; I <= 95; I++)
        //        {
        //            if(Global.GenData[I] == null) Global.GenData[I] = "0.0";
        //           Global.Data[I] = Global.GenData[I];
        //        }


        //        if (flgSFC == false)
        //        {
        //           Global.Data[t + 1] = GenData[101];
        //           Global.Data[t + 2] = GenData[fxd[14]];
        //           Global.Data[t + 3] = "0.0";
        //           Global.Data[t + 4] = "0.0";
        //           Global.Data[t + 5] = Corfact.ToString("0.00000");
        //           Global.Data[t + 6] = varTRQ.ToString("000.0");
        //           Global.Data[t + 7] = VarPowkW.ToString("00.00");
        //           Global.Data[t + 8] = "0.0";
        //           Global.Data[t + 9] = "0.0";
        //           Global.Data[t + 10] = GenData[110];
        //           Global.Data[t + 11] = GenData[111];
        //           Global.Data[t + 12] = "0.0";
        //           Global.Data[t + 13] = "0.0";
        //           Global.Data[t + 14] = "0.0";
        //           Global.Data[t + 15] = Global.VarPowHp.ToString("00.00");
        //           Global.Data[t + 16] = GenData[116];
        //           Global.Data[t + 17] = "0.0";
        //           Global.Data[t + 18] = "0.0";
        //           Global.Data[t + 19] = Global.varbmep.ToString("0.000");
        //           Global.Data[t + 20] = "0.0";
        //            //Data[t + 21] = "0.0";

        //        }
        //        else if (flgSFC == true)
        //        {
        //           Global.flg_SFCON = false;
        //            Global.Data[3] = GenData[3];
        //           Global.Data[4] = GenData[4];
        //            if (SmkVal == null) SmkVal = 0.00;
        //            Global.Data[t + 1] = SmkVal.ToString();
        //            Global.Data[t + 2] = BlBy.ToString();
        //            Global.Data[t + 3] = SFCwt.ToString(); // .ArrData[11].ToString();
        //            Global.Data[t + 4] = SFCTm.ToString(); // .ArrData[12].ToString();                       
        //            Global.Data[t + 5] = Corfact.ToString("0.00000");
        //            Global.Data[t + 6] = varTRQ.ToString("00.0");
        //            Global.Data[t + 7] = VarPowkW.ToString("00.0");
        //            Global.Data[t + 8] = SFCValkW.ToString("000.0");
        //            Global.Data[t + 9] = Bi_Val.ToString("00.0");
        //            Global.Data[t + 10] = GenData[110];  //Global.varTRQ.ToString("00.0");
        //            Global.Data[t + 11] = GenData[111];
        //            Global.Data[t + 12] = (Convert.ToDouble(Global.Data[108]) * Global.Corfact).ToString("00.0");
        //            Global.Data[t + 13] = GenData[113];   // (Convert.ToDouble(double.Parse(Global.Data[103]) / double.Parse(Global.Data[104])) * 3.6).ToString("0.00");
        //            Global.Data[t + 14] = "00.00";  //(Convert.ToDouble((double.Parse(Global.Data[103]) / double.Parse(Global.Data[104])) * 3.6) / 0.835).ToString("0.00");
        //            Global.Data[t + 15] = VarPowHp.ToString("00.0");
        //            Global.Data[t + 16] = GenData[116];
        //            Global.Data[t + 17] = (SFCValPs).ToString("000.0");
        //            Global.Data[t + 18] = GenData[118];
        //            Global.Data[t + 19] = Global.varbmep.ToString("0.000");
        //            Global.Data[t + 20] = "0.0";
        //            //Global.Data[t + 21] = "0.0";

        //        }
        //        Global.Data[121] = Global.TestTyp;
        //        string l = DateTime.Now.ToString("dd/MM/yyyy");
        //        if (OperatorNm == null) OperatorNm = "OpName";
        //        if (TKnNo == null) TKnNo = "TNo";
        //        if (EngMd == null) EngMd = "EngMd";

        //       Global.Data[122] = System.DateTime.Now.ToString("hh:mm:ss tt");
        //        Global.Data[123] = Global.S_StartTime;
        //        Global.Data[124] =clsFun.cummbuff;
        //        if (Global.StrAlarm == String.Empty)Global.StrAlarm = "*****";
        //        Global.Data[125] =Global.StrAlarm;
        //       Global.Data[126] = Global.StpComm;
        //       Global.Data[127] = "*****";


        //       if (GridSeq.Rows[Global.StpN].Cells[32].Value.ToString() == "True")
        //       {
        //           Global.Data[128] = minPassOfLim[0];
        //           Global.Data[129] = maxPassOfLim[0];
        //           Global.Data[130] = minPassOfLim[1];
        //           Global.Data[131] = maxPassOfLim[1];
        //           Global.Data[132] = minPassOfLim[2];
        //           Global.Data[133] = maxPassOfLim[2];
        //           Global.Data[134] = minPassOfLim[3];
        //           Global.Data[135] = maxPassOfLim[3];
        //           Global.Data[136] = minPassOfLim[4];
        //           Global.Data[137] = maxPassOfLim[4];
        //           Global.Data[138] = minPassOfLim[5];
        //           Global.Data[139] = maxPassOfLim[5];
        //           Global.Data[140] = minPassOfLim[6];
        //           Global.Data[141] = maxPassOfLim[6];
        //           Global.Data[142] =minPassOfLim[7];
        //           Global.Data[143] = maxPassOfLim[7];
                  
        //       }
        //       else
        //       {
        //           Global.Data[128] = "00.00";
        //           Global.Data[129] = "00.00";
        //           Global.Data[130] = "00.00";
        //           Global.Data[131] = "00.00";
        //           Global.Data[132] = "00.00";
        //           Global.Data[133] = "00.00";
        //           Global.Data[134] = "00.00";
        //           Global.Data[135] = "00.00";
        //           Global.Data[136] = "00.00";
        //           Global.Data[137] = "00.00";
        //           Global.Data[138] = "00.00";
        //           Global.Data[140] = "00.00";
        //           Global.Data[142] = "00.00";
        //           Global.Data[143] = "00.00";
        //       }

        //    }
        //    catch (Exception ex)
        //    {
        //        Global.Create_OnLog(ex.Message + " :  Capture Data....", "Alart");
        //        return;
        //        //MessageBox.Show("Error Code:- 1517", ex.Message);
        //    }
        //}


        public void LogData()
        {
            try
            {
                if (Global.Eng_FileNm == "") Global.Eng_FileNm = "Man";
                int i = 0;
                Global.Capture_Data();
                Global.Sn += 1;
                String strData = String.Empty;
                String strData1 = String.Empty;
                String strData2 = String.Empty;
                String strData3 = String.Empty;
               
            for (i = 0; i <=125; i++)
                {
                    if (Global.Data[i] == null) Global.Data[i] = "000.000";
                    strData1 = strData1 + Global.Data[i] + ", ";
                }
              
                strData = strData1;
                strData = strData + Global.Sn + ",\n";      // Global.StrAlarm + ", " +

                for (i = 0; i <= 12; i++)
                {
                    if (Global.Sn == 1) Global.arrIdle_1[i] = Global.Data[Convert.ToInt32(Global.vId[i])];
                    if (Global.Sn == 2) Global.arrIdle_2[i] = Global.Data[Convert.ToInt32(Global.vId[i])];
                    if (Global.Sn == 3) Global.arrIdle_3[i] = Global.Data[Convert.ToInt32(Global.vId[i])];
                }  
                
                    
                
               
                var filePath = Global.DataPath + "Gen_Data\\" + Global.Eng_FileNm + ".csv";
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
               
                flg_SaveData = false;
                Global.flg_UpdateViewData = true;
                Update_ViewData();

                lblLog.Text = Global.Sn.ToString("000");
                AddListItem("Data Logged... ", "Normal");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error in LogData() :" + ex.Message);
                MessageBox.Show("Data Log Problem.." + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Global.Create_OnLog("Data Log Problem... ", "Normal");
                Global.flg_SFCStart = false;
            }

        }

       
       
        //private void MakeAVGData()
        //{
        //    try
        //    {
        //        String Str = String.Empty;
        //        int i = 0;
        //        int sn1 = 0;
        //        int sn2 = 0;
        //        Global.Open_Connection("gen_db", "con");
        //        SqlDataAdapter Adp = new SqlDataAdapter("SELECT * FROM AvgTemp", Global.con);
        //        DataSet ds = new DataSet();
        //        Adp.Fill(ds);

        //        if (ds.Tables[0].Rows.Count != 0)
        //        {
        //            Str = "SELECT ";
        //            for (i = 0; i < 95; i++)
        //            {
        //                if ((i != 2) && (i != 3) && (i != 4))
        //                {
        //                    if (i == 94)
        //                    {
        //                        Str = Str + "avg(" + ds.Tables[0].Columns[i].ColumnName + ") ";
        //                    }
        //                    else
        //                    {
        //                        Str = Str + "avg(" + ds.Tables[0].Columns[i].ColumnName + "), ";
        //                    }
        //                }
        //            }

        //            Str = Str + "from AvgTemp";
        //            SqlCommand AVGcmd = new SqlCommand(Str, Global.con);
        //            AVGcmd.ExecuteNonQuery();
        //            SqlDataReader Rd = AVGcmd.ExecuteReader();
                                      
        //            i = 0;
        //            while (Rd.Read())
        //            {
        //                for (i = 0; i < 92; i++)
        //                {
        //                  if (i == 3) Global.ArrData[3] = Global.GenData[3];
        //                  if (i == 4) Global.ArrData[4] = Global.GenData[4];
                           
                           
        //                    Global.ArrData[i] = Rd.GetValue(i).ToString();
                           
        //                    if (Global.ArrData[i] == null)
        //                    {
        //                        Global.ArrData[i] = "0.0";
        //                    }
        //                }
        //            }
        //            Global.con.Close();  
        //            Double T = 0;
        //            T = Double.Parse(Global.ArrData[0]);
        //            Global.ArrData[0] = T.ToString("0000");

        //            Global.AvgRpm = int.Parse(Global.ArrData[0]);
        //            Global.AvgTrq = Convert.ToDouble(Global.ArrData[1]);

        //            if (Convert.ToString(Global.AvgRpm) == null) Global.AvgRpm = Global.varRPM;
        //            if (Convert.ToString(Global.AvgTrq) == null) Global.AvgTrq  = Global.varTRQ;
        //            Double P = 0;
        //            P = (2 * 3.142 * Global.AvgRpm * Math.Abs(Global.AvgTrq) / (4500 * 9.81));
        //            Global.AvgPowPs = Convert.ToDouble(P.ToString("00.00"));
        //            P = 0;
        //            P = (2 * 3.142 * Global.AvgRpm * Math.Abs(Global.AvgTrq) / 60000);
        //            Global.AvgPowkW = Convert.ToDouble(P.ToString("00.00"));
                    
        //            if (Global.AvgPowkW <= 0) Global.AvgPowkW = 0.1;
        //            if (Global.AvgPowPs <= 0) Global.AvgPowPs = 0.1;
                   

        //            for (i = 0; i < 92; i++)
        //            {
        //                if (i == Global.fxd[11]) Global.ArrData[11] = Global.GenData[3].ToString();
        //                else if (i == Global.fxd[12]) Global.ArrData[12] = Global.GenData[4].ToString();
        //                else
        //                {
        //                    Double l = Double.Parse(Global.ArrData[i]);
        //                    if (Global.PMax[i].Substring(1, 1) == ".")
        //                    {
        //                        Global.ArrData[i] = l.ToString("0.000");
        //                    }
        //                    else if (Global.PMax[i].Substring(2, 1) == ".")
        //                    {
        //                        Global.ArrData[i] = l.ToString("00.00");
        //                    }
        //                    else if (Global.PMax[i].Substring(3, 1) == ".")
        //                    {
        //                        Global.ArrData[i] = l.ToString("000.0");

        //                    }
        //                    else
        //                    {
        //                        Global.ArrData[i] = l.ToString("0000");
        //                    }
        //                }
        //            }
        //            //if (Global.flg_SFCStart == true) Calculate_SFC();
        //            int t = 100;
        //            if (Global.flg_SFCStart == true)
        //            {
        //                Global.Data[3] = Global.ArrData[11];
        //                Global.Data[4] = Global.ArrData[12];
        //                Global.Data[t + 1] = Global.SmkVal.ToString();
        //                Global.Data[t + 2] = Global.BlBy.ToString();
        //                Global.Data[t + 3] = Global.ArrData[11].ToString();
        //                Global.Data[t + 4] = Global.ArrData[12].ToString();

        //                if ((Global.Corfact > 1.2) && (Global.Corfact < 0.8)) Global.Corfact = 1.01234;
        //                Global.Data[t + 5] = Global.Corfact.ToString("0.00000");
        //                Global.Data[t + 6] = Global.AvgTrq.ToString("00.0");
        //                Global.Data[t + 7] = Global.AvgPowkW.ToString("00.0");
        //                Global.Data[t + 8] = Global.SFCVal.ToString("000.0");
        //                Global.Data[t + 9] = Global.Bi_Val.ToString("00.0");
        //                Global.Data[t + 10] = (Convert.ToDouble(Global.Data[106]) * Global.Corfact).ToString("00.0");
        //                Global.Data[t + 11] = (Convert.ToDouble(Global.Data[107]) * Global.Corfact).ToString("00.0"); 
        //                Global.Data[t + 12] = (Convert.ToDouble(Global.Data[108]) / Global.Corfact).ToString("00.0");
        //                Global.Data[t + 13] = (Convert.ToDouble(double.Parse(Global.Data[103]) / double.Parse(Global.Data[104])) * 3.6).ToString("0.00");
        //                Global.Data[t + 14] = (Convert.ToDouble((double.Parse(Global.Data[103]) / double.Parse(Global.Data[104])) * 3.6) / 0.835).ToString("0.00");
        //                Global.Data[t + 15] =  Global.AvgPowPs.ToString("00.0");
        //                Global.Data[t + 16] = ((Global.AvgPowPs) * (Global.Corfact)).ToString("00.0");
        //                Global.Data[t + 17] = ((Global.SFCVal) / 0.735).ToString("000.0");
        //                Global.Data[t + 18] = ((Global.SFCVal) / (0.735 * Global.Corfact)).ToString("000.0");
        //                Global.Data[t + 19] = (Global.varbmep).ToString(); 
        //                Global.Data[t + 20] = "0.0";
        //                Global.Data[t + 21] = "0.0";
                         
        //            }
        //            else 
        //            {
        //                Global.Data[3] = "00.00";
        //                Global.Data[4] = "00.00";
        //                Global.Data[t + 1] = "00.00";
        //                Global.Data[t + 2] = "00.00";
        //                Global.Data[t + 3] = "00.00";
        //                Global.Data[t + 4] = "00.00";
        //                if ((Global.Corfact > 1.2) && (Global.Corfact < 0.8)) Global.Corfact = 1.01234;
        //                Global.Data[t + 5] = Global.Corfact.ToString("0.00000");
        //                Global.Data[t + 6] = Global.AvgTrq.ToString("00.0");
        //                Global.Data[t + 7] = Global.AvgPowkW.ToString("00.0");
        //                Global.Data[t + 8] = "00.00";
        //                Global.Data[t + 9] = "00.00";
        //                Global.Data[t + 10] = (Convert.ToDouble(Global.Data[106]) * Global.Corfact).ToString("00.0");
        //                Global.Data[t + 11] = (Convert.ToDouble(Global.Data[107]) * Global.Corfact).ToString("00.0");
        //                Global.Data[t + 12] = "00.00";
        //                Global.Data[t + 13] = "00.00";
        //                Global.Data[t + 14] = "00.00";
        //                Global.Data[t + 15] = Global.AvgPowPs.ToString("00.0");
        //                Global.Data[t + 16] = ((Global.AvgPowPs) * (Global.Corfact)).ToString("00.0");
        //                Global.Data[t + 17] = "00.00";
        //                Global.Data[t + 18] = "00.00";
        //                Global.Data[t + 19] = (Global.varbmep).ToString(); 
        //                Global.Data[t + 20] = "0.0";
        //                Global.Data[t + 21] = "0.0";
                       
        //            }
        //            Global.Data[122] = Global.Prj[5]; // +", " + Global.T_CellNo + ", " + Global.Shift + ", " + Global.EngNo + ", " + Global.FipNo + ", " + Global.EngMd;
        //            Global.Data[123] = Global.StpTm;
        //            Global.Data[124] = Global.cumhours;   //Global.Data[124] = "***"; // Global.T_CellNo + ", " + Global.Shift + ", " + Global.EngNo + ", " + Global.FipNo + ", " + Global.EngMd;
        //                if (Global.StrAlarm == String.Empty) Global.StrAlarm = "*****";
        //                Global.Data[125] = Global.StrAlarm;
                   
        //            Global.Open_Connection("gen_db", "Con");
        //            SqlCommand cmd = new SqlCommand("DELETE * FROM AVGTemp", Global.con);
        //            cmd.ExecuteNonQuery();
        //            Global.con.Close ();
        //            for (int k = 0; k < 125; k++)
        //            {
        //                Global.GenData[k] = Global.Data[k];   
        //            }
        //            //if (Global.flg_SFCStart == true) Calculate_SFC();

        //            Sn += 1;
        //            String strData = null;
        //            for (i = 0; i <= 125; i++)
        //            {
        //                if (Global.GenData[i] == null) Global.GenData[i] = "0.0";
        //                strData = strData + Global.GenData[i] + "', '";
        //            }


        //            Global.Open_DataConn("Data", "conData");
        //            SqlDataAdapter adpFilenm = new SqlDataAdapter("SELECT * FROM " + Global.Eng_FileNm, Global.conData);
        //            DataSet ds4 = new DataSet();
        //            adpFilenm.Fill(ds4);
                 
        //            if (ds4.Tables[0].Rows.Count != 0)
        //            {
                       
        //                SqlCommand cmd4 = new SqlCommand("SELECT MAX(Pn)FROM " + Global.Eng_FileNm, Global.conData);
        //                SqlDataReader rd4 = cmd4.ExecuteReader();
        //                while (rd4.Read())
        //                {

        //                    sn1 = int.Parse(rd4.GetValue(0).ToString());
        //                }
        //            }
        //            else
        //            {
        //                sn1 = 0;
        //            }
        //            sn2 = sn1 + 1;


        //            cmd = new SqlCommand();
        //            cmd.CommandText = "INSERT INTO " + Global.Eng_FileNm + " VALUES ('" + strData + Global.Eng_FileNm + "', '" + sn2 + "')";
        //            cmd.Connection = Global.conData;
        //            cmd.ExecuteNonQuery();
        //            txtlog.Text = Sn.ToString();
        //            Global.conData.Close();  
                                  
        //        }
        //        tmrLog.Enabled = true; 
        //            Global.flg_SFCStart = false;
        //    }

        //    catch (Exception ex)
        //    {
        //        //AddListItem("Error in Make avg ", 6);
        //        Global.Create_OnLog("Error in Make avg "+ex.Message );  
        //        return;
        //    }

            //******************************

        //}

        
        private void RdProg()
        {
            try
            {
                String A = " rpm";
                String B = " Nm";
                String C = " %";

                Global.Open_Connection("seq_db", "conSeq");
                MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM " + Global.Prj[2] + " ORDER BY StepNo", Global.conSeq);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                Int16 x = 0;
                Int16 y = 0;
                //string st = "";
                GridSeq1.RowCount = (ds.Tables[0].Rows.Count + 1);

                for (x = 0; x <= (ds.Tables[0].Rows.Count - 1); x++)
                {
                    for (y = 0; y < (ds.Tables[0].Columns.Count); y++)
                    {
                        String T = "0";
                        switch (y)
                        {
                            case 3:
                            case 5:
                            case 6:
                            case 7:
                                T = ds.Tables[0].Rows[x].ItemArray[y].ToString();
                                int TR = ((int.Parse(T.Substring(0, 2)) * 60) + int.Parse(T.Substring(3, 2)));
                                if (TR <= 1) TR = 1;
                                TimeSpan t = TimeSpan.FromSeconds(TR);
                                GridSeq1[y, x].Value = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                t.Hours,
                                t.Minutes,
                                t.Seconds);
                                break;
                            case 11:
                            case 12:
                            case 13:

                            case 16:
                            case 17:
                            case 18:
                                if (ds.Tables[0].Rows[x].ItemArray[y].ToString() == "1")
                                    GridSeq1[y, x].Value = true;
                                else 
                                    GridSeq1[y, x].Value = false;
                                break;
                            

                            case 15:
                                Int16 Ts = Convert.ToInt16(ds.Tables[0].Rows[x].ItemArray[15]);
                                t = TimeSpan.FromSeconds(Ts);

                                GridSeq1[y, x].Value = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                t.Hours,
                                t.Minutes,
                                t.Seconds);
                                break;
                            case 29:
                                GridSeq1[y, x].Value = ds.Tables[0].Rows[x].ItemArray[29];
                                break;
                            default:
                                GridSeq1[y, x].Value = ds.Tables[0].Rows[x].ItemArray[y].ToString();
                                break;
                        }
                    }
                    Int16 Q = Convert.ToInt16(GridSeq1[1, x].Value);
                    switch (Q)
                    {
                        case 1:
                            GridSeq1[2, x].Value = GridSeq1[2, x].Value + " (" + C + ")";
                            GridSeq1[4, x].Value = GridSeq1[4, x].Value + " (" + C + ")";
                            break; 
                        case 2:
                            GridSeq1[2, x].Value = GridSeq1[2, x].Value + " (" + A + ")";
                            GridSeq1[4, x].Value = GridSeq1[4, x].Value + " (" + C + ")";
                            break;
                        case 3:
                            GridSeq1[2, x].Value = GridSeq1[2, x].Value + " (" + C +")";
                            GridSeq1[4, x].Value = GridSeq1[4, x].Value + " (" + B + ")";
                            break;
                        case 4:
                            GridSeq1[2, x].Value = GridSeq1[2, x].Value + " (" + A + ")";
                            GridSeq1[4, x].Value = GridSeq1[4, x].Value + " (" + B + ")";
                            break;
                        case 5:
                            GridSeq1[2, x].Value = GridSeq1[2, x].Value + " (" + A + ")";
                            GridSeq1[4, x].Value = GridSeq1[4, x].Value + " (" + C + ")";
                            break;
                        case 6:
                            GridSeq1[2, x].Value = GridSeq1[2, x].Value + " (" + A + ")";
                            GridSeq1[4, x].Value = GridSeq1[4, x].Value + " (" + B + ")";
                            break;
                    }                   
                                       
                }
                Global.conSeq.Close();
                Global.Create_OnLog("Prog File Read Successfully....", "Normal");
                //MessageBox.Show("Prog File Read Successfully....", "Dynalec Control Pvt Ltd.",
                //MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Prog File not Read Sucessfully....", "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Global.Create_OnLog("Prog File not Read Sucessfully....", "Alert");
                Global.Create_OnLog("Error in Main: Rd_Prog() : ", "Alert");
                MessageBox.Show("Error in Main: Rd_Prog() :" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
       

        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        //private static double RandomNumber2(double min, double max)
        //{
        //    Random random = new Random();
        //    return random.NextDouble(min + 0.2,) * (min);
        //}

      
        private void Fun_AnalogOut_StandardChangeover()
        {
            try
            {
                if (PBar3.Caption == "RAMP TIME:")
                {
                    flg_Ramp = true;
                    
                    clsFun.MODE_TO_MODE(); // _STANDARD(); // _New(); 
                    tmrWrite.Interval = 100;

                    switch (Global.C_Mode)
                    {

                        case "0":
                        case "1":
                            txtSetpt1.Text = (Global.AnaOut1 * 10).ToString("00.00");
                            //txtSetpt2.Text = (Global.AnaOut2 * 10).ToString("00.00");
                            break;
                        case "2":
                            txtSetpt1.Text = (Global.AnaOut1 * (Convert.ToDouble(Global.sysIn[5])) / 10).ToString("0000");
                            //txtSetpt2.Text = (Global.AnaOut2 * 10).ToString("00.00");
                            break;
                        case "3":
                            txtSetpt1.Text = (Global.AnaOut1 * 10).ToString("00.00");
                            //txtSetpt2.Text = (Global.AnaOut2 * (Convert.ToDouble(Global.sysIn[4])) / 10).ToString("000.0");
                            break;
                        case "4":
                            txtSetpt1.Text = (Global.AnaOut1 * (Convert.ToDouble(Global.sysIn[5])) / 10).ToString("0000");
                            //txtSetpt2.Text = (Global.AnaOut2 * (Convert.ToDouble(Global.sysIn[4])) / 10).ToString("000.0");
                            break;
                        case "5":
                            //txtSetpt2.Text = (Global.AnaOut2 * 10).ToString("00.00");
                            txtSetpt1.Text = (Global.AnaOut1 * (Convert.ToDouble(Global.sysIn[5])) / 10).ToString("0000");
                            break;
                        case "6":
                            //txtSetpt2.Text = (Global.AnaOut2 * (Convert.ToDouble(Global.sysIn[4])) / 10).ToString("000.0");
                            txtSetpt1.Text = (Global.AnaOut1 * (Convert.ToDouble(Global.sysIn[5])) / 10).ToString("0000");
                            break;
                    }
                }

                else if ((PBar3.Caption == "STEADY TIME:") || (PBar3.Caption == "STABILISATION TIME:"))
                {
                    //Global.AOvar = Global.AnaOut1.ToString("00.000");
                    //if (Global.RTPort.IsOpen) Global.Init_RtPort. .Init_RtPort();
                    //Global.RTPort.Write("#04C0+" + Global.AOvar + "\r");
                    //Global.AnaOut1 = Global.AnaOut1 + Global.Diff1;

                    flg_Ramp = false;
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
                 //   Tss7.Text = Global.AnaOut2.ToString("0.000");
                    tmrWrite.Interval = 100;
                    //switch (Global.C_Mode)
                    //{
                    //    case "2":
                    //    case "4":
                    //    case "5":
                    //    case "6":
                    //        if (Global.sysIn[13] == "TRUE")
                    //        {
                    //            int rDiff = (Convert.ToInt32(Convert.ToDouble(Global.SetPtOut1) * (Convert.ToDouble(Global.sysIn[5]) / 10)) - Convert.ToInt32(Global.varRPM));
                    //            if ((rDiff <= 60) && (rDiff >= 4))
                    //            {
                    //                Global.AnaOut1 = Global.AnaOut1 + 0.0002;
                    //            }
                    //            else if ((rDiff >= -60) && (rDiff <= -4))
                    //            {
                    //                Global.AnaOut1 = Global.AnaOut1 - 0.0002;
                    //            }
                    //        }
                    //        break;
                    //    default:
                    //        Tss6.Text = Global.AnaOut1.ToString("0.000");
                    //        Tss7.Text = Global.AnaOut2.ToString("0.000");
                    //        txtSetpt1.Text = (Global.AnaOut1 * 10).ToString();
                    //        //txtSetpt2.Text = (Global.AnaOut2 * 10).ToString();
                    //        break;
                    //}
                }
                //Tss6.Text = String.Format("{0:0.000}", Global.AnaOut1);
                //Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);               

                switch (int.Parse(Global.C_Mode))
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        //PBar1.Value = (int)(Global.AnaOut1 * 1000);
                        PBar2.Value = (int)(Global.AnaOut1 * 1000);
                        break;
                    case 5:
                    case 6:
                        //PBar1.Value = (int)(Global.AnaOut2 * 1000);
                        PBar2.Value = (int)(Global.AnaOut1 * 1000);
                        break;
                }
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: Fun_AnaOut() : ", "Alert");
                MessageBox.Show("Error in frmMain: Fun_AnalogOut():" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Error in frmMain: Fun_AnalogOut():  " + ex.Message);
            }
        }

        
       
       
        private void tmrEnd_Tick(object sender, EventArgs e)
        {
            try
            {

                flg_AnaOut = false;
                flg_ProgOut = false;
                stopsec = stopsec - 1; //(seconds / 10);
                if (stopsec <= 0) stopsec = 0;
                t = TimeSpan.FromSeconds(stopsec);

                answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                txtPStatus.Text = answer;

                settimefor_gridseq();
                //PBar1.Value = (int)(Global.AnaOut1 * 1000);
                PBar2.Value = (int)(Global.AnaOut1 * 1000);

                PBar3.Maximum = 100;
                PBar3.Value = (int)(stopsec);
                if (PBar3.Value == 0)
                    PBar3.Value = 0;
                if (int.Parse(Global.C_Mode) <= 4)
                {
                    if (Global.AnaOut1 >= 0.81)  // ((Global.AnaOut2 > 0.1) && (Global.AnaOut1 >= 0.81))
                    {
                        Global.AnaOut1 = Global.AnaOut1 - Global.Edif1;
                        //Global.AnaOut2 = Global.AnaOut2 - Global.Edif2;
                        //if (Global.AnaOut2 <= 0) Global.Edif2 = 0;
                        if (Global.AnaOut1 <= 0.80) Global.Edif1 = 0;
                        // Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Tss6.Text = String.Format("{0:0.800}", Global.AnaOut1);
                        txtSetpt1.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        //txtSetpt2.Text = String.Format("{0:0.800}", Global.AnaOut2);

                    }
                    else
                    {
                        Global.AnaOut1 = 001;
                        //Global.AnaOut2 = 001;
                        //Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        // Tss6.Text = String.Format("{0:0.800}", Global.AnaOut1);
                        txtSetpt1.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        //txtSetpt2.Text = String.Format("{0:0.800}", Global.AnaOut2);
                        //Global.Mode_Out(1, 0, 0);
                        ResetOutPut();
                        tmrEnd.Enabled = false;
                        if (flg_ChkAlarmON == true)
                            MessageBox.Show("Engine Is off Due to 'OFF' : Alarm" + "\n" +
                            " Please check On_log Error File");

                        EngOK frm = new EngOK();
                        frm.ShowDialog(this);
                        frm.Dispose();
                    }
                }
                else if (int.Parse(Global.C_Mode) >= 5)
                {
                    if ((Global.AnaOut2 > 0.1))
                    {
                        //Global.AnaOut1 = Global.AnaOut1 - Global.Edif1;
                        Global.AnaOut2 = Global.AnaOut2 - Global.Edif2;
                        if (Global.AnaOut2 <= 0) Global.Edif2 = 0;
                        if (Global.AnaOut1 <= 0.8) Global.Edif1 = 0;
                        //Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        // Tss6.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        txtSetpt1.Text = String.Format("{0:0.800}", Global.AnaOut1);
                        //txtSetpt2.Text = String.Format("{0:0.000}", Global.AnaOut2);
                    }
                    else
                    {
                        Global.AnaOut1 = 0.8;
                        Global.AnaOut2 = 0.01;
                        //Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        //Tss6.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        txtSetpt1.Text = String.Format("{0:0.800}", Global.AnaOut1);
                        //txtSetpt2.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        //Global.Mode_Out(1, 0, 0);

                        tmrEnd.Enabled = false;
                        if (flg_ChkAlarmON == true)
                            MessageBox.Show("Engine Is off Due to 'OFF' : Alarm" + "\n" +
                           " Please check On_log Error File");
                        ResetOutPut();
                        EngOK frm = new EngOK();
                        frm.ShowDialog(this);
                        frm.Dispose();
                    }
                }
                // Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);
                // Tss6.Text = String.Format("{0:0.800}", Global.AnaOut1);
                txtSetpt1.Text = String.Format("{0:0.800}", Global.AnaOut1);
                //txtSetpt2.Text = String.Format("{0:0.000}", Global.AnaOut2);
                Global.flg_EngStart = false;
                Global.Sn = 0;
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Problem In Engine Stop.....", "Alart");

                //MessageBox.Show("Error in frmMain: tmrEnd_Tick():  " + ex.Message);
            }
        }
       

        private void tmrLog_Tick(object sender, EventArgs e)
        {
            try
            {
                if (flg_ProgOut == true) Fun_ProgOut();   

                //semi Auto Mode Logging..
                if ((checkBox11.CheckState == CheckState.Checked))
                {
                    if (Global.LTm >= Global.LogTm)
                    {
                        LogData();
                        Global.LTm = 1;
                        lblLog.Text = Global.Sn.ToString();
                    }
                    else
                    {
                        Global.LTm++;
                        label3.Text = Global.LTm.ToString();

                    }
                }

                //*********************************

                if (Global.flg_RecorsPmData == true) Global.RecordPMData();


                            if (flg_PerStep == true)
                            {
                                if (SockT >= 44)
                                {                                    

                                    if (((Tstd == 35) || (Tstd == 34)) && (flg_PerStep == true))
                                    {  
                                        GridSeq1.Columns[10].HeaderText = "LogData    ( " + LogT + " )";
                                        Tss9.Text = "Averaging Started.....";
                                        Tss9.BackColor = Color.Red;
                                        Tss9.ForeColor = Color.Yellow;
                                        tmrAvg.Start();
                                    }
                                    else
                                        if ((Tstd == 5) ||((Tstd == 4)) && (flg_SaveData == true))
                                        {
                                            tmrAvg.Stop();
                                            Tss9.Text = "Data Logged.....";
                                            Tss9.BackColor = Color.Silver;
                                            Tss9.ForeColor = Color.Blue;
                                            LogData(); 
                                            //MakeAVGData();
                                        }
                                }
                                else
                                {
                                    GridSeq1.Columns[10].HeaderText = "LogData    ( " + LogT + " )";
                                    if ((flg_Std == true) && ((Tstd == 5) || ((Tstd == 4))) && (flg_SaveData == true))
                                    {
                                        LogData();
                                        Update_ViewData();
                                        flg_PerStep = false;
                                    }
                                }
                            }
                            else if (flg_Instat == true)
                            {
                                
                                GridSeq1.Columns[10].HeaderText = "LogData    ( " + DataCnt + " )";

                                if ((flg_Std == true) && (SockT > 45))
                                {
                                    if (DataCnt <= 1)
                                    {
                                        DataCnt = LogT;
                                        flg_SaveData = true;
                                    }
                                    else DataCnt -= 1;

                                    if (LogT >= 44)
                                    {
                                        if (((DataCnt == 35) || (DataCnt == 34)) && (flg_Instat == true))
                                        {
                                            Tss9.Text = "Averaging Started.....";
                                            Tss9.BackColor = Color.Red;
                                            Tss9.ForeColor = Color.Yellow;
                                            tmrAvg.Start();

                                        }
                                        else if (((DataCnt == 5) || (DataCnt == 4)) && (flg_SaveData == true))
                                        {
                                            tmrAvg.Stop();
                                            Tss9.Text = "Data Logged.....";
                                            Tss9.BackColor = Color.Silver;
                                            Tss9.ForeColor = Color.Blue;
                                            MakeAVGData();
                                            Update_ViewData();
                                        }
                                    }
                                }
                                else
                                {
                                    if ((flg_Instat == true) && (flg_Std == true)) // && (SockT < 45))
                                    {
                                        if (DataCnt <= 1)
                                        {
                                            DataCnt = LogT;
                                            flg_SaveData = true;
                                        }
                                        else DataCnt -= 1;

                                        if (DataCnt == 1)
                                        {
                                            LogData();
                                            Update_ViewData();
                                            GridSeq1.Columns[10].HeaderText = "LogData    ( " + LogT + " )";
                                            flg_PerStep = false;
                                        }
                                    }
                                }  
                            }
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show("Error Code:10740  " + ex.Message);
                            MessageBox.Show("Error in Tmer Log Data" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //AddListItem("Error TmrLog Data", "Alert");
                            return;
                        }
            }
           
        private void MakeAVGData()
        {
            try
            {
                String Str = String.Empty;
                int i = 0;
                //Global.Sn++;
                Global.Open_Connection("gen_db", "con");
                MySqlDataAdapter Adp = new MySqlDataAdapter("SELECT * FROM gen_db.avgtemp", Global.con);
                DataSet ds = new DataSet();
                Adp.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                  
                    Str = "SELECT ";
                    for (i = 0; i <= 95; i++)
                    {
                        if ((i != 2) || (i != 3) || (i != 4) || (i != 5))
                        {
                            if (i == 95)
                            {
                                Str = Str + "avg(" + ds.Tables[0].Columns[i].ColumnName + ") ";
                            }
                            else
                            {
                                Str = Str + "avg(" + ds.Tables[0].Columns[i].ColumnName + "), ";
                            }
                        }

                    }
                    string Str1 = Str + "from AvgTemp";
                    MySqlCommand AVGcmd = new MySqlCommand(Str1, Global.con);
                    AVGcmd.ExecuteNonQuery();
                    MySqlDataReader Rd = AVGcmd.ExecuteReader();
                    i = 0;
                    Double M = 0;
                    while (Rd.Read())
                    {
                        for (i = 0; i < 90; i++)
                        {
                            M = Double.Parse(Rd.GetValue(i).ToString());
                            if ((Global.PUnit[i] == "Nm") || (Global.PUnit[i] == "°C") || (Global.PUnit[i] == "%"))
                                Global.ArrData[i] = M.ToString("000.0");
                            else if ((Global.PUnit[i] == "bar"))
                                Global.ArrData[i] = M.ToString("0.000");
                            else if ((Global.PUnit[i] == "rpm") || (Global.PUnit[i] == "r/min") || (Global.PUnit[i] == "mbar") || (Global.PUnit[i] == "lpm"))
                                Global.ArrData[i] = M.ToString("0000");
                            else
                                Global.ArrData[i] = M.ToString("##0.0##");

                            if (Global.ArrData[i] == null) Global.ArrData[i] = "0.0";

                            if (Global.ArrData[i] == null)
                            {
                                Global.ArrData[i] = "0.0";
                            }
                        }
                    }
                    Rd.Close();
                    Global.con.Close();
                    Double T = 0;
                    T = Double.Parse(Global.ArrData[0]);
                    //Global.ArrData[0] = T.ToString("0000");
                    Global.AvgRpm = int.Parse(Global.ArrData[0]);
                    Global.AvgTrq = Double.Parse(Global.ArrData[1]);
                    if (Global.AvgRpm <= 0) Global.AvgRpm = 0.1;
                    if (Global.AvgTrq <= 0) Global.AvgTrq = 0.1;
                    Double P = 0;
                    P = (2 * 3.142 * Global.AvgRpm * Math.Abs(Global.AvgTrq) / (4500 * 9.81));
                    Global.AvgPowPs = Double.Parse(P.ToString("00.00"));
                    P = 0;
                    P = (2 * 3.142 * Global.AvgRpm * Math.Abs(Global.AvgTrq) / 60000);
                    Global.AvgPowkW = Double.Parse(P.ToString("00.00"));
                    if (Global.AvgPowkW <= 0) Global.AvgPowkW = 0.1;
                    if (Global.AvgPowPs <= 0) Global.AvgPowPs = 0.1;

                    if ((Global.AvgRpm >= 1000) && (Global.AvgTrq >= 10))
                    {
                        //Double SFC = (Convert.ToDouble(Global.ArrData[89]) * 1000 / Global.AvgPowPs);

                        //if (SFC >= 1000)
                        //{
                        //    Global.ArrData[108] = "999";
                        //    Global.SFCVal = 999;
                        //}
                        //else
                        //{
                        //    Global.ArrData[108] = SFC.ToString("000.0");
                        //    Global.SFCVal = SFC;
                        //}
                    }
                    else
                        //Global.SFCVal = 00.0;

                    for (i = 0; i < 60; i++)
                    {
                        if (Global.ArrData[i] == null)
                        {
                            Global.ArrData[i] = "0.00";
                        }
                        Global.Data[i] = Global.ArrData[i];
                    }
                    
                       
                    
                    int t = 100;
                    Global.Data[t + 1] = Global.SmkVal.ToString();
                    Global.Data[t + 2] = "00.0";  // Global.Blow_by.ToString();
                    Global.Data[t + 3] = Global.SFCwt.ToString("##0.0");
                    Global.Data[t + 4] = Global.SFCTm.ToString("##0.0");
                    if ((Global.Corfact > 1.2) && (Global.Corfact < 0.8)) Global.Corfact = 1.01234;
                    Global.Data[t + 5] = Global.Corfact.ToString("0.00000");  //
                    Global.Data[t + 6] = Global.varTRQ.ToString("000.0");
                    Global.Data[t + 7] = Global.VarPowkW.ToString("000.0");
                    Global.Data[t + 8] = (Global.SFCValkW).ToString("000.0");
                    Global.Data[t + 9] = Global.Bi_Val.ToString("00.0");
                    Global.Data[t + 10] = (Global.AvgTrq * Global.Corfact).ToString("00.00");
                    Global.Data[t + 11] = (Global.VarPowkW * Global.Corfact).ToString("00.0");
                    Global.Data[t + 12] = (Global.SFCValkW / Global.Corfact).ToString("00.0");

                    Global.Data[t + 13] = ((Global.SFCwt / Global.SFCTm) * 3.6).ToString("00.00"); // (Double.Parse(Double.Parse(Global.Data[103]) / Double.Parse(Global.Data[104])) * 3.6).ToString("0.00");
                    Global.Data[t + 14] = "00.00"; //(Double.Parse((double.Parse(Global.Data[103]) / double.Parse(Global.Data[104])) * 3.6) / 0.835).ToString("0.00");
                    Global.Data[t + 15] = Global.AvgPowPs.ToString("00.0");
                    Global.Data[t + 16] = ((Global.AvgPowPs) * (Global.Corfact)).ToString("00.0");
                    Global.Data[t + 17] = Global.SFCValPs.ToString("000.0");
                    Global.Data[t + 18] = ((Global.SFCValPs) / (Global.Corfact)).ToString("000.0");
                    Global.Data[t + 19] = Global.varbmep.ToString("0.000");
                    Global.Data[t + 20] = Global.Rel_Hum.ToString("00.0");
                    Global.Data[t + 21] = Global.TestTyp; //  Global.Rel_Hum.ToString("00.0");

                    string l = DateTime.Now.ToString("dd/MM/yyyy");
                    if (Global.OperatorNm == null) Global.OperatorNm = "OpName";
                    if (Global.TKnNo == null) Global.TKnNo = "TNo";
                    if (Global.EngMd == null) Global.EngMd = "EngMd";


                    Global.Data[122] = System.DateTime.Now.ToString("hh:mm:ss tt");
                    Global.Data[123] = Global.S_StartTime;
                    Global.Data[124] = clsFun.cummbuff;
                    if (Global.StrAlarm == String.Empty) Global.StrAlarm = "*****";
                    Global.Data[125] = Global.StrAlarm;
                    Global.Data[126] = Global.StpComm; // "******"; //  l + ", " + Global.Shift + ", " + Global.T_CellNo + ", " + Global.OperatorNm + ", " + Global.TKnNo + ", " + Global.EngNo + ", " + Global.EngMd + ", " + Global.FipNo;
                    //*****************************
                    if (Global.Eng_FileNm == "") Global.Eng_FileNm = "Man";
                    Global.flg_DataSave = true;
                    if (Global.flg_DataSave == true)
                    {
                        i = 0;
                        //if (Global.Sn == 0) fill_Engine_Details();
                        Global.Sn += 1;

                        String strData = null;
                        //for (i = 0; i <= 124; i++)
                        //{
                        //    if (Global.Data[i] == null) Global.Data[i] = "0.0";
                        //    strData = strData + Global.Data[i] + ", ";
                        //}
                        strData = "";
                        for (i = 0; i < 127; i++)
                        {
                            if (Global.Data[i] == null) Global.Data[i] = "000.000";
                            strData = strData + Global.Data[i] + ", ";
                        }

                        strData = strData + Global.StrAlarm + ", " + Global.Sn + ",\n";
                        var filePath = Global.DataPath + "Gen_Data\\" + Global.Eng_FileNm + ".csv";
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
                            Global.flg_DataSave = false;
                        }

                    }
                    //***********************
                }
                st.Start();
                tmrLog.Enabled = true;
                Global.flg_SFCStart = false;

                Global.flg_UpdateViewData = true;
                flg_SaveData = false;
                lblLog.Text = Global.Sn.ToString("000");
                AddListItem("Avg-Data Logged... ", "Normal");
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in Make Data avg ", "Alert"); // + ex.Message);
                MessageBox.Show("Error in Make Data avg " + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //******************************
        }       
        public  void ResetOutPut()
        {
            try
            {
                flg_AnaOut = true;
                Global.C_Mode = "1";
                Global.Mode_Out(1, 0, 0);
                Global.SetPtOut1 = "0";
                Global.SetPtOut2 = "0";
                Global.LastAna1 = 0;
                Global.LastAna2 = 0;
                Global.AnaOut1 = 0.01;
                Global.AnaOut2 = 0.01;
                Global.C_Mode = "1";
                 flg_AnaOut = false;
                 Global.flg_RunStart = false;
                 //btn25.Enabled = true;
                 Btn25.Enabled = false;

                 mnuRunStatus.Enabled = true;
                 //mnuSemAuto.Enabled = true;
                 Btn21.Enabled = false;
                 BtnSA.Enabled = false; 

                t = TimeSpan.FromSeconds(0);
                answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                txtPStatus.Text = answer;
                //txtPStatus.Text = "000";
                settimefor_gridseq();
                tmrLog.Enabled = false;
                LogT = 0;
                //checkBox16.Text = "000";
                PBar3.Value = 1;
                //Btn21.Enabled = true;
                Btn22.Enabled = false;              
                Btn24.Enabled = false;
                lblLog.Text = "000"; 
                
                GridSeq1.Rows.Clear();
                GridSeq1.RowCount = 10; 
                Global.Rd_Confg();
                Global.Rd_ECU_Confg(); 
                //Global.Read_ECU_Names();

                Load_Arr();
                Global.StpLimFl = "Lim_STANDBY";               
                clsLimit.Read_LimtStandby();
                if (Global.RTPort.IsOpen)
                {
                    Global.AOvar = Global.AnaOut1.ToString("00.000");
                    Global.RTPort.Write("#04C0+" + Global.AOvar + "\r");
                }
                
                Global.SFC_msg = "SFC Status .....";
                //if  (Global.flg_smk = true) Global.Init_SmokePort();
                Global.Create_OnLog("SYSTEM RESETED SUCCESSFULLY.....", "Normal");


            }
            catch (Exception ex)
            {
                Global.Create_OnLog("PROBLEM IN ResetOutPut.....", "Alert");
                MessageBox.Show("Error in frmMain: ResetOutPut():" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Error in frmMain: ResetOutPut():  " + ex.Message);
            }
        }
        public void IdleEng()
        {
            try
            {
                Global.flg_SFCStart = false;
                Global.flg_SFCON = false;
                Global.flg_SFCOVER = false;
                Global.flg_SFCReset = false;

                flg_Avg = false;
                flg_Ramp = false;
                flg_Stb = false;
                flg_Std = false;
                Global.Edif1 = (Global.AnaOut1) / (40);
                Global.Edif2 = (Global.AnaOut2) / (40);
                stopsec = 100;
                tmrIdel.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: IdelEng():" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
               // MessageBox.Show("Error in frmMain: IdelEng():  " + ex.Message);
            }
        }

        public void stopEngine()
        {
            try
            {
                Global.flg_SFCStart = false;
                Global.flg_SFCON = false;
                Global.flg_SFCOVER = false;
                Global.flg_SFCReset = false;
                Global.flg_LimitON = false;
                flg_Avg = false;
                flg_Ramp = false;
                flg_Stb = false;
                flg_Std = false;
                Global.Edif1 = (Global.AnaOut1) / 50;
                Global.Edif2 = (Global.AnaOut2) / 20;
                stopsec = 100;
                Global.Open_Connection("gen_db", "con");
                string h = Tss2.Text.Substring(0, 4);
                string m = Tss2.Text.Substring(5, 2);
                string hm = h + "." + m;
                MySqlCommand cmd = new MySqlCommand("Update tblProject SET  C_Time = '" + hm+ "' where ProjectFile= '" + Global.PrjNm + "'", Global.con);
                cmd.ExecuteNonQuery();
                Global.con.Close();
                tmrEnd.Enabled = true;
                Global.Create_OnLog("ENGINE STOPPED SUCCESSFULLY.....", "Normal");

            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Problem in StopEngine.....", "Alert");
                MessageBox.Show("Error in Stopping Engine" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //MessageBox.Show("Error in StopEng function", ex.Message);
            }
        }



        private void Btn1_Click(object sender, EventArgs e)
        {
            try
            {
                if (flg_ProgOut == true)
                {
                    frmLEfiles frm = new frmLEfiles();
                    frm.ShowDialog(this);
                    frm.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Btn1_Click():" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //MessageBox.Show("Error in frmMain: Btn1_Click():  " + ex.Message);
            }
        }               
        public void settimefor_gridseq()
        {
            if (PBar3.Caption == "RAMP TIME:")
            {

                GridSeq1.Columns[3].HeaderText = " RmT-1 (" + txtPStatus.Text + ")";
                GridSeq1.Columns[5].HeaderText = " RmT-2 (" + txtPStatus.Text + ")";
            }
            if (PBar3.Caption == "STABILISATION TIME:")
            {
                GridSeq1.Columns[6].HeaderText = " T_Stb (" + txtPStatus.Text + ")";

            }
            if (PBar3.Caption == "STEADY TIME:")
            {
                GridSeq1.Columns[7].HeaderText = " T_Std (" + txtPStatus.Text + ")";

            }
        }

        private void tmrIdel_Tick(object sender, EventArgs e)
        {
            try
            {
                flg_AnaOut = false;
                flg_ProgOut = false;
               
               
                if (stopsec <= 0)
                    stopsec = 0;
                else
                {
                    stopsec = stopsec - 1;
                    PBar3.Value = (int)(stopsec);
                    t = TimeSpan.FromSeconds(stopsec);
                    answer = string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
                    txtPStatus.Text = answer;
                }
                if (int.Parse(Global.C_Mode) <= 4)
                {
                    if ((Global.AnaOut2 > 0) || (Global.AnaOut1 > 0))
                    {
                        Global.AnaOut1 = Global.AnaOut1 - Global.Edif1;
                        Global.AnaOut2 = Global.AnaOut2 - Global.Edif2;
                        if (Global.AnaOut2 <= 0) Global.Edif2 = 0;
                        if (Global.AnaOut1 <= 0) Global.Edif1 = 0;
                        Tss6.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Tss7.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        txtSetpt1.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        //txtSetpt2.Text = String.Format("{0:0.000}", Global.AnaOut2);
                    }
                    else
                    {
                        Global.AnaOut1 = 0.01;
                        Global.AnaOut2 = 00.01;
                        Tss6.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Tss7.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        txtSetpt1.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        //txtSetpt2.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Hold_Cycle(true); 
                        Btn24.Text = "Step_Resume";
                        tmrIdel.Stop(); 

                    }
                }
                else if (int.Parse(Global.C_Mode) >= 5)
                {
                    if ((Global.AnaOut2 > 0))
                    {
                        //Global.AnaOut1 = Global.AnaOut1 - Global.Edif1;
                        Global.AnaOut2 = Global.AnaOut2 - Global.Edif2;
                        if (Global.AnaOut2 <= 0) Global.Edif2 = 0;
                        if (Global.AnaOut1 <= 0.8) Global.Edif1 = 0;
                        Tss6.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Tss7.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        txtSetpt1.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        //txtSetpt2.Text = String.Format("{0:0.000}", Global.AnaOut2);

                    }
                    else
                    {
                        Global.AnaOut1 = 1;
                        Global.AnaOut2 = 0;
                        Tss6.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Tss7.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        txtSetpt1.Text = String.Format("{0:0.000}", Global.AnaOut1);
                        //txtSetpt2.Text = String.Format("{0:0.000}", Global.AnaOut2);
                        Hold_Cycle(true); 
                        Btn24.Text = "Step_Resume";
                        tmrIdel.Stop(); 
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Timer Idle Problem" + ex.Message  , "Alert",
                //MessageBoxButtons.OK, MessageBoxIcon.Error); 
                Global.Create_OnLog("Timer Idle Problem.....", "Alert");

            }
        }
       
      
     
     
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login frm = new Login ();
            frm.ShowDialog(this);
            frm.Dispose();
        }     
        
        private void eDITORSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process[] prs = Process.GetProcesses();
            //Process pr = new Process(); 
            foreach (Process pr in prs)
            {
                //if (pr.ProcessName == "ModbusPollCS") pr.Kill();
                if (pr.ProcessName == "Editors") pr.Kill();
                if (pr.ProcessName == "EXCEL") pr.Kill();
                //if (pr.ProcessName == "DataAppliacation") pr.Kill();
            }
            p.StartInfo = new ProcessStartInfo(Global.PATH + "Editors.exe");
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal ;
            p.Start();
        }
      

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string helpFilepath = @"" + Global.HelpPATH + "Help.chm";
            if (File.Exists(helpFilepath))
            {
                Process.Start(helpFilepath);
            }
            else
            {
                MessageBox.Show("File not Found" + '\n' + helpFilepath, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
               // MessageBox.Show("file not Found" + helpFilepath);
            }
        }

        private void mnuSystem_MouseMove(object sender, MouseEventArgs e)
        {
            //mnusyspara.ForeColor = Color.White;
        }

        private void mnuSystem_MouseLeave(object sender, EventArgs e)
        {
            //mnusyspara.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
        }

        private void mnuChannel_MouseMove(object sender, MouseEventArgs e)
        {
            mnuChannel.ForeColor = Color.White;  

        }

        private void mnuChannel_MouseLeave(object sender, EventArgs e)
        {
            mnuChannel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));   
        }

       

       
        public  DateTime Eng_Start_DelaySc(int nSeconds)
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
                    Btn21.Enabled = false;
                    if (Global.varRPM >= Global.S_Rpm)
                    {
                        return System.DateTime.Now;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15016" + '\n' + ex.Message, "Alert",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
               // MessageBox.Show("Error Code:- 15016", ex.Message);
                //MessageBox.Show("Error in frmMain: Eng_Start Delay()" + ex.Message, "Alert",
                //MessageBoxButtons.OK, MessageBoxIcon.Error); 
                Global.Create_OnLog("Error in frmMain: Eng_Start Delay() : ", "Alert");
            }
            return System.DateTime.Now;
        }

        private void Btn21_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Global.EngNo == null) || (Global.PrjNm == null))
                {
                    EngDialog frm = new EngDialog(this);
                    frm.ShowDialog(this);
                    frm.Dispose();
                    return;
                }
                int c = 0;
                Global.StpN = 0;
                Global.Sn = 0;
                Global.Ecn = 0;
                Tss2.Text = clsFun.cummbuff;
                Global.Dig_OutBit(0, 7, true);
                BtnSA.Enabled = false;
                Global.flg_Auto = true;
                Btn21.Enabled = false;
                Global.LastAna1 = 0;
                Global.LastAna2 = 0;
                RdProg();
                Load_ProgStep();
                init_ReadyStatus();
                if (Global.varRPM <= (Global.S_Rpm - 20))
                {
                    Tss2.Text = clsFun.cummbuff;
                    Tss1.Text = "Wait For Running signal ......";
                    Tss1.BackColor = Color.Red;
                    Tss1.ForeColor = Color.Yellow;
                    Btn21.Enabled = false;
                    Btn22.Enabled = false;
                    Btn23.Enabled = false;
                    Btn24.Enabled = false;
                    Btn25.Enabled = false;
                    Btn26.Enabled = false;


                    Global.Dig_OutBit(0, 7, true);  //Ingnition on
                    Thread.Sleep(500);
                    Global.Dig_OutBit(1, 0, true);  //Eng start Pulse
                    Thread.Sleep(500);
                    Global.Dig_OutBit(1, 0, false);//Eng start Pulse false


                    Tss1.Text = "Start the Engine....";
                    Eng_Start_DelaySc(3);


                    if (Global.varRPM >= (Global.S_Rpm - 20)) //Convert.ToInt16(Global.Prj[12]))
                    {
                        Tss2.Text = clsFun.cummbuff; ;
                        Global.flg_CycleStarted = true;
                        Tss1.Text = "Engine Started ......";
                        //Update_Tss1(1);
                        Thread.Sleep(500);
                        Tss1.Text = "Engine Is Running ......";
                        Tss1.BackColor = Color.Red;
                        Tss1.ForeColor = Color.Yellow;
                        //MessageBox.Show("Engine Is Running", "Dynalec Control Pvt Ltd.",
                        //MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Global.Create_OnLog("Engine Is Running ......", "Normal");
                        //AddListItem("Engine Is Running ......", 5);
                        tmrInst.Enabled = true;
                        Btn25.Enabled = true;
                        mnuRunStatus.Enabled = true;
                        flg_AnaOut = true;
                        flg_ProgOut = true;
                        Global.Make_mdb(Global.DataPath);
                        tmrLog.Enabled = true;
                        Create_FileName(Global.EngNo);

                        Btn21.Enabled = false;
                        Btn22.Enabled = true;
                        Btn23.Enabled = true;
                        Btn24.Enabled = true;
                        Btn25.Enabled = true;
                        Btn26.Enabled = true;
                        mnuRunStatus.Enabled = true;
                        Global.flg_EngStart = true;
                        Global.flg_CylStart = true;
                        Global.flg_CycleStarted = true;
                        //MessageBox.Show("Engine Started Successfully", "Dynalec Controls Pvt Ltd.",
                        //MessageBoxButtons.OK, MessageBoxIcon.Information);
                       // AddListItem("Engine Started .......", "Normal");
                        Global.Create_OnLog("Engine Started Successfully .....", "Normal");
                        Global.Create_OnLog(Global.Prj[0], "Normal");
                        Global.Create_OnLog(Global.Prj[1], "Normal");
                        Global.Create_OnLog(Global.Prj[2], "Normal");
                        Global.Create_OnLog(Global.StpLimFl, "Normal");
                        tmrInst.Enabled = true;
                        //frmPar.btnStart.Enabled = true;
                        //frmPar.btnStop.Enabled = true;
                    }
                    else
                    {
                        Tss1.Text = "Wait For Engine Running signal ......";
                    a: DialogResult result1 = MessageBox.Show("Wait For Engine Running signal ......" + c, "Engine Message", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                        if (result1 == DialogResult.Yes)
                        {
                            if (Global.varRPM >= (Global.S_Rpm - 20)) //Convert.ToInt16(Global.Prj[12]))
                            {
                                Create_FileName(Global.EngNo);
                                Tss2.Text = clsFun.cummbuff;
                                Global.flg_CycleStarted = true;
                                Tss1.Text = "Engine Started ......";
                                Tss1.BackColor = Color.Red;
                                Tss1.ForeColor = Color.Yellow;
                                Thread.Sleep(500);
                                Tss1.Text = "Engine Is Running ......";
                                //st.Start();
                                Tss1.BackColor = Color.Red;
                                Tss1.ForeColor = Color.Yellow;
                                AddListItem("Engine Is Running ......", "Normal");
                                Global.Create_OnLog("Engine Started ..... ", "Normal");
                                tmrInst.Enabled = true;
                                AddListItem(Global.Prj[0], "Normal");
                                AddListItem(Global.Prj[1], "Normal");
                                AddListItem(Global.Prj[2], "Normal");
                                AddListItem(Global.StpLimFl, "Normal");
                                flg_AnaOut = true;
                                flg_ProgOut = true;
                                Global.Make_mdb(Global.DataPath);
                                //Create_FileName(Global.EngNo);
                                tmrWrite.Start();
                                tmrLog.Start();
                                Btn21.Enabled = false;
                                Btn22.Enabled = true;
                                Btn23.Enabled = true;
                                Btn24.Enabled = true;
                                Btn25.Enabled = true;
                                Btn26.Enabled = true;
                                //frmPar.btnStart.Enabled = true;
                                //frmPar.btnStop.Enabled = true;

                                mnuRunStatus.Enabled = true;
                                Global.flg_EngStart = true;
                                Global.flg_CylStart = true;
                                //Btn21.Enabled = false;
                                //mnuLogData.Enabled = true;
                                //mnuRunStatus.Enabled = true;
                                ////Btn21.Enabled = false;                               
                                //Btn22.Enabled = true;
                                //Global.flg_EngStart = true;


                            }
                            else
                            {
                                c += 1;
                                Thread.Sleep(3000);
                                if (c >= 3)
                                {
                                    Btn21.Enabled = true;
                                    Btn22.Enabled = false;
                                    Btn23.Enabled = false;
                                    Btn24.Enabled = false;
                                    Btn25.Enabled = false;
                                    Btn26.Enabled = false;

                                    mnuRunStatus.Enabled = false;
                                    Tss1.Text = "Engine Not Started ......";
                                    //frmPar.btnStart.Enabled = false;
                                    Tss1.BackColor = Color.Gainsboro;
                                    MessageBox.Show("Engine not Started . Try Again..", "Dynalec Controls Pvt Ltd.",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //MessageBox.Show("Engine Not Started. Try Again ......");
                                    return;

                                    Tss1.Text = "Engine Not Started ......";
                                    Tss1.BackColor = Color.Gainsboro;
                                    MessageBox.Show("Engine not Started . Try Again..", "Dynalec Controls Pvt Ltd.",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //MessageBox.Show("Engine Not Started. Try Again ......");
                                    return;
                                }
                                else
                                {
                                    Tss1.Text = "Wait For Engine Start....";
                                    Thread.Sleep(500);
                                    Eng_Start_DelaySc(3);
                                    goto a;
                                }
                            }
                        }
                        else
                        {
                            Btn21.Enabled = true;
                            Btn22.Enabled = false;
                            Btn23.Enabled = false;
                            Btn24.Enabled = false;
                            Btn25.Enabled = false;
                            Btn26.Enabled = false;

                            mnuRunStatus.Enabled = false;
                            //MessageBox.Show("Engine not Started . Try Again..", "Dynalec Control Pvt Ltd.",
                            //MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Tss1.Text = "Engine Not Started ......";
                            Tss1.BackColor = Color.Gainsboro;
                            MessageBox.Show("Engine not Started . Try Again..", "Dynalec Controls Pvt Ltd.",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                           // MessageBox.Show("Engine Not Started. Try Again ......");
                            //frmPar.btnStart.Enabled = false;
                            //frmPar.btnStop.Enabled = false;

                        }
                    }
                }
                else if (Global.varRPM >= (Global.S_Rpm - 20)) //Convert.ToInt16(Global.Prj[12])))// && (Global.DigIn[6] == 0))
                {
                    Create_FileName(Global.EngNo);
                    Tss2.Text = clsFun.cummbuff;
                    Tss1.Text = "Engine Started ......";
                    Tss1.BackColor = Color.Red;
                    Tss1.ForeColor = Color.Yellow;
                    Global.flg_CycleStarted = true;
                    Thread.Sleep(500);
                    Tss1.Text = "Engine Is Running ......";
                    //st.Start();
                    Tss1.BackColor = Color.Red;
                    Tss1.ForeColor = Color.Yellow;
                    //AddListItem("Engine Is Running ......", 5);
                    //MessageBox.Show("Engine Started", "Dynalec Controls Pvt Ltd.",
                    //MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //AddListItem("Engine Started ..... ", "Normal");
                    AddListItem(Global.Prj[0], "Normal");
                    AddListItem(Global.Prj[1], "Normal");
                    AddListItem(Global.Prj[2], "Normal");
                    AddListItem(Global.StpLimFl, "Normal");
                    tmrInst.Enabled = true;
                    flg_AnaOut = true;
                    flg_ProgOut = true;
                    Global.Make_mdb(Global.DataPath);
                    tmrWrite.Start();
                    tmrLog.Start();
                    Btn25.Enabled = true;
                    mnuRunStatus.Enabled = true;
                    //Create_FileName(Global.EngNo);
                    Btn21.Enabled = false;
                    Btn22.Enabled = true;
                    Btn23.Enabled = true;
                    Btn24.Enabled = true;
                    Btn25.Enabled = true;
                    Btn26.Enabled = true;
                    mnuRunStatus.Enabled = true;

                    Global.flg_EngStart = true;
                    Global.flg_CylStart = true;
                }
                else if (Global.varRPM < (Global.S_Rpm - 20)) //Convert.ToInt16(Global.Prj[12])))  // && (Global.DigIn[6] == 0))
                {
                    Btn21.Enabled = true;
                    Btn22.Enabled = false;
                    Btn23.Enabled = false;
                    Btn24.Enabled = false;
                    Btn25.Enabled = false;
                    Btn26.Enabled = false;

                    mnuRunStatus.Enabled = false;
                    Tss1.Text = "Engine Not Started ......";
                    Tss1.BackColor = Color.Gainsboro;
                    MessageBox.Show("Engine is not Ready", "Dynalec Controls Pvt Ltd.",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // MessageBox.Show("Engine is Not ready.");

                }
                Global.CStrtTm = DateTime.Now.ToString("HH:mm:ss");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Engine Start Issue", "Alert",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
               // AddListItem("Engine Start Problem  .....", "Alart");
            }
        }


        private void mnuLogIn_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.ShowDialog(this);
            frm.Dispose();

        }
        private void mnuLogData_Click(object sender, EventArgs e)
        {
            LogData(); 
        }
       
        private void mnuSystem_Click(object sender, EventArgs e)
        {
            //    frmSysP frm = new frmSysP();
            //    frm.ShowDialog(this);
            //    frm.Dispose();
        }

        private void mnuEditor_Click(object sender, EventArgs e)
        {
            p.StartInfo = new ProcessStartInfo(Global.PATH + "Editor.exe");
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
        }

        private void mnuProject_Click(object sender, EventArgs e)
        {
            frmProject frm = new frmProject();
            frm.ShowDialog(this);
            frm.Dispose();
        }

        private void mnuShowValues_Click(object sender, EventArgs e)
        {
            frmInOut frm = new frmInOut();
            frm.ShowDialog(this);
        }

       
        private void mnuGraph_Click(object sender, EventArgs e)
        {
            if (Global.flg_CycleStarted == true)
            {
                OnLineGraph frm = new OnLineGraph();
                frm.ShowDialog(this);
                frm.Dispose();
            }
            else
            {
                MessageBox.Show("Please Start the Cycle First", "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //MessageBox.Show("Please Start the Cycle First ........", "DCPL");
                return;               
            }
        }

        private void mnuReset_Click(object sender, EventArgs e)
        {
            ResetOutPut();
            EngDialog frm = new EngDialog(this);
            frm.ShowDialog(this);
            frm.Dispose(); 
        }

      
#region read sfc
        //public void Read_SFC()
        //{
        //    try
        //    {
                
        //        switch (Global.SFC_Msg_from_Inst)
        //        {
        //            case "*02X44":

        //                if (Global.SFC_msg == "SFC ON")
        //                {
        //                    Global.SFC_msg = "SFC OVER";
        //                    tmrSFC.Enabled = false;
        //                    AddListItem("SFC OVER.....", "Normal");

        //                   Thread.Sleep(500);
        //                    Calculate_SFC();
        //                    LogData();
        //                    Update_Tss1(0);
        //                    Global.flg_SFCStart = false;
        //                    Tss1.BackColor = Color.Silver;
        //                    Tss1.ForeColor = Color.Black;  
        //                    Global.flg_SFC = false;
        //                }
        //                break;

        //            case "*02X22": //   "_RESET": //   '"_RESET"                        
        //                Global.SFC_msg = "SFC RESET";                       
        //                Update_Tss1(0);
        //                Tss1.BackColor = Color.Red;
        //                Tss1.ForeColor = Color.Yellow;
        //                Global.flg_SFC = true;
        //                Global.flg_SFCStart = true;
        //                //Global.Auto_SFC = false;
        //                //AddListItem("SFC RESET.....", "Normal");

        //                break;
        //            case "*02X33": //   "SFC_ON": //  '"SFC_ON"
        //                if (Global.SFC_msg != "SFC ON")
        //                {
        //                    AddListItem(" SFC ON ...... ", "Normal");
        //                    //tmrAvg.Start();
        //                    Tss9.Text = "Averaging Started.....";
        //                    Global.SFC_msg = "SFC ON";
        //                    Global.flg_SFC = true;
        //                    Tss1.BackColor = Color.Red;
        //                    Tss1.ForeColor = Color.Yellow;
        //                }
        //                tmrSFC.Enabled = true;
        //                break;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        AddListItem("PROBLEM IN SFC REDAING.....", "Alart");
        //    }
        //}

        public void Read_SFC()
        {
            //Update_Tss1(1);
            try
            {
                Global.SFC_Msg_from_Inst = "*02X44";
                switch (Global.GenData[2])
                {

                    case "44444":

                        if (Global.SFC_msg == "SFC ON")
                        {
                            Global.SFC_msg = "SFC OVER";
                            tmrSFC.Enabled = false;
                            AddListItem(" SFC OVER ...... ", "Normal");  //AddListItem("SFC OVER", 5);
                            Thread.Sleep(500);
                            Calculate_SFC();
                            //MakeAVGData();
                            LogData();
                            //Update_Tss1(0);
                            Global.flg_SFC = false;
                        }
                        break;

                    case "22222":    //"*02X22": //   '"_RESET"                       
                        Global.SFC_msg = "SFC RESET";
                        //Update_Tss1(1);
                        //Update_Tss1(0);
                        Global.flg_SFC = true;
                        Global.SFC_Reset = false;

                        break;
                    case "33333":    //"*02X33": //  '"SFC_ON"
                        if (Global.SFC_msg != "SFC ON")
                        {
                            AddListItem(" SFC ON ...... ", "Normal");  //AddListItem(" SFC ON ", 3);
                            Global.SFC_msg = "SFC ON";
                            Global.flg_SFC = true;
                            tmrSFC.Enabled = true;
                        }

                        break;
                }

            }
            catch (Exception ex)
            {
                AddListItem("PROBLEM IN SFC REDAING.....", "Alert"); // Global.Create_OnLog("Read_SFC Errer ...." + ex.Message);
            }

        }    


        public void Calculate_SFC()
        {
            try
            {                
                int r;               
                int N;

               Global.SGrv = "0.835";
               if(Global.E_Pow <= 1) Global.E_Pow  = 1;
               N = int.Parse(Global.NCyl);
               if (N <= 0) N = 3;
               r = int.Parse(Global.varRPM.ToString ());

               Global.SFCwt = 50; // double.Parse(Global.GenData[103]);

               Global.SFCTm = double.Parse(Global.GenData[4]); 
               
                Global.SFCValkW = clsFun.Cal_SFC_G(Global.VarPowkW, Global.SFCwt, Global.SFCTm);
                Global.SFCValPs = clsFun.Cal_SFC_G(Global.VarPowHp, Global.SFCwt, Global.SFCTm);

                Global.fl_Rate = clsFun.Flow_Rate(Global.SFCwt, Global.SFCTm);
                Global.Bi_Val = clsFun.Fuel_Del(Global.SFCwt, Global.SFCTm,r,N);
             
                Double P1 = Global.Atp;
                Double D1 = Global.Drb; 
                Double W1 = Global.Web;
                Double S1 = Convert.ToDouble(Global.Svol);


                if (Global.Prj[4] == "IS_1585_NA")
                    Global.Corfact = clsFun.CF_ISO_1585_NA(P1, W1, D1, Global.Bi_Val, S1);
                else if (Global.Prj[4] == "IS_1585_TC")
                    Global.Corfact = clsFun.CF_ISO_1585_NA(P1, W1, D1, Global.Bi_Val, S1);
                else if (Global.Prj[4] == "IS_14599_NA")
                    Global.Corfact = clsFun.IS_14599_NA(P1, W1, D1, Global.Bi_Val, S1);
                else if (Global.Prj[4] == "IS_14599_TC")
                    Global.Corfact = clsFun.IS_14599_NA(P1, W1, D1, Global.Bi_Val, S1);
                else if (Global.Prj[4] == "CF_DIN")
                    Global.Corfact = clsFun.CF_DIN_70020(D1, P1);
                else if (Global.Prj[4] == "CF_IS_10003")
                    Global.Corfact = clsFun.CF_IS_10000CS(Global.Rel_Hum, D1, P1);
                else
                    Global.Corfact = clsFun.CF_DIN_70020(D1, P1);

               
                Global.C_SFCValkW = Global.SFCValkW / Global.Corfact;
                Global.C_SFCValPs  = Global.SFCValPs / Global.Corfact;

                Global.GenData[101] = "0.01";
                Global.GenData[102] = Global.GenData[46];
                Global.GenData[103] = Global.SFCwt.ToString("000");
                Global.GenData[104] = Global.SFCTm.ToString("000.0"); ;
                Global.GenData[105] = Global.Corfact.ToString("0.0000"); 
                Global.GenData[108] = Global.SFCValkW.ToString("00.0"); 
                Global.GenData[109] = Global.Bi_Val.ToString("00.0"); ;
                Global.GenData[112] = Global.C_SFCValkW.ToString("00.0"); 
                Global.GenData[113] = Global.fl_Rate.ToString("00.00"); 
                Global.GenData[117] = Global.SFCValPs.ToString("00.0"); 
                Global.GenData[118] = Global.C_SFCValPs.ToString("00.0");
 
                //***********************
               
              
               
               

                
              


                //****************************


               
                //Global.SFC_msg = "SFC Status .....";
                flg_ProgOut = true;
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: Cal_SFC() : ", "Alert");
                return;
                //Global.Create_OnLog(ex.Message,false);
            }
        }





#endregion

      
        //private void Tss6_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Global.AnaOut1 >= 9.999) Global.AnaOut1 = 9.999;
               
        //            Automation.BDaq.ErrorCode err;
        //            dataScaled[0] = Global.AnaOut1;
        //            err = Global.InstantAO.Write(0, 1, dataScaled);
               
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error in Tss6 :" + ex.Message);
        //    }
        //}

        //private void Tss7_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Global.AnaOut2 >= 9.999) Global.AnaOut2 = 9.999;
               
        //            Automation.BDaq.ErrorCode err;
        //            dataScaled[1] = Global.AnaOut2;
        //            err = Global.InstantAO.Write(0, 2, dataScaled);
                
        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error in Tss7 :" + ex.Message);
        //    }
        //} 
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Process[] prs = Process.GetProcesses();
            //foreach (Process pr in prs)
            //    if (pr.ProcessName == "Mod_PID") pr.Kill();

            //Thread.Sleep(1000);
            //p.StartInfo = new ProcessStartInfo(Global.PATH + "Mod_PID.exe");
            //p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            //p.Start();
            
            
            
            Global.Read_ModbusValues();
            //Show_Dialog();
            //Global.PIDPort.DiscardOutBuffer(); 

         //   Tss6.Text = String.Format("{0:0.000}", Global.AnaOut1);
           // Tss7.Text = String.Format("{0:0.000}", Global.AnaOut2);

            //if (Global.PIDPort.IsOpen == true) Global.PIDPort.Write(OutBuffer);

            //Global.flg_SFC = false;
            //Global.SFC_Reset = true;
            //Global.flg_SFCStart = true;
            //Global.flg_DataSave = true;        

            //if ((Global.flg_SFCStart == true) && (Global.DigIn[0] == 1)) 
            //{
            //    Global.SFC_msg = "SFC ON";
            //    //AddListItem("SFC ON ......", "Normal"); 
            //    Global.flg_SFCON = true;
            //}
            //else if ((Global.flg_SFCStart == true) && (Global.DigIn[0] == 0) && (Global.flg_SFCON == true))
            //{
            //    Global.SFC_msg = "SFC OVER";
               
            //    Global.flg_SFCON = false;
            //    AddListItem("SFC OVER.....", "Normal");
            //    Global.SFCTm = Convert.ToDouble(Global.GenData[3]);
            //    Global.SFCwt= Convert.ToDouble(Global.GenData[4]);
            //    Global.SFC_msg = "SFC OVER";
            //    Calculate_SFC();               
            //    LogData(); 
            //    Tss1.BackColor = Color.Silver;
            //    Tss1.ForeColor = Color.Black;
            //    Global.flg_SFC = false;
            //    Global.flg_SFCStart = false;
            //}
            //Global.Read_ADAMValues();
            //Tss5.Text = Global.bufftss8;


            //if (Global.Er_Serial == false)
            //{
            //    label4.Text = "Instrument Communication Failed .....";
            //}
            //else
            //{
            //    label4.Text = "Instrument Communication 'OK' .....";
            //}
           
            //if (Global.Er_ADAM == false)
            //{
            //    label5.Text = "ADAM Communication Failed .....";
            //}
            //else
            //{
            //    label5.Text = "ADAM Communication 'OK' .....";
            //}

            //if (Global.Er_Gantner == false)
            //{
            //    label5.Text = "Gantner Communication Failed .....";
            //}
            //else
            //{
            //    label5.Text = "Gantner Communication 'OK' .....";
            //}


          

        }  
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetOutPut();
            EngDialog frm= new EngDialog(this);
            frm.ShowDialog(this);
            frm.Dispose(); 
        }                

        private void mnuLimEngFile_Click(object sender, EventArgs e)
        {
            if (Global.flg_CycleStarted == true)
            {
                frmLEfiles frm = new frmLEfiles();
                frm.ShowDialog(this);
                frm.Dispose();
            }
            else
            {
                MessageBox.Show("Please Start the Cycle First", "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //MessageBox.Show("Please Start the Cycle First ........", "DCPL");
                return;
            }
        }

        private void tmrAvg_Tick(object sender, EventArgs e)
        {
            LogAVGData();
        }
        private void LogAVGData()
        {
            try
            {
                int i = 0;
                String strData = null;
                for (i = 0; i <= 50 ; i++)
                {
                    Global.Data[i] = Global.GenData[i];
                    if (Global.Data[i] == null) Global.Data[i] = "0.0";
                    strData = strData + Global.Data[i] + "', '";
                }
                strData = strData + Global.Data[i];
                strData = strData.Substring(0, strData.Length - 4);
                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "INSERT INTO gen_db.avgtemp VALUES ('" + strData + "'" + ")";
                cmd.Connection = Global.con;
                cmd.ExecuteNonQuery();
                Global.con.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error in Log Avg" + ex.Message, "Alert",
                //MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Global.Create_OnLog("Error in Log Avg.....", "Alert");
                return;
            }
        }



        private void GridSeq_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (DataGridViewColumn colm in GridSeq1.Columns)
            {
                colm.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            int Lst = Global.StpN; 

            if (Btn24.Text == "Cycle_Resume")
            {
                Hold_Cycle(true);
            }
            Global.flg_IdleLim = true;
            int Ast = GridSeq1.CurrentRow.Index + 1;
            if ((Ast <= -1) || (Ast >= GridSeq1.RowCount)) //  || (Ast == Lst))
            {
                MessageBox.Show("Invalid Selection of Step", "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
               // MessageBox.Show("Invalid Selection of Step......");
                return;
            }
            else
            {
                if (MessageBox.Show("Do you Want to Select Step No." + Ast , "Dynalec Controls Pvt Ltd.",MessageBoxButtons.OKCancel, MessageBoxIcon.Question)== DialogResult.OK)
                    //MessageBox.Show("Do you Want to Select Step No. " + (Ast) + " ...?", "Step Change", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    PBar3.Caption = "RAMP TIME:";
                    Global.LastAna1 = Double.Parse(Global.SetPtOut1);
                    Global.LastAna2 = Double.Parse(Global.SetPtOut2);
                    if (tmrAvg.Enabled == true)
                    {
                        //tmrAvg.Stop();
                        //Tss9.Text = "Avg inturrupted ";
                        //Global.Open_Connection("gen_db", "con");
                        //MySqlCommand cmd = new MySqlCommand ("DELETE * FROM AVGTemp", Global.con);
                        //cmd.ExecuteNonQuery();
                        //Global.con.Close();
                    }
                    Global.Create_OnLog("Manually Step Changed : " + Ast, "  Alert"); 
                    //MessageBox.Show("Manually Step Changed" + Ast, "Dynalec Control Pvt Ltd.",
                    //MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Global.StpN = Ast - 1;
                    Load_ProgStep();
                    Hold_Cycle(false);
                }
            }
            //int Lst = Global.StpN;

            //if (Btn24.Text == "Cycle_Resume")
            //{
            //    Hold_Cycle(true);
            //}
            //int Ast = GridSeq.CurrentRow.Index;
            //if ((Ast <= -1) || (Ast >= GridSeq.RowCount) || (Ast == Lst))
            //{
            //    MessageBox.Show("Invalid Selection of Step......");
            //    return;
            //}
            //else
            //{
            //    if (MessageBox.Show("Do you Want to Select Step No. " + (Ast) + " ...?", "Step Change", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //    {
            //        //lblStatus.Text = "RAMP TIME:";
            //        PBar3.Caption = "RAMP TIME:";
            //        //GridSeq.Enabled = false;
            //        Global.LastAna1 = Double.Parse(Global.SetPtOut1);
            //        Global.LastAna2 = Double.Parse(Global.SetPtOut2);
            //        Global.StpN = Ast;
            //        Load_ProgStep();
            //        Hold_Cycle(false);
            //    }
            //}

        }

        private void BtnSA_Click(object sender, EventArgs e)
        {
            panel6.BringToFront();
            panel6.Visible = true;           
            //radioButton1.BringToFront();
            //radioButton2.BringToFront();
            //radioButton3.BringToFront();
            //radioButton4.BringToFront();  
            comboBox2.SelectedIndex = 0;
            Global.flg_Auto = false;
            Global.Make_mdb(Global.DataPath);

            Create_FileName(Global.EngNo);
            Global.Sn = 0;
            //checkBox13.Text = Global.EngNo;
            //checkBox15.Text = Global.Eng_FileNm;
            checkBox8.Text = Global.PrjNm;
            checkBox1.Text = Global.Eng_FileNm;
            LoadDgView();
           
        }

        private void Btn26_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.flg_CycleStarted == true)
                {
                    Global.flg_SFC = false;
                    Global.SFC_Reset = true;
                    Global.flg_SFCStart = true;
                    Global.Auto_SFC = false;
                }
                else
                {
                    MessageBox.Show("Please Start the Cycle First", "Dynalec Controls Pvt Ltd.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                   // MessageBox.Show("Please Start the Cycle First ........", "DCPL");
                    return;                            
                }
            }
            catch (Exception ex)
            {
                 MessageBox.Show("Error in frmMain: Btn13_Click():" + ex.Message, "Dynalec Controls Pvt Ltd.",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
               // MessageBox.Show("Error in frmMain: Btn13_Click():  " + ex.Message);
            }
        }

        private void Btn25_Click(object sender, EventArgs e)
        {
            if (Global.flg_CycleStarted == true)
            {
                LogData();
                Update_ViewData();
            }
            else
            {
                MessageBox.Show("Please Start the Cycle First", "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
               // MessageBox.Show("Please Start the Cycle First ........", "DCPL");
                return;
            }          
          
        }

     
        private void panel6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                MouseDownLocation = e.Location;
        }

        private void panel6_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                panel6.Left = e.X + panel6.Left - MouseDownLocation.X;
                panel6.Top = e.Y + panel6.Top - MouseDownLocation.Y;
            }
        }

        private void valueout()
        {
            double T = 0;
            double D = 0;
            Global.LastRPM = ((Convert.ToDouble(Global.varRPM) * 10) / Convert.ToDouble(Global.sysIn[5]));
            Global.LastTrq = ((Convert.ToDouble(Global.varTRQ) * 10) / Convert.ToDouble(Global.sysIn[4]));

            Global.LastAna1 = double.Parse(Global.SetPtOut1);
            Global.LastAna2 = double.Parse(Global.SetPtOut2);
            Global.C_Mode = MSt;
            switch (Global.C_Mode) 
            {
                case "6":
                    T = Double.Parse(textBox6.Text);
                    Global.SetPtOut1 = ((T * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                    D = Double.Parse(textBox5.Text);
                    Global.SetPtOut2 = ((D * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                    break;
                case "5":
                    T = Double.Parse(textBox6.Text);
                    Global.SetPtOut1 = ((T * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                    D = Double.Parse(textBox5.Text);
                    Global.SetPtOut2 = (D / 10).ToString();
                    break;
                case "4":
                    T = Double.Parse(textBox6.Text);
                    Global.SetPtOut1 = ((T * 10) / (Convert.ToDouble(Global.sysIn[5]))).ToString();
                    D = Double.Parse(textBox5.Text);
                    Global.SetPtOut2 = ((D * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                    break;
                case "3":                   
                    T = Double.Parse(textBox6.Text);                   
                    Global.SetPtOut1 = (T / 10).ToString();
                    D = Double.Parse(textBox5.Text);
                    Global.SetPtOut2 = ((D * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                    break;
                   
                case "2":
                    T = double.Parse(textBox6.Text);
                    Global.SetPtOut1 = (T / 10).ToString();
                    D = Double.Parse(textBox5.Text);
                    Global.SetPtOut2 = ((D * 10) / (Convert.ToDouble(Global.sysIn[4]))).ToString();
                    break;
                default:                   
                    Global.Mode_Out(1, 0, 0);
                    T = double.Parse(textBox6.Text);
                    Global.SetPtOut1 = (T / 10).ToString();
                    D = double.Parse(textBox5.Text);
                    Global.SetPtOut2 = (D / 10).ToString();
                    break;
            }


            //***********************
            Global.SetRPM = textBox6.Text;
            Global.SetTRQ = textBox5.Text;

            //*********************
            RMP1 = int.Parse(textBox9.Text) * 9;
            RMP2 = int.Parse(textBox8.Text) * 9;
            if (RMP1 <= 1) RMP1 = 1;
            if (RMP2 <= 1) RMP2 = 1;
            if (RMP1 >= RMP2) RMP = RMP1; else RMP = RMP2;
            Global.LastT = Convert.ToDouble(T);
            Global.LastD = Convert.ToDouble(D);         

            Global.Diff1 = (Double.Parse(Global.SetPtOut1) - (Global.LastAna1)) / RMP1;
            Global.Diff2 = (Double.Parse(Global.SetPtOut2) - (Global.LastAna2)) / RMP2;
            //PBar1.Maximum = 10000;
            PBar2.Maximum = 10000;
            if ((int.Parse(Global.L_Mode) == 1) && (int.Parse(Global.C_Mode) >= 5))
            {
                Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                RMP1 = 1;
            }
          
            if ((int.Parse(Global.L_Mode) == 6) && (int.Parse(Global.C_Mode) >= 5))
            {
                Global.AnaOut2 = 10; // Double.Parse(Global.SetPtOut1);
                RMP2 = 0.1;
            }
        
            flg_M_Ramp = true;
            tmrAnaOut.Start();


        }
        
       

        private void btnDemand1_Click(object sender, EventArgs e)
        {
            valueout();
            Btn27.Enabled = true;
            btnMclose.Enabled = true;  
            Double x = Double.Parse(textBox6.Text);
            Double y = Double.Parse(textBox5.Text);

            tmrLog.Start();
            timer1.Start();
          
            Btn21.Enabled = false;
            Btn22.Enabled = true;
            Btn23.Enabled = true;
            Btn24.Enabled = true;
            Btn25.Enabled = true;
            Btn26.Enabled = true;
            mnuRunStatus.Enabled = true;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                Double x = Double.Parse(textBox6.Text);
                Double y = Double.Parse(textBox5.Text);
                MSt = comboBox2.Text.Substring(0, 1);

                switch (MSt)
                {
                    case "1":
                        label13.Text = "%";
                        label12.Text = "%";
                        textBox6.Text = x.ToString("00.00");
                        textBox5.Text = y.ToString("00.00");
                        break;
                    case "2":
                        label13.Text = "R";
                        label12.Text = "%";
                        textBox6.Text = x.ToString("0000");
                        textBox5.Text = y.ToString("00.00");
                        break;
                    case "3":
                        label13.Text = "%";
                        label12.Text = "T";
                        textBox6.Text = x.ToString("00.00");
                        textBox5.Text = y.ToString("000.0");
                        break;
                    case "4":
                        label13.Text = "R";
                        label12.Text = "T";
                        textBox6.Text = x.ToString("0000");
                        textBox5.Text = y.ToString("000.0");
                        break;
                    case "5":
                        label13.Text = "R";
                        label12.Text = "%";
                        textBox6.Text = x.ToString("0000");
                        textBox5.Text = y.ToString("00.00");
                        break;
                    case "6":
                        label13.Text = "R";
                        label12.Text = "T";
                        textBox6.Text = x.ToString("0000");
                        textBox5.Text = y.ToString("000.0");
                        break;
                }
                //Global.C_Mode = MSt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tmrAnaOut_Tick(object sender, EventArgs e)
        {
            if (flg_M_Ramp == true)
            {
               
                if (RMP1 <= 0)
                {
                    RMP1 = 0;
                    label33.Text = "sec";
                }
                else
                {
                    RMP1 -= 1;
                    label33.Text = RMP1.ToString();
                }
                if (RMP2 <= 0)
                {
                    RMP2 = 0;
                    label32.Text = "sec";
                }
                else
                {
                    RMP2 -= 1;
                    label32.Text = RMP2.ToString();
                }
                if (RMP <= 0)
                {
                    RMP = 0;
                    //tss2.Text = "00";
                    Global.L_Mode = Global.C_Mode;
                    flg_M_Ramp = false;
                    Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                    Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                }
                else
                {
                RMP -= 1;
                btnInd.BackColor = Color.Red;
                btnInd.Text = "Ramp-State  :" + RMP.ToString();
                if (Global.flg_Semi_Auto == true) clsFun.MODE_TO_MODE(); // .MODE_TO_MODE_STANDARD(); // MODE_TO_MODE_Smooth();
                }
            }
            else
            {
                flg_M_Ramp = false;
                btnInd.BackColor = Color.Green;
                btnInd.Text = "Steady-State";
                switch (int.Parse(Global.C_Mode))
                {
                    case 1:
                        Global.Mode_Out(1, 0, 0);
                        break;
                    case 2:
                        Global.Mode_Out(0, 1, 0);
                        break;
                    case 3:
                        Global.Mode_Out(1, 1, 0 );
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

                switch (Global.C_Mode)
                {
                    case "2":
                    case "4":
                    case "5":
                    case "6":
                        if (Global.RcrOn == "TRUE")
                        {
                            int rDiff = (Convert.ToInt32(Convert.ToDouble(Global.SetPtOut1) * (Convert.ToDouble(Global.sysIn[5]) / 10)) - Convert.ToInt32(Global.varRPM));

                            if ((rDiff <= 60) && (rDiff >= 4))
                            {
                                Global.AnaOut1 = Global.AnaOut1 + 0.0002;
                            }
                            else if ((rDiff >= -60) && (rDiff <= -4))
                            {
                                Global.AnaOut1 = Global.AnaOut1 - 0.0002;
                            }
                        }
                        break;
                }
            }
                            //C_Hours = Int16.Parse(Tss2.Text.Substring(0, 4));
                            //C_Minutes = Int16.Parse(Tss2.Text.Substring(5, 2));
                            //C_Seconds = Int16.Parse(Tss2.Text.Substring(8, 2));
                            //clsFun.TmCounter(C_Hours, C_Minutes, C_Seconds, true);
                            //Tss2.Text = clsFun.cummbuff;  
                            //textBox4.Text = clsFun.cummbuff; 
        }
       
  

        private void mnuSimulate_Click(object sender, EventArgs e)
        {
            frmSimulation frm = new frmSimulation();
            frm.ShowDialog();
            frm.Dispose(); 

        }

        private void btrIdle_Click(object sender, EventArgs e)
        {
            tmrIdel.Start();
        }
       
       
        private void mnuClose_Click(object sender, EventArgs e)
        {
           
                Process[] prs = Process.GetProcesses();
                foreach (Process pr in prs)
                {
                    if (pr.ProcessName == "Editors") pr.Kill();
                    if (pr.ProcessName == "EXCEL") pr.Kill();
                    if (pr.ProcessName == "Read_ECUVal") pr.Kill();
                    if (pr.ProcessName == "Main_EDAC") pr.Kill();
                }              
                AddListItem("Fast Logging Stopped.....", "Normal");           
                this.Close();
           
        }

        private void mnusyspara_Click(object sender, EventArgs e)
        {
           // frmSysPara frm = new frmSysPara();
           // frm.ShowDialog(this);
           // frm.Dispose();
        }

        private void mnuChannel_Click(object sender, EventArgs e)
        {
            frmConf frm = new frmConf();
            frm.ShowDialog(this);
            frm.Dispose();
        }

        private void mnuComports_Click(object sender, EventArgs e)
        {
            try
            {
                p.StartInfo = new ProcessStartInfo(Global.PATH + "ConfigurationManager.exe");
                p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                p.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + '\n' + ex.Message , "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		private void Btn27_Click(object sender, EventArgs e)
		{
			IdleEng();
			AddListItem("Engine Stop By Operator .....", "Normal");
		}

		
		private void mnuShowData1_Click(object sender, EventArgs e)
		{
            if (Global.flg_CycleStarted == true)
            {
                frmRStatus frm = new frmRStatus();
                frm.ShowDialog(this);
                frm.Dispose();
            }
            else
            {
                MessageBox.Show("Please Start the Cycle First", "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
		}    
        private void mnuShowDataFiles_Click(object sender, EventArgs e)
        {
            Process[] prs = Process.GetProcesses();
            foreach (Process pr in prs)
            {
                if (pr.ProcessName == "DataManagement") pr.Kill();
                if (pr.ProcessName == "EXCEL") pr.Kill();
            }
            p.StartInfo = new ProcessStartInfo(Global.PATH + "DataManagement.exe");
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.Start(); 
        }           
        private void btnMclose_Click(object sender, EventArgs e)
        {
            IdleEng();  
            stopEngine();
            panel6.Visible = false;
            panel6.SendToBack();
        }
        private void btnMidle_Click(object sender, EventArgs e)
        {
            IdleEng(); 
        }

        private void btnDemand_Click(object sender, EventArgs e)
        {
            valueout();
            M_Cmt = 0;

            Btn21.Enabled = false;
            Btn22.Enabled = true;
            Btn23.Enabled = true;
            Btn24.Enabled = true;
            Btn25.Enabled = true;
            Btn26.Enabled = true;
            //mnuRunData.Enabled = true;
            Global.flg_CycleStarted = true;

            Double x = Double.Parse(textBox6.Text);
            Double y = Double.Parse(textBox5.Text);
            tmrLog.Start();
            timer1.Start();
            btnMclose.Enabled = true;
            SS2.Text = "0000:00:00";

        }
        private void MlogTm_Leave(object sender, EventArgs e)
        {
            Double y = Double.Parse(MlogTm.Text);
            Global.LogTm = (int)y;
            Global.LTm = (int)y;
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.CheckState == CheckState.Checked)
            {
                Global.flg_LogM = true;
                MlogTm.Enabled = true;
                Double y = Double.Parse(MlogTm.Text);
                Global.LogTm = (int)y;
                Global.LTm = (int)y;
            }
            else
            {
                Global.flg_LogM = false;
                MlogTm.Enabled = false;
            }
            
        }      
        private void mnuRun_Status_Click(object sender, EventArgs e)
        {
            try
            {
                string ToDate = DateTime.Now.ToString("ddMMMyy");
                Global.DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\";
                string strFileName = Global.DataPath + "Log_Data\\OnLog_" + ToDate + ".txt";
                Process p = Process.Start("notepad.exe", strFileName);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error Code:- 12002", ex.Message);
                MessageBox.Show("Error Code:- 12002" + '\n' + ex.Message, "Status",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }

        }     
        private void Btn22_Click(object sender, EventArgs e)
        {
            try
            {
                if (tmrIdel.Enabled == true) tmrIdel.Enabled = false;
                Global.flg_fastlog = false;
                Global.flg_flog = false;
                //frmPar.btnStart.Enabled = true;
                //frmPar.btnStop.Enabled = true;
                if (flg_ChkAlarmON == true)
                {
                    AddListItem("Engine Stopped due to Alarm \n" +
                        "Check log error.....", "Normal");
                    Global.Dig_OutBit(0, 2, true); 
                }
                else
                    AddListItem("Engine Stop By Operator .....", "Normal");
                
                stopEngine();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Btn23_Click():" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
               // MessageBox.Show("Error in frmMain: Btn23_Click():  " + ex.Message);
            }
        }
        private void GridSeq_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void mnuE_Start_Click(object sender, EventArgs e)
        {
            if (Global.varRPM <= Global.S_Rpm)
            {
                Tss1.Text = "Wait For Running signal ......";
                Tss1.BackColor = Color.Red;
                Tss1.ForeColor = Color.Yellow;
                Btn21.Enabled = false;
                Btn22.Enabled = false;
                Btn23.Enabled = false;
                Btn24.Enabled = false;
                Btn25.Enabled = false;
                Btn26.Enabled = false;

                Global.Dig_OutBit(0, 7, true);  //Ingnition on
                Thread.Sleep(500);
                Global.Dig_OutBit(1, 0, true);  //Eng start Pulse
                Thread.Sleep(500);
                Global.Dig_OutBit(1, 0, false);//Eng start Pulse false                    

                Tss1.Text = "Start the Engine....";
            }
        }
        private void Btn23_Click(object sender, EventArgs e)
        {
            if (Global.flg_CycleStarted == true)
            {
                frmSmoke frm = new frmSmoke();
                frm.ShowDialog(this);
                frm.Dispose();
            }
            else
            {
                MessageBox.Show("Please Start the Cycle First", "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //MessageBox.Show("Please Start the Cycle First ........", "DCPL");
                //return;
            }          
        }

        private void Btn24_Click(object sender, EventArgs e)
        {
            Hold_Cycle(true);
            Auto_Hold = false;
        }

       
        private void tmrSmk_Tick(object sender, EventArgs e)
        {
            try
            {
                Global.S_Add++;
                Tss5.Text = Global.S_Add.ToString();
                if (Global.flg_smokeStart == true)
                {
                    if (Global.S_Add == 3)
                        Global.smkPort.Write(" SMES");
                    if (Global.S_Add >= 18)
                    {
                        Tss5.Text = "";
                        Global.smkPort.Write(" AFSN");
                        Thread.Sleep(200);
                        string buffer = (Global.smkPort.ReadExisting());
                        Global.smkbuffer = buffer;
                        Global.flg_smokeStart = false;
                        Global.GenData[101] = Global.smkbuffer.Substring((buffer.Length - 7), 6);
                        Global.SmkVal = Double.Parse(Global.GenData[101]);
                        Tss5.Text = Global.GenData[101];
                        Global.S_Add = 0;
                        tmrSmk.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + '\n' + ex.Message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

       
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Global.Er_Serial == false)
            {
                checkBox9.Text = "Instrument Communication Failed .....";
                checkBox9.BackColor = Color.Red;
                checkBox9.ForeColor = Color.Yellow; 
            }
            else
            {
                checkBox9.Text = "Instrument Communication 'OK' .....";
                checkBox9.BackColor = Color.Teal;
                checkBox9.ForeColor = Color.White;
            }

            if (RdAdam.Er_ADAM == false) 
            {
                checkBox10.Text = "ADAM Communication Failed .....";
                checkBox10.BackColor = Color.Red;
                checkBox10.ForeColor = Color.Yellow; 
            }
            else
            {
                checkBox10.Text = "ADAM Communication 'OK' .....";
                checkBox10.BackColor = Color.Teal;
                checkBox10.ForeColor = Color.White; 
            }

            if (Global.Er_Gantner == false)
            {
                checkBox12.Text = "ECU Communication OFF .....";
                checkBox12.BackColor = Color.Red;
                checkBox12.ForeColor = Color.Yellow; 
            }
            else
            {
                checkBox12.Text = "ECU Communication 'ON' .....";
                checkBox12.BackColor = Color.Teal;
                checkBox12.ForeColor = Color.White; 
            }
            //if (Global.Er_SmkMeter == false)
            //{
            //    label7.Text = "Smoke Meter Not Connected .....";                
            //    label7.BackColor = Color.Red;
            //    label7.ForeColor = Color.Yellow; 
            //}
            //else
            //{
            //    label7.Text = "Smoke Meter  Connected .....";
            //    label7.BackColor = Color.LightGray;
            //    label7.ForeColor = Color.Black; 
            //}
            Read_SFC(); 
        }       

        private void Tss11_Click(object sender, EventArgs e)
        {
           //DGView.SendToBack();  
           //flowLayoutPanel2.SendToBack();
           flowLayoutPanel1.BringToFront();
           Tss11.BackColor = Color.DarkGray;
           Tss12.BackColor = Color.LightGray; 
        }

        private void Tss12_Click(object sender, EventArgs e)
        {          
            //flowLayoutPanel2.BringToFront();
            //DGView.BringToFront();
            flowLayoutPanel1.SendToBack();
            Tss12.BackColor = Color.DarkGray;
            Tss11.BackColor = Color.LightGray; 
        }

        public void LoadDgView()
        {
            try
            {
                Global.Open_Connection("gen_db", "con");
                MySqlDataAdapter adp = new MySqlDataAdapter("Select * from tb_view Order By N", Global.con);
                DataSet ds = new DataSet();
                adp.Fill(ds);

                DGView.ColumnCount = 16;
                if (DGView.RowCount >= 5)
                    DGView.RowCount = Global.Sn + 2;
                else
                    DGView.RowCount = 5;
                DGView.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                DGView.Columns[0].Width = 60;
                DGView.Columns[0].Name = "Sn";
                DGView.Columns[1].Width = 150;
                DGView.Columns[1].Name = "LogTime";
                for (int i = 0; i <= 13; i++)
                {
                    DGView.Columns[i + 2].Width = 80;
                    ViewNo[i] = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    DGView.Columns[i + 2].Name = Global.PSName[int.Parse(ViewNo[i])] + "    " + Global.PUnit[int.Parse(ViewNo[i])];
                }

                DGView.Columns[15].Width = 200;
                //DGView.Rows[Global.Sn].Cells[0].Value = Global.Sn;
                //DGView.Rows[Global.Sn].Cells[1].Value = Global.GenData[122];

                for (int i = 0; i < 15; i++)
                {
                    DGView.Rows[Global.Sn].Cells[i + 2].Value = Global.Data[int.Parse(ViewNo[i])];
                }
                if (Global.Sn >= 5)
                {
                    DGView.RowCount += 1;
                    DGView.FirstDisplayedScrollingRowIndex = (Global.Sn - 5);
                }
                DGView.Rows[Global.Sn].Selected = true;

            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: DGView() : ", "Alert");
                return;//MessageBox.Show("Error Code:- 12002", ex.Message);
            }
        }
        // for Data Logging Color Change.....
        public void Update_ViewData()
        {
            int i = 0;
            ////DGView.RowCount += 1;
            //if (Global.Sn >= 10)
            //        {
            //            DGView.RowCount += 1;
            //            DGView.FirstDisplayedScrollingRowIndex = (Global.Sn - 9);
            //        }
            DGView[0, Global.Sn - 1].Value = Global.Sn;
            DGView[1, Global.Sn - 1].Value = System.DateTime.Now.ToString("hh:mm:ss  tt");


            for (i = 0; i <= 13; i++)
            {
                DGView[i + 2, Global.Sn - 1].Value = Global.Data[int.Parse(ViewNo[i])];
            }

            //        DGView.Rows[Global.Sn - 1].Selected = true;
            //            //Global.flg_UpdateViewData = false;

            //            if (flg_chkpass == true)
            //            {
            //                if ((Convert.ToDouble(DGView[2, Global.Sn - 1].Value) <= Convert.ToDouble(maxPassOfLim[0])) && (Convert.ToDouble(DGView[2, Global.Sn - 1].Value) >= Convert.ToDouble(minPassOfLim[0])))
            //                    {
            //                        //DGView[2, Global.Sn - 1].Style.BackColor = Color.Red;
            //                        DGView[2, Global.Sn - 1].Style.ForeColor = Color.Yellow;//avg trq
            //                    }
            //                    else
            //                    DGView[2, Global.Sn - 1].Style.ForeColor = Color.Red;


            //                if ((Convert.ToDouble(DGView[3, Global.Sn - 1].Value) <= Convert.ToDouble(maxPassOfLim[1])) && (Convert.ToDouble(DGView[3, Global.Sn - 1].Value) >= Convert.ToDouble((minPassOfLim[1]))))
            //                    {
            //                        DGView[3, Global.Sn - 1].Style.ForeColor = Color.Yellow;
            //                    }
            //                          else
            //                    DGView[3, Global.Sn - 1].Style.ForeColor = Color.Red;


            //                if ((Convert.ToDouble(DGView[15, Global.Sn - 1].Value) <= Convert.ToDouble(maxPassOfLim[2])) && (Convert.ToDouble(DGView[15, Global.Sn - 1].Value) >= Convert.ToDouble((minPassOfLim[2]))))
            //                {
            //                    DGView[15, Global.Sn - 1].Style.ForeColor = Color.Yellow;
            //                }
            //                 else
            //                    DGView[15, Global.Sn - 1].Style.ForeColor = Color.Red;

            //                if ((Convert.ToDouble(DGView[14, Global.Sn - 1].Value) <= Convert.ToDouble(maxPassOfLim[3])) && (Convert.ToDouble(DGView[14, Global.Sn - 1].Value) >= Convert.ToDouble((minPassOfLim[3]))))
            //                {
            //                    DGView[14, Global.Sn - 1].Style.ForeColor = Color.Yellow;
            //                }
            //                      else
            //                    DGView[14, Global.Sn - 1].Style.ForeColor = Color.Red;

            //                if ((Convert.ToDouble(DGView[8, Global.Sn - 1].Value) <= Convert.ToDouble(maxPassOfLim[4])) && (Convert.ToDouble(DGView[8, Global.Sn - 1].Value) >= Convert.ToDouble((minPassOfLim[4]))))
            //                {
            //                    DGView[8, Global.Sn - 1].Style.ForeColor = Color.Yellow;
            //                }
            //                 else
            //                     DGView[8, Global.Sn - 1].Style.ForeColor = Color.Red;

            //                if ((Convert.ToDouble(DGView[7, Global.Sn - 1].Value) <= Convert.ToDouble(maxPassOfLim[5])) && (Convert.ToDouble(DGView[7, Global.Sn - 1].Value) >= Convert.ToDouble((minPassOfLim[5]))))
            //                {
            //                    DGView[7, Global.Sn - 1].Style.ForeColor = Color.Yellow;
            //                }
            //                else
            //                    DGView[7, Global.Sn - 1].Style.ForeColor = Color.Red;

            //                if ((Convert.ToDouble(DGView[13, Global.Sn - 1].Value) <= Convert.ToDouble(maxPassOfLim[6])) && (Convert.ToDouble(DGView[13, Global.Sn - 1].Value) >= Convert.ToDouble((minPassOfLim[6]))))
            //                {
            //                    DGView[13, Global.Sn - 1].Style.ForeColor = Color.Yellow;
            //                }
            //                     else
            //                    DGView[13, Global.Sn - 1].Style.ForeColor = Color.Red;

            //                if ((Convert.ToDouble(DGView[16, Global.Sn - 1].Value) <= Convert.ToDouble(maxPassOfLim[7])) && (Convert.ToDouble(DGView[16, Global.Sn - 1].Value) >= Convert.ToDouble((minPassOfLim[7]))))
            //                {
            //                    DGView[16, Global.Sn - 1].Style.ForeColor = Color.Yellow;
            //                }
            //                else
            //                  DGView[16, Global.Sn - 1].Style.ForeColor = Color.Red;
            //            }
            }
              

        private void eDACParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void tmrInst_Tick(object sender, EventArgs e)
        {
           
            
        //    if (iCnt >= 14)
        //        {
        //            //if (Global.flg_EngStart == true)
        //            //{
        //                iCnt = 0;                        
        //               Global.LogECUData();            
        //            //}
        //        } 
        //        else
        //           iCnt++;  
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //Global.GenData[30] = trackBar1.Value.ToString();
        }

        private void setPidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process[] prs = Process.GetProcesses();
            foreach (Process pr in prs)
                if (pr.ProcessName == "Mod_PID") pr.Kill();

            Thread.Sleep(1000);
            p.StartInfo = new ProcessStartInfo(Global.PATH + "Mod_PID.exe");
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.Start();
        }

        private void mnuPreS_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //engOk.Show();

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            try
            {

                RdAdam.Transfer_Adam();

            }

            catch (Exception ex)
            {
                return;
            }
        }

       private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {


            if (btnReset.Enabled == true)
            {
                if (e.KeyCode == Keys.F5) btnReset.PerformClick();
            }
           
           //if (e.KeyCode == Keys.F5)
           // {
           //     btnReset.PerformClick();
           // }

           // else if (e.KeyCode == Keys.F1)
           // {
           //     Btn21.PerformClick();
           // }
           // else if (e.KeyCode == Keys.F2)
           // {
           //     Btn22.PerformClick();
           // }
           // else if (e.KeyCode == Keys.F8)
           // {
           //     Btn27.PerformClick();
           // }
           // else if (e.KeyCode == Keys.F7)
           // {
           //     Btn24.PerformClick();
           // }
           // else if (e.KeyCode == Keys.F12)
           // {
           //     BtnSA.PerformClick();
           // } 

        }

       private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
       {
           //if (e.KeyChar == C) btnReset.PerformClick(); 
       }

       private void mnuS_Start_Click(object sender, EventArgs e)
       {
           Process[] prs = Process.GetProcesses();
           foreach (Process pr in prs)
               if (pr.ProcessName == "Read_ECUVal") pr.Kill();

           Thread.Sleep(1000);
           p.StartInfo = new ProcessStartInfo(Global.PATH + "Read_ECUVal.exe");
           p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
           p.Start();
       }

       private void mnuAbout_Click(object sender, EventArgs e)
       {
           frmAbout frm = new frmAbout();
           frm.ShowDialog(this);
           frm.Dispose();
       }

       private void textBox1_TextChanged(object sender, EventArgs e)
       {

       }

       private void panel6_Paint(object sender, PaintEventArgs e)
       {

       }

       private void ipVal1_Load(object sender, EventArgs e)
       {

       }

       private void ipVal2_Load(object sender, EventArgs e)
       {

       }

       private void ipVal3_Load(object sender, EventArgs e)
       {

       }

       private void ipVal4_Load(object sender, EventArgs e)
       {

       }

       private void ipVal5_Load(object sender, EventArgs e)
       {

       }

       private void ipVal6_Load(object sender, EventArgs e)
       {

       }

       private void ipVal7_Load(object sender, EventArgs e)
       {

       }

       private void ipVal8_Load(object sender, EventArgs e)
       {

       }

       private void ipVal9_Load(object sender, EventArgs e)
       {

       }

       private void ipVal10_Load(object sender, EventArgs e)
       {

       }

       private void ipVal11_Load(object sender, EventArgs e)
       {

       }

       private void ipVal12_Load(object sender, EventArgs e)
       {

       }

       private void ipVal13_Load(object sender, EventArgs e)
       {

       }

       private void ipVal14_Load(object sender, EventArgs e)
       {

       }

       private void ipVal15_Load(object sender, EventArgs e)
       {

       }

       private void ipVal16_Load(object sender, EventArgs e)
       {

       }

       private void ipVal17_Load(object sender, EventArgs e)
       {

       }

       private void ipVal18_Load(object sender, EventArgs e)
       {

       }

       private void ipVal19_Load(object sender, EventArgs e)
       {

       }

       private void ipVal20_Load(object sender, EventArgs e)
       {

       }

       private void ipVal21_Load(object sender, EventArgs e)
       {

       }

       private void ipVal22_Load(object sender, EventArgs e)
       {

       }

       private void ipVal23_Load(object sender, EventArgs e)
       {

       }

       private void ipVal24_Load(object sender, EventArgs e)
       {

       }

       private void ipVal30_Load(object sender, EventArgs e)
       {

       }

       private void ipVal36_Load(object sender, EventArgs e)
       {

       }

       private void ipVal35_Load(object sender, EventArgs e)
       {

       }

       private void ipVal29_Load(object sender, EventArgs e)
       {

       }

       private void ipVal34_Load(object sender, EventArgs e)
       {

       }

       private void ipVal28_Load(object sender, EventArgs e)
       {

       }

       private void ipVal33_Load(object sender, EventArgs e)
       {

       }

       private void ipVal27_Load(object sender, EventArgs e)
       {

       }

       private void ipVal32_Load(object sender, EventArgs e)
       {

       }

       private void ipVal26_Load(object sender, EventArgs e)
       {

       }

       private void ipVal31_Load(object sender, EventArgs e)
       {

       }

       private void ipVal25_Load(object sender, EventArgs e)
       {

       }

       private void ipVal37_Load(object sender, EventArgs e)
       {

       }
           
    
        
        
        //private void trackBar1_Scroll_1(object sender, EventArgs e)
        //{
        //    Tcnt = trackBar1.Value; 
        //}

      
    }
   }
        

       
       

       

       
       
       
       

        

     

       

       
       
           

       

        
       
       

        
       
        

       

       


        

        
         
        
       
       

       
     
   

       

 
        
    

       