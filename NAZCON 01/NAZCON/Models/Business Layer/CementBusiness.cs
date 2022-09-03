using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using NAZCON.Models.ViewModel;

namespace NAZCON.Models.Business_Layer
{
    public class CementBusiness
    {
        public CementModel cm { get; set; } 
        public void AddCement()
        {
            SqlCommand sc = new SqlCommand("CreateCement", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@plantlocation", cm.PlantLocation);
            sc.Parameters.AddWithValue("@quality", cm.Quality);
            sc.Parameters.AddWithValue("@silo", cm.Silo);
            sc.Parameters.AddWithValue("@inward", cm.inwardid);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public void UpdateCement()
        {
            SqlCommand sc = new SqlCommand("UpdateCement", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@plantlocation", cm.PlantLocation);
            sc.Parameters.AddWithValue("@quality", cm.Quality);
            sc.Parameters.AddWithValue("@silo", cm.Silo);
            sc.Parameters.AddWithValue("@bulker", cm.Bulker);
            sc.Parameters.AddWithValue("@date", cm.date);
            sc.Parameters.AddWithValue("@quantity", cm.Quantity);
            sc.Parameters.AddWithValue("@supplier", cm.SupplierId);
            sc.Parameters.AddWithValue("@id", cm.id);
            sc.Parameters.AddWithValue("@inward", cm.inwardid);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public void DeleteCement(int id)
        {
            SqlCommand sc = new SqlCommand("DeleteCement", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public List<CementModel> ShowCement()
        {
            List<CementModel> lis = new List<CementModel>();
            SqlCommand sc = new SqlCommand("ShowCement", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                cm = new CementModel();
                cm.Bulker = sdr["Vehicle"].ToString();
                cm.date = Convert.ToDateTime(sdr["date"]);
                cm.id = Convert.ToInt32(sdr["CementId"]);
                cm.inwardid = Convert.ToInt32(sdr["InwardId"]);
                cm.PlantLocation = sdr["PlantLocation"].ToString();
                cm.Quality = sdr["Quality"].ToString();
                cm.Quantity = Convert.ToDouble(sdr["Quantity"]);
                cm.Silo = Convert.ToInt32(sdr["Silo"]);
                cm.Supplier = sdr["Vendor_name"].ToString();
                lis.Add(cm);
            }
            sdr.Close();
             return lis;
        }

        public CementModel GetCementById(int id)
        {
            SqlCommand sc = new SqlCommand("ShowCementById", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                cm = new CementModel();
                cm.Bulker = sdr["Vehicle"].ToString();
                cm.date = Convert.ToDateTime(sdr["date"]);
                cm.id = Convert.ToInt32(sdr["CementId"]);
                cm.inwardid = Convert.ToInt32(sdr["InwardId"]);
                cm.PlantLocation = sdr["PlantLocation"].ToString();
                cm.Quality = sdr["Quality"].ToString();
                cm.Quantity = Convert.ToDouble(sdr["Quantity"]);
                cm.Silo = Convert.ToInt32(sdr["Silo"]);
                cm.Supplier = sdr["Vendor_name"].ToString();
            }
            sdr.Close();
            return cm;
        }

        public List<CementModel> CementQuality()
        {
            List<CementModel> cm = new List<CementModel>();
            CementModel cm1 = new CementModel();
            cm1.Quality = "SRC";
            CementModel cm2 = new CementModel();
            cm2.Quality = "OPC";
            cm.Add(cm1);
            cm.Add(cm2);
            return cm;
        }

        
    }
}