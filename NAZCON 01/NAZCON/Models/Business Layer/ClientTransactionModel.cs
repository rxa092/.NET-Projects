using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using NAZCON.Models.EntityModel;

namespace NAZCON.Models.Business_Layer
{
    public class ClientTransactionModel
    {
      public  ClientTransaction ct = new ClientTransaction();
        public void add()
        {
            
            SqlCommand sc = new SqlCommand("ClientPayments", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id",ct.clientid);
            sc.Parameters.AddWithValue("@date", ct.date);
            sc.Parameters.AddWithValue("@amount", ct.amount);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public List<ClientTransaction> show()
        {
            List<ClientTransaction> list = new List<ClientTransaction>();
            
            SqlCommand sc = new SqlCommand("ViewClientPayments", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                ClientTransaction ct = new ClientTransaction();
                ct.amount = Convert.ToDouble(sdr["Recieved"]);
                ct.date = Convert.ToDateTime(sdr["Date"]);
                ct.name = sdr["ClientName"].ToString();
                ct.account = Convert.ToDouble(sdr["CurrentBalance"]);
                list.Add(ct);
            }
            sdr.Close();
            return list;
        }

        

    }
}