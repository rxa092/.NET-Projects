using Microsoft.Reporting.WebForms;
using NAZCON.Controllers.MVC;
using NAZCON.Models.Business_Layer;
using NAZCON.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAZCON.Controllers
{
    public class DoController : Controller
    {
        public ActionResult DOreport(int id)
        {
            LocalReport lr = new LocalReport();

            string path = Path.Combine(Server.MapPath("~/Reports"), "DOReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            ReportBusiness rb = new ReportBusiness();
            List<DelieveryOrderReportModel> lsreport = rb.GetDelieveryOrderReport(id);


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
        // GET: Do
        [AppAuth(PageName = "Dodo_create")]
        [HttpGet]

        public ActionResult do_create(int x)
        {
            DoBussiness db = new DoBussiness();
            db.Create_Do(x);
            return (RedirectToAction("show_all"));
        }

        [HttpGet]
        public ActionResult Do_view()
        {
            DoBussiness db = new DoBussiness();
         //   db.Create_Do(); 
            return View(db.Do_show());
        }


        public ActionResult DeleteDo(int id)
        {
            new DoBussiness().delete(id);
            return RedirectToAction("show_all");
        }

        [HttpGet]
        public ActionResult So_delete()
        {
            SoBusiness sb = new SoBusiness();
            sb.Delete_so();
            return RedirectToAction("So_add", "SO");
        }
        [AppAuth(PageName = "Doshow_all")]
        [HttpGet]
        public ActionResult show_all()
        {
            DoBussiness db = new DoBussiness();
            return View(db.show_all());
        }
    }
}