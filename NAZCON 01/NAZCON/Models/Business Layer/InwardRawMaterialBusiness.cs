using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAZCON.Models.Business_Layer
{
    public class InwardRawMaterialBusiness
    {
        public InwardRawMaterial irm { get; set; }
       
        public void AddInwardRawMaterial()
        {
            SqlCommand sc = new SqlCommand("AddInwardRawMaterial", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@date", irm.date);
            sc.Parameters.AddWithValue("@quantity", irm.Quantity);
            sc.Parameters.AddWithValue("@rawmaterial", irm.RawMaterialId);
            sc.Parameters.AddWithValue("@refno", irm.ReferenceNo);
            sc.Parameters.AddWithValue("@remarks", irm.Remarks);
            sc.Parameters.AddWithValue("@timein", irm.TimeIn);
            sc.Parameters.AddWithValue("@vehicle", irm.Vehicle);
            sc.Parameters.AddWithValue("@vendor", irm.VendorId);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public List<InwardRawMaterial> ShowInwardRawMaterial()
        {
            List<InwardRawMaterial> list = new List<InwardRawMaterial>();
            SqlCommand sc = new SqlCommand("ShowAllInwardRawMaterial", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                irm = new InwardRawMaterial();
                irm.date = Convert.ToDateTime(sdr["date"]);
                irm.Quantity = Convert.ToDouble(sdr["Quantity"]);
                irm.RawMaterialName = sdr["RMName"].ToString();
                irm.ReferenceNo = Convert.ToInt32(sdr["ReferenceNo"]);
                irm.Remarks = sdr["Remarks"].ToString();
                irm.TimeIn = sdr["TimeIn"].ToString();
                irm.Vehicle = sdr["Vehicle"].ToString();
                irm.VendorName = sdr["Vendor_name"].ToString();
                irm.InwardId = Convert.ToInt32(sdr["InwardId"]);
                list.Add(irm);
            }
            sdr.Close();
            return list;
        }

        public InwardRawMaterial getinwardbyid(int id)
        {
            irm = new InwardRawMaterial();
            SqlCommand sc = new SqlCommand("GetInwardById", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id",id);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                irm.date = Convert.ToDateTime(sdr["date"]);
                irm.Quantity = Convert.ToDouble(sdr["Quantity"]);
                irm.RawMaterialId = Convert.ToInt32(sdr["RawMaterialId"]);
                irm.ReferenceNo = Convert.ToInt32(sdr["ReferenceNo"]);
                irm.Remarks = sdr["Remarks"].ToString();
                irm.TimeIn = sdr["TimeIn"].ToString();
                irm.Vehicle = sdr["Vehicle"].ToString();
                irm.VendorId = Convert.ToInt32(sdr["VendorId"]);
                irm.InwardId = Convert.ToInt32(sdr["InwardId"]);

            }
            sdr.Close();
            return irm;
        }
        public void UpdateInward()
        {
            SqlCommand sc = new SqlCommand("UpdateInwardRawMaterial", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@date", irm.date);
            sc.Parameters.AddWithValue("@id", irm.InwardId);
            sc.Parameters.AddWithValue("@quantity", irm.Quantity);
            sc.Parameters.AddWithValue("@rawmaterial", irm.RawMaterialId);
            sc.Parameters.AddWithValue("@reference", irm.ReferenceNo);
            sc.Parameters.AddWithValue("@remarks", irm.Remarks);
            sc.Parameters.AddWithValue("@timein", irm.TimeIn);
            sc.Parameters.AddWithValue("@vehicle", irm.Vehicle);
            sc.Parameters.AddWithValue("@Vendor", irm.VendorId);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }
    }
}