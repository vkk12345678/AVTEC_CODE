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
using System.Windows.Forms;

namespace DataManagement
{
    public partial class frmExcel : Form
    {
       
        
        string NodeT;
        int M;
        int N;
        String L;
       
       

        
        public frmExcel()
        {
            InitializeComponent();
        }

        private void frmExcel_Load(object sender, EventArgs e)
        {
            
            fill_combo();
            defaultCombo();
        }
        private void defaultCombo()
        {
            comboBox1.Text = DateTime.Now.ToString("MMMyy");

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
                MessageBox.Show("Error Code:- 17005", ex.Message);
            }
        }

        private void LOAD_Files()
        {
            try
            {
                L = "D:\\TestCell_" + Global.T_CellNo + "\\";
                String L1 = L + comboBox1.Text;
                M = L1.Length + 1;
                TVreport.Nodes.Clear();
                TVreport.Nodes.Add("R1", L1);
                TVreport.Nodes["R1"].Tag = "R1";
                TVreport.Nodes.Add("R2", L1);
                TVreport.Nodes["R2"].Tag = "R2";

                if (System.IO.Directory.Exists(L + (comboBox1.Text)) == true)
                {
                    String[] files1 = System.IO.Directory.GetFiles(L + comboBox1.Text);
                    foreach (string fnm in files1)
                    {
                        N = fnm.Length - 5;

                        if ((fnm.Substring(N) == ".xlsx") && (fnm.Substring(M, 4) == "Endu"))
                        {
                            TVreport.Nodes["R1"].Nodes.Add("R1", fnm.Substring(M));
                        }
                    }
                   
                    foreach (string fnm in files1)
                    {
                        N = fnm.Length - 5;

                        if ((fnm.Substring(N) == ".xlsx") && (fnm.Substring(M, 4) == "Perf"))
                        {
                            TVreport.Nodes["R2"].Nodes.Add("R2", fnm.Substring(M));
                        }
                    }
                }

                TVreport.Nodes["R1"].Expand();
                //label7.Text = "ENDURANCE";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Could Not Show : " +  ex.Message );  
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LOAD_Files(); 
        }

        private void TVreport_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                    String Nm = TVreport.SelectedNode.Text;
                    Process[] prs = Process.GetProcesses();
                    foreach (Process pr in prs)
                    {
                        if ((pr.ProcessName == "EXCEL") || (pr.ProcessName == "excel")) pr.Kill();
                    }
                    object objMissing = System.Reflection.Missing.Value;
                    Global.DataPath = L + (comboBox1.Text) + "\\";
                    NodeT = TVreport.SelectedNode.Text;
                    if ((TVreport.SelectedNode.Tag != "R1"))
                    {
                        splitContainer1.Panel2.Select();   
                        string showFilepath = @"" + Global.DataPath + Nm;// ;+ "Project.chm";
                        if (File.Exists(showFilepath))
                        {
                            Process.Start(showFilepath);                            
                        }
                        else
                        {
                            MessageBox.Show("file not Found" + showFilepath);
                        }

                    }
                }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 17015", ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }





    }
}
