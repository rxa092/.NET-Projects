using NAZCON.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NAZCON.Models.Business_Layer
{
    public class ProductionBusiness
    {
        public Production p { get; set; }
        public void AddProduction()
        {
            p.totalproductionunits = p.agradeunits + p.bgradeunits + p.brokenbymachineunits + p.brokenbyoperatorunits;
            p.totalproductionsteelapllets = p.Agradesteelpallets + p.bgradesteelpallets + p.bokenbymachinepallets + p.brokenbyoperatorpallets;
            p.actualefficiency = ( p.totalproductionunits/p.efficiency100) * 100;

            SqlCommand sc = new SqlCommand("AddProduction", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@actualcycletime", p.actualcycletime);
            sc.Parameters.AddWithValue("@actualefficiency", p.actualefficiency);
            sc.Parameters.AddWithValue("@actualstarttime", p.actualstarttime);
            sc.Parameters.AddWithValue("@agradesteelpallets", p.Agradesteelpallets);
            sc.Parameters.AddWithValue("@agradeunits", p.agradeunits);
            sc.Parameters.AddWithValue("@balance", p.balance);
            sc.Parameters.AddWithValue("@bgradesteelpallets", p.bgradesteelpallets);
            sc.Parameters.AddWithValue("@bgradeunits", p.bgradeunits);
            sc.Parameters.AddWithValue("@brokenbymachinepallets", p.bokenbymachinepallets);
            sc.Parameters.AddWithValue("@brokenbymachineunits", p.brokenbymachineunits);
            sc.Parameters.AddWithValue("@brokenbyoperatorpallets", p.brokenbyoperatorpallets);
            sc.Parameters.AddWithValue("@brokenbyoperatorunits", p.brokenbyoperatorunits);
            sc.Parameters.AddWithValue("@consumption", p.consumption);
            sc.Parameters.AddWithValue("@efficiency100", p.efficiency100);
            sc.Parameters.AddWithValue("@mixweight", p.mixweight);
            sc.Parameters.AddWithValue("@noofpiecesinonemix", p.noofpiecesinonemix);
            sc.Parameters.AddWithValue("@noofpiecesinonepallet", p.noofpiecesinonepallet);
            sc.Parameters.AddWithValue("@noofplatesinonemix", p.noofplatesinonemix);
            sc.Parameters.AddWithValue("@opening", p.opening);
            sc.Parameters.AddWithValue("@productid", p.ProductId);
            sc.Parameters.AddWithValue("@singlepieceweight", p.singlepieceweight);
            sc.Parameters.AddWithValue("@recieving", p.recieving);
            sc.Parameters.AddWithValue("@remarks", p.remarks);
            sc.Parameters.AddWithValue("@shiftinchargeid", p.shiftinchargeid);
            sc.Parameters.AddWithValue("@size", p.size);
            sc.Parameters.AddWithValue("@totalmixes", p.totalmixes);
            sc.Parameters.AddWithValue("@totalproductionsteelpallets", p.totalproductionsteelapllets);
            sc.Parameters.AddWithValue("@totalproductionunits", p.totalproductionunits);
            sc.Parameters.AddWithValue("@weight", p.weight);
            sc.Parameters.AddWithValue("@Date", p.date);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
            

        }

        public void PRawMaterial()
        {
            p.totalproductionunits = p.agradeunits + p.bgradeunits + p.brokenbymachineunits + p.brokenbyoperatorunits;
            p.rawmaterial.TotalConsumption = p.rawmaterial.TotalWeightInSingleMix * p.totalmixes;
            p.rawmaterial.AggregateUse = p.rawmaterial.TotalConsumption/p.totalproductionunits;
            SqlCommand sc = new SqlCommand("AddPRaw", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@Aggregateuse", p.rawmaterial.AggregateUse);
            sc.Parameters.AddWithValue("@Id", p.rawmaterial.RMId);
            sc.Parameters.AddWithValue("@TotalConsumption", p.rawmaterial.TotalConsumption);
            sc.Parameters.AddWithValue("@TotalWeightinSingleMix", p.rawmaterial.TotalWeightInSingleMix);
            SqlDataReader sdr = sc.ExecuteReader();
            sdr.Close();
        }

        public List<Production> GetAllProductions()
        {
            List<Production> list = new List<Production>();
            SqlCommand sc = new SqlCommand("GetAllProductions", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Production p = new Production();
                p.ProductionId = Convert.ToInt32(sdr["ProductionId"]);
                p.ProductName = sdr["Description"].ToString();
                p.date = Convert.ToString(sdr["Date"]);
                p.totalproductionsteelapllets = Convert.ToDouble(sdr["totalproductionsteelapllets"]);
                p.totalproductionunits = Convert.ToDouble(sdr["totalproductionunits"]);
                p.shiftinchargename = sdr["Name"].ToString();
                list.Add(p);
            }
            sdr.Close();
            return list;
        }

        public List<Production> details(int id)
        {
            List<Production> lis = new List<Production>();
            Production p;
            SqlCommand sc = new SqlCommand("ProductionDetail", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                p = new Production();
                p.rawmaterial = new ProductionRawMaterial();
                p.actualcycletime = Convert.ToDouble(sdr["actualcycletime"]);
                p.actualefficiency = Convert.ToDouble(sdr["actualefficiency"]);
                p.actualstarttime = Convert.ToString(sdr["actualstarttime"]);
                p.Agradesteelpallets = Convert.ToDouble(sdr["Agradesteelpallets"]);
                p.agradeunits = Convert.ToDouble(sdr["agradeunits"]);
                p.balance = Convert.ToDouble(sdr["balance"]);
                p.bgradesteelpallets = Convert.ToDouble(sdr["bgradesteelpallets"]);
                p.bgradeunits = Convert.ToDouble(sdr["bgradeunits"]);
                p.bokenbymachinepallets = Convert.ToDouble(sdr["bokenbymachinepallets"]);
                p.brokenbymachineunits = Convert.ToDouble(sdr["brokenbymachineunits"]);
                p.brokenbyoperatorpallets = Convert.ToDouble(sdr["brokenbyoperatorpallets"]);
                p.brokenbyoperatorunits = Convert.ToDouble(sdr["brokenbyoperatorunits"]);
                p.consumption = Convert.ToDouble(sdr["consumption"]);
                p.date = Convert.ToString(sdr["date"]);
                p.efficiency100 = Convert.ToDouble(sdr["efficiency100"]);
                p.mixweight = Convert.ToDouble(sdr["mixweight"]);
                p.noofpiecesinonemix = Convert.ToDouble(sdr["noofpiecesinonemix"]);
                p.noofpiecesinonepallet = Convert.ToDouble(sdr["noofpiecesinonepallet"]);
                p.noofplatesinonemix = Convert.ToDouble(sdr["noofplatesinonemix"]);
                p.opening = Convert.ToDouble(sdr["opening"]);
                p.ProductName = sdr["Description"].ToString();
                p.recieving = Convert.ToDouble(sdr["recieving"]);
                p.remarks = sdr["remarks"].ToString();
                p.shiftinchargename = sdr["Name"].ToString();
                p.singlepieceweight = Convert.ToDouble(sdr["singlepieceweight"]);
                p.size = Convert.ToDouble(sdr["size"]);
                p.totalmixes = Convert.ToDouble(sdr["totalmixes"]);
                p.totalproductionsteelapllets = Convert.ToDouble(sdr["totalproductionsteelapllets"]);
                p.totalproductionunits = Convert.ToDouble(sdr["totalproductionunits"]);
                p.weight = Convert.ToDouble(sdr["weight"]);
                p.AggregateUsed = Convert.ToDouble(sdr["AggregateUsed"]);
                p.TotalConsumption = Convert.ToDouble(sdr["TotalConsumption"]);
                p.rawmaterial.TotalWeightInSingleMix = Convert.ToDouble(sdr["TotalWeightSingleMix"]);
                p.rawmaterial.Name = sdr["RMName"].ToString();
                lis.Add(p);
            }
            sdr.Close();
            return lis;
        }


    }
}