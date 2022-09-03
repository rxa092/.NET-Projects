using NAZCON.Models.Business_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAZCON.Controllers.MVC
{
    public class AttendanceController : Controller
    {
        // GET: Attendance
        [AppAuth(PageName = "Attendanceshow")]
        public ActionResult Show()
        {
            return View(new AttendanceBusiness().ShowAll());
        }
    }
}