using NAZCON.Models.Business_Layer;
using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAZCON.Controllers.MVC
{
    public class MouldController : Controller
    {
        // GET: Mould
        [HttpGet]
        [AppAuth(PageName = "MouldAdd")]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [AppAuth(PageName = "MouldAdd")]
        public ActionResult Add(MouldModel mm)
        {
            MouldBusiness mb = new MouldBusiness();
            mb.mm = mm;
            mb.AddMould();
            return View();
        }

        [HttpGet]
        [AppAuth(PageName = "MouldShow")]
        public ActionResult Show()
        {
            return View(new MouldBusiness().ShowAllMould());
        }

        [HttpGet]
        [AppAuth(PageName = "MouldShow")]
        public ActionResult Update(int id)
        {
            return View(new MouldBusiness().SpecificMould(id));
        }

        [HttpPost]
        [AppAuth(PageName = "MouldShow")]
        public ActionResult Update(MouldModel mm)
        {
            MouldBusiness mb = new MouldBusiness();
            mb.mm = mm;
            mb.UpdateMould();
            return RedirectToAction("Show");
        }

        [HttpGet]
        [AppAuth(PageName = "MouldShow")]
        public ActionResult Delete(int id)
        {
            new MouldBusiness().DeleteMould(id);
            return RedirectToAction("Show");
        }




    }
}