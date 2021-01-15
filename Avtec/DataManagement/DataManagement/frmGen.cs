
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions; 
using System.Windows.Forms;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using MySql.Web; 

namespace DataManagement

{

    public partial class frmGen : Form
    {
        
        string L;   
       
        String[] Perfno = new String[50];

        string Test_cyl = "GENERAL";
        int Rstart, Rstop;

        string NodeT;
        int M;
        int N;

        public frmGen()
        {
            InitializeComponent();
        }

        private void View_Data()
        {
            OleDbDataAdapter adp;
            DataSet ds = new DataSet();
            int l, k, j, i;
            try
            {
                Cursor.Current = Cursors.WaitCursor;  
                textBox2.Text = "0"; 
                textBox3.Text = "0";//ds.Tables[0].Rows.Count.ToString();  //
                textBox4.Text = "0";
                
                GDView.Refresh();  

                if ((label1.Text.Substring(0, 4) == "Prod") || (label1.Text.Substring(0, 4) == "Perf") || (label1.Text.Substring(0, 4) == "Endu"))
                {
                    Global.DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + comboBox1.Text + "\\";
                    string strFileName = Global.DataPath + "Gen_Data\\" + label1.Text + ".csv";
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + System.IO.Path.GetDirectoryName(strFileName) + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"");
                    con.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + System.IO.Path.GetFileName(strFileName), con);
                    DataSet ds1 = new DataSet("Temp");
                    adapter.Fill(ds1);
                    int y = ds1.Tables[0].Rows.Count;
                    if (y <= 1)
                    {
                        MessageBox.Show("File Is Empty. Please Select Another", "Dynalec Controls Pvt Ltd.",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);                       
                        return;
                    }
                    GDView.DataSource = ds1.Tables[0];
                    con.Close();

                    textBox2.Text = "1";
                    textBox3.Text = (ds1.Tables[0].Rows.Count).ToString();
                    textBox4.Text = (ds1.Tables[0].Rows.Count).ToString();
                    //*************************                  
                   //Cursor. 
                    ds1.Dispose();
                    Global.conData.Close();
                    //***************************************

                    Global.DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + comboBox1.Text + "\\";
                    strFileName = Global.DataPath + "Gen_Data\\EngDetails.csv";
                    StreamReader sr = new StreamReader(strFileName);
                    String X = label1.Text;
                    string strline = "";
                    string[] _values = null;
                    String[] Arr = null;
                    int S = 0;
                    int T = 0;
                    //PBar1.Value = 1; 
                    while (!sr.EndOfStream)
                    {
                        S++;
                        strline = sr.ReadLine();
                        _values = strline.Split(',');
                        if (_values[0] == X)
                        {
                            Arr = strline.Split(',');
                            PBar1.Value = S; 
                        }
                    }
                    sr.Close();
                    if (Arr != null)
                        for (T = 0; T <= 25; T++)  //dataGridView1.ColumnCount - 1
                        {
                            if (Arr[T] == null) Arr[T] = "***";
                            dataGridView1[T, 1].Value = Arr[T].ToString();
                        }
                    else 
                        {
                            for (T = 0; T <= 25; T++)    //dataGridView1.ColumnCount - 1;
                            {
                                dataGridView1[T, 1].Value = "***";
                            }
                            
                            Global.flg_HDdata = false;
                            MessageBox.Show("There is no report file header data", "Dynalec Controls Pvt Ltd.",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //MessageBox.Show("There is no report file header data", "ERROR");
                            return;
                        }
                    
                }

                else if (label1.Text.Substring(0, 3) == "PM_")
                {
                    Global.DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + comboBox1.Text + "\\";
                    string strFileName = Global.DataPath + "PM_Data\\" + label1.Text + ".csv";
					OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + System.IO.Path.GetDirectoryName(strFileName) + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"");
                    con1.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + System.IO.Path.GetFileName(strFileName), con1);
                    DataSet ds3 = new DataSet("Temp");
                    adapter.Fill(ds3);
                    GDView.DataSource = ds3.Tables[0];
                }
                else if (label1.Text.Substring(0, 4) == "ECU_")
                {
                    Global.DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + comboBox1.Text + "\\";
                    string strFileName = Global.DataPath + "ECU_Data\\" + label1.Text + ".csv";
                    OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + System.IO.Path.GetDirectoryName(strFileName) + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"");
                    con1.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + System.IO.Path.GetFileName(strFileName), con1);
                    DataSet ds3 = new DataSet("Temp");
                    adapter.Fill(ds3);
                    GDView.DataSource = ds3.Tables[0];
    
                   // Process p = Process.Start("excel.exe", strFileName); // ("notepad.exe");
                    //p.Start(strFileName);
                }
                else if (label1.Text.Substring(0, 6) == "OnLog_")
                {
                    Global.DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + comboBox1.Text + "\\";
                    string strFileName = Global.DataPath + "Log_Data\\" + label1.Text + ".csv";
                    OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + System.IO.Path.GetDirectoryName(strFileName) + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"");
                    con1.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + System.IO.Path.GetFileName(strFileName), con1);
                    DataSet ds3 = new DataSet("Temp");
                    adapter.Fill(ds3);
                    GDView.DataSource = ds3.Tables[0];

                    // Process p = Process.Start("excel.exe", strFileName); // ("notepad.exe");
                    //p.Start(strFileName);
                }



                //else if (label1.Text.Substring(0, 6) == "OnLog_")
                //{
                //    Global.DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + comboBox1.Text + "\\";
                //    string strFileName = Global.DataPath + "Log_Data\\" + label1.Text + ".txt";
                //    Process p = Process.Start("notepad.exe",strFileName); // ("notepad.exe");
                //    //p.Start(strFileName);
                //}
                

                    //**************************


               
                
                foreach (DataGridViewColumn colm in GDView.Columns)
                {
                    colm.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                Cursor.Current = Cursors.Default;  

                
            }
            
            catch (Exception ex) 
            {               
                    DialogResult result1 = MessageBox.Show("File is empty. Do you want to delete?", "Dynalec Controls Pvt Ltd.", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (result1 == DialogResult.Yes)
                    {
                        System.IO.File.Delete(Global.DataPath + "Gen_Data\\" + label1.Text+".csv");
                        MessageBox.Show("Deleted" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                       // MessageBox.Show(" Deleted");
                        Load_TV_Date(); 
                    }
                    else
                    {
                        MessageBox.Show("Not Deleted" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                       // MessageBox.Show("Not Deleted");
                    }

                    
                }
                
        }

      private void Load_TV_Date()
        {
            try
            {
                string tbname;
                DataTable ts;
               
                TVGen.BringToFront();

                TVGen.Nodes.Clear();
                //********************Performance
                string DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + comboBox1.Text + "\\Gen_Data\\";


                int M = DataPath.Length;
                if (System.IO.Directory.Exists(DataPath) == false)
                {
                    MessageBox.Show("There is no files for this month", "Dynalec Controls Pvt Ltd.",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // MessageBox.Show("There is no files for this month");
                    return;
                }

                if (System.IO.Directory.Exists(DataPath) != false)
                {
                    TVGen.Nodes.Add("R1", Global.DataPath + "Data");
                    TVGen.Nodes["R1"].Tag = "R1";

                    TVGen.Nodes["R1"].Nodes.Add("C1", "PERFORMANCE");
                    TVGen.Nodes["R1"].Nodes["C1"].Tag = "C1";
                    TVGen.Nodes["R1"].Nodes.Add("C2", "ENDURANCE");
                    TVGen.Nodes["R1"].Nodes["C2"].Tag = "C2";
                    TVGen.Nodes["R1"].Nodes.Add("C3", "PRODUCTION");
                    TVGen.Nodes["R1"].Nodes["C3"].Tag = "C3";
                    TVGen.Nodes["R1"].Nodes.Add("C4", "PM_Data");
                    TVGen.Nodes["R1"].Nodes["C4"].Tag = "C4";
                    TVGen.Nodes["R1"].Nodes.Add("C5", "ECU_Data");
                    TVGen.Nodes["R1"].Nodes["C5"].Tag = "C5";
                    TVGen.Nodes["R1"].Nodes.Add("C6", "Log_Error");
                    TVGen.Nodes["R1"].Nodes["C6"].Tag = "C6";








                    String[] files1 = System.IO.Directory.GetFiles(DataPath);  // + comboBox1.Text);
                    if (files1 == null)
                    {
                        MessageBox.Show("There is no files for this month", "Dynalec Controls Pvt Ltd.",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                       // MessageBox.Show("There is no files for this month");
                        return;
                    }
                    
                        foreach (string fnm in files1)
                        {

                            N = fnm.Length - 4;

                            if (fnm.Substring(M, 4) == "Perf") // (fnm.Substring(N) == ".csv")
                            {
                                TVGen.Nodes["R1"].Nodes["C1"].Nodes.Add("Pf", fnm.Substring(M, N - M));
                            }
                        }


                        files1 = System.IO.Directory.GetFiles(DataPath);
                        foreach (string fnm in files1)
                        {

                            N = fnm.Length - 4;

                            if (fnm.Substring(M, 4) == "Endu") // (fnm.Substring(N) == ".csv")
                            {
                                TVGen.Nodes["R1"].Nodes["C2"].Nodes.Add("En", fnm.Substring(M, N - M));
                            }
                        }
                        files1 = System.IO.Directory.GetFiles(DataPath);
                        foreach (string fnm in files1)
                        {

                            N = fnm.Length - 4;

                            if (fnm.Substring(M, 4) == "Prod") // (fnm.Substring(N) == ".csv")
                            {
                                TVGen.Nodes["R1"].Nodes["C3"].Nodes.Add("Pr", fnm.Substring(M, N - M));
                            }
                        }

                        DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + comboBox1.Text + "\\PM_Data\\";
                        M = DataPath.Length;
                        files1 = System.IO.Directory.GetFiles(DataPath);
                        foreach (string fnm in files1)
                        {

                            N = fnm.Length - 4;

                            if (fnm.Substring(M, 3) == "PM_") // (fnm.Substring(N) == ".csv")
                            {
                                TVGen.Nodes["R1"].Nodes["C4"].Nodes.Add("Pm", fnm.Substring(M, N - M));
                            }
                        }

                        DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + comboBox1.Text + "\\ECU_Data\\";
                        M = DataPath.Length;
                        files1 = System.IO.Directory.GetFiles(DataPath);
                        foreach (string fnm in files1)
                        {
                            N = fnm.Length - 4;
                            if (M != N)
                            {
                                if (fnm.Substring(M, 4) == "ECU_")// (fnm.Substring(N) == ".csv")
                                {
                                    TVGen.Nodes["R1"].Nodes["C5"].Nodes.Add("FastLog_Data", fnm.Substring(M, N - M));
                                }
                            }
                        }

                        DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + comboBox1.Text + "\\Log_Data\\";
                        M = DataPath.Length;
                        files1 = System.IO.Directory.GetFiles(DataPath);
                        foreach (string fnm in files1)
                        {

                            N = fnm.Length - 4;
                            if (M != N)
                            {

                                if (fnm.Substring(M, 6) == "OnLog_")// (fnm.Substring(N) == ".csv")
                                {
                                    TVGen.Nodes["R1"].Nodes["C6"].Nodes.Add("LogError", fnm.Substring(M, N - M));
                                }
                            }
                        }
                    }


                

                ////*******************     
                TVGen.Nodes["R1"].Expand();
                TVGen.Nodes["R1"].Nodes["C1"].Expand();
                //TVGen.Nodes["R1"].Nodes["C2"].Expand();
                //label7.Text = "Test Engine Data";
                Global.conData.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 17002" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Error Code:- 17002", ex.Message);
            }
        }
       
       
        private void defaultCombo()
        {
            comboBox1.Text = DateTime.Now.ToString("MMMyy");
            Load_TV_Date();  
        }
        private void fill_combo()
        {
            try
            {
                Global.Rd_System(); 
                comboBox1.Text = DateTime.Now.ToString("MMMyy");
                L = "D:\\TestCell_" + Global.T_CellNo + "\\";
                M = L.Length;  //("D:\\TestCell_" & T_CellNo & "\\");
                comboBox1.Items.Clear();
                String[] files = System.IO.Directory.GetDirectories(L);
                foreach (String fnm in files)
                {
                    if (fnm.Substring(M) != "Data") comboBox1.Items.Add(fnm.Substring(M));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 17005" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
               // MessageBox.Show("Error Code:- 17005",ex.Message);
            }
        }
        
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
                 
        private void frmShowData_Load(object sender, EventArgs e)
        {
            
            fill_combo();           
            defaultCombo();
            dataGridView1.RowCount = 2;
            dataGridView1.ColumnCount = 26;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1[0, 0].Value = "FILE NAME";
            dataGridView1[1, 0].Value = "COMMON RAIL NO";
            dataGridView1[2, 0].Value = "TB-CHARGERNO";
            dataGridView1[3, 0].Value = "HIGH PRESS FP NP";
            dataGridView1[4, 0].Value = "ENGINE SL.NO";
            dataGridView1[5, 0].Value = "NUMBER OF CYLs";
            
            
            dataGridView1[6, 0].Value = "BORE(mm)";
            dataGridView1[7, 0].Value = "STROKE(mm)";
            dataGridView1[8, 0].Value = "SWEPT VOL.(L)";

            dataGridView1[9, 0].Value = "RADIATOR";
            dataGridView1[10, 0].Value = "FAN";
            dataGridView1[11, 0].Value = "AirCLEANER";
            dataGridView1[12, 0].Value = "SILINCER";


           
            dataGridView1[13, 0].Value = "OPERATOR";
            dataGridView1[14, 0].Value = "ENGINEER";
            dataGridView1[15, 0].Value = "TEST CELL No.";
            dataGridView1[16, 0].Value = "SHIFT";
           
            dataGridView1[17, 0].Value = "TEST START Tm";
            dataGridView1[18, 0].Value = "TEST STOP Tm";
            dataGridView1[19, 0].Value = "Cum_HOURS";

            dataGridView1[20, 0].Value = "Date";
            dataGridView1[21, 0].Value = "Error Matrix";

            dataGridView1[22, 0].Value = "INJECTOR-01";
            dataGridView1[23, 0].Value = "INJECTOR-02";
            dataGridView1[24, 0].Value = "INJECTOR-03";
            dataGridView1[25, 0].Value = "INJECTOR-04";

                       //***********************************

        }

        private void TVGen_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                
                NodeT = TVGen.SelectedNode.Text;
                if (TVGen.SelectedNode.Tag != "R1") //|| (TVGen.SelectedNode.Tag != R1))
                {
                    //cmdRd.Enabled = true;
                    label1.Text = TVGen.SelectedNode.Text;
                    
                    if (label1.Text.Substring(0, 4).ToUpper()  == "PERF")
                        label7.Text = "Engine Test Data (Performance)";
                    else if (label1.Text.Substring(0, 4).ToUpper() == "ENDU")
                        label7.Text = "Engine Test Data (Endurance)";
                    else if (label1.Text.Substring(0, 4).ToUpper() == "PROD")
                        label7.Text = "Engine Test Data (Production)";
                    else if (label1.Text.Substring(0, 2).ToUpper() == "PM")
                        label7.Text = "Engine Test Data (Post Analysis)";
                    else if (label1.Text.Substring(0, 2).ToUpper() == "fData")
                        label7.Text = "Engine Test Data (Fast_log)";
                    else
                        label7.Text = "Engine Test Data (On Log Data)";
                }
                
                View_Data();
               
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 17013" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Error Code:- 17013", ex.Message);
            }   


        }

        private void Search_File_name()
        {
            try
            {             
               

                TVGen.Nodes.Clear();
                TVGen.Nodes.Add("R1", Global.DataPath + "Data");
                TVGen.Nodes["R1"].Tag = "R1";

                TVGen.Nodes["R1"].Nodes.Add("C1", "PERFORMANCE");
                TVGen.Nodes["R1"].Nodes["C1"].Tag = "C1";
                TVGen.Nodes["R1"].Nodes.Add("C2", "ENDURANCE");
                TVGen.Nodes["R1"].Nodes["C2"].Tag = "C2";
                TVGen.Nodes["R1"].Nodes.Add("C3", "PRODUCTION");
                TVGen.Nodes["R1"].Nodes["C3"].Tag = "C3";
                TVGen.Nodes["R1"].Nodes.Add("C4", "PM_Data");
                TVGen.Nodes["R1"].Nodes["C4"].Tag = "C4";


                string DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + comboBox1.Text + "\\Gen_Data\\";

                int M = (DataPath).Length;
                if (System.IO.Directory.Exists(DataPath) == true)
                {
                    String[] files1 = System.IO.Directory.GetFiles(DataPath);
                    foreach (string fnm in files1)
                    {
                        N = fnm.Length - 4;
                        int Y = M + 14; 

                        if (fnm.Substring(M, 4) == "Perf")
                        {
                            if (fnm.Substring(N) == ".csv")
                            {
                                if (fnm.Contains(txtSearch.Text)) 
                                {
                                    TVGen.Nodes["R1"].Nodes["C1"].Nodes.Add("Pe", fnm.Substring(M, (N - M)));
                                }
                            }
                        }

                        else if (fnm.Substring(M, 4) == "Endu")
                        {
                            if (fnm.Substring(N) == ".csv")
                            {
                                if (fnm.Contains(txtSearch.Text)) 
                                {
                                    TVGen.Nodes["R1"].Nodes["C2"].Nodes.Add("En", fnm.Substring(M, (N - M)));
                                }
                            }
                        }

                        else if (fnm.Substring(M, 4) == "Prod")
                        {
                            if (fnm.Substring(N) == ".csv")
                            {
                                if (fnm.Contains(txtSearch.Text)) 
                                {
                                    TVGen.Nodes["R1"].Nodes["C3"].Nodes.Add("Pr", fnm.Substring(M, (N - M)));
                                }
                            }
                        }
                    }
                    DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + comboBox1.Text + "\\PM_Data\\";

                    M = (DataPath).Length;
                    if (System.IO.Directory.Exists(DataPath) == true)
                    {
                        String[] files2 = System.IO.Directory.GetFiles(DataPath);
                        foreach (string fnm in files2)
                        {
                            N = fnm.Length - 4;
                            if (fnm.Substring(N) == ".csv")
                            {
                                if (fnm.Contains(txtSearch.Text)) 
                                {
                                    TVGen.Nodes["R1"].Nodes["C4"].Nodes.Add("Pm", fnm.Substring(M, (N - M)));
                                }
                            }
                        }


                    }
                }

                   TVGen.Nodes["R1"].Expand();                 
                  
                    //label7.Text = "Test Engine Data";
                    Global.conData.Close();
                
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error Code:- 17002", ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtSearch.Text.ToUpper();
            Search_File_name(); 
        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

      
      
       

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            Load_TV_Date(); 
        }

       
       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fill_combo();

            Load_TV_Date();

            dataGridView1.RowCount = 2;
            dataGridView1.ColumnCount = 50;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1[0, 0].Value = "File Name";
            dataGridView1[1, 0].Value = "CUSTOMER";
            dataGridView1[2, 0].Value = "ENGINE TYPE";
            dataGridView1[3, 0].Value = "ENGINE RATING";
            dataGridView1[4, 0].Value = "ENGINE SL.NO";
            dataGridView1[5, 0].Value = "ENGINE Test STD.";
            dataGridView1[6, 0].Value = "NUMBER OF CYL";
            dataGridView1[7, 0].Value = "ARR OF CYL";
            dataGridView1[8, 0].Value = "BORE(mm)";
            dataGridView1[9, 0].Value = "STROKE(mm)";
            dataGridView1[10, 0].Value = "SWEPT VOL.(L)";
            dataGridView1[11, 0].Value = "NOZZLE SIZE(mm)";

            dataGridView1[12, 0].Value = "COMPRESSION RATIO";
            dataGridView1[13, 0].Value = "ENGINE COOLANT";
            dataGridView1[14, 0].Value = "FUEL INJECTION TIME";
            dataGridView1[15, 0].Value = "FIRING ORDER";
            dataGridView1[16, 0].Value = "IDLING SPEED(rpm)";
            dataGridView1[17, 0].Value = "FUEL INJECTION PUMP";
            dataGridView1[18, 0].Value = "F.I.P.S.No.";
            dataGridView1[19, 0].Value = "INJECTION PR.(bar)";
            dataGridView1[20, 0].Value = "FIP NOZZLE TYPE";
            dataGridView1[21, 0].Value = "SPRAY HOLE CONFIG";
            dataGridView1[22, 0].Value = "EGR CONNECTION";

            dataGridView1[23, 0].Value = "FUEL";
            dataGridView1[24, 0].Value = "SP.G.OF FUEL";
            dataGridView1[25, 0].Value = "ENGINE LUB OIL";
            dataGridView1[26, 0].Value = "TC MODEL";
            dataGridView1[27, 0].Value = "TC SPECIFICATION";
            dataGridView1[28, 0].Value = "TC PART NUMBER";
            dataGridView1[29, 0].Value = "TC SERIAL NUMBER";
            dataGridView1[30, 0].Value = "TC AFTER COOLER";
            dataGridView1[31, 0].Value = "AIR FILTER";
            dataGridView1[32, 0].Value = "DYNO.TYPE";
            dataGridView1[33, 0].Value = "REMARKS";

            dataGridView1[34, 0].Value = "CELL NO";
            dataGridView1[35, 0].Value = "EWO NO";
            dataGridView1[36, 0].Value = "TEST NAME";
            dataGridView1[37, 0].Value = "AIR COMPRESSOR";
            dataGridView1[38, 0].Value = "ALTERNATOR";
            dataGridView1[39, 0].Value = "COOLING FAN";
            dataGridView1[40, 0].Value = "POWER STEERING PUMP";
            dataGridView1[41, 0].Value = "DATE OF TEST";
            dataGridView1[42, 0].Value = "TESTED BY";
            dataGridView1[43, 0].Value = "ENGINEER";

            //Global.EnginerNm = txtengineer.Text;
            //Global.OperatorNm =
            //Global.RpArr[40] = DateTime.Now.ToString("dd/MM/yyyy"); 
            //Global.RpArr[41] = Global.EnginerNm;
            //Global.RpArr[42] = Global.OperatorNm;

            //dataGridView1[0, 0].Value = "File Name";
            //dataGridView1[1, 0].Value = "Engine Type";
            //dataGridView1[2, 0].Value = "Engine Rating";
            //dataGridView1[3, 0].Value = "FIP No";
            //dataGridView1[4, 0].Value = "Engine Sr No";
            //dataGridView1[5, 0].Value = "No Of Cylinder";
            //dataGridView1[6, 0].Value = "Bore Dia.";
            //dataGridView1[7, 0].Value = "Stroke";
            //dataGridView1[8, 0].Value = "Swept Vol.";
            //dataGridView1[9, 0].Value = "Radiator";
            //dataGridView1[10, 0].Value = "Cooling Fan";
            //dataGridView1[11, 0].Value = "AirCleaner";
            //dataGridView1[12, 0].Value = "Silincer";
            //dataGridView1[13, 0].Value = "Dyno. Type";
            //dataGridView1[14, 0].Value = "Operator Name";
            //dataGridView1[15, 0].Value = "Engineer Name";
            //dataGridView1[16, 0].Value = "Test-Cell No";
            //dataGridView1[17, 0].Value = "Start Time";
            //dataGridView1[18, 0].Value = "Stop Time";
            //dataGridView1[19, 0].Value = "Comment";
            //dataGridView1[20, 0].Value = "Comment";
            //dataGridView1[21, 0].Value = "Comment";
            //dataGridView1[22, 0].Value = "Comment";
            //dataGridView1[23, 0].Value = "Comment";
            //dataGridView1[24, 0].Value = "Comment";

            //***********************************

           

        }

      
        private void Transfer_Perf_excel()
        {
            Cursor.Current = Cursors.WaitCursor;   
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;

            Process[] prs = Process.GetProcesses();
            foreach (Process pr in prs)
            {
                if (pr.ProcessName == "EXCEL") pr.Kill();
            }
            try
            {
                PBar1.Value = 5; 
                String[] Perfno = new String[50];
                String[] Perfhead = new String[50];
                String[] Perfunit = new String[50];
                string cell1, cell2, cell3, cell4;
                object misValue = System.Reflection.Missing.Value;
                int i, k;
                int j, rx;
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(Global.PATH + "Performance.xltx", 0, misValue, 4, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("Performance");

                //template
                dataGridView1.Refresh(); 
                int y = dataGridView1.ColumnCount - 1;
                for (int X1 = 0; X1 <= y; X1++)
                    if (dataGridView1[X1, 1].Value == null) dataGridView1[X1, 1].Value = "***";


                for (int x = 0; x <= 4; x++)
                {
                    xlWorkSheet.Cells[x + 4, 2] = dataGridView1[x, 0].Value.ToString();
                    xlWorkSheet.Cells[x + 4, 4] = dataGridView1[x, 1].Value.ToString();
                }
                xlWorkSheet.Cells[4, 4] = label1.Text;
                for (int x = 0; x <= 3; x++)
                {
                    xlWorkSheet.Cells[x + 5, 6] = dataGridView1[x + 5, 0].Value.ToString();
                    xlWorkSheet.Cells[x + 5, 8] = dataGridView1[x + 5, 1].Value.ToString();
                }
                for (int x = 0; x <= 3; x++)
                {
                    xlWorkSheet.Cells[x + 5, 10] = dataGridView1[x + 9, 0].Value.ToString();
                    xlWorkSheet.Cells[x + 5, 11] = dataGridView1[x + 9, 1].Value.ToString();
                }

                for (int x = 0; x <= 3; x++)
                {
                    xlWorkSheet.Cells[x + 5, 13] = dataGridView1[x + 13, 0].Value.ToString();
                    xlWorkSheet.Cells[x + 5, 15] = dataGridView1[x + 13, 1].Value.ToString();
                }
                for (int x = 0; x <= 2; x++)
                {
                    xlWorkSheet.Cells[x + 5, 17] = dataGridView1[x + 17, 0].Value.ToString();
                    xlWorkSheet.Cells[x + 5, 19] = dataGridView1[x + 17, 1].Value.ToString();
                }
                for (int x = 0; x <= 3; x++)
                {
                    xlWorkSheet.Cells[x + 5, 20] = dataGridView1[x + 22, 0].Value.ToString();
                    xlWorkSheet.Cells[x + 5, 21] = dataGridView1[x + 22, 1].Value.ToString();
                }

                xlWorkSheet.Cells[8, 18] = "Total Cyl Tm";
                xlWorkSheet.Cells[2, 19] = dataGridView1[20, 1].Value.ToString();
                xlWorkSheet.Cells[3, 19] = dataGridView1[21, 1].Value.ToString();

               
                Global.Open_Connection("gen_db", "con");
                MySqlDataAdapter adp2 = new MySqlDataAdapter("Select * from Tb_Perf ", Global.con);
                DataSet ds2 = new DataSet();
                adp2.Fill(ds2);

               

                k = ds2.Tables[0].Rows.Count;
                for (i = 0; i <= 20; i++)
                {
                    Perfno[i] = ds2.Tables[0].Rows[i].ItemArray[1].ToString();
                    Perfhead[i] = ds2.Tables[0].Rows[i].ItemArray[2].ToString();
                    xlWorkSheet.Cells[9, i + 2] = ds2.Tables[0].Rows[i].ItemArray[2].ToString();
                    Perfunit[i] = ds2.Tables[0].Rows[i].ItemArray[3].ToString();
                    xlWorkSheet.Cells[10, i + 2] = ds2.Tables[0].Rows[i].ItemArray[3].ToString();                    
                }               
                
                
                cell1 = "B9";
                cell2 = "V10";
                xlWorkSheet.get_Range(cell1, cell2).Font.Size = 11;
                xlWorkSheet.get_Range(cell1, cell2).Font.ColorIndex = 9;
                xlWorkSheet.get_Range(cell1, cell2).Font.Bold = true;
                xlWorkSheet.get_Range(cell1, cell2).Font.Name = "Calibri";
                xlWorkSheet.get_Range(cell1, cell2).Borders.ColorIndex = 15;
                xlWorkSheet.get_Range(cell1, cell2).Borders.LineStyle = Excel.XlBorderWeight.xlHairline;
                xlWorkSheet.get_Range(cell1, cell2).BorderAround(Excel.XlLineStyle.xlDouble, Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);
                //****************************************

               
                rx = GDView.Rows.Count;

                PBar1.Maximum = rx - 2;
                PBar1.Value = (int)1;

                adp2.Dispose();
                ds2.Dispose();
                Global.con.Close();
                int m;
                int x1 = 21; // rx - 2;
                for (m = 0; m <= rx - 2; m++)
                {

                    Excel.Range Line = (Excel.Range)xlWorkSheet.Rows[(m + 12), misValue];
                    Line = Line.EntireRow;
                    Line.Insert(Excel.XlInsertShiftDirection.xlShiftDown, misValue);
                    for (int n = 0; n <= 20; n++)
                    {
                        xlWorkSheet.Cells[m + 11, n + 2] = GDView[int.Parse(Perfno[n]), m].Value.ToString();
                    }

                    textBox4.Text = (x1--).ToString();
                    System.Threading.Thread.Sleep(100);
                    PBar1.Value = (int)m;
                }

                cell1 = "B11";
                cell2 = "V" + (rx + 11);

                xlWorkSheet.get_Range(cell1, cell2).Font.Size = 11; //style.FontStyle.Color = Color.White;
                xlWorkSheet.get_Range(cell1, cell2).Font.Bold = false;
                xlWorkSheet.get_Range(cell1, cell2).Font.ColorIndex = 5;
                xlWorkSheet.get_Range(cell1, cell2).Font.Name = "Calibri";
                xlWorkSheet.get_Range(cell1, cell2).Borders.ColorIndex = 15;
                xlWorkSheet.get_Range(cell1, cell2).Borders.LineStyle = Excel.XlBorderWeight.xlHairline;
                xlWorkSheet.get_Range(cell1, cell2).BorderAround(Excel.XlLineStyle.xlDouble, Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);

               
                PBar1.Text = "Data Transfer Over .......";
                String st = label1.Text;
                String St1 = st.Substring(4);
                xlWorkBook.SaveAs((object)(Global.DataPath + "Perf" + St1), misValue, misValue, misValue, false, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);

                xlApp.Visible = true;
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 17007" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }


        }


        private void Transfer_Endu_excel()
        {

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;

            Cursor.Current = Cursors.WaitCursor;   

            Process[] prs = Process.GetProcesses();
            foreach (Process pr in prs)
            {
                if (pr.ProcessName == "EXCEL") pr.Kill();
            }
            try
            {
                String[] Enduno = new String[50];
                String[] Enduhead = new String[50];
                String[] Enduunit = new String[50];
                string cell1, cell2, cell3, cell4;
                object misValue = System.Reflection.Missing.Value;
                int i, k;
                int j, rx;
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(Global.PATH + "Endurance.xltx", 0, misValue, 4, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("Endurance");

                //Templete
                dataGridView1.Refresh(); 
                int y = dataGridView1.RowCount - 1;
                for (int X1 = 0; X1 <= y; X1++)
                    if (dataGridView1[X1, 1].Value  == null) dataGridView1[X1, 1].Value  = "***";

                    for (int x = 0; x <= 4; x++)
                    {                    
                        xlWorkSheet.Cells[x + 4, 2] = dataGridView1[x, 0].Value.ToString();
                        xlWorkSheet.Cells[x + 4, 4] = dataGridView1[x, 1].Value.ToString();
                    }
                for (int x = 0; x <= 3; x++)
                {
                    xlWorkSheet.Cells[x + 5, 6] = dataGridView1[x + 5, 0].Value.ToString();
                    xlWorkSheet.Cells[x + 5, 8] = dataGridView1[x + 5, 1].Value.ToString();
                }
                for (int x = 0; x <= 3; x++)
                {
                    xlWorkSheet.Cells[x + 5, 10] = dataGridView1[x + 9, 0].Value.ToString();
                    xlWorkSheet.Cells[x + 5, 12] = dataGridView1[x + 9, 1].Value.ToString();
                }

                for (int x = 0; x <= 3; x++)
                {
                    xlWorkSheet.Cells[x + 5, 14] = dataGridView1[x + 13, 0].Value.ToString();
                    xlWorkSheet.Cells[x + 5, 16] = dataGridView1[x + 13, 1].Value.ToString();
                }
                for (int x = 0; x <= 2; x++)
                {
                    xlWorkSheet.Cells[x + 5, 18] = dataGridView1[x + 17, 0].Value.ToString();
                    xlWorkSheet.Cells[x + 5, 20] = dataGridView1[x + 17, 1].Value.ToString();
                }

                xlWorkSheet.Cells[8, 18] = "Total Cyl Tm";
                xlWorkSheet.Cells[2, 19] = dataGridView1[20, 1].Value.ToString();
                xlWorkSheet.Cells[3, 19] = dataGridView1[21, 1].Value.ToString();
                PBar1.Value = 5; 

                Global.Open_Connection("gen_db", "con");
                MySqlDataAdapter adp2 = new MySqlDataAdapter("Select * from Tb_Endu ", Global.con);
                DataSet ds2 = new DataSet();
                adp2.Fill(ds2);
                cell1 = "B9";
                cell2 = "AE10";
                xlWorkSheet.get_Range(cell1, cell2).ClearContents();
                xlWorkSheet.get_Range(cell1, cell2).ClearFormats();

                k = ds2.Tables[0].Rows.Count;
                for (i = 0; i <= k - 1; i++)
                {
                    Enduno[i] = ds2.Tables[0].Rows[i].ItemArray[1].ToString();
                    Enduhead[i] = ds2.Tables[0].Rows[i].ItemArray[2].ToString();
                    xlWorkSheet.Cells[9, i + 2] = ds2.Tables[0].Rows[i].ItemArray[2].ToString();
                    Enduunit[i] = ds2.Tables[0].Rows[i].ItemArray[3].ToString();
                    xlWorkSheet.Cells[10, i + 2] = ds2.Tables[0].Rows[i].ItemArray[3].ToString();
                }

                cell1 = "B9";
                cell2 = "AE10";
                xlWorkSheet.get_Range(cell1, cell2).Font.Size = 11; 
                xlWorkSheet.get_Range(cell1, cell2).Font.ColorIndex = 9;
                xlWorkSheet.get_Range(cell1, cell2).Font.Bold = true;
                xlWorkSheet.get_Range(cell1, cell2).Font.Name = "Calibri";
                xlWorkSheet.get_Range(cell1, cell2).Borders.ColorIndex = 15;
                xlWorkSheet.get_Range(cell1, cell2).Borders.LineStyle = Excel.XlBorderWeight.xlHairline;
                xlWorkSheet.get_Range(cell1, cell2).BorderAround(Excel.XlLineStyle.xlDouble, Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);

//**************************
                rx = GDView.Rows.Count;

                PBar1.Maximum = rx + 1;
                PBar1.Value = (int)1;

                adp2.Dispose();
                ds2.Dispose();
                Global.con.Close();
                int m;
                int x1 = rx - 2;
                PBar1.Maximum = x1;
                for (m = 0; m <= rx - 2; m++)
                {

                    Excel.Range Line = (Excel.Range)xlWorkSheet.Rows[(m + 12), misValue];
                    Line = Line.EntireRow;
                    Line.Insert(Excel.XlInsertShiftDirection.xlShiftDown, misValue);
                    for (int n = 0; n <= 22; n++)
                    {
                        xlWorkSheet.Cells[m + 11, n + 2] = GDView[int.Parse(Enduno[n]), m].Value.ToString();
                    }
                    textBox4.Text = (x1--).ToString();
                    System.Threading.Thread.Sleep(100);
                    PBar1.Value = (int)m;
                }

                cell1 = "B11";
                cell2 = "AE" + (rx + 11);

                xlWorkSheet.get_Range(cell1, cell2).Font.Size = 11; //style.FontStyle.Color = Color.White;
                xlWorkSheet.get_Range(cell1, cell2).Font.Bold = false;
                xlWorkSheet.get_Range(cell1, cell2).Font.ColorIndex = 5;
                xlWorkSheet.get_Range(cell1, cell2).Font.Name = "Calibri";
                xlWorkSheet.get_Range(cell1, cell2).Borders.ColorIndex = 15;
                xlWorkSheet.get_Range(cell1, cell2).Borders.LineStyle = Excel.XlBorderWeight.xlHairline;
                xlWorkSheet.get_Range(cell1, cell2).BorderAround(Excel.XlLineStyle.xlDouble, Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);
               
                PBar1.Text = "Data Transfer Over .......";
                String st = label1.Text;  
                String St1 = st.Substring(4); 
                xlWorkBook.SaveAs((object)(Global.DataPath + "Endu" + St1), misValue, misValue, misValue, false, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);

                xlApp.Visible = true;
                Cursor.Current = Cursors.Default;   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 17008" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Error Code:- 17007", ex.Message);
            }


        }

       

        private void DeleteFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("File is empty. Do you want to delete?", "Dynalec Controls Pvt Ltd.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result1 == DialogResult.Yes)
            {
                System.IO.File.Delete(Global.DataPath + "Gen_Data\\" + label1.Text + ".csv");
                MessageBox.Show("File Deleted", "Dynalec Controls Pvt Ltd.",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                // MessageBox.Show(" Deleted");
                Load_TV_Date();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEndurance_Click(object sender, EventArgs e)
        {
            Transfer_Endu_excel();
        }

        private void btnPerformance_Click(object sender, EventArgs e)
        {
            Transfer_Perf_excel(); 
        }

       
       
        
        }
    }


       
    

