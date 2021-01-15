using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Editor
{
    public partial class frmPass : Form
    {
        private Boolean flg_NewUser = false;
        private Boolean flg_ExistUser = false;
        private Boolean flg_del = false;
        private MySqlCommand cmd;
        private MySqlCommand cmd1;
        public frmPass()
        {
            InitializeComponent();
        }

        private void mnuNewUser_Click(object sender, EventArgs e)
        {

            clear_text();
            txtOLDPass_Opr.Enabled = false;
            txtOpNm_Opr.Enabled = false;
            txtOpNm_Opr.Visible = true;
            txtNewpass_Opr.Enabled = false;
            txtConfPass_Opr.Enabled = false;
            comboBox1.Visible = false;
            flg_NewUser = true;
            flg_ExistUser = false;
            flg_del = false;

        }
        private void clear_text()
        {
            txtOLDPass_Opr.Text = "";
            txtOpNm_Opr.Text = "";
            txtSupPass_OPR.Text = "";
            comboBox1.Text = "";
            txtNewpass_Opr.Text = "";
            txtConfPass_Opr.Text = "";
        }

        private void mnuExisting_Click(object sender, EventArgs e)
        {
            clear_text();
            txtOLDPass_Opr.Enabled = false;

            txtOpNm_Opr.Visible = true;
            comboBox1.Visible = false;
            txtNewpass_Opr.Enabled = false;
            txtConfPass_Opr.Enabled = false;
            flg_NewUser = false;
            flg_ExistUser = true;
            flg_del = false;
        }

        private void tabControl1_Validating(object sender, CancelEventArgs e)
        {
            if ((txtNewPass_SUP.Text.Trim()) != (txtConfPass_SUP.Text.Trim()))
            {
                MessageBox.Show("Confirm Password didn't matched", "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Dose not Match Confirm Pssword");
                txtNewPass_SUP.Text = "";
                txtConfPass_SUP.Text = "";
                txtNewPass_SUP.Focus();
            }
            else
            {
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtConfPass_Opr_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSupClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnserclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnserSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOldPass_Ser.Text == "")
                {
                    MessageBox.Show("Enter Old Password", "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // MessageBox.Show("Enter Old Password....");
                    txtOldPass_Ser.Focus();
                    return;
                }
                if (txtNewPass_Ser.Text == "")
                {
                    MessageBox.Show("Enter New Password", "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // MessageBox.Show("Enter New Password....");
                    txtNewPass_Ser.Focus();
                    return;
                }
                if (txtConfPass_Ser.Text == "")
                {
                    MessageBox.Show("Confirm New Password", "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // MessageBox.Show("Confirm New Password....");
                    txtConfPass_Ser.Focus();
                    return;
                }

                string STR = "";
                Common.Open_Connection("gen_db", "con");
                cmd = new MySqlCommand("Select Passw from Sec where TokenNo = 'Service'", Common.con);
                //cmd.ExecuteNonQuery();
                MySqlDataReader Rd = cmd.ExecuteReader();
                while (Rd.Read())
                {
                    STR = Rd.GetValue(0).ToString();
                }
                Common.con.Close();
                if (txtOldPass_Ser.Text.Trim() == STR.Trim())
                {
                    if ((txtNewPass_Ser.Text.Trim()) == (STR.Trim()))
                    {
                        MessageBox.Show("This Password Already Exists", "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       // MessageBox.Show("This Password Already Exists");
                        txtNewPass_Ser.Text = "";
                        txtConfPass_Ser.Text = "";
                    }
                    else
                    {
                        string str1 = txtNewPass_Ser.Text.Trim();
                        Common.Open_Connection("gen_db", "con");
                        cmd1 = new MySqlCommand("UPDATE Sec SET Passw = '" + str1 + "' WHERE TokenNo = 'Service'");
                        cmd1.Connection = Common.con;
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Password Saved", "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      //  MessageBox.Show("Password Saved");
                        Common.con.Close();

                        txtNewPass_Ser.Text = "";
                        txtConfPass_Ser.Text = "";
                        txtOldPass_Ser.Text = "";
                        txtConfPass_Ser.Enabled = false;
                        txtNewPass_Ser.Enabled = false;

                    }
                }
                else
                {
                    MessageBox.Show("The Old Password is not Correct", "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   // MessageBox.Show("The OLD Password is not Correct");
                    txtOldPass_Ser.Text = "";
                }


                Common.con.Close();
            }
            catch (Exception ex)
            {
                Global.Create_OffLog("Alert","The OLD Password is not Correct");
                MessageBox.Show("Error Code:- 9002" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Error Code:- 9002", ex.Message);
            }


        }

        private void btnsupSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOldPass_SUP.Text == "")
                {
                    MessageBox.Show("Enter Old Password", "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // MessageBox.Show("Enter Old Password....");
                    txtOldPass_SUP.Focus();
                    return;
                }
                if (txtNewPass_SUP.Text == "")
                {
                    MessageBox.Show("Enter New Password", "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show("Enter New Password....");
                    txtNewPass_SUP.Focus();
                    return;
                }
                if (txtConfPass_SUP.Text == "")
                {
                    MessageBox.Show("Confirm New Password", "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // MessageBox.Show("Confirm New Password....");
                    txtConfPass_SUP.Focus();
                    return;
                }

                string STR = "";
                Common.Open_Connection("gen_db", "con");
                cmd = new MySqlCommand("Select Passw from Sec where TokenNo = 'Supervisor'", Common.con);
                //cmd.ExecuteNonQuery();
                MySqlDataReader Rd = cmd.ExecuteReader();
                while (Rd.Read())
                {
                    STR = Rd.GetValue(0).ToString();
                }
                Common.con.Close();
                if (txtOldPass_SUP.Text.Trim() == STR.Trim())
                {
                    if ((txtNewPass_SUP.Text.Trim()) == (STR.Trim()))
                    {
                        MessageBox.Show("This Password Already Exists", "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                       // MessageBox.Show("This Password Already Exists");
                        txtNewPass_SUP.Text = "";
                        txtConfPass_SUP.Text = "";
                    }
                    else
                    {
                        string str1 = txtNewPass_SUP.Text.Trim();
                        Common.Open_Connection("gen_db", "con");
                        cmd1 = new MySqlCommand("UPDATE Sec SET Passw = '" + str1 + "' WHERE TokenNo = 'Supervisor'");
                        cmd1.Connection = Common.con;
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Password Saved", "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Information );
                        //MessageBox.Show("Password Saved");
                        Common.con.Close();
                        txtConfPass_SUP.Enabled = false;
                        txtNewPass_SUP.Enabled = false;
                        txtConfPass_SUP.Text = "";
                        txtOldPass_SUP.Text = "";
                        txtNewPass_SUP.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("The Old Password Is Incorrect", "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   // MessageBox.Show("The OLD Password is not Correct");
                    txtOldPass_SUP.Text = "";
                }
                Common.con.Close();
            }
            catch (Exception ex)
            {
                Global.Create_OffLog("Alert", "Error In btnSupSave_Click");
                MessageBox.Show("Error Code:- 9001" + '\n' + ex.Message , "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Error Code:- 9001 ", ex.Message);
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {

                string str1, str2;
                str1 = txtNewpass_Opr.Text.Trim();
                str2 = txtOpNm_Opr.Text.Trim();
                if ((flg_NewUser == true) && (flg_ExistUser == false))
                {
                    Common.Open_Connection("gen_db", "con");
                    cmd1 = new MySqlCommand("Insert into Sec values ('" + str2 + "','" + str1 + "') ");
                    //            cmd1 = new MySqlCommand("UPDATE Sec SET Passw = '" + str1 + "' WHERE TokenNo ='" + str2 + "' ");
                    cmd1.Connection = Common.con;
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Password Saved", "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show("Password Saved");
                    Common.con.Close();
                }
                else if ((flg_ExistUser == true) && (flg_NewUser == false))
                {
                    Common.Open_Connection("gen_db", "con");
                    cmd1 = new MySqlCommand("UPDATE Sec SET Passw = '" + str1 + "' WHERE TokenNo ='" + str2 + "' ");
                    cmd1.Connection = Common.con;
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Password Changed", "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // MessageBox.Show("Password change");
                    Common.con.Close();

                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                Global.Create_OffLog("Alert", "Error In btnSave_Click");
                MessageBox.Show("btnsave_Click @ Error Code:-14005" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("btnsave_Click @ Error Code:-14005", ex.Message);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                string str1, str2;
                str1 = txtNewpass_Opr.Text.Trim();
                str2 = comboBox1.Text.Trim();   //txtOpNm_Opr.Text.Trim();
                Common.Open_Connection("gen_db", "con");
                cmd1 = new MySqlCommand("Delete  from Sec where TokenNo ='" + str2 + "' ");
                //            cmd1 = new MySqlCommand("UPDATE Sec SET Passw = '" + str1 + "' WHERE TokenNo ='" + str2 + "' ");
                cmd1.Connection = Common.con;
                cmd1.ExecuteNonQuery();
                MessageBox.Show("User Deleted", "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Information);
               // MessageBox.Show("Delete User");
                Common.con.Close();
                comboBox1.Items.Clear();
                fillcombo();
            }
            catch (Exception ex)
            {
                Global.Create_OffLog("Alert", "Error In btnDelete_Click");
                MessageBox.Show("btndelete_Click @ Error Code:-14006" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("btndelete_Click @ Error Code:-14005", ex.Message);
            }

        }


        private void fillcombo()
        {
            try
            {
                string STR = "";
                Common.Open_Connection("gen_db", "con");
                cmd = new MySqlCommand("Select TokenNo from Sec");
                cmd.Connection = Common.con;
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    STR = dr.GetValue(0).ToString();
                    if ((STR != "Supervisor") && (STR != "Service") && (STR != "DataSec"))
                    {
                        comboBox1.Items.Add(STR);
                    }
                }
                Common.con.Close();
            }
            catch (Exception ex)
            {
                Global.Create_OffLog("Alert", "Error In fillCombo");
                MessageBox.Show("fillcombo @ Error Code:-14007" + '\n' + ex.Message, "Dynalec Controls Pvt Ltd.", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // MessageBox.Show("fillcombo @ Error Code:-14007", ex.Message);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clear_text();
            flg_del = true;
            txtSupPass_OPR.Enabled = true;
            txtOLDPass_Opr.Enabled = false;
            txtOpNm_Opr.Visible = false;
            txtNewpass_Opr.Enabled = false;
            txtConfPass_Opr.Enabled = false;
            flg_NewUser = false;
            flg_ExistUser = false;
            comboBox1.Visible = true;
            comboBox1.Items.Clear();


        }

        private void frmPass_Load(object sender, EventArgs e)
        {

        }
    }
}
