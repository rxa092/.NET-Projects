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
    public class MouldBusiness
    {
        public MouldModel mm { get; set; }
        public void AddMould()
        {
            if (connection.sdr !=null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            SqlCommand sc = new SqlCommand("AddMould", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@Date", mm.dateofinstallation);
            sc.Parameters.AddWithValue("@Dimension", mm.Dimension);
            sc.Parameters.AddWithValue("@StdCycle", mm.mouldstdcycle);
            sc.Parameters.AddWithValue("@Name", mm.Name);
            sc.Parameters.AddWithValue("@Status", mm.status);
            sc.Parameters.AddWithValue("@Vendor", mm.vendor);
            connection.sdr = sc.ExecuteReader();
            connection.sdr.Close();
        }

        public void UpdateMould()
        {
            if (connection.sdr != null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            SqlCommand sc = new SqlCommand("UpdateMould", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@Date", mm.dateofinstallation);
            sc.Parameters.AddWithValue("@Dimension", mm.Dimension);
            sc.Parameters.AddWithValue("@StdCycle", mm.mouldstdcycle);
            sc.Parameters.AddWithValue("@Name", mm.Name);
            sc.Parameters.AddWithValue("@Status", mm.status);
            sc.Parameters.AddWithValue("@Vendor", mm.vendor);
            sc.Parameters.AddWithValue("@id", mm.id);
            connection.sdr = sc.ExecuteReader();
            connection.sdr.Close();
        }

        public List<MouldModel> ShowAllMould()
        {
            if (connection.sdr!=null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            List<MouldModel> lis = new List<MouldModel>();
            SqlCommand sc = new SqlCommand("ShowAllMould", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            connection.sdr = sc.ExecuteReader();
            while (connection.sdr.Read())
            {
                mm = new MouldModel();
                mm.dateofinstallation = connection.sdr["DateOfInstallation"].ToString();
                mm.Dimension = connection.sdr["Dimension"].ToString();
                mm.id = Convert.ToInt32(connection.sdr["ID"]);
                mm.lifecycle = Convert.ToDouble(connection.sdr["LifeCycle"]);
                mm.mouldstdcycle = Convert.ToDouble(connection.sdr["StdCycle"]);
                mm.Name = Convert.ToString(connection.sdr["Name"]);
                mm.statusname = Convert.ToString(connection.sdr["Status"]);
                mm.vendorname = Convert.ToString(connection.sdr["Vendor"]);
                lis.Add(mm); 
            }
            connection.sdr.Close();
            return lis;
        }

        public MouldModel SpecificMould(int id)
        {
            if (connection.sdr!=null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            mm = new MouldModel();
            SqlCommand sc = new SqlCommand("ShowSpecificMould", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            connection.sdr = sc.ExecuteReader();
            while (connection.sdr.Read())
            {
                mm.dateofinstallation = connection.sdr["DateOfInstallation"].ToString();
                mm.Dimension = connection.sdr["Dimension"].ToString();
                mm.id = Convert.ToInt32(connection.sdr["ID"]);
                mm.mouldstdcycle = Convert.ToDouble(connection.sdr["StdCycle"]);
                mm.Name = Convert.ToString(connection.sdr["Name"]);
                mm.statusname = Convert.ToString(connection.sdr["Status"]);
                mm.vendorname = Convert.ToString(connection.sdr["Vendor"]);

            }
            connection.sdr.Close();
            return mm;
        }

        public void DeleteMould(int id)
        {
            if (connection.sdr!=null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            SqlCommand sc = new SqlCommand("DeleteMould", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            connection.sdr = sc.ExecuteReader();
            connection.sdr.Close();
        }
    }
}