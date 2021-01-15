using ConfigurationManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logger
{
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
            //Global.Rd_Pwd(); 
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
           
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void Close_forms()
        {
            if (Application.OpenForms.OfType<frmSysCf>().Count() == 1)
                Application.OpenForms.OfType<frmSysCf>().First().Close();
            if (Application.OpenForms.OfType<frmSysPara>().Count() == 1)
                Application.OpenForms.OfType<frmSysPara>().First().Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Close_forms();
            ////Common.Create_OffLog("Alart", "Engine Editor Opened.....");
            ////Tss1.Text = "'Make Engine File..' Editor Open ........";
            //frmSysCf frm = new frmSysCf();
            //frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Close_forms();
            ////Common.Create_OffLog("Alart", "Engine Editor Opened.....");
            ////Tss1.Text = "'Make Engine File..' Editor Open ........";
            //frmSysPara frm = new frmSysPara();
            //frm.Show();
        }

        private void systemConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close_forms();
            //Common.Create_OffLog("Alart", "Engine Editor Opened.....");
            //Tss1.Text = "'Make Engine File..' Editor Open ........";
            frmSysCf frm = new frmSysCf();
            frm.Show();
        }

        private void systemParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close_forms();
            //Common.Create_OffLog("Alart", "Engine Editor Opened.....");
            //Tss1.Text = "'Make Engine File..' Editor Open ........";
            frmSysPara frm = new frmSysPara();
            frm.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pORTCONFIGURATIONSETTINGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close_forms();
            //Common.Create_OffLog("Alart", "Engine Editor Opened.....");
            //Tss1.Text = "'Make Engine File..' Editor Open ........";

           PortConfigurationSetting frmport= new PortConfigurationSetting();

           frmport.Show();
        }
    }
}
