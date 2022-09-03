using NAZCON.Models.Business_Layer;
using NAZCON.Models.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAZCON.Controllers.MVC
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        [AppAuth(PageName ="EmployeeAdd")]
        public ActionResult Add()
        {
            return View();
        }
        [AppAuth(PageName = "EmployeeAdd")]
        [HttpPost]
        public ActionResult Add(EmployeeModel em)
        {
            EmployeeBusiness embu = new EmployeeBusiness();
            embu.em = em;
            embu.AddEmp();
            return View();
        }
        [AppAuth(PageName = "EmployeeShow")]
        [HttpGet]
        public ActionResult Show()
        {
            EmployeeBusiness embu = new EmployeeBusiness();
            return View(embu.ShowEmp());
        }

        
        public ActionResult del(int id)
        {
            EmployeeBusiness embu = new EmployeeBusiness();
            embu.em = new EmployeeModel();
            embu.em.empid = id;

            embu.DelEmp();
            return RedirectToAction("Show");
        }
        [AppAuth(PageName = "Employeeupdate")]
        [HttpGet]
        
        public ActionResult update(string id)
        {
            
            EmployeeBusiness eb = new EmployeeBusiness();
            return View(eb.EmpSearch(id));
        }
        [AppAuth(PageName = "Employeeupdate")]
        [HttpPost]
        public ActionResult update(EmployeeModel em)
        {
            EmployeeBusiness embu = new EmployeeBusiness();
            embu.em = em;
            embu.UpdEmp();
            return RedirectToAction("Show");
        }
    }
}