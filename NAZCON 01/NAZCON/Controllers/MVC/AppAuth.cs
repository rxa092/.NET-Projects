using Microsoft.AspNet.Identity;
using NAZCON.Models.EntityModel;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NAZCON.Controllers.MVC
{
    public class AppAuth : AuthorizeAttribute
    {
        public string PageName { get; set; }
       
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string UserId = httpContext.User.Identity.GetUserId();

            if (UserId == null)
                return false;
            
            if (Page.VerifyUserAccess(UserId, PageName))
                return true;
            else
                return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                string Message = @"Sorry you don't have permission to access this page. If you try to access this page again and again so, your account will be blocked.";
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Message" , message = Message}));
            }
        }
    }
}