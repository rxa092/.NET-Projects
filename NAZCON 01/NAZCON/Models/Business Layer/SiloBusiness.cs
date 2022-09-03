using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAZCON.Models.Business_Layer
{
    public class SiloBusiness
    {
        public List<Silo> AllSilo()
        {
            List<Silo> lis = new List<Silo>();
            SqlCommand sc = new SqlCommand("ShowSilo", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Silo s = new Silo();
                s.SiloId = Convert.ToInt32(sdr["SiloId"]);
                s.SiloNumber = Convert.ToInt32(sdr["SiloNumber"]);
                lis.Add(s);
            }
            sdr.Close();
            return lis;
        }
    }
}