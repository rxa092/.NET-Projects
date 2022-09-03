using System;
using System.Security.Principal;
using System.Web;
using System.Linq;
using NAZCON.Models;
using NAZCON.Models.EntityModel;

namespace NAZCON.Controllers.MVC
{
    //Extension class to check access on front end
    public static class CheckAccess 
    {
        //Function to check access on page link on front end
        public static bool CheckPageAccess(this IPrincipal User,string pageName)
        {
            string userName = HttpContext.Current.User.Identity.Name;
            
            if (userName.Trim() == "")
                return false;

            try
            {
                var context = new ApplicationDbContext();
                ApplicationUser user = context.Users.Where(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                return Page.VerifyUserAccess(user.Id, pageName);
            }
            catch
            {
                return false;
            }
        }
    }
}