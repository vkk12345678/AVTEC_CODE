using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading; 
using System.Text.RegularExpressions;


namespace Logger
{
    public partial class frmSmoke : Form
    {
        private SerialPort smkPort = new SerialPort();
        private Boolean flg_437 = false;
        private Boolean flg_415 = false;
        private Boolean flg_smkCal = false;
        private Boolean flg_smkTest = false;
        private String RxString = "";
        private StringBuilder str = new StringBuilder();
        private int smk437 = 00;
        private int smk415 = 00;
        //***********************************
        private int Vol = 1000;
        private Double Tm = 6.0;
        private Boolean StartEngine = false;
        private Double SmkVal;
     


        public frmSmoke()
        {
            InitializeComponent();
            //smkPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);

        }


        private void Init_SmkPort()
        {

            try
            {
                smkPort.Close();
                smkPort.PortName = Global.sysIn[40];
                
                if (smkPort.IsOpen == true) smkPort.Dispose();
                smkPort.PortName = Global.sysIn[40];
                smkPort.BaudRate = int.Parse("9600");
                smkPort.DataBits = int.Parse("8");
                //smkPort.ReadTimeout = 20;
                smkPort.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                smkPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                if (smkPort.IsOpen == false)
                {
                    smkPort.Dispose();
                    //smkPort.PortName = Global.sysIn[40];
                    smkPort.Open();
                    if (Global.smk == 1)
                        smkPort.Write(" SEX1");
                    else if (Global.smk == 2)
                        smkPort.Write(" SEX2");

                    Global.SmkError = "Smoke Meter Ready ......";
                    Global.SmkVal = 0.000;
                }
                else
                {
                    Global.SmkError = "Smoke Meter Not Connected......";
                    Global.SmkVal = 0.000;   
                }

            }
            catch 
            {
                //MessageBox.Show("Error Code:- 15001 " + ex.Message);
              
            }
        }

        private void btnSmk1_Click(object sender, EventArgs e)
        {
            flg_437 = true;
            flg_smkCal = true;
            flg_smkTest = false;
            smkPort.Write("V");
            Init_SmkPort();
        }
        //private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    RxString = "";
        //    if (!smkPort.IsOpen) smkPort.Open();
        //    RxString = smkPort.ReadExisting();
        //    if (RxString == "V?")
        //    {
        //        RxString = "";
        //        smkPort.Write("T");
        //    }
        //    if (RxString == "T?")
        //    {
        //        RxString = "";
        //        smkPort.Write("P");
        //        Global.DelayMs(20);
        //       // label12.Text = RxString.ToString();
        //        RxString = "";
        //        smkPort.Write("K");
        //        Global.DelayMs(20);
        //        label11.Text = RxString.ToString();
        //        RxString = "";
        //        smkPort.Write("E");
        //        Global.DelayMs(20);
        //        label10.Text = RxString.ToString();
        //        RxString = "";
        //        smkPort.Write("O");
        //        Global.DelayMs(20);
        //        label20.Text = RxString.ToString();
        //        Global.SmkVal = Convert.ToDouble(label20.Text);
        //    }
        //    //label13.Text = RxString.ToString();   

        //}






        private void tmrSmoke_Tick(object sender, EventArgs e)
        {
            string buf;
            buf = smkPort.ReadExisting();
            if ((flg_437 == true) && (flg_smkCal = true))
            {
                if (buf.Substring(1, 2) == "V?")
                {
                    flg_smkCal = false;
                    flg_smkTest = true;
                    smkPort.Write("T");
                }
            }
            else if ((flg_437 == true) && (flg_smkTest = true))
            {
                if (buf.Substring(1, 2) == "T?")
                {
                    flg_smkCal = false;
                    flg_smkTest = false;

                    //Write_Opacity_Values();
                }
            }


            else if (flg_415 == true)
            {

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //public void Read_Smoke()
        //{
        //    Vol = Convert.ToInt16(textBox2.Text);
        //    Tm = Convert.ToDouble(textBox1.Text);
          
        //    smk415 = 0;
        //    Init_SmkPort();
        //    tmr415.Start();          
                
        //}
        private void btnSMK2_Click(object sender, EventArgs e)
        {

            Global.Init_SmokePort();
            Global.flg_smokeStart = true;
               
        }

        private void tmr415_Tick(object sender, EventArgs e)
        {
        //    string B = ""; // ("^(B)");
        //    string C = ("^(C)");
        //    String Buf = "";

        //    smk415 += 31;
        //    label1.Text = smk415.ToString("00");
        //    if (smk415 >= 30) tmr415.Stop();
        //    //if (!smkPort.IsOpen) smkPort.Open();
        //    //RxString   = smkPort.ReadExisting();
        //    Global.DelayMs(400);
        //    Init_SmkPort();
        //   // label2.Text = smkPort.ReadExisting(); //RxString;

        //    switch (smk415)
        //    {
        //        case 1:
        //            //B = " SREM";
        //            smkPort.Write(" SREM");
        //            //smkPort.Write(B);
        //            //smkPort.Write(B + " SREM" + C);
        //            label19.Text = "Smoke Meter Remote Mode";
        //            Global.SmkError = "Smoke Meter Ready...";
        //            break;
        //        case 2:
        //            smkPort.Write(" SRDY");
        //            Global.SmkError = "Smoke Meter Ready...";
        //            break;
        //        case 3:
        //            label19.Text = "Smoke Meter Remote Mode";
        //            if (Rd1.Checked == true)
        //            {
        //                smkPort.Write(" EMZY Z 6.0 1");
        //            }
        //            else
        //            {
        //                smkPort.Write(" EMZY V" + Vol + " 1");
        //            }
        //            Global.SmkError = "Smoke Meter Busy..";
        //            break;
        //        case 5:
        //            smkPort.Write(" SMES");
        //            label19.Text = "Meter is Ready for first Sampling";
        //            Global.SmkError = "Smoke Meter Is Busy .....";
        //            break;
        //        case 23:
        //            smkPort.Write(" AFSN");
        //            label19.Text = "Meter is Reading Value";
        //            Global.DelayMs(300);
        //            Buf = smkPort.ReadExisting();
        //            Global.SmkError = Buf.Substring(7, 1);
        //            if (Global.SmkError == "0")
        //            {
        //                Global.SmkVal = Convert.ToDouble(Buf.Substring(20, 5));
        //                label20.Text = Global.SmkVal.ToString();
        //                Global.GenData[101] = Global.SmkVal.ToString();
        //                Global.SmkError = " Smoke Over.." + ":" + Global.SmkError;
        //                label19.Text = Global.SmkError;
        //                smkPort.Close();
        //                smkPort.Dispose(); 
        //            }
        //            else
        //            {
        //                Global.SmkVal = 0.000;
        //                Global.SmkError = " Smoke Over.." + ":" + Global.SmkError;
        //                label19.Text = Global.SmkError;
        //                smkPort.Close();
        //                smkPort.Dispose();
        //                btnSMK2.Enabled = true;
        //                tmr415.Stop();
        //            }
        //            break;
        //        case 24:

        //            Global.SmkVal = Convert.ToDouble(label20.Text);
        //            label20.Text = Global.SmkVal.ToString();
        //            Global.GenData[101] = Global.SmkVal.ToString();
        //            Global.SmkError = Global.SmkError;
        //            label19.Text = Global.SmkError;
        //            btnSMK2.Enabled = true;
        //            tmr415.Stop();
        //            break;
        //        case 30:

        //            label19.Text = " Smoke Over ";
        //            Global.SmkError = " Smoke Over.." + ":" + Global.SmkError;
        //            btnSMK2.Enabled = true;
        //            tmr415.Stop();
        //            break;

        //    }
        //    //label2.Text = smkPort.ReadExisting();

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
           
        }

        private void frmSmoke_Load(object sender, EventArgs e)
        {
            label8.Text = Global.SmkEr2;
            label9.Text = Global.SmkEr1;
            label10.Text = Global.SmkEr3;
            label1.Text = Global.GenData[107];
            label4.Text = Global.E_setpt4;
            label13.Text = Global.SmkEr5; 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Global.Init_SmokePort(); 
            button1.Enabled = false; 
 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Global.flg_smokeStart = true;
            Global.S_Add = 0;
            timer1.Start(); 
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Global.S_Add++;
                label12.Text = Global.S_Add.ToString();
                if (Global.flg_smokeStart == true)
                {
                    if (Global.S_Add == 3)
                        Global.smkPort.Write(" SMES");
                    if (Global.S_Add == 18)
                    {
                        Global.smkPort.Write(" AFSN");
                        Thread.Sleep(200);
                        string buffer = (Global.smkPort.ReadExisting());
                        Global.smkbuffer = buffer;
                        Global.flg_smokeStart = false;
                        Global.GenData[101] = Global.smkbuffer.Substring((buffer.Length - 7), 6);
                        Global.SmkVal = Double.Parse(Global.GenData[101]);
                        label1.Text = Global.GenData[101];
                        Global.S_Add = 0;
                        timer1.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
        } 
        
   
           
    }
} 
