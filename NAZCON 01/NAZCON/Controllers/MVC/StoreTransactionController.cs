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
    public class StoreTransactionController : Controller
    {
        // GET: StoreTransaction

        public ActionResult StoreTransactionReport(int id)
        {
            LocalReport lr = new LocalReport();

            string path = Path.Combine(Server.MapPath("~/Reports"), "StoreReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }

            List<StoreReportModel> cm = new List<StoreReportModel>();
            cm = new ReportBusiness().StoreReport(id);
            //Data Set
            ReportDataSource rd = new ReportDataSource("StoreReportDataSet", cm);
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


        [HttpGet]
        public ActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Add(StoreTransaction st)
        {
            StoretransactionBusiness stb = new StoretransactionBusiness();
            stb.st = st;
            stb.AddTransaction();
            return RedirectToAction("Show");
        }

        public ActionResult Show()
        {
            StoretransactionBusiness stb = new StoretransactionBusiness();
            return View(stb.AllStoreTransaction());
        }
    }
}