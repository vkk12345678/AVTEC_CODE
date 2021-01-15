using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class clsFun
    {
         const Double Pi = 3.1428571;
        public static string  cummbuff;

        public static Double HP_Power(int rpm, Double Tq)
        {
            if (rpm <= 0) rpm = 1;
            if (Tq <= 0) Tq = 0.1;

            rpm = Global.varRPM;
            Tq = Math.Abs(Global.varTRQ);
            Double Tmp = (2 * Pi * rpm * Tq) / (4500 * 9.81 );
            return Convert.ToDouble(Tmp.ToString("00.00"));
        }
        public static Double Ps_Power(int rpm, Double Tq)
        {
            if (rpm <= 0) rpm = 1;
            if (Tq <= 0) Tq = 0.1;
            rpm = Global.varRPM;
            Tq = Math.Abs(Global.varTRQ);
            Double Tmp = (2 * Pi * rpm * Tq) / (4500 * 9.81 * 1.014);
            return Convert.ToDouble(Tmp.ToString("00.00"));
        }
        public static Double kW_Power(int rpm, Double Tq)
        {
            if (rpm <= 0) rpm = 1;
            if (Tq <= 0)  Tq = 0.1;
            rpm = Global.varRPM;
            Tq = Math.Abs(Global.varTRQ);
            Double Tmp = (2 * Pi * rpm * Tq) / 60000;
            return Convert.ToDouble(Tmp.ToString("00.00"));
        }

        public static Double Cal_SFC_G(Double Pow,Double Gm,Double Tm)
        {
            if (Pow <= 0) Pow = 1;
            if (Gm <= 0)  Gm = 0.1;
            if (Tm <= 0) Tm = 0.1;
            Double Tmp = ((Gm * 3600) / (Pow * Tm));
            return Convert.ToDouble(Tmp.ToString("000"));
        }
        public static Double Cal_SFC_V(Double Pow,Double Vm,Double Tm)
        {
            if (Pow <= 0) Pow = 1;
            if (Vm <= 0)  Vm = 0.1;
            if (Tm <= 0)  Tm = 0.1;
            Double Tmp = ((Vm * 0.835 * 3600) / (Pow * Tm));
            return Convert.ToDouble(Tmp.ToString("000"));
        }
        public static Double Flow_Rate(Double Gm,Double Tm)
        {            
            if (Gm <= 0) Gm = 0.1;
            if (Tm <= 0)  Tm = 0.1;
            Double Tmp = (Gm / Tm)*3.6;
            return Convert.ToDouble(Tmp.ToString("00.0"));
        }

        public static Double Fuel_Del(Double Gm,Double Tm, int rpm, int Cn)
        {
            if (rpm <= 0)  rpm = 1;
            if (Cn <= 0)  Cn = 3;           
            if (Gm <= 0)  Gm = 0.1;
            if (Tm <= 0)  Tm = 0.1;
            Double Tmp = (Gm * 2000 * 3600) / (60 * Tm * 0.835 * rpm * Cn);
            return Convert.ToDouble(Tmp.ToString("00.0"));
        }
        public static Double Cal_bmep(Double Tq, Double vol)
        {
            if (vol <= 0)  vol = 1.0;
            if (Tq <= 0)  Tq = 0.1;
            Double Tmp = (4 * 3.142 * Tq) / (vol * 100);
            return Convert.ToDouble(Tmp.ToString("0.000"));
        }
        public  static string  TmCounter(Int16 hr, Int16 mm, Int16 ss, Boolean stat)
        {           
            if (stat == true)
            {
                if (ss > 59)
                {
                    ss = 0;
                    if (mm == 59)
                    {
                        mm = 0;
                        if (hr != 0) hr += 1; else hr = 1;
                    }
                    else
                    {
                        mm += 1;
                    }
                }
                else
                    ss += 1;
            }
            else if (stat == false)
            {
                if (ss < 1)
                {
                    ss = 59;
                    if (mm == 0)
                    {
                        mm = 59;
                        if (hr != 0) hr -= 1;
                    }
                    else
                    {
                        mm -= 1;
                    }
                }
                else
                    ss -= 1;
            }

           
            cummbuff = hr.ToString("0000") + ":" + mm.ToString("00") + ":" + ss.ToString("00"); ;
            return cummbuff;

        }
        public static Double CF_DIN_70020(Double DbT, Double Pb)
        {
            try
            {
                double Sq_Root = 1;
                double inv_corfct = 1;

                if ((Pb >= 1.1000) || (Pb <= 0.900)) Pb =  1.013;
                if ((DbT >= 50.0) || (DbT <= 10)) DbT = 31;

                Sq_Root = Math.Sqrt(((273 + DbT) / 293));
                inv_corfct = (Sq_Root * (760 / (Pb * 750)));

                return Convert.ToDouble(inv_corfct.ToString("0.00000"));
            }
            catch (Exception ex)
            {
                //Global.Create_OnLog("Error in CF_DIN_70020" + ex.Message);
                return (1.0000);
            }

        }

        public static Double SatWtrVp(Double T)
        {
            if ((T <= 10) || (T >= 55)) T = 32;
            double T1 = (4.6291 + (0.311 * T) + (0.0133 * T * T) + (0.00007 * T * T * T) + (0.000005 * T * T * T * T) - (0.000000008 * T * T * T * T * T));
            return (T1 / 800);
        }
        public static Double Cal_Rel_Humid(Double Bp, Double Dt, Double Wt)
        {
            Double Psw, Psd, PV = 0;
            Double Rel_Hum = 0;
            Psw = SatWtrVp(Wt);
            PV = Psw - ((Bp - Psw) * (Dt - Wt) * 1.8) / (2800 - 1.3 * (1.8 * (Dt + 32)));
            Psd = SatWtrVp(Dt);
            Rel_Hum = ((PV * 100) / (Psd));
            return Convert.ToDouble(Rel_Hum.ToString("00.0"));
            //return (Rel_Hum);
        }
        public static Double CF_IS_10000CS(Double rel, Double T, Double Pb)
        {
            double refsvp = 97.8687;
            double inv_corfct = 1;
            Double svp = SatWtrVp(T);

            double T1, T2, T3;
            //pressure Corrections
            T1 = (svp * 100) / 750;     // water Vp mmhg to kpa
            T2 = ((Pb * 1000) / 10) - (T1 * (rel / 100));//saturated water vapour Press
            T3 = T2 / refsvp; //Pressure Corrction
            //Temperature Corrections
            T1 = Math.Pow((300 / (273 + T)), 0.75);
            T2 = T1 * T3;
            inv_corfct = 1 / (T2 - 0.7 * (1 - T2) * ((1 / 0.85) - 1));
            return Convert.ToDouble(inv_corfct.ToString("0.00000"));
        }
        public static Double CF_BS_AU_141_A(Double fd, Double T, Double Pb)
        {            
            double refAtms = 760;
            double inv_corfct = 1;
            double refTemp = 20.0;
            double T1, T2, T3;
            //pressure Corrections
            T1 = Math.Pow((fd / 0.834), 2.88) * (refAtms - (Pb * 750)) * 0.00000059;
            //Temperture Corrections
            T2 = Math.Pow((fd / 0.834), 1.76) * (T - refTemp) * 0.00012;
            T3 = (T1 + T2 + 100) / 100;
            inv_corfct = T3;
            return Convert.ToDouble(inv_corfct.ToString("0.00000"));
        }


        public static Double CF_ISO_1585_NA(Double Bp, Double Wt, Double Dt, Double Fd, Double Svol)
        {
            //double TCR = 1.0;
            //double refsvp = 97.8687;
            double inv_corfct = 1;
            Double svp = SatWtrVp(Dt);
            Double fm = 1;
            if ((Bp >= 1.1) || (Bp <= 0.900)) Bp = 0.986;
            if ((Dt >= 55) || (Dt <= 2)) Dt = 32;
            if ((Wt >= 55) || (Wt <= 2)) Wt = 32;

            Double q = (0.835 * Convert.ToDouble(Global.Bi_Val) * Convert.ToDouble(Global.NCyl) / Convert.ToDouble(Global.Svol));
            int r = 1;
            Double qc = q / r;
            if (qc < 40)
                fm = 0.3;
            else if (qc > 65)
                fm = 1.2;
            else
                fm = 0.036 * (qc - 1.14);

            double PW = (0.00048333 * Wt * Wt * Wt) + (0.00175 * Wt * Wt) + (1.0579 * Wt) + 4.25625 - (0.63 * Dt);
            double pc = Bp - (PW / 1000);
            double C1 = Math.Pow (((273 + Dt) / 298), 1.5);
            double fa = Math.Pow((1 / pc), 0.7) * C1;
            if (fa <= 0) fa = 2;
            double C = Math.Pow((fa), fm);
            if ((C >= 1.1) || (C <= 0.9)) C = 1;

            inv_corfct = 1 / C;
            return Convert.ToDouble(inv_corfct.ToString("0.00000"));
        }


        public static Double CF_ISO_1585_TC(Double Bp, Double Tp, Double Wt, Double Dt, Double Fd, Double Svol)
        {
            double TCR = 1.0;
            double refsvp = 97.8687;
            double inv_corfct = 1;
            Double svp = SatWtrVp(Dt);
            Double fm = 1;
            if ((Bp >= 1.1) || (Bp <= 0.900)) Bp = 0.986;
            if ((Dt >= 55) || (Dt <= 2)) Dt = 32;
            if ((Wt >= 55) || (Wt <= 2)) Wt = 30;

            Double q = (0.835 * Convert.ToDouble(Global.Bi_Val) * Convert.ToDouble(Global.NCyl) / Convert.ToDouble(Global.Svol));

            Double r = (Bp + Tp) / Bp;
            Double qc = q / r;
            if (qc < 40)
                fm = 0.3;
            else if (qc > 65)
                fm = 1.2;
            else
                fm = 0.036 * (qc - 1.14);

            double PW = (0.00048333 * Wt * Wt * Wt) + (0.00175 * Wt * Wt) + (1.0579 * Wt) + 4.25625 - (0.63 * Dt);
            double pc = Bp - (PW / 1000);
            double C1 = Math.Pow(((273 + Dt) / 298), 1.5);
            double fa = Math.Pow((1 / pc), 0.7) * C1;
            if (fa <= 0) fa = 2;
            double C = Math.Pow((fa), fm);
            if ((C >= 1.1) || (C <= 0.9)) C = 1;

            inv_corfct = 1 / C;
            return Convert.ToDouble(inv_corfct.ToString("0.00000"));
        }

        public static Double CF_ISO_15550_NA(Double Bp, Double Wt, Double Dt, Double Fd, Double Svol)
        {
            double TCR = 1.0;
            double refsvp = 97.8687;
            double inv_corfct = 1;
            Double svp = SatWtrVp(Dt);
            Double fm = 1;
            if ((Bp >= 1.1) || (Bp <= 0.900)) Bp = 0.986;
            if ((Dt >= 55) || (Dt <= 2)) Dt = 32;
            if ((Wt >= 55) || (Wt <= 2)) Wt = 32;

            Double q = (0.835 * Convert.ToDouble(Global.Bi_Val) * Convert.ToDouble(Global.NCyl) / Convert.ToDouble(Global.Svol));
            int r = 1;
            Double qc = q / r;
            if (qc < 37.5)
                fm = 0.2;
            else if (qc > 65)
                fm = 1.2;
            else
                fm = 0.036 * (qc - 1.14);

            double PW = (0.00048333 * Wt * Wt * Wt) + (0.00175 * Wt * Wt) + (1.0579 * Wt) + 4.25625 - (0.63 * Dt);
            double pc = Bp - (PW / 1000);
            double C1 = Math.Pow(((273 + Dt) / 298), 1.5);
            double fa = Math.Pow((1 / pc), 0.7) * C1;
            if (fa <= 0) fa = 2;
            double C = Math.Pow((fa), fm);
            if ((C >= 1.1) || (C <= 0.9)) C = 1;

            inv_corfct = 1 / C;
            return Convert.ToDouble(inv_corfct.ToString("0.00000"));
        }



        public static Double IS_14599_NA(Double Bp, Double Wt, Double Dt, Double Fd, Double Svol)
        {
            double TCR = 1.0;
            double refsvp = 97.8687;
            double inv_corfct = 1;
            Double svp = SatWtrVp(Dt);
            Double fm = 1;
            if ((Bp >= 1.1) || (Bp <= 0.900)) Bp = 0.986;
            if ((Dt >= 55) || (Dt <= 2)) Dt = 32;
            if ((Wt >= 55) || (Wt <= 2)) Wt = 32;

            Double q = (0.835 * Convert.ToDouble(Global.Bi_Val) * Convert.ToDouble(Global.NCyl) / Convert.ToDouble(Global.Svol));
            int r = 1;
            Double qc = q / r;
            if (qc < 40)
                fm = 0.3;
            else if (qc > 65)
                fm = 1.2;
            else
                fm = 0.036 * (qc - 1.14);

            double PW = (0.00048333 * Wt * Wt * Wt) + (0.00175 * Wt * Wt) + (1.0579 * Wt) + 4.25625 - (0.63 * Dt);
            double pc = Bp - (PW / 1000);
            double C1 = Math.Pow (((273 + Dt) / 298), 1.5);
            double fa = Math.Pow((1 / pc), 0.7) * C1;
            if (fa <= 0) fa = 2;
            double C = Math.Pow((fa), fm);
            if ((C >= 1.1) || (C <= 0.9)) C = 1;

            inv_corfct = 1 / C;
            return Convert.ToDouble(inv_corfct.ToString("0.00000"));
        }


        public static Double IS_14599_TC(Double Bp, Double Tp, Double Wt, Double Dt, Double Fd, Double Svol)
        {
            //double TCR = 1.0;
            //double refsvp = 97.8687;
            double inv_corfct = 1;
            Double svp = SatWtrVp(Dt);
            Double fm = 1;
            if ((Bp >= 1.1) || (Bp <= 0.900)) Bp = 0.986;
            if ((Dt >= 55) || (Dt <= 2)) Dt = 32;
            if ((Wt >= 55) || (Wt <= 2)) Wt = 30;

            Double q = (0.835 * Convert.ToDouble(Global.Bi_Val) * Convert.ToDouble(Global.NCyl) / Convert.ToDouble(Global.Svol));

            Double r = (Bp + Tp) / Bp;
            Double qc = q / r;
            if (qc < 40)
                fm = 0.3;
            else if (qc > 65)
                fm = 1.2;
            else
                fm = 0.036 * (qc - 1.14);

            double PW = (0.00048333 * Wt * Wt * Wt) + (0.00175 * Wt * Wt) + (1.0579 * Wt) + 4.25625 - (0.63 * Dt);
            double pc = Bp - (PW / 1000);
            double C1 = Math.Pow(((273 + Dt) / 298), 1.5);
            double fa = Math.Pow((1 / pc), 0.7) * C1;
            if (fa <= 0) fa = 2;
            double C = Math.Pow((fa), fm);
            if ((C >= 1.1) || (C <= 0.9)) C = 1;

            inv_corfct = 1 / C;
            return Convert.ToDouble(inv_corfct.ToString("0.00000"));
        }

        //*****************************
      

        public static void Mode_to_Mode()
        {
            try
            {

                if (Global.Diff1 > 0)
                {
                    if (Global.AnaOut1 >= Double.Parse(Global.SetPtOut1))
                    {
                        Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                        Global.Diff1 = 0;
                    }
                }
                else if (Global.Diff1 < 0)
                {
                    if (Global.AnaOut1 <= Double.Parse(Global.SetPtOut1))
                    {
                        Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                        Global.Diff1 = 0;
                    }
                }
                if (Global.Diff2 > 0)
                {
                    if (Global.AnaOut2 > Double.Parse(Global.SetPtOut2))
                    {
                        Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                        Global.Diff2 = 0;
                    }
                }
                else if (Global.Diff2 < 0)
                {
                    if (Global.AnaOut2 <= Double.Parse(Global.SetPtOut2))
                    {
                        Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                        Global.Diff2 = 0;
                    }
                }
                Global.AnaOut1 = Global.AnaOut1 + Global.Diff1;
                Global.AnaOut2 = Global.LastAna2 + Global.Diff2;     //Global.AnaOut2 + Global.Diff2;

                switch (int.Parse(Global.C_Mode))
                {
                    case 1:
                        Global.Mode_Out(1, 0, 0);
                        break;
                    case 2:
                        Global.Mode_Out(0, 1, 0);
                        break;
                    case 3:
                        Global.Mode_Out(1, 1, 0);
                        break;
                    case 4:
                        Global.Mode_Out(0, 0, 1);
                        break;
                    case 5:
                        Global.Mode_Out(1, 0, 1);
                        break;
                    case 6:
                        Global.Mode_Out(0, 1, 1);
                        break;
                }
            }

            catch (Exception ex)
            {
                return; //MessageBox.Show("Error Code:- 15018", ex.Message);
            }
        }
       
//*************************
        public static void MODE5_TO_MODE6()
        {
            Global.Mode_Out(1, 0, 1);
            if (Global.Diff1 > 0)
            {
                if (Global.AnaOut1 >= Double.Parse(Global.SetPtOut1))
                {
                    Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                    Global.Diff1 = 0;
                }
            }
            else if (Global.Diff1 < 0)
            {
                if (Global.AnaOut1 <= Double.Parse(Global.SetPtOut1))
                {
                    Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                    Global.Diff1 = 0;
                }
            }

            if (Global.Diff2 > 0)
            {
                if (Global.AnaOut2 > Global.varTRQ)
                {
                    Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                    Global.Diff2 = 0;
                }
            }
            else if (Global.Diff2 < 0)
            {
                if (Global.AnaOut2 <= Global.varTRQ)
                {
                    Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                    Global.Diff2 = 0;
                }
            }
            Global.AnaOut1 = Global.AnaOut1 + Global.Diff1;
            Global.AnaOut2 = Global.LastAna2 + Global.Diff2;

        }

        //*****************************
        public static void MODE_TO_MODE()
        {
            try
            {
                //switch (int.Parse(Global.C_Mode))
                //{
                //    case 1:
                //        Global.Mode_Out(1, 0, 0);
                //        break;
                //    case 2:
                //        Global.Mode_Out(0, 1, 0);
                //        break;
                //    case 3:
                //        Global.Mode_Out(1, 1, 0);
                //        break;
                //    case 4:
                //        Global.Mode_Out(0, 0, 1);
                //        break;
                //    case 5:
                //        Global.Mode_Out(1, 0, 1);
                //        break;
                //    case 6:
                //        Global.Mode_Out(0, 1, 1);
                //        break;
                //}
                //if (Global.Diff1 > 0)
                //{
                //    if (Global.AnaOut1 >= Double.Parse(Global.SetPtOut1))
                //    {
                //        Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                //        Global.Diff1 = 0;
                //    }
                //}
                //else if (Global.Diff1 < 0)
                //{
                //    if (Global.AnaOut1 <= Double.Parse(Global.SetPtOut1))
                //    {
                //        Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                //        Global.Diff1 = 0;
                //    }
                //}
                //if (Global.Diff2 > 0)
                //{
                //    if (Global.AnaOut2 > Double.Parse(Global.SetPtOut2))
                //    {
                //        Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                //        Global.Diff2 = 0;
                //    }
                //}
                //else if (Global.Diff2 < 0)
                //{
                //    if (Global.AnaOut2 <= Double.Parse(Global.SetPtOut2))
                //    {
                //        Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                //        Global.Diff2 = 0;
                //    }
                //}
                //if (Global.C_Mode == "2")
                //    if (Global.AnaOut1 <= 0.800) Global.AnaOut1 = 0.800;

                //Global.AnaOut1 = Global.AnaOut1 + Global.Diff1;
// for 4024 ADAM Modul
               
                // // double Ao = (Global.AnaOut1);
                if (!Global.RTPort.IsOpen) Global.Init_RtPort();
                if (Global.flg_CylStart == true)
                {
                    Global.AOvar = Global.AnaOut1.ToString("00.000");
                    Global.RTPort.Write("#04C0+" + Global.AOvar + "\r");
                    Global.AnaOut1 = Global.AnaOut1 + Global.Diff1;
                }
               

                //Global.AnaOut2 = Global.AnaOut2 + Global.Diff2;
            }
            catch //(Exception ex)
            {
                return;
            }
        }

        //**************************
        public static void MODE_TO_MODE_STANDARD_New()
        {
           try
            {
                if (((Global.L_Mode == "2") || (Global.L_Mode == "3") || (Global.L_Mode == "4"))
                   && ((Global.C_Mode == "5") || (Global.C_Mode == "6")))
                    Global.Mode_Out(0, 1, 1);
                else if (((Global.C_Mode == "2") || (Global.C_Mode == "3") || (Global.C_Mode == "4"))
                   && ((Global.L_Mode == "5") || (Global.L_Mode == "6")))
                    Global.Mode_Out(0, 1, 1);
               else
                   {
                       switch (int.Parse(Global.C_Mode))
                       {
                           case 1:
                               Global.Mode_Out(1, 0, 0);
                               break;
                           case 2:
                               Global.Mode_Out(0, 1, 0);
                               break;
                           case 3:
                               Global.Mode_Out(1, 1, 0);
                               break;
                           case 4:
                               Global.Mode_Out(0, 0, 1);
                               break;
                           case 5:
                               Global.Mode_Out(1, 0, 1);
                               break;
                           case 6:
                               Global.Mode_Out(0, 1, 1);
                               break;
                       }
                   }

                if (Global.Diff1 > 0)
                    {
                        if (Global.AnaOut1 >= Double.Parse(Global.SetPtOut1))
                        {
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                            Global.Diff1 = 0;
                        }
                    }
                else if (Global.Diff1 < 0)
                    {
                        if (Global.AnaOut1 <= Double.Parse(Global.SetPtOut1))
                        {
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                            Global.Diff1 = 0;
                        }
                    }
                if (Global.Diff2 > 0)
                    {
                        if (Global.AnaOut2 > Double.Parse(Global.SetPtOut2))
                        {
                            Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                            Global.Diff2 = 0;
                        }
                    }
                else if (Global.Diff2 < 0)
                    {
                        if (Global.AnaOut2 <= Double.Parse(Global.SetPtOut2))
                        {
                            Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                            Global.Diff2 = 0;
                        }
                    }
                Global.AnaOut1 = Global.AnaOut1 + Global.Diff1;
                Global.AnaOut2 = Global.AnaOut2 + Global.Diff2;
               }
            
            catch (Exception ex)
            {
                Global.Create_OnLog("Error in frmMain: Fun_AnaOut() : ", "Alert");
                //MessageBox.Show("Error Code:- 15018", ex.Message);
                return;           
           
            }

        }

        //********************
        public static void MODE_TO_MODE_STANDARD()
        {
            try
            {
                if ((int.Parse(Global.C_Mode) >= 4) || (int.Parse(Global.C_Mode) == 2))
                {
                    //int a = (Global.I_Rpm * 10) / int.Parse(Global.sysIn[5]);
                    //if (Global.AnaOut1 <= Convert.ToDouble(a)) Global.AnaOut1 = Convert.ToDouble(a);
                }
                //*****************
                if ((int.Parse(Global.C_Mode) >= 5) && (Double.Parse(Global.SetPtOut2) <= 0.1))
                {
                    Global.Mode_Out(1, 0, 1);
                    if (Global.Diff1 > 0)
                    {
                        if (Global.AnaOut1 >= Double.Parse(Global.SetPtOut1))
                        {
                            //Global.Mode_Out(0, 1, 1);
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                            Global.Diff1 = 0;
                        }
                    }
                    else if (Global.Diff1 < 0)
                    {
                        if (Global.AnaOut1 <= 2) //Double.Parse(Global.SetPtOut1))
                        {
                            //Global.Mode_Out(0, 1, 1);
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                            Global.Diff1 = 0;
                        }
                    }
                    if (Global.Diff2 > 0)
                    {
                        if (Global.AnaOut2 > Double.Parse(Global.SetPtOut2))
                        {

                            Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                            Global.Diff2 = 0;
                        }
                    }
                    else if (Global.Diff2 < 0)
                    {
                        if (Global.AnaOut2 <= Double.Parse(Global.SetPtOut2))
                        {
                            //Global.Mode_Out(0,1,1);
                            Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                            Global.Diff2 = 0;
                        }
                    }
                    Global.AnaOut1 = Global.AnaOut1 + Global.Diff1;
                    Global.AnaOut2 = Global.AnaOut2 + Global.Diff2;
                }

                else if ((int.Parse(Global.L_Mode) >= 5) && (int.Parse(Global.C_Mode) <= 4))
                {
                    if (Global.Diff1 > 0)
                    {
                        if (Global.AnaOut1 >= Double.Parse(Global.SetPtOut1))
                        {
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                            Global.Diff1 = 0;
                        }
                    }
                    else if (Global.Diff1 < 0)
                    {
                        if (Global.AnaOut1 <= Double.Parse(Global.SetPtOut1))
                        {
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                            Global.Diff1 = 0;
                        }
                    }
                    if (Global.Diff2 > 0)
                    {
                        if (Global.AnaOut2 > Double.Parse(Global.SetPtOut2))
                        {
                            Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                            Global.Diff2 = 0;
                            Global.Mode_Out(0, 0, 1);
                        }
                    }
                    else if (Global.Diff2 < 0)
                    {
                        if (Global.AnaOut2 <= Double.Parse(Global.SetPtOut2))
                        {
                            Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                            Global.Diff2 = 0;
                            Global.Mode_Out(0, 0, 1);
                        }
                    }
                    Global.AnaOut1 = Global.AnaOut1 + Global.Diff1;
                    Global.AnaOut2 = Global.AnaOut2 + Global.Diff2;
                }
                else if ((int.Parse(Global.L_Mode) <= 4) && (int.Parse(Global.C_Mode) >= 5))
                {
                    Global.Mode_Out(0, 1, 1);
                    if (Global.Diff1 > 0)
                    {
                        if (Global.AnaOut1 >= Double.Parse(Global.SetPtOut1))
                        {
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                            Global.Diff1 = 0;
                        }
                    }
                    else if (Global.Diff1 < 0)
                    {
                        if (Global.AnaOut1 <= Double.Parse(Global.SetPtOut1))
                        {
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                            Global.Diff1 = 0;
                        }
                    }
                    if (Global.Diff2 > 0)
                    {
                        if (Global.AnaOut2 > Double.Parse(Global.SetPtOut2))
                        {
                            Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                            Global.Diff2 = 0;
                        }
                    }
                    else if (Global.Diff2 < 0)
                    {
                        if (Global.AnaOut2 <= Double.Parse(Global.SetPtOut2))
                        {
                            Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                            Global.Diff2 = 0;
                        }
                    }
                    Global.AnaOut1 = Global.AnaOut1 + Global.Diff1;
                    Global.AnaOut2 = Global.AnaOut2 +Global.Diff2;
                }
                else
                {
                    switch (int.Parse(Global.C_Mode))
                    {
                        case 1:
                            Global.Mode_Out(1, 0, 0);
                            break;
                        case 2:
                            Global.Mode_Out(0, 0, 1);
                            break;
                        case 3:
                            Global.Mode_Out(0, 0, 1);
                            break;
                        case 4:
                            Global.Mode_Out(0, 0, 1);
                            break;
                        case 5:
                            Global.Mode_Out(0, 1, 1);
                            break;
                        case 6:
                            Global.Mode_Out(0, 1, 1);
                            break;
                    }
                    if (Global.Diff1 > 0)
                    {
                        if (Global.AnaOut1 >= Double.Parse(Global.SetPtOut1))
                        {
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                            Global.Diff1 = 0;
                        }
                    }
                    else if (Global.Diff1 < 0)

                        if (Global.AnaOut1 <= Double.Parse(Global.SetPtOut1))
                        {
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                            Global.Diff1 = 0;
                        }
                    }
                    if (Global.Diff2 > 0)
                    {
                        if (Global.AnaOut2 > Double.Parse(Global.SetPtOut2))
                        {
                            Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                            Global.Diff2 = 0;
                        }
                    }
                    else if (Global.Diff2 < 0)
                    {
                        if (Global.AnaOut2 <= Double.Parse(Global.SetPtOut2))
                        {
                            Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                            Global.Diff2 = 0;
                        }
                    }
                    Global.AnaOut1 = Global.AnaOut1 + Global.Diff1;
                    Global.AnaOut2 = Global.AnaOut2 + Global.Diff2;
                }
       
    
            catch
            {
                Global.Create_OnLog("Error in frmMain: Fun_AnaOut() : ", "Alert");
                return;
            }
        }

       

        //*************************

        public static void MODE_TO_MODE_Smooth()
        {
            try
            {
                if ((int.Parse(Global.C_Mode) >= 4) || (int.Parse(Global.C_Mode) == 2))
                {
                    //int a = (Global.I_Rpm * 10) / int.Parse(Global.sysIn[5]);
                    //if (Global.AnaOut1 <= Convert.ToDouble(a)) Global.AnaOut1 = Convert.ToDouble(a);
                }
                //*****************
                if ((int.Parse(Global.C_Mode) >= 5) && (Double.Parse(Global.SetPtOut2) <= 0.1))
                {
                    Global.Mode_Out(1, 0, 1);
                    if (Global.Diff1 > 0)
                    {
                        if (Global.AnaOut1 >= Double.Parse(Global.SetPtOut1))
                        {
                            //Global.Mode_Out(0, 1, 1);
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                            Global.Diff1 = 0;
                        }
                    }
                    else if (Global.Diff1 < 0)
                    {
                        if (Global.AnaOut1 <= 2) //Double.Parse(Global.SetPtOut1))
                        {
                            //Global.Mode_Out(0, 1, 1);
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                            Global.Diff1 = 0;
                        }
                    }
                    if (Global.Diff2 > 0)
                    {
                        if (Global.AnaOut2 > Double.Parse(Global.SetPtOut2))
                        {

                            Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                            Global.Diff2 = 0;
                        }
                    }
                    else if (Global.Diff2 < 0)
                    {
                        if (Global.AnaOut2 <= Double.Parse(Global.SetPtOut2))
                        {
                            //Global.Mode_Out(0,1,1);
                            Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                            Global.Diff2 = 0;
                        }
                    }
                    Global.AnaOut1 = Global.AnaOut1 + Global.Diff1;
                    Global.AnaOut2 = Global.AnaOut2 + Global.Diff2;
                }

                else if ((int.Parse(Global.L_Mode) >= 5) && (int.Parse(Global.C_Mode) <= 4))
                {
                    if (Global.Diff1 > 0)
                    {
                        if (Global.AnaOut1 >= Double.Parse(Global.SetPtOut1))
                        {
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                            Global.Diff1 = 0;
                        }
                    }
                    else if (Global.Diff1 < 0)
                    {
                        if (Global.AnaOut1 <= Double.Parse(Global.SetPtOut1))
                        {
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                            Global.Diff1 = 0;
                        }
                    }
                    if (Global.Diff2 > 0)
                    {
                        if (Global.AnaOut2 > Double.Parse(Global.SetPtOut2))
                        {
                            Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                            Global.Diff2 = 0;
                            Global.Mode_Out(0, 0, 1);
                        }
                    }
                    else if (Global.Diff2 < 0)
                    {
                        if (Global.AnaOut2 <= Double.Parse(Global.SetPtOut2))
                        {
                            Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                            Global.Diff2 = 0;
                            Global.Mode_Out(0, 0, 1);
                        }
                    }
                    Global.AnaOut1 = Global.AnaOut1 + Global.Diff1;
                    Global.AnaOut2 = Global.AnaOut2 + Global.Diff2;
                }
                else if ((int.Parse(Global.L_Mode) <= 4) && (int.Parse(Global.C_Mode) >= 5))
                {
                    Global.Mode_Out(0, 1, 1);
                    if (Global.Diff1 > 0)
                    {
                        if (Global.AnaOut1 >= Double.Parse(Global.SetPtOut1))
                        {
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                            Global.Diff1 = 0;
                        }
                    }
                    else if (Global.Diff1 < 0)
                    {
                        if (Global.AnaOut1 <= Double.Parse(Global.SetPtOut1))
                        {
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                            Global.Diff1 = 0;
                        }
                    }
                    if (Global.Diff2 > 0)
                    {
                        if (Global.AnaOut2 > Double.Parse(Global.SetPtOut2))
                        {
                            Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                            Global.Diff2 = 0;
                        }
                    }
                    else if (Global.Diff2 < 0)
                    {
                        if (Global.AnaOut2 <= Double.Parse(Global.SetPtOut2))
                        {
                            Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                            Global.Diff2 = 0;
                        }
                    }
                    Global.AnaOut1 = Global.AnaOut1 + Global.Diff1;
                    Global.AnaOut2 = Global.AnaOut2 + Global.Diff2;
                }
                else
                {
                    switch (int.Parse(Global.C_Mode))
                    {
                        case 1:
                            Global.Mode_Out(1, 0, 0);
                            break;
                        case 2:
                            Global.Mode_Out(0, 0, 1);
                            break;
                        case 3:
                            Global.Mode_Out(0, 0, 1);
                            break;
                        case 4:
                            Global.Mode_Out(0, 0, 1);
                            break;
                        case 5:
                            Global.Mode_Out(0, 1, 1);
                            break;
                        case 6:
                            Global.Mode_Out(0, 1, 1);
                            break;
                    }
                    if (Global.Diff1 > 0)
                    {
                        if (Global.AnaOut1 >= Double.Parse(Global.SetPtOut1))
                        {
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                            Global.Diff1 = 0;
                        }
                    }
                    else if (Global.Diff1 < 0)
                    {
                        if (Global.AnaOut1 <= Double.Parse(Global.SetPtOut1))
                        {
                            Global.AnaOut1 = Double.Parse(Global.SetPtOut1);
                            Global.Diff1 = 0;
                        }
                    }
                    if (Global.Diff2 > 0)
                    {
                        if (Global.AnaOut2 > Double.Parse(Global.SetPtOut2))
                        {
                            Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                            Global.Diff2 = 0;
                        }
                    }
                    else if (Global.Diff2 < 0)
                    {
                        if (Global.AnaOut2 <= Double.Parse(Global.SetPtOut2))
                        {
                            Global.AnaOut2 = Double.Parse(Global.SetPtOut2);
                            Global.Diff2 = 0;
                        }
                    }
                    Global.AnaOut1 = Global.AnaOut1 + Global.Diff1;
                    Global.AnaOut2 = Global.AnaOut2 + Global.Diff2;
                }
            }
            catch
            {
                Global.Create_OnLog("Error in frmMain: Fun_AnaOut() : ", "Alert");
                return;
            }
        }
       
       
//*********************************
        
       

//************************
        //public static void Read_Limfl()
        //{
        //    try
        //    {
        //        Global.Open_Connection("gen_db", "conLim");
        //       MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + Global.Prj[3], Global.conLim);
        //        MySqlDataReader Rd = cmd.ExecuteReader();
        //        Int16 x = 0;
        //        while (Rd.Read())
        //        {
        //            Global.LL1[x] = Rd.GetValue(2).ToString();
        //            Global.L1[x] = Rd.GetValue(3).ToString();
        //            Global.H1[x] = Rd.GetValue(4).ToString();
        //            Global.HH1[x] = Rd.GetValue(5).ToString();
        //            x += 1;
        //        }
        //        Global.con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show("Error Code:-15019", ex.Message);
        //        return;
        //    }
        //}
        //public static void Read_LimtStandby()
        //{
        //    try
        //    {
        //        Global.Open_Connection("lim_db", "conLim");
        //        MySqlCommand cmd = new MySqlCommand("SELECT * FROM LIM_STANDBY", Global.conLim);
        //        MySqlDataReader Rd = cmd.ExecuteReader();
        //        Int16 x = 0;
        //        while (Rd.Read())
        //        {

        //            Global.Ls[x] = Rd.GetValue(3).ToString();
        //            Global.Hs[x] = Rd.GetValue(4).ToString();

        //            x += 1;
        //        }
        //        Global.con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //        //MessageBox.Show("Error Code:-15019", ex.Message);
        //    }
        //}

        public static void Check_Limit_Standby()
        {
            Int16 L = 0;
            String B1, C1;
            String B2 = "";
            String C2 = "";
            Double InVal = 0;

            Global.StrAlarm = "";

            for (L = 0; L <= 95; L++)
            {
                if (L == 2) L = 6;
                B1 = Global.Ls[L].Substring(0, 1);
                C1 = Global.Hs[L].Substring(0, 1);
                if (Global.Ls[L].Substring(1) != String.Empty) B2 = Global.Ls[L].Substring(1); else B2 = Global.PMin[L];
                if (Global.Hs[L].Substring(1) != String.Empty) C2 = Global.Hs[L].Substring(1); else C2 = Global.PMax[L];

                InVal = Convert.ToDouble(Global.GenData[L]);
                
                if (((B1 == "A") && (InVal < double.Parse(B2))) || ((C1 == "A") && (InVal > Double.Parse(C2))))
                {
                    Global.BufLim[L] = "A";
                }
                else
                {
                    Global.BufLim[L] = "N";
                }
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
                    if (L == 2) L = 6;
                    if (Global.PSName[L] != "Not_Prog")
                    {
                        if (Global.LL1[L] != "") A1 = Global.LL1[L].Substring(0, 1);
                        if (Global.L1[L] != "") B1 = Global.L1[L].Substring(0, 1);
                        if (Global.H1[L] != "") C1 = Global.H1[L].Substring(0, 1);
                        if (Global.HH1[L] != "") D1 = Global.HH1[L].Substring(0, 1);

                        if (Global.LL1[L].Length > 1) A2 = Global.LL1[L].Substring(1); else A2 = Global.PMin[L];
                        if (Global.L1[L].Length > 1) B2 = Global.L1[L].Substring(1); else B2 = Global.PMin[L];
                        if (Global.H1[L].Length > 1) C2 = Global.H1[L].Substring(1); else C2 = Global.PMax[L];
                        if (Global.HH1[L].Length > 1) D2 = Global.HH1[L].Substring(1); else D2 = Global.PMax[L];

                        if (Global.GenData[L] != null) InVal = Convert.ToDouble(Global.GenData[L]); else InVal = 0.0;
                        Global.StrAlarm = "";
                        if (((A1 == "O") && (InVal <= Convert.ToDouble(A2))) || ((D1 == "O") && (InVal >= Convert.ToDouble(D2))))
                        {
                            Global.Flg_AList = true;
                            if (Global.Flg_AList == true)
                            {
                                Global.arrLim[L] = "O : " + Global.PSName[L] + " ";
                                Global.BufLim[L] = "O";
                                Global.Create_OnLog("IGNITION OFF  : " + Global.PSName[L], "Normal");
                                Global.StrAlarm = Global.StrAlarm + "  Engine OFF : " + Global.arrLim[L];
                                Global.Create_OnLog("Engine ShutOFF: " + Global.PSName[L] + " : " + InVal, "Normal");
                                Global.flg_ChlLim = true;
                                return;
                            }
                        }
                        else if (((A1 == "I") && (InVal < Convert.ToDouble(A2))) || ((D1 == "I") && (InVal > Convert.ToDouble(D2))))
                        {
                            Global.Flg_AList = true;

                            if (Global.LimNo[L] <= 2)
                            {
                                Global.LimNo[L] += 1;
                            }
                            if (Global.LimNo[L] > 2)
                            {
                                if ((Global.Flg_AList == true) && (Global.BufLim[L] != "I"))
                                {
                                    Global.arrLim[L] = "I:" + Global.PSName[L] + " ";
                                    Global.BufLim[L] = "I";
                                    Global.StrAlarm = Global.StrAlarm + " Engine @ Idle " + " : " + InVal;
                                    Global.Create_OnLog("Engine @ Idle: " + Global.PSName[L] + " : " + InVal, "Normal");
                                    Global.flg_ChlLim = true;
                                }
                            }
                            return;
                        }
                        else if (((B1 == "A") && (InVal < double.Parse(B2))) || ((C1 == "A") && (InVal > Double.Parse(C2))))
                        {
                            if ((Global.BufLim[L] != "A") && ((InVal < double.Parse(B2)) || ((C1 == "A") && (InVal > Double.Parse(C2)))))
                            {
                                Global.arrLim[L] = "A : " + Global.PSName[L] + " ";
                                Global.Create_OnLog("Alarm  : " + Global.PSName[L], "Normal");
                                Global.StrAlarm = Global.StrAlarm + "A : " + Global.PSName[L];
                                Global.BufLim[L] = "A";
                                Global.Flg_AList = true;
                            }
                        }
                        else
                        {
                            Global.BufLim[L] = "N";
                        }
                    }
                }
                for (int k = 0; k <= 95; k++)
                {
                    Global.StrAlarm = Global.StrAlarm + Global.arrLim[k];
                }
            }
            catch (Exception ex)
            {
                Global.Create_OnLog("Error Check_Limit :" + L + " : " + InVal, "Normal");
            }
        }

//***********************************
       
//************************************
    }
    }

