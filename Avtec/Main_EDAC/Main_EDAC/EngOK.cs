using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Web;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO; 
using System.Diagnostics; 
using System.Windows.Forms;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;


 

namespace Logger
{
    public partial class EngOK : Form
    {
        private frmMain main = new frmMain();
        private String[] EngData = new String[30];
        public EngOK()
        {
            InitializeComponent();
        }

        private void EngOK_Load(object sender, EventArgs e)
        {
            try
            {    
                  
               
               
            }
            catch (Exception ex)
            {
                Global.Create_OnLog(ex.Message + " :  Fill Engine Details....", "Alert");  
                //MessageBox.Show("ErrorCode :- 2001", ex.Message);
            }
        }

        private void fill_Engine_Details()
        {

            String Str = "";
            Global.CStopTm = DateTime.Now.ToString("HH:mm:ss");

            for (int x = 0; x <= 25; x++) EngData[x] = null;
            //string  Str = null;
            EngData[0] = Global.Eng_FileNm;
            EngData[1] = Global.EngType;
            EngData[2] = Global.TestRef;
            EngData[3] = Global.FipNo;
            EngData[4] = Global.EngNo;
            EngData[5] = Global.NCyl;
            EngData[6] = Global.Bor;
            EngData[7] = Global.Strk;
            EngData[8] = Global.Svol;

            if (Global.flg_Radiator == true) EngData[9] = "YES"; else EngData[9] = "NO";
            if (Global.flg_Fan == true) EngData[10] = "YES"; else EngData[10] = "NO";
            if (Global.flg_AirCln == true) EngData[11] = "YES"; else EngData[11] = "NO";
            if (Global.flg_Silincer == true) EngData[12] = "YES"; else EngData[12] = "NO";

            
            EngData[13] = Global.OperatorNm;
            EngData[14] = Global.EnginerNm;
            EngData[15] = Global.T_CellNo;
            EngData[16] = Global.Shift;
            EngData[17] = Global.CStrtTm;
            EngData[18] = Global.CStopTm;
            EngData[19] = Global.cumhours; 
            EngData[20] = DateTime.Now.ToString("dd:MMM:yyyy");      

            if (Global.ErrorMatrix == null) Global.ErrorMatrix = "*******";
            EngData[21] = Global.ErrorMatrix;            
            EngData[22] = Global.Inj_01;
            EngData[23] = Global.Inj_02;
            EngData[24] = Global.Inj_03;
            EngData[25] = Global.Inj_04; 

            Str = "";
            for (int i = 0; i <= 25; i++)
            {
                if ((EngData[i] == null) || (EngData[i] == ""))
                {
                    EngData[i] = "****";
                }
                Str = Str + EngData[i] + ", ";
            }
                        
                Str = Str + "\n";
                var filePath = Global.DataPath + "Gen_Data\\EngDetails.csv";
                using (var wr = new StreamWriter(filePath, true))
                {
                    var row = new List<string> { Str.Substring(0, Str.Length - 1) };
                    var sb = new StringBuilder();
                    foreach (string value in row)
                    {
                        if (sb.Length > 0)
                            sb.Append(",");
                        sb.Append(value);
                    }
                    wr.WriteLine(sb.ToString());
                }
                Global.Create_OnLog("Engine Details File Created.", "Normal");
            }
               

        //}


        //private void Export_Data()
        //{
        //    Excel.Application xlApp;
        //    Excel.Workbook xlWorkBook;
        //    Excel.Worksheet xlWorkSheet;

        //    Process[] prs = Process.GetProcesses();
        //    foreach (Process pr in prs)
        //    {
        //        if (pr.ProcessName == "EXCEL") pr.Kill();
        //    }
        //    try
        //    {
        //        String[] Perfno = new String[50];
        //        String[] Perfhead = new String[50];
        //        String[] Perfunit = new String[50];
        //        string cell1, cell2, cell3, cell4;
        //        object misValue = System.Reflection.Missing.Value;
        //        int i, k;
        //        int j, rx;
        //        xlApp = new Excel.ApplicationClass();
        //        xlWorkBook = xlApp.Workbooks.Open(Global.PATH + "Performance11.xlsx", 0, misValue, 4, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

        //        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("Performance");
        //        // xlWorkSheet.get_Range("B20", "X36").ClearContents(); // .Clear();
        //        //xlWorkSheet.get_Range("B41", "AA57").ClearContents();
        //        if (Global.flg_HDdata == true)
        //        {
        //            for (i = 0; i <= 10; i++)
        //            {
        //                xlWorkSheet.Cells[i + 5, 5] = dataGridView1[i + 1, 1].Value.ToString();
        //            }

        //            for (i = 0; i <= 10; i++)
        //            {
        //                xlWorkSheet.Cells[i + 5, 11] = dataGridView1[i + 12, 1].Value.ToString();
        //            }

        //            for (i = 0; i <= 10; i++)
        //            {
        //                xlWorkSheet.Cells[i + 5, 16] = dataGridView1[i + 23, 1].Value.ToString();
        //            }

        //            for (i = 0; i <= 9; i++)
        //            {
        //                xlWorkSheet.Cells[i + 5, 22] = dataGridView1[i + 34, 1].Value.ToString();
        //            }
        //        }

        //        Global.Open_Connection("gen_db", "con");
        //        MySqlDataAdapter adp2 = new MySqlDataAdapter("Select * from Tb_Perf ", Global.con);
        //        DataSet ds2 = new DataSet();
        //        adp2.Fill(ds2);

        //        k = ds2.Tables[0].Rows.Count;
        //        for (i = 0; i <= k - 1; i++)
        //        {
        //            Perfno[i] = ds2.Tables[0].Rows[i].ItemArray[1].ToString();
        //        }

        //        rx = GDView.Rows.Count;
        //        if (rx >= 22) rx = 22;
        //        PBar1.Maximum = rx + 1;
        //        PBar1.Value = (int)1;

        //        adp2.Dispose();
        //        ds2.Dispose();
        //        Global.con.Close();
        //        for (int m = 0; m <= rx - 2; m++)
        //        {

        //            //Excel.Range Line = (Excel.Range)xlWorkSheet.Rows[(m + 20), misValue];
        //            //Line = Line.EntireRow;
        //            //Line.Insert(Excel.XlInsertShiftDirection.xlShiftDown, misValue);


        //            for (int n = 0; n <= 23; n++)
        //            {
        //                xlWorkSheet.Cells[m + 11, n + 2] = GDView[int.Parse(Perfno[n]), m].Value.ToString();
        //            }
        //            //cell1 = "B20";
        //            //cell2 = "X" + (rx + 16);
        //            //xlWorkSheet.get_Range(cell1, cell2).Font.Size = 11; //style.FontStyle.Color = Color.White;
        //            ////xlWorkSheet.get_Range(cell1, cell2).Font.ColorIndex = 5;
        //            //xlWorkSheet.get_Range(cell1, cell2).Font.Name = "Calibri";
        //            ////xlWorkSheet.get_Range(cell1, cell2).Borders.ColorIndex = 15;
        //            //xlWorkSheet.get_Range(cell1, cell2).Borders.LineStyle = Excel.XlBorderWeight.xlHairline;
        //            ////xlWorkSheet.get_Range(cell1, cell2).BorderAround(Excel.XlLineStyle.xlDouble, Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);

        //        }
        //        //****************************************
        //        int l = 0;
        //        for (l = 0; l <= rx - 2; l++)
        //        {
        //            PBar1.Value = (int)(l + 1);
        //            //prgT.Value = (int)(m + 1);
        //            //Excel.Range Line = (Excel.Range)xlWorkSheet.Rows[(l + (rx + 25)), misValue];
        //            //Line = Line.EntireRow;
        //            //Line.Insert(Excel.XlInsertShiftDirection.xlShiftDown, misValue);

        //            xlWorkSheet.Cells[l + 31, 2] = GDView[128, l].Value.ToString();
        //            xlWorkSheet.Cells[l + 31, 3] = GDView[129, l].Value.ToString();
        //            xlWorkSheet.Cells[l + 31, 4] = GDView[130, l].Value.ToString();
        //            xlWorkSheet.Cells[l + 31, 5] = GDView[131, l].Value.ToString();
        //            xlWorkSheet.Cells[l + 31, 6] = GDView[132, l].Value.ToString();
        //            xlWorkSheet.Cells[l + 31, 7] = GDView[133, l].Value.ToString();
        //            xlWorkSheet.Cells[l + 31, 8] = GDView[135, l].Value.ToString();
        //            xlWorkSheet.Cells[l + 31, 9] = GDView[136, l].Value.ToString();
        //            xlWorkSheet.Cells[l + 31, 10] = GDView[137, l].Value.ToString();
        //            xlWorkSheet.Cells[l + 31, 11] = GDView[138, l].Value.ToString();
        //            xlWorkSheet.Cells[l + 31, 12] = GDView[139, l].Value.ToString();
        //            xlWorkSheet.Cells[l + 31, 13] = GDView[140, l].Value.ToString();
        //            xlWorkSheet.Cells[l + 31, 14] = GDView[141, l].Value.ToString();
        //            xlWorkSheet.Cells[l + 31, 15] = GDView[142, l].Value.ToString();
        //            xlWorkSheet.Cells[l + 31, 16] = GDView[143, l].Value.ToString();
        //            //xlWorkSheet.Cells[l + 31, 17] = GDView[143, l].Value.ToString();
        //            //PBar1.Value = m + 1;

        //        }
        //        //xlWorkSheet.Cells[33, 17] = dataGridView1[17, 1].Val6ue.ToString();
        //        //xlWorkSheet.Cells[35, 17] = dataGridView1[18, 1].Value.ToString(); 

        //        PBar1.Text = "Data Transfer Over .......";
        //        //cell1 = "B" + (rx + 25);
        //        //cell2 = "AA" + (rx + 26 + l);
        //        //xlWorkSheet.get_Range(cell1, cell2).Font.Size = 11; //style.FontStyle.Color = Color.White;
        //        //xlWorkSheet.get_Range(cell1, cell2).Font.ColorIndex = 5;
        //        //xlWorkSheet.get_Range(cell1, cell2).Font.Name = "Calibri";
        //        ////xlWorkSheet.get_Range(cell1, cell2).Borders.ColorIndex = 15;
        //        //xlWorkSheet.get_Range(cell1, cell2).Borders.LineStyle = Excel.XlBorderWeight.xlHairline;
        //        //xlWorkSheet.get_Range(cell1, cell2).BorderAround(Excel.XlLineStyle.xlDouble, Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);


        //        ////-------------------------- 



        //        //rx = GDView.RowCount - 1;
        //        ////PBar1.Maximum = rx + 1;
        //        //if (rx >= 15) rx = 15;

        //        ////PBar1.Maximum = rx + 1;
        //        ////PBar1.Value = (int)1;

        //        //for (int m = 0; m <= rx - 1; m++)
        //        //{
        //        //    //prgT.Value = (int)(m + 1);
        //        //    //Excel.Range Line = (Excel.Range)xlWorkSheet.Rows[(m + 12), misValue];
        //        //    //Line = Line.EntireRow;
        //        //    //Line.Insert(Excel.XlInsertShiftDirection.xlShiftDown, misValue);
        //        //    for (int n = 0; n <= 19; n++)
        //        //    {
        //        //        xlWorkSheet.Cells[m + 12, n + 2] = GDView[int.Parse(Perfno[n]), m].Value.ToString();   
        //        //    }

        //        //    //****************************************
        //        //    xlWorkSheet.Cells[m + 31, 2] = GDView[0, m].Value.ToString();
        //        //    xlWorkSheet.Cells[m + 31, 3] = GDView[1, m].Value.ToString();
        //        //    xlWorkSheet.Cells[m + 31, 4] = GDView[107, m].Value.ToString();
        //        //    xlWorkSheet.Cells[m + 31, 5] = GDView[108, m].Value.ToString();
        //        //    xlWorkSheet.Cells[m + 31, 6] = GDView[109, m].Value.ToString();
        //        //    xlWorkSheet.Cells[m + 31, 7] = GDView[105, m].Value.ToString();
        //        //    xlWorkSheet.Cells[m + 31, 8] = GDView[111, m].Value.ToString();
        //        //    xlWorkSheet.Cells[m + 31, 9] = GDView[112, m].Value.ToString();
        //        //    xlWorkSheet.Cells[m + 31, 10] = GDView[101, m].Value.ToString();
        //        //    xlWorkSheet.Cells[m + 31, 11] = GDView[102, m].Value.ToString();
        //        //    xlWorkSheet.Cells[m + 31, 12] = GDView[119, m].Value.ToString();
        //        //   xlWorkSheet.Cells[m + 31, 13] = GDView[113, m].Value.ToString();
        //        //    //PBar1.Value = m + 1;

        //        //}
        //        // xlWorkSheet.Cells[33, 17] = dataGridView1[17, 1].Value.ToString();
        //        // xlWorkSheet.Cells[35, 17] = dataGridView1[18, 1].Value.ToString();

        //        //Global.conData.Close();
        //        //PBar1.Text = "Data Transfer Over .......";
        //        //PBar1.Text = "Data Transfer Over .......";
        //        PBar1.Text = "Data Transfer Over .......";
        //        xlWorkBook.SaveAs((object)(Global.DataPath + label1.Text), misValue, misValue, misValue, false, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);

        //        xlApp.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error Code:- 17007", ex.Message);
        //    }
        //}
      
      


        //private void Export_NewData()
        //{

        //    //XLS.Application myapp = new XLS.ApplicationClass();
          
        //        Excel.Application xlApp;
        //        Excel.Workbook xlWorkBook;
        //        Excel.Worksheet xlWorkSheet;

        //        Process[] prs = Process.GetProcesses();
        //        foreach (Process pr in prs)
        //        {
        //            if (pr.ProcessName == "EXCEL") pr.Kill();
        //        }
        //        try
        //        {
        //            String[] Perfno = new String[50];
        //            String[] Perfhead = new String[50];
        //            String[] Perfunit = new String[50];
        //            string cell1, cell2, cell3, cell4;
        //            object misValue = System.Reflection.Missing.Value;
        //            int i, k;
        //            int j, rx;
        //            xlApp = new Excel.Application();
        //            xlWorkBook = xlApp.Workbooks.Open(Global.PATH + "PerformanceNew1.xlsx", 0, misValue, 4, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

        //            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("Performance");


        //            Global.Open_Connection("gen_db", "con");
        //            MySqlDataAdapter adp2 = new MySqlDataAdapter("Select * from Tb_Perf ", Global.con);
        //            DataSet ds2 = new DataSet();
        //            adp2.Fill(ds2);

        //            k = ds2.Tables[0].Rows.Count;
        //            for (i = 0; i <= k - 1; i++)
        //            {
        //                Perfno[i] = ds2.Tables[0].Rows[i].ItemArray[1].ToString();
        //            }

        //            adp2.Dispose();
        //            ds2.Dispose();

               
            
        //        Global.Open_Connection("gen_db", "con");
        //        MySqlCommand cmd = new MySqlCommand("SELECT * FROM tb_passout WHERE EngType ",Global.con);
        //        MySqlDataReader rd = cmd.ExecuteReader();
        //        Int16 x = 0;
        //            int l =31;
        //            int countR= rd.FieldCount;
        //        while (rd.Read())
        //        {

        //            for (l = 31; l < countR; l++)
        //            {
        //                xlWorkSheet.Cells[l, 2] = Convert.ToInt32(rd.GetValue(1));
        //            }
                 
        //        }
        //        rd.Close();
        //        Global.con.Close();  



           
        //            xlApp.ActiveWorkbook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, (object)(Global.DataPath + "Rep_" + Global.Eng_FileNm), (object)Excel.XlFixedFormatQuality.xlQualityStandard);
        //            xlApp.DisplayAlerts = false;
        //            xlApp.SaveWorkspace((object)(Global.DataPath + "Rep_" + Global.Eng_FileNm));
        //            xlApp.Quit();
        //            xlApp.Visible = true;

               
        //        }

        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Record Saved & Engine Stopped", "Dynalec Controls Pvt Ltd.",
        //            MessageBoxButtons.OK, MessageBoxIcon.Information);
        //           // MessageBox.Show("Record Saved  & Engin  stopped");
        //        }
        //}
        private void MSFG_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //int rw;
                //rw = e.RowIndex;
                //if (lblDfMatrix.Text == "")
                //{
                //    lblDfMatrix.Text = lblDfMatrix.Text + " " + MSFG.Rows[rw].Cells[1].Value.ToString();
                //}
                //else
                //{
                //    lblDfMatrix.Text =  lblDfMatrix.Text + ", " + MSFG.Rows[rw].Cells[1].Value.ToString();
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code :-2003" + '\n' + ex.Message , "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
               // MessageBox.Show("Error Code :-2003", ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;

                String str1 = "";
                String str2 = "";
                String str3 = "";
                Global.ErrorMatrix = "";
                Global.ErrorMatrix = lblDfMatrix.Text; // +"@  Test OK";
                if (checkBox1.CheckState == CheckState.Checked) str1 = "Abnormal"; else str1 = "Normal";
                if (checkBox2.CheckState == CheckState.Checked) str2 = "Yes"; else str2 = "No";
                if (checkBox3.CheckState == CheckState.Checked) str3 = "Yes"; else str3 = "No";

                Global.CStopTm = DateTime.Now.ToString("HH:mm:ss");

               
                Process[] prs = Process.GetProcesses();
                foreach (Process pr in prs)
                {
                    if (pr.ProcessName == "EXCEL") pr.Kill();
                }

                object misValue = System.Reflection.Missing.Value;
                int i, k;
                int j, rx;
                xlApp = new Excel.Application(); // new Excel.ApplicationClass();
                xlWorkBook = xlApp.Workbooks.Open(Global.PATH + "DW10_REPORT.xltx", 0, misValue, 4, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("FORMAT-02");
                xlWorkSheet.get_Range("B19", "D31").ClearContents();


                xlWorkSheet.Cells[1, 4] = DateTime.Now.ToString();  //"dd:MMM:yy");  // Global.EngineNo;
                xlWorkSheet.Cells[2, 2] = Global.EngNo;
                xlWorkSheet.Cells[3, 2] = Global.EngType;
                xlWorkSheet.Cells[4, 2] = Global.TestRef;
                xlWorkSheet.Cells[5, 2] = Global.FipNo;
                xlWorkSheet.Cells[6, 2] = Global.Turbo_No;
                xlWorkSheet.Cells[7, 2] = Global.Eng_FileNm;

                xlWorkSheet.Cells[9, 2] = Global.T_CellNo;
                xlWorkSheet.Cells[10,2] = Global.OperatorNm;
                xlWorkSheet.Cells[11, 2] = Global.EnginerNm;
                xlWorkSheet.Cells[12, 2] = Global.Shift;

                xlWorkSheet.Cells[14, 2] = "OK";  // Global.EnginerNm;
                xlWorkSheet.Cells[15, 2] = str1;
                xlWorkSheet.Cells[16, 2] = str2;
                xlWorkSheet.Cells[17, 2] = str3;

                for (i = 0; i <= 12; i++)
                {
                    xlWorkSheet.Cells[i + 19, 2] = Global.arrIdle_1[i];
                    xlWorkSheet.Cells[i + 19, 3] = Global.arrIdle_2[i];
                    xlWorkSheet.Cells[i + 19, 4] = Global.arrIdle_3[i]; 
                }
                xlWorkSheet.Cells[32, 1] = lblDfMatrix.Text;

                xlWorkBook.SaveAs((object)(Global.DataPath + Global.Eng_FileNm), misValue, misValue, misValue, false, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                xlApp.Visible = true;                              
                //*************************
                //Check_EngDetailsFile();
                //fill_Engine_Details(); 
                main.ResetOutPut();
                main.Btn21.Enabled = false;
                this.Close();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("ErrorCode :- 2002" + '\n' + ex.Message, "Status",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //MessageBox.Show("ErrorCode :- 2002", ex.Message);
            }

        }

        //private void fill_Engine_Details()
        //{
        //    try
        //    {

        //        String Str = "";
        //        Global.CStopTm = DateTime.Now.ToString("hh:mm:ss tt");

               
        //        Str = "";
        //        Str = Global.Eng_FileNm + ", ";
        //        //Global.RpArr[0] = Global.Eng_FileNm;
        //        for (int i = 0; i <= Global.RpArr.Length - 1; i++)
        //        {
        //            if ((Global.RpArr[i] == null) || (Global.RpArr[i] == ""))
        //            {
        //                Global.RpArr[i] = "****";
        //            }
        //            Str = Str + Global.RpArr[i] + ", ";
        //        }
        //        Str = Str + "\n";
        //        var filePath = Global.DataPath + "Gen_Data\\EngDetails.csv";
        //        using (var wr = new StreamWriter(filePath, true))
        //        {
        //            var row = new List<string> { Str.Substring(0, Str.Length - 1) };
        //            var sb = new StringBuilder();
        //            foreach (string value in row)
        //            {
        //                if (sb.Length > 0)
        //                    sb.Append(",");
        //                sb.Append(value);
        //            }
        //            wr.WriteLine(sb.ToString());
        //        }
        //        Global.Create_OnLog("Engine Details File Created.", "Normal");
        //    }

        //    catch (Exception ex)
        //    {
        //        Global.Create_OnLog("Engine Details File not Created...", "Alert");
        //        return;
        //    }
        //}
        public void Check_EngDetailsFile()
        {
            if (System.IO.File.Exists("D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Gen_Data\\EngDetails.csv") == false)
            {
                string path = "D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\Gen_Data\\EngDetails.csv";
                using (StreamWriter sw = File.CreateText(path))
                {
                    String M = "FileName,Common RailNo,T-Charger No,High Fp No,Engine No,No of Cylinders,BoreDia,Stroke, Swept Vol, Radiator,Fan,AirCleaner,Silencer,Operator, Engineer,Test CellNo, Shift, C_startTm, C_StopTm, C_hours, Date, Comment, Injector-01, Injector-02, Injector-03, Injector-04";
                    var row = new List<string> { M };
                    var sb = new StringBuilder();
                    foreach (string value in row)
                    {
                        if (sb.Length > 0)
                            sb.Append(",");
                        sb.Append(value);
                    }
                    sw.WriteLine(sb.ToString());
                }
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

      
        //private void Create_Performance()
        //{
        //    Excel.Application xlApp;
        //    Excel.Workbook xlWorkBook;
        //    Excel.Worksheet xlWorkSheet;

        //    Process[] prs = Process.GetProcesses();
        //    foreach (Process pr in prs)
        //    {
        //        if (pr.ProcessName == "EXCEL") pr.Kill();
        //    }
        //    try
        //    {
        //        String[] Perfno = new String[30];
        //        String[] Perfhead = new String[30];
        //        String[] Perfunit = new String[30];

        //        object misValue = System.Reflection.Missing.Value;
        //        int i, k;
        //        int j, rx;
        //        xlApp = new Excel.ApplicationClass();
        //        xlWorkBook = xlApp.Workbooks.Open(Global.PATH + "Performance.xlsx", 0, misValue, 4, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

        //        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("Performance");
        //        xlWorkSheet.get_Range("B12", "X27").ClearContents(); // .Clear();
        //        xlWorkSheet.get_Range("B31", "M48").ClearContents();
        //        //-------------------------
        //        xlWorkSheet.Cells[3, 20] = DateTime.Now.ToString("dd/MM/yyyy");
        //        xlWorkSheet.Cells[5, 20] = "ECB - 200"; 
        //        xlWorkSheet.Cells[6, 20] = Global.OperatorNm ;
        //        xlWorkSheet.Cells[7, 20] = Global.EnginerNm; 
        //        xlWorkSheet.Cells[8, 20] = Global.T_CellNo;

        //        //-----------------------
        //        xlWorkSheet.Cells[5, 5] = Global.EngType;
        //        xlWorkSheet.Cells[6, 5] = Global.TestRef;
        //        xlWorkSheet.Cells[7, 5] = Global.FipNo;
        //        xlWorkSheet.Cells[8, 5] = Global.EngNo;
        //        ////----------------------------
        //        xlWorkSheet.Cells[5, 11] = Global.NCyl;
        //        xlWorkSheet.Cells[6, 11] = Global.Bor;
        //        xlWorkSheet.Cells[7, 11] = Global.Strk;
        //        xlWorkSheet.Cells[8, 11] = Global.Svol;
        //        //------------------------
        //        if (Global.flg_Radiator == true) xlWorkSheet.Cells[5, 16] = "YES"; else xlWorkSheet.Cells[5, 16] = "NO";
        //        if (Global.flg_Fan == true) xlWorkSheet.Cells[6, 16] = "YES"; else xlWorkSheet.Cells[6, 16] = "NO";
        //        if (Global.flg_AirCln == true) xlWorkSheet.Cells[7, 16] = "YES"; else xlWorkSheet.Cells[7, 16] = "NO";
        //        if (Global.flg_Silincer == true) xlWorkSheet.Cells[8, 16] = "YES"; else xlWorkSheet.Cells[8, 16] = "NO";
        //        ////-------------------------- 

        //        Global.Open_Connection("gen_db", "con");
        //        MySqlDataAdapter adp2 = new MySqlDataAdapter("Select * from Tb_Perf ", Global.con);
        //        DataSet ds2 = new DataSet();
        //        adp2.Fill(ds2);
        //        prgT.Visible = true;
        //        prgT.Value = (int)1;
        //        prgT.Caption = "Wait Data For Transfer .......";

        //        k = ds2.Tables[0].Rows.Count;
        //        for (i = 0; i <= k - 1; i++)
        //        {
        //            Perfno[i] = ds2.Tables[0].Rows[i].ItemArray[1].ToString();
        //            Perfhead[i] = ds2.Tables[0].Rows[i].ItemArray[2].ToString();
        //            Perfunit[i] = ds2.Tables[0].Rows[i].ItemArray[3].ToString();
        //        }
        //        adp2.Dispose();
        //        ds2.Dispose();
        //        Global.con.Close();
        //        for (i = 0; i <= k - 1; i++)
        //        {
        //            xlWorkSheet.Cells[9, 2 + i] = Perfhead[i];
        //            xlWorkSheet.Cells[10, 2 + i] = Perfunit[i];
        //        }

        //        Global.Open_Connection("Data", "conData");
        //        MySqlDataAdapter adp1 = new MySqlDataAdapter("Select * from " + Global.Eng_FileNm + " Order by Pn", Global.conData);
        //        DataSet ds1 = new DataSet();
        //        adp1.Fill(ds1);
        //        rx = ds1.Tables[0].Rows.Count;
        //        if (rx >= 15) rx = 15; 

        //        prgT.Maximum = rx + 1;
        //        prgT.Value = (int)1;
        //        for (int m = 0; m <= rx - 1; m++)
        //        {
        //            prgT.Value = (int)(m + 1);
        //            for (i = 0; i <= k - 1; i++)
        //            {
        //                xlWorkSheet.Cells[m + 11, i + 2] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Perfno[i])].ToString();
        //            }
        //            //****************************************
        //            xlWorkSheet.Cells[m + 31, 2] = ds1.Tables[0].Rows[m].ItemArray[0].ToString();
        //            xlWorkSheet.Cells[m + 31, 3] = ds1.Tables[0].Rows[m].ItemArray[1].ToString();
        //            xlWorkSheet.Cells[m + 31, 4] = ds1.Tables[0].Rows[m].ItemArray[107].ToString();
        //            xlWorkSheet.Cells[m + 31, 5] = ds1.Tables[0].Rows[m].ItemArray[108].ToString();
        //            xlWorkSheet.Cells[m + 31, 6] = ds1.Tables[0].Rows[m].ItemArray[109].ToString();
        //            xlWorkSheet.Cells[m + 31, 7] = ds1.Tables[0].Rows[m].ItemArray[105].ToString();
        //            xlWorkSheet.Cells[m + 31, 8] = ds1.Tables[0].Rows[m].ItemArray[111].ToString();
        //            xlWorkSheet.Cells[m + 31, 9] = ds1.Tables[0].Rows[m].ItemArray[112].ToString();
        //            xlWorkSheet.Cells[m + 31, 10] = ds1.Tables[0].Rows[m].ItemArray[101].ToString();
        //            xlWorkSheet.Cells[m + 31, 11] = ds1.Tables[0].Rows[m].ItemArray[102].ToString();
        //            xlWorkSheet.Cells[m + 31, 12] = ds1.Tables[0].Rows[m].ItemArray[119].ToString();
        //            xlWorkSheet.Cells[m + 31, 13] = ds1.Tables[0].Rows[m].ItemArray[113].ToString();
        //            prgT.Value = m + 1;
        //        }
        //        xlWorkSheet.Cells[33, 17] = Global.CStrtTm;
        //        xlWorkSheet.Cells[35, 17] = Global.CStopTm;

        //        Global.conData.Close();
        //        prgT.Caption = "Data Transfer Over .......";
        //        xlWorkBook.SaveAs((object)(Global.DataPath + "Perf_" + Global.Eng_FileNm.Substring(4)), misValue, misValue, misValue, false, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);

        //        xlApp.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.Create_OnLog(ex.Message + " :  Create Performance....", "Alart");  
        //        //MessageBox.Show("Error Code:- 17007", ex.Message);
        //    }



        //}

        //private void Create_Endurance()
        //{
        //    Excel.Application xlApp;
        //    Excel.Workbook xlWorkBook;
        //    Excel.Worksheet xlWorkSheet;
        //    Process[] prs = Process.GetProcesses();
        //    foreach (Process pr in prs)
        //    {
        //        if (pr.ProcessName == "EXCEL") pr.Kill();
        //    }
        //    try
        //    {
        //        String[] Enduno = new String[30];
        //        String[] Enduhead = new String[30];
        //        String[] Enduunit = new String[30];
        //        string cell1, cell2;
        //        object misValue = System.Reflection.Missing.Value;
        //        int i, k;
        //        int j, rx;
        //        xlApp = new Excel.ApplicationClass();
        //        xlWorkBook = xlApp.Workbooks.Open(Global.PATH + "Endurance.xlsx", 0, misValue, 4, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

        //        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item("Endurance");
        //        xlWorkSheet.get_Range("B12", "U2000").Clear();
        //        //-------------------------
        //        xlWorkSheet.Cells[2, 19] = DateTime.Now.ToString("dd/MM/yyyy");
        //        xlWorkSheet.Cells[3, 19] = Global.T_CellNo;
        //        //-----------------------
        //        xlWorkSheet.Cells[4, 4] = Global.EngType;
        //        xlWorkSheet.Cells[5, 4] = Global.EngNo;
        //        xlWorkSheet.Cells[6, 4] = Global.Bor;
        //        xlWorkSheet.Cells[7, 4] = Global.Strk;
        //        xlWorkSheet.Cells[8, 4] = Global.NCyl;
        //        xlWorkSheet.Cells[9, 4] = Global.Svol;
        //        //------------------------
        //        xlWorkSheet.Cells[5, 8] = Global.EnginerNm;
        //        xlWorkSheet.Cells[6, 8] = Global.OperatorNm;
        //        xlWorkSheet.Cells[7, 8] = Global.TestRef;
        //        xlWorkSheet.Cells[8, 8] = Global.SGrv;

        //        //-------------------------- 
        //        //------------------------
        //        if (Global.flg_Radiator == true) xlWorkSheet.Cells[5, 12] = "YES"; else xlWorkSheet.Cells[5, 12] = "NO";
        //        if (Global.flg_Fan == true) xlWorkSheet.Cells[6, 12] = "YES"; else xlWorkSheet.Cells[6, 12] = "NO";
        //        if (Global.flg_AirCln == true) xlWorkSheet.Cells[7, 12] = "YES"; else xlWorkSheet.Cells[7, 12] = "NO";
        //        if (Global.flg_Silincer == true) xlWorkSheet.Cells[8, 12] = "YES"; else xlWorkSheet.Cells[8, 12] = "NO";
        //        ////-------------------------- 
        //        //----------------------------------
        //        xlWorkSheet.Cells[5, 16] = Global.CStrtTm;
        //        xlWorkSheet.Cells[6, 16] = Global.CStopTm;

        //        xlWorkSheet.Cells[8, 16] = Global.cumhours;


        //        Global.Open_Connection("gen_db", "con");
        //        MySqlDataAdapter adp2 = new MySqlDataAdapter("Select * from Tb_Endu ", Global.con);
        //        DataSet ds2 = new DataSet();
        //        adp2.Fill(ds2);
        //        prgT.Visible = true;
        //        prgT.Value = (int)1;
        //        prgT.Caption = "Wait Data For Transfer .......";

        //        k = 20;
        //        for (i = 0; i <= k - 1; i++)
        //        {
        //            Enduno[i] = ds2.Tables[0].Rows[i].ItemArray[1].ToString();
        //            Enduhead[i] = ds2.Tables[0].Rows[i].ItemArray[2].ToString();
        //            xlWorkSheet.Cells[10, i + 2] = ds2.Tables[0].Rows[i].ItemArray[2].ToString();
        //            Enduunit[i] = ds2.Tables[0].Rows[i].ItemArray[3].ToString();
        //            xlWorkSheet.Cells[11, i + 2] = ds2.Tables[0].Rows[i].ItemArray[3].ToString();
        //        }
        //        k = i;
        //        adp2.Dispose();
        //        ds2.Dispose();
        //        Global.con.Close();
        //        Global.Open_Connection("Data", "conData");
        //        MySqlDataAdapter adp1 = new MySqlDataAdapter("Select * from " + Global.Eng_FileNm + " Order by Pn", Global.conData);
        //        DataSet ds1 = new DataSet();
        //        adp1.Fill(ds1);
        //        rx = ds1.Tables[0].Rows.Count;

        //        prgT.Maximum = rx + 1;
        //        prgT.Value = (int)1;
        //        for (int m = 0; m <= rx - 1; m++)
        //        {
        //            prgT.Value = (int)(m + 1);
        //            for (int n = 0; n <= k - 1; n++)
        //            {
        //                xlWorkSheet.Cells[m + 12, n + 2] = ds1.Tables[0].Rows[m].ItemArray[int.Parse(Enduno[n])].ToString();
        //            }
        //            prgT.Value = m;
        //        }
        //        Global.conData.Close();

        //        prgT.Caption = "Data Transfer Over .......";
        //        //cell3 = "B8";
        //        //cell4 = "AB10";
        //        cell1 = "B12";
        //        cell2 = "U" + (rx + 12);
        //        xlWorkSheet.get_Range(cell1, cell2).Font.Size = 11; //style.FontStyle.Color = Color.White;
        //        xlWorkSheet.get_Range(cell1, cell2).Font.ColorIndex = 5;
        //        xlWorkSheet.get_Range(cell1, cell2).Font.Name = "Book Antiqua";
        //        xlWorkSheet.get_Range(cell1, cell2).Borders.ColorIndex = 15;
        //        xlWorkSheet.get_Range(cell1, cell2).Borders.LineStyle = Excel.XlBorderWeight.xlHairline;
        //        xlWorkSheet.get_Range(cell1, cell2).BorderAround(Excel.XlLineStyle.xlDouble, Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic);
        //        //xlWorkSheet.get_Range(cell3, cell4).Borders.LineStyle = Excel.XlBorderWeight.xlHairline;
        //        //xlWorkSheet.get_Range(cell3, cell4).Font.Size = 11;
        //        //xlWorkSheet.get_Range(cell3, cell4).Font.Bold = false;
        //        //xlWorkSheet.get_Range(cell3, cell4).Borders.ColorIndex = 15;
        //        //xlWorkSheet.get_Range(cell3, cell4).Font.ColorIndex = 9;
        //        ////xlWorkSheet.get_Range("B9", "W9").Font.ColorIndex = 5;
        //        //xlWorkSheet.get_Range("B10", "W10").Font.ColorIndex = 1;
        //        //xlWorkSheet.get_Range(cell3, cell4).Font.Name = "Book Antiqua";
        //        //xlWorkSheet.get_Range(cell3, cell4).BorderAround(Excel.XlLineStyle.xlDouble, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic);


        //        xlWorkBook.SaveAs((object)(Global.DataPath + "Endu_" + Global.Eng_FileNm.Substring(4)), misValue, misValue, misValue, false, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);

        //        xlApp.Visible = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.Create_OnLog(ex.Message + " :  Create Endurance....", "Alart");  
        //        //MessageBox.Show("Error Code:- 17007", ex.Message);
        //    }

        //}



        

    }
}
