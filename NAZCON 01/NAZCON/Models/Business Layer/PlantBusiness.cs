using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAZCON.Models.Business_Layer
{
    public class PlantBusiness
    {
        public List<PlantModel> AllPlants()
        {
            List<PlantModel> lis = new List<PlantModel>();
            SqlCommand sc = new SqlCommand("ShowPlants", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                PlantModel p = new PlantModel();
                p.id = Convert.ToInt32(sdr["PlantId"]);
                p.Name = sdr["PlantName"].ToString();
                lis.Add(p);
            }
            sdr.Close();
            return lis;
        }
    }
}