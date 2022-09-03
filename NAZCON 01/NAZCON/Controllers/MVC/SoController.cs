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
    public class SoController : Controller
    {

        public ActionResult SOreport(int id)
        {
            LocalReport lr = new LocalReport();

            string path = Path.Combine(Server.MapPath("~/Reports"), "SalesOrderReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            ReportBusiness rb = new ReportBusiness();
            List<SalesOrderReportModel> lsreport = rb.GetSalesOrderReport(id);


            ReportDataSource rd = new ReportDataSource("SalesOrderDataSet", lsreport);
            //  ReportDataSource rd2 = new ReportDataSource("SalesOrderDataSet2", lsreport);
            new LocalReport().ListRenderingExtensions();
            lr.DataSources.Add(rd);
            //  lr.DataSources.Add(rd2);
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
        // GET: So
        [AppAuth(PageName ="SoSo_add")]
        [HttpGet]
        public ActionResult So_add()
        {
            SoBusiness s = new SoBusiness();
            ViewBag.myitems = new SelectList(s.item(), "Item", "Description");  

            ClientBussiness cb = new ClientBussiness();
            ViewBag.client = new SelectList(cb.DropDown(), "Client_id", "Client_name");

            
            return View();
        }
        [AppAuth(PageName = "SoSo_add")]
        [HttpPost]
        public ActionResult So_add(SoModel sm)
        {
            SoBusiness bs = new SoBusiness();
            bs.sm = sm;
            if (SoModel.count==0)
            {
                bs.addso();
                bs.addso2();
                SoModel.count++;
            }

            else
            {
                bs.addso2();
            }
            SoBusiness s = new SoBusiness();
            ViewBag.myitems = new SelectList(s.item(), "Item", "Description");
            ClientBussiness cb = new ClientBussiness();
            ViewBag.client = new SelectList(cb.DropDown(), "Client_id", "Client_name");

            return View();
        }

        //public ActionResult So_add(SoModel sm, HttpPostedFileBase f1)
        //{
        //    string pa = f1.FileName;
        //    pa = Server.MapPath("/fonts/" + pa);
        //    f1.SaveAs(pa);
        //    SoBusiness bs = new SoBusiness();
        //    bs.sm = sm;
        //    if (SoModel.count == 0)
        //    {
        //        bs.addso();
        //        bs.addso2();
        //        SoModel.count++;
        //    }

        //    else
        //    {
        //        bs.addso2();
        //    }
        //    SoBusiness s = new SoBusiness();
        //    ViewBag.myitems = new SelectList(s.item(), "Item", "Description");
        //    ClientBussiness cb = new ClientBussiness();
        //    ViewBag.client = new SelectList(cb.DropDown(), "Client_id", "Client_name");

        //    return View();
        //}
        [AppAuth(PageName ="SoSo_view")]
        [HttpGet]
        public ActionResult So_view()
        {
            SoBusiness sb = new SoBusiness();
            SoModel.count = 0;

            //sb.final_amount();
            return View(sb.show_current());
        }
        [AppAuth(PageName ="SoShowSo")]
        [HttpGet]
        public ActionResult ShowSo()
        {
            SoBusiness sb = new SoBusiness();
            return View(sb.show_all());
        }

        [HttpGet]

        public ActionResult search()
        {
            SoBusiness sb = new SoBusiness();
            
            return View(sb.search());
        }


        [HttpGet]
        [AppAuth(PageName = "SoShowSo")]
        public ActionResult delete(int id)
        {
            new SoBusiness().DeleteSo(id);
            return RedirectToAction("ShowSo");
        }


        [HttpGet]
        public ActionResult do_create(int id)
        {
            DoBussiness db = new DoBussiness();
            db.Create_Do(id);
            return (RedirectToAction("ShowSo"));
        }
    }
}