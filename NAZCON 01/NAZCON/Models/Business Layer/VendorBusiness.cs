using Microsoft.ReportingServices.DataProcessing;
using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAZCON.Models.Business_Layer
{
    public class VendorBusiness
    {
        public void add(VendorModel vm)
        {
            SqlCommand sc = new SqlCommand("CreateVendor", connection.getcon());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@name", vm.name);
            sc.Parameters.AddWithValue("@nic", vm.nic);
            sc.Parameters.AddWithValue("@address", vm.address);
            sc.Parameters.AddWithValue("@cell", vm.cellno);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();

        }

        public void update (VendorModel vm)
        {
            SqlCommand sc = new SqlCommand("UpdateVendor", connection.getcon());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", vm.id);
            sc.Parameters.AddWithValue("@name", vm.name);
            sc.Parameters.AddWithValue("@nic", vm.nic);
            sc.Parameters.AddWithValue("@address", vm.address);
            sc.Parameters.AddWithValue("@cell", vm.cellno);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public void delete(int vm)
        {
            SqlCommand sc = new SqlCommand("DeleteVendor", connection.getcon());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", vm);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public List<VendorModel> show()
        {
            List<VendorModel> list = new List<VendorModel>();
            SqlCommand sc = new SqlCommand("ShowVendor", connection.getcon());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                VendorModel vm = new VendorModel();
                vm.id = Convert.ToInt32(sdr["Vendor_id"]);
                vm.name = sdr["Vendor_name"].ToString();
                vm.cellno = (sdr["cell_no"]).ToString();
                vm.address = sdr["address"].ToString();
                vm.nic = sdr["nic"].ToString();
                list.Add(vm);
            }
            sdr.Close();
            return list;
        }

        public List<VendorModel> Vendorlist()
        {
            List<VendorModel> list = new List<VendorModel>();
            SqlCommand sc = new SqlCommand("ShowVendorName", connection.getcon());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                VendorModel vm = new VendorModel();
                vm.id = Convert.ToInt32(sdr["Vendor_id"]);
                vm.name = sdr["Vendor_name"].ToString();
                list.Add(vm);
            }
            sdr.Close();
            return list;
        }

        public VendorModel GetVendor(int id)
        {
            VendorModel vm = new VendorModel();
            SqlCommand sc = new SqlCommand("GetVendor" ,connection.getcon());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                vm.name = sdr["Vendor_name"].ToString();
                vm.nic = sdr["nic"].ToString();
                vm.cellno = (sdr["cell_no"]).ToString();
                vm.address = sdr["address"].ToString();
            }
            sdr.Close();
            return vm;
        }
    }
}