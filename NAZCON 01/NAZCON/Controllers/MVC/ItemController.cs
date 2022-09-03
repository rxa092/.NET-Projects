using NAZCON.Models.Business_Layer;
using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAZCON.Controllers.MVC
{
    public class ItemController : Controller
    {

        // GET: Item
        [AppAuth(PageName ="Itemadd_item")]
        [HttpGet]
        public ActionResult add_item()
        {
            return View();
        }
        [AppAuth(PageName ="Itemadd_item")]
        [HttpPost]
        public ActionResult add_item(ItemModel im)
        {
            ItemBussiness ib = new ItemBussiness();
            ib.im = im;
            ib.item_add();
            return View();
        }
        
        [HttpGet]
        public ActionResult del(ItemModel im)
        {
            ItemBussiness ib = new ItemBussiness();
            ib.im = im;
            ib.item_delete();
            return RedirectToAction("show_item");
        }
        [AppAuth(PageName ="Itemshow_item")]
        [HttpGet]
        public ActionResult show_item()
        {
            ItemBussiness ib = new ItemBussiness();
            return View(ib.show_all());
        }
        [AppAuth(PageName ="Itemupdate_item")]
        [HttpGet]
        public ActionResult update_item(int id)
        {

            ItemBussiness ib = new ItemBussiness();
            return View(ib.item_search(id));
        }
        [AppAuth(PageName ="Itemupdate_item")]
        [HttpPost]
        public ActionResult update_item(ItemModel im)
        {
            ItemBussiness ib = new ItemBussiness();
            ib.im = im;
            ib.item_update1();
            return RedirectToAction("show_item");
        }

        [AppAuth(PageName = "ItemUpdQuan")]
        [HttpGet]
        public ActionResult UpdQuan(int id)
        {
            ItemBussiness ib = new ItemBussiness();
            ib.im = new ItemModel();
            ib.im.id = id;
            return View(ib.im);
        }
        [AppAuth(PageName = "ItemUpdQuan")]
        [HttpPost]
        public ActionResult UpdQuan(ItemModel im)
        {
            ItemBussiness ib = new ItemBussiness();
            ib.im = im;
            ib.quantity();
            return RedirectToAction("ShowQuan");
        }
        [AppAuth(PageName = "ItemShowQuan")]
        [HttpGet]
        public ActionResult ShowQuan()
        {
            ItemBussiness ib = new ItemBussiness();
            ib.showquan();
            return View(ib.showquan());
        }
    }
}