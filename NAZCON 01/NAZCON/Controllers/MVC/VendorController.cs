using NAZCON.Models.Business_Layer;
using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAZCON.Controllers.MVC
{
    public class VendorController : Controller
    {
        // GET: Vendor
        [AppAuth(PageName ="VendorAdd")]
        [HttpGet]
        public ActionResult Add()
        {

            return View();
        }

        [AppAuth(PageName ="VendorAdd")]
        [HttpPost]
        public ActionResult Add(VendorModel vm)
        {
            VendorBusiness vb = new VendorBusiness();
            vb.add(vm);
            return View();
        }

        [AppAuth(PageName ="VendorShow")]
        public ActionResult Show()
        {
            VendorBusiness vb = new VendorBusiness();
            return View(vb.show());
        }

        public ActionResult Delete(int id)
        {
            new VendorBusiness().delete(id);
            return RedirectToAction("Show");
        }
        [AppAuth (PageName ="VendorUpdate")]
        [HttpGet]
        public ActionResult Update(int id)
        {
            VendorBusiness vb=new VendorBusiness();
            return View(vb.GetVendor(id));
        }
        [AppAuth(PageName ="VendorUpdate")]
        [HttpPost]
        public ActionResult Update(VendorModel vm)
        {
            VendorBusiness vb = new VendorBusiness();
            vb.update(vm);
            return RedirectToAction("Show");
        }
    }
}