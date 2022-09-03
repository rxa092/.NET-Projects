using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAZCON
{
    public class connection
    {
        public static SqlConnection con;
        public static SqlDataReader sdr;
        public static SqlConnection getcon()
        {
            if (con == null)
            {
                con = new SqlConnection();
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnection"].ToString();
                con.Open();
            }

            return con;
        }
    }
}