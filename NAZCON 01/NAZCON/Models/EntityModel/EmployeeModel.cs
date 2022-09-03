using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NAZCON.Models.EntityModel
{
    public class EmployeeModel
    {

        public int empid { get; set; }
        [Display(Name = "Employee Name")]
        public string ename { get; set; }
        [Display(Name = "Employee Contact")]
        public string contact { get; set; }
        [Display(Name = "Employee NIC")]
        public string nic { get; set; }
        [Display(Name = "Employee Joining Date")]
        public string join { get; set; }
        [Display(Name = "Employee Date Of Birth")]
        public string dob { get; set; }
        [Display(Name = "Employee Address")]
        public string address { get; set; }
        [Display(Name = "Employee Designation")]
        public string qualification { get; set; }

    }
}