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
    public class GatePassController : Controller
    {
        // GET: GatePass


        public ActionResult GPreport(int id)
        {
            LocalReport lr = new LocalReport();

            string path = Path.Combine(Server.MapPath("~/Reports"), "GatePassReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            ReportBusiness rb = new ReportBusiness();
            List<GatePassReportModel> lsreport = rb.GetGatePassReport(id);


            ReportDataSource rd = new ReportDataSource("GatePassDataSet", lsreport);
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

        [HttpGet]
        public ActionResult gatepass_add(int id)
        {
            GatepassBussiness gp = new GatepassBussiness();
            gp.add_GP(id);
            return RedirectToAction("show_all", "Dc");
        }
        [AppAuth(PageName = "GatePassshowAll_GP")]
        [HttpGet]
        public ActionResult showAll_GP()
        {
            GatepassBussiness gp = new GatepassBussiness();
            return View(gp.show_dc());
        }

        [AppAuth(PageName = "GatePassshowAll_GP")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            new GatepassBussiness().DeleteGp(id);
            return RedirectToAction("shwoAll_GP");
        }
    }
}