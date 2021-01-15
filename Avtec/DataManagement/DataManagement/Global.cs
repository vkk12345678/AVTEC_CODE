using System;
using System.Data; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;   
using System.Data.OleDb;
using System.Globalization; 
using System.IO.Ports ;
using MySql.Data.MySqlClient;
using System.IO;

 
namespace DataManagement    //WindowsFormsApplication1
{
    public class Global
    {
        public static string PATH = Application.StartupPath + "\\";
        public static string HelpPATH = "C:\\Windows\\Help\\DynalecHelp\\";
        public static string Data_Dir;
        public static string DataPath;
        public static string MySqlPW;
        public static MySqlConnection  con = new MySqlConnection();
        public static MySqlConnection conLim = new MySqlConnection();
        public static MySqlConnection conSeq = new MySqlConnection();
        public static MySqlConnection conData = new MySqlConnection();
        public static MySqlConnection conMES = new MySqlConnection();
        public static MySqlConnection conLog = new MySqlConnection();       
        public static String[] GenData = new String[130];
        public static String[] GenPara = new String[20];

        public static Boolean flg_HDdata = true;
        public static String[] sysIn = new String[80];
        public static string T_CellNo;





        //public static void Rd_Pwd()
        //{
                        
        //    //File.SetAttributes(path, FileAttributes.Normal);
        //    FileStream fs2 = new FileStream("C:\\edac.ini", FileMode.Open,FileAccess.Read); // , FileAccess.ReadWrite);
        //    StreamReader reader = new StreamReader(fs2);
        //    String InPut = reader.ReadToEnd();
        //    int pos1 = 1;
        //    int pos2 = 1;
        //    pos1 = InPut.IndexOf("@", 0);
        //    pos2 = InPut.IndexOf("@", (pos1 + 1));
        //    MySqlPW = InPut.Substring(pos1 + 1, (pos2 - pos1 - 1));
             
        //    //File.SetAttributes(path, FileAttributes.Hidden);
        //    reader.Close();

        //}

        public static void Open_DataConn(String db, String cNm)
        {
            try
            {

                MySqlConnection cn = new MySqlConnection("server = localhost; user id = root; password = dynalec; database =" + db);
                cn.Open();

                if (cNm == "conData")
                {
                    if (cn.State == System.Data.ConnectionState.Open)
                    {
                        conData.Close();
                        conData = cn;
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15011", ex.Message); 
            }

        }


		public static void Open_Connection(String db, String conNm)
		{
			try
			{
                MySqlConnection conn = new MySqlConnection("server = localhost; user id = root; password =dynalec; database =" + db);

				conn.Open();

				if (conNm == "con")
				{
					if (conn.State == System.Data.ConnectionState.Open)
					{
						con.Close();
						con = conn;
					}
				}
				if (conNm == "conLim")
				{
					if (conn.State == System.Data.ConnectionState.Open)
					{
						conLim.Close();
						conLim = conn;
					}
				}
				if (conNm == "conSeq")
				{
					if (conn.State == System.Data.ConnectionState.Open)
					{
						conSeq.Close();
						conSeq = conn;
					}
				}
				if (conNm == "conMES")
				{
					if (conn.State == System.Data.ConnectionState.Open)
					{
						conMES.Close();
						conMES = conn;
					}
				}


			}
			catch (Exception ex)
			{
				MessageBox.Show("Error Code:- 15008", ex.Message);
			}

		}

		

		public static void Open_LogConn(String db, String cNm)
		{
			try
			{
              //  MySqlConnection cn = new MySqlConnection("server = localhost; user id = root; password = dcpl; database =" + db);
                MySqlConnection cn = new MySqlConnection("server = localhost; user id = root; password = dynalec; database =" + db);
				cn.Open();

				if (cNm == "conLog")
				{
					if (cn.State == System.Data.ConnectionState.Open)
					{
						conLog.Close();
						conLog = cn;
					}
				}
			}
			catch (Exception ex)
			{
				return;
			
			}
		}
		

		

		
              public static void Rd_System()
        {
            try
            {
                Open_Connection ("gen_db", "con");
				MySqlCommand cmd = new MySqlCommand("SELECT * FROM TbSys WHERE FileName = '08_SystemPara'", con);
				MySqlDataReader Rd = cmd.ExecuteReader();
                Int16 x = 0;
                while (Rd.Read())
                {
                    for (x = 0; x <= (Rd.FieldCount - 1); x++)
                    {
                        sysIn[x] = Rd.GetValue(x).ToString();
                    }
                }
                Global.con.Close();   
                    //MD1 = sysIn[22];
                    //MD2 = sysIn[25];
                    //MD3 = sysIn[28];
                    //MD4 = sysIn[31];
                    //MD5 = sysIn[34];
                    //if (sysIn[16] == "TRUE") flg_VolActive = 1; else flg_VolActive = 0;
                    //flg_rdMod = Convert.ToBoolean(sysIn[61]);
                    //flg_LoginRPM = Convert.ToBoolean(sysIn[64]);
                    //flg_RecorsPmData = Convert.ToBoolean(sysIn[15]);
                    //flg_simulateRPM = Convert.ToBoolean(sysIn[65]);
                    T_CellNo = sysIn[9];
                    Data_Dir = DateTime.Now.ToString("MMMyy");
                    DataPath = "D:\\TestCell_" + T_CellNo + "\\" + Data_Dir + "\\";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15014", ex.Message); 
            }
        }
        public static DateTime DelayMs(int nMs)
        {
            try
            {

                System.DateTime ThisMoment = System.DateTime.Now;
                System.TimeSpan duration = new System.TimeSpan(0, 0, 0, 0, nMs);
                System.DateTime AfterWards = ThisMoment.Add(duration);
                while (AfterWards >= ThisMoment)
                {
                    System.Windows.Forms.Application.DoEvents();
                    ThisMoment = System.DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15015", ex.Message);
            }
                return System.DateTime.Now;            
            
        }
        ///////////////////////////////////////////////////////////////////////////////

       public static DateTime DelaySc(int nSeconds)
        {
            try
            {
                System.DateTime ThisMoment = System.DateTime.Now;
                System.TimeSpan duration = new System.TimeSpan(0, 0, 0, nSeconds, 0);
                System.DateTime AfterWards = ThisMoment.Add(duration);
                while (AfterWards >= ThisMoment)
                {
                    System.Windows.Forms.Application.DoEvents();
                    ThisMoment = System.DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Code:- 15016", ex.Message);
            }
                return System.DateTime.Now;           
           
        }     

             //***************** 

    }
    
}
