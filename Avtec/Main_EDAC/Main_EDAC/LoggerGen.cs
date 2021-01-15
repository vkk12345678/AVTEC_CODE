using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO.Ports;
using MySql.Data;
using System.Data;

namespace Logger
{

    class LoggerGen
    {
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
        public static string AdamBuf1 = "";
        public static string AdamBuf2 = "";
        public static string AdamBuf3 = "";
       // public static string AdamBuf1 = "";

        public static SerialPort MSPort = new SerialPort();
        public static SerialPort RTPort = new SerialPort();
        public static SerialPort ADPortG1 = new SerialPort();
        public static SerialPort ADPortG2 = new SerialPort();


        public static SerialPort PIDPort = new SerialPort();
        public static SerialPort BlPort = new SerialPort();
        public static SerialPort mbPort = new SerialPort();
        public static SerialPort scPort = new SerialPort();
        public static SerialPort smkPort = new SerialPort();
        public static SerialPort ComPort = new SerialPort();
        public static Parity P;
        public static string comn;
        public static int Bd = 9600;
        public static int Addr;
        public static int cnt = 0;
        public static StopBits stopbt;

        public static SerialPort adPort = new SerialPort();
        public static String Buf;
        public static string a;

      
        public static void Rd_COM_Confg()
        {
            try
            {
                int x = 0;
               Global.Open_Connection("gen_db", "con");
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
               // if (Sr_Port1[9] == "True")Init_Port(Sr_Port1[2], int.Parse(Sr_Port1[3]), 8, (Parity)Enum.Parse(typeof(Parity), Sr_Port1[4]), (StopBits)Enum.Parse(typeof(StopBits), "One"));

                // Serail port 2 Initialization //

              //  if (Sr_Port2[9] == "True")Init_Port(Sr_Port2[2], int.Parse(Sr_Port2[3]), 8, (Parity)Enum.Parse(typeof(Parity), Sr_Port2[4]), (StopBits)Enum.Parse(typeof(StopBits), "One"));



                // Adam Port 1 Initialization //

                Parity p = ((Parity)Enum.Parse(typeof(Parity) ,Ad_Port1[4]));

                StopBits stb =((StopBits)Enum.Parse(typeof(StopBits), "One"));

             //   if (Ad_Port1[9] == "True") RdAdam.Init_Port(Ad_Port1[2], int.Parse(Ad_Port1[3]), 8, p,stb);


                // Adam Port 2 Initialization //

                if (Ad_Port2[9] == "True") Global.Init_Port(Ad_Port2[2], int.Parse(Ad_Port2[3]), 8, (Parity)Enum.Parse(typeof(Parity), Ad_Port2[4]), (StopBits)Enum.Parse(typeof(StopBits), "One"));

                // Smoke Port Initialization 

                if (Smk_Port[9] == "True") Global.Init_Port(Smk_Port[2], int.Parse(Smk_Port[3]), 8, (Parity)Enum.Parse(typeof(Parity), Smk_Port[4]), (StopBits)Enum.Parse(typeof(StopBits), "One"));


                //  Blow By Port Initialization 

                if (Bl_Port[9] == "True") Global.Init_Port(Bl_Port[2], int.Parse(Bl_Port[3]), 8, (Parity)Enum.Parse(typeof(Parity), Bl_Port[4]), (StopBits)Enum.Parse(typeof(StopBits), "One"));
                // BarCode Scanner Port Initialization

                if (sc_Port[9] == "True") Global.Init_Port(sc_Port[2], int.Parse(sc_Port[3]), 8, (Parity)Enum.Parse(typeof(Parity), sc_Port[4]), (StopBits)Enum.Parse(typeof(StopBits), "One"));

            }
            catch (Exception)
            {
                Global.Create_OnLog("COM ports are not  read successfully    ", "Alert");
            }

        }
    }
}
