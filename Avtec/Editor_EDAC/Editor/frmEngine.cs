using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;



namespace Editor
{
    public partial class frmEngine : Form
    {
        private int Rn = 0;
        private Boolean flg_New = false;
        public static string T_CellNo;
        public static string Data_Dir;
        public static string I_Tm;

        public frmEngine()
        {
            InitializeComponent();
        }

        private void frmEngine_Load(object sender, EventArgs e)
        {
            try
            {
                int i;
                Load_Datagrid();               
                DataGrid.RowCount = (EngGView.ColumnCount);
                for (i = 1; i <= (EngGView.ColumnCount - 2); i++)
                {
                    DataGrid[0, i - 1].Value = EngGView.Columns[i].Name;
                }
                load_InCell(0);
            }
            catch (Exception ex)
            {
                Global.Create_OffLog(ex.Message + " :Error In FrmEngine_Load....", "Alert");
                MessageBox.Show("frmEngine_Load @ Error Code:- 11001" + ex.Message, "Engine File",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
               // MessageBox.Show("frmEngine_Load @ Error Code:- 11001", ex.Message);
            }
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
            flg_New = true;
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    Erp.SetError(textBox1, "Type the File Name First..." +
                                            "Name Should Be More Than 5 Characters");
                    return;
                }
                int x;
                for (x = 0; x <= (EngGView.RowCount - 1); x++)
                {
                    if (textBox1.Text == EngGView[0, x].Value.ToString())
                    {
                        flg_New = false;
                        break;
                    }
                    else
                    {
                        flg_New = true;
                    }
                }
                String strData = "";

                if (textBox1.Text == "") textBox1.Text = " ";



                strData = strData + textBox1.Text + "', '";
                strData = strData + "Diesel";
               

                for (x = 1; x <= (EngGView.Columns.Count - 2); x++)
                {
                    if ((DataGrid[1, x].Value) == null)
                    {
                        DataGrid[1, x].Value = "***";
                    }
                    strData = strData + "', '" + DataGrid[1, x].Value.ToString();
                }

                if (flg_New == false)
                {
                    Common.Del_EngRec(textBox1.Text,"Common.con");  
                   
                }
                Common.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = " INSERT INTO tblEngine VALUES ('" + strData + "')";
                cmd.Connection = Common.con;
                cmd.ExecuteNonQuery();

               // MessageBox.Show("File saved .....");
                MessageBox.Show("File Saved", "Engine File",
                MessageBoxButtons.OK, MessageBoxIcon.Information); 
                Global.Create_OffLog("Normal", "Engine File Saved.....");
                Load_Datagrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("File not Saved" + ex.Message, "Engine File",
                MessageBoxButtons.OK, MessageBoxIcon.Information); 
               // MessageBox.Show("mnuSave_Click @ Error Code:-11007 " + ex.Message);
                Global.Create_OffLog("Alert", "Engine File not Saved.");
            }


        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult result1 = MessageBox.Show("Do you Want to Delete Selected File ?", "Important Question", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result1 == DialogResult.Yes)
                {
                    Common.Del_EngRec(textBox1.Text,"Common.con");
                    Global.Create_OffLog("Normal", "Engine File deleted Manually.....");
                    Load_Datagrid();
                    load_InCell(0);
                    MessageBox.Show("File Deleted" , "Engine File",
                    MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    //MessageBox.Show(" file Deleted .....");
                }

                else
                {
                    MessageBox.Show("File Not Deleted", "Engine File",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show("file Not Deleted");
                }

            }
            catch (Exception ex)
            {
                Global.Create_OffLog("Alert", "Engine File not deleted.....");
                MessageBox.Show("mnuDelete_Click @ Error Code:- 4006 " + '\n' + ex.Message, "Engine File",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
               // MessageBox.Show("mnuDelete_Click @ Error Code:- 4006  " + ex.Message);
            }
        }
        public static void Create_OffLog(String Str, String Msg)//,int Icon)
        {
            try
            {
                Global.Data_Dir = DateTime.Now.ToString("MMMyy");
                String OffLog_Editor = "OffLogEditor_" + DateTime.Now.ToString("ddMMMyy");

                if (System.IO.Directory.Exists("D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\") == false)
                {
                    System.IO.Directory.CreateDirectory("D:\\TestCell_" + T_CellNo + "\\" + Data_Dir);
                }
                if (System.IO.Directory.Exists("D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\Log_Data") == false)
                {
                    System.IO.Directory.CreateDirectory("D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\Log_Data");
                }
                if (System.IO.File.Exists("D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\Log_Data\\" + OffLog_Editor + ".txt") == false)
                {
                    System.IO.File.Create("D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\Log_Data\\" + OffLog_Editor + ".txt");
                }

                I_Tm = DateTime.Now.ToString();
                String strData = I_Tm + " ,     " + Str + " ,          " + Msg;

                String filePath = "D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\Log_Data\\" + OffLog_Editor + ".txt";
                using (StreamWriter sw = File.AppendText(filePath))
                    sw.WriteLine(strData); ;
            }
            catch (Exception ex)
            {
                //return;
                Global.Create_OnLog(ex.Message + " :  Load In Cell....", "false");
                //MessageBox.Show("Error Code:- 15007", ex.Message);
            }

        }


        private void mnuHelp_Click(object sender, EventArgs e)
        {
            string helpFilepath = @"" + Global.HelpPath + "Engine.chm";
            if (File.Exists(helpFilepath))
            {
                Process.Start(helpFilepath);
            }
            else
            {
                MessageBox.Show("File not Found" + '\n' + helpFilepath, "Engine File",
               MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //MessageBox.Show("file not Found" + helpFilepath);
            }

        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            Global.Create_OffLog("Normal", "Engine File closed.....");
            this.Close();
        }
        private void Load_Datagrid()
        {
            try
            {
                int MaxRow = 0;

                Common.Open_Connection("gen_db", "con");
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM tblEngine order by EngineFile", Common.con);
                da.Fill(ds);               
                MaxRow = ds.Tables[0].Rows.Count;
                EngGView.DataSource = ds.Tables[0];

                foreach (DataGridViewColumn cln in EngGView.Columns)
                {
                    cln.Width = 60;
                    cln.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                EngGView.Columns[0].Width = 120;
                EngGView.Columns[5].Width = 100;
                ds.Dispose();
                da.Dispose();
                Common.con.Close();
            }
            catch (Exception ex)
            {
                Global.Create_OffLog("Normal", "Error In load Datagrid.....");
                MessageBox.Show("Load_Datagrid @ Error Code:-11002 " + '\n' + ex.Message, "Engine File",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
               // MessageBox.Show("Load_Datagrid @ Error Code:-11002 " + ex.Message);
            }
        }

        private void load_InCell(int Rw)
        {

            try
            {
                int i = 0;

                textBox1.Text = EngGView[0, Rw].Value.ToString();
                DataGrid.Rows[0].Cells[1].Style.BackColor = SystemColors.ActiveCaption;
                DataGrid.Rows[1].Cells[1].Style.BackColor = SystemColors.ActiveCaption;
                DataGrid.Rows[2].Cells[1].Style.BackColor = SystemColors.ActiveCaption;
                DataGrid.Rows[3].Cells[1].Style.BackColor = SystemColors.ActiveCaption;
                DataGrid.Rows[4].Cells[1].Style.BackColor = SystemColors.ActiveCaption;
                DataGrid.Rows[5].Cells[1].Style.BackColor = SystemColors.ActiveCaption;

                for (i = 1; i <= (EngGView.ColumnCount - 1); i++)
                {
                    DataGrid[1, i - 1].Value = EngGView[i, Rw].Value;

                }
            }
            catch (Exception ex)
            {
                Global.Create_OffLog("Normal", "Error In LoadInCell.....");
                MessageBox.Show("load_InCell @ Error Code:- 11003" + '\n' + ex.Message, "Engine File",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
               // MessageBox.Show("load_InCell @ Error Code:- 11003" + ex.Message);
            }
        }

        private void EngGView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Rn = EngGView.CurrentRow.Index;
            load_InCell(Rn);
        }
        //private void Key_Validation(int KeyAscii)
        //{

        //    if ((((KeyAscii > 47) && (KeyAscii < 58)) || ((KeyAscii == 8) || (KeyAscii == 46)||(KeyAscii==45))))
        //    {
        //        // Or KeyAscii = 45 Or'select only numbers, fullstop,backspace
        //        // EP.Clear()
        //    }
        //    else
        //    {
        //        SendKeys.Send(("{+}" + "{HOME}"));
        //        MessageBox.Show("Only Numbers are Allowed  & Not !!");
        //        SendKeys.Send("{BACKSPACE}");
        //    }
        //}

        private void DataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            //int columnIndex = 1;   // e.ColumnIndex;

            if (e.ColumnIndex == 1)
            {
                bool validation = true;
                if ((RowIndex <= 5) && (RowIndex > 1))

                    if (DataGrid.Rows[RowIndex].Cells[1].Value != null && DataGrid.Rows[RowIndex].Cells[1].Value.ToString().Trim() != "")
                    {
                        string DataToValidate = DataGrid.Rows[RowIndex].Cells[1].Value.ToString();
                        foreach (char c in DataToValidate)
                        {

                            if ((!char.IsDigit(c)) && (c != 46))
                            {
                                validation = false;
                                break;
                            }
                        }
                        if (validation == false)
                        {
                            DataGrid.Rows[RowIndex].Cells[1].ErrorText = "You Can Only Enter Number here ";
                            DataGrid.Rows[RowIndex].Cells[1].Value = "";
                        }
                        else
                        {
                            DataGrid.Rows[RowIndex].Cells[1].ErrorText = "";
                        }
                    }

            }
        }

        private void DataGrid_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            if (e.ColumnIndex == 1)
            {
               
                    Double l = Convert.ToDouble(DataGrid[1, 1].Value.ToString());
                    DataGrid[1, 1].Value = l.ToString("000.000");
                    l = Convert.ToDouble(DataGrid[1, 2].Value.ToString());
                    DataGrid[1, 2].Value = l.ToString("00");
                    l = Convert.ToDouble(DataGrid[1, 3].Value.ToString());
                    DataGrid[1, 3].Value = l.ToString("000.000");

                    double R = double.Parse(DataGrid[1, 1].Value.ToString());
                    double L = double.Parse(DataGrid[1, 2].Value.ToString());
                    double C = double.Parse(DataGrid[1, 3].Value.ToString());
                    double S =((0.003142 / 4000) * R * R * L * C);
                    DataGrid[1, 4].Value = S.ToString("0.00000");
                    mnuSave.Enabled = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    Erp.SetError(textBox1, "Type the File Name First..." +
                                            "Name Should Be More Than 5 Characters");
                    return;
                }

                if (textBox1.Text.Length <= 4)
                {
                    Erp.SetError(textBox1, "Type the File Name First..." +
                                            "Name Should Be More Than 5 Characters");
                    textBox1.Focus();
                    textBox1.Text = "";
                    return;
                }

                Common.FormatCombo(textBox1);

                if (textBox1.Text.Length > 4)
                {
                    switch ((textBox1.Text.Substring(0, 4)))
                    {
                        case "ENG_":
                            textBox1.Text = "eng_" + (textBox1.Text.Substring(4)).ToLower();
                            Erp.Clear();
                            break;
                        case "Eng_":
                            textBox1.Text = "eng_" + (textBox1.Text.Substring(4)).ToLower();
                            Erp.Clear();
                            break;
                        case "eng_":
                            textBox1.Text = "eng_" + (textBox1.Text.Substring(4)).ToLower();
                            Erp.Clear();
                            break;
                        default:
                            textBox1.Text = "eng_" + textBox1.Text.ToLower();
                            Erp.Clear();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Global.Create_OffLog("Normal", "Error In ComBox1_Leave.....");
                MessageBox.Show("textBox1_Leave @ " + '\n' + ex.Message, "Engine File",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //MessageBox.Show("textBox1_Leave @ " + ex.Message);
            }

        }

        private void EngGView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_Leave_1(object sender, EventArgs e)
        {

        }
    }
    
}