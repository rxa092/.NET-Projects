using Microsoft.AspNet.Identity.EntityFramework;
using NAZCON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAZCON.Models.EntityModel
{
    public class Role : IdentityRole
    {
        public virtual ICollection<Page> Pages { get; set; }

        public static List<Page> GetRolePages(string id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            string query = string.Format(@"select p.* from Pages p inner join RolePages rp
                            on p.Id = rp.Page_Id
                            where rp.Role_Id = '{0}'", id);
            return context.Pages.SqlQuery(query).ToList();
        }
    }
}