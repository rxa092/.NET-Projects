using Microsoft.Reporting.WebForms;
using NAZCON.Models.Business_Layer;
using NAZCON.Models.EntityModel;
using NAZCON.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAZCON.Controllers.MVC
{
    public class StockMovementController : Controller
    {
        // GET: StockMovement
        [AppAuth(PageName = "StockMovementShow")]
        public ActionResult StockMovementReport(int id)
        {
            LocalReport lr = new LocalReport();

            string path = Path.Combine(Server.MapPath("~/Reports"), "StockReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }

            List<StockReportModel> cm = new List<StockReportModel>();
            cm = new ReportBusiness().Stockreport(id);

            ReportDataSource rd = new ReportDataSource("StockDataSet", cm);
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
        [AppAuth(PageName = "StockMovementAdd")]
        [HttpGet]
        public ActionResult Add()
        {
            SoBusiness s = new SoBusiness();
            ViewBag.myitems = new SelectList(s.item(), "Item", "Description");
            return View();
        }
        [AppAuth(PageName = "StockMovementAdd")]
        [HttpPost]
        public ActionResult Add(StockMOvementModel sm)
        {
            StockMovementBusiness smb = new StockMovementBusiness();
            smb.sm = sm;
            smb.AddStockMovement();
            return RedirectToAction("Show");
        }
        [AppAuth(PageName = "StockMovementShow")]
        [HttpGet]
        public ActionResult Show()
        {
            StockMovementBusiness smb = new StockMovementBusiness();
            return View(smb.ShowStockMovement());
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(new StockMovementBusiness().GetStockById(id));
        }

        [HttpPost]
        public ActionResult Update(StockMOvementModel sm)
        {
            StockMovementBusiness smb = new StockMovementBusiness();
            smb.sm = sm;
            
            return RedirectToAction("Show");
        }
    }
}