using NAZCON.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAZCON.Models.Business_Layer
{
    public class DoBussiness
    {
        public List<DoModel> Do_show()
        {
            List<DoModel> show = new List<DoModel>();

            SqlCommand sc = new SqlCommand("ViewDo", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                DoModel Do = new DoModel();
                Do.Item_Description = sdr["Description"].ToString();
                Do.Client = sdr["ClientName"].ToString();
                Do.Destination = sdr["destination"].ToString();
                Do.Created_by = sdr["created"].ToString();
                Do.Date = sdr["Date"].ToString();
                
                Do.Quantity = Convert.ToInt32(sdr["quantity"]);
                Do.Do_number = Convert.ToInt32(sdr["DONO"]);

                show.Add(Do);
            }
            sdr.Close();

            return show;
        }


        public List<DoModel> show_all()
        {
            List<DoModel> show = new List<DoModel>();

            SqlCommand sc = new SqlCommand("ShowAllDo", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                DoModel Do = new DoModel();
                Do.Item_Description = sdr["Description"].ToString();
                Do.Client = sdr["ClientName"].ToString();
                Do.Destination = sdr["destination"].ToString();
                Do.Created_by = sdr["created"].ToString();
                Do.Date = sdr["Date"].ToString();

                Do.Quantity = Convert.ToInt32(sdr["quantity"]);
                Do.Do_number = Convert.ToInt32(sdr["DONO"]);
                Do.remaining = Convert.ToInt32(sdr["remaining"]);
                Do.sono = Convert.ToInt32(sdr["SONO"]);
                show.Add(Do);
            }
            sdr.Close();

            return show;
        }

        public void delete(int id)
        {
            SqlCommand sc = new SqlCommand("Delete_do", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);  
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public void Create_Do(int x)
        {
            SqlCommand sc = new SqlCommand("Add_Do", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@Date", DateTime.Now.Date);
            sc.Parameters.AddWithValue("@so", x);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

    }
}
