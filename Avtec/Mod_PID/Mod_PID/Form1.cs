using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;
using System.Diagnostics;
using System.IO.Ports;
using System.IO; 
namespace Mod_PID
{
    public partial class Form1 : Form
    {
        public static Parity p1, p2, p3, p4, p5;
        public static StopBits stopbt1, stopbt2, stopbt3, stopbt4, stopbt5;
        public static string comn1, comn2, comn3, comn4, comn5;
        public static int Bd1, Bd2, Bd3, Bd4, Bd5;
        public static int Addr;
        public static string mod1, mod2, mod3, mod4, mod5;
        public Boolean flg_mod = false;
        public int modcnt = 0;
        public int modcn = 0;
        public int cnt = 0, cnt1 = 0, cnt2 = 0;
        
        
        public int pollStart;
        public Byte Id;
        public ushort InstID = 1;
        double l1 = 00.00;
        double l2 = 00.00;
        double l3 = 00.00;
        double l4 = 00.00;
        double l5 = 00.00;
        Modbus mb = new Modbus();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartPoll_1();
            //StartPoll_2();
            //StartPoll_3();
            //StartPoll_4();
            //StartPoll_5();
            tmrmode.Start();
        }
        public void StartPoll_1()
        {
            try
            {
                //if (Global.sysIn[68] == "TRUE")
                //if (chk_1.Checked)
                //{
                    comn1 = "COM10"; ///Global.sysIn[69];
                    Bd1 = 9600;    //int.Parse(Global.sysIn[70]);
                    p1 = (Parity)Enum.Parse(typeof(Parity),"Odd");//
                    stopbt1 = (StopBits)Enum.Parse(typeof(StopBits), "1");
                    Addr = Convert.ToInt16("138");
                    if (mb.Open(comn1, Bd1, 8, p1, stopbt1))
                    {
                       PollFunction_1();
                    }
                //}
                //else
                //{
                //    MessageBox.Show("Please Select T_Intclr_Out");
                //    return;
                //}
            }
            catch (Exception rxx)
            {
                return; 
                //MessageBox.Show("Instrument - 1 Not Connected", rxx.Message);
            }
        }

        public void StartPoll_2()
        {
            try
            {
               // if (Global.sysIn[61] == "TRUE")
                //if (chk_2.Checked)
                //{
                    comn2 = "COM16"; //Global.sysIn[56];
                    Bd2 = 9600;   //int.Parse(Global.sysIn[57]);
                    p2 = (Parity)Enum.Parse(typeof(Parity),"Odd");
                    stopbt2 = (StopBits)Enum.Parse(typeof(StopBits), "1");
                    Addr = Convert.ToInt16("138");
                    if (mb.Open(comn2, Bd2, 8, p2, stopbt2))
                    {
                       PollFunction_2();
                    }
                //}
                //else
                //{
                //    MessageBox.Show("Please Select P_Coolent_In");
                //    return;
                //}
            }
            catch (Exception ex)
            {
               return;// MessageBox.Show("Instrument - 2 Not Connected", ex.Message);
            }
        }

        public void StartPoll_3()
        {
            try
            {
                //if (sysIn[74] == "TRUE")
                //if (chk_3.Checked)
                //{
                    comn3 = "COM17";    //Global.sysIn[75];
                    Bd3 = 9600;      //int.Parse(Global.sysIn[76]);
                    p3 = (Parity)Enum.Parse(typeof(Parity), "Odd"); //Global.sysIn[77]);
                    stopbt3 = (StopBits)Enum.Parse(typeof(StopBits), "1");
                    Addr = Convert.ToInt16("138");
                    if (mb.Open(comn3, Bd3, 8, p3, stopbt3))
                    {
                        PollFunction_3();
                    }
                //}
                //else
                //{
                //    MessageBox.Show("Please Select T_Fuel_Tank");
                //    return;
                //}
            }
            catch (Exception ex)
            {
                return; // MessageBox.Show("Instrument - 3 Not Connected", ex.Message);
            }
        }

        public void StartPoll_4()
        {
            try
            {
              //  if (Global.sysIn[80] == "TRUE")
                //if (chk_4.Checked)
                //{
                    comn4 = "COM18";   //Global.sysIn[81];
                    Bd4 = 9600;     //int.Parse(Global.sysIn[82]);
                    p4 = (Parity)Enum.Parse(typeof(Parity), "Odd" );//Global.sysIn[83]
                    stopbt4 = (StopBits)Enum.Parse(typeof(StopBits), "1");
                    Addr = Convert.ToInt16("138");
                    if (mb.Open(comn4, Bd4, 8, p4, stopbt4))
                    {
                        PollFunction_4();
                    }
                //}
                //else
                //{
                //    MessageBox.Show("Please Select T_Coolent_In");
                //    return;
                //}
            }
            catch (Exception ex)
            {
                return; // MessageBox.Show("Instrument - 4 Not Connected", ex.Message);
            }
        }

        public void StartPoll_5()
        {
            try
            {
                ////if (Global.sysIn[86] == "TRUE")
                //if (chk_5.Checked)
                //{
                    comn5 = "COM19";     //Global.sysIn[87];
                    Bd5 = 9600;       //int.Parse(Global.sysIn[88]);
                    p5 = (Parity)Enum.Parse(typeof(Parity),"Odd" );  // Global.sysIn[89]
                    stopbt5 = (StopBits)Enum.Parse(typeof(StopBits), "1");
                    Addr = Convert.ToInt16("138");
                    if (mb.Open(comn5, Bd5, 8, p5, stopbt5))
                    {
                       PollFunction_5();
                    }
                //}
                //else
                //{
                //    MessageBox.Show("Please Select Coolent_Heater_Tank");
                //    return;
                //}
            }
            catch (Exception ex)
            {
                return; // MessageBox.Show("Instrument - 5 Not Connected", ex.Message);
            }
        }

        private void chk_1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_1.Checked)
            {
                txt_1.Enabled = true;
               // chk_2.Checked = false;
                chk_2.CheckState = CheckState.Unchecked;
                chk_3.CheckState = CheckState.Unchecked;
                chk_4.CheckState = CheckState.Unchecked;
                chk_5.CheckState = CheckState.Unchecked;
            }
            else if (!chk_1.Checked)
            {
                txt_1.Enabled = false;
            }
        }
        private void chk_2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_2.Checked)
            {
                txt_2.Enabled = true;
                chk_1.CheckState = CheckState.Unchecked;
                chk_3.CheckState = CheckState.Unchecked;
                chk_4.CheckState = CheckState.Unchecked;
                chk_5.CheckState = CheckState.Unchecked;
            }
            else if (!chk_2.Checked)
            {
                txt_2.Enabled = false;
            }
        }
        private void chk_3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_3.Checked)
            {
                txt_3.Enabled = true;
                chk_2.CheckState = CheckState.Unchecked;
                chk_1.CheckState = CheckState.Unchecked;
                chk_4.CheckState = CheckState.Unchecked;
                chk_5.CheckState = CheckState.Unchecked;
            }
            else if (!chk_3.Checked)
            {
                txt_3.Enabled = false;
            }
        }
        private void chk_4_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_4.Checked)
            {
                txt_4.Enabled = true;
                chk_2.CheckState = CheckState.Unchecked;
                chk_3.CheckState = CheckState.Unchecked;
                chk_1.CheckState = CheckState.Unchecked;
                chk_5.CheckState = CheckState.Unchecked;
            }
            else if (!chk_4.Checked)
            {
                txt_4.Enabled = false;
            }
        }
        private void chk_5_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_5.Checked)
            {
                txt_5.Enabled = true;
                chk_2.CheckState = CheckState.Unchecked;
                chk_3.CheckState = CheckState.Unchecked;
                chk_4.CheckState = CheckState.Unchecked;
                chk_1.CheckState = CheckState.Unchecked;
            }
            else if (!chk_5.Checked)
            {
                txt_5.Enabled = false;
            }
        }
        private void btn_1_Click(object sender, EventArgs e)
        {
            if (chk_1.Checked)
            {
               // mb.sp.Close();
              // StartPoll_1();
                modcnt = 1;
                tmrmode.Start();
                comn1 = "COM10"; ///Global.sysIn[69];
                Bd1 = 9600;    //int.Parse(Global.sysIn[70]);
                p1 = (Parity)Enum.Parse(typeof(Parity), "Odd");//
                stopbt1 = (StopBits)Enum.Parse(typeof(StopBits), "1");
                Addr = Convert.ToInt16("138");
                if (mb.Open(comn1, Bd1, 8, p1, stopbt1))
                {
                   // PollFunction_1();
                }
                    flg_mod = true;
                    byte address = Convert.ToByte(1);
                    ushort start = Convert.ToUInt16(0);
                    short[] value = new short[1];
                    value[0] = Convert.ToInt16(txt_1.Text);
                    try
                    {
                        while (!mb.SendFc16(address, start, (ushort)1, value)) ;
                        flg_mod = false;
                        mb.sp.Close();
                    }
                catch (Exception err)
                {
                    //statusStrip.Text = "Error in write function: " + err.Message;
                    //DoGUIStatus("Error in write function: " + err.Message);
                    MessageBox.Show("Please Write Coorect Value");
                }
            }

        }
        private void btn_2_Click(object sender, EventArgs e)
        {
            if (chk_2.Checked)
            {
                modcnt = 2;
                //StartPoll_2();
                tmrmode.Start();
                comn2 = "COM16"; //Global.sysIn[56];
                Bd2 = 9600;   //int.Parse(Global.sysIn[57]);
                p2 = (Parity)Enum.Parse(typeof(Parity), "Odd");
                stopbt2 = (StopBits)Enum.Parse(typeof(StopBits), "1");
                Addr = Convert.ToInt16("138");
                if (mb.Open(comn2, Bd2, 8, p2, stopbt2))
                {
                   // PollFunction_2();
                }
                flg_mod = true;
                byte address = Convert.ToByte(2);
                ushort start = Convert.ToUInt16(0);
                short[] value = new short[1];
                value[0] = Convert.ToInt16(txt_2.Text);
                try
                {
                    while (!mb.SendFc16(address, start, (ushort)1, value)) ;
                    flg_mod = false;
                    mb.sp.Close();
                }
                catch (Exception err)
                {
                    //statusStrip.Text = "Error in write function: " + err.Message;
                    //DoGUIStatus("Error in write function: " + err.Message);
                    MessageBox.Show("Please Write Coorect Value");
                }
            }

        }
        private void btn_3_Click(object sender, EventArgs e)
        {
            if (chk_3.Checked)
            {
                modcnt = 3;
              
                tmrmode.Start();
                //StartPoll_3();
                comn3 = "COM17";    //Global.sysIn[75];
                Bd3 = 9600;      //int.Parse(Global.sysIn[76]);
                p3 = (Parity)Enum.Parse(typeof(Parity), "Odd"); //Global.sysIn[77]);
                stopbt3 = (StopBits)Enum.Parse(typeof(StopBits), "1");
                Addr = Convert.ToInt16("138");
                if (mb.Open(comn3, Bd3, 8, p3, stopbt3))
                {
                    //PollFunction_3();
                }
                flg_mod = true;
                byte address = Convert.ToByte(3);
                ushort start = Convert.ToUInt16(0);
                short[] value = new short[1];
                value[0] = Convert.ToInt16(txt_3.Text);
               
                try
                {
                    while (!mb.SendFc16(address, start, (ushort)1, value)) ;
                    flg_mod = false;
                    mb.sp.Close();
                }
                catch (Exception err)
                {
                    //statusStrip.Text = "Error in write function: " + err.Message;
                    //DoGUIStatus("Error in write function: " + err.Message);
                    MessageBox.Show("Please Write Coorect Value");
                }
            }
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            if (chk_4.Checked)
            {
              //  StartPoll_4();
                modcnt = 4;

                tmrmode.Start();
                comn4 = "COM18";   //Global.sysIn[81];
                Bd4 = 9600;     //int.Parse(Global.sysIn[82]);
                p4 = (Parity)Enum.Parse(typeof(Parity), "Odd");//Global.sysIn[83]
                stopbt4 = (StopBits)Enum.Parse(typeof(StopBits), "1");
                Addr = Convert.ToInt16("138");
                if (mb.Open(comn4, Bd4, 8, p4, stopbt4))
                {
                   // PollFunction_4();
                }
                flg_mod = true;
                byte address = Convert.ToByte(4);
                ushort start = Convert.ToUInt16(0);
                short[] value = new short[1];
                value[0] = Convert.ToInt16(txt_4.Text);
              
                try
                {
                    while (!mb.SendFc16(address, start, (ushort)1, value)) ;
                    flg_mod = false;
                    mb.sp.Close();
                }
                catch (Exception err)
                {
                    //statusStrip.Text = "Error in write function: " + err.Message;
                    //DoGUIStatus("Error in write function: " + err.Message);
                    MessageBox.Show("Please Write Coorect Value");
                }
            }
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            if (chk_5.Checked)
            {
               // StartPoll_5();
                modcnt = 5;
                tmrmode.Start();
                comn5 = "COM19";     //Global.sysIn[87];
                Bd5 = 9600;       //int.Parse(Global.sysIn[88]);
                p5 = (Parity)Enum.Parse(typeof(Parity), "Odd");  // Global.sysIn[89]
                stopbt5 = (StopBits)Enum.Parse(typeof(StopBits), "1");
                Addr = Convert.ToInt16("138");
                if (mb.Open(comn5, Bd5, 8, p5, stopbt5))
                {
                   // PollFunction_5();
                }

                flg_mod = true;
                byte address = Convert.ToByte(5);
                ushort start = Convert.ToUInt16(0);
                short[] value = new short[1];
                value[0] = Convert.ToInt16(txt_5.Text);
               
                try
                {
                    while (!mb.SendFc16(address, start, (ushort)1, value)) ;
                    flg_mod = false;
                    mb.sp.Close();
                }
                catch (Exception err)
                {
                    //statusStrip.Text = "Error in write function: " + err.Message;
                    //DoGUIStatus("Error in write function: " + err.Message);
                    MessageBox.Show("Please Write Coorect Value");
                }
            }
        }

        public void PollFunction_1()
        {
            ushort InstID;
            short[] values = new short[Convert.ToInt32(1)];

            //int pollStart = Convert.ToUInt16(txtStartAddr.Text); // 138;
            string itemString;
            try
            {
                if (flg_mod == false)
                {
                    pollStart = 138;
                }
                else
                {
                    pollStart = 0;
                }
                InstID = 1; //Convert.ToUInt16(Global.sysIn[72]);

                mb.Open(comn1, Bd1, 8, p1, stopbt1);

                while (!mb.SendFc3(Convert.ToByte(InstID), Convert.ToUInt16(pollStart), 1, ref values) == false)
                {
                    itemString = values[0].ToString();
                    l1 = Double.Parse(itemString) / 100;                   
                    mb.sp.Close();
                    if (itemString != "null")
                        goto a;
                }
            a: if ((pollStart == 138))
                {
                   // Global.GenData[87] = l1.ToString("00.0");
                    lbl_1.Text = l1.ToString("0.00");                   
                }
                else if ((pollStart == 0))
                {
                   txt_1.Text = l1.ToString("0.00");
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error In PollStart_1", ex.Message);
                return;
            }
        }

        public void PollFunction_2()
        {
            ushort InstID;
            short[] values = new short[Convert.ToInt32(1)];
            //int pollStart = Convert.ToUInt16(txtStartAddr.Text); // 138;
            string itemString;
            try
            {
                if (flg_mod == false)
                {
                    pollStart = 138;
                }
                else
                {
                    pollStart = 0;
                }
                InstID = 2; //Convert.ToUInt16(Global.sysIn[72]);

               // mb_2.Open(comn2, Bd2, 8, p2, stopbt3);
                mb.Open(comn2, Bd2, 8, p2, stopbt2);
              //  while (!mb_2.SendFc3(Convert.ToByte(InstID), Convert.ToUInt16(pollStart), 1, ref values) == false) 
                while (!mb.SendFc3(Convert.ToByte(InstID), Convert.ToUInt16(pollStart), 1, ref values) == false) // pollStart
                {
                    itemString = values[0].ToString();
                    l2 = Double.Parse(itemString) / 100;                   
                    //mb_2.Close();
                   // mb.Close();
                    // if (l != 0)
                  
                    if (itemString != "null")
                        goto a;
                }
            a: if ((pollStart == 138))
                {
                   // Global.GenData[88] = l2.ToString("0.000");
                    lbl_2.Text = l2.ToString("0.00");
                }
                else if ((pollStart == 0))
                {
                   // mod2 = l2.ToString("00.0");
                    txt_2.Text = l2.ToString("00.0");

                }
                mb.sp.Close();
            }
            catch (Exception ex)
            {
                return;// MessageBox.Show("Error In PollStart_2", ex.Message);
            }
        }

        public void PollFunction_3()
        {
            ushort InstID;
            short[] values = new short[Convert.ToInt32(1)];
            //int pollStart = Convert.ToUInt16(txtStartAddr.Text); // 138;
            string itemString;
            try
            {
                if (flg_mod == false)
                {
                    pollStart = 138;
                }
                else
                {
                    pollStart = 0;
                }
                InstID = 3; //Convert.ToUInt16(Global.sysIn[72]);

                //mb_3.Open(comn3, Bd3, 8, p3, stopbt3);
                mb.Open(comn3, Bd3, 8, p3, stopbt3);
              //  while (!mb_3.SendFc3(Convert.ToByte(InstID), Convert.ToUInt16(pollStart), 1, ref values) == false)
                while (!mb.SendFc3(Convert.ToByte(InstID), Convert.ToUInt16(pollStart), 1, ref values) == false) // pollStart
                {
                    itemString = values[0].ToString();
                    l3 = Double.Parse(itemString) / 10;
                    //mb_3.Close();
                   // mb.Close();
                    // if (l != 0 )
                    mb.sp.Close();
                    if (itemString != "null")
                        goto a;
                    else
                        return;
                }
            a: if ((pollStart == 138))
                {
                    //Global.GenData[89] = l3.ToString("00.0");
                    lbl_3.Text = l3.ToString("00.0");
                }
                else if ((pollStart == 0))
                {
                   // mod3 = l3.ToString("00.0");
                    txt_3.Text = l3.ToString("00.0");
                }
            }
            catch (Exception ex)
            {
                return;// MessageBox.Show("Error In PollStart_3", ex.Message);
            }
        }

        public void PollFunction_4()
        {
            ushort InstID;
            short[] values = new short[Convert.ToInt32(1)];
            //int pollStart = Convert.ToUInt16(txtStartAddr.Text); // 138;
            string itemString;
            try
            {
                if (flg_mod == false)
                {
                    pollStart = 138;
                }
                else
                {
                    pollStart = 0;
                }
                InstID = 4; //Convert.ToUInt16(Global.sysIn[72]);

                //mb_4.Open(comn4, Bd4, 8, p4, stopbt4);
                mb.Open(comn4, Bd4, 8, p4, stopbt4);
                //while (!mb_4.SendFc3(Convert.ToByte(InstID), Convert.ToUInt16(pollStart), 1, ref values) == false)
                while (!mb.SendFc3(Convert.ToByte(InstID), Convert.ToUInt16(pollStart), 1, ref values) == false) // pollStart
                {
                    itemString = values[0].ToString();
                    l4 = Double.Parse(itemString) / 10;
                    //mb_4.Close();
                    //mb.Close();
                    //if (l != 0 ) 
                    mb.sp.Close();
                    if (itemString != "null")
                        goto a;
                }
            a: if ((pollStart == 138))
                {
                    //Global.GenData[90] = l4.ToString("00.0");
                    lbl_4.Text = l4.ToString("00.0");
                }
                else if ((pollStart == 0))
                {
                    //mod4 = l4.ToString("00.0");
                    txt_4.Text = l4.ToString("00.0");
                }
            }
            catch (Exception ex)
            {
                return;//  MessageBox.Show("Error In PollStart_4", ex.Message);
            }
        }

        public void PollFunction_5()
        {
            ushort InstID;
            short[] values = new short[Convert.ToInt32(1)];
            //int pollStart = Convert.ToUInt16(txtStartAddr.Text); // 138;
            string itemString;
            try
            {
                if (flg_mod == false)
                {
                    pollStart = 138;
                }
                else
                {
                    pollStart = 0;
                }
                InstID = 5; //Convert.ToUInt16(Global.sysIn[72]);

                //mb_5.Open(comn5, Bd5, 8, p4, stopbt4);
                mb.Open(comn5, Bd5, 8, p4, stopbt4);

                //while (!mb_5.SendFc3(Convert.ToByte(InstID), Convert.ToUInt16(pollStart), 1, ref values) == false) 
                while (!mb.SendFc3(Convert.ToByte(InstID), Convert.ToUInt16(pollStart), 1, ref values) == false) // pollStart
                {
                    itemString = values[0].ToString();
                    l5 = Double.Parse(itemString) / 10;
                    //mb_5.Close();
                    //mb.Close();
                    //if (l != 0)
                    mb.sp.Close();
                    if (itemString != "null")
                    goto a; //else return;
                }
            a: if ((pollStart == 138))
                {
                    //Global.GenData[91] = l5.ToString("00.0");
                    lbl_5.Text = l5.ToString("00.0");
                }
                else if ((pollStart == 0))
                {
                    //mod5 = l5.ToString("00.0");
                    txt_5.Text = l5.ToString("00.0");
                }
            }
            catch (Exception ex)
            {
                return;//  MessageBox.Show("Error In PollStart_5", ex.Message);
            }
        }

        private void tmrmode_Tick(object sender, EventArgs e)
        {
            try
            {
                String TotalStr = null;

                PollFunction_1();

                TotalStr = l1.ToString("00.00");

                string path = Application.StartupPath + "\\ModBus.txt";
                FileStream fs1 = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fs1);
                writer.Write("");
                writer.Write(TotalStr);
                writer.Close();

                //switch (modcnt)
                //{
                //    case 1:
                //        PollFunction_1();
                //        break;
                //    case 2:
                //        PollFunction_2();
                //        break;
                //    case 3:
                //        PollFunction_3();
                //        break;
                //    case 4:
                //        PollFunction_4();
                //        break;
                //    case 5:
                //        PollFunction_5();
                //        break;
                //}
                //if (modcnt > 5)
                //{
                //    String TotalStr = null;
                //    if (cnt2 >= 100) cnt2 = 1; cnt2++;
                //    modcnt = 1;

                //    TotalStr = l1 + ", " + l2 + ", " + l3 + ", " + l4 + ", " + l5 + ", " + cnt2.ToString();
                //    string path = Application.StartupPath + "\\ModBus.txt";
                //    FileStream fs1 = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                //    StreamWriter writer = new StreamWriter(fs1);
                //    writer.Write("");
                //    writer.Write(TotalStr);
                //    writer.Close();
                //}
                //else
                //{
                //    modcnt++;
                //}
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); 
           
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {

                //if (chk_1.Checked) StartPoll_1();
                //if (chk_2.Checked) StartPoll_2();
                //if (chk_3.Checked) StartPoll_3();
                //if (chk_4.Checked) StartPoll_4();
                //if (chk_5.Checked) StartPoll_5();
                //if ((chk_5.Checked) || (chk_4.Checked) || (chk_3.Checked) || (chk_2.Checked) || (chk_1.Checked))
                //{
                    tmrmode.Start();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check instrument is in working condition");
            }
        }
    }
}
