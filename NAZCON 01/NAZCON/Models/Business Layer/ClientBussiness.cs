using NAZCON.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAZCON.Models.Business_Layer
{
    public class ClientBussiness
    {
        public ClientModel cb { get; set; }
        public void Add_client()
        {
            SqlCommand sc = new SqlCommand("Create_Client",connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@clientName", cb.Client_name);
            sc.Parameters.AddWithValue("@Joining", DateTime.Now.Date);
            sc.Parameters.AddWithValue("@Email", cb.Client_email);
            sc.Parameters.AddWithValue("@address", cb.address);
            sc.Parameters.AddWithValue("@Contact", cb.Client_contact);
            sc.Parameters.AddWithValue("@balance", cb.OpeningBalance);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public void Delete_client()
        {
            SqlCommand sc = new SqlCommand("Delete_Client", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@ClientID", cb.Client_id);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public void Update_client()
        {
            SqlCommand sc = new SqlCommand("Update_client", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@ClientName", cb.Client_name);
            sc.Parameters.AddWithValue("@Joining", Convert.ToDateTime(cb.Date));
            sc.Parameters.AddWithValue("@Email", cb.Client_email);
            sc.Parameters.AddWithValue("@ClientID", cb.Client_id);
            sc.Parameters.AddWithValue("@Contact", cb.Client_contact);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }


        public List<ClientModel> DropDown()
        {
            List<ClientModel> take_order = new List<ClientModel>();

            SqlCommand sc = new SqlCommand("DropdownClient", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                ClientModel sales = new ClientModel();
                sales.Client_id = Convert.ToInt32(sdr["ClientID"]);
                sales.Client_name = sdr["ClientName"].ToString();
                take_order.Add(sales);
            }
            sdr.Close();

            return take_order;
        }

        public List<ClientModel> show_all()
        {
            List<ClientModel> take_order = new List<ClientModel>();

            SqlCommand sc = new SqlCommand("Show_Client", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                ClientModel sales = new ClientModel();
                sales.Client_id = Convert.ToInt32(sdr["ClientID"]);
                sales.Client_name = sdr["ClientName"].ToString();
                sales.Client_contact = sdr["Contact"].ToString();
                sales.Client_email = sdr["Email"].ToString();
                sales.Date = sdr["Joining"].ToString();
                take_order.Add(sales);
            }
            sdr.Close();

            return take_order;
        }

        public ClientModel client_search(int id)
        {
            ClientModel clients = new ClientModel();
            SqlCommand sc = new SqlCommand("Search_Client", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@ClientID", id);
            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                clients.Client_id = Convert.ToInt32(sdr["ClientID"]);
                clients.Client_name = sdr["ClientName"].ToString();
                clients.Client_contact = sdr["Contact"].ToString();
                clients.Client_email = sdr["Email"].ToString();
                clients.Date = sdr["Joining"].ToString();
            }
            sdr.Close();

            return clients;
        }


        public List<ClientModel> getclient()
        {
            List<ClientModel> list = new List<ClientModel>();
            SqlCommand sc = new SqlCommand("GetClient", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                ClientModel cm = new ClientModel();
                cm.Client_id = Convert.ToInt32(sdr["ClientID"]);
                cm.Client_name = sdr["ClientName"].ToString();

                list.Add(cm);

            }
            sdr.Close();
            return list;
        }
    }
}