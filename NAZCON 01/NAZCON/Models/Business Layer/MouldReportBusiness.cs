using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAZCON.Models.Business_Layer
{
    public class MouldReportBusiness
    {
        public MouldReport mr { get; set; }
        public void AddMouldReport()
        {
            if (connection.sdr != null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            SqlCommand sc = new SqlCommand("AddMouldReport", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@date", mr.date);
            sc.Parameters.AddWithValue("@mould", mr.mouldid);
            sc.Parameters.AddWithValue("@plates", mr.plates);
            connection.sdr = sc.ExecuteReader();
            connection.sdr.Close();
        }
    public void UpdateMouldReport()
    {
        if (connection.sdr != null && !connection.sdr.IsClosed)
        {
            connection.sdr.Close();
        }
            SqlCommand sc = new SqlCommand("UpdateMouldReport", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@date", mr.date);
            sc.Parameters.AddWithValue("@mould", mr.mouldid);
            sc.Parameters.AddWithValue("@plates", mr.plates);
            sc.Parameters.AddWithValue("@id", mr.reportid);
            connection.sdr = sc.ExecuteReader();
            connection.sdr.Close();
    }

        public List<MouldReport> AllMouldReport()
        {
            List<MouldReport> lis = new List<MouldReport>();
            if (connection.sdr !=null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            SqlCommand sc = new SqlCommand("ShowMouldReport", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            connection.sdr = sc.ExecuteReader();
            while (connection.sdr.Read())
            {
                mr = new MouldReport();
                mr.mm = new MouldModel();
                mr.msm = new MouldStatusModel();
                mr.date = connection.sdr["Date"].ToString();
                mr.plates = Convert.ToInt32(connection.sdr["plates"]);
                mr.mm.dateofinstallation = connection.sdr["DateOfInstallation"].ToString();
                mr.mm.Dimension = connection.sdr["Dimension"].ToString();
                mr.mm.lifecycle = Convert.ToInt32(connection.sdr["LifeCycle"]);
                mr.mm.mouldstdcycle = Convert.ToInt32(connection.sdr["StdCycle"]);
                mr.mm.Name = connection.sdr["Name"].ToString();
                mr.mm.statusname = connection.sdr["Status"].ToString();
                mr.mm.vendorname = connection.sdr["Vendor"].ToString();
                mr.reportid = Convert.ToInt32(connection.sdr["ID"]);
                lis.Add(mr);
            }
            connection.sdr.Close();
            return lis;
        }

        public MouldReport SpecificMouldReport(int id)
        {
            if (connection.sdr != null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            mr = new MouldReport();
            SqlCommand sc = new SqlCommand("ShowSpecificMouldReport", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            connection.sdr = sc.ExecuteReader();
            while (connection.sdr.Read())
            {
                mr.date = connection.sdr["Date"].ToString();
                mr.mouldid = Convert.ToInt32(connection.sdr["Mould"]);
                mr.plates = Convert.ToInt32(connection.sdr["plates"]);
                mr.reportid = Convert.ToInt32(connection.sdr["ID"]);
            }
            connection.sdr.Close();
            return mr;
        }

        public void DeleteReport(int id)
        {
            if (connection.sdr != null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            SqlCommand sc = new SqlCommand("DeleteMouldReport", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            connection.sdr = sc.ExecuteReader();
            connection.sdr.Close();
        }
}
}