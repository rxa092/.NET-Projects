using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeGenerator
{
    class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        SqlConnection serverconnection = new SqlConnection("Data Source=www.nazirconcrete.com;Initial Catalog=nazircon_concrete;Uid=nazircon_Muhammad_Raza; password=FUCK_OFF_123");
        SqlConnection connection = new SqlConnection("Data Source=RAZA-PC\\SQL12;Initial Catalog=Barcode;Integrated Security=True");
        public void ConnectToServer()
        {
            //SqlConnection connection = new SqlConnection("Data Source=www.nazirconcrete.com;Initial Catalog=nazircon_concrete;Uid=nazircon_Muhammad_Raza; password=FUCK_OFF_123");
            //connection.Open();
            //connection.Close();
        }

        public Dictionary<string, int> getProducts()
        {
            if (Form1.CheckForInternetConnection())
            {
                //SqlConnection connection = new SqlConnection("Data Source=www.nazirconcrete.com;Initial Catalog=nazircon_concrete;Uid=nazircon_Muhammad_Raza; password=FUCK_OFF_123");
                serverconnection.Open();
                Dictionary<string, int> products = new Dictionary<string, int>();
                SqlCommand sc = new SqlCommand("Show_items", serverconnection);
                sc.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader sdr = sc.ExecuteReader();
                while (sdr.Read())
                {
                    products.Add(sdr["Description"].ToString(), (int)sdr["ItemID"]);
                }
                sdr.Close();
                serverconnection.Close();
                return products;
            }
            else
            {
                return new Dictionary<string, int>();
            }
            
        }

        public int LastID(DateTime date)
        {

            serverconnection.Open();
            SqlCommand sc = new SqlCommand("GetLastCount", serverconnection);
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@date", date);
            SqlDataReader sdr = sc.ExecuteReader();
            int value = 0;
            if (sdr.Read())
            {
                if (date == Convert.ToDateTime(sdr["Date"]))
                {
                    value = (int)sdr["Count"];
                }

            }
            sdr.Close();
            serverconnection.Close();
            return value;
        }

        public static Barcode barcode;

        public void StockOut(string barcode)
        {
            bool internet = Form1.CheckForInternetConnection();
            SqlCommand sc;
            SqlDataReader sdr;
            if (internet)
            {
                serverconnection.Open();
                sc = new SqlCommand("OutStockUsingBarcode", connection);
                sc.CommandType = System.Data.CommandType.StoredProcedure;
                sc.Parameters.AddWithValue("@barcode", barcode);
                sdr = sc.ExecuteReader();
                sdr.Close();
                serverconnection.Close();
            }
            //update = internet;
            //connection = new SqlConnection("Data Source=RAZA-PC\\SQL12;Initial Catalog=Barcode;Integrated Security=True");
            //connection.Open();
            //sc = new SqlCommand("StockOut", connection);
            //sc.CommandType = System.Data.CommandType.StoredProcedure;
            //sc.Parameters.AddWithValue("@barcode", Convert.ToDecimal(barcode));
            //sc.Parameters.AddWithValue("@uploaded", update);
            //sdr = sc.ExecuteReader();
            //sdr.Close();
            //connection.Close();

        }

        public void StockIn(string barcode)
        {
            bool internet = Form1.CheckForInternetConnection();
            //bool internet = false;
 
            SqlCommand sc;
            SqlDataReader sdr;
            if (internet)

            {
                serverconnection.Open();
                sc = new SqlCommand("AddStockUsingBarcode", serverconnection);
                sc.CommandType = System.Data.CommandType.StoredProcedure;
                sc.Parameters.AddWithValue("@barcode", barcode);
                sdr = sc.ExecuteReader();
                sdr.Close();
                serverconnection.Close();
            }
            //connection = new SqlConnection("Data Source=RAZA-PC\\SQL12;Initial Catalog=Barcode;Integrated Security=True");
            //connection.Open();
            //sc = new SqlCommand("StockIn", connection);
            //sc.CommandType = System.Data.CommandType.StoredProcedure;
            //sc.Parameters.AddWithValue("@barcode", barcode);
            //sc.Parameters.AddWithValue("@uploaded", internet);
            //sdr = sc.ExecuteReader();
            //sdr.Close();
            //connection.Close();

        }

        //Work Remaining
        public void GetBarcode(string barcode)
        {
            Barcode b = new Barcode();
            serverconnection.Open();
            SqlCommand sc = new SqlCommand("", serverconnection);
            sc.CommandType = System.Data.CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("", barcode);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                b.BarcodeId = sdr[""].ToString();
                b.date = Convert.ToDateTime(sdr[""]).Date;
                b.Quantity = Convert.ToInt32(sdr[""]);
                b.ProductName = sdr[""].ToString();
                b.ShiftName = sdr[""].ToString();
            }
            Product.barcode = b;
        }

        public void NewStock(string barcode, DateTime date, int product, int shift, int quantity, int count)
        {
            bool internet = true;
            //bool internet = false;
            bool update = false;
            SqlCommand sc;
            SqlDataReader sdr;
            if (internet)
            {
                update = internet;
                serverconnection.Open();
                sc = new SqlCommand("Addbarcode", serverconnection);
                sc.CommandType = System.Data.CommandType.StoredProcedure;
                sc.Parameters.AddWithValue("@barcode", barcode);
                sc.Parameters.AddWithValue("@date", date.Date);
                sc.Parameters.AddWithValue("@product", product);
                sc.Parameters.AddWithValue("@shift", shift);
                sc.Parameters.AddWithValue("@quantity", quantity);
                sc.Parameters.AddWithValue("@count", count);
                sdr = sc.ExecuteReader();
                sdr.Close();
                serverconnection.Close();
                

            }
            //else
            //{
            //    status = "Created but not updated";
            //}

            //connection = new SqlConnection("Data Source=RAZA-PC\\SQL12;Initial Catalog=Barcode;Integrated Security=True");
            //connection.Open();
            //sc = new SqlCommand("Addbarcode", connection);
            //sc.CommandType = System.Data.CommandType.StoredProcedure;
            //sc.Parameters.AddWithValue("@barcode", barcode);
            //sc.Parameters.AddWithValue("@date", date.Date);
            //sc.Parameters.AddWithValue("@product", product);
            //sc.Parameters.AddWithValue("@shift", shift);
            //sc.Parameters.AddWithValue("@quantity", quantity);
            //sc.Parameters.AddWithValue("@count", count);
            //sc.Parameters.AddWithValue("@update", update);
            //sc.Parameters.AddWithValue("@status", status);
            //sdr = sc.ExecuteReader();
            //sdr.Close();
            //connection.Close();

        }

        public bool CheckValidity(string barcode, string operation)
        {
            if (operation == "IN")
            {

            }
            else
            {

            }
            return true;
        }
        //public void RunPendingTask()
        //{
        //    List<Barcode> lis = new List<Barcode>();
        //    SqlCommand sc;
        //    SqlDataReader sdr;
        //    SqlConnection connection;
        //    bool internet = Form1.CheckForInternetConnection();
        //    connection = new SqlConnection("Data Source=RAZA-PC\\SQL12;Initial Catalog=Barcode;Integrated Security=True");
        //    connection.Open();
        //    sc = new SqlCommand("", connection);
        //    sc.CommandType = System.Data.CommandType.StoredProcedure;
        //    sdr = sc.ExecuteReader();
        //    while (sdr.Read())
        //    {
        //        Barcode b = new Barcode();
        //        b.BarcodeId = "";
        //        b.Count = 0;
        //        b.date = DateTime.Now;
        //        b.ProductId = 0;
        //        b.Quantity = 0;
        //        b.Shift = 0;
        //        lis.Add(b);
        //    }
        //    sdr.Close();
        //    connection.Close();
        //    connection = new SqlConnection("Data Source=RAZA-PC\\SQL12;Initial Catalog=nazeer_concrete;Integrated Security=True");
        //    connection.Open();
        //    for (int i = 0; i < lis.Count; i++)
        //    {
        //        sc = new SqlCommand("Addbarcode", connection);
        //        sc.CommandType = System.Data.CommandType.StoredProcedure;
        //        sc.Parameters.AddWithValue("@barcode", lis[i].BarcodeId);
        //        sc.Parameters.AddWithValue("@date", lis[i].date);
        //        sc.Parameters.AddWithValue("@product", lis[i].ProductId);
        //        sc.Parameters.AddWithValue("@shift", lis[i].Shift);
        //        sc.Parameters.AddWithValue("@quantity", lis[i].Quantity);
        //        sc.Parameters.AddWithValue("@count", lis[i].Count);
        //        sdr = sc.ExecuteReader();
        //        sdr.Close();
        //    }
        //    connection.Close();
        //    connection = new SqlConnection("Data Source=RAZA-PC\\SQL12;Initial Catalog=Barcode;Integrated Security=True");
        //    connection.Open();
        //    lis = new List<Barcode>();
        //    sc = new SqlCommand("", connection);
        //    sdr = sc.ExecuteReader();
        //    while (sdr.Read())
        //    {
        //        Barcode b = new Barcode();
        //        b.BarcodeId = "";

        //    }



        //}
    }
}
