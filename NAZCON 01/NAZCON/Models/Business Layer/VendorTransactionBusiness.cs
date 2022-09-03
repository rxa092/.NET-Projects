using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAZCON.Models.Business_Layer
{
    public class VendorTransactionBusiness
    {
        public void add(VendorTransactionModel vm)
        {
            SqlCommand sc = new SqlCommand("AddVendorTransaction", connection.getcon());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id",vm.vid);
            sc.Parameters.AddWithValue("@qty", vm.quantity);
            sc.Parameters.AddWithValue("@product", vm.product);
            sc.Parameters.AddWithValue("@amount", vm.amount);
            sc.Parameters.AddWithValue("@date", vm.date);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public List<VendorTransactionModel> Vendorlist()
        {
            List<VendorTransactionModel> list = new List<VendorTransactionModel>();
            SqlCommand sc = new SqlCommand("ShowVendorName", connection.getcon());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                VendorTransactionModel vm = new VendorTransactionModel();
                vm.vid = Convert.ToInt32(sdr["Vendor_id"]);
                vm.vname = sdr["Vendor_name"].ToString();
                list.Add(vm);
            }
            sdr.Close();
            return list;
        }

        public List<VendorTransactionModel> show()
        {
            List<VendorTransactionModel> list = new List<VendorTransactionModel>();
            SqlCommand sc = new SqlCommand("Showvendortransaction", connection.getcon());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                VendorTransactionModel vm = new VendorTransactionModel();
                vm.amount = Convert.ToDouble(sdr["amount"]);
                vm.product = sdr["product"].ToString();
                vm.quantity = Convert.ToInt32(sdr["qty"]);
                vm.vname = sdr["Vendor_name"].ToString();
                vm.date = Convert.ToDateTime(sdr["date"]);
                list.Add(vm);
            }
            sdr.Close();
            return list;
        }
    }
}