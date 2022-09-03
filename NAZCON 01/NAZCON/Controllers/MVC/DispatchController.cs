using Microsoft.Reporting.WebForms;
using NAZCON.Models.Business_Layer;
using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAZCON.Controllers.MVC
{
    public class DispatchController : Controller
    {
        // GET: Dispatch
        [HttpGet]
        [AppAuth(PageName ="DispatchAdd")]
        public ActionResult Add()
        {
            ViewBag.order = new SelectList(new DcBusiness().get_do());
            return View();

        }
        [AppAuth(PageName = "DispatchAdd")]
        [HttpPost]
        public ActionResult Add(DispatchReport dr)
        {
            DIspatchBusiness db = new DIspatchBusiness();
            db.dp = dr;
            db.AddDispatch();
          return  RedirectToAction("Show");
        }
        [AppAuth(PageName = "DispatchShow")]
        public ActionResult Show()
        {
            return View(new DIspatchBusiness().ShowDispatch());
        }

        public ActionResult DispatchCEO()
        {
            return View();
        }

        public ActionResult CEODispatch(DateTime start , DateTime end , int product , int client)
        {
            return View(new DIspatchBusiness().SpecialDispatch(start, end, client, product));
        }


        [AppAuth(PageName ="DispatchReportRate")]
        public ActionResult DispatchWithRateReport(int id)
        {
            LocalReport lr = new LocalReport();

            string path = Path.Combine(Server.MapPath("~/Reports"), "DIpatchReportWithRate.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            ReportBusiness rb = new ReportBusiness();
            List<DispatchReport> lsreport = rb.GetDispatchWithRate(id);


            ReportDataSource rd = new ReportDataSource("DispatchReportwithRate", lsreport);
            new LocalReport().ListRenderingExtensions();
            lr.DataSources.Add(rd);
            string reportType = "Word";
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + reportType + "</OutputFormat>" +
            "  <PageWidth>11in</PageWidth>" +
            "  <PageHeight>8.5in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>0.5in</MarginLeft>" +
            "  <MarginRight>0.5in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);


            return File(renderedBytes, mimeType);

        }


        [AppAuth(PageName = "DIspatchReport")]
        public ActionResult DispatchReport(int id)
        {
            LocalReport lr = new LocalReport();

            string path = Path.Combine(Server.MapPath("~/Reports"), "DipatchReportWithoutRate.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            ReportBusiness rb = new ReportBusiness();
            List<DispatchReport> lsreport = rb.GetDispatchWithRate(id);


            ReportDataSource rd = new ReportDataSource("DispatchReportWithoutRate", lsreport);
            new LocalReport().ListRenderingExtensions();
            lr.DataSources.Add(rd);
            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + reportType + "</OutputFormat>" +
            "  <PageWidth>11in</PageWidth>" +
            "  <PageHeight>8.5in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>0.5in</MarginLeft>" +
            "  <MarginRight>0.5in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);


            return File(renderedBytes, mimeType);

        }



    }
}