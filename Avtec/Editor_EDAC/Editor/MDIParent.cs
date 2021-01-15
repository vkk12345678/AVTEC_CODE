using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace Editor
{
    public partial class MDIParent : Form
    {
        private int childFormNumber = 0;

        public MDIParent()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
           
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }
      
        private void MDIParent_Load(object sender, EventArgs e)
        {
            Read_SystemFl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            Global.flg_Log_supervisor = false; 
            Global.Create_OffLog("Alert", "Editor Closed.....");
            tmrLogin.Enabled = false;
            this.Close();
        
        }

        private void MDIParent_Shown(object sender, EventArgs e)
        {
            //MDIParent1..te.t.Text = "EDAC-- Editor : 'Make Engine File..' Editor Open ........";
            frmProject frm = new frmProject();
            frm.Show();
            //Tss2.Text = System.DateTime.Today.ToString("dd : MMMM : yyyy");
        }

        private void btnEngine_Click(object sender, EventArgs e)
        {
           
            Global.Create_OffLog("Engine Editor Opened.....","Alert");
            //Tss1.Text = "'Make Engine File..' Editor Open ........";
            frmEngine frm = new frmEngine();
            frm.Show();

        }

        private void btnLimit_Click(object sender, EventArgs e)
        {
            Global.Create_OffLog("Limit Editor Opened.....", "Alert");
            //Tss1.Text = "'Make Limit File' Editor Open ........";
            tmrLogin.Enabled = false;
            frmLimit frm = new frmLimit();
            frm.Show();


        }

        private void btnSequence_Click(object sender, EventArgs e)
        {
            Global.Create_OffLog("Sequence Editor Opened.....", "Alert");
            //Tss1.Text = "'Make Sequence File' Editor Open ........";
            tmrLogin.Enabled = false;
            frmSeq frm = new frmSeq();
            frm.Show();
        }

        private void btnFormat_Click(object sender, EventArgs e)
        {
            Global.Create_OffLog("File Format Editor Opened.....", "Alert");
            //Tss1.Text = "'Make File Format' Editor Open ........";
            tmrLogin.Enabled = false;
            frmPrint frm = new frmPrint();
            frm.Show();

        }

        private void btnPassword_Click(object sender, EventArgs e)
        {
            Global.Create_OffLog("Password Editor Opened.....", "Alert");
            //Tss1.Text = "'Make Pass word' Editor Open ........";
            tmrLogin.Enabled = false;
            frmPass frm = new frmPass();
            frm.Show();
        
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Global.Create_OffLog("Help PDF Opened.....", "Alert");
            string helpFilepath = @"" + Global.HelpPath + "Help.chm";
            if (File.Exists(helpFilepath))
            {
                Process.Start(helpFilepath);
            }
            else
            {
                MessageBox.Show("File not Found" + '\n' + helpFilepath, "Dynalec Controls Pvt Ltd.",
                MessageBoxButtons.OK, MessageBoxIcon.Error); 
                //MessageBox.Show("file not Found" + helpFilepath);
            }
        }

        private void btnPassout_Click(object sender, EventArgs e)
        {
            Global.Create_OffLog("Passout Editor Opened.....", "Alert");
        }

        private void btnPrj_Click(object sender, EventArgs e)
        {
            Global.Create_OffLog("Project Editor Opened.....", "Alert");            
            //Tss1.Text = "'Make Project File..' Editor Open ........";
            frmProject  frm = new frmProject();
            frm.Show();
        }

        private void Read_SystemFl()
        {
            Common.Open_Connection("gen_db", "con");
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbsys where FileName = 'SystemPara'", Common.con);
            MySqlDataReader Rd = cmd.ExecuteReader(); 

           
            Int16 x = 0;
            while (Rd.Read())
            {
                for (x = 0; x <= (Rd.FieldCount - 1); x++)
                {
                    Global.sysIn[x] = Rd.GetValue(x).ToString();
                }
            }

            Global.T_CellNo = Global.sysIn[9];

            cmd.Dispose();
            Common.con.Close();

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

		
	}
}
