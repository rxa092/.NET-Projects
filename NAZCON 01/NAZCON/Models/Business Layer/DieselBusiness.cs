using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAZCON.Models.Business_Layer
{
    public class DieselBusiness
    {
        public Diesel d { get; set; }

        public void CreateDiesel()
        {
            if (connection.sdr!=null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            SqlCommand sc = new SqlCommand("AddDieselTransaction", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@Date", d.Date);
            sc.Parameters.AddWithValue("@DieselDispensery", d.DieselDispensery);
            sc.Parameters.AddWithValue("@Dip", d.DipRecordin);
            sc.Parameters.AddWithValue("@OpeningDiesel", d.OpeningDiesel);
            sc.Parameters.AddWithValue("@Vehicle", d.Vehicle);
            sc.Parameters.AddWithValue("@VehicleType", d.VehicleType);
            sc.Parameters.AddWithValue("@LastReading", d.LastReading);
            connection.sdr = sc.ExecuteReader();
            connection.sdr.Close();
        }

        public List<Diesel> ShowAllDiesel(DateTime start , DateTime end ,string type)
        {
            if (connection.sdr != null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            List<Diesel> lis = new List<Diesel>();
            SqlCommand sc = new SqlCommand("ShowDieselTransaction", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@start", start);
            sc.Parameters.AddWithValue("@end", end);
            sc.Parameters.AddWithValue("@type", type);
            connection.sdr = sc.ExecuteReader();
            while (connection.sdr.Read())
            {
                d = new Diesel();
                d.id = Convert.ToInt16(connection.sdr["DieselTransactionId"]);
                d.Balance = Convert.ToDouble(connection.sdr["Balance"]);
                d.CurrentReading = Convert.ToDouble(connection.sdr["CurrentReading"]);
                string x = Convert.ToDateTime(connection.sdr["Date"]).ToString("dd-MM-yyyy");
                d.Date = x;
                d.DieselDispensery = Convert.ToDouble(connection.sdr["DieselDispensery"]);
                d.DipRecordin = Convert.ToDouble(connection.sdr["Dip"]);
                d.LastReading = Convert.ToDouble(connection.sdr["LastReading"]);
                d.OpeningDiesel = Convert.ToDouble(connection.sdr["OpeningDiesel"]);
                d.Vehicle = connection.sdr["Vehicle"].ToString();
                d.VehicleType = connection.sdr["VehicleType"].ToString();
                lis.Add(d);
            }
            connection.sdr.Close();
            return lis;
        }

        public void FillTank()
        {
            if (connection.sdr != null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            SqlCommand sc = new SqlCommand("FillDieselTank", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@Date", d.Date);
            sc.Parameters.AddWithValue("@quantity", d.DieselDispensery);
            connection.sdr = sc.ExecuteReader();
            connection.sdr.Close();
        }

        public void DeleteDiesel(int id)
        {
            if (connection.sdr != null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            SqlCommand sc = new SqlCommand("DeleteDiesel", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            connection.sdr = sc.ExecuteReader();
            connection.sdr.Close();
        }

        public void UpdateDiesel()
        {
            if (connection.sdr != null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            SqlCommand sc = new SqlCommand("UpdateDiesel", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", d.id);
            sc.Parameters.AddWithValue("@balance", d.Balance);
            sc.Parameters.AddWithValue("@creading", d.CurrentReading);
            sc.Parameters.AddWithValue("@date", d.Date);
            sc.Parameters.AddWithValue("@dieseldis", d.DieselDispensery);
            sc.Parameters.AddWithValue("@dip", d.DipRecordin);
            sc.Parameters.AddWithValue("@lreading", d.LastReading);
            sc.Parameters.AddWithValue("@odiesel", d.OpeningDiesel);
            sc.Parameters.AddWithValue("@vehicle", d.Vehicle);
            sc.Parameters.AddWithValue("@vtype", d.VehicleType);
            connection.sdr = sc.ExecuteReader();
            connection.sdr.Close();
        }

        public Diesel GetDieselById(int id)
        {
            if (connection.sdr != null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            SqlCommand sc = new SqlCommand("GetDieselById", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            connection.sdr = sc.ExecuteReader();
            while (connection.sdr.Read())
            {
                d = new Diesel();
                d.id = Convert.ToInt32(connection.sdr["DieselTransactionId"]);
                d.Balance = Convert.ToDouble(connection.sdr["Balance"]);
                d.CurrentReading = Convert.ToDouble(connection.sdr["CurrentReading"]);
            //    d.Date = Convert.ToDateTime(sdr["Date"]);
                d.DieselDispensery = Convert.ToDouble(connection.sdr["DieselDispensery"]);
                d.DipRecordin = Convert.ToDouble(connection.sdr["Dip"]);
                d.LastReading = Convert.ToDouble(connection.sdr["LastReading"]);
                d.OpeningDiesel = Convert.ToDouble(connection.sdr["OpeningDiesel"]);
                d.Vehicle = connection.sdr["Vehicle"].ToString();
                d.VehicleType = connection.sdr["VehicleType"].ToString();
            }
            connection.sdr.Close();
            return d;
        }

        public List<Diesel> DipChart(DateTime start , DateTime end)
        {
            if (connection.sdr != null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            List<Diesel> lis = new List<Diesel>();
            SqlCommand sc = new SqlCommand("DipChartShow", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@start", start);
            sc.Parameters.AddWithValue("@end", end);
            connection.sdr = sc.ExecuteReader();
            while (connection.sdr.Read())
            {
                d = new Diesel();
                d.Balance = Convert.ToDouble(connection.sdr["Balance"]);
                d.CurrentReading = Convert.ToDouble(Math.Round(Convert.ToDecimal(connection.sdr["OLITRE"])));
                string x = Convert.ToDateTime(connection.sdr["Date"]).ToString("dd-MM-yyyy");
                d.Date = x;
                d.LastReading = Convert.ToDouble(Math.Round(Convert.ToDecimal(connection.sdr["CLITRE"])));
                d.OpeningDiesel = Convert.ToDouble(connection.sdr["OpeningDiesel"]);
                d.DipRecordin = Convert.ToDouble(connection.sdr["Dip"]);
                d.DieselDispensery = Convert.ToDouble(connection.sdr["DieselDispensery"]);
                lis.Add(d);
            }
            connection.sdr.Close();
            return lis;
        }

        public bool checkyesterdayvalue(DateTime yesterday)
        {
            if (connection.sdr != null && !connection.sdr.IsClosed)
            {
                connection.sdr.Close();
            }
            SqlCommand sc = new SqlCommand("YesterdayEntry", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@date", yesterday);
            connection.sdr = sc.ExecuteReader();
            bool check = false;
            while (connection.sdr.Read())
            {
                check = true;
                break;
            }
            connection.sdr.Close();
            return check;
            
        }
        
    }
}