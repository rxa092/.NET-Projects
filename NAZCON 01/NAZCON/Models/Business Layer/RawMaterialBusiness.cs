using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAZCON.Models.Business_Layer
{
    public class RawMaterialBusiness
    {
          public  RawMaterial rm { get; set; }
        public List<RawMaterial> DropDownRawMaterial()
        {   
            List<RawMaterial> list = new List<RawMaterial>();
            SqlCommand sc = new SqlCommand("GetRawMaterial", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                RawMaterial rm = new RawMaterial();
                rm.Id = Convert.ToInt32(sdr["RMId"]);
                rm.Name = sdr["RMName"].ToString();
                list.Add(rm);
            }
            sdr.Close();
            return list;
        }

        public void AddRawmaterial()
        {
            SqlCommand sc = new SqlCommand("AddRawMaterial", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@Name", rm.Name);
            sc.Parameters.AddWithValue("@Quantity", rm.Quantity);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public List<RawMaterial> ShowRawMaterial()
        {
            List<RawMaterial> list = new List<RawMaterial>();
            SqlCommand sc = new SqlCommand("GetRawMaterial", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                RawMaterial rm = new RawMaterial();
                rm.Id = Convert.ToInt32(sdr["RMId"]);
                rm.Name = sdr["RMName"].ToString();
                rm.Quantity = Convert.ToDouble(sdr["RMQuantity"]);
                list.Add(rm);
            }
            sdr.Close();
            return list;
        }

        public RawMaterial GetRawMaterialByid(int id)
        {
            RawMaterial rm = new RawMaterial();
            SqlCommand sc = new SqlCommand("GetRawMaterialById", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@ID", id);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                rm.Name = sdr["RMName"].ToString();

            }
            sdr.Close();
            return rm;
        }

        public void UpdateRawMaterial()
        {
            SqlCommand sc = new SqlCommand("UpdateRawMaterial", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@ID",rm.Id);
            sc.Parameters.AddWithValue("@Name", rm.Name);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public void DeleteRawMaterial(int id)
        {
            SqlCommand sc = new SqlCommand("DeleteRawMaterial", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id ", id);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }
    }
}