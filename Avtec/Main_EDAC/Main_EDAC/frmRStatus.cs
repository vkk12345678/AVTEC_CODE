using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics; 
using System.Windows.Forms;

namespace Logger
{
    public partial class frmRStatus : Form
    {
        private string[] ViewNo = new string[22];
        public frmRStatus()
        {
            InitializeComponent();
            
        }
        private void LoadPm()
        {
            try
            {               
                GridGen.Refresh();
                String DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\";
                string strFileName1 = DataPath + "PM_Data\\" + Global.Eng_PMFileNm + ".csv";
                
                OleDbConnection conn1 = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + System.IO.Path.GetDirectoryName(strFileName1) + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"");
                conn1.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + System.IO.Path.GetFileName(strFileName1), conn1);
                DataSet ds1 = new DataSet("Temp");
                adapter.Fill(ds1); 
                GridGen.DataSource = ds1.Tables[0]; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 12001" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
              //  MessageBox.Show("Error Code:- 12001", ex.Message); 
            }
        }
        private void LoadGen()
        {
            try
            {
                GridGen.Refresh();
                String DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\";
                string strFileName = DataPath + "Gen_Data\\" + Global.Eng_FileNm + ".csv";
                OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + System.IO.Path.GetDirectoryName(strFileName) + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"");
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + System.IO.Path.GetFileName(strFileName), conn);
                DataSet ds1 = new DataSet("Temp");
                adapter.Fill(ds1);
                GridGen.DataSource = ds1.Tables[0];
                for (int i = 0; i <= 120; i++)
                {
                    if (GridGen.Columns[i].Name.Substring(3, 8) == "Not_Prog") //continue;
                    {
                        GridGen.Columns[i].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.Create_OnLog( ex.Message + " :  Load General file....", "Alert");  
                //MessageBox.Show("Error Code:- 12002", ex.Message);
            }
        }
        private void LoadInst()
        {
            try
            {
                GridGen.Refresh();
                //D:\TestCell_VIII\Mar20\ECU_Data
                String DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\" ;
                string strFileName = DataPath + "ECU_Data\\" + Global.Eng_ECU_FileNm + ".csv";
                OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + System.IO.Path.GetDirectoryName(strFileName) + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"");
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + System.IO.Path.GetFileName(strFileName), conn);
                DataSet ds1 = new DataSet("Temp");
                adapter.Fill(ds1);
                GridGen.DataSource = ds1.Tables[0];
                for (int i = 0; i <= 120; i++)
                {
                    if (GridGen.Columns[i].Name.Substring(3, 8) == "Not_Prog")
                    {
                        GridGen.Columns[i].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.Create_OnLog(ex.Message + " :  Load General file....","Alart");
                //MessageBox.Show("Error Code:- 12002", ex.Message);
            }
        }
        private void LoadError()
        {
            try
            {
                GridGen.Refresh();
                String DataPath = "D:\\TestCell_" + Global.T_CellNo + "\\" + Global.Data_Dir + "\\";  
                string strFileName = DataPath + "Log_Data\\" + Global.OnLog_Data + ".csv";
                OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + System.IO.Path.GetDirectoryName(strFileName) + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"");
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM " + System.IO.Path.GetFileName(strFileName), conn);
                DataSet ds1 = new DataSet("Temp");
                adapter.Fill(ds1);
                GridGen.DataSource = ds1.Tables[0];
   
                for (int i = 0; i <= 6; i++)
                {
                    if (GridGen.Columns[i].Name.Substring(3, 8) == "Not_Prog")
                    {
                        GridGen.Columns[i].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Alert", ex.Message + " :  LoadError file....");
                //MessageBox.Show("Error Code:- 12002", ex.Message);
            }
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuGen_Click(object sender, EventArgs e)
        {
            LoadGen(); 
        }

        private void mnuPM_Click(object sender, EventArgs e)
        {
            LoadPm(); 
        }

       
        private void RunStatus_Click(object sender, EventArgs e)
        {

            LoadError();
        }

        private void mnuInst_Click(object sender, EventArgs e)
        {
            LoadInst();
        }

        private void frmRStatus_Load(object sender, EventArgs e)
        {

        }

       
       
     }
}
