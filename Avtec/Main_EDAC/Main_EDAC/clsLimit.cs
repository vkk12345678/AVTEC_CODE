using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Logger
{
    public  class clsLimit
    {
        public static void Check_Necessary_Files()
        {
            try
            {
                if (System.IO.Directory.Exists(Global.PATH) == false)
                {

                    MessageBox.Show(Global.PATH + " folder does not exist!!! Can not start Application.");
                }

                if (System.IO.File.Exists(Global.PATH + "General.accdb") == false)
                {

                    MessageBox.Show(Global.PATH + " General.accdb does not exist!!! Can not start Application.");
                }

                if (System.IO.File.Exists(Global.PATH + "Data.accdb") == false)
                {
                    MessageBox.Show(Global.PATH + " Data.accdb does not exist!!! Can not start Application.");
                }

                if (System.IO.File.Exists(Global.PATH + "Limit.accdb") == false)
                {
                    MessageBox.Show(Global.PATH + " Limit.accdb does not exist!!! Can not start Application.");
                }

                if (System.IO.File.Exists(Global.PATH + "Sequence.accdb") == false)
                {
                    MessageBox.Show(Global.PATH + " Sequence.accdb does not exist!!! Can not start Application.");

                }

                if (System.IO.File.Exists(Global.PATH + "Log.accdb") == false)
                {

                    MessageBox.Show(Global.PATH + " Log.accdb does not exist!!! Can not start Application.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in frmMain: Check_Necessary_Files():  " + ex.Message);
            }
        }
        //**************************
        public static void Read_Limfl()
        {
            try
            {
                Global.Open_Connection("lim_db", "conLim");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + Global.StpLimFl, Global.conLim);
                MySqlDataReader Rd = cmd.ExecuteReader();
                Int16 x = 0;
                while (Rd.Read())
                {
                    Global.LL1[x] = Rd.GetValue(2).ToString();
                    Global.L1[x] = Rd.GetValue(3).ToString();
                    Global.H1[x] = Rd.GetValue(4).ToString();
                    Global.HH1[x] = Rd.GetValue(5).ToString();
                    x += 1;
                }
                Rd.Close();
                Global.con.Close();
                Global.Create_OnLog("Limit file Read Successfully .....", "Normal");

            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Limit file not Read Successfully .....", "Alert");

                //MessageBox.Show("Error Code:-15019", ex.Message); 
            }
        }
        public static void Read_LimtStandby()
        {
            try
            {
                Global.Open_Connection("lim_db", "conLim");
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM LIM_STANDBY", Global.conLim);
                MySqlDataReader Rd = cmd.ExecuteReader();
                Int16 x = 0;
                while (Rd.Read())
                {

                    Global.Ls[x] = Rd.GetValue(3).ToString();
                    Global.Hs[x] = Rd.GetValue(4).ToString();

                    x += 1;
                }
                Rd.Close();
                Global.con.Close();
                Global.Create_OnLog("Limit Standard file Read Successfully .....", "Normal");

            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Limit Standard file not Read Successfully .....", "Alert");

                //MessageBox.Show("Error Code:-15019", ex.Message);
            }
        }
        //**************************

        public static void Check_ReadyDyno()
        {
            try
            {

                if (Global.DigIn[4] == Global.flg_VolActive)
                {
                    Global.ChkLim[0] = "N";
                    Global.cntDSafty = 0;
                }
                else
                {
                    if (Global.cntDSafty < 3) Global.cntDSafty += 1;
                    if (Global.cntDSafty == 3)
                    {
                        Global.ChkLim[0] = "N";
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Check_ReadyDyno(): " + ex.Message);
            }
        }

        public static void Check_Limit()
        {


            Int16 L = 0;
            String A1 = "";
            String B1 = "";
            String C1 = "";
            String D1 = "";
            String A2 = "";
            String B2 = "";
            String C2 = "";
            String D2 = "";
            Double InVal = 0;

            try
            {

                for (L = 0; L <= 95; L++)
                {
                    if (L == 2) L = 20;
                    if (Global.PSName[L] != "Not_Prog")
                    {
                        if (Global.LL1[L] != null) A1 = Global.LL1[L].Substring(0, 1);
                        if (Global.L1[L] != null) B1 = Global.L1[L].Substring(0, 1);
                        if (Global.H1[L] != null) C1 = Global.H1[L].Substring(0, 1);
                        if (Global.HH1[L] != null) D1 = Global.HH1[L].Substring(0, 1);

                        if (Global.LL1[L].Length > 1) A2 = Global.LL1[L].Substring(1); else A2 = Global.PMin[L];
                        if (Global.L1[L].Length > 1) B2 = Global.L1[L].Substring(1); else B2 = Global.PMin[L];
                        if (Global.H1[L].Length > 1) C2 = Global.H1[L].Substring(1); else C2 = Global.PMax[L];
                        if (Global.HH1[L].Length > 1) D2 = Global.HH1[L].Substring(1); else D2 = Global.PMax[L];

                        if (Global.GenData[L] != null) InVal = Double.Parse(Global.GenData[L]); else InVal = 0.0;
                        Global.StrAlarm = "";
                        if (((A1 == "O") && (InVal <= Convert.ToDouble(A2))) || ((D1 == "O") && (InVal >= Double.Parse(D2))))
                        {
                            Global.Flg_AList = true;
                            if ((Global.Flg_AList == true))//&& (Global.arrLim[L] == null) || (Global.arrLim[L] == "A"))
                            {
                                Global.arrLim[L] = "O : " + Global.PSName[L] + " ";
                                Global.BufLim[L] = "O";      //if (ViewGrid[2, L].Style.BackColor == Color.Green) 

                                Global.StrAlarm = Global.StrAlarm + "," + Global.arrLim[L];

                                Global.Create_OnLog("Engine Shut Off: " + Global.PSName[L] + " : " + InVal + "count :" + Global.LimNo[L], "Normal");

                                return;

                            }
                        }
                        else if ((((A1 == "I") && (InVal < double.Parse(A2))) || ((D1 == "I") && (InVal > Double.Parse(D2)))) && Global.flg_ChlLim == false)
                        {
                            Global.Flg_AList = true;
                            if ((Global.Flg_AList == true) && (Global.BufLim[L] != "I"))    //(ViewGrid[2, L].Style.BackColor == Color.Gainsboro))
                            {
                                Global.arrLim[L] = "I:" + Global.PSName[L] + " ";
                                Global.BufLim[L] = "I";    //if (ViewGrid[2, L].Style.BackColor == Color.Blue)

                                Global.StrAlarm = Global.StrAlarm + "," + Global.arrLim[L];
                                Global.Create_OnLog("Engine @ Idle: " + Global.PSName[L] + " : " + InVal + "count :" + Global.LimNo[L], "Normal");
                                Global.flg_ChlLim = true;
                                //                               

                                return;
                            }
                        }
                        else if (((B1 == "A") && (InVal < double.Parse(B2))) || ((C1 == "A") && (InVal > Double.Parse(C2))))
                        {
                            Global.Flg_AList = true;

                            if ((Global.Flg_AList == true) && (Global.arrLim[L] == null))    //A : " + Global.PSName[L] + " ";
                            {
                                Global.arrLim[L] = "A : " + Global.PSName[L] + " ";
                                Global.BufLim[L] = "A";  //if (ViewGrid[2, L].Style.BackColor == Color.Red)
                            }
                        }

                        else
                        {

                            Global.arrLim[L] = null;
                            Global.BufLim[L] = "N";

                        }
                        for (int k = 0; k <= 95; k++)
                        {
                            Global.StrAlarm = Global.StrAlarm + Global.arrLim[k];

                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Engine  Check_Limit :" + L + " : " + InVal, "Normal");
            }
        }


        //public static void Check_Limit()
        //        {
        //            Int16 L = 0;
        //            String A1, B1, C1, D1;
        //            String A2 = "";
        //            String B2 = "";
        //            String C2 = "";
        //            String D2 = "";
        //            Double InVal = 0;

        //            try
        //            {
        //                //Global.StrAlarm = "";


        //                for (L = 0; L <= 95; L++)
        //                {

        //                    if (L == 2) L = 6;
        //                    A1 = Global.LL1[L].Substring(0, 1);
        //                    B1 = Global.L1[L].Substring(0, 1);
        //                    C1 = Global.H1[L].Substring(0, 1);
        //                    D1 = Global.HH1[L].Substring(0, 1);

        //                    if (Global.LL1[L].Substring(1) != String.Empty) A2 = Global.LL1[L].Substring(1); else A2 = Global.PMin[L];
        //                    if (Global.L1[L].Substring(1) != String.Empty) B2 = Global.L1[L].Substring(1); else B2 = Global.PMin[L];
        //                    if (Global.H1[L].Substring(1) != String.Empty) C2 = Global.H1[L].Substring(1); else C2 = Global.PMax[L];
        //                    if (Global.HH1[L].Substring(1) != String.Empty) D2 = Global.HH1[L].Substring(1); else D2 = Global.PMax[L];
        //                    if (Global.GenData[L] == null) Global.GenData[L] = "0.0"; 
        //                    InVal = Double.Parse(Global.GenData[L]);
        //                    //
        //                    if (((A1 == "O") && (InVal <= Convert.ToDouble(A2))) || ((D1 == "O") && (InVal >= Double.Parse(D2))))
        //                    {
        //                        Global.Flg_AList = true;
        //                        if ((Global.Flg_AList == true) || (Global.BufLim[L] == "A"))  //&& (Global.arrLim[L] == "")
        //                        {
        //                            Global.arrLim[L] = "  O :  " + Global.PSName[L] + " ";
        //                            Global.BufLim[L] = "O";                           
        //                            Global.StrAlarm = "Engine OFF " + Global.arrLim[L];                            
        //                            Global.flg_ChlLim = true;                            
        //                            return;
        //                        }
        //                    }
        //                    else if (((A1 == "I") && (InVal < double.Parse(A2))) || ((D1 == "I") && (InVal > Double.Parse(D2))))
        //                    {
        //                        Global.Flg_AList = true;

        //                        if (Global.LimNo[L] <= 2)
        //                        {
        //                            Global.LimNo[L] += 1;
        //                            Global.Create_OnLog("Engine @ Idle: " + Global.PSName[L] + " : " + InVal + "count :" + Global.LimNo[L], "Normal");
        //                        }                       
        //                        if (Global.LimNo[L] > 2)
        //                        {
        //                            if ((Global.Flg_AList == true) && (Global.BufLim[L] != "I"))    //(ViewGrid[2, L].Style.BackColor == Color.Gainsboro))
        //                            {
        //                                Global.arrLim[L] = "I:" + Global.PSName[L] + " ";
        //                                Global.BufLim[L] = "I";    //if (ViewGrid[2, L].Style.BackColor == Color.Blue)
        //                                Global.StrAlarm = Global.StrAlarm + "," + Global.arrLim[L];                               
        //                            }
        //                        }
        //                        return;
        //                    }

        //                    else if (((B1 == "A") && (InVal < double.Parse(B2))) || ((C1 == "A") && (InVal > Double.Parse(C2))))
        //                    {

        //                        Global.Flg_AList = true;

        //                        //if ((Global.Flg_AList == true) && ((Global.arrLim[L] == "") || (Global.arrLim[L] == null)))    //A : " + Global.PSName[L] + " ";
        //                        if ((Global.Flg_AList == true) && ((Global.BufLim[L] == "N"))) // || (Global.arrLim[L].Substring(0, 1) == "N")))   

        //                        {
        //                            Global.arrLim[L] = "A : " + Global.PSName[L] + " ";
        //                            Global.BufLim[L] = "A";                            
        //                            Global.flg_AlarmLim = true;

        //                        }
        //                    }


        //                    else
        //                    {
        //                        Global.arrLim[L] = "";
        //                        Global.BufLim[L] = "N";                      

        //                    }
        //                }
        //                Global.StrAlarm = "";
        //                for (int k = 0; k <= 95; k++)
        //                {
        //                    Global.StrAlarm = Global.StrAlarm + Global.arrLim[k];
        //                    if (Global.StrAlarm == "") Global.StrAlarm = "";

        //                }
        //            }
        //            catch
        //            {               
        //                Global.Create_OnLog("Engine  Check_Limit :" + L + " : " + InVal, "Normal");
        //            }
        //        }




        //        public static void Check_Limit_Off()
        //        {
        //            Int16 L = 0;
        //            String A1 = "";
        //            String B1 = "";
        //            String C1 = "";
        //            String D1 = "";

        //            String A2 = "";
        //            String B2 = "";
        //            String C2 = "";
        //            String D2 = "";
        //            Double InVal = 0;

        //            try
        //            {
        //                for (L = 0; L <= 95; L++)
        //                {
        //                    if (L == 2) L = 6;
        //                    if (Global.PSName[L] != "Not_Prog")
        //                    {
        //                        if (Global.LL1[L] != "") A1 = Global.LL1[L].Substring(0, 1);
        //                        if (Global.L1[L] != "") B1 = Global.L1[L].Substring(0, 1);
        //                        if (Global.H1[L] != "") C1 = Global.H1[L].Substring(0, 1);
        //                        if (Global.HH1[L] != "") D1 = Global.HH1[L].Substring(0, 1);

        //                        if (Global.LL1[L].Length > 1) A2 = Global.LL1[L].Substring(1); else A2 = Global.PMin[L];
        //                        if (Global.L1[L].Length > 1) B2 = Global.L1[L].Substring(1); else B2 = Global.PMin[L];
        //                        if (Global.H1[L].Length > 1) C2 = Global.H1[L].Substring(1); else C2 = Global.PMax[L];
        //                        if (Global.HH1[L].Length > 1) D2 = Global.HH1[L].Substring(1); else D2 = Global.PMax[L];

        //                        if (Global.GenData[L] != null) InVal = Convert.ToDouble(Global.GenData[L]); else InVal = 0.0;
        //                        Global.StrAlarm = "";
        //                        if (((A1 == "O") && (InVal <= Convert.ToDouble(A2))) || ((D1 == "O") && (InVal >= Convert.ToDouble(D2))))
        //                        {
        //                            Global.Flg_AList = true;
        //                            if (Global.Flg_AList == true)
        //                            {
        //                                Global.arrLim[L] = "O : " + Global.PSName[L] + " ";
        //                                Global.BufLim[L] = "O";
        //                                Global.Create_OnLog("IGNITION OFF  : " + Global.PSName[L], "Normal");
        //                                Global.StrAlarm = "Engine OFF" + Global.arrLim[L];
        //                                Global.Create_OnLog("Engine ShutOFF: " + Global.PSName[L] + " : " + InVal, "Normal");
        //                                Global.flg_ChlLim = true;
        //                                return;
        //                            }
        //                        }
        //                        Global.StrAlarm = "";
        //                        for (int k = 0; k <= 95; k++)
        //                        {
        //                            Global.StrAlarm = Global.StrAlarm + Global.arrLim[k];
        //                            if (Global.StrAlarm == "") Global.StrAlarm = "";

        //                        }
        //                    }
        //                }
        //            }
        //            catch
        //            {
        //                Global.Create_OnLog("Engine  Check_Limit :" + L + " : " + InVal, "Normal");
        //            }
        //        }

        //        public static void Check_Limit_Idle()
        //        {
        //            Int16 L = 0;
        //            String A1 = "";
        //            String B1 = "";
        //            String C1 = "";
        //            String D1 = "";

        //            String A2 = "";
        //            String B2 = "";
        //            String C2 = "";
        //            String D2 = "";
        //            Double InVal = 0;

        //            try
        //            {
        //                for (L = 0; L <= 95; L++)
        //                {
        //                    if (L == 2) L = 6;
        //                    if (Global.PSName[L] != "Not_Prog")
        //                    {
        //                        if (Global.LL1[L] != "") A1 = Global.LL1[L].Substring(0, 1);
        //                        if (Global.L1[L] != "") B1 = Global.L1[L].Substring(0, 1);
        //                        if (Global.H1[L] != "") C1 = Global.H1[L].Substring(0, 1);
        //                        if (Global.HH1[L] != "") D1 = Global.HH1[L].Substring(0, 1);

        //                        if (Global.LL1[L].Length > 1) A2 = Global.LL1[L].Substring(1); else A2 = Global.PMin[L];
        //                        if (Global.L1[L].Length > 1) B2 = Global.L1[L].Substring(1); else B2 = Global.PMin[L];
        //                        if (Global.H1[L].Length > 1) C2 = Global.H1[L].Substring(1); else C2 = Global.PMax[L];
        //                        if (Global.HH1[L].Length > 1) D2 = Global.HH1[L].Substring(1); else D2 = Global.PMax[L];

        //                        if (Global.GenData[L] != null) InVal = Convert.ToDouble(Global.GenData[L]); else InVal = 0.0;
        //                        Global.StrAlarm = "";
        //                       if (((A1 == "I") && (InVal < double.Parse(A2))) || ((D1 == "I") && (InVal > Double.Parse(D2))))
        //                    {
        //                        Global.Flg_AList = true;

        //                        if (Global.LimNo[L] <= 2)
        //                        {
        //                            Global.LimNo[L] += 1;
        //                            Global.Create_OnLog("Engine @ Idle: " + Global.PSName[L] + " : " + InVal + "count :" + Global.LimNo[L], "Normal");
        //                        }                       
        //                        if (Global.LimNo[L] > 2)
        //                        {
        //                            if ((Global.Flg_AList == true) && (Global.BufLim[L] != "I"))    //(ViewGrid[2, L].Style.BackColor == Color.Gainsboro))
        //                            {
        //                                Global.arrLim[L] = "I:" + Global.PSName[L] + " ";
        //                                Global.BufLim[L] = "I";    //if (ViewGrid[2, L].Style.BackColor == Color.Blue)
        //                                Global.StrAlarm = Global.StrAlarm + "," + Global.arrLim[L];                               
        //                            }
        //                        }
        //                        return;
        //                    }
        //                        Global.StrAlarm = "";
        //                        for (int k = 0; k <= 95; k++)
        //                        {
        //                            Global.StrAlarm = Global.StrAlarm + Global.arrLim[k];
        //                            if (Global.StrAlarm == "") Global.StrAlarm = "";

        //                        }
        //                    }
        //                }
        //            }
        //            catch
        //            {
        //                Global.Create_OnLog("Engine  Check_Limit :" + L + " : " + InVal, "Normal");
        //            }
        //        }

        //         public static void Check_Limit_Alarm()
        //        {
        //            Int16 L = 0;
        //            String A1 = "";
        //            String B1 = "";
        //            String C1 = "";
        //            String D1 = "";

        //            String A2 = "";
        //            String B2 = "";
        //            String C2 = "";
        //            String D2 = "";
        //            Double InVal = 0;

        //            try
        //            {
        //                for (L = 0; L <= 95; L++)
        //                {
        //                    if (L == 2) L = 6;
        //                    if (Global.PSName[L] != "Not_Prog")
        //                    {
        //                        if (Global.LL1[L] != "") A1 = Global.LL1[L].Substring(0, 1);
        //                        if (Global.L1[L] != "") B1 = Global.L1[L].Substring(0, 1);
        //                        if (Global.H1[L] != "") C1 = Global.H1[L].Substring(0, 1);
        //                        if (Global.HH1[L] != "") D1 = Global.HH1[L].Substring(0, 1);

        //                        if (Global.LL1[L].Length > 1) A2 = Global.LL1[L].Substring(1); else A2 = Global.PMin[L];
        //                        if (Global.L1[L].Length > 1) B2 = Global.L1[L].Substring(1); else B2 = Global.PMin[L];
        //                        if (Global.H1[L].Length > 1) C2 = Global.H1[L].Substring(1); else C2 = Global.PMax[L];
        //                        if (Global.HH1[L].Length > 1) D2 = Global.HH1[L].Substring(1); else D2 = Global.PMax[L];

        //                        if (Global.GenData[L] != null) InVal = Convert.ToDouble(Global.GenData[L]); else InVal = 0.0;
        //                        Global.StrAlarm = "";
        //                   if (((B1 == "A") && (InVal < double.Parse(B2))) || ((C1 == "A") && (InVal > Double.Parse(C2))))
        //                    {

        //                        Global.Flg_AList = true;

        //                        //if ((Global.Flg_AList == true) && ((Global.arrLim[L] == "") || (Global.arrLim[L] == null)))    //A : " + Global.PSName[L] + " ";
        //                        if ((Global.Flg_AList == true) && ((Global.BufLim[L] == "N"))) // || (Global.arrLim[L].Substring(0, 1) == "N")))   

        //                        {
        //                            Global.arrLim[L] = "A : " + Global.PSName[L] + " ";
        //                            Global.BufLim[L] = "A";                            
        //                            Global.flg_AlarmLim = true;

        //                        }
        //                    }

        //                    }

        //                    else
        //                    {
        //                        Global.arrLim[L] = "";
        //                        Global.BufLim[L] = "N";                      

        //                    }

        //                        Global.StrAlarm = "";
        //                        for (int k = 0; k <= 95; k++)
        //                        {
        //                            Global.StrAlarm = Global.StrAlarm + Global.arrLim[k];
        //                            if (Global.StrAlarm == "") Global.StrAlarm = "";

        //                        }
        //                }
        //            }
        //            catch(Exception ex)
        //            {
        //                Global.Create_OnLog("Engine  Check_Limit :" + L + " : " + InVal, "Normal");
        //            }
        //        }
        //}


        //                else if (((A1 == "I") && (InVal < Convert.ToDouble(A2))) || ((D1 == "I") && (InVal > Convert.ToDouble(D2))))
        //                {
        //                    Global.Flg_AList = true;

        //                    if (Global.LimNo[L] <= 2)
        //                    {
        //                        Global.LimNo[L] += 1;
        //                    }
        //                    if (Global.LimNo[L] > 2)
        //                    {
        //                        if ((Global.Flg_AList == true) && (Global.BufLim[L] != "I"))
        //                        {
        //                            Global.arrLim[L] = "I:" + Global.PSName[L] + " ";
        //                            Global.BufLim[L] = "I";
        //                            Global.StrAlarm = "Engine @ Idle " + " : " + InVal;
        //                            Global.Create_OnLog("Engine @ Idle: " + Global.PSName[L] + " : " + InVal, "Normal");                               
        //                            Global.flg_ChlLim = true;
        //                        }
        //                    }
        //                    return;
        //                }
        //                //Global.StrAlarm = "";
        //                else if (((B1 == "A") && (InVal < double.Parse(B2))) || ((C1 == "A") && (InVal > Double.Parse(C2))))
        //                {
        //                    if ((Global.BufLim[L] != "A") && ((InVal < double.Parse(B2)) || ((C1 == "A") && (InVal > Double.Parse(C2)))))
        //                    {
        //                        Global.arrLim[L] = "A : " + Global.PSName[L] + " ";
        //                        Global.Create_OnLog("Alarm  : " + Global.PSName[L], "Normal");
        //                        Global.BufLim[L] = "A";
        //                        Global.Flg_AList = true;
        //                    }
        //                }
        //                else
        //                {
        //                    Global.BufLim[L] = "N";
        //                }
        //            }
        //        }
        //        for (int k = 0; k <= 50; k++)
        //        {
        //            Global.StrAlarm = Global.StrAlarm + Global.arrLim[k];
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Global.Create_OnLog("Error Check_Limit :" + L + " : " + InVal, "Normal");
        //    }
        //}

        public static void Check_Limit_Standby()
        {
            Int16 L = 0;
            String B1, C1;
            String B2 = "";
            String C2 = "";
            Double InVal = 0;
               
                for (L = 21; L <= 44; L++)
                {
                    if (Global.GenData[L] != "****")
                    { 
                    InVal = Convert.ToDouble(Global.GenData[L]);
                        B1 = Global.Ls[L].Substring(0, 1);
                        C1 = Global.Hs[L].Substring(0, 1);
                        if (Global.Ls[L].Substring(1) != String.Empty) B2 = Global.Ls[L].Substring(1); else B2 = Global.PMin[L];
                        if (Global.Hs[L].Substring(1) != String.Empty) C2 = Global.Hs[L].Substring(1); else C2 = Global.PMax[L];

                        if (((B1 == "A") && (InVal < double.Parse(B2))) || ((C1 == "A") && (InVal > Double.Parse(C2))))
                            Global.BufLim[L] = "A";
                        else
                            Global.BufLim[L] = "N";
                    }
                }  
        }






    }
}
