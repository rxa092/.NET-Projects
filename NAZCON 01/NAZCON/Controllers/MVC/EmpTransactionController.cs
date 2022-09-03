using NAZCON.Models.Business_Layer;
using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAZCON.Controllers.MVC
{
    public class EmpTransactionController : Controller
    {
        // GET: EmpTransaction
        [AppAuth(PageName ="EmpTransactionAdd")]
        [HttpGet]
        public ActionResult Add()
        {
            EmployeeBusiness em = new EmployeeBusiness();
            ViewBag.employee = new SelectList(em.getemp(), "empid", "ename");
            return View();
        }
        [AppAuth(PageName = "EmpTransactionAdd")]
        [HttpPost]

        public ActionResult Add(EmpTransaction em)
        {
            EmployeeBusiness em1 = new EmployeeBusiness();
            ViewBag.employee = new SelectList(em1.getemp(), "empid", "ename");
            EmpTransactionBusiness etran = new EmpTransactionBusiness();
            etran.emp = em;
            etran.add();
            return View();
        }

        [AppAuth(PageName = "EmpTransactionShow")]
        public ActionResult Show()
        {
            EmpTransactionBusiness etranb = new EmpTransactionBusiness();
            return View(etranb.show());
        }
    }
}