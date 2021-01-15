using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Globalization;
using System.IO.Ports;
using MySql.Data.MySqlClient;
using System.IO;
using Editors_DLL;

namespace Editors_DLL
{
    public class Global
    {
        //public static string PATH = Application.StartupPath;//+ "\\";Application.StartupPath + "\\"; //
         
        public static string HelpPath = "C:\\Windows\\Help\\DynalecHelp\\";
        public static string Data_Dir;
        public static string I_Tm;

        // = "D:\\TestCell_" + T_CellNo + "\\" & Data_Dir & "\\";
        public static string[] bin0 = new string[8] { "0", "0", "0", "0", "0", "0", "0", "0" };
        public static string[] bin1 = new string[8] { "0", "0", "0", "0", "0", "0", "0", "0" };

        public static String[] PNo = new String[130];
        public static String[] PName = new String[130];
        public static String[] PSName = new String[130];
        public static String[] PUnit = new String[130];
        public static String[] PMin = new String[130];
        public static String[] PMax = new String[130];
        public static String[] PMark = new String[130];
        public static String[] GenData = new String[130];

        public static String[] Data = new String[130];
        public static String[] ArrData = new String[130];
        public static String[] PmArr = new String[150];
        //public static String[] Arr = new String[5];

        public static SerialPort msPort = new SerialPort();
        public static SerialPort adPort = new SerialPort();
        public static SerialPort mbPort = new SerialPort();
        public static int cntlist = 0;


        public static int loopcount = 0;
        public static int[] DigIn = new int[20];
        public static int[] DigOut = new int[20];
        //public static int[] DigOut1 = new int[8];


        public static int[] fxd = new int[60];
        public static int[] Pm_PNo = new int[20];
        public static String[] sysIn = new String[80];
        public static String[] arr = new String[200];


        public static int[] vId = new int[130];
        public static Boolean flg_EngStart = false;

        public static Boolean flg_SFCStart = false;
        public static double[] m_data = new double[16];
        public static string[] GetData = new string[16];
        public static String[] L1 = new String[105];
        public static String[] LL1 = new String[105];
        public static String[] H1 = new String[105];
        public static String[] HH1 = new String[105];

        public static String[] L2 = new String[105];
        public static String[] LL2 = new String[105];
        public static String[] H2 = new String[105];
        public static String[] HH2 = new String[105];
        public static String[] BufLim = new String[105];
        public static String[] arrLim = new String[105];

        public static String PartRpm = "2000";
        public static String SFC_Msg_from_Inst = "";
        public static String SFC_Status = "";
        public static string modcnt;

        public static Boolean Flg_AList = true;

        public static Boolean SFC_Reset = false;
        public static Int16 varRPM;
        public static double varTRQ;
        public static double varLUB;
        public static double varWtr;
        public static String StpTm;
        public static String EngHrs;
        public static String SFC_msg;
        public static string bufftss4;
        public static string bufftss8;

        public static int VolA = 100;
        public static int VolB = 200;
        public static int VolC = 300;
        public static int Vol = 100;
        public static int StNo = 1;

        public static Int16 ADAMCnt = 1;
        public static Int16 ChnCnt = -1;
        public static int stopid;
        public static Int16 t = 31;
        public static Int16 U = 39;
        public static Int16 V = 47;
        public static Int16 W = 55;
        public static Int16 X = 63;

        public static String S_Out = "00";
        public static Int16 I_Add = 0;
        public static string EngType = "";
        public static string Bor = "100";
        public static string NCyl = "2";
        public static string Strk = "100";
        public static string Svol = "1.5";
        public static string SGrv = "0.835";
        public static string FuelType = "";
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
        public static String SFCStatus;
        public static Int16 LogCounter;
        public static string cumhours = "0000:00:00";

        public static Boolean flg_prjOn = false;
        public static Boolean flg_LimitON = false;
        public static Boolean flg_SMK437 = false;
        public static Boolean flg_SMK415 = false;
        public static Boolean flg_SMK415_S = false;
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

        public static Double Diff1;
        public static Double Diff2;
        public static Double Edif1;
        public static Double Edif2;

        public static Double AnaOut1 = 0.01;
        public static Double AnaOut2 = 0.01;
        public static Double LastAna1 = 0;
        public static Double LastAna2 = 0;
        public static String SetPtOut1 = "0";
        public static String SetPtOut2 = "0";
        public static String C_Mode = "1";
        public static String L_Mode = "1";

        public static int RcrOn = 1;
        public static int TcrOn = 0;

        public static String Eng_FileNm;
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
        public static Double VarTrq;
        public static Double VarPowkW;
        public static Double VarPowPs;


        public static String StrAlarm;
        public static String RunStatus;
        public static String ErrorMatrix;

        public static String MD1, MD2, MD3, MD4, MD5;
        public static String DConst;
        public static String MySqlPW;


        //For pass Of Limit
        public static double[] minPass = new double[10];
        public static double[] maxPass = new double[10];


        //////////// Passout variable///////////////

        public static Int32 PassOutIdleRPMMin = 0;
        public static Int32 PassOutIdleRPMMax = 0;
        public static Int32 PassOutFlyupRPMMin = 0;
        public static Int32 PassOutFlyupRPMMax = 0;
        public static Double PassOut_T_WtrminValue = 0;
        public static Double PassOut_T_WtrmaxValue = 0;
        public static Double PassOut_Rtd_MaxTrqMin = 0;
        public static Double PassOut_Rtd_MaxTrqMax = 0;
        public static Double PassOut_Rtd_SFC = 0;
        public static Double PassOutP_Lub_IdleRpmMin = 0;
        public static Double PassOutP_Lub_IdleRpmMax = 0;
        public static Double PassOutP_Lub_FlyRpmMin = 0;
        public static Double PassOutP_Lub_FlyRpmMax = 0;
        public static Double PassOutMaxTRQMin = 0;
        public static Double PassOutMaxTRQMax = 0;
        public static Double PassOutMaxTRQRpmMin = 0;
        public static Double PassOutMaxTRQRpmMax = 0;
        public static string PassOutFIPModel = "";
        public static Boolean flg_PassOutFile = false;


        //public static void Rd_Pwd()
        //{            
        //    FileStream fs2 = new FileStream("C:\\edac.ini", FileMode.Open, FileAccess.Read);
        //    StreamReader reader = new StreamReader(fs2);
        //    String InPut = reader.ReadToEnd();
        //    int pos1 = 1;
        //    int pos2 = 1;
        //    pos1 = InPut.IndexOf("@", 0);
        //    pos2 = InPut.IndexOf("@", (pos1 + 1));
        //    MySqlPW = InPut.Substring(pos1 + 1, (pos2 - pos1 - 1));
        //    reader.Close();

        //}
        public static void Create_OffLog(String Str, String Msg)//,int Icon)
        {
            try
            {
                Global.Data_Dir = DateTime.Now.ToString("MMMyy");
                String OffLog_Editor = "OffLogEditor_" + DateTime.Now.ToString("ddMMMyy");

                if (System.IO.Directory.Exists("D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\") == false)
                {
                    System.IO.Directory.CreateDirectory("D:\\TestCell_" + T_CellNo + "\\" + Data_Dir);
                }
                if (System.IO.Directory.Exists("D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\Log_Data") == false)
                {
                    System.IO.Directory.CreateDirectory("D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\Log_Data");
                }
                if (System.IO.File.Exists("D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\Log_Data\\" + OffLog_Editor + ".txt") == false)
                {
                    System.IO.File.Create("D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\Log_Data\\" + OffLog_Editor + ".txt");
                }

                I_Tm = DateTime.Now.ToString();
                String strData = I_Tm + " ,     " + Str + " ,          " + Msg;

                String filePath = "D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\Log_Data\\" + OffLog_Editor + ".txt";
                using (StreamWriter sw = File.AppendText(filePath))
                    sw.WriteLine(strData); ;
            }
            catch (Exception ex)
            {
                //return;
                Create_OnLog(ex.Message + " :  Load In Cell....", "false");
                //MessageBox.Show("Error Code:- 15007", ex.Message);
            }

        }


        public static void Create_OnLog(string Msg, String state)//,int Icon)
        {
            try
            {
                Data_Dir = DateTime.Now.ToString("MMMyy");
                //string OnLog_Data = System.DateTime.Now.ToString() + "_OnLogData";
                String OnLog_Data = "OnLog_Data_" + DateTime.Now.ToString("ddMMMyy");

                I_Tm = System.DateTime.Now.ToString(); // ("hh:mm:ss tt");

                if (System.IO.Directory.Exists("D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\") == false)
                {
                    System.IO.Directory.CreateDirectory("D:\\TestCell_" + T_CellNo + "\\" + Data_Dir);
                }
                if (System.IO.Directory.Exists("D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\Log_Data") == false)
                {
                    System.IO.Directory.CreateDirectory("D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\Log_Data");
                }
                if (System.IO.File.Exists("D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\Log_Data\\ OnLog_Data.csv") == false)
                {
                    System.IO.File.Create("D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\Log_Data\\ OnLog_Data.csv");
                }


                String strData = I_Tm + ",      " + EngNo + ",     " + StNo + ",     " + varRPM + ",     " + Msg + ",     " + state;
                String filePath1 = "D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\Log_Data\\ OnLog_Data.csv";

                using (StreamWriter sw = File.AppendText(filePath1))
                    sw.WriteLine(strData); ;
            }
            catch (Exception ex)
            {
                return;
                
                //MessageBox.Show("Error Code:- 15007", ex.Message);
            }

        }
       

        public static void Rd_System()
        {
            try
            {
                Common.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbsys WHERE FileName = 'SystemPara'", Editors_DLL.Common.con);
                MySqlDataReader Rd = cmd.ExecuteReader();
                Int16 x = 0;
                while (Rd.Read())
                {
                    for (x = 0; x <= (Rd.FieldCount - 1); x++)
                    {
                        sysIn[x] = Rd.GetValue(x).ToString();
                    }
                    //DConst = sysIn[6];
                    //MD1 = sysIn[22];
                    //MD2 = sysIn[25];
                    //MD3 = sysIn[28];
                    //MD4 = sysIn[31];
                    //MD5 = sysIn[34];
                    //flg_rdMod = Convert.ToBoolean(sysIn[61]);
                    //flg_LoginRPM = Convert.ToBoolean(sysIn[64]);
                    //flg_RecorsPmData = Convert.ToBoolean(sysIn[15]);
                    //flg_simulateRPM = Convert.ToBoolean(sysIn[65]);
                    T_CellNo = sysIn[9];
                    Data_Dir = DateTime.Now.ToString("MMMyy");
                    DataPath  = "D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\";
                }
            }
            catch (Exception ex)
            {
                return; // MessageBox.Show("Error Code:- 15014", ex.Message);
            }
        }

        //public static void Read_ModbusValues()
        //{
        //    try
        //    {
        //        Open_Connection("General", "con");
        //        MySqlCommand cmd = new MySqlCommand("Select * from Modbus where ID='1'", con);
        //        MySqlDataReader rd = cmd.ExecuteReader();
        //        while (rd.Read())
        //        {
        //            GenData[87] = rd.GetValue(0).ToString();
        //            GenData[88] = rd.GetValue(1).ToString();
        //            GenData[89] = rd.GetValue(2).ToString();
        //            modcnt = rd.GetValue(3).ToString();
        //        }
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error Code:- 15004", ex.Message); 
        //    }


        //}
        //public static void Read_ADAMValues()
        //{
        //    try
        //    {
        //        string Buf = "";
        //        Buf = adPort.ReadExisting();
        //        bufftss8 = Buf;

        //        if (Buf != "")
        //            Transfer_Adam_Values(ADAM.Module, Buf, ADAM.Indx);
        //        else
        //            goto a;

        //    a: switch (ADAMCnt)
        //        {
        //            case 1:
        //                if (MD1 != "NONE")
        //                {
        //                    Buf = "";
        //                    if (ChnCnt >= 7)
        //                    {
        //                        ChnCnt = -1;
        //                        ADAMCnt = 2;
        //                    }
        //                    else
        //                    {
        //                        ChnCnt += 1;
        //                    }
        //                    adPort.DiscardInBuffer();
        //                    ADAM.Module = MD1;
        //                    ADAM.Indx = t;
        //                    if (ChnCnt >= 0) adPort.Write("#01" + ChnCnt + "\r");// adPort.Write("$" + ChnCnt.ToString("X2") + "M" + "\r");// 
        //                }
        //                else
        //                {
        //                    ADAM.Module = "";
        //                    ADAM.Indx = 0;
        //                    ChnCnt = -1;
        //                    ADAMCnt = 2;
        //                }
        //                break;
        //            case 2:
        //                if (MD2 != "NONE")
        //                {
        //                    Buf = "";
        //                    if (ChnCnt >= 7)
        //                    {
        //                        ChnCnt = -1;
        //                        ADAMCnt = 3;
        //                    }
        //                    else
        //                    {
        //                        ChnCnt += 1;
        //                    }
        //                    adPort.DiscardInBuffer();
        //                    ADAM.Module = MD2;
        //                    ADAM.Indx = U;
        //                    if (ChnCnt >= 0) adPort.Write("#02" + ChnCnt + "\r");// adPort.Write("$" + ChnCnt.ToString("X2") + "M" + "\r");//
        //                }
        //                else
        //                {
        //                    ADAM.Module = "";
        //                    ADAM.Indx = 0;
        //                    ChnCnt = -1;
        //                    ADAMCnt = 3;
        //                }
        //                break;
        //            case 3:
        //                if (MD3 != "NONE")
        //                {
        //                    Buf = "";
        //                    if (ChnCnt >= 7)
        //                    {
        //                        ChnCnt = -1;
        //                        ADAMCnt = 4;
        //                    }
        //                    else
        //                    {
        //                        ChnCnt += 1;
        //                    }
        //                    adPort.DiscardInBuffer();
        //                    ADAM.Module = Global.MD3;
        //                    ADAM.Indx = V;
        //                    if (ChnCnt >= 0) adPort.Write("#03" + ChnCnt + "\r");// adPort.Write("$" + ChnCnt.ToString("X2") + "M" + "\r"); // 
        //                }
        //                else
        //                {
        //                    ADAM.Module = "";
        //                    ADAM.Indx = 0;
        //                    ChnCnt = -1;
        //                    ADAMCnt = 4;
        //                }
        //                break;
        //            case 4:
        //                if (MD4 != "NONE")
        //                {
        //                    Buf = "";
        //                    if (ChnCnt >= 7)
        //                    {
        //                        ChnCnt = -1;
        //                        ADAMCnt = 5;
        //                    }
        //                    else
        //                    {
        //                        ChnCnt += 1;
        //                    }
        //                    adPort.DiscardInBuffer();
        //                    ADAM.Module = Global.MD4;
        //                    ADAM.Indx = W;
        //                    if (ChnCnt >= 0) adPort.Write("#04" + ChnCnt + "\r");// adPort.Write("$" + ChnCnt.ToString("X2") + "M" + "\r");
        //                }
        //                else
        //                {
        //                    ADAM.Module = "";
        //                    ADAM.Indx = 0;
        //                    ChnCnt = -1;
        //                    ADAMCnt = 5;
        //                }
        //                break;
        //            case 5:
        //                if (MD5 != "NONE")
        //                {
        //                    Buf = "";
        //                    if (ChnCnt >= 7)
        //                    {
        //                        ChnCnt = -1;
        //                        ADAMCnt = 1;
        //                    }
        //                    else
        //                    {
        //                        ChnCnt += 1;
        //                    }
        //                    adPort.DiscardInBuffer();
        //                    ADAM.Module = Global.MD5;
        //                    ADAM.Indx = X;
        //                    if (ChnCnt >= 0) adPort.Write("#05" + ChnCnt + "\r");//adPort.Write("$" + ChnCnt.ToString("X2") + "M" + "\r");
        //                }
        //                else
        //                {
        //                    ADAM.Module = "";
        //                    ADAM.Indx = 0;
        //                    ChnCnt = -1;
        //                    ADAMCnt = 1;
        //                }
        //                break;
        //        }
        //        if ((ADAMCnt > 5) || (ADAMCnt <= 0)) ADAMCnt = 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        return; // MessageBox.Show("Error Code :- 15005", ex.Message);
        //    }
        //}

        //public struct ADAM
        //{
        //    public static String Module;
        //    public static Int16 Indx;
        //}
        //public static void Transfer_Adam_Values(String Module, String Buf1, int dx)
        //{
        //    try
        //    {
        //        Int16 pos = Convert.ToInt16(Buf1.IndexOf("+", 1));
        //        if (pos == -1) pos = Convert.ToInt16(Buf1.IndexOf("-", 1));
        //        //pos = Convert.ToInt16(Buf1.IndexOf("-",1));
        //        if (pos != -1) Buf1 = Buf1.Substring(pos); else Buf1 = "0000.00";

        //        switch (Module.Substring(0, 4))
        //        {
        //            case "4017":
        //                if (PSName[ChnCnt + dx] != "Not_Prog")
        //                {
        //                    Double Temp = ((Double.Parse(PMax[ChnCnt + dx]) - Double.Parse(PMin[ChnCnt + dx])) / 16);
        //                    GenData[ChnCnt + dx] = (((Double.Parse(Buf1.Substring(pos, 7)) - 4) * Temp) + Double.Parse(PMin[ChnCnt + dx])).ToString();

        //                }
        //                else
        //                {
        //                    GenData[ChnCnt + dx] = "0.0";
        //                }
        //                break;
        //            case "4018":
        //            case "4015":
        //                if (PSName[ChnCnt + dx] != "Not_Prog")
        //                    Global.GenData[ChnCnt + dx] = Buf1.Substring(pos, 6);  // , 6);
        //                else
        //                    Global.GenData[ChnCnt + dx] = "0.0";
        //                break;
        //        }
        //        int D = (ChnCnt + dx);
        //        Double l = Double.Parse(GenData[ChnCnt + dx]);
        //        Double max = Double.Parse(Global.PMax[ChnCnt + dx]);
        //        Double min = double.Parse(Global.PMin[ChnCnt + dx]);
        //        //if ((l >= 5000) && (l <= -5000))
        //        //{
        //        //    l = double.Parse(Global.PMax[ChnCnt + dx]);
        //        //    GenData[D] = l.ToString();
        //        //}
        //        //else if (l <= -5000)
        //        //{
        //        //    l = double.Parse(Global.PMin[ChnCnt + dx]);
        //        //    GenData[D] = l.ToString();
        //        //}

        //        if (l >= max)
        //        {
        //            GenData[D] = max.ToString();

        //        }
        //        else if (l <= min)
        //        {
        //            GenData[D] = min.ToString();
        //        }
        //        else if (l >= 10000) GenData[D] = "9999.9";
        //        else
        //        {
        //            if (PMax[D].Substring(1, 1) == ".")
        //            {
        //                GenData[D] = l.ToString("0.000");

        //            }
        //            else if (PMax[D].Substring(2, 1) == ".")
        //            {
        //                GenData[D] = l.ToString("00.00");

        //            }
        //            else if (PMax[D].Substring(3, 1) == ".")
        //            {
        //                GenData[D] = l.ToString("000.0");
        //            }
        //            else
        //            {
        //                GenData[D] = l.ToString("0000");

        //            }
        //        }
        //    }
        //    catch   //(Exception ex)
        //    {
        //        //MessageBox.Show("Error Transfer adam value : " + ex.Message);
        //        return;
        //        //adPort.Write("#05" + ChnCnt + "\r");
        //    }
        //}








        public static string DataPath { get; set; }
    }
}
