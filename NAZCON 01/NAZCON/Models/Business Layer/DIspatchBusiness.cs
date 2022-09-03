using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAZCON.Models.Business_Layer
{
    public class DIspatchBusiness
    {
        public DispatchReport dp { get; set; }

        public void AddDispatch()
        {
            SqlCommand sc = new SqlCommand("AddDispatchReport", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@amount",dp.Amount);
            sc.Parameters.AddWithValue("@clientId", dp.ClientId);
            sc.Parameters.AddWithValue("@c_p", dp.cube_pallet);
            sc.Parameters.AddWithValue("@date", dp.Date);
            sc.Parameters.AddWithValue("@dc", dp.DC);
            sc.Parameters.AddWithValue("@do", dp.DO);
            sc.Parameters.AddWithValue("@po", dp.PO);
            sc.Parameters.AddWithValue("@product", dp.ProductId);
            sc.Parameters.AddWithValue("@quantity", dp.Quantity);
            sc.Parameters.AddWithValue("@rate", dp.Rate);
            sc.Parameters.AddWithValue("@remarks", dp.Remarks);
            sc.Parameters.AddWithValue("@truck", dp.Truck);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public List<DispatchReport> ShowDispatch()
        {
            SqlCommand sc = new SqlCommand("ShowDispatchRwport", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            List<DispatchReport> list = new List<DispatchReport>();
            while (sdr.Read())
            {
                dp = new DispatchReport();
                dp.Amount = Convert.ToDouble(sdr["Amount"]);
                dp.ClientName = sdr["ClientName"].ToString();
                dp.cube_pallet = Convert.ToInt32(sdr["Cube_Pallets"]);
                dp.Date = Convert.ToDateTime(sdr["Date"]);
                dp.DC = Convert.ToInt32(sdr["DC"]);
                dp.DO = Convert.ToInt32(sdr["DO"]);
                dp.PO = Convert.ToString(sdr["PO"]);
                dp.ProductName = sdr["Description"].ToString();
                dp.Quantity = Convert.ToInt32(sdr["Quantity"]);
                dp.Rate = Convert.ToDouble(sdr["Rate"]);
                dp.Remarks = sdr["Remarks"].ToString();
                dp.Truck = sdr["Truck"].ToString();
                dp.DispatchId = Convert.ToInt32(sdr["DispatchId"]);
                list.Add(dp);
            }
            sdr.Close();
            return list;
        }

        public void UpdateDispatch()
        {
            SqlCommand sc = new SqlCommand("UpdateDispatchReport", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("", dp.Amount);
            sc.Parameters.AddWithValue("", dp.ClientId);
            sc.Parameters.AddWithValue("", dp.cube_pallet);
            sc.Parameters.AddWithValue("", dp.Date);
            sc.Parameters.AddWithValue("", dp.DC);
            sc.Parameters.AddWithValue("", dp.DO);
            sc.Parameters.AddWithValue("", dp.PO);
            sc.Parameters.AddWithValue("", dp.ProductId);
            sc.Parameters.AddWithValue("", dp.Quantity);
            sc.Parameters.AddWithValue("", dp.Rate);
            sc.Parameters.AddWithValue("", dp.Remarks);
            sc.Parameters.AddWithValue("", dp.Truck);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();

        }

        public List<DispatchReport> GetDispatchById(int id)
        {
            SqlCommand sc = new SqlCommand("ShowDispatchRwport", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sc.ExecuteReader();
            List<DispatchReport> list = new List<DispatchReport>();
            while (sdr.Read())
            {
                dp = new DispatchReport();
                dp.Amount = Convert.ToDouble(sdr["Amount"]);
                dp.ClientName = sdr["ClientName"].ToString();
                dp.cube_pallet = Convert.ToInt32(sdr["Cube_Pallets"]);
                dp.Date = Convert.ToDateTime(sdr["Date"]);
                dp.DC = Convert.ToInt32(sdr["DC"]);
                dp.DO = Convert.ToInt32(sdr["DO"]);
                dp.PO = Convert.ToString(sdr["PO"]);
                dp.ProductName = sdr["Description"].ToString();
                dp.Quantity = Convert.ToInt32(sdr["Quantity"]);
                dp.Rate = Convert.ToDouble(sdr["Rate"]);
                dp.Remarks = sdr["Remarks"].ToString();
                dp.Truck = sdr["Truck"].ToString();
                dp.DispatchId = Convert.ToInt32(sdr["DispatchId"]);
                list.Add(dp);
            }
            sdr.Close();
            return list;
        }

        public void DeleteDispatch(int id)
        {
            SqlCommand sc = new SqlCommand("", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public List<DispatchReport> SpecialDispatch(DateTime start, DateTime end , int client , int product)
        {
            List<DispatchReport> lis = new List<DispatchReport>();
            SqlCommand sc = new SqlCommand("DispatchForCEO", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@start", start);
            sc.Parameters.AddWithValue("@end", end);
            sc.Parameters.AddWithValue("@client", client);
            sc.Parameters.AddWithValue("@product", product);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                dp = new DispatchReport();
                dp.Amount = Convert.ToDouble(sdr["Amount"]);
                dp.ClientName = sdr["ClientName"].ToString();
                dp.cube_pallet = Convert.ToInt32(sdr["Cube_Pallets"]);
                dp.Date = Convert.ToDateTime(sdr["Date"]);
                dp.DC = Convert.ToInt32(sdr["DC"]);
                dp.DO = Convert.ToInt32(sdr["DO"]);
                dp.PO = Convert.ToString(sdr["PO"]);
                dp.ProductName = sdr["Description"].ToString();
                dp.Quantity = Convert.ToInt32(sdr["Quantity"]);
                dp.Rate = Convert.ToDouble(sdr["Rate"]);
                dp.Remarks = sdr["Remarks"].ToString();
                dp.Truck = sdr["Truck"].ToString();
                dp.DispatchId = Convert.ToInt32(sdr["DispatchId"]);
                lis.Add(dp);
            }
            sdr.Close();
                return lis;
        }
    }
}