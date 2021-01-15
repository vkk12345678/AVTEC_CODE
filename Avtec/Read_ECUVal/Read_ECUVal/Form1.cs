using canlibCLSNET;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Read_ECUVal
{
    public partial class Form1 : Form
    {

        private int handle = -1;
        private int channel = -1;
        private int readHandle = -1;
        private bool onBus = false;
        private bool onLog = false;
        private readonly BackgroundWorker dumper;
        byte[] msgInReadInjectorAll = new byte[64];
        byte[] msgInReadDTCAll = new byte[64];
        private int ECUCnt = 1;
        private int Ecn = 0;
        private int iCnt = 0;

        private string DataPath = "D:\\ECUDATA\\";
        private string Eng_ECU_FileNm = System.DateTime.Now.ToString("ddMMMyy_hhmmss tt"); 
        Stopwatch sw = new Stopwatch(); // sw cotructor
        public static String[] ECUData = new String[150];
        
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Gd.RowCount = 20;
            for (int i = 0; i < 20; i++)
            {
                Gd[0, i].Value = i + 1;
            }
            Gd[1, 0].Value = "ENGINE Speed";            
            Gd[4, 0].Value = "rpm";
            Gd[1, 1].Value = "ENGINE COOLANT TEMP.";
            Gd[4, 1].Value = "deg";
            Gd[1, 2].Value = "COOLANT TEMP. SETPT";
            Gd[4, 2].Value = "deg C";
            Gd[1, 3].Value = "INLET MANIFOLD TEMP.";
            Gd[4, 3].Value = "deg";
            Gd[1, 4].Value = "RAW OUTSIDE TEKP. ";
            Gd[4, 4].Value = "deg.C";
            Gd[1, 5].Value = "RAW COOLANT TEMP.";
            Gd[4, 5].Value = "deg.C";
            Gd[1, 6].Value = "ENGINE OIL TEMP.";
            Gd[4, 6].Value = "deg.C";
            Gd[1, 7].Value = "RAW ENGINE OIL TEMP.";
            Gd[4, 7].Value = "deg.C";
            Gd[1, 8].Value = "RAW OIL PRESS.";
            Gd[4, 8].Value = "bar";
            Gd[1, 9].Value = "RAIL PRESS. SET PT";
            Gd[4, 9].Value = "bar";
            Gd[1, 10].Value = "RAW RAIL PRESS";
            Gd[4, 10].Value = "bar";
            Gd[1, 11].Value = "OIL PRESS. SET PT";
            Gd[4, 11].Value = "bar";
            Gd[1, 12].Value = "ATMS. PRESSURE";
            Gd[4, 12].Value = "Mbar";
            Gd[1, 13].Value = "INTAKE AIR PRESS";
            Gd[4, 13].Value = "mbar";
            Gd[1, 14].Value = "INTAKE THROTTLE SET PT";
            Gd[4, 14].Value = "%";
            Gd[1, 15].Value = "INTAKE THROTTLE CONTROL";
            Gd[4, 15].Value = "%";
            Gd[1, 16].Value = "MEASURED AIR MASS FLOW";
            Gd[4, 16].Value = "mg";
            Gd[1, 17].Value = "RAW AIR MASS-FLOW";
            Gd[4, 17].Value = "kg-hr";
            Gd[1, 18].Value = "SPARE-1";
            Gd[4, 18].Value = "UNIT";
            Gd[1, 19].Value = "SPARE-2";
            Gd[4, 19].Value = "UNIT";
            //Gd[1, 20].Value = "SPARE-3";
            //Gd[4, 20].Value = "UNIT";

            System.Threading.Thread.Sleep(400);
            Init_ECU();
            timer1.Start(); 

        }


        private void CheckStatus(String action, Canlib.canStatus status)
        {
            if (status != Canlib.canStatus.canOK)
            {
                String errorText = "";
                Canlib.canGetErrorText(status, out errorText);
                statusText.Text = action + " failed: " + errorText;
            }
            else
            {
                statusText.Text = action + " succeeded";
            }
        }

        private void Init_ECU()
        {
            //Initializes Canlib
            Canlib.canInitializeLibrary();
            statusText.Text = "Canlib initialized";

            //Opens the channel selected in the "Channel" input box
            channel = 0;    // Convert.ToInt32(channelBox.Text);
            int hnd = Canlib.canOpenChannel(channel, Canlib.canOPEN_ACCEPT_VIRTUAL);

            CheckStatus("Open channel", (Canlib.canStatus)hnd); // .canStatus)hnd);
            if (hnd >= 0)
            {
                handle = hnd;
            }

            //Sets the bitrate
            int[] bitrates = new int[4] { Canlib.canBITRATE_125K, Canlib.canBITRATE_250K, 
                                            Canlib.canBITRATE_500K, Canlib.BAUD_1M};
            //int bitrate = bitrates[bitrateBox.SelectedIndex];
            int bitrate = bitrates[2];

            Canlib.canStatus status = Canlib.canSetBusParams(handle, bitrate, 0, 0, 0, 0, 0);

            //CheckStatus("Setting bitrate to " + ((ComboBoxItem)bitrateBox.SelectedValue).Content, status);
            CheckStatus("Setting bitrate to " + "500 kb/s", status);

            //Goes on bus
            //byte[] tx_msg = new byte[8] { 0x03, 0x19, 0x01, 0xFF, 0x00, 0x00, 0x00, 0x00  };
            byte[] tx_msg = new byte[8] { 0x03, 0x22, 0xD4, 0x22, 0x00, 0x00, 0x00, 0x00 };
            int flag = Canlib.canMSG_STD;
            int idOut = 0x6A8;
            int idIn = 0x688;//0x18DAFA00
            byte[] msgIn = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            int dlc = 0;
            long time = 0;
            long timeout = 200;
            int Counter = 0;
            int ECUCnt = 0;

            Canlib.canStatus statusBus = Canlib.canBusOn(handle);
            CheckStatus(" ECU Initialised,   &  Bus on ", status);
        }

      

        private void Read_ECUVal(Byte B2, Byte B3, Double CF, int Cnt)
        {           
            int flag = Canlib.canMSG_STD;
            int idOut = 0x6A8;
            int idIn = 0x688;
            byte[] msgIn = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            int dlc = 0;
            long time = 0;
            //long timeout = 200;
            int Counter = Cnt;
            if (CF == 0) CF = 1;
            
            label1.Text = ECUCnt.ToString();


            Byte[] MES = new Byte[8];
            int myNewInt = 0;
            string myHex1;
            string myHex2;

            string myHex;

            Double l;
            
            byte[] tx_msg = new byte[8] { 0x03, 0x22, B2, B3, 0x00, 0x00, 0x00, 0x00 };
            Canlib.canStatus statusWrite = Canlib.canWrite(handle, idOut, tx_msg, 4, flag);
            DelayMs(10); //await      Delay_InMliiS(5); //Thread.Sleep(5); //
            while (msgIn[1] != 0x62)
            {
                Canlib.canStatus statusRead1 = Canlib.canReadSpecific(handle, idIn, msgIn, out dlc, out flag, out time);
            }
           
            Gd[2, Cnt-1].Value = ByteArrayToString(msgIn).ToUpper();
            myHex1 = msgIn[4].ToString("X2");
            myHex2 = msgIn[5].ToString("X2");
            myHex = myHex1 + myHex2; 
            myNewInt = Convert.ToInt32(myHex, 16);
            Gd[3, Cnt-1].Value = Convert.ToDouble(myNewInt) * CF;
            ECUData[Cnt] = Gd[3, Cnt - 1].Value.ToString(); 
        }




        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
      

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (ECUCnt >= 20) ECUCnt = 1; else ECUCnt++;
               
                if (ECUCnt == 1)
                    Read_ECUVal(0xD4, 0x00, 1, 1);
                else if (ECUCnt == 2)
                    Read_ECUVal(0xD4, 0x0A, 1, 2);
                else if (ECUCnt == 3)
                    Read_ECUVal(0xD4, 0x0D, 1, 3);
                else if (ECUCnt == 4)
                    Read_ECUVal(0xD4, 0x11, 1, 4);
                else if (ECUCnt == 5)
                    Read_ECUVal(0xD4, 0x14, 1, 5);
                else if (ECUCnt == 6)
                    Read_ECUVal(0xD4, 0x15, 1, 6);
                else if (ECUCnt == 7)
                    Read_ECUVal(0xD4, 0x2A, 0.0625, 7);
                else if (ECUCnt == 8)
                    Read_ECUVal(0xD4, 0x7D, 0.0625, 8);
                else if (ECUCnt == 9)
                    Read_ECUVal(0xD4, 0x29, 0.0078125, 9);
                else if (ECUCnt == 10)
                    Read_ECUVal(0xD4, 0x45, 1, 10);
                else if (ECUCnt == 11)
                    Read_ECUVal(0xD4, 0x46, 1, 11);
                else if (ECUCnt == 12)
                    Read_ECUVal(0xD4, 0x64, 0.001, 12);
                else if (ECUCnt == 13)
                    Read_ECUVal(0xD4, 0x65, 1, 13);
                else if (ECUCnt == 14)
                    Read_ECUVal(0xD4, 0xD9, 1, 14);
                else if (ECUCnt == 15)
                    Read_ECUVal(0xD4, 0x60, 0.0078125, 15);
                else if (ECUCnt == 16)
                    Read_ECUVal(0xD4, 0x61, 0.0078125, 16);
                else if (ECUCnt == 17)
                    Read_ECUVal(0xD4, 0x88, 0.1, 17);
                else if (ECUCnt == 18)
                    Read_ECUVal(0xD4, 0xEF, 0.1125, 18);
                else if (ECUCnt == 19)
                    Read_ECUVal(0xD4, 0x46, 1, 19);
                else if (ECUCnt == 20)
                    Read_ECUVal(0xD4, 0x46, 1, 20);
                
            }
            catch (Exception ex)
            {
                return;
            }

        }

      

        public static DateTime DelayMs(int nMs)
        {
            try
            {
                System.DateTime ThisMoment = System.DateTime.Now; // ("hh:mm:ss.fff");
                System.TimeSpan duration = new System.TimeSpan(0, 0, 0, 0, nMs);
                System.DateTime AfterWards = ThisMoment.Add(duration);
                while (AfterWards >= ThisMoment)
                {
                    System.Windows.Forms.Application.DoEvents();
                    ThisMoment = System.DateTime.Now;
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15015", ex.Message);
            }
            return System.DateTime.Now;

        }

        private static void DelaynMs(int nMs)
        {
            var durationTicks = (nMs * Stopwatch.Frequency);
            var sw = Stopwatch.StartNew();

            while(sw.ElapsedTicks  < nMs)
            {

            }
  
        }


        private void mnuInitECU_Click(object sender, EventArgs e)
        {
            Init_ECU();
            timer1.Start(); 
        }
       

        private void mnuDisECU_Click(object sender, EventArgs e)
        {
            Canlib.canStatus status = Canlib.canBusOff(handle);
            CheckStatus("Bus off", status);
            onBus = false;

            Canlib.canStatus statusCh = Canlib.canClose(handle);
            CheckStatus("Closing channel", statusCh);
            handle = -1;
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            Canlib.canStatus status = Canlib.canBusOff(handle);
            CheckStatus("Bus off", status);
            onBus = false;

            Canlib.canStatus statusCh = Canlib.canClose(handle);
            CheckStatus("Closing channel", statusCh);
            handle = -1;

            this.Close(); 

        }

        private void chkDTC_Click(object sender, EventArgs e)
        {
            int flag = Canlib.canMSG_STD;
            int idOut = 0x6A8;
            int idIn = 0x688;
            byte[] msgIn = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            int dlc = 0;
            long time = 0;
            ////long timeout = 200;
            int Counter = 0;
            int myNewInt = 0;
            string myHex1;
            string myHex2;
            string myHex3;

            string myHex;

            Init_ECU();

            byte[] tx_msg = new byte[8] { 0x03, 0x19, 0x02, 0xFF, 0x00, 0x00, 0x00, 0x00 };
            Canlib.canStatus statusWrite = Canlib.canWrite(handle, idOut, tx_msg, 4, flag);
            CheckStatus("canWrite", statusWrite);

            while (msgIn[1] != 0x77 && Counter < 60)
            {
                //label2.Text = Counter.ToString("00");
                //Canlib.canStatus statusRead1 = Canlib.canReadWait(handle, out idIn, msgIn, out dlc, out flag, out time, timeout);
                Canlib.canStatus statusRead1 = Canlib.canReadSpecific(handle, idIn, msgIn, out dlc, out flag, out time);
                CheckStatus("canReadSpecific", statusRead1);
                //MessageBox.Show("Read DTC Output 1: \n" + ByteArrayToString(msgIn) + "\n.    Counter:  " + Counter + "\n");                   
                Counter++;
               

                Thread.Sleep(200);   // Delay_InMliiS(500);

            }

            Canlib.canStatus statusRead = Canlib.canReadSpecific(handle, idIn, msgIn, out dlc, out flag, out time);
            //statusRead1 = Canlib.canReadSpecific(handle, idIn, msgIn, out dlc, out flag, out time);

            myHex1 = msgIn[5].ToString("X2");
            myHex2 = msgIn[6].ToString("X2");
            myHex3 = msgIn[7].ToString("X2");
            myHex = myHex1 + myHex2 + "-" + myHex3;
            MessageBox.Show("Read DTC Output 1: \n" + "Timeout : " + Counter + "\n" + "DTC No : " + myHex);
          
        }

        private void mnuchkDTCList_Click(object sender, EventArgs e)
        {
            int flag = Canlib.canMSG_STD;
            int idOut = 0x6A8;
            int idIn = 0x688;
            byte[] msgIn = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            int dlc = 0;
            long time = 0;
            int Counter = 0;

            string myHex1;
            string myHex2;
            string myHex3;

            string myHex;

            Init_ECU();

            byte[] tx_msg = new byte[8] { 0x03, 0x19, 0x01, 0xFF, 0x00, 0x00, 0x00, 0x00 };
            Canlib.canStatus statusWrite = Canlib.canWrite(handle, idOut, tx_msg, 4, flag);
            CheckStatus("canWrite", statusWrite);

            while (msgIn[1] != 0x59 && Counter < 60)
            {
                //label2.Text = Counter.ToString("00");
                Canlib.canStatus statusRead1 = Canlib.canReadSpecific(handle, idIn, msgIn, out dlc, out flag, out time);
                CheckStatus("canReadSpecific", statusRead1);
                Counter++;
                Thread.Sleep(200);

            }

            Canlib.canStatus statusRead = Canlib.canReadSpecific(handle, idIn, msgIn, out dlc, out flag, out time);

            myHex1 = msgIn[5].ToString("X2");
            myHex2 = msgIn[6].ToString("X2");


            //myHex3 = msgIn[7].ToString();
            myHex = myHex1 + myHex2;
            int myDec = Convert.ToInt32(myHex, 16);

            MessageBox.Show("Read DTC Output 1: \n" + "Timeout : " + Counter + "\n" + "No. of DTCs  : " + myDec);

        }

        public static void Capture_ECU_Data()
        {
            try
            {
                int I = 0;
                ECUData[0] = DateTime.Now.ToString("hh:mm:ss tt "); ;

                for (I = 1; I <= 20; I++)
                {
                    if (ECUData[I] == null) ECUData[I] = "0.0";
                    ECUData[I] = ECUData[I];
                }

            }
            catch (Exception ex)
            {
                //.Create_OnLog(ex.Message + " :  Capture ECU Data....", "Alert");
                return;
            }
        }

        private void LogECUData()
        {
            try
            {
                int i = 0;
                Capture_ECU_Data();
                Ecn += 1;
                String strData = String.Empty;
                String strData1 = String.Empty;
                String strData2 = String.Empty;
                String strData3 = String.Empty;
                String StpTm = DateTime.Now.ToString("hh:mm:ss tt ");
                strData1 = StpTm + ", ";
                for (i = 1; i <= 20; i++)
                {
                    if (ECUData[i] == null) ECUData[i] = "000.000";
                    strData1 = strData1 + ECUData[i] + ", ";
                }

                strData = strData1; 
                strData = strData + Ecn + ",\n";      // Global.StrAlarm + ", " +
                var filePath = DataPath + "\\" + Eng_ECU_FileNm + ".csv";
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


            }
            catch (Exception ex)
            {
                return;
                //MessageBox.Show("Error in LogData() :" + ex.Message);
                //MessageBox.Show("ECU Data Log Problem.." + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                //MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    Global.Create_OnLog("ECU Data Log Problem... ", "Alert");
                //    Global.flg_SFCStart = false;
            }
        }


        private void mnuStartLog_Click(object sender, EventArgs e)
        {
            if (mnuStartLog.Text == "START-LOG")
            {
                onLog = true;
                tmrLog.Start();
                mnuStartLog.Text = "STOP-LOG";
            }
            else if (mnuStartLog.Text == "STOP-LOG")
            {
                onLog = false;
                tmrLog.Stop();
                mnuStartLog.Text = "START-LOG";
            }
        }

        private void tmrLog_Tick(object sender, EventArgs e)
        {
            if (iCnt >= 14)
            {
                if (onLog == true)
                {
                    iCnt = 0;
                    LogECUData();
                }
            }
            else
                iCnt++;  
        }

       

       

     
        




    }
}
