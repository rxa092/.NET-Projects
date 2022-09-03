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
    public class ReportBusiness
    {
        public SalesOrderReportModel SOreport { get; set; }
        public DelieveryOrderReportModel DOreport { get; set; }
        public DelieveryChallanReportModel dcReport { get; set; }

        public GatePassReportModel gpreport { get; set; }

        public List<Diesel> PrintDiesel(DateTime start, DateTime end, string type)
        {
            List<Diesel> list = new List<Diesel>();
            SqlCommand sc = new SqlCommand("PrintDieselReport", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@start", start);
            sc.Parameters.AddWithValue("@end", end);
            sc.Parameters.AddWithValue("@type", type);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Diesel  d = new Diesel();
                d.Balance = Convert.ToDouble(sdr["Balance"]);
                d.CurrentReading = Convert.ToDouble(sdr["CurrentReading"]);
                d.Date = Convert.ToDateTime(sdr["Date"]).ToString("dd-MM-yyyy");
                d.DieselDispensery = Convert.ToDouble(sdr["DieselDispensery"]);
                d.DipRecordin = Convert.ToDouble(sdr["DipRecordin"]);
                d.LastReading = Convert.ToDouble(sdr["LastReading"]);
                d.OpeningDiesel = Convert.ToDouble(sdr["OpeningDiesel"]);
                d.Vehicle = sdr["Vehicle"].ToString();
                d.VehicleType = sdr["VehicleType"].ToString();
                list.Add(d);
            }
            sdr.Close();
            return list;
        }
        public List<StoreReportModel> StoreReport(int id)
        {
            List<StoreReportModel> ls = new List<StoreReportModel>();
            SqlCommand sc = new SqlCommand("GetStoreTransactionById", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                StoreReportModel st = new StoreReportModel();
                st.Balance = Convert.ToInt32(sdr["Balance"]);
                st.Date = Convert.ToDateTime( sdr["Date"]);
                st.EmployeeName = (sdr["EmployeeName"]).ToString();
                st.ItemName = (sdr["ItemName"]).ToString();
                st.Quantity = Convert.ToInt32(sdr["Quantity"]);
                st.Type = sdr["Type"].ToString();
                ls.Add(st);
            }
            sdr.Close();
            return ls;
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

        public  List<SalesOrderReportModel> GetSalesOrderReport(int id)
        {
            List<SalesOrderReportModel> lis = new List<SalesOrderReportModel>();
            SqlCommand sc = new SqlCommand("ReportSO", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                SOreport = new SalesOrderReportModel();
                SOreport.Description = sdr["Description"].ToString();
                SOreport.ClientName = sdr["ClientName"].ToString();
                SOreport.destination = sdr["destination"].ToString();
                SOreport.Date = Convert.ToDateTime(sdr["Date"]);
                SOreport.price = Convert.ToInt32(sdr["price"]);
                SOreport.quantity = Convert.ToInt32(sdr["quantity"]);
                SOreport.tax = Convert.ToDouble(sdr["tax"]);
                SOreport.total = Convert.ToDouble(sdr["total"]);
                SOreport.remarks = sdr["remarks"].ToString();
                SOreport.pallets = Convert.ToInt32(sdr["pallets"]);
                SOreport.SONO = Convert.ToInt32(sdr["SONO"]);
                SOreport.Final_Amount = Convert.ToDouble(sdr["Final_Amount"]);
                SOreport.Created = sdr["Created"].ToString();
                lis.Add(SOreport);
            }
            sdr.Close();
            return lis;
        }

        public List<DelieveryOrderReportModel> GetDelieveryOrderReport(int id)
        {
            List<DelieveryOrderReportModel> lis = new List<DelieveryOrderReportModel>();
            SqlCommand sc = new SqlCommand("ReportDO", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                DOreport = new DelieveryOrderReportModel();
                DOreport.ClientName = sdr["ClientName"].ToString();
                DOreport.Date = sdr["Date"].ToString();
                DOreport.Description = sdr["Description"].ToString();
                DOreport.destination = sdr["destination"].ToString();
                DOreport.DONO = Convert.ToInt32(sdr["DONO"]);
                DOreport.pallets = Convert.ToInt32(sdr["pallets"]);
                DOreport.quantity = Convert.ToInt32(sdr["quantity"]);
                lis.Add(DOreport);
            }
            sdr.Close();
            return lis;
        }

        public List<DelieveryChallanReportModel> GetDelieveryChallanReport(int id)
        {
            List<DelieveryChallanReportModel> lis = new List<DelieveryChallanReportModel>();
            SqlCommand sc = new SqlCommand("ReportDC", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                dcReport = new DelieveryChallanReportModel();
                dcReport.ClientName = sdr["ClientName"].ToString();
                dcReport.Date = sdr["Date"].ToString();
                dcReport.Description = sdr["Description"].ToString();
                dcReport.location = sdr["location"].ToString();
                dcReport.quantity = Convert.ToInt32(sdr["quantity"]);
                dcReport.DCNO = Convert.ToInt32(sdr["DCNO"]);
                dcReport.TruckNo = sdr["TruckNo"].ToString();
                dcReport.pallets = Convert.ToInt32(sdr["pallets"]);
                dcReport.remarks = sdr["remarks"].ToString();
                lis.Add(dcReport);
            }
            sdr.Close();
            return lis;
        }

        public List<GatePassReportModel> GetGatePassReport(int id)
        {
            List<GatePassReportModel> lis = new List<GatePassReportModel>();
            SqlCommand sc = new SqlCommand("ReportGP", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                gpreport = new GatePassReportModel();
                gpreport.ClientName = sdr["ClientName"].ToString();
                gpreport.Date = sdr["Date"].ToString();
                gpreport.Description = sdr["Description"].ToString();
                gpreport.location = sdr["location"].ToString();
                gpreport.quantity = Convert.ToInt32(sdr["quantity"]);
                gpreport.GPNO = Convert.ToInt32(sdr["GPNO"]);
                gpreport.TruckNo = sdr["TruckNo"].ToString();
                gpreport.pallets = Convert.ToInt32(sdr["pallets"]);
                gpreport.remarks = sdr["remarks"].ToString();
                lis.Add(gpreport);
            }
            sdr.Close();
            return lis;
        }

        public List<InwardRawMaterial> GetInwardReport(DateTime start,DateTime end)
        {
            List<InwardRawMaterial> lis = new List<InwardRawMaterial>();
            SqlCommand sc = new SqlCommand("ReportInwardRawMaterial", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@start", start);
            sc.Parameters.AddWithValue("@end", end);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                InwardRawMaterial rm = new InwardRawMaterial();
                rm.date = Convert.ToDateTime(sdr["date"]);
                rm.Quantity = Convert.ToInt32(sdr["Quantity"]);
                rm.RMName = sdr["RMName"].ToString();
                rm.ReferenceNo = Convert.ToInt32(sdr["ReferenceNo"]);
                rm.Remarks = sdr["Remarks"].ToString();
                rm.Vehicle = sdr["Vehicle"].ToString();
                rm.Vendor_name = sdr["Vendor_name"].ToString();
                rm.TimeIn = sdr["TimeIn"].ToString();
                lis.Add(rm);
            }
            sdr.Close();
            return lis;

        }


        public List<Production> GetProductionReport (int id)
        {
            List<Production> list = new List<Production>();
            SqlCommand sc = new SqlCommand("ProductionDetail", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {

                Production p = new Production();
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
                p.Description = sdr["Description"].ToString();
                p.recieving = Convert.ToDouble(sdr["recieving"]);
                p.remarks = sdr["remarks"].ToString();
                p.Name = sdr["Name"].ToString();
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
                list.Add(p);
            }
            sdr.Close();
            return list;
        }


        public List<DispatchReport> GetDispatchWithRate(int id)
        {
            List<DispatchReport> lis = new List<DispatchReport>();
            SqlCommand sc = new SqlCommand("ReportDispatchReport", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                DispatchReport dp = new DispatchReport();
                dp.Amount = Convert.ToDouble(sdr["Amount"]);
                dp.ClientName = sdr["ClientName"].ToString();
                dp.Cube_Pallets = Convert.ToInt32(sdr["Cube_Pallets"]);
                dp.Date = Convert.ToDateTime(sdr["Date"]);
                dp.DC = Convert.ToInt32(sdr["DC"]);
                dp.DO = Convert.ToInt32(sdr["DO"]);
                dp.PO = sdr["PO"].ToString();
                dp.Description = sdr["Description"].ToString();
                dp.Quantity = Convert.ToInt32(sdr["Quantity"]);
                dp.Rate = Convert.ToInt32(sdr["Rate"]);
                dp.Remarks = sdr["Remarks"].ToString();
                dp.Truck = sdr["Truck"].ToString();
                lis.Add(dp);
            }
            sdr.Close();
            return lis;
        }

        public List<CementModel> CementReport(DateTime start, DateTime end)
        {
            List<CementModel> lis = new List<CementModel>();
            SqlCommand sc = new SqlCommand("ReportCement", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@start", start);
            sc.Parameters.AddWithValue("@end", end);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                CementModel  cm = new CementModel();
                cm.Bulker = sdr["Bulker"].ToString();
                cm.date = Convert.ToDateTime(sdr["date"]);
                cm.PlantLocation = sdr["PlantLocation"].ToString();
                cm.Quality = sdr["Quality"].ToString();
                cm.Quantity = Convert.ToDouble(sdr["Quantity"]);
                cm.Silo = Convert.ToInt16(sdr["Silo"]);
                cm.Supplier = sdr["Supplier"].ToString();
                lis.Add(cm);
            }
            sdr.Close();
            return lis;
        }

        public List<MouldReport> mouldReport(DateTime start , DateTime end)
        {
            List<MouldReport> lis = new List<MouldReport>();
            SqlCommand sc = new SqlCommand("", connection.getcon());
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("", Convert.ToDateTime(start));
            sc.Parameters.AddWithValue("", Convert.ToDateTime(end));
            connection.sdr = sc.ExecuteReader();
            while (connection.sdr.Read())
            {
                MouldReport mr = new MouldReport();
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




    }
}