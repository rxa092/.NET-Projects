using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NAZCON.Models.EntityModel;
using System.Data.SqlClient;
using System.Data;

namespace NAZCON.Models.Business_Layer
{
    public class LocationBusiness
    {

        Location location { get; set; }
        public void AddLocation()
        {
            SqlCommand sc = new SqlCommand("", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("", location.LocationName);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public void UpdateLocation()
        { }

        public List<Location> Show()
        {
            List<Location> list = new List<Location>();
            return list;
        }

        public Location GetLocationById()
        {
            return location;
        }

        public void DeleteLocation()
        {

        }
    }
}