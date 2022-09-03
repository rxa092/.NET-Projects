using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAZCON.Models.Business_Layer
{
    public class MouldStatusBusiness
    {
        public MouldStatusModel msm { get; set; }

        public void AddStatus()
        {
            if (connection.sdr !=null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            SqlCommand sc = new SqlCommand("AddMouldStatus", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@name", msm.name);
            connection.sdr = sc.ExecuteReader();
            connection.sdr.Close();
        }

        public void UpdateStatus()
        {
            if (connection.sdr !=null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            SqlCommand sc = new SqlCommand("UpdateMouldStatus", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", msm.id);
            sc.Parameters.AddWithValue("@name", msm.name);
            connection.sdr = sc.ExecuteReader();
            connection.sdr.Close();
        }

        public List<MouldStatusModel> AllStatus()
        {
            if (connection.sdr != null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            List<MouldStatusModel> lis = new List<MouldStatusModel>();
            SqlCommand sc = new SqlCommand("ShowMouldStatus", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            connection.sdr = sc.ExecuteReader();
            while (connection.sdr.Read())
            {
                msm = new MouldStatusModel();
                msm.id = Convert.ToInt32(connection.sdr["ID"]);
                msm.name = connection.sdr["Name"].ToString();
                lis.Add(msm);
            }
            connection.sdr.Close();
            return lis;
        }

        public MouldStatusModel SpecificStatus(int id)
        {
            msm = new MouldStatusModel();
            if (connection.sdr !=null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            SqlCommand sc = new SqlCommand("ShowSpecificMouldStatus", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            connection.sdr = sc.ExecuteReader();
            while (connection.sdr.Read())
            {
                msm.id = Convert.ToInt32(connection.sdr["ID"]);
                msm.name = Convert.ToString(connection.sdr["Name"]);
            }
            connection.sdr.Close();
            return msm;
        }

        public void DeleteStatus(int id)
        {
            if (connection.sdr!=null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            SqlCommand sc = new SqlCommand("DeleteMouldStatus", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            connection.sdr = sc.ExecuteReader();
            connection.sdr.Close();
        }
    }
}