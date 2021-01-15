using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using MySql.Data;
using MySql.Data.MySqlClient;
using Logger;

namespace ConfigurationManager
{
    public partial class PortConfigurationSetting : Form
    {
        //PortConfigurationSetting portsett = new PortConfigurationSetting();
        //IPortConfiguration portconfiguration = new PortConfigurationBL();
       // #region Adam Module
        int Rw = 0;
        SerialPort msADAM = new SerialPort();
        ListViewItem m_firstItem = new ListViewItem();
        String PATH = Application.StartupPath + "\\";
        //String CmInst = "COM";
        String CmAdam = "COM";
        String ServerNm = System.Environment.MachineName;
        int I_Add = 0;
        String S_Out = "";
        String N_Name = "";
        int Adx = 0;
        String[] SyspArr = new string[75];
       

        
        DataTable dtDevicePortConfig = new DataTable();
        SerialPort msPort = new SerialPort();
        //InitializeSerialPort initializeSerialPort = new InitializeSerialPort();
        bool blndoesnotContainsSpecialCharacters = false;
        //IModbus modbus1 = new Modbus();
        private readonly SerialPort _smkPort = new SerialPort();
        SerialPort smokePort = new SerialPort();


        System.Windows.Forms.TextBox[] ArrVal = new
        System.Windows.Forms.TextBox[32];
        public PortConfigurationSetting()
        {
            InitializeComponent();
        }

        public static DateTime DelayMs(int nMs)
        {

            System.DateTime ThisMoment = System.DateTime.Now;
            System.TimeSpan duration = new System.TimeSpan(0, 0, 0, 0, nMs);
            System.DateTime AfterWards = ThisMoment.Add(duration);
            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = System.DateTime.Now;
            }
            return System.DateTime.Now;


        }
        private void LoadListbox()
        {
            try
            {
                int i = 1;
                string[] ports = SerialPort.GetPortNames();
                if (tvCOM.Nodes.Count != 0) tvCOM.Nodes.Clear();

                tvCOM.Nodes.Add("R", "PORTS");
                foreach (string port in ports)
                {
                    tvCOM.Nodes["R"].Nodes.Add("C" + i, port);
                    //comboBox1.Items.Add(port);
                    i += 1;
                }
                string[] baudrates = { "230400", "115200", "57600", "38400", "19200", "9600" };
                tvCOM.Refresh();
                tvCOM.Nodes["R"].Expand();
            }
            catch
            {

            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Process[] prs = Process.GetProcesses();
            foreach (Process pr in prs)
            {
                if (pr.ProcessName == "Modbus Poll CS") pr.Kill();
                if (pr.ProcessName == "Editors") pr.Kill();
                if ((pr.ProcessName == "EXCEL") || (pr.ProcessName == "Excel") || (pr.ProcessName == "excel")) pr.Kill();
                if (pr.ProcessName == "AcroRd32") pr.Kill();
                if (pr.ProcessName == "Logger.vshost.exe") pr.Kill();
                if (pr.ProcessName == "Logger.vshost") pr.Kill();
                if (pr.ProcessName == "Logger") pr.Kill();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadListbox();
            tvCOM.Refresh();
        }

        private void btnStartScan_Click(object sender, EventArgs e)
        {
            int x = 0;
            int i = 1;
            pBar1.Maximum = 16;

            pBar1.Value = 1;
            x = 0; i = 1; int j = 0;
            String str = "";
            try
            {
                while (x < (cmbPort.Items.Count - 1))
                {
                a:
                    cmbPort.SelectedIndex = x;
                    msADAM.PortName = cmbPort.Text;
                    label8.Text = "Checking COM PORT : " + cmbPort.Text;
                    if (msADAM.IsOpen == true) msADAM.Dispose();
                    msADAM.BaudRate = int.Parse(cmbBaudRate.Text);
                    msADAM.DataBits = int.Parse("8");
                    msADAM.Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.Text);
                    msADAM.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                    msADAM.Open();
                    for (j = 1; j <= 16; j++)
                    {
                        pBar1.Value = j;
                        msADAM.Write("$" + j.ToString("X2") + "M" + "\r");
                        DelayMs(100);
                        str = msADAM.ReadExisting();
                        if (str != "")
                        {
                            String T = str.Substring(1, 2);
                            T = T + " " + str.Substring(3, 4);
                            tvCOM.Nodes["R"].Nodes["C" + i].Nodes.Add("Ad", T);
                            tvCOM.Nodes["R"].ExpandAll();
                            CmAdam = tvCOM.Nodes["R"].Nodes["C" + i].Text;
                        }
                    }
                    if (j > 16)
                    {
                        if (x >= cmbPort.Items.Count - 1)
                        {
                            msADAM.Dispose();
                            MessageBox.Show("ADAM port 'COM Port DETECTION Over!", "Dynalec Controls Pvt Ltd.",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //MessageBox.Show("ADAM port 'COM Port DETECTION Over!.....");
                            break;
                        }
                        else
                        {
                            x = x + 1;
                            i = i + 1;

                            msADAM.Dispose();
                            goto a;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message);
            }
        }

        private void btnStopScan_Click(object sender, EventArgs e)
        {
            tvCOM.Enabled = false;
            msADAM.Close();
            //msPort.Close();
            tmr_ADAM.Enabled = false;
            tmr_SInst.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> deviceId = new List<string>();
            List<string> ModelId = new List<string>();
            List<string> ModelNumber = new List<string>();
            List<string> Unit = new List<string>();

            deviceId.Add("1"); deviceId.Add("1"); deviceId.Add("1"); deviceId.Add("1"); deviceId.Add("1");
            if (TextBox10.Text != null)
                ModelId.Add(TextBox10.Text); if (TextBox11.Text != null) ModelId.Add(TextBox11.Text); if (TextBox12.Text != null) ModelId.Add(TextBox12.Text); if (TextBox13.Text != null) ModelId.Add(TextBox13.Text); if (TextBox14.Text != null) ModelId.Add(TextBox14.Text);
            //ModelId.Add("01"); ModelId.Add("02"); ModelId.Add("03"); ModelId.Add("04"); ModelId.Add("05");
            if (ComboBox8.SelectedItem.ToString() != null)
                ModelNumber.Add(ComboBox8.SelectedItem.ToString()); if (ComboBox10.SelectedItem != null) ModelNumber.Add(ComboBox10.SelectedItem.ToString()); if (ComboBox12.SelectedItem != null) ModelNumber.Add(ComboBox12.SelectedItem.ToString()); if (ComboBox14.SelectedItem != null) ModelNumber.Add(ComboBox14.SelectedItem.ToString()); if (ComboBox16.SelectedItem != null) ModelNumber.Add(ComboBox16.SelectedItem.ToString());
            if (ComboBox9.SelectedItem != null) Unit.Add(ComboBox9.SelectedItem.ToString()); if (ComboBox11.SelectedItem != null) Unit.Add(ComboBox11.SelectedItem.ToString()); if (ComboBox13.SelectedItem != null) Unit.Add(ComboBox13.SelectedItem.ToString()); if (ComboBox15.SelectedItem != null) Unit.Add(ComboBox15.SelectedItem.ToString()); if (ComboBox17.SelectedItem != null) Unit.Add(ComboBox17.SelectedItem.ToString());
            //truncate table first and then add
        }

        private void PortConfigurationSetting_Load(object sender, EventArgs e)
        {

            int x = 0;
            LoadListboxes();
            dgvDevicePortConfig.RowCount = 16;
            dgvDevicePortConfig.ColumnCount = 10;

            dgvDevicePortConfig.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

           Global.Open_Connection("gen_db", "con");
            MySqlCommand cmd = new MySqlCommand("select * from tb_comPorts", Global.con);
            MySqlDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                dgvDevicePortConfig[0, x].Value = rd.GetValue(0).ToString();
                dgvDevicePortConfig[1, x].Value = rd.GetValue(1).ToString();
                dgvDevicePortConfig[2, x].Value = rd.GetValue(2).ToString();
                dgvDevicePortConfig[3, x].Value = rd.GetValue(3).ToString();
                dgvDevicePortConfig[4, x].Value = rd.GetValue(4).ToString();
                dgvDevicePortConfig[5, x].Value = rd.GetValue(5).ToString();
                dgvDevicePortConfig[6, x].Value = rd.GetValue(6).ToString();
                dgvDevicePortConfig[7, x].Value = rd.GetValue(7).ToString();
                dgvDevicePortConfig[8, x].Value = rd.GetValue(8).ToString();
                dgvDevicePortConfig[9, x].Value = rd.GetValue(9).ToString();
                dgvDevicePortConfig[1, 14].Selected = true;
                x++;
            }
            loadInCell();
        }
        #region Load Listboxes
        private void LoadListboxes()
        {

            //1) Available Ports:',
            string[] ports = SerialPort.GetPortNames();
            cmbPort.Items.Add("COM");
            foreach (string port in ports)
                cmbPort.Items.Add(port);
            cmbPort.SelectedIndex = 0;

            //2) Baudrates:
            string[] baudrates = { "9600", "19200", "38400", "57600", "115200", "230400" };
            foreach (string baudrate in baudrates)
                cmbBaudRate.Items.Add(baudrate);
            cmbBaudRate.SelectedIndex = 0;

            //3) Parity:
            cmbParity.SelectedIndex = 0;
            //4) Stop Bit:
            cmbStopBit.SelectedIndex = 0;

        }
        #endregion

        private void loadInCell()
        {
            Rw = dgvDevicePortConfig.CurrentRow.Index;
            cmbDeviceName.Text = dgvDevicePortConfig[1, Rw].Value.ToString();
            cmbPort.Text = dgvDevicePortConfig[2, Rw].Value.ToString();
            cmbBaudRate.Text = dgvDevicePortConfig[3, Rw].Value.ToString();
            cmbParity.Text = dgvDevicePortConfig[4, Rw].Value.ToString();
            cmbStopBit.Text = dgvDevicePortConfig[5, Rw].Value.ToString();
            //txtInstID.Text = dgvDevicePortConfig[6, Rw].Value.ToString();
            //txtStartAdd.Text = dgvDevicePortConfig[7, Rw].Value.ToString();
           // txtNReads.Text = dgvDevicePortConfig[8, Rw].Value.ToString();

            String st = dgvDevicePortConfig[9, Rw].Value.ToString();
           

        }
        private void tmr_ADAM_Tick(object sender, EventArgs e)
        {
            try
            {
                if (msADAM.IsOpen == false) msADAM.Open();
                String Buf = msADAM.ReadExisting();
                Int16 pos = Convert.ToInt16(Buf.IndexOf("+", 1));
                if (pos != -1) Buf = Buf.Substring(pos);
                //DGView1[0, Adx].Value = Buf.Substring(pos, 6);
                String T = N_Name.Substring(0, 2);
                msADAM.DiscardInBuffer();
                if (Adx >= 7) Adx = 0; else Adx += 1;
                if (!msADAM.IsOpen) msADAM.Open();
                msADAM.Write("#" + (T + Adx.ToString()) + "\r");
            }
            catch
            {
                Adx = 0;
                msADAM.Write("#" + (N_Name.Substring(0, 2) + Adx.ToString()) + "\r");

            }
        }

        private void tmr_SInst_Tick(object sender, EventArgs e)
        {
            Rd_SerialPort();
        }

        public void Rd_SerialPort()
        {
            String buffer = "";

            if (msPort.IsOpen == false) msPort.Open();
            buffer = (msPort.ReadExisting());
            if ((buffer != "") && (buffer.Length > 10))
            {
                S_Out = (buffer.Substring(1, 2));

                if (int.Parse(S_Out) <= 7)
                {
                    dataGridView1[0, int.Parse(S_Out)].Value = buffer;
                }
                else if ((int.Parse(S_Out) >= 8) && (int.Parse(S_Out) < 16))
                {
                    dataGridView1[1, int.Parse(S_Out) - 8].Value = buffer;
                }
                else
                {
                    dataGridView1[2, int.Parse(S_Out) - 16].Value = buffer;
                }
            }

            msPort.DiscardInBuffer();

            String x = "";
            if (I_Add >= 23)  //l)
            {
                I_Add = -1;
            }
            else
            {

                if (I_Add <= 9) x = ("0" + I_Add.ToString()); else x = (I_Add.ToString());
                msPort.Write("*" + x + "T%");
                I_Add += 1;
            }


        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void smokeLoadListbox()
        {
            try
            {
                int i = 1;
                string[] ports = SerialPort.GetPortNames();
                if (treeView3.Nodes.Count != 0) treeView3.Nodes.Clear();

                treeView3.Nodes.Add("R", "PORTS");
                foreach (string port in ports)
                {
                    treeView3.Nodes["R"].Nodes.Add("C" + i, port);
                    //comboBox1.Items.Add(port);
                    i += 1;
                }
                string[] baudrates = { "230400", "115200", "57600", "38400", "19200", "9600" };
                treeView3.Refresh();
                treeView3.Nodes["R"].Expand();
            }
            catch
            {

            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            smokeLoadListbox();
            treeView3.Refresh();
        }

        private void InitSmoke_Click(object sender, EventArgs e)
        {

            //string msg;
            //DataTable dtDevicePortConfig2 = new DataTable();
            //dtDevicePortConfig2 = portconfiguration.GetDeviceDetailsbyId("5");
            //string[] getbaseandvolume = new string[2];
            //string mbase, volumeortime;
            //getbaseandvolume = dtDevicePortConfig2.Rows[0]["mbase"].ToString().Split(',');
            //mbase = getbaseandvolume[0];
            //volumeortime = getbaseandvolume[1];
            //try
            //{
            //    _smkPort.Close();
            //    if (_smkPort.IsOpen) _smkPort.Dispose();
            //    _smkPort.PortName = dtDevicePortConfig2.Rows[0]["portname"].ToString();
            //    _smkPort.BaudRate = Convert.ToInt32(dtDevicePortConfig2.Rows[0]["baudrate"]);
            //    _smkPort.DataBits = int.Parse("8");
            //    _smkPort.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
            //    _smkPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
            //    if (_smkPort.IsOpen == false)
            //    {
            //        _smkPort.Dispose();
            //        _smkPort.Open();
            //        msg = "Smoke Meter is initialized successfully";
            //        ReadSmokeMeter(mbase, volumeortime, dtDevicePortConfig2.Rows[0]["sample"].ToString());
            //    }
            //    else
            //    {
            //        msg = "Not connected";
            //    }
            //}
            //try
            //{

            //    if (_smkPort.IsOpen == true) _smkPort.Dispose();
            //    _smkPort.PortName = Global._smkPort[2];
            //    //Global.smkPort.PortName = Global.Smk_Port[2];

            //    //smkPort.BaudRate = int.Parse(Global.smkPort[3]);
            //    _smkPort.DataBits = int.Parse("8");
            //    _smkPort.Parity = (Parity)Enum.Parse(typeof(Parity), Global._smkPort[4]);
            //    _smkPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
            //    if (_smkPort.IsOpen == false)
            //    {
            //        _smkPort.Dispose();
            //        _smkPort.PortName = Global._smkPort[2];
            //        _smkPort.Open();
            //    }
            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show("Smoke Meter Initialization Error", ex.Message);
            //}
                    
        }

        private void CheckStatus_Click(object sender, EventArgs e)
        {
            CheckSmokeMeterStatus(Convert.ToString(ddlSmokeBase.SelectedItem), txtvolumeortimeinsec.Text, Convert.ToString(ddlSmokeSample.SelectedItem));
        }
        private void CheckSmokeMeterStatus(string mbase, string volumeortime, string sample)
        {
            StatusValue.Text = ReadSmokeMeter(mbase, volumeortime, sample);
        }

        private string ReadSmokeMeter(string smokeBase, string volumeortime, string sample)
        {
            _smkPort.Write("ASTF\r");
            Thread.Sleep(200);
            var smkBuffer = _smkPort.ReadExisting();

            if (smkBuffer.Substring(5, 1) == "0")
            {
                //Smoke Meter is sent to remote mode.
                _smkPort.Write("SREM\r");
                Thread.Sleep(200);
                smkBuffer = _smkPort.ReadExisting();

                if (string.IsNullOrEmpty(smkBuffer))
                {
                    smkBuffer = "Smoke meter not connected";
                }
                if (smkBuffer.Substring(5, 1) == "0")
                {
                    _smkPort.Write("SEX1" + "\r");
                    Thread.Sleep(200);
                    smkBuffer = _smkPort.ReadExisting();
                    if (smkBuffer.Substring(5, 1) == "0")
                    {
                        _smkPort.Write("ASTZ\r");
                        Thread.Sleep(200);
                        smkBuffer = _smkPort.ReadExisting();
                        if (smkBuffer.Substring(5, 1) == "0")
                        {
                            if (smokeBase == "VolumeBase")
                            { _smkPort.Write("EMZY V" + volumeortime + sample + "\r"); }
                            else if (smokeBase == "TimeBase")
                            { _smkPort.Write("EMZY Z" + volumeortime + sample + "\r"); }
                            Thread.Sleep(200);
                            _smkPort.Write("SMES\r");
                            if (!smkBuffer.Contains("SRDY")) return smkBuffer;
                            else 
                            {
                                MessageBox.Show("Smoke Meter is busy", "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                //MessageBox.Show("Smoke Meter is busy"); 
                            }
                            _smkPort.Write("AFSN\r");
                            Thread.Sleep(200);
                            smkBuffer = _smkPort.ReadExisting();
                            while (true)
                            {
                                if (!smkBuffer.Contains("AFSN")) continue;
                                _smkPort.Write("AFSN\r");
                                Thread.Sleep(200);
                                smkBuffer = _smkPort.ReadExisting();
                                if (string.IsNullOrEmpty(smkBuffer)) continue;
                                if (smkBuffer.Substring(7, 1) != sample) continue;
                                var b = smkBuffer.Split('\n');
                                if (b.Length != 2) continue;
                                //textBox1.Text = Convert.ToString(b[0].Substring(9, 5));
                                //Smokevalue = Convert.ToString(b[0].Substring(9, 5));
                                //srModel.smokevalue = Smokevalue;
                                break;
                            }
                        }
                        else if (smkBuffer.Substring(5, 1) == "1")
                        {
                            smkBuffer = " Not ready for sampling.";
                        }
                    }
                    else if (smkBuffer.Substring(5, 1) == "1")
                    {
                        _smkPort.Write("SEX2" + "\r");
                        smkBuffer = smkBuffer.Substring(5, 1) == "0" ? " Connector 2 selected" : " Check connector";
                    }
                }
                else if (smkBuffer.Substring(5, 1) == "1")
                {
                    smkBuffer = "Smoke meter in manual mode";
                    MessageBox.Show(smkBuffer, "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            //check if filter paper is installed incorrectly
            else if (smkBuffer == "ASTF 1 K0BS 20")
            {
                MessageBox.Show("Filter paper is installed incorrectly", "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // MessageBox.Show("Filter paper is installed incorrectly")
            }
            else if (smkBuffer == "ASTF 1 K0BS 100")
            {
                MessageBox.Show("Door is Open", "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               // MessageBox.Show("Door is Open");
            }
            //check if door is open
            else
            {
                smkBuffer = "";
            }
            return smkBuffer;
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void Add_RangeList(String M_Type, int M_No)
        {
            try
            {
                String str = "";
                switch (M_Type)
                {
                    case "NONE":
                        str = "NONE";
                        break;
                    case "4018*8":
                        str = "K-Type,J-Type";
                        break;
                    case "4017*8":
                        str = "-10~+10V,4~20mA";
                        break;
                    case "4015*6":
                        str = "-50~150°C,0~200°C,0~400°C";
                        break;
                }

                string input = str;
                string pattern = @"(,)";
                Regex regex = new Regex(pattern);
                switch (M_No)
                {
                    case 1:
                        ComboBox9.Items.Clear();
                        foreach (string result in regex.Split(input))
                        {
                            if (result != ",") ComboBox9.Items.Add(result);
                        }
                        ComboBox9.SelectedIndex = 0;
                        break;
                    case 2:
                        ComboBox11.Items.Clear();
                        foreach (string result in regex.Split(input))
                        {
                            if (result != ",") ComboBox11.Items.Add(result);
                        }
                        ComboBox11.SelectedIndex = 0;
                        break;
                    case 3:
                        ComboBox13.Items.Clear();
                        foreach (string result in regex.Split(input))
                        {
                            if (result != ",") ComboBox13.Items.Add(result);
                        }
                        ComboBox13.SelectedIndex = 0;
                        break;
                    case 4:
                        ComboBox15.Items.Clear();
                        foreach (string result in regex.Split(input))
                        {
                            if (result != ",") ComboBox15.Items.Add(result);
                        }
                        ComboBox15.SelectedIndex = 0;
                        break;
                    case 5:
                        ComboBox17.Items.Clear();
                        foreach (string result in regex.Split(input))
                        {
                            if (result != ",") ComboBox17.Items.Add(result);
                        }
                        ComboBox17.SelectedIndex = 0;
                        break;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 14002" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
               // MessageBox.Show("Error Code:- 14002", ex.Message);

                //Global.Create_OnLog(ex.Message, false);
            }


        }
        private void ComboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            Add_RangeList(ComboBox8.Text, 1);
        }

        private void ComboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            Add_RangeList(ComboBox10.Text, 2);
        }

        private void ComboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            Add_RangeList(ComboBox12.Text, 3);
        }

        private void ComboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            Add_RangeList(ComboBox14.Text, 4);
        }

        private void ComboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            Add_RangeList(ComboBox16.Text, 5);
        }

        private void dgvDevicePortConfig_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDevicePortConfig_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            loadInCell();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
