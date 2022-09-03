using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAZCON.Models.Business_Layer
{
    public class ItemBussiness
    {
        public ItemModel im {get;set;}

        public void item_add()
        {
            SqlCommand sc = new SqlCommand("AddItem", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@describe", im.description);
            sc.Parameters.AddWithValue("@price", im.price);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public void item_delete()
        {
            SqlCommand sc = new SqlCommand("Delete_item", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@Itemid", @im.id);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public List<ItemModel> show_all()
        {
            List<ItemModel> show_items = new List<ItemModel>();

            SqlCommand sc = new SqlCommand("Show_items", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                ItemModel items = new ItemModel();
                items.id = Convert.ToInt32(sdr["itemID"]);
                items.description =sdr["Description"].ToString();
                items.price = Convert.ToDouble(sdr["price"]);
                show_items.Add(items);
            }
            sdr.Close();

            return show_items;
        }

        public ItemModel item_search(int id)
        {
            ItemModel im = new ItemModel();
            SqlCommand sc = new SqlCommand("update_item", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@Itemid",id);
            SqlDataReader sdr = sc.ExecuteReader();
            
            while(sdr.Read())
            {
                im.id = Convert.ToInt32(sdr["ItemID"]);
                im.description = sdr["Description"].ToString();
                im.price = Convert.ToDouble(sdr["price"]);
            }
            sdr.Close();
            return im;
        }
        public void item_update1()
        {
            SqlCommand sc = new SqlCommand("update_item1", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@Itemid", im.id);
            sc.Parameters.AddWithValue("@Description", im.description);
            sc.Parameters.AddWithValue("@price", im.price);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public void quantity()
        {
            SqlCommand sc = new SqlCommand("UpdQuan", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", im.id);
            sc.Parameters.AddWithValue("@quan", im.quantity);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public List<ItemModel> showquan()
        {
            List<ItemModel> ls = new List<ItemModel>();
            SqlCommand sc = new SqlCommand("ShowQuan", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                ItemModel im=new ItemModel();
                im.id = Convert.ToInt32(sdr["ItemID"]);
                im.description = sdr["Description"].ToString();
                im.quantity = Convert.ToInt32(sdr["Quantity"]);
                ls.Add(im);
            }
            sdr.Close();
            return ls;
        }
    }
}