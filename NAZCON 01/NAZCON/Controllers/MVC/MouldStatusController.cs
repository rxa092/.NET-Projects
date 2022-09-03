using NAZCON.Models.Business_Layer;
using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAZCON.Controllers.MVC
{
    public class MouldStatusController : Controller
    {
        // GET: MouldStatus
        [HttpGet]
        [AppAuth(PageName = "MouldStatusAdd")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [AppAuth(PageName = "MouldStatusAdd")]
        public ActionResult Add(MouldStatusModel msm)
        {
            MouldStatusBusiness msb = new MouldStatusBusiness();
            msb.msm = msm;
            msb.AddStatus();
            return View();
        }

        [HttpGet]
        [AppAuth(PageName = "MouldStatusShow")]
        public ActionResult Show()
        {
            return View(new MouldStatusBusiness().AllStatus());
        }

        [HttpGet]
        [AppAuth(PageName = "MouldStatusShow")]
        public ActionResult Update(int id)
        {
            return View(new MouldStatusBusiness().SpecificStatus(id));
        }
        [HttpPost]
        [AppAuth(PageName = "MouldStatusShow")]
        public ActionResult Update(MouldStatusModel msm)
        {
            MouldStatusBusiness msb = new MouldStatusBusiness();
            msb.msm = msm;
            msb.UpdateStatus();
            return RedirectToAction("Show");
        }
        [HttpGet]
        [AppAuth(PageName = "MouldStatusShow")]
        public ActionResult Delete(int id)
        {
            new MouldStatusBusiness().DeleteStatus(id);
            return RedirectToAction("Show");
        }
    }
}