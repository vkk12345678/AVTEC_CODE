using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace Editor
{
    public partial class frmPrint : Form
    {
        private MySqlDataAdapter Adp;
        private DataSet ds;
        private int i = 0;
        private int FromIndx = 0;
        private int ToIndx = 0;
        private string Tb_Help = "Tb_Pm";
        private String cNm0 = null;
        private String cNm1 = null;
        private String cNm2 = null;
        private String cNm3 = null;


        public frmPrint()
        {
            InitializeComponent();
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            try
            {
                Common.Open_Connection("Gen_db", "con");
                Adp = new MySqlDataAdapter("SELECT * FROM Tb_std", Common.con);
                ds = new DataSet();
                Adp.Fill(ds);
                cmbPrint.SelectedIndex = 0;

                Display_Tbl("Tb_Pm");
            }
            catch (Exception ex)
            {
                Global.Create_OffLog("Alert", "Error In FrmPrint_Load");
                MessageBox.Show("frmPrint_Load @ Error Code:- 10001" + '\n' + ex.Message, "Show File Format",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //MessageBox.Show("frmPrint_Load @ Error Code:- 10001", ex.Message);
            }
        }

        private void Pm_Parameters()
        {
            DataGrid.RowCount = ds.Tables[0].Rows.Count;
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                DataGrid[0, i].Value = i.ToString("00");
                DataGrid[1, i].Value = ds.Tables[0].Rows[i].ItemArray[5];
                DataGrid[2, i].Value = ds.Tables[0].Rows[i].ItemArray[4];
            }
        }
        private void Gen_Parameters()
        {


            //if (cmbPrint.Text == "02 Screen Format_Cal")
            //{
            //    DataGrid.RowCount = ds.Tables[0].Rows.Count + 1;
            //    for (i = 0; i < 125; i++)
            //    {
            //        DataGrid[0, i].Value = ds.Tables[0].Rows[i].ItemArray[0];
            //        DataGrid[1, i].Value = ds.Tables[0].Rows[i].ItemArray[5];
            //        DataGrid[2, i].Value = ds.Tables[0].Rows[i].ItemArray[4];
            //        if (cmbPrint.Text == "02 Screen Format_Cal") if (i <= 100) DataGrid.Rows[i].Visible = false;
            //    }

            //}
            ////else if (cmbPrint.Text == "03 Screen Format_Par")
            ////{
            ////    DataGrid.RowCount   = ds.Tables[0].Rows.Count + 1;
            ////    for (i = 0; i < 125; i++)
            ////    {
            ////        DataGrid[0, i].Value = ds.Tables[0].Rows[i].ItemArray[0];
            ////        DataGrid[1, i].Value = ds.Tables[0].Rows[i].ItemArray[5];
            ////        DataGrid[2, i].Value = ds.Tables[0].Rows[i].ItemArray[4];
            ////        //if (i >= 100) DataGrid.Rows[i].Visible = false;
            ////    }
            ////}
            //else
            //{
				DataGrid.RowCount = ds.Tables[0].Rows.Count;
				for (i = 0; i <= DataGrid.RowCount - 1; i++)
				{
					DataGrid[0, i].Value = ds.Tables[0].Rows[i].ItemArray[0];
					DataGrid[1, i].Value = ds.Tables[0].Rows[i].ItemArray[5];
					DataGrid[2, i].Value = ds.Tables[0].Rows[i].ItemArray[4];
					
				}
            //}
		}

        private void Display_Tbl(String Tb)
        {
            try
            {
                MySqlDataAdapter Adp1 = new MySqlDataAdapter("SELECT * FROM " + Tb + " ORDER BY N", Common.con);
                DataSet ds1 = new DataSet();
                Adp1.Fill(ds1);
                cNm0 = ds1.Tables[0].Columns[0].Caption;
                cNm1 = ds1.Tables[0].Columns[1].Caption;
                cNm2 = ds1.Tables[0].Columns[2].Caption;
                cNm3 = ds1.Tables[0].Columns[3].Caption;

                PrnDataGrid.RowCount = ds1.Tables[0].Rows.Count;
                for (i = 0; i <= ds1.Tables[0].Rows.Count - 1; i++)
                {
                    PrnDataGrid[0, i].Value = ds1.Tables[0].Rows[i].ItemArray[0];
                    PrnDataGrid[1, i].Value = ds1.Tables[0].Rows[i].ItemArray[1];
                    PrnDataGrid[2, i].Value = ds1.Tables[0].Rows[i].ItemArray[2];
                    PrnDataGrid[3, i].Value = ds1.Tables[0].Rows[i].ItemArray[3];
                }
                ds1.Dispose();
                Adp1.Dispose();
            }
            catch (Exception ex)
            {
                Global.Create_OffLog("Alert", "Error In Display_Tbl");
                MessageBox.Show("Display_Tbl @ Error Code :-10002" + '\n' + ex.Message, "Show File Format",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //MessageBox.Show("Display_Tbl @ Error Code :-10002", ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbPrint_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                label3.Text = Convert.ToString(cmbPrint.SelectedIndex);
                switch (cmbPrint.Text)
                {
                    case "01 PM Format":
                        Pm_Parameters();
                        Display_Tbl("Tb_Pm");
                        Tb_Help = "PMFormat";
                        break;
                    case "02 Screen Format_Cal":
                        Gen_Parameters();
                        Display_Tbl("tb_calpar");
                        Tb_Help = "screenformat";
                        break;
					case "03 Screen Format_Par":
						Gen_Parameters();
						Display_Tbl("tb_scrn");
						Tb_Help = "screenformat";
						break;
					case "04 Performance":
                        Gen_Parameters();
                        Display_Tbl("Tb_Perf");
                        Tb_Help = "Printformat";
                        break;
                    case "05 Endurance":
                        Gen_Parameters();
                        Display_Tbl("Tb_Endu");
                        Tb_Help = "Printformat";
                        break;
                    case "06 Fixed Format":
                        Gen_Parameters();
                        Display_Tbl("Tb_Fixed");
                        Tb_Help = "Printformat";
                        break;
                    case "07 View Format":
                        Gen_Parameters();
                        Display_Tbl("Tb_View");
                        Tb_Help = "Printformat";
                        break;
                    case "08 FTP Format":
                        Gen_Parameters();
                        Display_Tbl("Tb_Report");
                        Tb_Help = "Printformat";
                        break;
                    default:
                        Pm_Parameters();
                        Display_Tbl("Tb_PM");
                        Tb_Help = "PMFormat";

                        break;
                }
            }
            catch (Exception ex)
            {
                Global.Create_OffLog("Alert", "Error In cmbprint");
                MessageBox.Show("cmbPrint_SelectedIndexChanged @ Error Code:-10003" + '\n' + ex.Message, "Show File Format",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //MessageBox.Show("cmbPrint_SelectedIndexChanged @ Error Code:-10003", ex.Message);
            }

        }

       

        private void PrnDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ToIndx = PrnDataGrid.CurrentRow.Index;
                label2.Text = Convert.ToString(ToIndx);

                //int n = cmbPrint.SelectedIndex;
                //switch (n)
				switch(cmbPrint.Text)
				{
                    case "01 PM Format":
                        PrnDataGrid[1, ToIndx].Value = DataGrid[0, FromIndx].Value;
                        PrnDataGrid[2, ToIndx].Value = ToIndx.ToString("00") + DataGrid[1, FromIndx].Value;
                        PrnDataGrid[3, ToIndx].Value = DataGrid[2, FromIndx].Value;
                        Update_Record("Tb_PM");
                        Tb_Help = "PMFormat";
                        break;
                    case "02 Screen Format_Cal":
						PrnDataGrid[1, ToIndx].Value = DataGrid[0, FromIndx].Value; //         DataGrid[1, FromIndx].Value;
						PrnDataGrid[2, ToIndx].Value = DataGrid[1, FromIndx].Value;
                        PrnDataGrid[3, ToIndx].Value = DataGrid[2, FromIndx].Value;
                        Update_Record("tb_calpar");
                        Tb_Help = "screenformat";
                        break;
                    case "03 Screen Format_Par":
						PrnDataGrid[1, ToIndx].Value = DataGrid[0, FromIndx].Value;
                        PrnDataGrid[2, ToIndx].Value = DataGrid[1, FromIndx].Value;
                        PrnDataGrid[3, ToIndx].Value = DataGrid[2, FromIndx].Value;
                        Update_Record("tb_scrn");
                        Tb_Help = "screenformat";
						break;
                    case "04 Performance":
						PrnDataGrid[1, ToIndx].Value = DataGrid[0, FromIndx].Value;
                        PrnDataGrid[2, ToIndx].Value = DataGrid[1, FromIndx].Value;
                        PrnDataGrid[3, ToIndx].Value = DataGrid[2, FromIndx].Value;
                        Update_Record("Tb_Perf");
                        Tb_Help = "Printformat";
                        break;
                    case "05 Endurance":
						PrnDataGrid[1, ToIndx].Value = DataGrid[0, FromIndx].Value;
                        PrnDataGrid[2, ToIndx].Value = DataGrid[1, FromIndx].Value;
                        PrnDataGrid[3, ToIndx].Value = DataGrid[2, FromIndx].Value;
                        Update_Record("Tb_Endu");
                        Tb_Help = "Printformat";
                        break;
                    case "06 Fixed Format":
						PrnDataGrid[1, ToIndx].Value = DataGrid[0, FromIndx].Value;
                        Update_Record("Tb_Fixed");
                        Tb_Help = "Printformat";
                        break;
                    case "07 View Format":						
                        PrnDataGrid[1, ToIndx].Value = DataGrid[0, FromIndx].Value;
                        PrnDataGrid[2, ToIndx].Value = DataGrid[1, FromIndx].Value;
                        PrnDataGrid[3, ToIndx].Value = DataGrid[2, FromIndx].Value;
                        Update_Record("Tb_View");
                        Tb_Help = "Printformat";
                        break;
					case "08 FTP Format":
						PrnDataGrid[1, ToIndx].Value = DataGrid[0, FromIndx].Value;
                        PrnDataGrid[2, ToIndx].Value = DataGrid[1, FromIndx].Value;
                        PrnDataGrid[3, ToIndx].Value = DataGrid[2, FromIndx].Value;
						Update_Record("Tb_Report");
						Tb_Help = "Printformat";
						break;
				}
            }
            catch (Exception ex)
            {
                MessageBox.Show("PrnDataGrid_CellClick @ Error Code:10004" + '\n' + ex.Message, "Show File Format",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
               // MessageBox.Show(" PrnDataGrid_CellClick @ Error Code:10004", ex.Message);
            }

        }

        private void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FromIndx = DataGrid.CurrentRow.Index;
            label1.Text = Convert.ToString(FromIndx);
        }
        private void Update_Record(String Tbl)
        {
            try
            {
                int TbIndx = cmbPrint.SelectedIndex;
				switch (cmbPrint.Text)
				{
					case "01 PM Format":
						Tbl = "Tb_PM";
                        Tb_Help = "PMFormat";
                        break;
					case "02 Screen Format_Cal":
						Tbl = "tb_calpar";
                        Tb_Help = "screenformat";
                        break;
					case "03 Screen Format_Par":
						Tbl = "tb_scrn";
                        Tb_Help = "Printformat";
                        break;
					case "04 Performance":
						Tbl = "Tb_Perf"; 
                        Tb_Help = "Printformat";
                        break;
					case "05 Endurance":
						Tbl = "Tb_Endu"; 
                        Tb_Help = "Printformat";
                        break;
					case "06 Fixed Format":
						Tbl = "Tb_Fixed";
                        Tb_Help = "Printformat";
                        break;
					case "07 View Format":
						Tbl = "Tb_View"; 
                        Tb_Help = "Printformat";
                        break;
					case "08 FTP Format":
						Tbl = "Tb_Report";
						Tb_Help = "Printformat";
						break;
				}

                String ColData1 = PrnDataGrid[1, ToIndx].Value.ToString();
                String ColData2 = PrnDataGrid[2, ToIndx].Value.ToString();
                String ColData3 = PrnDataGrid[3, ToIndx].Value.ToString();


                Common.Open_Connection("gen_db", "con");
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "UPDATE " + Tbl + " SET Cn ='" + ColData1 + "',PName ='" + ColData2 + "',Unit = '" + ColData3 + "' WHERE N = " + ToIndx;

                cmd.Connection = Common.con;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated ..", "Show File Format",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessageBox.Show("Record Updated .....");
                Common.con.Close();
            }
            catch (Exception ex)
            {
                Global.Create_OffLog("Alert", "Error In update record");
                MessageBox.Show("Update_Record @ Error Code:- 10005" + '\n' + ex.Message, "Show File Format",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
               // MessageBox.Show("Update_Record @ Error Code:- 10005", ex.Message);
            }

        }

        private void btnNotProg_Click(object sender, EventArgs e)
        {
			FromIndx = 100;
			label1.Text = Convert.ToString(FromIndx);
		}

        private void btnhelp_Click(object sender, EventArgs e)
        {
            string helpFilepath = @"" + Global.HelpPath + Tb_Help + ".chm";
            if (File.Exists(helpFilepath))
            {
                Process.Start(helpFilepath);
            }
            else
            {
                MessageBox.Show("File not Found" + '\n' + helpFilepath, "Show File Format",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		private void PrnDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
