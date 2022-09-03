using Microsoft.Reporting.WebForms;
using NAZCON.Models.Business_Layer;
using NAZCON.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAZCON.Controllers.MVC
{
    public class ReportController : Controller
    {
        // GET: Report
        //public ActionResult SOreport(int id)
        //{
        //    LocalReport lr = new LocalReport();

        //    string path = Path.Combine(Server.MapPath("~/Reports"), "SalesOrderReport.rdlc");
        //    if (System.IO.File.Exists(path))
        //    {
        //        lr.ReportPath = path;
        //    }
        //    ReportBusiness rb = new ReportBusiness();
        //    List<SalesOrderReportModel> lsreport = rb.GetSalesOrderReport(id);
            

        //    ReportDataSource rd = new ReportDataSource("SalesOrderDataSet", lsreport);
        //  //  ReportDataSource rd2 = new ReportDataSource("SalesOrderDataSet2", lsreport);
        //    new LocalReport().ListRenderingExtensions();
        //    lr.DataSources.Add(rd);
        //  //  lr.DataSources.Add(rd2);
        //    string reportType = "Word";
        //    string mimeType;
        //    string encoding;
        //    string fileNameExtension;

        //    string deviceInfo =

        //    "<DeviceInfo>" +
        //    "  <OutputFormat>" + reportType + "</OutputFormat>" +
        //    "  <PageWidth>11in</PageWidth>" +
        //    "  <PageHeight>8.5in</PageHeight>" +
        //    "  <MarginTop>0.5in</MarginTop>" +
        //    "  <MarginLeft>0.5in</MarginLeft>" +
        //    "  <MarginRight>0.5in</MarginRight>" +
        //    "  <MarginBottom>0.5in</MarginBottom>" +
        //    "</DeviceInfo>";

        //    Warning[] warnings;
        //    string[] streams;
        //    byte[] renderedBytes;

        //    renderedBytes = lr.Render(
        //        reportType,
        //        deviceInfo,
        //        out mimeType,
        //        out encoding,
        //        out fileNameExtension,
        //        out streams,
        //        out warnings);


        //    return File(renderedBytes, mimeType);
        //}

        //public ActionResult DOreport()
        //{
        //    LocalReport lr = new LocalReport();

        //    string path = Path.Combine(Server.MapPath("~/Reports"), "DelieveryOrderReport.rdlc");
        //    if (System.IO.File.Exists(path))
        //    {
        //        lr.ReportPath = path;
        //    }
        //    ReportBusiness rb = new ReportBusiness();
        //    List<DelieveryOrderReportModel> lsreport = rb.GetDelieveryOrderReport();


        //    ReportDataSource rd = new ReportDataSource("DelieveryOrderDataset", lsreport);
        //    new LocalReport().ListRenderingExtensions();
        //    lr.DataSources.Add(rd);
        //    string reportType = "Word";
        //    string mimeType;
        //    string encoding;
        //    string fileNameExtension;

        //    string deviceInfo =

        //    "<DeviceInfo>" +
        //    "  <OutputFormat>" + reportType + "</OutputFormat>" +
        //    "  <PageWidth>11in</PageWidth>" +
        //    "  <PageHeight>8.5in</PageHeight>" +
        //    "  <MarginTop>0.5in</MarginTop>" +
        //    "  <MarginLeft>0.5in</MarginLeft>" +
        //    "  <MarginRight>0.5in</MarginRight>" +
        //    "  <MarginBottom>0.5in</MarginBottom>" +
        //    "</DeviceInfo>";

        //    Warning[] warnings;
        //    string[] streams;
        //    byte[] renderedBytes;

        //    renderedBytes = lr.Render(
        //        reportType,
        //        deviceInfo,
        //        out mimeType,
        //        out encoding,
        //        out fileNameExtension,
        //        out streams,
        //        out warnings);


        //    return File(renderedBytes, mimeType);
        //}

        //public ActionResult GPreport()
        //{
        //    LocalReport lr = new LocalReport();

        //    string path = Path.Combine(Server.MapPath("~/Reports"), "GatePassReport.rdlc");
        //    if (System.IO.File.Exists(path))
        //    {
        //        lr.ReportPath = path;
        //    }
        //    ReportBusiness rb = new ReportBusiness();
        //    List<GatePassReportModel> lsreport = rb.GetGatePassReport();


        //    ReportDataSource rd = new ReportDataSource("GatePassDataset", lsreport);
        //    new LocalReport().ListRenderingExtensions();
        //    lr.DataSources.Add(rd);
        //    string reportType = "Word";
        //    string mimeType;
        //    string encoding;
        //    string fileNameExtension;

        //    string deviceInfo =

        //    "<DeviceInfo>" +
        //    "  <OutputFormat>" + reportType + "</OutputFormat>" +
        //    "  <PageWidth>11in</PageWidth>" +
        //    "  <PageHeight>8.5in</PageHeight>" +
        //    "  <MarginTop>0.5in</MarginTop>" +
        //    "  <MarginLeft>0.5in</MarginLeft>" +
        //    "  <MarginRight>0.5in</MarginRight>" +
        //    "  <MarginBottom>0.5in</MarginBottom>" +
        //    "</DeviceInfo>";

        //    Warning[] warnings;
        //    string[] streams;
        //    byte[] renderedBytes;

        //    renderedBytes = lr.Render(
        //        reportType,
        //        deviceInfo,
        //        out mimeType,
        //        out encoding,
        //        out fileNameExtension,
        //        out streams,
        //        out warnings);


        //    return File(renderedBytes, mimeType);
        //}

        //public ActionResult DCreport()
        //{
        //    LocalReport lr = new LocalReport();

        //    string path = Path.Combine(Server.MapPath("~/Reports"), "DelieveryChallanReport.rdlc");
        //    if (System.IO.File.Exists(path))
        //    {
        //        lr.ReportPath = path;
        //    }
        //    ReportBusiness rb = new ReportBusiness();
        //    List<DelieveryChallanReportModel> lsreport = rb.GetDelieveryChallanReport();


        //    ReportDataSource rd = new ReportDataSource("DelieveryChallanDataset", lsreport);
        //    new LocalReport().ListRenderingExtensions();
        //    lr.DataSources.Add(rd);
        //    string reportType = "Word";
        //    string mimeType;
        //    string encoding;
        //    string fileNameExtension;

        //    string deviceInfo =

        //    "<DeviceInfo>" +
        //    "  <OutputFormat>" + reportType + "</OutputFormat>" +
        //    "  <PageWidth>11in</PageWidth>" +
        //    "  <PageHeight>8.5in</PageHeight>" +
        //    "  <MarginTop>0.5in</MarginTop>" +
        //    "  <MarginLeft>0.5in</MarginLeft>" +
        //    "  <MarginRight>0.5in</MarginRight>" +
        //    "  <MarginBottom>0.5in</MarginBottom>" +
        //    "</DeviceInfo>";

        //    Warning[] warnings;
        //    string[] streams;
        //    byte[] renderedBytes;

        //    renderedBytes = lr.Render(
        //        reportType,
        //        deviceInfo,
        //        out mimeType,
        //        out encoding,
        //        out fileNameExtension,
        //        out streams,
        //        out warnings);


        //    return File(renderedBytes, mimeType);
        //}
    }
}