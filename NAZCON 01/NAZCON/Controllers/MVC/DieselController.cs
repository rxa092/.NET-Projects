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
    public class DieselController : Controller
    {
        // GET: Diesel
        [AppAuth(PageName = "DieselAdd")]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [AppAuth(PageName = "DieselAdd")]
        [HttpPost]
        public ActionResult Add(Diesel d)
        {
            DieselBusiness db = new DieselBusiness();
            db.d = d;

            if (db.checkyesterdayvalue(Convert.ToDateTime(d.Date).AddDays(-1)))
            {
                db.CreateDiesel();
                return View(new Diesel());
            }
            else
            {
                ViewBag.message = "The Entry of previous date is not present please enter the entry of the previous date";
                return View("ErrorMessage");
            }
        }


        public ActionResult FIlter()
        {
            return View();
        }

        [AppAuth(PageName = "DieselShow")]
        public ActionResult Show(DateTime start , DateTime end , string type)
        {
            return View(new DieselBusiness().ShowAllDiesel(start,end,type));
        }

        [AppAuth(PageName = "DieselFill")]
        [HttpGet]
        public ActionResult Fill()
        {
            return View();
        }

        [AppAuth(PageName = "DieselFill")]
        [HttpPost]
        public ActionResult Fill(Diesel d)
        {
            DieselBusiness db = new DieselBusiness();
            db.d = d;
            db.FillTank();
            return RedirectToAction("Show");
        }
        [AppAuth(PageName = "DieselDieselReport")]
        [HttpGet]
        public ActionResult Dieselreport()
        {
            return RedirectToAction("FIlter");
        }
        [AppAuth(PageName = "DieselShow")]
        [HttpGet]
        public ActionResult Delete (int id)
        {
            DieselBusiness db = new DieselBusiness();
            db.DeleteDiesel(id);
            return RedirectToAction("FIlter");
        }
        [AppAuth(PageName = "DieselShow")]
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View(new DieselBusiness().GetDieselById(id));
        }

        [AppAuth(PageName = "DieselShow")]
        [HttpPost]
        public ActionResult Update(Diesel d)
        {
            DieselBusiness db = new DieselBusiness();
            db.d = d;
            db.UpdateDiesel();
            return RedirectToAction("Filter");
        }

        public ActionResult dip()
        {
            return View();
        }

        public ActionResult dipchart(DateTime start , DateTime end)
        {
            return View(new DieselBusiness().DipChart(start,end));
        }
        
        [AppAuth(PageName = "DieselDieselReport")]
        [HttpPost]
        public ActionResult DieselReport(DateTime start,DateTime end, string type)
        {
            LocalReport lr = new LocalReport();

            string path = Path.Combine(Server.MapPath("~/Reports"), "DieselReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            ReportBusiness rb = new ReportBusiness();
            List<Diesel> lsreport = rb.PrintDiesel(start, end,type);


            ReportDataSource rd = new ReportDataSource("DieselDataSet", lsreport);
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