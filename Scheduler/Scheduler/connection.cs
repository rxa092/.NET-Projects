using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    class connection
    {
        static SqlConnection con = new SqlConnection("Data Source=RAZA-PC\\SQL12;Initial Catalog=FYP;Integrated Security=True");
        public static SqlDataReader sdr = null;
        public List<Teacher> GetTeachers()
        {
            con.Open();
            List<Teacher> teachers = new List<Teacher>();
            SqlCommand sc = new SqlCommand("GetTeachers", con);
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                connection.sdr = sc.ExecuteReader();
            }
            catch (Exception)
            {

                connection.sdr.Close();
                connection.sdr = sc.ExecuteReader();
            }
            while (connection.sdr.Read())
            {
                Teacher t = new Teacher();
                t.ID = Convert.ToInt32(connection.sdr["ID"]);
                t.Name = connection.sdr["Name"].ToString();
                teachers.Add(t);
            }
            connection.sdr.Close();
            con.Close();
            return teachers;
        }

        public List<Classes> GetClasses()
        {
            con.Open();

            List<Classes> classes = new List<Classes>();
            SqlCommand sc = new SqlCommand("GetClasses", con);
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                connection.sdr = sc.ExecuteReader();
            }
            catch (Exception)
            {

                connection.sdr.Close();
                connection.sdr = sc.ExecuteReader();
            }
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
            con.Open();
            SqlCommand sc = new SqlCommand("GetRooms", con);
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                connection.sdr = sc.ExecuteReader();
            }
            catch (Exception)
            {

                connection.sdr.Close();
                connection.sdr = sc.ExecuteReader();
            }
            while (connection.sdr.Read())
            {
                Room r = new Room();
                r.ID = Convert.ToInt32(connection.sdr["ID"]);
                r.Name = connection.sdr["Name"].ToString();
                rooms.Add(r);
            }
            connection.sdr.Close();
            con.Close();
            return rooms;
        }

        public List<Days> GetDays()
        {
            con.Open();

            List<Days> days = new List<Days>();
            SqlCommand sc = new SqlCommand("GetDays", con);
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                connection.sdr = sc.ExecuteReader();
            }
            catch (Exception)
            {

                connection.sdr.Close();
                connection.sdr = sc.ExecuteReader();
            }
            while (connection.sdr.Read())
            {
                Days d = new Days();
                d.ID = Convert.ToInt32(connection.sdr["ID"]);
                d.Name = connection.sdr["Name"].ToString();
                days.Add(d);
            }
            connection.sdr.Close();
            con.Close();
            return days;
        }

        public List<Timeslots> GetTimeslots()
        {
            con.Open();

            List<Timeslots> timeslots = new List<Timeslots>();
            SqlCommand sc = new SqlCommand("GetTimeslots", con);
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                connection.sdr = sc.ExecuteReader();
            }
            catch (Exception)
            {

                connection.sdr.Close();
                connection.sdr = sc.ExecuteReader();
            }
            while (connection.sdr.Read())
            {
                Timeslots t = new Timeslots();
                t.ID = Convert.ToInt32(connection.sdr["ID"]);
                t.Name = connection.sdr["Name"].ToString();
                timeslots.Add(t);
            }
            connection.sdr.Close();
            con.Close();
            return timeslots;
        }

        public List<TeacherClass> GetTeacherClasses()
        {
            con.Open();

            List<TeacherClass> teacherClasses = new List<TeacherClass>();
            SqlCommand sc = new SqlCommand("GetTeacherClasses", con);
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            try
            {
                connection.sdr = sc.ExecuteReader();
            }
            catch (Exception)
            {

                connection.sdr.Close();
                connection.sdr = sc.ExecuteReader();
            }
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
            con.Close();
            return teacherClasses;
        }
    }
}
