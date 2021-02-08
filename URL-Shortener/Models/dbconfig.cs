using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace URL_Shortener.Models
{
    public class dbconfig
    {
        private SqlConnection con;
        public dbconfig()
        {
        }

        //hapje e lidhjes me databaze
        private void connect()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            con.Open();
        }

        //mbyllja e lidhjes me databaze
        private void close()
        {
            con.Close();
        }

        //egzekuton "SELECT" ne databaze dhe kthen te dhena nga databaza
        public DataSet querySelect(String requete, Dictionary<string, object> param)
        {
            connect();
            SqlCommand sc = new SqlCommand(requete, con);
            if (param != null)
            {
                foreach (KeyValuePair<string, object> entry in param)
                    sc.Parameters.AddWithValue(entry.Key, entry.Value);
            }
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            close();
            return ds;
        }

        //ben update rekordin aktual ne databaze
        public void queryUpdate(String requete, Dictionary<string, object> param)
        {
            connect();
            SqlCommand sc = new SqlCommand(requete, con);
            if (param != null)
            {
                foreach (KeyValuePair<string, object> entry in param)
                    sc.Parameters.AddWithValue(entry.Key, entry.Value);
            }
            sc.ExecuteNonQuery();
            close();
        }
    }
}