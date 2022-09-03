using NAZCON.Models.Business_Layer;
using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAZCON.Controllers.MVC
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        [AppAuth(PageName ="InventoryAdd")]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [AppAuth(PageName ="InventoryAdd")]
        [HttpPost]
        public ActionResult Add(Inventory inv)
        {
            InventoryBusiness ib = new InventoryBusiness();
            ib.inv = inv;
            ib.add();
            return RedirectToAction("Show");
        }
        [AppAuth(PageName ="InventoryShow")]
        [HttpGet]

        public ActionResult Show()
        {
            InventoryBusiness ib = new InventoryBusiness();
            
            return View(ib.show());
        }
        [AppAuth(PageName ="InventoryUpdate")]
        [HttpGet]
        public ActionResult Update(int id)
        {
            InventoryBusiness ib = new InventoryBusiness();
            return View(ib.search(id));

        }
        [AppAuth(PageName ="InventoryUpdate")]
        [HttpPost]
        public ActionResult Update(Inventory inv)
        {
            InventoryBusiness ib = new InventoryBusiness();
            ib.inv = inv;
            ib.update();
            return RedirectToAction("Show");
        }

        public ActionResult Delete(int id)
        {
            InventoryBusiness inv = new InventoryBusiness();
            inv.inv = new Inventory();
            inv.inv.id = id;
            inv.delete();
            return RedirectToAction("Show");
        }
    }
}