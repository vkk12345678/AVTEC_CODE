using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Logger
{
    class RdAdam
    {
        public static String[] PNo = new String[130];
        public static String[] PName = new String[130];
        public static String[] PSName = new String[130];
        public static String[] GenData = new String[130];
        public static String[] PMin = new String[130];
        public static String[] PMax = new String[130];
        public static Int16 ADAMCnt = 1;
        public static Int16 ChnCnt = -1;
        public static string bufftss8;
        public static String MD1, MD2, MD3, MD4, MD5, MD6;
        public static Int16 T = 21;
        public static Int16 U = 29;
        public static Int16 V = 37;
        public static Int16 W = 45;
        public static Int16 X = 53;
        public static Int16 Y = 61;
        public static int dx1 = 21;
        public static int dx2 = 29;
        public static int dx3= 36;
        public static int dx4= 44;
        public static int dx5 = 52;
        public static string AdamBuf;
        public static Boolean Er_ADAM = false;

        public static string admCount = "0";


        public static SerialPort adPort = new SerialPort();
        public static String Buf;
       
        public static int b;
        public static double[] arr = new double[5];
        public static String[] array1 = new String[30];
    
        public static int x=0;
          public static int a=0;
        public static void Init_adPort(string com, int bud, int datab, Parity p, StopBits stpb)
        {
            try
            {
                adPort.PortName = com;
                if (adPort.IsOpen == true) adPort.Dispose();
                adPort.BaudRate = bud;
                adPort.DataBits = datab;
                adPort.Parity = p;
                adPort.StopBits = stpb;
                if (adPort.IsOpen == false)
                {
                    adPort.Dispose();
                    adPort.PortName = com;
                    Er_ADAM = true;
                    adPort.Open();
                    
                }
            }
            catch
            {
                Er_ADAM = false;
                return;
            }
        }
        public static string Read_Module(string add, int StrtAdd)
        {

            try
            {
                adPort.Write("#" + add + "\r");
                string buf1 = (adPort.ReadExisting());

                return buf1;
              
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        public static void Transfer_Adam()
        {
            try
            {
                string Buff = "";
                string Buff1 = "";
                string Buff2 = "";
                string Buff3 = "";
                string Buff4 = "";
                string InPut = "";

                if (x >= 4) x = 1;
                else
                {
                    x++;
                    a = 1;
                    //    x=1;
                    if (x == 1)
                    {
                        
                        Buff = Read_Module(x.ToString("00"), a);
                        Er_ADAM = true;
                        if (!string.IsNullOrEmpty(Buff))
                        {
                            //AdamBuf = string.Empty;
                            if (Buff != "")
                                InPut = Buff.Substring(2, Buff.Length - 3);
                            AdamBuf = InPut;
                            char[] delimeterChar = { '+', '-' };
                            string[] words1 = InPut.Split(delimeterChar);
                           
                            for (int i = 0; i <= 7; i++)
                            {
                                double val3 = Double.Parse(words1[i]);
                                if ((val3 >= Double.Parse(Global.PMin[i + 37])) && (val3 <= Double.Parse(Global.PMax[i + 37])))
                                {
                                    Global.GenData[i + 37] = val3.ToString();
                               } 
                            }
                           
                        }
                    }
                    else if (x == 2)
                    {
                        int var1 = 21;
                        
                        Buff1 = Read_Module(x.ToString("00"), a);

                        if (!string.IsNullOrEmpty(Buff1))
                        {
                            Er_ADAM = true;
                            if (Buff1 != "")
                                InPut = Buff1.Substring(2, Buff1.Length - 3);
                            AdamBuf = InPut;
                            char[] delimeterChar = { '+', '-' };
                            string[] words2 = InPut.Split(delimeterChar);

                            List<string> l1 = new List<string>();

                            l1.Add(words2[0]);
                            l1.Add(words2[1]);
                            l1.Add(words2[2]);
                            l1.Add(words2[3]);
                            l1.Add(words2[4]);
                            l1.Add(words2[5]);
                            l1.Add(words2[6]);
                            l1.Add(words2[7]);

                            while ((var1 >= RdAdam.dx1) && (var1 <= RdAdam.dx1 + 7))
                            {
                                if (RdAdam.PSName[a] != "Not_Prog")
                                {
                                   
                                    Double Temp = ((Double.Parse(Global.PMax[var1]) - Double.Parse(Global.PMin[var1])) / 16);
                                    double val=(((Double.Parse(l1[0]) - 4) * Temp) + Double.Parse(Global.PMin[var1]));

                                    //if ((val >= Double.Parse(Global.PMin[var1])) && (val <= Double.Parse(Global.PMax[var1])))
                                    //{
                                        Global.GenData[var1]=val.ToString("000.000");
                                   // }
                                   
                                }
                                var1++;
                            }

                           
                         
                        }
                    }
                    else if (x == 3)
                    {
                        Er_ADAM = true;
                        Buff2 = Read_Module(x.ToString("00"), a);

                        if (!string.IsNullOrEmpty(Buff2))
                        {
                            if (Buff2 != "")
                                InPut = Buff2.Substring(2, Buff2.Length - 3);
                            AdamBuf = InPut;
                            char[] delimeterChar = { '+', '-' };
                            string[] words3 = InPut.Split(delimeterChar);

                            for (int i = 0; i <= 7; i++)
                            {
                                double val2 = Double.Parse(words3[i]);
                                if ((val2 >= Double.Parse(Global.PMin[i + 29])) && (val2 <= Double.Parse(Global.PMax[i+29])))
                                {
                                    Global.GenData[i+29] = val2.ToString();
                                }
                                //Global.GenData[i+28] = words3[i];
                              
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Er_ADAM = false;
                return;
            }
        }
                 
    
    }
    }


