using NAZCON.Models.Business_Layer;
using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAZCON.Controllers.MVC
{
    public class RawMaterialController : Controller
    {

        // GET: RawMaterial
        [HttpGet]
        [AppAuth(PageName = "RawMaterialAdd")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [AppAuth(PageName = "RawMaterialAdd")]
        public ActionResult Add(RawMaterial rm)
        {
            RawMaterialBusiness rb = new RawMaterialBusiness();
            rb.rm = rm;
            rb.AddRawmaterial();
            return RedirectToAction("Show");
        }

        [AppAuth(PageName = "RawMaterialShow")]
        public ActionResult Show()
        {
            return View(new RawMaterialBusiness().ShowRawMaterial());
        }

        [HttpGet]
        [AppAuth(PageName = "RawMaterialUpdate")]
        public ActionResult Update(int id)
        {
            return View(new RawMaterialBusiness().GetRawMaterialByid(id));
        }

        [HttpPost]
        [AppAuth(PageName = "RawMaterialUpdate")]
        public ActionResult Update(RawMaterial rm)
        {
            RawMaterialBusiness rb = new RawMaterialBusiness();
            rb.rm = rm;
            rb.UpdateRawMaterial();
            return RedirectToAction("Show");
        }

        public ActionResult Delete(int id)
        {
            new RawMaterialBusiness().DeleteRawMaterial(id);
            return RedirectToAction("Show");
        }

        


    }
}