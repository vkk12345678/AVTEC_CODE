

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using Editors_DLL;



namespace Editors_DLL
{
    public class Common
    {
        //public static string PATH = Application.StartupPath + "\\";
        public static MySqlConnection con = new MySqlConnection();
        public static MySqlConnection conLim = new MySqlConnection();
        public static MySqlConnection conSeq = new MySqlConnection();
        public static MySqlConnection conData = new MySqlConnection();
        public static MySqlConnection conMES = new MySqlConnection();
        public static MySqlConnection conLog = new MySqlConnection();
        public static string DataPath;
     


        public static void Open_Connection(String db, String conNm)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection("server = localhost; user id = root; password = dynalec ; database =" + db);    //dcpl

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
                return; // MessageBox.Show("Error Code:- 15008", ex.Message);
            }

        }
        
       
      

        public static void Read_SqlTable(string TbNm, string ColNm, string flNm)
        {
            for (int i = 0; i <= 199; i++) Global.arr[i] = null;
            //Editors_DLL.                .Common.Open_Connection("gen_db", "con");
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM " + TbNm + " where " + ColNm + " = '" + flNm + "'", con);
            MySqlDataReader Rd = cmd.ExecuteReader();


            Int16 x = 0;
            while (Rd.Read())
            {
                for (x = 0; x <= (Rd.FieldCount - 1); x++)
                {
                   Global.arr[x] = Rd.GetValue(x).ToString();
                }
            }
            cmd.Dispose();
            con.Close();
        }

        //*************************Delete tables

        public static void Del_limTable(string str, string Con)
        {
            Open_Connection("lim_db", "conLim");
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = ("Drop table " + str.ToLower().Trim());
            cmd.Connection = conLim;
            cmd.ExecuteNonQuery();
            conLim.Close();
        }

        public static void Del_seqTable(string str, string Con)
        {
            Open_Connection("seq_db", "conSeq");
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = ("Drop table " + str.ToLower().Trim());
            cmd.Connection = conSeq;
            cmd.ExecuteNonQuery();
            conSeq.Close();
        }
        public static void Del_EngRec(string str, string Con)
        {
            Open_Connection("gen_db", "con");
            MySqlCommand cDelete = new MySqlCommand();
            cDelete.CommandText = "DELETE FROM tblEngine WHERE EngineFile ='" + str + "'";
            cDelete.Connection = con;
            cDelete.ExecuteNonQuery();
        }
        //****************************

       

       //***********************Limit File


        public static void Save_Lim_File(string str, string Con)
        {
            try
            {
                Open_Connection("seq_db", "conSeq");
                MySqlCommand cmd = new MySqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'seq_db'", conSeq);
                using (MySqlDataReader reader1 = cmd.ExecuteReader())
                {
                    while (reader1.Read())
                    {
                        if ((string)reader1["TABLE_NAME"] == str.ToLower())
                        {
                            reader1.Close();
                            MySqlCommand cmd1 = new MySqlCommand();
                            cmd1.CommandText = ("Drop table " + str.Trim());
                            cmd1.Connection = conSeq;
                            cmd1.ExecuteNonQuery();
                            cmd1.Dispose();
                            conSeq.Close();
                            break;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                return;  //MessageBox.Show("file Not Saved .......");
            }
        }

      

        public static void Save_Seq_File(string str)
        {
            try
            {
                Open_Connection("seq_db", "conSeq");
                MySqlCommand cmd = new MySqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'seq_db'", conSeq);
                using (MySqlDataReader reader1 = cmd.ExecuteReader())
                {
                    while (reader1.Read())
                    {
                        if ((string)reader1["TABLE_NAME"] == str.ToLower())
                        {
                            reader1.Close();
                            MySqlCommand cmd1 = new MySqlCommand();
                            cmd1.CommandText = ("Drop table " + str.Trim());
                            cmd1.Connection = conSeq;
                            cmd1.ExecuteNonQuery();
                            cmd1.Dispose();
                            conSeq.Close();
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return;  //MessageBox.Show("file Not Saved .......");
            }
        }

        //*****************************Engine File
        



        internal static void Create_OffLog(string p)
        {
            throw new NotImplementedException();
        }

    }
}
