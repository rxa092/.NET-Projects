using NAZCON.Models.Business_Layer;
using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAZCON.Controllers.MVC
{
    public class VendorTransactionController : Controller
    {
        // GET: VendorTransaction
        [AppAuth(PageName ="VendorTransactionAdd")]
        [HttpGet]
        public ActionResult Add()
        {
            VendorBusiness vb = new VendorBusiness();
            ViewBag.vendor = new SelectList(vb.Vendorlist(), "id", "name");
            return View();
        }
        [AppAuth(PageName ="VendorTransactionAdd")]
        [HttpPost]
        public ActionResult Add(VendorTransactionModel vm)
        {
            //VendorBusiness vb = new VendorBusiness();
            VendorTransactionBusiness vtb = new VendorTransactionBusiness();
            ViewBag.vendor = new SelectList(vtb.Vendorlist(), "vid", "vname");
            vtb.add(vm);
            return View(new VendorTransactionModel());
        }
        [AppAuth(PageName ="VendorTransactionShow")]
        public ActionResult Show()
        {
            VendorTransactionBusiness vb = new VendorTransactionBusiness();
            return View(vb.show());
        }
    }
}