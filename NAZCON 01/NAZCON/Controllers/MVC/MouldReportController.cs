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
    public class MouldReportController : Controller
    {
        // GET: MouldReport
        [HttpGet]
        [AppAuth(PageName = "MouldReportAdd")]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [AppAuth(PageName = "MouldReportAdd")]
        public ActionResult Add(MouldReport mr)
        {
            MouldReportBusiness mrb = new MouldReportBusiness();
            mrb.mr = mr;
            mrb.AddMouldReport();
            return View();
        }

        [HttpGet]
        [AppAuth(PageName = "MouldReportShow")]
        public ActionResult Show()
        {
            return View(new MouldReportBusiness().AllMouldReport());
        }

        [HttpGet]
        [AppAuth(PageName = "MouldReportShow")]
        public ActionResult Update(int id)
        {
            return View(new MouldReportBusiness().SpecificMouldReport(id));
        }

        [HttpPost]
        [AppAuth(PageName = "MouldReportShow")]
        public ActionResult Update(MouldReport mr)
        {
            MouldReportBusiness mrb = new MouldReportBusiness();
            mrb.mr = mr;
            mrb.UpdateMouldReport();
            return RedirectToAction("Show");
        }

        [HttpGet]
        [AppAuth(PageName = "MouldReportShow")]
        public ActionResult Delete(int id)
        {
            new MouldReportBusiness().DeleteReport(id);
            return RedirectToAction("Show");
        }

        [HttpGet]
        public ActionResult Print(DateTime start , DateTime end)
        {
            LocalReport lr = new LocalReport();

            string path = Path.Combine(Server.MapPath("~/Reports"), "DOReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            ReportBusiness rb = new ReportBusiness();
            List<MouldReport> lsreport = rb.mouldReport(start,end);


            ReportDataSource rd = new ReportDataSource("DODataSet", lsreport);
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
    }
}