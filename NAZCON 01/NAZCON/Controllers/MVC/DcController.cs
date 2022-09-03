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
    public class DcController : Controller
    {
        // GET: Dc
        public ActionResult DCreport(int id)
        {
            LocalReport lr = new LocalReport();

            string path = Path.Combine(Server.MapPath("~/Reports"), "DelieveryChallanReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            ReportBusiness rb = new ReportBusiness();
            List<DelieveryChallanReportModel> lsreport = rb.GetDelieveryChallanReport(id);


            ReportDataSource rd = new ReportDataSource("DelieveryChallanDataSet", lsreport);
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

        [AppAuth(PageName = "Dcdc_update")]
        [HttpGet]
        public ActionResult dc_update()
        {
            // DcBusiness db = new DcBusiness();
            SoBusiness sb = new SoBusiness();
            ViewBag.items = new SelectList(sb.item(), "Item", "Description");

            DcBusiness db = new DcBusiness();
            ViewBag.order = new SelectList(db.get_do());
            return View();
        }


        [AppAuth(PageName = "Dcdc_update")]
        [HttpPost]
        public ActionResult dc_update(DcModel dm)
        {
            DcBusiness db = new DcBusiness();
            db.dm = dm;
            db.items = db.dm.quantity;
            if (DcBusiness.yes == false)
            {
                db.add_dc();
                db.add_dc2();
            }

            else
            {
                db.add_dc2();
            }

            double z = 0;
            z = dm.quantity;
            //DcBusiness db = new DcBusiness();
            // z-=db.update_dc1();
            z = db.update_dc1() - z;
            db.dm.quantity = z;
            db.update_dc2();
            db.minusitems();
            SoBusiness sb = new SoBusiness();
            ViewBag.items = new SelectList(sb.item(), "Item", "Description");
            ViewBag.order = new SelectList(db.get_do());

            return View();
        }


        [HttpGet]
        public ActionResult msg()
        {
            ViewBag.Message = "Please enter less quantity";
            return View();
        }


        [AppAuth(PageName = "Dcshow_all")]
        [HttpGet]
        public ActionResult show_all()
        {
            DcBusiness db = new DcBusiness();
            DcBusiness.yes = false;
            return View(db.show_dc());
        }
        [AppAuth(PageName = "Dcshow_all")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            DcBusiness db = new DcBusiness();
            db.DeleteDc(id);
            return RedirectToAction("show_all");
        }
    }
}
