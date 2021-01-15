



using System.Threading.Tasks;
//using canlibCLSNET;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Logger
{
    class clsECU
    {


        public static int handle = -1;
        public static int channel = -1;
        private int readHandle = -1;
        private bool onBus = false;
        private readonly BackgroundWorker dumper;
        byte[] msgInReadInjectorAll = new byte[64];
        byte[] msgInReadDTCAll = new byte[64];
       
        Stopwatch sw = new Stopwatch(); // sw cotructor
        public static string ECUMsg = "State";
        public static int ECUCnt = 1;
        public static string[] ArrECUVal = new string[50];
        public static double[] ECUVal = new double[50];
        
        
        
        
        //public static void Init_ECU()
        //{

        //    //Initializes Canlib
        //    Canlib.canInitializeLibrary();
        //    //statusText.Text = "Canlib initialized";

        //    //Opens the channel selected in the "Channel" input box
        //    channel = 0;    // Convert.ToInt32(channelBox.Text);
        //    int hnd = Canlib.canOpenChannel(channel, Canlib.canOPEN_ACCEPT_VIRTUAL);

        //    //CheckStatus("Open channel", (Canlib.canStatus)hnd); // .canStatus)hnd);
        //    if (hnd >= 0)
        //    {
        //        handle = hnd;
        //    }

        //    //Sets the bitrate
        //    int[] bitrates = new int[4] { Canlib.canBITRATE_125K, Canlib.canBITRATE_250K, 
        //                                    Canlib.canBITRATE_500K, Canlib.BAUD_1M};
        //    //int bitrate = bitrates[bitrateBox.SelectedIndex];
        //    int bitrate = bitrates[2];

        //    Canlib.canStatus status = Canlib.canSetBusParams(handle, bitrate, 0, 0, 0, 0, 0);

        //    //CheckStatus("Setting bitrate to " + ((ComboBoxItem)bitrateBox.SelectedValue).Content, status);
        //    //CheckStatus("Setting bitrate to " + "500 kb/s", status);

        //    //Goes on bus
        //    //byte[] tx_msg = new byte[8] { 0x03, 0x19, 0x01, 0xFF, 0x00, 0x00, 0x00, 0x00  };
        //    byte[] tx_msg = new byte[8] { 0x03, 0x22, 0xD4, 0x22, 0x00, 0x00, 0x00, 0x00 };
        //    int flag = Canlib.canMSG_STD;
        //    int idOut = 0x6A8;
        //    int idIn = 0x688;//0x18DAFA00
        //    byte[] msgIn = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        //    int dlc = 0;
        //    long time = 0;
        //    long timeout = 200;
        //    int Counter = 0;
        //    int ECUCnt = 0;

        //    Canlib.canStatus statusBus = Canlib.canBusOn(handle);
        //    //CheckStatus(" ECU Initialised,   &  Bus on ", status);
        //    ////Initializes Canlib
        //    //Canlib.canInitializeLibrary();
        //    //ECUMsg = "Canlib initialized";

        //    ////Opens the channel selected in the "Channel" input box
        //    //channel = 0;    // Convert.ToInt32(channelBox.Text);
        //    //int hnd = Canlib.canOpenChannel(channel, Canlib.canOPEN_ACCEPT_VIRTUAL);

        //    ////CheckStatus("Open channel", (Canlib.canStatus)hnd); // .canStatus)hnd);
        //    //if (hnd >= 0)
        //    //{
        //    //    handle = hnd;
        //    //}

        //    ////Sets the bitrate
        //    //int[] bitrates = new int[4] { Canlib.canBITRATE_125K, Canlib.canBITRATE_250K, 
        //    //                                Canlib.canBITRATE_500K, Canlib.BAUD_1M};
        //    ////int bitrate = bitrates[bitrateBox.SelectedIndex];
        //    //int bitrate = bitrates[2];

        //    //Canlib.canStatus status = Canlib.canSetBusParams(handle, bitrate, 0, 0, 0, 0, 0);

        //    ////CheckStatus("Setting bitrate to " + ((ComboBoxItem)bitrateBox.SelectedValue).Content, status);
        //    ////CheckStatus("Setting bitrate to " + "500 kb/s", status);

        //    ////Goes on bus
        //    ////byte[] tx_msg = new byte[8] { 0x03, 0x19, 0x01, 0xFF, 0x00, 0x00, 0x00, 0x00  };
        //    //byte[] tx_msg = new byte[8] { 0x03, 0x22, 0xD4, 0x22, 0x00, 0x00, 0x00, 0x00 };
        //    //int flag = Canlib.canMSG_STD;
        //    //int idOut = 0x6A8;
        //    //int idIn = 0x688;//0x18DAFA00
        //    //byte[] msgIn = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        //    //int dlc = 0;
        //    //long time = 0;
        //    //long timeout = 200;
        //    //int Counter = 0;
        //    //int ECUCnt = 0;

        //    //Canlib.canStatus statusBus = Canlib.canBusOn(handle);
        //    ////CheckStatus(" ECU Initialised,   &  Bus on ", status);
        //}

        //public static void Read_ECUVal(Byte B2, Byte B3, Double CF, int Cnt)
        //{
        //    int flag = Canlib.canMSG_STD;
        //    int idOut = 0x6A8;
        //    int idIn = 0x688;
        //    byte[] msgIn = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        //    int dlc = 0;
        //    long time = 0;
        //    //long timeout = 200;
        //    int Counter = Cnt;
        //    if (CF == 0) CF = 1;

        //    //label1.Text = ECUCnt.ToString();


        //    Byte[] MES = new Byte[8];
        //    int myNewInt = 0;
        //    string myHex1;
        //    string myHex2;

        //    string myHex;
        //    //ECUCnt = ECUCnt.ToString();

        //    Double l;

        //    byte[] tx_msg = new byte[8] { 0x03, 0x22, B2, B3, 0x00, 0x00, 0x00, 0x00 };
        //    Canlib.canStatus statusWrite = Canlib.canWrite(handle, idOut, tx_msg, 4, flag);
        //    DelayMs(10); //await      Delay_InMliiS(5); //Thread.Sleep(5); //
        //    while (msgIn[1] != 0x62)
        //    {
        //        Canlib.canStatus statusRead1 = Canlib.canReadSpecific(handle, idIn, msgIn, out dlc, out flag, out time);
        //    }

        //    //ECUVal[2, Cnt - 1].Value = ByteArrayToString(msgIn).ToUpper();
        //    ArrECUVal[Cnt] = ByteArrayToString(msgIn).ToUpper();
        //    myHex1 = msgIn[4].ToString("X2");
        //    myHex2 = msgIn[5].ToString("X2");
        //    myHex = myHex1 + myHex2;
        //    myNewInt = Convert.ToInt32(myHex, 16);
        //    //ECUVal[3, Cnt - 1].Value = Convert.ToDouble(myNewInt) * CF;
        //    //int flag = Canlib.canMSG_STD;
        //    //int idOut = 0x6A8;
        //    //int idIn = 0x688;
        //    //byte[] msgIn = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        //    //int dlc = 0;
        //    //long time = 0;
        //    ////long timeout = 200;
        //    //int Counter = ECUCnt;
        //    //if (CF == 0) CF = 1;

        //    ////ECUCnt = ECUCnt.ToString();


        //    //Byte[] MES = new Byte[8];
        //    //int myNewInt = 0;
        //    //string myHex1;
        //    //string myHex2;

        //    //string myHex;

        //    //Double l;

        //    //byte[] tx_msg = new byte[8] { 0x03, 0x22, B2, B3, 0x00, 0x00, 0x00, 0x00 };
        //    //Canlib.canStatus statusWrite = Canlib.canWrite(handle, idOut, tx_msg, 4, flag);
        //    //Thread.Sleep(5); // ////DelayMs(10); //await      Delay_InMliiS(5);
        //    //while (msgIn[1] != 0x62)
        //    //{
        //    //    Canlib.canStatus statusRead1 = Canlib.canReadSpecific(handle, idIn, msgIn, out dlc, out flag, out time);
        //    //}

        //    ////if (ByteArrayToString(msgIn) == null) ByteArrayToString(msgIn) = "* * * * * * * *";
        //    //ArrECUVal[Cnt] = ByteArrayToString(msgIn).ToUpper();

        //    ////Gd[2, Cnt - 1].Value = ByteArrayToString(msgIn).ToUpper();
        //    //myHex1 = msgIn[4].ToString("X2");
        //    //myHex2 = msgIn[5].ToString("X2");
        //    //myHex = myHex1 + myHex2;
        //    //myNewInt = Convert.ToInt32(myHex, 16);
        //    ////Double X = 0.0;
        //    ////if (myNewInt == null) X = 0.0; else X = Convert.ToDouble(myNewInt) * CF;
        //    //ECUVal[Cnt] =  Convert.ToDouble(myNewInt) * CF;  // x
        //    ////Gd[3, Cnt - 1].Value = Convert.ToDouble(myNewInt) * CF;

        //}

       
        //public static string ByteArrayToString(byte[] ba)
        //{
        //    StringBuilder hex = new StringBuilder(ba.Length * 2);
        //    foreach (byte b in ba)
        //        hex.AppendFormat("{0:x2}", b);
        //    return hex.ToString();
        //}


        //public static DateTime DelayMs(int nMs)
        //{
        //    try
        //    {
        //        System.DateTime ThisMoment = System.DateTime.Now; // ("hh:mm:ss.fff");
        //        System.TimeSpan duration = new System.TimeSpan(0, 0, 0, 0, nMs);
        //        System.DateTime AfterWards = ThisMoment.Add(duration);
        //        while (AfterWards >= ThisMoment)
        //        {
        //            System.Windows.Forms.Application.DoEvents();
        //            ThisMoment = System.DateTime.Now;
        //            break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error Code:- 15015", ex.Message);
        //    }
        //    return System.DateTime.Now;

        //}

        //public static void ReadFromECU()
        //{
        //    try
        //    {
        //        if (ECUCnt >= 20) ECUCnt = 1; else ECUCnt++;

        //        if (ECUCnt == 1)
        //            Read_ECUVal(0xD4, 0x00, 1, 1);
        //        else if (ECUCnt == 2)
        //            Read_ECUVal(0xD4, 0x0A, 1, 2);
        //        else if (ECUCnt == 3)
        //            Read_ECUVal(0xD4, 0x0D, 1, 3);
        //        else if (ECUCnt == 4)
        //            Read_ECUVal(0xD4, 0x11, 1, 4);
        //        else if (ECUCnt == 5)
        //            Read_ECUVal(0xD4, 0x14, 1, 5);
        //        else if (ECUCnt == 6)
        //            Read_ECUVal(0xD4, 0x15, 1, 6);
        //        else if (ECUCnt == 7)
        //            Read_ECUVal(0xD4, 0x2A, 0.0625, 7);
        //        else if (ECUCnt == 8)
        //            Read_ECUVal(0xD4, 0x7D, 0.0625, 8);
        //        else if (ECUCnt == 9)
        //            Read_ECUVal(0xD4, 0x29, 0.0078125, 9);
        //        else if (ECUCnt == 10)
        //            Read_ECUVal(0xD4, 0x45, 1, 10);
        //        else if (ECUCnt == 11)
        //            Read_ECUVal(0xD4, 0x46, 1, 11);
        //        else if (ECUCnt == 12)
        //            Read_ECUVal(0xD4, 0x64, 0.001, 12);
        //        else if (ECUCnt == 13)
        //            Read_ECUVal(0xD4, 0x65, 1, 13);
        //        else if (ECUCnt == 14)
        //            Read_ECUVal(0xD4, 0xD9, 1, 14);
        //        else if (ECUCnt == 15)
        //            Read_ECUVal(0xD4, 0x60, 0.0078125, 15);
        //        else if (ECUCnt == 16)
        //            Read_ECUVal(0xD4, 0x61, 0.0078125, 16);
        //        else if (ECUCnt == 17)
        //            Read_ECUVal(0xD4, 0x88, 0.1, 17);
        //        else if (ECUCnt == 18)
        //            Read_ECUVal(0xD4, 0xEF, 0.1125, 18);
        //        else if (ECUCnt == 19)
        //            Read_ECUVal(0xD4, 0x46, 1, 19);
        //        else if (ECUCnt == 20)
        //            Read_ECUVal(0xD4, 0x46, 1, 20);

        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //}

        //public static void Check_DTC()
        //{
        //    int flag = Canlib.canMSG_STD;
        //    int idOut = 0x6A8;
        //    int idIn = 0x688;
        //    byte[] msgIn = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        //    int dlc = 0;
        //    long time = 0;
        //    ////long timeout = 200;
        //    int Counter = 0;
        //    int myNewInt = 0;
        //    string myHex1;
        //    string myHex2;
        //    string myHex3;

        //    string myHex;

        //    Init_ECU();

        //    byte[] tx_msg = new byte[8] { 0x03, 0x19, 0x02, 0xFF, 0x00, 0x00, 0x00, 0x00 };
        //    Canlib.canStatus statusWrite = Canlib.canWrite(handle, idOut, tx_msg, 4, flag);
        //    //CheckStatus("canWrite", statusWrite);

        //    while (msgIn[1] == 0x7F && Counter < 60)
        //    {
        //        //label1.Text = Counter.ToString("00");
        //        //Canlib.canStatus statusRead1 = Canlib.canReadWait(handle, out idIn, msgIn, out dlc, out flag, out time, timeout);
        //        Canlib.canStatus statusRead1 = Canlib.canReadSpecific(handle, idIn, msgIn, out dlc, out flag, out time);
        //        //CheckStatus("canReadSpecific", statusRead1);
        //        //MessageBox.Show("Read DTC Output 1: \n" + ByteArrayToString(msgIn) + "\n    Counter:  " + Counter + "\n");                   
        //        Counter++;

        //        Thread.Sleep(200);   // Delay_InMliiS(500);

        //    }

        //    Canlib.canStatus statusRead = Canlib.canReadSpecific(handle, idIn, msgIn, out dlc, out flag, out time);
        //    //statusRead1 = Canlib.canReadSpecific(handle, idIn, msgIn, out dlc, out flag, out time);

        //    myHex1 = msgIn[5].ToString("X2");
        //    myHex2 = msgIn[6].ToString("X2");
        //    myHex3 = msgIn[7].ToString("X2");
        //    myHex = myHex1 + myHex2 + "-" + myHex3;
        //    MessageBox.Show("Read DTC Output 1: \n" + "Timeout : " + Counter + "\n" + "DTC No : " + myHex);
           

        //}

        // public static void Check_DTCn()
        //{
        //    int flag = Canlib.canMSG_STD;
        //    int idOut = 0x6A8;
        //    int idIn = 0x688;
        //    byte[] msgIn = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        //    int dlc = 0;
        //    long time = 0;
        //    int Counter = 0;

        //    string myHex1;
        //    string myHex2;
        //    string myHex3;

        //    string myHex;

        //    Init_ECU();

        //    byte[] tx_msg = new byte[8] { 0x03, 0x19, 0x01, 0xFF, 0x00, 0x00, 0x00, 0x00 };
        //    Canlib.canStatus statusWrite = Canlib.canWrite(handle, idOut, tx_msg, 4, flag);
        //    //CheckStatus("canWrite", statusWrite);

        //    while (msgIn[1] != 0x59 && Counter < 60)
        //    {
        //        //label1.Text = Counter.ToString("00");
        //        Canlib.canStatus statusRead1 = Canlib.canReadSpecific(handle, idIn, msgIn, out dlc, out flag, out time);
        //        //CheckStatus("canReadSpecific", statusRead1);
        //        Counter++;
        //        Thread.Sleep(200);

        //    }

        //    Canlib.canStatus statusRead = Canlib.canReadSpecific(handle, idIn, msgIn, out dlc, out flag, out time);

        //    myHex1 = msgIn[5].ToString("X2");
        //    myHex2 = msgIn[6].ToString("X2");


        //    //myHex3 = msgIn[7].ToString();
        //    myHex = myHex1 + myHex2;
        //    int myDec = Convert.ToInt32(myHex, 16);

        //    MessageBox.Show("Read DTC Output 1: \n" + "Timeout : " + Counter + "\n" + "No. of DTCs  : " + myDec);

        //}




    }
}
