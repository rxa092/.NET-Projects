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
    public class CementController : Controller
    {
        // GET: Cement
        [AppAuth(PageName ="CementAdd")]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [AppAuth(PageName = "CementAdd")]
        [HttpPost]
        public ActionResult Add(CementModel cm)
        {
            CementBusiness cb = new CementBusiness();
            cb.cm = cm;
            cb.AddCement();
            return View(new CementModel());
        }
        [AppAuth(PageName = "CementShow")]
        [HttpGet]
        public ActionResult Show()
        {
            return View(new CementBusiness().ShowCement());
        }
        [AppAuth(PageName = "CementShow")]
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(new CementBusiness().GetCementById(id));
        }
        [AppAuth(PageName = "CementShow")]
        [HttpPost]
        public ActionResult Update(CementModel cm)
        {
            CementBusiness cb = new CementBusiness();
            cb.cm = cm;
            cb.UpdateCement();
            return RedirectToAction("Show");
        }
        [AppAuth(PageName = "CementShow")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            new CementBusiness().DeleteCement(id);
            return RedirectToAction("Show");
        }
        [AppAuth(PageName = "CementReport")]
        [HttpGet]
        public ActionResult Report()
        {
            return View();
        }
        [AppAuth(PageName = "CementReport")]
        [HttpPost]
        public ActionResult Report(DateTime start,DateTime end)
        {
            LocalReport lr = new LocalReport();

            string path = Path.Combine(Server.MapPath("~/Reports"), "CementReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            ReportBusiness rb = new ReportBusiness();
            List<CementModel> lsreport = rb.CementReport(start, end);


            ReportDataSource rd = new ReportDataSource("CementDataSet", lsreport);
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