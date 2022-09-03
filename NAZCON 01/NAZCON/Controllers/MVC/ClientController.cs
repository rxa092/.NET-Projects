using NAZCON.Models.Business_Layer;
using NAZCON.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAZCON.Controllers.MVC
{
   // [AllowAnonymous]
    public class ClientController : Controller
    {
        // GET: Client
        [AppAuth(PageName ="Clientclient_add")]
        [HttpGet]
        public ActionResult client_add()
        {
            return View();
        }
        [AppAuth(PageName = "Clientclient_add")]
        [HttpPost]
        public ActionResult client_add(ClientModel cm)
        {
            ClientBussiness cb = new ClientBussiness();
            cb.cb = cm;
            cb.Add_client();
            return View();
        }
        [AppAuth(PageName = "Clientclient_delete")]
        [HttpGet]
        public ActionResult client_delete()
        {
            return View();
        }
        [AppAuth(PageName = "Clientclient_delete")]
        [HttpPost]
        public ActionResult client_delete(ClientModel cm)
        {
            ClientBussiness cb = new ClientBussiness();
            cb.cb = cm;
            cb.Delete_client();
            return View();
        }
        [AppAuth(PageName = "Clientclient_show")]
        [HttpGet]
        public ActionResult client_show()
        {
            ClientBussiness cm = new ClientBussiness();
            return View(cm.show_all());
        }

        public ActionResult del(int id)
        {
            ClientBussiness cb = new ClientBussiness();
            cb.cb = new ClientModel();
            cb.cb.Client_id = id;
            cb.Delete_client();
            return RedirectToAction("client_show");
        }
        [AppAuth(PageName = "Clientupdate")]
        [HttpGet]
        public ActionResult update(int id)
        {
            ClientBussiness cb = new ClientBussiness();
            return View(cb.client_search(id));
        }
        [AppAuth(PageName = "Clientupdate")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult update(ClientModel cm)
        {
            ClientBussiness cb = new ClientBussiness();
            cb.cb = cm;
            cb.Update_client();
            return RedirectToAction("client_show");
        }
        
    }
}