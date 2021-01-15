using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Web;
using MySql.Data.MySqlClient;
//using canlibCLSNET;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO.Ports;
using Automation.BDaq;
using System.Threading; 
//******************************

using System.IO;



namespace Logger
{
    public partial class frmInOut : Form
    {
        public DataGridViewColumnSortMode SortMode { get; set; }
        #region GUI Delegate Declarations
        public delegate void GUIDelegate(string paramString);
        public delegate void GUIClear();
        public delegate void GUIStatus(string paramString);
        #endregion

        int pollCount;
        //modbus mb = new modbus();
        public string comn;
        public int Bd = 9600;
        public int Addr;
        public int cnt = 0;
        public Parity p;
        public StopBits stopbt;

        private int handle = -1;
        private int channel = -1;
        private int readHandle = -1;
        private bool onBus = false;
        private readonly BackgroundWorker dumper;
        byte[] msgInReadInjectorAll = new byte[64];
        byte[] msgInReadDTCAll = new byte[64];
        private int ECUCnt = 1;
        //Stopwatch sw = new Stopwatch(); // sw cotructor

       
        public frmInOut()
        {
            InitializeComponent(); 
        }

        private void frmInOut_Load(object sender, EventArgs e)
        {
            DGIn.RowCount = 16;

            tmrRead.Enabled = true;
            try
            {
                foreach (DataGridViewColumn colm in ViewGrid.Columns)
                {
                    colm.SortMode = DataGridViewColumnSortMode.NotSortable;  
                }
                foreach (DataGridViewColumn colm in DGIn.Columns)
                {
                    colm.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                foreach (DataGridViewColumn colm in DGOut.Columns)
                {
                    colm.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                Global.Rd_Confg();

                int Rn = 0;
                while (Rn < 125)
                {
                   
                    ViewGrid.RowCount += 1;
                    ViewGrid[0, Rn].Value = Global.PNo[Rn].ToString();
                    ViewGrid[1, Rn].Value = Global.PSName[Rn].ToString();
                    ViewGrid.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    ViewGrid[3, Rn].Value = Global.PMin[Rn].ToString() + "  :  " + Global.PMax[Rn].ToString();
                    ViewGrid[4, Rn].Value = Global.PUnit[Rn].ToString();
                    ViewGrid[5, Rn].Value = Global.PMark[Rn].ToString();
                    Rn += 1;
                }
                //Load_ECU_Grid(); 

                //Global.Rd_ECU_Confg();
                //Rn = 0;
                //while (Rn <= 50)
                //{

                //    ViewGridECU.RowCount += 1;
                //    ViewGridECU[0, Rn].Value = Global.EcuNo[Rn].ToString();
                //    ViewGridECU[1, Rn].Value = Global.EcuSName[Rn].ToString();
                //    ViewGridECU.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                //    ViewGridECU[3, Rn].Value = Global.EcuMin[Rn].ToString() + "  :  " + Global.EcuMax[Rn].ToString();
                //    ViewGridECU[4, Rn].Value = Global.EcuUnit[Rn].ToString();
                //    ViewGridECU[5, Rn].Value = Global.EcuMark[Rn].ToString();
                //    Rn += 1;
                //}
               
                Global.Rd_System();
                Load_DigInOut();
                //clsECU.Init_ECU(); 
            }
            catch (Exception ex)
            {
                Global.Create_OnLog(ex.Message + " :  Load frmIO....", "Alert");  
                //MessageBox.Show("Error Code:-5001 " + ex.Message);
            }
        }
        private void Load_DigInOut()
        {
            try
            {

                DGIn.RowCount = 16;

                Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbsys WHERE FileName = '03_DigInPuts'", Global.con);
                MySqlDataReader Rd = cmd.ExecuteReader();
                Int16 x = 0;
                while (Rd.Read())
                {
                    for (x = 0; x <= 15; x++)
                    {
                        DGIn[1, x].Value = Rd.GetValue(x + 1).ToString();
                        DGIn[1, x].Style.BackColor = Color.Green;
                        DGIn[2, x].Value = x + 1; 
                    }
                }
                Global.con.Close(); 

				//****************************

                DGOut.RowCount = 16;
				Global.Open_Connection("gen_db", "con");
                MySqlCommand cmd1 = new MySqlCommand("SELECT * FROM tbsys WHERE FileName = '04_DigOutPuts'", Global.con);
                MySqlDataReader Rd1 = cmd1.ExecuteReader();
                x = 0;
                while (Rd1.Read())
                {
                    for (x = 0; x <= 15; x++)
                    {
                        DGOut[1, x].Value = Rd1.GetValue(x + 1).ToString();
                        DGOut[1, x].Style.BackColor = Color.Green;
                        DGOut[2, x].Value = x+1; 
                    }
                }
                Global.con.Close();   
            }
            catch (Exception ex)
            {
                Global.Create_OnLog(ex.Message + " :  Load DigIO....", "Alert");  
                //MessageBox.Show("Error Code;-5002 " + ex.Message);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            tmrRead.Enabled = false; 
            this.Close();

        }        
        
        
        private void tmrRead_Tick(object sender, EventArgs e)
        {
            try
            {
                showDgIn();

                //Double P1 = 1.016;  Convert.ToDouble(Global.GenData[Global.fxd[10]]); //Global.Atp; // 
                //Double D1 = Convert.ToDouble(Global.GenData[Global.fxd[8]]) + 4; //.Global.Drb; //
                //Double W1 = Convert.ToDouble(Global.GenData[Global.fxd[9]]);  //  Global.Web; // Convert.ToDouble(Global.GenData[Global.fxd[9]]);

                //textBox1.Text = P1.ToString();
                //textBox2.Text = D1.ToString();
                //textBox3.Text = W1.ToString(); 
                double l = Convert.ToDouble(clsFun.Cal_Rel_Humid(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text)));
                textBox4.Text = l.ToString("00.0"); 
            }
            catch (Exception ex)
            {
                return;
            }
        }


        private void showDgIn()
        {

            for (int j = 0; j <= 15; j++)
            {
                if (Global.DigIn[j] == 1)
                {
                    DGIn[1, j].Style.BackColor = Color.Red;
                    DGIn[1, j].Style.ForeColor = Color.Yellow;
                    DGIn[0, j].Value = 1;

                }
                else
                {
                    DGIn[0, j].Value = 0;
                    DGIn[1, j].Style.BackColor = Color.Green;
                    DGIn[1, j].Style.ForeColor = Color.Yellow;

                }
            }
            label6.Text = string.Empty;
            for (int j = 0; j <= 15; j++)
            {
                if (Global.DigOut[j] == "1")
                {
                    DGOut[1, j].Style.BackColor = Color.Red;
                    DGOut[1, j].Style.ForeColor = Color.Yellow;
                    DGOut[0, j].Value = 1;
                }
                else
                {
                    DGOut[0, j].Value = 0;
                    DGOut[1, j].Style.BackColor = Color.Green;
                    DGOut[1, j].Style.ForeColor = Color.Yellow;

                }
                label6.Text = Global.Ds1;
                label7.Text = Global.Ds2; 

            }

            for (int i = 0; i < 125; i++)
            {
                ViewGrid.RowCount = 130;
                for (int Chnl = 0; Chnl < 125; Chnl++)
                {
                    if ((Global.GenData[Chnl] == null) || (Global.PSName[Chnl] == "Not_Prog"))
                    {
                        ViewGrid[2, Chnl].Value = "0.0";
                    }
                    else
                    {
                        ViewGrid[2, Chnl].Value = Global.GenData[Chnl];
                    }
                }
            }
            //for (int p = 0; p <= 99; p++)
            //{
            //    if (Global.GenData[p + 21] == null) Global.GenData[p + 21] = "****";
            //    //else
            //    ViewGridECU[2, p].Value = Global.GenData[p + 21];

            //}
        }                     
           
        private void DGOut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int port = 0;
            int c = DGOut.CurrentRow.Index;
            if (c >= 8) port = 1; else port = 0;

            if (port == 0)
            {
                if (Convert.ToBoolean(DGOut[0, c].Value) == true)
                {
                    DGOut[1, c].Style.BackColor = Color.Green; ;
                    DGOut[1, c].Style.ForeColor = Color.Yellow;
                    DGOut[0, c].Value = 0;
                    Global.Dig_OutBit(port, c, false);
                }
                else
                {
                    DGOut[1, c].Style.BackColor = Color.Red; ;
                    DGOut[1, c].Style.ForeColor = Color.Yellow;
                    DGOut[0, c].Value = 1;
                    Global.Dig_OutBit(port, c, true);
                }
            }
            else if (port == 1)
            {
                if (Convert.ToBoolean(DGOut[0, c].Value) == true)
                {
                    DGOut[1, c].Style.BackColor = Color.Green; ;
                    DGOut[1, c].Style.ForeColor = Color.Yellow;
                    DGOut[0, c].Value = 0;
                    Global.Dig_OutBit(port, (c - 8), false);
                }
                else
                {
                    DGOut[1, c].Style.BackColor = Color.Red; ;
                    DGOut[1, c].Style.ForeColor = Color.Yellow;
                    DGOut[0, c].Value = 1;
                    Global.Dig_OutBit(port, (c - 8), true);
                }

            }
         }

       
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tmrRead.Enabled = false;
            this.Close();
 
        }

        private void mnuChkDTC_Click(object sender, EventArgs e)
        {
            try
            {

                ////clsECU.Check_DTC(); 
                ////panel1.Visible = true;
                ////panel1.BringToFront(); 
                //int flag = Canlib.canMSG_STD;
                //int idOut = 0x6A8;
                //int idIn = 0x688;
                //byte[] msgIn = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                //int dlc = 0;
                //long time = 0;
                //////long timeout = 200;
                //int Counter = 0;
                //int myNewInt = 0;
                //string myHex1;
                //string myHex2;
                //string myHex3;

                //string myHex;

                //clsECU.Init_ECU();

                //byte[] tx_msg = new byte[8] { 0x03, 0x19, 0x02, 0xFF, 0x00, 0x00, 0x00, 0x00 };
                //Canlib.canStatus statusWrite = Canlib.canWrite(clsECU.handle, idOut, tx_msg, 4, flag);
                ////CheckStatus("canWrite", statusWrite);
                //mnuChkDTC.Enabled = false;

                //while (msgIn[1] != 0x77 && Counter < 60)
                //{
                //    //label1.Text = Counter.ToString("00");
                //    //Canlib.canStatus statusRead1 = Canlib.canReadWait(handle, out idIn, msgIn, out dlc, out flag, out time, timeout);
                //    Canlib.canStatus statusRead1 = Canlib.canReadSpecific(clsECU.handle, idIn, msgIn, out dlc, out flag, out time);
                //    //CheckStatus("canReadSpecific", statusRead1);
                //    //MessageBox.Show("Read DTC Output 1: \n" + ByteArrayToString(msgIn) + "\n    Counter:  " + Counter + "\n");                   
                //    Counter++;
                //    label12.Text = Counter.ToString("00");
                //    Thread.Sleep(300);   // Delay_InMliiS(500);

                //}

                //Canlib.canStatus statusRead = Canlib.canReadSpecific(clsECU.handle, idIn, msgIn, out dlc, out flag, out time);
                ////statusRead1 = Canlib.canReadSpecific(handle, idIn, msgIn, out dlc, out flag, out time);

                //myHex1 = msgIn[5].ToString("X2");
                //myHex2 = msgIn[6].ToString("X2");
                //myHex3 = msgIn[7].ToString("X2");
                //myHex = myHex1 + myHex2 + "-" + myHex3;
                //label13.Text = myHex;    // "Read DTC Output 1: \n" + "Timeout : " + Counter + "\n" + "DTC No : " + myHex; 


            }

            catch (Exception ex)
            {
                return;
            }
        }

        private void mnuChkDTCn_Click(object sender, EventArgs e)
        {

            //try
            //{
            // int flag = Canlib.canMSG_STD;
            //int idOut = 0x6A8;
            //int idIn = 0x688;
            //byte[] msgIn = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            //int dlc = 0;
            //long time = 0;
            //int Counter = 0;

            //string myHex1;
            //string myHex2;
            //string myHex3;

            //string myHex;

            //clsECU.Init_ECU();

            ////byte[] tx_msg = new byte[8] { 0x03, 0x19, 0x02, 0xFF, 0x00, 0x00, 0x00, 0x00 };
            ////Canlib.canStatus statusWrite = Canlib.canWrite(clsECU.handle, idOut, tx_msg, 4, flag);
              

            //byte[] tx_msg = new byte[8] { 0x03, 0x19, 0x01, 0xFF, 0x00, 0x00, 0x00, 0x00 };
            //Canlib.canStatus statusWrite = Canlib.canWrite(clsECU.handle, idOut, tx_msg, 4, flag);
            ////CheckStatus("canWrite", statusWrite);

            //while (msgIn[1] != 0x59 && Counter < 60)
            //{
            //    //label1.Text = Counter.ToString("00");
            //    Canlib.canStatus statusRead1 = Canlib.canReadSpecific(clsECU.handle, idIn, msgIn, out dlc, out flag, out time);
            //    //CheckStatus("canReadSpecific", statusRead1);
            //    Counter++;
            //    label12.Text = Counter.ToString("00");  
            //    Thread.Sleep(200);

            //}

            //Canlib.canStatus statusRead = Canlib.canReadSpecific(clsECU.handle, idIn, msgIn, out dlc, out flag, out time);

            //myHex1 = msgIn[5].ToString("X2");
            //myHex2 = msgIn[6].ToString("X2");


            ////myHex3 = msgIn[7].ToString();
            //myHex = myHex1 + myHex2;
            //int myDec = Convert.ToInt32(myHex, 16);
            //label13.Text = myDec.ToString();  
            ////MessageBox.Show("Read DTC Output 1: \n" + "Timeout : " + Counter + "\n" + "No. of DTCs  : " + myDec);
            //}
            //catch (Exception ex)
            //{
            //    return;
            //}

        }

        private void mnuDTCCls_Click(object sender, EventArgs e)
        {

        }
       //*********************************************

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    Gd.RowCount = 100;
        //    for (int i = 0; i < 100; i++)
        //    {
        //        Gd[0, i].Value = i + 1;
        //    }
        //    Gd[1, 0].Value = "ENGINE Speed";
        //    Gd[4, 0].Value = "rpm";
        //    Gd[1, 1].Value = "ENGINE COOLANT TEMP.";
        //    Gd[4, 1].Value = "deg";
        //    Gd[1, 2].Value = "COOLANT TEMP. SETPT";
        //    Gd[4, 2].Value = "deg C";
        //    Gd[1, 3].Value = "INLET MANIFOLD TEMP.";
        //    Gd[4, 3].Value = "deg";
        //    Gd[1, 4].Value = "RAW OUTSIDE TEKP. ";
        //    Gd[4, 4].Value = "deg.C";
        //    Gd[1, 5].Value = "RAW COOLANT TEMP.";
        //    Gd[4, 5].Value = "deg.C";
        //    Gd[1, 6].Value = "FUEL TEMP.";
        //    Gd[4, 6].Value = "deg.C";
        //    Gd[1, 7].Value = "RAW ENGINE OIL TEMP.";
        //    Gd[4, 7].Value = "deg.C";
        //    Gd[1, 8].Value = "RAW OIL PRESS.";
        //    Gd[4, 8].Value = "bar";
        //    Gd[1, 9].Value = "RAIL PRESS. SET PT";
        //    Gd[4, 9].Value = "bar";
        //    Gd[1, 10].Value = "RAW RAIL PRESS";
        //    Gd[4, 10].Value = "bar";
        //    Gd[1, 11].Value = "OIL PRESS. SET PT";
        //    Gd[4, 11].Value = "bar";
        //    Gd[1, 12].Value = "ATMS. PRESSURE";
        //    Gd[4, 12].Value = "Mbar";
        //    Gd[1, 13].Value = "INTAKE AIR PRESS";
        //    Gd[4, 13].Value = "mbar";
        //    Gd[1, 14].Value = "INTAKE THROTTLE SET PT";
        //    Gd[4, 14].Value = "%";
        //    Gd[1, 15].Value = "INTAKE THROTTLE CONTROL";
        //    Gd[4, 15].Value = "%";
        //    Gd[1, 16].Value = "MEASURED AIR MASS FLOW";
        //    Gd[4, 16].Value = "mg";
        //    Gd[1, 17].Value = "RAW AIR MASS-FLOW";
        //    Gd[4, 17].Value = "kg-hr";
        //    Gd[1, 18].Value = "SPARE-1";
        //    Gd[4, 18].Value = "UNIT";
        //    Gd[1, 19].Value = "SPARE-2";
        //    Gd[4, 19].Value = "UNIT";
        //    Gd[1, 20].Value = "SPARE-3";
        //    Gd[4, 20].Value = "UNIT";



        //}


        //private void CheckStatus(String action, Canlib.canStatus status)
        //{
        //    if (status != Canlib.canStatus.canOK)
        //    {
        //        String errorText = "";
        //        Canlib.canGetErrorText(status, out errorText);
        //        statusText.Text = action + " failed: " + errorText;
        //    }
        //    else
        //    {
        //        statusText.Text = action + " succeeded";
        //    }
        //}
        //private void btnConnect_Click_1(object sender, System.EventArgs e)
        //{
        //    Init_ECU();

        //    timer1.Start();

        //}
        ////private void Init_ECU()
        //{
        //    //Initializes Canlib
        //    Canlib.canInitializeLibrary();
        //    statusText.Text = "Canlib initialized";

        //    //Opens the channel selected in the "Channel" input box
        //    channel = 0;    // Convert.ToInt32(channelBox.Text);
        //    int hnd = Canlib.canOpenChannel(channel, Canlib.canOPEN_ACCEPT_VIRTUAL);

        //    CheckStatus("Open channel", (Canlib.canStatus)hnd); // .canStatus)hnd);
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
        //    CheckStatus("Setting bitrate to " + "500 kb/s", status);

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
        //    CheckStatus(" ECU Initialised,   &  Bus on ", status);
        //}

        //private void btnConnect_Click(object sender, EventArgs e)
        //{
        //    Init_ECU();

        //    timer1.Start();

        //}


        private void Read_ECUVal(Byte B2, Byte B3, Double CF, int Cnt)
        {
            //int flag = Canlib.canMSG_STD;
            //int idOut = 0x6A8;
            //int idIn = 0x688;
            //byte[] msgIn = new byte[8] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            //int dlc = 0;
            //long time = 0;
            ////long timeout = 200;
            //int Counter = Cnt;
            //if (CF == 0) CF = 1;

            //label1.Text = ECUCnt.ToString();


            //Byte[] MES = new Byte[8];
            //int myNewInt = 0;
            //string myHex1;
            //string myHex2;

            //string myHex;

            //Double l;

            //byte[] tx_msg = new byte[8] { 0x03, 0x22, B2, B3, 0x00, 0x00, 0x00, 0x00 };
            //Canlib.canStatus statusWrite = Canlib.canWrite(handle, idOut, tx_msg, 4, flag);
            //DelayMs(10); //await      Delay_InMliiS(5); //Thread.Sleep(5); //
            //while (msgIn[1] != 0x62)
            //{
            //    Canlib.canStatus statusRead1 = Canlib.canReadSpecific(handle, idIn, msgIn, out dlc, out flag, out time);
            //}

            //Gd[2, Cnt - 1].Value = ByteArrayToString(msgIn).ToUpper();
            //myHex1 = msgIn[4].ToString("X2");
            //myHex2 = msgIn[5].ToString("X2");
            //myHex = myHex1 + myHex2;
            //myNewInt = Convert.ToInt32(myHex, 16);
            //Gd[3, Cnt - 1].Value = Convert.ToDouble(myNewInt) * CF;
        }




        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }



        //private void btnDisConnect_Click(object sender, EventArgs e)
        //{
        //    Canlib.canStatus status = Canlib.canBusOff(handle);
        //    CheckStatus("Bus off", status);
        //    onBus = false;

        //    Canlib.canStatus statusCh = Canlib.canClose(handle);
        //    CheckStatus("Closing channel", statusCh);
        //    handle = -1;

        //}

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

        private void Chk_DTC_Click(object sender, EventArgs e)
        {

        }

        //private void btnClose_Click(object sender, EventArgs e)
        //{

        //    Canlib.canStatus status = Canlib.canBusOff(handle);
        //    CheckStatus("Bus off", status);
        //    onBus = false;

        //    Canlib.canStatus statusCh = Canlib.canClose(handle);
        //    CheckStatus("Closing channel", statusCh);
        //    handle = -1;

        //    this.Close();

        //}

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

        //private static void DelaynMs(int nMs)
        //{
        //    var durationTicks = (nMs * Stopwatch.Frequency);
        //    var sw = Stopwatch.StartNew();

        //    while (sw.ElapsedTicks < nMs)
        //    {

        //    }

        //}

        private void btnChkList_Click(object sender, EventArgs e)
        {

        }

        private void Load_ECU_Grid()
        {
            //Gd.RowCount = 100;
            //for (int i = 0; i < 100; i++)
            //{
            //    Gd[0, i].Value = i + 1;
            //}
            //Gd[1, 0].Value = "ENGINE Speed";            
            //Gd[4, 0].Value = "rpm";
            //Gd[1, 1].Value = "ENGINE COOLANT TEMP.";
            //Gd[4, 1].Value = "deg";
            //Gd[1, 2].Value = "COOLANT TEMP. SETPT";
            //Gd[4, 2].Value = "deg C";
            //Gd[1, 3].Value = "INLET MANIFOLD TEMP.";
            //Gd[4, 3].Value = "deg";
            //Gd[1, 4].Value = "RAW OUTSIDE TEKP. ";
            //Gd[4, 4].Value = "deg.C";
            //Gd[1, 5].Value = "RAW COOLANT TEMP.";
            //Gd[4, 5].Value = "deg.C";
            //Gd[1, 6].Value = "FUEL TEMP.";
            //Gd[4, 6].Value = "deg.C";
            //Gd[1, 7].Value = "RAW ENGINE OIL TEMP.";
            //Gd[4, 7].Value = "deg.C";
            //Gd[1, 8].Value = "RAW OIL PRESS.";
            //Gd[4, 8].Value = "bar";
            //Gd[1, 9].Value = "RAIL PRESS. SET PT";
            //Gd[4, 9].Value = "bar";
            //Gd[1, 10].Value = "RAW RAIL PRESS";
            //Gd[4, 10].Value = "bar";
            //Gd[1, 11].Value = "OIL PRESS. SET PT";
            //Gd[4, 11].Value = "bar";
            //Gd[1, 12].Value = "ATMS. PRESSURE";
            //Gd[4, 12].Value = "Mbar";
            //Gd[1, 13].Value = "INTAKE AIR PRESS";
            //Gd[4, 13].Value = "mbar";
            //Gd[1, 14].Value = "INTAKE THROTTLE SET PT";
            //Gd[4, 14].Value = "%";
            //Gd[1, 15].Value = "INTAKE THROTTLE CONTROL";
            //Gd[4, 15].Value = "%";
            //Gd[1, 16].Value = "MEASURED AIR MASS FLOW";
            //Gd[4, 16].Value = "mg";
            //Gd[1, 17].Value = "RAW AIR MASS-FLOW";
            //Gd[4, 17].Value = "kg-hr";
            //Gd[1, 18].Value = "SPARE-1";
            //Gd[4, 18].Value = "UNIT";
            //Gd[1, 19].Value = "SPARE-2";
            //Gd[4, 19].Value = "UNIT";
            //Gd[1, 20].Value = "SPARE-3";
            //Gd[4, 20].Value = "UNIT";
        

        }

       

        private void timer1_Tick_1(object sender, System.EventArgs e)
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

       

       

     
       
      
      

      
      
      

       //***************************
       
    }
}

//*****************************






 

