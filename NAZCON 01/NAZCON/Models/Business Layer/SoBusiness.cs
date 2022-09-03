using NAZCON.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace NAZCON.Models.Business_Layer
{
    public class SoBusiness
    {
        public static string UserName { get; set; }
        public SoModel sm { get; set; }
        static double? final = 0;
      
      string name { get; set; }
        List<double> pr;
        
        private void prices()
        {
            pr = new List<double>();
            SqlCommand sc = new SqlCommand("get_price", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                pr.Add(Convert.ToDouble(sdr["price"]));
            }
            sdr.Close();
        }


        public void addso()
        {
            SqlCommand sc = new SqlCommand("so1", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@Date", sm.Date);
            sc.Parameters.AddWithValue("@client", sm.ClientName);
            sc.Parameters.AddWithValue("@destination", sm.destination);
            sc.Parameters.AddWithValue("@pono", sm.po);
            if (sm.remarks == null)
            {
                sc.Parameters.AddWithValue("@remarks", "nothing");
            }
            else
            {
                sc.Parameters.AddWithValue("@remarks", sm.remarks);
            }
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
           
        }

        public void addso2()
        {
            SqlCommand sc = new SqlCommand("so2", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@item_id", sm.Item);
            sc.Parameters.AddWithValue("@quantity", sm.quantity);
            sc.Parameters.AddWithValue("@pallets", sm.pallets);
            // sc.Parameters.AddWithValue("@tax", sm.Tax);
            // sc.Parameters.AddWithValue("@price", sm.Price);
            //  sc.Parameters.AddWithValue("@total", (sm.Price * sm.Item) + sm.Tax);
            prices();
            if (sm.price==null)
            {
                sc.Parameters.AddWithValue("@price", pr[sm.Item-1]);
                sm.price = Convert.ToInt32( pr[sm.Item - 1]);
            }
            else
            {
                sc.Parameters.AddWithValue("@price", sm.price);
            }
            sc.Parameters.AddWithValue("@total", (sm.price * sm.quantity) + (sm.quantity * sm.price * 0.17));
            sc.Parameters.AddWithValue("@tax", (sm.quantity * sm.price * 0.17));
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
            final =final+
                ( (sm.price * sm.quantity) + (sm.quantity * sm.price * 0.17));
            final_amount();
            


        }


        public List<SoModel> item()
        {
            List<SoModel> lis = new List<SoModel>();
            SqlCommand sc = new SqlCommand("getitem", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;

           SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                SoModel s = new SoModel();
                s.Item = Convert.ToInt32(sdr["ItemID"]);
                s.Description = sdr["Description"].ToString();
                lis.Add(s);
            }
            sdr.Close();
            return lis;

        }

        public void final_amount()
        {
            SqlCommand sc = new SqlCommand("final_amount_so", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@amount", final);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public List<SoModel> show_current()
        {
            List<SoModel> take_order = new List<SoModel>();

            SqlCommand sc = new SqlCommand("viewso", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                SoModel sales = new SoModel();
                sales.Description = sdr["Description"].ToString();
                sales.ClientName = sdr["ClientName"].ToString();
                sales.destination = sdr["destination"].ToString();
                sales.Created = sdr["created"].ToString();
                sales.Date = sdr["Date"].ToString();
                sales.price = Convert.ToInt32(sdr["price"]);
                sales.quantity = Convert.ToInt32(sdr["quantity"]);
                sales.tax = Convert.ToInt32(sdr["tax"]);
                sales.total = Convert.ToInt32(sdr["total"]);
                sales.remarks = sdr["remarks"].ToString();
                sales.pallets = Convert.ToInt32(sdr["pallets"]);
                sales.sono = Convert.ToInt32(sdr["SONO"]);
                sales.final = Convert.ToDouble(sdr["Final_Amount"]);
             //   sales.final = Convert.ToDouble(sdr["Final_Amount"]);
                take_order.Add(sales);
            }
            sdr.Close();

            return take_order;
        }
        public void Delete_so()
        {
            SqlCommand sc = new SqlCommand("Delete_so", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();

        }


        public List<SoModel> show_all()
        {
            List<SoModel> take_order = new List<SoModel>();

            SqlCommand sc = new SqlCommand("ShowAllSo", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {

                SoModel sales = new SoModel();
                sales.sono = Convert.ToInt32(sdr["SONO"]);
                sales.Description = sdr["Description"].ToString();
                sales.ClientName = sdr["ClientName"].ToString();
                sales.destination = sdr["destination"].ToString();
                sales.Created = sdr["created"].ToString();
                sales.Date = sdr["Date"].ToString();
                sales.price = Convert.ToInt32(sdr["price"]);
                sales.quantity = Convert.ToInt32(sdr["quantity"]);
                sales.tax = Convert.ToInt32(sdr["tax"]);
                sales.total = Convert.ToInt32(sdr["total"]);
                sales.authorization = sdr["authorized"].ToString();
                sales.final = Convert.ToDouble(sdr["Final_Amount"]);
                sales.pallets = Convert.ToInt32(sdr["pallets"]);
                take_order.Add(sales);
            }
            sdr.Close();

            return take_order;
        }
        

        public List<SoModel> search()
        {
            List<SoModel> ser = new List<SoModel>();
            SqlCommand sc = new SqlCommand("Search_So", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                SoModel sm = new SoModel();
                sm.sono = Convert.ToInt32(sdr["SONO"]);
                sm.ClientName = sdr["Client"].ToString();
                ser.Add(sm);
            }
            sdr.Close();
            return ser;
        }



        public void UpdateSo()
        {
            SqlCommand sc = new SqlCommand("so1", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@Date", sm.Date);
            sc.Parameters.AddWithValue("@client", sm.ClientName);
            sc.Parameters.AddWithValue("@destination", sm.destination);
            sc.Parameters.AddWithValue("@pono", sm.po);
            if (sm.remarks == null)
            {
                sc.Parameters.AddWithValue("@remarks", "nothing");
            }
            else
            {
                sc.Parameters.AddWithValue("@remarks", sm.remarks);
            }
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();

        }


        public void UpdateSoItems()
        {
            SqlCommand sc = new SqlCommand("", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("", 0);
            sc.Parameters.AddWithValue("", 0);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public void DeleteSo(int id)
        {
            SqlCommand sc = new SqlCommand("DeleteSo", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }
    }
}