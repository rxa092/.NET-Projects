using NAZCON.Models.Business_Layer;
using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAZCON.Controllers.MVC
{
   // [AllowAnonymous]
    public class ClientTransactionController : Controller
    {
        public object ClientBusiness { get; private set; }

        // GET: ClientTransaction
       [AppAuth(PageName = "ClientTransactionAdd")]
        [HttpGet]
        public ActionResult Add()
        {
            ClientBussiness cb = new ClientBussiness();
            ViewBag.client = new SelectList(cb.DropDown(), "Client_id", "Client_name");
            return View();
        }
        [AppAuth(PageName = "ClientTransactionAdd")]
        [HttpPost]
        public ActionResult Add(ClientTransaction ctran)
        {
            ClientBussiness cb = new ClientBussiness();
            ViewBag.client = new SelectList(cb.DropDown(), "Client_id", "Client_name");
            ClientTransactionModel tran = new ClientTransactionModel();
            tran.ct = ctran;
            tran.add();
            return View();
        }
        [AppAuth(PageName = "ClientTransactionShow")]
        [HttpGet]
        public ActionResult Show()
        {
            ClientTransactionModel ctran = new ClientTransactionModel();
            return View(ctran.show());
        }
    }
}