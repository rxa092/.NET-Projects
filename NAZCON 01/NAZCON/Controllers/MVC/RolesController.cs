using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NAZCON.Models;
using NAZCON.Models.EntityModel;
using NAZCON.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NAZCON.Controllers.MVC
{
    public class RolesController : Controller
    {
        [AppAuth(PageName = "RolesIndex")]
        public ActionResult Index()
        {
            // Populate Dropdown Lists
            var context = new Models.ApplicationDbContext();

            var rolelist = context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
            new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = rolelist;

            var userlist = context.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
            new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userlist;

            ViewBag.Message = "";

            return View();
        }

        // GET: /Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Roles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            try
            {
                var context = new Models.ApplicationDbContext();
                context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = collection["RoleName"]
                });
                context.SaveChanges();
                ViewBag.Message = "Role created successfully !";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET: /Roles/Delete
        public ActionResult Delete(string RoleName)
        {
            var context = new Models.ApplicationDbContext();
            var thisRole = context.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            context.Roles.Remove(thisRole);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // GET: /Roles/Edit/5
        [AppAuth(PageName ="RolesEdit")]
        public ActionResult Edit(string roleName)
        {
            var context = new Models.ApplicationDbContext();
            var thisRole = context.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            return View(thisRole);
        }

        //
        // POST: /Roles/Edit/5
        [AppAuth(PageName ="RolesEdit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IdentityRole role)
        {
            try
            {
                var context = new Models.ApplicationDbContext();
                context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //  Adding Roles to a user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string UserName, string RoleName)
        {
            var context = new Models.ApplicationDbContext();

            if (context == null)
            {
                throw new ArgumentNullException("context", "Context must not be null.");
            }

            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            userManager.AddToRole(user.Id, RoleName);


            ViewBag.Message = "Role created successfully !";

            // Repopulate Dropdown Lists
            var rolelist = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = rolelist;
            var userlist = context.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
            new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userlist;

            return View("Index");
        }

        //Getting a List of Roles for a User
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                var context = new Models.ApplicationDbContext();
                ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                ViewBag.RolesForThisUser = userManager.GetRoles(user.Id);


                // Repopulate Dropdown Lists
                var rolelist = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Roles = rolelist;
                var userlist = context.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
                new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
                ViewBag.Users = userlist;
                ViewBag.Message = "Roles retrieved successfully !";
            }

            return View("Index");
        }

        //Deleting a User from A Role
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName)
        {
            var account = new AccountController();
            var context = new Models.ApplicationDbContext();
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);


            if (userManager.IsInRole(user.Id, RoleName))
            {
                userManager.RemoveFromRole(user.Id, RoleName);
                ViewBag.Message = "Role removed from this user successfully !";
            }
            else
            {
                ViewBag.Message = "This user doesn't belong to selected role.";
            }

            // Repopulate Dropdown Lists
            var rolelist = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = rolelist;
            var userlist = context.Users.OrderBy(u => u.UserName).ToList().Select(uu =>
            new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userlist;

            return View("Index");
        }

        [HttpPost]
        //Getting user roles
        public ActionResult GetUserRoles(string userName)
        {
            var context = new ApplicationDbContext();
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var RolesForSelectedUser = userManager.GetRoles(user.Id).Select(x => new { id = x, name = x }).ToList();
            return Json(RolesForSelectedUser, JsonRequestBehavior.AllowGet);
        }

        //Showing pages assign to role
        [AppAuth(PageName ="RolesAddPagesToRole")]
        [HttpGet]
        public ActionResult AddPagesToRole(string id = "")
        {
            var context = new ApplicationDbContext();
            var rolelist = context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>
            new SelectListItem { Value = rr.Id.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = rolelist;

            if (id != "")
            {
                GetRolePagesViewModel GRPVM = new GetRolePagesViewModel();
                GRPVM.SelectedRole = id;
                GRPVM.RolePages = GetRolePages(id);

                for (int i = 0; i < rolelist.Count; i++)
                {
                    if (rolelist[i].Value == id)
                        rolelist[i].Selected = true;
                }

                return View(GRPVM);
            }
            return View();
        }

        //Giving pages access to role
        [AppAuth(PageName = "RolesAddPagesToRole")]
        [HttpPost]
        public ActionResult AddPagesToRole(GetRolePagesViewModel gg)
        {
            var context = new ApplicationDbContext();
            for (int i = 0; i < gg.RolePages.Count; i++)
            {
                if (gg.RolePages[i].Check)
                    Page.SetAccess(gg.SelectedRole, gg.RolePages[i].Pages.Id);
                else
                    Page.DeleteAccess(gg.SelectedRole, gg.RolePages[i].Pages.Id);
            }
            return RedirectToAction("AddPagesToRole", new { id = gg.SelectedRole });
        }

        //Getting pages assign to role from database
        public List<RolePageEditorTemplateViewModel> GetRolePages(string id)
        {
            var context = new ApplicationDbContext();
            List<Page> pages = context.Pages.ToList();
            List<Page> RolePages = Role.GetRolePages(context.Roles.Where(x => x.Id.Equals(id)).FirstOrDefault().Id);

            //Selecting check box for specific pages of role
            List<RolePageEditorTemplateViewModel> RolePagesList = new List<RolePageEditorTemplateViewModel>();
            foreach (var item in pages)
            {
                RolePageEditorTemplateViewModel Temp = new RolePageEditorTemplateViewModel();
                Temp.Pages = item;
                for (int i = 0; i < RolePages.Count; i++)
                {
                    if (item.PageName == RolePages[i].PageName)
                        Temp.Check = true;
                }
                RolePagesList.Add(Temp);
            }
            return RolePagesList;
        }
    }
}