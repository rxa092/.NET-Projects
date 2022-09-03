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
    public class ProductionController : Controller
    {
        private static bool x { get; set; }

        // GET: Production
        [AppAuth(PageName = "ProductionAddProduction")]
        [HttpGet]
        public ActionResult AddProduction()
        {
            x = true;
            return View();
            
        }
        [AppAuth(PageName = "ProductionAddProduction")]
        [HttpPost]
        public ActionResult AddProduction(Production p)
        {
            ProductionBusiness pb = new ProductionBusiness();
            pb.p = p;
            if (x)
            {
                pb.AddProduction();
                pb.PRawMaterial();
                x = false;
            }
            else
            {
                pb.PRawMaterial();
            }
            p.rawmaterial = new ProductionRawMaterial();
            return View(p);
        }
        [AppAuth(PageName = "ProductionShowProduction")]

        public ActionResult ShowProduction()
        {
            return View(new ProductionBusiness().GetAllProductions());
        }

        [HttpGet]
        [AppAuth(PageName = "ProductionDetails")]

        public ActionResult Details(int id)
        {
            return View(new ProductionBusiness().details(id));
        }

        public ActionResult ProductionReport(int id)
        {
            LocalReport lr = new LocalReport();

            string path = Path.Combine(Server.MapPath("~/Reports"), "ProductionReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            ReportBusiness rb = new ReportBusiness();
            List<Production> lsreport = rb.GetProductionReport(id);


            ReportDataSource rd = new ReportDataSource("ProductionreportDataSet", lsreport);
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