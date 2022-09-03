using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using NAZCON.Models.EntityModel;

namespace NAZCON.Models.Business_Layer
{
    public class EmployeeBusiness
    {
        public EmployeeModel em;

        public void AddEmp()
        {
            SqlCommand sc = new SqlCommand("AddEmp", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@address",em.address);
            sc.Parameters.AddWithValue("@contact", em.contact);
            sc.Parameters.AddWithValue("@DOB", em.dob);
            sc.Parameters.AddWithValue("@name", em.ename);
            sc.Parameters.AddWithValue("@join", em.join);
            sc.Parameters.AddWithValue("@nic", em.nic);
            sc.Parameters.AddWithValue("@degree", em.qualification);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
         }


        public void DelEmp()
        {
            SqlCommand sc = new SqlCommand("DelEmp", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", em.empid);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public void UpdEmp()
        {
            SqlCommand sc = new SqlCommand("UpdEmp", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@address", em.address);
            sc.Parameters.AddWithValue("@contact", em.contact);
            sc.Parameters.AddWithValue("@DOB", em.dob);
            sc.Parameters.AddWithValue("@name", em.ename);
            sc.Parameters.AddWithValue("@join", em.join);
            sc.Parameters.AddWithValue("@nic", em.nic);
            sc.Parameters.AddWithValue("@degree", em.qualification);
            sc.Parameters.AddWithValue("@id", em.empid);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }


        public List<EmployeeModel> ShowEmp()
        {
            List<EmployeeModel> list = new List<EmployeeModel>();
            SqlCommand sc = new SqlCommand("ViweEmp", connection.getcon());
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                EmployeeModel emm = new EmployeeModel();
                emm.empid = Convert.ToInt32(sdr["EmployeeId"]);
                emm.address = sdr["address"].ToString();
                emm.contact = sdr["Number"].ToString();
                emm.dob = Convert.ToString(sdr["DOB"]);
                emm.join = Convert.ToString(sdr["Joining"]);
                //emm.email = sdr["Email"].ToString();
                emm.ename = sdr["Name"].ToString();
                emm.nic = sdr["NIC"].ToString();
                emm.qualification = sdr["Highest-Qualification"].ToString();
                list.Add(emm);
            }

            sdr.Close();
            return list;
        }

        public EmployeeModel EmpSearch(string id)
        {
            em = new EmployeeModel();
            SqlCommand sc = new SqlCommand("empSearch",connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                em.empid = Convert.ToInt32(sdr["EmployeeId"]);
                em.address = sdr["address"].ToString();
                em.contact = sdr["Number"].ToString();
                em.dob = Convert.ToString(sdr["DOB"]);
                //emm.email = sdr["Email"].ToString();
                em.ename = sdr["Name"].ToString();
                em.join = Convert.ToString(sdr["Joining"]);
                em.nic = sdr["NIC"].ToString();
                em.qualification = sdr["Highest-Qualification"].ToString();
            }
            sdr.Close();

            return em;
        }

        public List<EmployeeModel> getemp()
        {
            List<EmployeeModel> list = new List<EmployeeModel>();
            SqlCommand sc = new SqlCommand("GetEmp", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();

            while (sdr.Read())
            {
                EmployeeModel em = new EmployeeModel();
                em.empid = Convert.ToInt32(sdr["EmployeeId"]);
                em.ename = sdr["Name"].ToString();
                list.Add(em);
            }
            sdr.Close();
            return list;
        }

        public List<EmployeeModel> GetSpecificEmployee(string category)
        {
            List<EmployeeModel> list = new List<EmployeeModel>();
            SqlCommand sc = new SqlCommand("GetSpecificCategoryEmployee", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("Category", category);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                EmployeeModel emm = new EmployeeModel();
                emm.empid = Convert.ToInt32(sdr["EmployeeId"]);
                emm.address = sdr["address"].ToString();
                emm.contact = sdr["Number"].ToString();
                emm.dob = Convert.ToString(sdr["DOB"]);
                emm.join = Convert.ToString(sdr["Joining"]);
                //emm.email = sdr["Email"].ToString();
                emm.ename = sdr["Name"].ToString();
                emm.join = Convert.ToString(sdr["Joining"]);
                emm.nic = sdr["NIC"].ToString();
                emm.qualification = sdr["Highest-Qualification"].ToString();
                list.Add(emm);
            }
            sdr.Close();
            return list;
        }
    }
}