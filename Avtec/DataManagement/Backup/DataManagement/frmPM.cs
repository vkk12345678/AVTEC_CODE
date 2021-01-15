using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DataManagement
{
    public partial class frmPM : Form
    {
        public frmPM()
        {
            InitializeComponent();
        }
       
        private void fill_combo()
        {
            try
            {
                Global.Rd_System();
                comboBox1.Text = DateTime.Now.ToString("MMMyy");
                Global.L = "D:\\TestCell_" + Global.T_CellNo + "\\";
                Global.M = Global.L.Length;  //("D:\\TestCell_" & T_CellNo & "\\");
                comboBox1.Items.Clear();
                String[] files = System.IO.Directory.GetDirectories(Global.L);
                foreach (String fnm in files)
                {
                    if (fnm.Substring(Global.M) != "Data") comboBox1.Items.Add(fnm.Substring(Global.M));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 17005", ex.Message);
            }
        }

        private void defaultCombo()
        {
            comboBox1.Text = DateTime.Now.ToString("MMMyy");
           // Load_TV_Date();
            Load_PMData();
        }

        private void Load_PMData()
        {

            string tbname;
            DataTable ts1;
            //checkedListBox1.Items.Clear();
            try
            {

                TVPM.Nodes.Clear();
                if (System.IO.File.Exists(Global.L + (comboBox1.Text) + "\\Data.accdb") == true)
                {
                    Global.DataPath =Global.L + (comboBox1.Text) + "\\";
                    if (Global.conData.State == ConnectionState.Closed) Global.Open_DataConn("Data", "conData");

                    TVPM.Nodes.Add("R1", Global.DataPath + "Data");
                    TVPM.Nodes["R1"].Tag = "R1";
                    ts1 = Global.conData.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new Object[] { null, null, null, null });// "TABLE"
                    foreach (DataRow row in ts1.Rows)
                    {
                        tbname = row["TABLE_NAME"].ToString();
                        if (((tbname.Substring(0, 2).ToString()) == "PM"))
                        {
                            TVPM.Nodes["R1"].Nodes.Add("D", tbname);
                        }

                        TVPM.Nodes["R1"].Expand();
                        ts1.Dispose();
                    }
                    label1.Text = " PM Data";
                    Global.conData.Close();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 17004", ex.Message);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPM_Load_1(object sender, EventArgs e)
        {
            fill_combo();
            defaultCombo();
            Global.Rd_Confg();

        }

      

        private void TVPM_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            try
            {
                Global.NodeT = TVPM.SelectedNode.Text;
                if ((TVPM.SelectedNode.Tag != "D") || (TVPM.SelectedNode.Tag != "R1"))
                {
                    //cmdRd.Enabled = true;
                    label1.Text = TVPM.SelectedNode.Text;
                }
                //panel1.Enabled = false;
                //panel2.Enabled = false;
                //panel3.Enabled = false;
                View_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 17013", ex.Message);
            }
        }


        private void View_Data()
        {
            OleDbDataAdapter adp;
            DataSet ds = new DataSet();
            int l, k, j, i;
            try
            {
                
              if (label1.Text.Substring(0, 2) == "PM")
                {
                    if (Global.conData.State == ConnectionState.Closed) Global.Open_DataConn("Data", "conData");
                    adp = new OleDbDataAdapter("Select * from " + label1.Text.Trim() + " Order By TM", Global.conData);
                    adp.Fill(ds);
                    Global.conData.Close();
                    gridview1.Refresh();
                    //////PBar1.Visible = true;
                    PBar1.Maximum = ds.Tables[0].Rows.Count;
                    PBar1.Value = 1;
                    PBar1.Caption = "Wait Data For Transfer .......";
                    gridview1.RowCount = ds.Tables[0].Rows.Count;
                    gridview1.ColumnCount = ds.Tables[0].Columns.Count;
                    gridview1.ColumnCount = 16;
                    gridview1.Columns[0].Name = "Time";
                    gridview1.Columns[13].Name = "Alarm";
                    //gridview1.Columns[15].Name = "File Name ";
                    gridview1.Columns[0].Width = 100;
                    gridview1.Columns[1].Width = 60;
                    //gridview1.Columns[15].Width = 180;
                    for (i = 0; i <= 12; i++)
                    {
                        l = Global.Pm_PNo[i];
                        gridview1.Columns[i + 1].Name = Global.PSName[l].ToString() + "  " + Global.PUnit[l].ToString();
                        gridview1.Columns[i + 1].Width = 80;
                    }
                    for (k = 0; k <= ds.Tables[0].Rows.Count - 1; k++)
                    {
                        for (i = 0; i <= 12; i++)
                        {
                            gridview1[i, k].Value = ds.Tables[0].Rows[k].ItemArray[i].ToString();   //.Rows[k].Cells[i].Value = 
                        }
                        //gridview1[13, k].Value = ds.Tables[0].Rows[k].ItemArray[90].ToString(); 
                        PBar1.Value = (int)(k + 2);
                        //Global.DelayMs(10);
                        //textBox3.Text = (k + 1).ToString();
                    }
                    //textBox4.Text = (ds.Tables[0].Rows.Count).ToString();
                   // cmdRd.Enabled = false;
                    //panel1.Enabled = false;
                   // panel2.Enabled = false;
                    //panel3.Enabled = false;
                   // BtnShowEndu.Enabled = false;
                    //BtnShowExcel.Enabled = false;
                   // BtnShowPerf.Enabled = false;
                    PBar1.Caption = "Data Transfer Over .......";


                }
                
                foreach (DataGridViewColumn colm in gridview1.Columns)
                {
                    colm.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("error: File Is Empty Select Another One...!", ex.Message);
            }
        }
    }

}
