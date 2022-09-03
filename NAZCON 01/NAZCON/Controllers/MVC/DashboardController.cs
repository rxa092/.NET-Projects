using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;
using NAZCON.Models.Business_Layer;

namespace NAZCON.Controllers.MVC
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [HttpGet]
        [AppAuth (PageName ="DashboardIndex")]
        public ActionResult Index()
        {
            string message = "Welcome to Nazir Concrete MR " + SoBusiness.UserName;
            ViewBag.Message = message;
            return View();
        }
    }
}