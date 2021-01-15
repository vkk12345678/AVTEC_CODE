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


namespace DataManagement

{

    public partial class frmGen : Form
    {
        
        string L;
        
        Boolean flg_PMCHK = false;
        Boolean flg_ProdChk = false;
        Boolean flg_Multichk = false;
        Boolean flg_Perf = false;
        Boolean flg_Endu = false;

        Boolean flg_delete = false;
        Boolean flg_MESchk = false;
        Boolean flg_Genchoice = false;
        Boolean flg_Enduchoice = false;
        Boolean flg_Perfchoice = false;
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

        private void viewmulti()
        {
            int i, j, k = 0;
            OleDbDataAdapter adp2;
            DataSet ds2 = new DataSet();
            try
            {
                if ((label1.Text.Substring(2, 2) == comboBox1.Text.Substring(0,2) ) || (label1.Text == "GenData"))
                {
                    if (Global.conData.State == ConnectionState.Closed) Global.Open_DataConn("Data", "conData");
                    adp2 = new OleDbDataAdapter("Select * from " + label1.Text.Trim() + " order by 'Pn'", Global.conData);
                    adp2.Fill(ds2);
                    Global.conData.Close();
                }

                GDView.RowCount = GDView.RowCount + 2;
                GDView.ColumnCount = ds2.Tables[0].Columns.Count;
                for (i = 0; i <= ds2.Tables[0].Columns.Count - 1; i++)
                {
                    GDView.Columns[i].Name = ds2.Tables[0].Columns[i].ToString();
                }
                k = GDView.RowCount - 1;
                GDView.RowCount = GDView.RowCount + ds2.Tables[0].Rows.Count;

                for (j = 0; j <= ds2.Tables[0].Rows.Count - 1; j++)
                {
                    //gridview1.RowCount = gridview1.RowCount + j ;

                    for (i = 0; i <= ds2.Tables[0].Columns.Count - 1; i++)
                    {
                        GDView.Rows[j + k].Cells[i].Value = ds2.Tables[0].Rows[j].ItemArray[i].ToString();

                    }
                }

                ds2.Dispose();
                Global.conData.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 17001" + ex.Message);
            }


        }

        private void View_Data()
        {
            OleDbDataAdapter adp;
            DataSet ds = new DataSet();
            int l, k, j, i;
            try
            {
                textBox2.Text = "0"; 
                textBox3.Text = "0";//ds.Tables[0].Rows.Count.ToString();  //
                textBox4.Text = "0";

                PBar1.Text = "Wait for Data Transfer.........";
                if ((label1.Text.Substring(0, 4) == "Prod") || (label1.Text.Substring(0, 4) == "Perf") || (label1.Text.Substring(0, 4) == "Endu"))
                {

                    Global.DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + comboBox1.Text + "\\";
                    string strFileName = Global.DataPath + "Gen_Data\\" + label1.Text + ".csv";
                    OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + System.IO.Path.GetDirectoryName(strFileName) + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"");
                    conn.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + System.IO.Path.GetFileName(strFileName), conn);
                    DataSet ds1 = new DataSet("Temp");
                    adapter.Fill(ds1);
                    int y = ds1.Tables[0].Rows.Count;
                    if (y <= 1)
                    {
                        MessageBox.Show("File Is Empty .... Pl. Select Another");
                        return;
                    }
                    GDView.DataSource = ds1.Tables[0];
                    conn.Close();

                    textBox2.Text = "1";
                    textBox3.Text = (ds1.Tables[0].Rows.Count).ToString();
                    textBox4.Text = (ds1.Tables[0].Rows.Count).ToString();
                    //*************************                  
                    PBar1.Text = "Wait Data For Transfer .......";
                    PBar1.Maximum = ds1.Tables[0].Rows.Count;
                    PBar1.Value = 1;
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
                    PBar1.Value = 1; 
                    while (!sr.EndOfStream)
                    {
                        S++;
                        strline = sr.ReadLine();
                        _values = strline.Split(',');
                        if (_values[0] == X)
                        {
                            Arr = strline.Split(',');
                            //PBar1.Value = S; 
                        }
                    }
                    sr.Close();
                    for (T = 0; T <= 24; T++)
                    {
                        dataGridView1[T, 1].Value = Arr[T].ToString();
                        
                    }
                    if (Arr[0] == null) MessageBox.Show("Heder Tempelete is not available.......");

                    PBar1.Text = "Data Transfer Over .......";
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
                else if (label1.Text.Substring(0, 6) == "OnLog_")
                {
                    Global.DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + comboBox1.Text + "\\";
                    string strFileName = Global.DataPath + "Log_Data\\" + label1.Text + ".txt";
                    Process p = Process.Start("notepad.exe",strFileName); // ("notepad.exe");
                    //p.Start(strFileName);
                }
                //else if (label1.Text.Substring(0, 3) == "PM_")
                //{
                //    Global.DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + comboBox1.Text + "\\";
                //    string strFileName = Global.DataPath + "Gen_Data\\" + Global.Eng_FileNm + ".csv";
                //    Process p = Process.Start("Excel", strFileName); // ("notepad.exe");
                //    //p.Start(strFileName);
                //}


                    //**************************
                    
              
                
                foreach (DataGridViewColumn colm in GDView.Columns)
                {
                    colm.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                
            }
            
            catch (Exception ex) 
            {               

                    DialogResult result1 = MessageBox.Show("File is empty Do you want to delete ?", "File Status", MessageBoxButtons.YesNo);
                    if (result1 == DialogResult.Yes)
                    {
                        if (Global.conData.State == ConnectionState.Closed) Global.Open_DataConn("Data", "conData");
                    //adp = new OleDbDataAdapter("Select * from " + label1.Text.Trim() + " Order By TM", Global.conData);

                        OleDbCommand cmd = new OleDbCommand();
                        cmd.CommandText = ("Drop table " + label1.Text.Trim());
                        cmd.Connection = Global.conData;
                        cmd.ExecuteNonQuery();
                        Global.conData.Close();
                        MessageBox.Show(" Deleted");

                    }
                    else
                    {
                        MessageBox.Show("Not Deleted");
                    }

                    
                }
                
        }

        //private void Load_TV_Date()
        //{
        //    try
        //    {
        //        string tbname;
        //        DataTable ts;
        //        checkedListBox1.Items.Clear();
        //        TVGen.BringToFront();  

        //        TVGen.Nodes.Clear();
        //        if (System.IO.File.Exists(L + (comboBox1.Text) + "\\Data.accdb") == true)
        //        {
        //            Global.DataPath = L + (comboBox1.Text) + "\\";
        //            if (Global.conData.State == ConnectionState.Closed) Global.Open_DataConn("Data", "conData");


        //            TVGen.Nodes.Add("R1", Global.DataPath + "Data"); 
        //            TVGen.Nodes["R1"].Tag = "R1";

        //            TVGen.Nodes.Add. 
        //            ts = Global.conData.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, null });// "TABLE"
                    
        //            foreach (DataRow row in ts.Rows)
        //            {
        //                tbname = row["TABLE_NAME"].ToString();
        //                if ((tbname.Substring(0, 4) == "Perf") || (tbname.Substring(0, 4) == "Prod") || (tbname.Substring(0, 4) == "Endu"))
        //                {
        //                    if ((tbname.Substring(7, 3).ToString()) == comboBox1.Text.Substring(0, 3))
        //                    {
        //                        TVGen.Nodes["R1"].Nodes.Add("D", tbname);
        //                    }
        //                }
        //                TVGen.Nodes["R1"].Expand();
        //                ts.Dispose();
        //            }

        //            foreach (DataRow row in ts.Rows)
        //            {
        //                tbname = row["TABLE_NAME"].ToString();
        //                if ((tbname.Substring(0, 4) == "Perf") || (tbname.Substring(0, 4) == "Prod") || (tbname.Substring(0, 4) == "Endu"))
        //                {
        //                    if ((tbname.Substring(7, 3).ToString()) == comboBox1.Text.Substring(0, 3))
        //                    {
        //                        TVGen.Nodes["R2"].Nodes.Add("E", tbname);
        //                    }
        //                }
        //                TVGen.Nodes["R2"].Expand();
        //                ts.Dispose();
        //            }


        //            label7.Text = "Test Engine Data";
        //            Global.conData.Close();
        //        }             
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error Code:- 17002",ex.Message);
        //    }
        //}

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
                if (System.IO.Directory.Exists(DataPath) == true)
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
                    TVGen.Nodes["R1"].Nodes.Add("C5", "Log_Error");
                    TVGen.Nodes["R1"].Nodes["C5"].Tag = "C5";

                        
                   
                    String[] files1 = System.IO.Directory.GetFiles(DataPath);  // + comboBox1.Text);
                    foreach (string fnm in files1)
                    {
                       
                        N = fnm.Length - 4;

                        if (fnm.Substring(M, 4) == "Perf") // (fnm.Substring(N) == ".csv")
                        {
                            TVGen.Nodes["R1"].Nodes["C1"].Nodes.Add("Pf", fnm.Substring(M, N-M));
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

                    DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + comboBox1.Text + "\\Log_Data\\";
                    M = DataPath.Length;
                    files1 = System.IO.Directory.GetFiles(DataPath);
                    foreach (string fnm in files1)
                    {

                        N = fnm.Length - 4;

                        if (fnm.Substring(M, 6) == "OnLog_") // (fnm.Substring(N) == ".csv")
                        {
                            TVGen.Nodes["R1"].Nodes["C5"].Nodes.Add("LogError", fnm.Substring(M, N - M));
                        }
                    }
                }




                ////*******************     
                TVGen.Nodes["R1"].Expand();
                //TVGen.Nodes["R1"].Nodes["C1"].Expand();
                //TVGen.Nodes["R1"].Nodes["C2"].Expand();
                //label7.Text = "Test Engine Data";
                Global.conData.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 17002", ex.Message);
            }
        }
        private void Load_TV_FTP()
        {
            try
            {
                string tbname;
                DataTable ts;
                //checkedListBox1.Items.Clear();
                TVGen.BringToFront();

                TVGen.Nodes.Clear();
                if (System.IO.File.Exists(L + (comboBox1.Text) + "\\Data.accdb") == true)
                {
                    Global.DataPath = L + (comboBox1.Text) + "\\";
                    if (Global.conData.State == ConnectionState.Closed) Global.Open_DataConn("Data", "conData");


                    TVGen.Nodes.Add("R1", Global.DataPath + "Data");
                    TVGen.Nodes["R1"].Tag = "R1";
                    ts = Global.conData.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, null });// "TABLE"

                    foreach (DataRow row in ts.Rows)
                    {
                        tbname = row["TABLE_NAME"].ToString();
                        if ((tbname.Substring(0, 4) == "Perf"))
                        {
                            if ((tbname.Substring(7, 3).ToString()) == comboBox1.Text.Substring(0, 3))
                            {
                                TVGen.Nodes["R1"].Nodes.Add("D", tbname);
                            }
                        }
                        TVGen.Nodes["R1"].Expand();
                        ts.Dispose();
                    }
                    //label7.Text = "Test Engine Data";
                    Global.conData.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 17002", ex.Message);
            }
        }
        private void Load_TV_Endu()
        {
            try
            {
                string tbname;
                DataTable ts;
               
                TVGen.BringToFront();

                TVGen.Nodes.Clear();
                if (System.IO.File.Exists(L + (comboBox1.Text) + "\\Data.accdb") == true)
                {
                    Global.DataPath = L + (comboBox1.Text) + "\\";
                    if (Global.conData.State == ConnectionState.Closed) Global.Open_DataConn("Data", "conData");


                    TVGen.Nodes.Add("R1", Global.DataPath + "Data");
                    TVGen.Nodes["R1"].Tag = "R1";
                    ts = Global.conData.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, null });// "TABLE"

                    foreach (DataRow row in ts.Rows)
                    {
                        tbname = row["TABLE_NAME"].ToString();
                        if ((tbname.Substring(0, 4) == "Endu"))
                        {
                            if ((tbname.Substring(7, 3).ToString()) == comboBox1.Text.Substring(0, 3))
                            {
                                TVGen.Nodes["R1"].Nodes.Add("D", tbname);
                            }
                        }
                        TVGen.Nodes["R1"].Expand();
                        ts.Dispose();
                    }
                    //label7.Text = "Test Engine Data";
                    Global.conData.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 17002", ex.Message);
            }
        }
        private void Load_TV_Prod()
        {
            try
            {
                string tbname;
                DataTable ts;
              
                TVGen.BringToFront();

                TVGen.Nodes.Clear();
                if (System.IO.File.Exists(L + (comboBox1.Text) + "\\Data.accdb") == true)
                {
                    Global.DataPath = L + (comboBox1.Text) + "\\";
                    if (Global.conData.State == ConnectionState.Closed) Global.Open_DataConn("Data", "conData");


                    TVGen.Nodes.Add("R1", Global.DataPath + "Data");
                    TVGen.Nodes["R1"].Tag = "R1";
                    ts = Global.conData.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, null });// "TABLE"

                    foreach (DataRow row in ts.Rows)
                    {
                        tbname = row["TABLE_NAME"].ToString();
                        if ((tbname.Substring(0, 4) == "Prod"))
                        {
                            if ((tbname.Substring(7, 3).ToString()) == comboBox1.Text.Substring(0, 3))
                            {
                                TVGen.Nodes["R1"].Nodes.Add("D", tbname);
                            }
                        }
                        TVGen.Nodes["R1"].Expand();
                        ts.Dispose();
                    }
                    //label7.Text = "Test Engine Data";
                    Global.conData.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 17002", ex.Message);
            }
        }
        private void Load_TV_PM()
        {
            try
            {
                string tbname;
                DataTable ts;
             
                TVGen.BringToFront();

                TVGen.Nodes.Clear();
                if (System.IO.File.Exists(L + (comboBox1.Text) + "\\Data.accdb") == true)
                {
                    Global.DataPath = L + (comboBox1.Text) + "\\";
                    if (Global.conData.State == ConnectionState.Closed) Global.Open_DataConn("Data", "conData");


                    TVGen.Nodes.Add("R1", Global.DataPath + "Data");
                    TVGen.Nodes["R1"].Tag = "R1";
                    ts = Global.conData.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, null });// "TABLE"

                    foreach (DataRow row in ts.Rows)
                    {
                        tbname = row["TABLE_NAME"].ToString();
                        if ((tbname.Substring(0, 3) == "PM_"))
                        {
                            if ((tbname.Substring(5, 3).ToString()) == comboBox1.Text.Substring(0, 3))
                            {
                                TVGen.Nodes["R1"].Nodes.Add("D", tbname);
                            }
                        }
                        TVGen.Nodes["R1"].Expand();
                        ts.Dispose();
                    }
                    //label7.Text = "PM Engine Data";
                    Global.conData.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 17002", ex.Message);
            }
        }
        //private void Transfer_excel()
        //{
        //    try
        //    {                
        //        L = "D:\\TestCell_" + Global.T_CellNo + "\\";
        //        String L1 = L + comboBox1.Text;
        //        M = L1.Length + 1; 
        //        TVreport.Nodes.Clear();
        //        TVreport.Nodes.Add("R1", L1);   
        //        TVreport.Nodes["R1"].Tag = "R1";
        //        TVreport.Nodes.Add("R2", L1);
        //        TVreport.Nodes["R2"].Tag = "R2";

        //        if (System.IO.Directory.Exists(L + (comboBox1.Text)) == true)
        //        {
        //            String[] files1 = System.IO.Directory.GetFiles(L + comboBox1.Text);
        //            foreach (string fnm in files1)
        //            {                       
        //                N = fnm.Length - 5;

        //                if ((fnm.Substring(N) == ".xlsx") && (fnm.Substring(M,4) == "Endu"))
        //                {
        //                    TVreport.Nodes["R1"].Nodes.Add("R1", fnm.Substring(M));                           
        //                }
        //            }
        //        }
        //        TVreport.Nodes["R1"].Expand();
        //        label7.Text = "ENDURANCE";
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.Create_OnLog(ex.Message);
        //    }
        //}

        //private void LOAD_Performance()
        //{
        //    try
        //    {
        //        L = "D:\\TestCell_" + Global.T_CellNo + "\\";
        //        String L1 = L + comboBox1.Text;
        //        M = L1.Length + 1;
        //        TVreport.Nodes.Clear();
        //        TVreport.Nodes.Add("R1", L1);
        //        TVreport.Nodes["R1"].Tag = "R1";

        //        if (System.IO.Directory.Exists(L + (comboBox1.Text)) == true)
        //        {
        //            String[] files1 = System.IO.Directory.GetFiles(L + comboBox1.Text);
        //            foreach (string fnm in files1)
        //            {
        //                N = fnm.Length - 5;

        //                if ((fnm.Substring(N) == ".xlsx") && (fnm.Substring(M, 4) == "Perf"))
        //                {
        //                    TVreport.Nodes["R1"].Nodes.Add("R1", fnm.Substring(M));
        //                }
        //            }
        //        }
        //        TVreport.Nodes["R1"].Expand();
        //        label7.Text = "Performance";
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.Create_OnLog(ex.Message);
        //    }

        //}
       
        //private void LoadMulti()
        //{
        //    String tbname;
        //    DataTable ts2;
           
        //    try
        //    {

        //        if (System.IO.File.Exists(L + (comboBox1.Text) + "\\Data.accdb") == true)
        //        {
        //            Global.DataPath = L + (comboBox1.Text) + "\\";
        //            if (Global.conData.State == ConnectionState.Closed) Global.Open_DataConn("Data", "conData");
        //            ts2 = Global.conData.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, null });
        //            foreach (DataRow row in ts2.Rows)
        //            {
        //                //tbname = row["TABLE_NAME"].ToString();
        //                //if (((tbname.Substring(2, 2).ToString()) == comboBox1.Text.Substring(0,2) ))// || ((tbname.Substring(0, 4).ToString()) == "GEN_"))
        //                //{
        //                //    checkedListBox1.Items.Add(tbname);

        //                //}
        //                //ts2.Dispose();
        //            }
        //        }

        //        label7.Text = " Test Engine Data";
        //        Global.conData.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error Code:- 17003",ex.Message);
        //    }
        //}
        //private void Load_PMData()
        //{
        //  try
        //  {
        //    string tbname;
        //    DataTable ts;
        //   TVGen.BringToFront(); 

        //        TVGen.Nodes.Clear();
        //        if (System.IO.File.Exists(L + (comboBox1.Text) + "\\Data.accdb") == true)
        //        {
        //            Global.DataPath = L + (comboBox1.Text) + "\\";
        //            if (Global.conData.State == ConnectionState.Closed) Global.Open_DataConn("Data", "conData");

        //            TVPM.Nodes.Add("R1", Global.DataPath + "Data");
        //            TVPM.Nodes["R1"].Tag = "R1";
        //            ts = Global.conData.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, null });// "TABLE"
        //            foreach (DataRow row in ts.Rows)
        //            {
        //                tbname = row["TABLE_NAME"].ToString();
        //                if ((tbname.Substring(0, 2) == "PM"))
        //                {
        //                    if ((tbname.Substring(7, 3).ToString()) == comboBox1.Text.Substring(0, 3))
        //                    {
        //                        TVGen.Nodes["R1"].Nodes.Add("D", tbname);
        //                    }
        //                }
        //                TVGen.Nodes["R1"].Expand();
        //                ts.Dispose();
        //            }
        //            label7.Text = "Test Engine Data";
        //            Global.conData.Close();
        //            //foreach (DataRow row in ts1.Rows)
        //            //{
        //            //    tbname = row["TABLE_NAME"].ToString();
        //            //    if (((tbname.Substring(0, 2).ToString()) == "PM"))
        //            //    {
        //            //        TVGen.Nodes["R1"].Nodes.Add("D", tbname);
        //            //    }

        //            //    TVGen.Nodes["R1"].Expand();
        //            //    ts1.Dispose();
        //            //}
        //            //label7.Text = " PM Data";
        //            //Global.conData.Close();
        //        }
              
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error Code:- 17004",ex.Message);
        //    }
           
        //}

        //private void Load_MESData() 
        //{

        //    string tbname;
        //    DataTable ts1;
        //    String DataPath;
           
        //    try
        //    {
        //        TvMes.Nodes.Clear();               
        //        DataTable ts;
              
        //        TvMes.BringToFront();

        //        TvMes.Nodes.Clear();
        //        DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + comboBox1.Text + "\\Inst_Data\\";
        //        TvMes.Nodes.Add("R1", DataPath);
        //        TvMes.Nodes["R1"].Tag = "R1";
        //        int M = DataPath.Length;
        //        if (System.IO.Directory.Exists(DataPath) == true)
        //        {
        //            String[] files1 = System.IO.Directory.GetFiles(DataPath);  // + comboBox1.Text);
        //            foreach (string fnm in files1)
        //            {
        //                N = fnm.Length - 4;

        //                if (fnm.Substring(N) == ".csv")
        //                {
        //                    TvMes.Nodes["R1"].Nodes.Add("D", fnm.Substring(M, (N - M)));
        //                }
        //            }

        //        }
        //        TvMes.ExpandAll(); 


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error Code:- 17004", ex.Message);
        //    }
           
            
            //checkedListBox1.Items.Clear();
            //try
            //{

            //    TvMes.Nodes.Clear();
            //    if (Global.conMES.State == ConnectionState.Closed) Global.Open_Connection("MESData", "conMES");

            //        TvMes.Nodes.Add("R2", "MESData");
            //        TvMes.Nodes["R2"].Tag = "R2";
            //        TvMes.Nodes["R2"].Nodes.Add("D", "GenMES");
            //        TvMes.Nodes["R2"].Expand();
            //        label7.Text = " MES Data";   
            //        Global.conMES.Close();
            //}               
            
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error Code:- 17004", ex.Message);
            //}

        //}


       
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
                MessageBox.Show("Error Code:- 17005",ex.Message);
            }
        }
        
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {               
        //        //cmdRd.Enabled = false;
        //        TVreport.Nodes.Clear();
        //        TVreport.Enabled = true;
        //        TVPM.Enabled = false;
               
        //        Load_TV_Date();                   
        //        panel3.Enabled = true ;
        //        gridview1.Rows.Clear();
        //        gridview1.Columns.Clear();             
               
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error Code:- 15006",ex.Message);
        //    }
           
        //}

        private void Read_Headers()
        {
            try
            {
                if (Global.conData.State == ConnectionState.Closed) Global.Open_DataConn("Data", "conData");

                OleDbDataAdapter adps = new OleDbDataAdapter("Select * from EngDetails Where FileName = '" + label1.Text + "'", Global.conData);
                DataSet dss = new DataSet();
                adps.Fill(dss);
                string file_Nm;

                file_Nm = label1.Text;
                for (int x = 0; x <= 17; x++)
                {
                    Perfno[x] = dss.Tables[0].Rows[0].ItemArray[x+1].ToString();                  
                    dataGridView1[1, x].Value = dss.Tables[0].Rows[0].ItemArray[x+1].ToString();
                }

                adps.Dispose();
                dss.Dispose();
                Global.conData.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("THERE IS NO HEADER DATA ......", ex.Message);
            }

        }

        private void Transfer_Perf_excel()
        {
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
                String[] Perfno = new String[50];
                String[] Perfhead = new String[50];
                String[] Perfunit = new String[50];

                PBar1.Text = "Wait for Data Transfer To excel Sheet.........";

                object misValue = System.Reflection.Missing.Value;
                int i, k;
                int j, rx;
                xlApp = new Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Open(Global.PATH + "Performance.xltx", 0, misValue, 4, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("Performance");
                xlWorkSheet.get_Range("B12", "X27").ClearContents(); // .Clear();
                xlWorkSheet.get_Range("B31", "M48").ClearContents();
                //-------------------------
                xlWorkSheet.Cells[3, 20] = dataGridView1[0, 1].Value.ToString();
                xlWorkSheet.Cells[5, 20] = "ECB - 200";
                xlWorkSheet.Cells[6, 20] = dataGridView1[14, 1].Value.ToString();
                xlWorkSheet.Cells[7, 20] = dataGridView1[15, 1].Value.ToString();
                xlWorkSheet.Cells[8, 20] = dataGridView1[16, 1].Value.ToString();

                //-----------------------
                xlWorkSheet.Cells[5, 5] = dataGridView1[1, 1].Value.ToString();
                xlWorkSheet.Cells[6, 5] = dataGridView1[2, 1].Value.ToString();
                xlWorkSheet.Cells[7, 5] = dataGridView1[3, 1].Value.ToString();
                xlWorkSheet.Cells[8, 5] = dataGridView1[4, 1].Value.ToString();
                ////----------------------------
                xlWorkSheet.Cells[5, 11] = dataGridView1[5, 1].Value.ToString();
                xlWorkSheet.Cells[6, 11] = dataGridView1[6, 1].Value.ToString();
                xlWorkSheet.Cells[7, 11] = dataGridView1[7, 1].Value.ToString();
                xlWorkSheet.Cells[8, 11] = dataGridView1[8, 1].Value.ToString();
                //------------------------
                xlWorkSheet.Cells[5, 16] = dataGridView1[9, 1].Value.ToString();
                xlWorkSheet.Cells[6, 16] = dataGridView1[10, 1].Value.ToString();
                xlWorkSheet.Cells[7, 16] = dataGridView1[11, 1].Value.ToString();
                xlWorkSheet.Cells[8, 16] = dataGridView1[12, 1].Value.ToString();

                ////-------------------------- 

                Global.Open_Connection("General", "con");
                OleDbDataAdapter adp2 = new OleDbDataAdapter("Select * from Tb_Perf ", Global.con);
                DataSet ds2 = new DataSet();
                adp2.Fill(ds2);
                PBar1.Visible = true;
                PBar1.Value = (int)1;
                PBar1.Text = "Wait Data For Transfer .......";

                k = ds2.Tables[0].Rows.Count;
                for (i = 0; i <= 19; i++)
                {
                    Perfno[i] = ds2.Tables[0].Rows[i].ItemArray[1].ToString();
                    Perfhead[i] = ds2.Tables[0].Rows[i].ItemArray[2].ToString();
                    Perfunit[i] = ds2.Tables[0].Rows[i].ItemArray[3].ToString();
                }
                adp2.Dispose();
                ds2.Dispose();
                Global.con.Close();

                for (i = 0; i <= 19; i++)
                {
                    xlWorkSheet.Cells[9, 2 + i] = Perfhead[i];
                    xlWorkSheet.Cells[10, 2 + i] = Perfunit[i];
                }
                String Eng_FNm = dataGridView1[1, 0].Value.ToString();

                //prgT.Value = (int)1;
                //int r1 = 0;
                //k = 27;
                //for (int m = Rstart; m <= Rstop - 1; m++)
                //{
                //    //prgT.Value = (int)(m + 1);
                //    //Excel.Range Line = (Excel.Range)xlWorkSheet.Rows[(m + 12), misValue];
                //    //Line = Line.EntireRow;
                //    //Line.Insert(Excel.XlInsertShiftDirection.xlShiftDown, misValue);
                //    for (int n = 0; n <= k - 1; n++)
                //    {
                //        xlWorkSheet.Cells[m + 12, n + 2] = GDView[Convert.ToInt32(Perfno[n]), m].Value.ToString();   //GDView[n, m].Value.ToString();   //
                //    }
                //    r1++;
                //}

                rx = GDView.RowCount - 1;
                PBar1.Maximum = rx + 1;
                if (rx >= 15) rx = 15;

                PBar1.Maximum = rx + 1;
                PBar1.Value = (int)1;

                for (int m = 0; m <= rx - 1; m++)
                {
                    //prgT.Value = (int)(m + 1);
                    //Excel.Range Line = (Excel.Range)xlWorkSheet.Rows[(m + 12), misValue];
                    //Line = Line.EntireRow;
                    //Line.Insert(Excel.XlInsertShiftDirection.xlShiftDown, misValue);
                    for (int n = 0; n <= 19; n++)
                    {
                        xlWorkSheet.Cells[m + 12, n + 2] = GDView[int.Parse(Perfno[n]), m].Value.ToString();   //GDView[n, m].Value.ToString();   //
                    }

                    //****************************************
                    xlWorkSheet.Cells[m + 31, 2] = GDView[0, m].Value.ToString();
                    xlWorkSheet.Cells[m + 31, 3] = GDView[1, m].Value.ToString();
                    xlWorkSheet.Cells[m + 31, 4] = GDView[107, m].Value.ToString();
                    xlWorkSheet.Cells[m + 31, 5] = GDView[108, m].Value.ToString();
                    xlWorkSheet.Cells[m + 31, 6] = GDView[109, m].Value.ToString();
                    xlWorkSheet.Cells[m + 31, 7] = GDView[105, m].Value.ToString();
                    xlWorkSheet.Cells[m + 31, 8] = GDView[111, m].Value.ToString();
                    xlWorkSheet.Cells[m + 31, 9] = GDView[112, m].Value.ToString();
                    xlWorkSheet.Cells[m + 31, 10] = GDView[101, m].Value.ToString();
                    xlWorkSheet.Cells[m + 31, 11] = GDView[102, m].Value.ToString();
                    xlWorkSheet.Cells[m + 31, 12] = GDView[119, m].Value.ToString();
                    xlWorkSheet.Cells[m + 31, 13] = GDView[113, m].Value.ToString();
                    PBar1.Value = m + 1;

                }
                xlWorkSheet.Cells[33, 17] = dataGridView1[17, 1].Value.ToString();
                xlWorkSheet.Cells[35, 17] = dataGridView1[18, 1].Value.ToString();

                //Global.conData.Close();
                PBar1.Text = "Data Transfer Over .......";
                xlWorkBook.SaveAs((object)(Global.DataPath + label1.Text), misValue, misValue, misValue, false, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                //xlWorkBook.SaveAs((object)(Global.DataPath + "Perf_" + Eng_FNm.Substring(4)), misValue, misValue, misValue, false, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);

                xlApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 17007", ex.Message);
            }



        }
        private void Transfer_Endu_excel()
        {
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
                String[] Enduno = new String[30];
                String[] Enduhead = new String[30];
                String[] Enduunit = new String[30];
                string cell1, cell2;
                object misValue = System.Reflection.Missing.Value;
                int i, k;
                int j, rx;
                PBar1.Text = "Wait for Data Transfer To excel Sheet.........";
                xlApp = new Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Open(Global.PATH + "Endurance.xltx", 0, misValue, 4, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("Endurance");
                xlWorkSheet.get_Range("B12", "U2000").Clear();
                //-------------------------
                xlWorkSheet.Cells[2, 19] = DateTime.Now.ToString("dd/MM/yyyy");
                xlWorkSheet.Cells[3, 19] = dataGridView1[16, 1].Value.ToString();
                //-----------------------
                xlWorkSheet.Cells[4, 4] = dataGridView1[1, 1].Value.ToString();
                xlWorkSheet.Cells[5, 4] = dataGridView1[4, 1].Value.ToString();
                xlWorkSheet.Cells[6, 4] = dataGridView1[6, 1].Value.ToString();
                xlWorkSheet.Cells[7, 4] = dataGridView1[7, 1].Value.ToString();
                xlWorkSheet.Cells[8, 4] = dataGridView1[5, 1].Value.ToString();
                xlWorkSheet.Cells[9, 4] = dataGridView1[8, 1].Value.ToString();
                //------------------------
                xlWorkSheet.Cells[5, 8] = dataGridView1[15, 1].Value.ToString();
                xlWorkSheet.Cells[6, 8] = dataGridView1[14, 1].Value.ToString();
                xlWorkSheet.Cells[7, 8] = dataGridView1[2, 1].Value.ToString();
                xlWorkSheet.Cells[8, 8] = "0.835";

                //-------------------------- 
                xlWorkSheet.Cells[5, 12] = dataGridView1[9, 1].Value.ToString();
                xlWorkSheet.Cells[6, 13] = dataGridView1[10, 1].Value.ToString();
                xlWorkSheet.Cells[7, 14] = dataGridView1[11, 1].Value.ToString();
                xlWorkSheet.Cells[8, 15] = dataGridView1[12, 1].Value.ToString();
                //----------------------------------
                xlWorkSheet.Cells[5, 16] = dataGridView1[17, 1].Value.ToString();
                xlWorkSheet.Cells[6, 16] = dataGridView1[18, 1].Value.ToString();

                //xlWorkSheet.Cells[8, 16] = Global.cumhours;


                Global.Open_Connection("General", "con");
                OleDbDataAdapter adp2 = new OleDbDataAdapter("Select * from Tb_Endu ", Global.con);
                DataSet ds2 = new DataSet();
                adp2.Fill(ds2);
                PBar1.Visible = true;
                PBar1.Value = (int)1;
                PBar1.Text = "Wait Data For Transfer .......";

                k = 20;
                for (i = 0; i <= k - 1; i++)
                {
                    Enduno[i] = ds2.Tables[0].Rows[i].ItemArray[1].ToString();
                    Enduhead[i] = ds2.Tables[0].Rows[i].ItemArray[2].ToString();
                    xlWorkSheet.Cells[10, i + 2] = ds2.Tables[0].Rows[i].ItemArray[2].ToString();
                    Enduunit[i] = ds2.Tables[0].Rows[i].ItemArray[3].ToString();
                    xlWorkSheet.Cells[11, i + 2] = ds2.Tables[0].Rows[i].ItemArray[3].ToString();
                }
                k = i;
                adp2.Dispose();
                ds2.Dispose();
                Global.con.Close();
                String Eng_FileNm = dataGridView1[1, 0].Value.ToString();

                rx = GDView.RowCount - 1;
                PBar1.Maximum = rx + 1;
                PBar1.Value = (int)1;

                for (int m = 0; m <= rx - 1; m++)
                {
                    PBar1.Value = (int)(m + 1);
                    for (int n = 0; n <= k - 1; n++)
                    {
                        xlWorkSheet.Cells[m + 12, n + 2] = GDView[int.Parse(Enduno[n]), m].Value.ToString();  // ds1.Tables[0].Rows[m].ItemArray[int.Parse(Enduno[n])].ToString();
                    }
                    PBar1.Value = m;
                }

                //Global.Open_Connection("Data", "conData");
                //OleDbDataAdapter adp1 = new OleDbDataAdapter("Select * from " + Eng_FileNm + " Order by Pn", Global.conData);
                //DataSet ds1 = new DataSet();
                //adp1.Fill(ds1);
                //rx = ds1.Tables[0].Rows.Count;

                //prgT.Maximum = rx + 1;
                //prgT.Value = (int)1;
                //for (int m = 0; m <= rx - 1; m++)
                //{
                //    prgT.Value = (int)(m + 1);
                //    for (int n = 0; n <= k - 1; n++)
                //    {
                //        xlWorkSheet.Cells[m + 12, n + 2] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Enduno[n])].ToString();
                //    }
                //    prgT.Value = m;
                //}
                //Global.conData.Close();

                PBar1.Text  = "Data Transfer Over .......";
                //cell3 = "B8";
                //cell4 = "AB10";
                cell1 = "B12";
                cell2 = "U" + (rx + 12);
                xlWorkSheet.get_Range(cell1, cell2).Font.Size = 11; //style.FontStyle.Color = Color.White;
                xlWorkSheet.get_Range(cell1, cell2).Font.ColorIndex = 5;
                xlWorkSheet.get_Range(cell1, cell2).Font.Name = "Book Antiqua";
                xlWorkSheet.get_Range(cell1, cell2).Borders.ColorIndex = 15;
                xlWorkSheet.get_Range(cell1, cell2).Borders.LineStyle = Excel.XlBorderWeight.xlHairline;
                xlWorkSheet.get_Range(cell1, cell2).BorderAround(Excel.XlLineStyle.xlDouble, Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);


                xlWorkBook.SaveAs((object)(Global.DataPath + "Endu_" + Eng_FileNm.Substring(4)), misValue, misValue, misValue, false, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);

                xlApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is no Header Data.......", ex.Message);
               
                //return;
            }

        }


        private void Transfer_Excel_Gen()
        {
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
                String[] Enduno = new String[40];
                String[] Enduhead = new String[40];
                String[] Enduunit = new String[40];
                string cell1, cell2, cell3, cell4;
                object misValue = System.Reflection.Missing.Value;
                int i, k, rx;
                xlApp = new Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Open(Global.PATH + "Performance.xltx", 0, misValue, 4, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                //********************************


                ctlLED1.tmron = false;
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("FTP");
                xlWorkSheet.get_Range("A12", "AJ2000").Clear();
                ////---------------------------------------     
                xlWorkSheet.Cells[4, 3] = Perfno[0];
                xlWorkSheet.Cells[8, 3] = Perfno[1];
                xlWorkSheet.Cells[4, 7] = Perfno[2];
                xlWorkSheet.Cells[5, 7] = Perfno[3];
                xlWorkSheet.Cells[8, 7] = Perfno[4];
                xlWorkSheet.Cells[4, 25] = Perfno[5];
                //xlWorkSheet.Cells[5, 25] = Perfno[6];
                xlWorkSheet.Cells[8, 25] = Perfno[6];//stop tm
                xlWorkSheet.Cells[6, 25] = Perfno[7];
                xlWorkSheet.Cells[7, 25] = Perfno[8];
                xlWorkSheet.Cells[1, 20] = Perfno[9];
                //xlWorkSheet.Cells[3, 20] = Perfno[10];
                xlWorkSheet.Cells[8, 29] = Perfno[10];//strt tm
                xlWorkSheet.Cells[4, 20] = Perfno[11];
                xlWorkSheet.Cells[3, 25] = Perfno[12];
                xlWorkSheet.Cells[5, 3] = Perfno[13];
                xlWorkSheet.Cells[6, 7] = Perfno[14];
                xlWorkSheet.Cells[6, 9] = Perfno[15];
                xlWorkSheet.Cells[6, 11] = Perfno[16];
                xlWorkSheet.Cells[6, 7] = Perfno[14];
                xlWorkSheet.Cells[6, 9] = Perfno[15];
                xlWorkSheet.Cells[6, 11] = Perfno[16];
                //xlWorkSheet.Cells[2, 19] = DateTime.Now.ToString("dd/MM/yyyy");
                xlWorkSheet.Cells[3, 19] = Global.T_CellNo;
                xlWorkSheet.Cells[7, 3] = "9550";
                xlWorkSheet.Cells[6, 15] = Perfno[17];
                xlWorkSheet.Cells[7, 7] = "II";
                //-----------------------


                //}



                Global.Open_Connection("General", "con");
                OleDbDataAdapter adp2 = new OleDbDataAdapter("Select * from Tb_Report ", Global.con);
                DataSet ds2 = new DataSet();
                adp2.Fill(ds2);
                PBar1.Visible = true;
                PBar1.Value = (int)1;
                PBar1.Text = "Wait For Data Transfer .......";

                k = ds2.Tables[0].Rows.Count - 1;
                for (i = 0; i <= k; i++)
                {
                    Enduno[i] = ds2.Tables[0].Rows[i].ItemArray[1].ToString();
                    Enduhead[i] = ds2.Tables[0].Rows[i].ItemArray[2].ToString();
                    xlWorkSheet.Cells[10, i + 1] = ds2.Tables[0].Rows[i].ItemArray[2].ToString();
                    Enduunit[i] = ds2.Tables[0].Rows[i].ItemArray[3].ToString();
                    xlWorkSheet.Cells[11, i + 1] = ds2.Tables[0].Rows[i].ItemArray[3].ToString();
                }
                k = i;
                adp2.Dispose();
                ds2.Dispose();
                Global.con.Close();
                Global.Open_Connection("Data", "conData");
                OleDbDataAdapter adp1 = new OleDbDataAdapter("Select * from " + label1.Text + " Order by Pn", Global.conData);
                DataSet ds1 = new DataSet();
                adp1.Fill(ds1);
                rx = ds1.Tables[0].Rows.Count;

                PBar1.Maximum = rx + 1;
                PBar1.Value = (int)1;
                for (int m = 0; m <= rx - 1; m++)
                {
                    // xlWorkSheet.Cells[m + 11, 2] = m + 1;
                    PBar1.Value = (int)(m + 1);

                    double nsfc = Convert.ToDouble(ds1.Tables[0].Rows[m].ItemArray[88]);
                    double ncf = Convert.ToDouble(ds1.Tables[0].Rows[m].ItemArray[83]);
                    double ncsfc = nsfc / ncf;
                    for (int n = 0; n <= k-1; n++)
                    {
                        xlWorkSheet.Cells[m + 12, n + 1] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Enduno[n]) - 20].ToString();
                    }
                    xlWorkSheet.Cells[m + 12, 18] = ncsfc.ToString("000.0");
                }
                Global.conData.Close();

                PBar1.Text = "Data Transfer Over .......";
                //cell3 = "B8";
                //cell4 = "AB10";
                cell1 = "A12";
                cell2 = "AJ" + (rx + 12);
                xlWorkSheet.get_Range(cell1, cell2).Font.Size = 11; //style.FontStyle.Color = Color.White;
                xlWorkSheet.get_Range(cell1, cell2).Font.ColorIndex = 5;
                xlWorkSheet.get_Range(cell1, cell2).Font.Name = "Calibri";
                xlWorkSheet.get_Range(cell1, cell2).Borders.ColorIndex = 15;
                xlWorkSheet.get_Range(cell1, cell2).Borders.LineStyle = Excel.XlBorderWeight.xlHairline;
                xlWorkSheet.get_Range(cell1, cell2).BorderAround(Excel.XlLineStyle.xlDouble, Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);


                xlWorkBook.SaveAs((object)(Global.DataPath + "Prod_" + label1.Text.Substring(4)), misValue, misValue, misValue, false, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);

                xlApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("DATA GRID NOT SAVED PROPERLY : Error Code:- 17007", ex.Message);
                //return;
            }
            //try
            //{                  
            //    Excel.Application xlApp;
            //    Excel.Workbook xlWorkBook;
            //    Excel.Worksheet xlWorkSheet;
            //    String[] Gen_no = new String[40];
            //    String[] Gen_head = new String[40];
            //    String[] Gen_unit = new String[40];
            //    string cell1, cell2, cell3, cell4;
            //    object misValue = System.Reflection.Missing.Value;
            //    int i, k, rx;
                

            //    Process[] prs = Process.GetProcesses();
            //    foreach (Process pr in prs)
            //    {
            //        if ((pr.ProcessName == "EXCEL")||(pr.ProcessName == "excel")) pr.Kill();
            //    } 
            //    xlApp = new Excel.ApplicationClass();


            //    xlWorkBook = xlApp.Workbooks.Open(Global.PATH + "Performance.xltx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);    //misValue
            //    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("FTP");


            //    xlWorkSheet.get_Range("A12", "AJ2000").Clear();
            //    ////---------------------------------------     
            //    xlWorkSheet.Cells[4, 3] = Perfno[0];
            //    xlWorkSheet.Cells[8, 3] = Perfno[1];
            //    xlWorkSheet.Cells[4, 7] = Perfno[2];
            //    xlWorkSheet.Cells[5, 7] = Perfno[3];
            //    xlWorkSheet.Cells[8, 7] = Perfno[4];
            //    xlWorkSheet.Cells[4, 25] = Perfno[5];
            //    //xlWorkSheet.Cells[5, 25] = Perfno[6];
            //    xlWorkSheet.Cells[8, 25] = Perfno[6];//stop tm
            //    xlWorkSheet.Cells[6, 25] = Perfno[7];
            //    xlWorkSheet.Cells[7, 25] = Perfno[8];
            //    xlWorkSheet.Cells[1, 20] = Perfno[9];
            //    //xlWorkSheet.Cells[3, 20] = Perfno[10];
            //    xlWorkSheet.Cells[8, 29] = Perfno[10];//strt tm
            //    xlWorkSheet.Cells[4, 20] = Perfno[11];
            //    xlWorkSheet.Cells[3, 25] = Perfno[12];
            //    xlWorkSheet.Cells[5, 3] = Perfno[13];
            //    xlWorkSheet.Cells[6, 7] = Perfno[14];
            //    xlWorkSheet.Cells[6, 9] = Perfno[15];
            //    xlWorkSheet.Cells[6, 11] = Perfno[16];
            //    xlWorkSheet.Cells[6, 7] = Perfno[14];
            //    xlWorkSheet.Cells[6, 9] = Perfno[15];
            //    xlWorkSheet.Cells[6, 11] = Perfno[16];
            //    //xlWorkSheet.Cells[2, 19] = DateTime.Now.ToString("dd/MM/yyyy");
            //    xlWorkSheet.Cells[3, 19] = Global.T_CellNo;
            //    xlWorkSheet.Cells[7, 3] = "9550";
            //    xlWorkSheet.Cells[6, 15] = Perfno[17];
            //    xlWorkSheet.Cells[7, 7] = "II";
            //    //-----------------------


            //    //}



            //    Global.Open_Connection("General", "con");
            //    OleDbDataAdapter adp3 = new OleDbDataAdapter("Select * from Tb_Report ", Global.con);
            //    DataSet ds3 = new DataSet();
            //    adp3.Fill(ds3);
            //    PBar1.Visible = true;
            //    PBar1.Value = (int)1;
            //    PBar1.Text = "Wait For Data Transfer .......";

            //    k = ds3.Tables[0].Rows.Count - 1;
            //    for (i = 0; i <= k; i++)
            //    {
            //        Gen_no[i] = ds3.Tables[0].Rows[i].ItemArray[1].ToString();
            //        Gen_head[i] = ds3.Tables[0].Rows[i].ItemArray[2].ToString();
            //        xlWorkSheet.Cells[10, i + 1] = ds3.Tables[0].Rows[i].ItemArray[2].ToString();
            //        Gen_unit[i] = ds3.Tables[0].Rows[i].ItemArray[3].ToString();
            //        xlWorkSheet.Cells[11, i + 1] = ds3.Tables[0].Rows[i].ItemArray[3].ToString();
            //    }
            //    k = i;
            //    adp3.Dispose();
            //    ds3.Dispose();
            //    Global.con.Close();
            //    Global.Open_Connection("Data", "conData");
            //    OleDbDataAdapter adp1 = new OleDbDataAdapter("Select * from " + label1.Text + " Order by Pn", Global.conData);
            //    DataSet ds1 = new DataSet();
            //    adp1.Fill(ds1);
            //    rx = ds1.Tables[0].Rows.Count;

            //    PBar1.Maximum = rx + 1;
            //    PBar1.Value = (int)1;
            //    for (int m = 0; m <= rx - 1; m++)
            //    {
            //        // xlWorkSheet.Cells[m + 11, 2] = m + 1;
            //        PBar1.Value = (int)(m + 1);

            //        double nsfc = Convert.ToDouble(ds1.Tables[0].Rows[m].ItemArray[88]);
            //        double ncf = Convert.ToDouble(ds1.Tables[0].Rows[m].ItemArray[83]);
            //        double ncsfc = nsfc / ncf;
            //        k = ds3.Tables[0].Rows.Count - 1;
            //        for (int n = 0; n <= k; n++)
            //        {
            //            xlWorkSheet.Cells[m + 12, n + 1] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Gen_no[n]) - 20].ToString();
            //        }
            //        xlWorkSheet.Cells[m + 12, 18] = ncsfc.ToString("000.0");
            //    }
            //    Global.conData.Close();

            //    PBar1.Text = "Data Transfer Over .......";
            //    //cell3 = "B8";
            //    //cell4 = "AB10";
            //    cell1 = "A12";
            //    cell2 = "AJ" + (rx + 12);
            //    xlWorkSheet.get_Range(cell1, cell2).Font.Size = 11; //style.FontStyle.Color = Color.White;
            //    xlWorkSheet.get_Range(cell1, cell2).Font.ColorIndex = 5;
            //    xlWorkSheet.get_Range(cell1, cell2).Font.Name = "Calibri";
            //    xlWorkSheet.get_Range(cell1, cell2).Borders.ColorIndex = 15;
            //    xlWorkSheet.get_Range(cell1, cell2).Borders.LineStyle = Excel.XlBorderWeight.xlHairline;
            //    xlWorkSheet.get_Range(cell1, cell2).BorderAround(Excel.XlLineStyle.xlDouble, Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);


            //    xlWorkBook.SaveAs((object)(Global.DataPath + "Endu_" + label1.Text.Substring(4)), misValue, misValue, misValue, false, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);

            //    xlApp.Visible = true;
            //    //k = gridview1.RowCount;
            //    //PBar1.Maximum = k;
            //    ////////PBar1.Visible = true;
            //    //ctlLED1.tmron = false; 
            //    //PBar1.Value = 1;
            //    //PBar1.Text = "Wait Data For Transfer .......";
            //    //xlWorkSheet.get_Range("B6", "CH4000").Clear();
            //    //for (j = 0; j <= gridview1.ColumnCount - 3; j++)
            //    //{
            //    //    int pos = 0;
            //    //    pos = Convert.ToInt16(gridview1.Columns[j].HeaderText.IndexOf(" ", 1));
            //    //    if (pos > 0)
            //    //    {
            //    //        xlWorkSheet.Cells[4, j + 3] = gridview1.Columns[j].HeaderText.Substring(0, pos).ToString();                        
            //    //        xlWorkSheet.Cells[5, j + 3] = gridview1.Columns[j].HeaderText.Substring(pos).ToString();
            //    //    }
            //    //}
            //    //xlWorkSheet.Cells[4, j + 3] = "EngNo";
            //    //xlWorkSheet.Cells[5, j + 3] = "****";
            //    //xlWorkSheet.Cells[4, j + 4] = "Pn";
            //    //xlWorkSheet.Cells[5, j + 4] = "****";
            //    //for (i = 0; i <= gridview1.RowCount - 1; i++)
            //    //{
            //    //    PBar1.Value = i;                    
            //    //    for (j = 0; j <= gridview1.ColumnCount - 1; j++)
            //    //    {
            //    //        DataGridViewCell cell = gridview1[j, i];
            //    //        xlWorkSheet.Cells[i + 6, j + 3] = cell.Value;                      
            //    //    }
            //    //    PBar1.Value = i;
            //    //}



            //    //PBar1.Text = "Data Transfer Over .......";
            //    //cell3 = "B4";
            //    //cell4 = "Ch5";
            //    //cell1 = "B6";
            //    //cell2 = "Ch" + (k + 6);
            //    //xlWorkSheet.get_Range(cell1, cell2).Font.Size = 10;
            //    //xlWorkSheet.get_Range(cell1, cell2).Font.ColorIndex = 5; // 23;
            //    //xlWorkSheet.get_Range(cell1, cell2).Font.Name ="Calibri";
            //    //xlWorkSheet.get_Range(cell1, cell2).Borders.ColorIndex = 15;    // 23;
            //    //xlWorkSheet.get_Range(cell1, cell2).Borders.LineStyle = Excel.XlBorderWeight.xlHairline;
            //    //xlWorkSheet.get_Range(cell1, cell2).BorderAround(Excel.XlLineStyle.xlDouble, Excel.XlBorderWeight.xlHairline, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            //    //xlWorkSheet.get_Range(cell3, cell4).Borders.LineStyle = Excel.XlBorderWeight.xlHairline;
            //    //xlWorkSheet.get_Range(cell3, cell4).Font.Size = 10;

            //    //xlWorkSheet.get_Range(cell3, cell4).Font.Bold = false;
            //    //xlWorkSheet.get_Range(cell3, cell4).Borders.ColorIndex = 15;
            //    ////xlWorkSheet.get_Range(cell3, cell4).Font.ColorIndex = 5; //37;  //
            //    //xlWorkSheet.get_Range("B4", "Ch4").Font.ColorIndex = 5;
            //    //xlWorkSheet.get_Range("B5", "Ch5").Font.ColorIndex = 9;
            //    //xlWorkSheet.get_Range(cell3, cell4).Font.Name = "Calibri";
            //    //xlWorkSheet.get_Range(cell3, cell4).BorderAround(Excel.XlLineStyle.xlDouble, Excel.XlBorderWeight.xlHairline, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);
            //    //xlApp.Visible = true;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error Code:-17009",ex.Message);
            //}
        }

        //private void pMFileToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        flg_PMCHK = true;
        //        flg_ProdChk = false;
        //        flg_Multichk = false;

        //        gridview1.Rows.Clear();
        //        gridview1.Columns.Clear();// .Refresh();
        //        TVreport.Nodes.Clear();
              
        //        TVreport.SendToBack();
        //        TVPM.BringToFront();
        //        TVPM.Enabled = true;
        //        Load_PMData();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error Code:- 17010",ex.Message);
        //    }

        //}

        //private void productionFileToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        flg_ProdChk = true;
        //        flg_PMCHK = false;
        //        flg_Multichk = false;

        //        gridview1.Rows.Clear();
        //        gridview1.Columns.Clear();
        //        TVPM.Nodes.Clear();
             
        //        TVPM.SendToBack();
        //        TVreport.BringToFront();
        //        TVreport.Enabled = true;
        //        Load_TV_Date();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error Code:- 17011",ex.Message);
        //    }

        //}

        private void MuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //flg_Multichk = true;
                //flg_delete = false;
                //flg_PMCHK = false;
                //flg_ProdChk = false;
                //cmdRd.Enabled = false;
                ////gridview1.Rows.Clear();
                ////gridview1.RowCount  = 0;  
                //gridview1.Refresh();
                //gridview1.DataSource = null;
                //gridview1.Columns.Clear();
                //gridview1.Rows.Clear();
                //TV.Nodes.Clear();
                //TVPM.Nodes.Clear();
                //checkedListBox1.BringToFront();

                //TVPM.SendToBack();
                //TV.SendToBack();
                //checkedListBox1.Enabled = true;
                //LoadMulti();
                //panel1.Enabled = false;
                //panel2.Enabled = false;
                //panel3.Enabled = false;
                //textBox2.Enabled = false;
                //textBox3.Enabled = false;
                //DeleteFilesToolStripMenuItem.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 17012",ex.Message);
            }

        }

        //private void TVPM_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    try
        //    {
        //        NodeT = TVPM.SelectedNode.Text;
        //        if ((TVPM.SelectedNode.Tag != "D") || (TVPM.SelectedNode.Tag != "R1"))
        //        {
        //            //cmdRd.Enabled = true;
        //            label1.Text = TVPM.SelectedNode.Text;
        //        }               
        //        panel3.Enabled = false;
        //        View_Data();
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show("Error Code:- 17013", ex.Message);
        //    }   

        //}
        //private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        OleDbDataAdapter adp, adp1;
        //        DataSet ds = new DataSet();
        //        DataSet ds1 = new DataSet();
        //        gridview1.Rows.Clear();
        //        gridview1.RowCount = 2;
        //        gridview1.ColumnCount = 4;
        //        int chk = checkedListBox1.CheckedItems.Count;
        //        cmdRd.Enabled = true;               
        //        panel3.Enabled = false;
        //        label1.Text = checkedListBox1.SelectedItem.ToString();
        //        if (Global.conData.State == ConnectionState.Closed) Global.Open_DataConn("Data", "conData");
        //        adp = new OleDbDataAdapter("Select * from " + label1.Text.Trim(), Global.conData);
        //        adp.Fill(ds);
        //        gridview1.ColumnCount = ds.Tables[0].Columns.Count;

        //        for (int l = 0; l <= ds.Tables[0].Columns.Count - 3; l++)
        //        {
        //            gridview1.Columns[l].Name = ds.Tables[0].Columns[l].ToString().Substring(3) + "  " + Global.PUnit[l];
        //            if ((ds.Tables[0].Columns[l].ToString().Substring(3) !="Not_Prog") || (ds.Tables[0].Columns[l].ToString().Substring(3) !="Not_Prog"))
        //            {
        //                gridview1.Columns[l].Width = 80;
        //            }
        //            else
        //            {
        //                gridview1.Columns[l].Visible = false;
        //            }
        //            //gridview1.Columns[l].Name = ds.Tables[0].Columns[l].ToString();

        //        }

        //        ds.Dispose();
        //        Global.conData.Close();

        //        for (int j = 0; j <= checkedListBox1.Items.Count - 1; j++)
        //        {
        //            int c = gridview1.RowCount;
        //            if (checkedListBox1.GetItemChecked(j) == true)// .ToString() == checkedListBox1.Items[i].ToString() )
        //            {

        //                label1.Text = checkedListBox1.Items[j].ToString();
        //                if (Global.conData.State == ConnectionState.Closed) Global.Open_DataConn("Data", "conData");
        //                adp1 = new OleDbDataAdapter("Select * from " + label1.Text.Trim(), Global.conData);
        //                ds1.Reset();
        //                adp1.Fill(ds1);                       
        //                if ((ds1.Tables[0].Rows.Count) <= 0)
        //                {
        //                    MessageBox.Show("error: File Is Empty Select Another One...!");
        //                    if (flg_delete != true)
        //                    {
        //                        checkedListBox1.SetItemChecked(j, false);
        //                        //break;
        //                    }
        //                    else
        //                    {
        //                        checkedListBox1.SetItemChecked(j, true);
        //                    }
        //                }
        //                gridview1.RowCount = gridview1.Rows.Count + ds1.Tables[0].Rows.Count + 1;

        //                gridview1.Rows[c - 1].Cells[3].Value = "Remark";

        //                for (int k = 0; k <= ds1.Tables[0].Rows.Count - 1; k++)
        //                {

        //                    for (int i = 0; i <= ds1.Tables[0].Columns.Count - 1; i++)
        //                    {
        //                        gridview1.Rows[k + c].Cells[i].Value = ds1.Tables[0].Rows[k].ItemArray[i].ToString();
        //                    }
        //                }
        //                adp1.Dispose();
        //                Global.conData.Close();

        //            }
        //            else
        //            {


        //            }


        //        }
        //    }
        //    catch 
        //    {
        //        MessageBox.Show("Select the file");
        //    }

        //}
                    
      
       
                

        //private void cmdRd_Click(object sender, EventArgs e)
        //{
        //    try
        //     { 
        //            if (label1.Text.Substring(0, 4) == "Perf") Transfer_Perf_excel();
        //            else if (label1.Text.Substring(0, 4) == "Endu") Transfer_Endu_excel();
        //            else Transfer_Excel_Gen();
        //     }
                
            
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error Code:- 17016",ex.Message);
        //    }
           
        //}

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //if (int.Parse(textBox2.Text) <= -1) textBox2.Text = "0";
            //if (int.Parse(textBox2.Text) >= int.Parse(textBox3.Text)) textBox2.Text = "0";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //if (int.Parse(textBox3.Text) >= gridview1.RowCount - 1) textBox3.Text = (gridview1.RowCount).ToString();
            //if (int.Parse(textBox3.Text) <= int.Parse(textBox2.Text)) textBox3.Text = (gridview1.RowCount).ToString();

        }

        //private void mnuGen_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        flg_ProdChk = true;
        //        flg_PMCHK = false;
        //        flg_Multichk = false;
        //        flg_delete = false;
        //        //cmdRd.Enabled = false;                
        //        gridview1.DataSource = null;
        //        gridview1.Columns.Clear();
        //        gridview1.Rows.Clear();
        //        TVPM.Nodes.Clear();
        //        checkedListBox1.Items.Clear();
        //        checkedListBox1.SendToBack();
        //        TVPM.SendToBack();
        //        TVreport.BringToFront();
        //        TVreport.Enabled = true;
        //        Load_TV_Date();
              
        //        panel3.Enabled = true ;
        //        textBox3.Enabled = true;
        //        textBox2.Enabled = true;
        //        DeleteFilesToolStripMenuItem.Enabled = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error Code:- 17017",ex.Message);
        //    }
        //}

        //private void mnuPM_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        flg_PMCHK = true;
        //        flg_ProdChk = false;
        //        flg_Multichk = false;
        //        flg_delete = false;
        //        gridview1.Refresh();
        //        gridview1.DataSource = null;
        //        gridview1.Rows.Clear();
        //        gridview1.Columns.Clear();// .Refresh();
        //        cmdRd.Enabled = false;
        //        TVreport.Nodes.Clear();
        //        checkedListBox1.Items.Clear();
        //        checkedListBox1.SendToBack();
        //        TVreport.SendToBack();
        //        TVPM.BringToFront();
        //        TVPM.Enabled = true;
        //        Load_PMData();               
        //        panel3.Enabled = false;
        //        textBox3.Enabled = true;
        //        textBox2.Enabled = true;
        //        DeleteFilesToolStripMenuItem.Enabled = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error Code:- 17018",ex.Message);
        //    }
        //}

        //private void DeleteFilesToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        flg_delete = true;
        //        OleDbCommand cmd;
        //        DataSet ds = new DataSet();
        //        DataSet ds1 = new DataSet();
        //        gridview1.Rows.Clear();
        //        gridview1.RowCount = 2;
        //        gridview1.ColumnCount = 4;
             
        //        //            cmdRd.Enabled = true;
        //        for (int i = 0; i <= chk - 1; i++)
        //        {
                   
        //        }
        //        LoadMulti();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error Code:- 17019 ",ex.Message);
        //    }
           
        //}

        //private void menuMes_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        flg_MESchk = true;
        //        flg_PMCHK = false;
        //        flg_ProdChk = false;
        //        flg_Multichk = false;
        //        flg_delete = false;
        //        gridview1.DataSource = null;
        //        //gridview1.Rows.Clear();
        //        //gridview1.Columns.Clear();// .Refresh();
        //        TvMes.Nodes.Clear();             
        //        TVreport.SendToBack();
        //        TvMes.BringToFront();
        //        TvMes.Enabled = true;
        //        Load_MESData();
        //        textBox3.Enabled = true;
        //        textBox2.Enabled = true;
        //        DeleteFilesToolStripMenuItem.Enabled = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error Code:- 17018", ex.Message);
        //    }
        //}

        //private void TvMes_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    try
        //    {
        //        NodeT = TvMes.SelectedNode.Text;
        //        if ((TvMes.SelectedNode.Tag != "R1") || (TvMes.SelectedNode.Tag != "R1"))
        //        {
        //            cmdRd.Enabled = true;
        //            label1.Text = TvMes.SelectedNode.Text;
        //        }

        //        String DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + comboBox1.Text + "\\Inst_Data\\"; 
        //        string strFileName = DataPath + label1.Text+".csv";
        //        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + System.IO.Path.GetDirectoryName(strFileName) + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"");
        //        conn.Open();
        //        String Str = label1.Text; 
        //        OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + System.IO.Path.GetFileName(strFileName), conn);
        //        DataSet ds = new DataSet("Temp");
        //        adapter.Fill(ds);
        //        int X = ds.Tables[0].Rows.Count;
        //        gridview1.DataSource = ds.Tables[0];  
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error Code:- 17013", ex.Message);
        //    }     

        //}

        private void button2_Click(object sender, EventArgs e)
        {
            //PBar1.Text = "Wail Data is getting transfer ..........."; 
            if (label1.Text.Substring(0, 4) == "Perf") 
                Transfer_Perf_excel();
            else if (label1.Text.Substring(0, 4) == "Endu") 
                Transfer_Endu_excel();
            //else
            //    Transfer_Excel_Gen();
        }

             
        private void frmShowData_Load(object sender, EventArgs e)
        {
            fill_combo();           
            defaultCombo();
            dataGridView1.RowCount = 2;
            dataGridView1.ColumnCount = 25;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1[0, 0].Value = "File Name";
            dataGridView1[1, 0].Value = "Engine Type";
            dataGridView1[2, 0].Value = "Engine Rating";
            dataGridView1[3, 0].Value = "FIP No";
            dataGridView1[4, 0].Value = "Engine Sr No";
            dataGridView1[5, 0].Value = "No Of Cylinder";
            dataGridView1[6, 0].Value = "Bore Dia.";
            dataGridView1[7, 0].Value = "Stroke";
            dataGridView1[8, 0].Value = "Swept Vol.";
            dataGridView1[9, 0].Value = "Radiator";
            dataGridView1[10, 0].Value = "Cooling Fan";
            dataGridView1[11, 0].Value = "AirCleaner";
            dataGridView1[12, 0].Value = "Silincer";
            dataGridView1[13, 0].Value = "Dyno. Type";
            dataGridView1[14, 0].Value = "Operator Name";
            dataGridView1[15, 0].Value = "Engineer Name";
            dataGridView1[16, 0].Value = "Test-Cell No";
            dataGridView1[17, 0].Value = "Start Time";
            dataGridView1[18, 0].Value = "Stop Time";
            dataGridView1[19, 0].Value = "Comment";
            dataGridView1[20, 0].Value = "Comment";
            dataGridView1[21, 0].Value = "Comment";
            dataGridView1[22, 0].Value = "Comment";
            dataGridView1[23, 0].Value = "Comment";
            dataGridView1[24, 0].Value = "Comment";

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
                    if (label1.Text.Substring(0, 4) == "Perf")
                        label7.Text = "Engine Test Data (Performance)";
                    else if (label1.Text.Substring(0, 4) == "Endu")
                        label7.Text = "Engine Test Data (Endurance)";
                    else if (label1.Text.Substring(0, 4) == "Prod")
                        label7.Text = "Engine Test Data (Production)";
                    else if (label1.Text.Substring(0, 2) == "PM")
                        label7.Text = "Engine Test Data (Post Analysis)";
                    else
                        label7.Text = "Engine Test Data (Unknown)";
                }
              
                View_Data();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 17013", ex.Message);
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

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fill_combo();

            Load_TV_Date();

            dataGridView1.RowCount = 2;
            dataGridView1.ColumnCount = 25;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1[0, 0].Value = "File Name";
            dataGridView1[1, 0].Value = "Engine Type";
            dataGridView1[2, 0].Value = "Engine Rating";
            dataGridView1[3, 0].Value = "FIP No";
            dataGridView1[4, 0].Value = "Engine Sr No";
            dataGridView1[5, 0].Value = "No Of Cylinder";
            dataGridView1[6, 0].Value = "Bore Dia.";
            dataGridView1[7, 0].Value = "Stroke";
            dataGridView1[8, 0].Value = "Swept Vol.";
            dataGridView1[9, 0].Value = "Radiator";
            dataGridView1[10, 0].Value = "Cooling Fan";
            dataGridView1[11, 0].Value = "AirCleaner";
            dataGridView1[12, 0].Value = "Silincer";
            dataGridView1[13, 0].Value = "Dyno. Type";
            dataGridView1[14, 0].Value = "Operator Name";
            dataGridView1[15, 0].Value = "Engineer Name";
            dataGridView1[16, 0].Value = "Test-Cell No";
            dataGridView1[17, 0].Value = "Start Time";
            dataGridView1[18, 0].Value = "Stop Time";
            dataGridView1[19, 0].Value = "Comment";
            dataGridView1[20, 0].Value = "Comment";
            dataGridView1[21, 0].Value = "Comment";
            dataGridView1[22, 0].Value = "Comment";
            dataGridView1[23, 0].Value = "Comment";
            dataGridView1[24, 0].Value = "Comment";

            //***********************************

           

        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
           
        }

        private void comboBox1_MouseUp(object sender, MouseEventArgs e)
        {
            

        }

      
      
        

       
       

        }
    }
//}

       
    

