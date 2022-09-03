using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAZCON.Models.Business_Layer
{
    public class StockMovementBusiness
    {
        public StockMOvementModel sm { get; set; }

        public void AddStockMovement()
        {
            SqlCommand sc = new SqlCommand("AddStockMovement", connection.getcon());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@pid", sm.item.id);
            sc.Parameters.AddWithValue("@inamount", sm.stockin);
            sc.Parameters.AddWithValue("@outamount", sm.stockout);
            sc.Parameters.AddWithValue("@broken", sm.broken);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public List<StockMOvementModel> ShowStockMovement()
        {
            StockMOvementModel sm = new StockMOvementModel();
            List<StockMOvementModel> lis = new List<StockMOvementModel>();
            SqlCommand sc = new SqlCommand("ShowStockMovement", connection.getcon());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            
            
            while (sdr.Read())
            {
                sm = new StockMOvementModel();
                sm.item = new ItemModel();
                sm.Id = Convert.ToInt32(sdr["SMID"]);
                sm.stockin = Convert.ToInt32(sdr["StockIn"]);
                sm.stockout = Convert.ToInt32(sdr["StockOut"]);
                sm.balance = Convert.ToInt32(sdr["Balance"]);
                sm.item.description = sdr["Description"].ToString();
                sm.broken = Convert.ToInt32(sdr["Broken"]);
                sm.date = Convert.ToDateTime(sdr["Date"]);
                
                lis.Add(sm);


            }

            sdr.Close();
            return lis;
        }
        
        public List<StockReportModel> Stockreport(int id)
        {
            StockReportModel sm = new StockReportModel();
            List<StockReportModel> lis = new List<StockReportModel>();
            SqlCommand sc = new SqlCommand("GetStockMovementById", connection.getcon());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sc.ExecuteReader();


            while (sdr.Read())
            {
                sm = new StockReportModel();
                //sm. = new ItemModel();
                //sm.Id = Convert.ToInt32(sdr["SMID"]);
                sm.StockIn = Convert.ToInt32(sdr["StockIn"]);
                sm.StockOut = Convert.ToInt32(sdr["StockOut"]);
                sm.Balance = Convert.ToInt32(sdr["Balance"]);
                sm.Description = sdr["Description"].ToString();
                sm.Broken = Convert.ToInt32(sdr["Broken"]);
                sm.Date = Convert.ToDateTime(sdr["Date"]);

                lis.Add(sm);


            }

            sdr.Close();
            return lis;
        }

        public StockMOvementModel GetStockById(int id)
        {
            StockMOvementModel sm = new StockMOvementModel();
            SqlCommand sc = new SqlCommand("GetStockMovementById", connection.getcon());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                sm.item = new ItemModel();
                sm.Id = Convert.ToInt32(sdr["SMID"]);
                sm.stockin = Convert.ToInt32(sdr["StockIn"]);
                sm.stockout = Convert.ToInt32(sdr["StockOut"]);
                sm.balance = Convert.ToInt32(sdr["Balance"]);
                sm.item.description = sdr["Description"].ToString();
                sm.broken = Convert.ToInt32(sdr["Broken"]);
                sm.date = Convert.ToDateTime(sdr["Date"]);
            }
            sdr.Close();
            return sm;
        }

        public void UpdateStockMovement()
        {
            SqlCommand sc = new SqlCommand("", connection.getcon());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("", sm.balance);
            sc.Parameters.AddWithValue("", sm.broken);
            sc.Parameters.AddWithValue("", sm.date);
            sc.Parameters.AddWithValue("", sm.Id);
            sc.Parameters.AddWithValue("", sm.item);
            sc.Parameters.AddWithValue("", sm.stockin);
            sc.Parameters.AddWithValue("", sm.stockout);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public void DeleteStockMovement()
        {
            SqlCommand sc = new SqlCommand("", connection.getcon());
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("", 0);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }
    }
}