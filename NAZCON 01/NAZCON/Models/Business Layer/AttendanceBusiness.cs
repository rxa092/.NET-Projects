using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAZCON.Models.Business_Layer
{
    public class AttendanceBusiness
    {
        public List<Attendance> ShowAll()
        {
            List<Attendance> lis = new List<Attendance>();
            SqlCommand sc = new SqlCommand("AttendanceReport", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Attendance at = new Attendance();
                at.CheckIn = sdr["CheckedIn"].ToString();
                at.CheckOut = sdr["CheckedOut"].ToString();
                at.Name = sdr["Name"].ToString();
                lis.Add(at);
            }
            sdr.Close();
            return lis;
        }
    }
}