using NAZCON.Models.EntityModel;
using NAZCON.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAZCON.Models.Business_Layer
{
    public class GatepassBussiness
    {
        

        public void add_GP(int id)
        {
            SqlCommand sc = new SqlCommand("Create_GP", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@date", DateTime.Now.Date);
            sc.Parameters.AddWithValue("@DCNO",id);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }
        public List<GpModel> show_dc()
        {
            List<GpModel> lis = new List<GpModel>();

            SqlCommand sc = new SqlCommand("Show_GP", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
              
                GpModel dm = new GpModel();
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
                dm.GPNO =Convert.ToInt32(sdr["GPNO"]);
                lis.Add(dm);
            }
            sdr.Close();
            return lis;
        }

        public void DeleteGp(int id)
        {
            SqlCommand sc = new SqlCommand("DeleteGatePass", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();

        }
    }
}