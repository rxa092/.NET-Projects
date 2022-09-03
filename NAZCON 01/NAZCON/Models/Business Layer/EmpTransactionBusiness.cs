using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using NAZCON.Models.EntityModel;

namespace NAZCON.Models.Business_Layer
{
    public class EmpTransactionBusiness
    {
        public EmpTransaction emp;
        public void add()
        {
          //  EmpTransaction emp = new EmpTransaction();
            SqlCommand sc = new SqlCommand("AddEmpTransaction", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id",emp.empid);
            sc.Parameters.AddWithValue("@description", emp.description);
            sc.Parameters.AddWithValue("@amount", emp.amount);
            sc.Parameters.AddWithValue("@date", emp.date);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
            
        }

        public List<EmpTransaction> show()
        {
            List<EmpTransaction> list = new List<EmpTransaction>();
            SqlCommand sc = new SqlCommand("ShowEmpTran", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                EmpTransaction etran = new EmpTransaction();
                etran.date = Convert.ToDateTime(sdr["Date"]);
                etran.description = sdr["Descrption"].ToString();
                etran.name = sdr["Email"].ToString();
                etran.amount = Convert.ToDouble(sdr["Amount"]);
                list.Add(etran);
            }
            sdr.Close();
            return list;
        }
    }
}