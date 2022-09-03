using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAZCON.Models.Business_Layer
{
    public class StoretransactionBusiness
    {
        public StoreTransaction st { get; set; }



        public void AddTransaction()
        {
            SqlCommand sc = new SqlCommand("", connection.getcon());
            if (st.type.ToLower() == "in")
            {
                 sc = new SqlCommand("AddstoreTransaction1", connection.getcon());
            }
            else if(st.type.ToLower()=="out")
            {
                sc = new SqlCommand("AddstoreTransaction2", connection.getcon());
            }
                sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@date", st.date);
            sc.Parameters.AddWithValue("@employee", st.employee);
            sc.Parameters.AddWithValue("@item", st.item);
            sc.Parameters.AddWithValue("@quantity", st.quantity);
            sc.Parameters.AddWithValue("@type", st.type);
            sc.Parameters.AddWithValue("@reference", st.Reference);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public List<StoreTransaction> AllStoreTransaction()
        {
            List<StoreTransaction> ls = new List<StoreTransaction>();
            SqlCommand sc = new SqlCommand("ShowStoreTransaction", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                StoreTransaction st = new StoreTransaction();
                st.balance = Convert.ToInt32(sdr["Balance"]);
                st.date = sdr["Date"].ToString();
                st.employeename = (sdr["Name"]).ToString();
                st.itemname = (sdr["Item"]).ToString();
                st.quantity=Convert.ToInt32(sdr["Quantity"]);
                st.type = sdr["Type"].ToString();
                st.id = Convert.ToInt32(sdr["TransId"]);
                st.LocationName = sdr["Location"].ToString();
                st.CategoryName = sdr["Category"].ToString();
                st.Reference = (int)sdr["Reference"];
                ls.Add(st);
            }
            sdr.Close();
            return ls;
        }


    }
}