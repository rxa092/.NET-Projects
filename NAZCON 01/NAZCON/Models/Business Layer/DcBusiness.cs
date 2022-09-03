using NAZCON.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NAZCON.Models.EntityModel;
namespace NAZCON.Models.Business_Layer
{
    public class DcBusiness
    {

        public DcModel dm { get; set; }
        public double items { get; set; }
        public static bool yes = false;
        //  public static int count=0;
        
        public List<int> get_do()
        {
            List<int> lis = new List<int>();
            SqlCommand sc = new SqlCommand("getDO", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                int s = 0;
               s = Convert.ToInt32( sdr["DONO"]);
                lis.Add(s);
            }
            sdr.Close();
            return lis;
        }

        public void minusitems()
        {
            SqlCommand sc = new SqlCommand("UpdateDcItems", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", dm.im.id);
            sc.Parameters.AddWithValue("@minus", items);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close ();
        }

        public void UpdateDcItems()
        {
            SqlCommand sc = new SqlCommand("", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("", 0);
            sc.Parameters.AddWithValue("", 0);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public void add_dc()
        {
            SqlCommand sc = new SqlCommand("CreateDc", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@truck", dm.truck);
            sc.Parameters.AddWithValue("@location", dm.location);
            sc.Parameters.AddWithValue("@remarks", "");
            sc.Parameters.AddWithValue("@date", DateTime.Now.Date);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
            yes = true;
        }


        public void add_dc2()
        {
            SqlCommand sc = new SqlCommand("CreateDc2", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@item", dm.im.id);
            sc.Parameters.AddWithValue("@pallets", dm.no_of_pallets);
            sc.Parameters.AddWithValue("@quantity", dm.quantity);
            sc.Parameters.AddWithValue("@dono", dm.dono);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
            
        }

        public double update_dc1()
        {
            double x = 0;
            SqlCommand sc = new SqlCommand("upd_itm", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@itemId", dm.im.id);
            sc.Parameters.AddWithValue("@dono", dm.dono);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                x = Convert.ToDouble( sdr["remaining"]);
            }
            sdr.Close();
            return x;
        }

        public void update_dc2()
        {
            SqlCommand sc = new SqlCommand("Do_data", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@dono", dm.dono);
            sc.Parameters.AddWithValue("@quantity", dm.quantity);
            sc.Parameters.AddWithValue("@itemId", dm.im.id);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public List<DcModel>  show_dc()
        {
            List<DcModel> lis = new List<DcModel>();
            
            SqlCommand sc = new SqlCommand("ShowAllDc", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                DcModel dm = new DcModel();
                dm.dcno = Convert.ToInt32(sdr["DCNO"]);
                dm.truck = sdr["TruckNo"].ToString();
                dm.remarks = sdr["remarks"].ToString();
                dm.location = sdr["location"].ToString();
                dm.dono = Convert.ToInt32(sdr["DONO"]);
                dm.no_of_pallets = Convert.ToInt32(sdr["pallets"]);
                dm.quantity = Convert.ToDouble(sdr["quantity"]);
                dm.cm = new ClientModel();
                dm.cm.Client_name = sdr["ClientName"].ToString();
                dm.cm.Date = sdr["Date"].ToString();
                dm.im = new ItemModel();
                dm.im.description = sdr["Description"].ToString();
                dm.authorization = sdr["authorize"].ToString();
                lis.Add(dm);
             }
            sdr.Close();
            return lis;
        }

        public void DeleteDc(int id)
        {
            SqlCommand sc = new SqlCommand("Deletedc", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

    }
}