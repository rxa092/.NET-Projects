using SchedulerWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SchedulerWeb
{
    public class connection
    {
        public static SqlConnection con;
        public static SqlDataReader sdr;
        public static SqlConnection getcon()
        {
            if (con == null)
            {
                con = new SqlConnection();
                con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FYP"].ToString();
                con.Open();
            }

            return con;
        }

        public List<Teacher> GetTeachers()
        {

            List<Teacher> teachers = new List<Teacher>();
            SqlCommand sc = new SqlCommand("GetTeachers", getcon());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            connection.sdr = sc.ExecuteReader();
            //try
            //{
            //    connection.sdr = sc.ExecuteReader();
            //}
            //catch (Exception)
            //{

            //    connection.sdr.Close();
            //    connection.sdr = sc.ExecuteReader();
            //}
            while (connection.sdr.Read())
            {
                Teacher t = new Teacher();
                t.ID = Convert.ToInt32(connection.sdr["ID"]);
                t.Name = connection.sdr["Name"].ToString();
                teachers.Add(t);
            }
            connection.sdr.Close();
            return teachers;
        }

        public List<Classes> GetClasses()
        {
            
            List<Classes> classes = new List<Classes>();
            SqlCommand sc = new SqlCommand("GetClasses", getcon());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            connection.sdr = sc.ExecuteReader();
            //try
            //{
            //    connection.sdr = sc.ExecuteReader();
            //}
            //catch (Exception)
            //{

            //    connection.sdr.Close();
            //    connection.sdr = sc.ExecuteReader();
            //}
            while (connection.sdr.Read())
            {
                Classes c = new Classes();
                c.ID = Convert.ToInt32(connection.sdr["ClassID"]);
                c.courses = new Courses();
                c.courses.ID = Convert.ToInt32(connection.sdr["ID"]);
                c.courses.Name = connection.sdr["Name"].ToString();
                classes.Add(c);
            }
            connection.sdr.Close();
            return classes;
        }

        public List<Room> GetRooms()
        {
            List<Room> rooms = new List<Room>();
            
            SqlCommand sc = new SqlCommand("GetRooms", getcon());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            connection.sdr = sc.ExecuteReader();
            //try
            //{
            //    connection.sdr = sc.ExecuteReader();
            //}
            //catch (Exception)
            //{

            //    connection.sdr.Close();
            //    connection.sdr = sc.ExecuteReader();
            //}
            while (connection.sdr.Read())
            {
                Room r = new Room();
                r.ID = Convert.ToInt32(connection.sdr["ID"]);
                r.Name = connection.sdr["Name"].ToString();
                rooms.Add(r);
            }
            connection.sdr.Close();
            return rooms;
        }

        public List<Days> GetDays()
        {
            
            List<Days> days = new List<Days>();
            SqlCommand sc = new SqlCommand("GetDays", getcon());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            connection.sdr = sc.ExecuteReader();
            //try
            //{
            //    connection.sdr = sc.ExecuteReader();
            //}
            //catch (Exception)
            //{

            //    connection.sdr.Close();
            //    connection.sdr = sc.ExecuteReader();
            //}
            while (connection.sdr.Read())
            {
                Days d = new Days();
                d.ID = Convert.ToInt32(connection.sdr["ID"]);
                d.Name = connection.sdr["Name"].ToString();
                days.Add(d);
            }
            connection.sdr.Close();
            return days;
        }

        public List<Timeslots> GetTimeslots()
        {
            
            List<Timeslots> timeslots = new List<Timeslots>();
            SqlCommand sc = new SqlCommand("GetTimeslots", getcon());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            connection.sdr = sc.ExecuteReader();
            //try
            //{
            //    connection.sdr = sc.ExecuteReader();
            //}
            //catch (Exception)
            //{

            //    connection.sdr.Close();

            //    connection.sdr = sc.ExecuteReader();
            //}
            while (connection.sdr.Read())
            {
                Timeslots t = new Timeslots();
                t.ID = Convert.ToInt32(connection.sdr["ID"]);
                t.Name = connection.sdr["Name"].ToString();
                timeslots.Add(t);
            }
            connection.sdr.Close();
            return timeslots;
        }

        public List<TeacherClass> GetTeacherClasses()
        {
            
            List<TeacherClass> teacherClasses = new List<TeacherClass>();
            SqlCommand sc = new SqlCommand("GetTeacherClasses", getcon());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            connection.sdr = sc.ExecuteReader();
            while (connection.sdr.Read())
            {
                TeacherClass t = new TeacherClass();
                t.classes = new Classes();
                t.teacher = new Teacher();
                t.classes.courses = new Courses();
                t.classes.courses.ID = Convert.ToInt32(connection.sdr["CourseID"]);
                t.classes.courses.Name = connection.sdr["Class Name"].ToString();
                t.classes.ID = (int)connection.sdr["ClassID"];
                t.teacher.ID = (int)connection.sdr["TeacherID"];
                t.teacher.Name = connection.sdr["Name"].ToString();
                teacherClasses.Add(t);
            }
            connection.sdr.Close();
            return teacherClasses;
        }

        public List<TeacherTiming> GetTeacherTimings()
        {
            List<TeacherTiming> teacherTimings = new List<TeacherTiming>();
            SqlCommand sc = new SqlCommand("GetTeacherTimings", getcon());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            connection.sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                TeacherTiming tt = new TeacherTiming();
                tt.Days = new Days();
                tt.Teacher = new Teacher();
                tt.Timeslots = new Timeslots();
                tt.Days.ID = Convert.ToInt32(connection.sdr["DayID"]);
                tt.Days.Name = connection.sdr["Days"].ToString();
                tt.Teacher.ID = Convert.ToInt32(connection.sdr["TeacherID"]);
                tt.Teacher.Name = connection.sdr["Teachers"].ToString();
                tt.Timeslots.ID = Convert.ToInt32(connection.sdr["TimeSlot"]);
                tt.Timeslots.Name = connection.sdr["Timeslots"].ToString();
                teacherTimings.Add(tt);
            }
            connection.sdr.Close();
            return teacherTimings;
        }


    }
}