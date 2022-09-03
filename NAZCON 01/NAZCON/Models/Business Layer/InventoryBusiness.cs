using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAZCON.Models.Business_Layer
{
    public class InventoryBusiness
    {
        public Inventory inv { get; set; }
        public void add()
        {
            SqlCommand sc = new SqlCommand("AddInventory", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@name",inv.name);
            sc.Parameters.AddWithValue("@quant", inv.quantity);
            sc.Parameters.AddWithValue("@category", inv.Category);
            sc.Parameters.AddWithValue("@location", inv.location);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public void update()
        {
            SqlCommand sc = new SqlCommand("UpdateInventory", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", inv.id);
            sc.Parameters.AddWithValue("@name", inv.name);
            sc.Parameters.AddWithValue("@quant", inv.quantity);
            sc.Parameters.AddWithValue("@category", inv.Category);
            sc.Parameters.AddWithValue("@location", inv.location);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public void delete()
        {
            SqlCommand sc = new SqlCommand("DeleteInventory", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", inv.id);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public List<Inventory> show()
        {
            List<Inventory> lis = new List<Inventory>();
            SqlCommand sc = new SqlCommand("ShowInventory", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                inv = new Inventory();
                inv.id = Convert.ToInt32(sdr["ItemID"]);
                inv.name = sdr["Name"].ToString();
                inv.quantity = Convert.ToInt32(sdr["Quantity"]);
                inv.LocationName = sdr["Location"].ToString();
                inv.CategoryName = sdr["Category"].ToString();
                lis.Add(inv);
            }
            sdr.Close();
            return lis;
        }

        public List<Inventory> getinv()
        {
            List<Inventory> lis = new List<Inventory>();
            SqlCommand sc = new SqlCommand("GetInventory", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                inv = new Inventory();
                inv.id = Convert.ToInt32(sdr["ItemID"]);
                inv.name = sdr["Name"].ToString();
                inv.LocationName = sdr[""].ToString();
                inv.CategoryName = sdr[""].ToString();

                lis.Add(inv);
            }
            sdr.Close();
            return lis;
        }

        public List<Inventory> filtered()
        {
            List<Inventory> inventories = new List<Inventory>();
            return inventories;
        }


        public Inventory search(int id)
        {
            Inventory i = new Inventory();
            SqlCommand sc = new SqlCommand("SearchInv", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {

                i.id = Convert.ToInt32(sdr["ItemID"]);
                i.name = sdr["Name"].ToString();
                i.quantity = Convert.ToInt32(sdr["Quantity"]);
                inv.LocationName = sdr["Location"].ToString();
                inv.CategoryName = sdr["Category"].ToString();

            }
            sdr.Close();
            return i;
        }

        public List<Inventory> AllCategories()
        {
            List<Inventory> lis = new List<Inventory>();
            SqlCommand sc = new SqlCommand("ShowNonSellingItemCategory", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            if (connection.sdr != null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            connection.sdr = sc.ExecuteReader();
            while (connection.sdr.Read())
            {
                Inventory st = new Inventory();
                st.Category = (int)connection.sdr["ID"];
                st.CategoryName = connection.sdr["Name"].ToString();
                lis.Add(st);
            }
            connection.sdr.Close();
            return lis;
        }

        public List<Inventory> AllLocations()
        {
            List<Inventory> lis = new List<Inventory>();
            SqlCommand sc = new SqlCommand("ShowNonSellingItemLocation", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            if (connection.sdr != null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            connection.sdr = sc.ExecuteReader();
            while (connection.sdr.Read())
            {
                Inventory st = new Inventory();
                st.location = (int)connection.sdr["ID"];
                st.LocationName = connection.sdr["Name"].ToString();
                lis.Add(st);
            }
            connection.sdr.Close();
            return lis;
        }
    }
}