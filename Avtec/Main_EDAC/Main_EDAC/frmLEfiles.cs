using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;  
using System.Windows.Forms;


namespace Logger
{
    public partial class frmLEfiles : Form
    {
        public frmLEfiles()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void frmLEfiles_Load(object sender, EventArgs e)
        {
            try
            {
                if (Global.PrjNm == null) 
                {
                    MessageBox.Show("Error :  Please. Select the Project ...." , "Dynalec Controls Pvt Ltd.",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   // MessageBox.Show ( "Error :  Please. Select the Project ....");
                    return;
                }
                else
                {
                    label3.Text = Global.StpLimFl;
                    label2.Text = Global.Prj[1];
                    label5.Text = Global.Prj[2];

                    read_Eng();
                    read_Lim();
                    read_Prog(); 



                }          
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code: -6001 " + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
               // MessageBox.Show("Error Code: -6001 " + ex.Message);
            }
        }

        private void read_Lim()
        {
            Global.Open_Connection("lim_db", "ConLim");
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM " + Global.StpLimFl, Global.conLim);
            DataSet ds = new DataSet();
            adp.Fill(ds);           

            LimGV.DataSource = ds.Tables[0];
            //LimGV.Columns[0].Width = 30;
            //LimGV.Columns[1].Width = 100;
            //LimGV.Columns[2].Width = 80;
            //LimGV.Columns[3].Width = 80;
            //LimGV.Columns[4].Width = 80;
            //LimGV.Columns[5].Width = 80;
            //LimGV.Columns[6].Width = 80;
            //LimGV.Columns[7].Width = 80;
            //LimGV.Columns[8].Width = 80;

            LimGV.DefaultCellStyle.ForeColor = Color.Blue;
            LimGV.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 10F);  //, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));    
            LimGV.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)));
            adp.Dispose();
            ds.Dispose();
            Global.conLim.Close();
            foreach (DataGridViewColumn colm in LimGV.Columns)
            {
                colm.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }
        private void read_Prog()
        {
            Global.Open_Connection("seq_db", "ConSeq");
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM " + Global.Prj[2], Global.conSeq);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            //LimGV.ColumnCount = ds.Tables[0].Columns.Count;

            SeqGV.DataSource = ds.Tables[0];

            SeqGV.DefaultCellStyle.ForeColor = Color.Blue;
            SeqGV.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 10F);  //, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));    
            SeqGV.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)));
            adp.Dispose();
            ds.Dispose();
            Global.conSeq.Close();
            foreach (DataGridViewColumn colm in SeqGV.Columns)
            {
                colm.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
         
                 SeqGV.Rows[Global.StpN].Selected = true;
        }
        private void read_Eng()
        {
            Global.Open_Connection("gen_db", "con");
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM tblEngine WHERE EngineFile = '" + Global.Prj[1] + "'", Global.con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            EngGV.DataSource = ds.Tables[0];
            EngGV.DefaultCellStyle.ForeColor = Color.Blue;
            EngGV.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 10F);
            EngGV.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Calibri", 11F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Regular)));
            adp.Dispose();
            ds.Dispose();
            Global.con.Close();
            foreach (DataGridViewColumn colm in EngGV.Columns)
            {
                colm.SortMode = DataGridViewColumnSortMode.NotSortable;
            } 

        }

    }
}
