using System;
using System.Collections.Generic;
using System.Linq;

namespace NAZCON.Models.EntityModel
{
    public class Page
    {
        public int Id { get; set; }
        public String PageName { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public static bool VerifyUserAccess(string userId, string pageName)
        {
            var context = new ApplicationDbContext();
            string query = string.Format(@"select p.PageName from Pages p inner join RolePages rp on p.Id = rp.Page_Id 
                                                inner join AspNetRoles r 
                                                on rp.Role_Id = r.Id
												inner join AspNetUserRoles ur
												on r.Id = ur.RoleId
												inner join AspNetUsers u
												on ur.UserId = u.Id
                                                where u.Id = '{0}' and p.PageName = '{1}'", userId, pageName);
            var data = context.Database.SqlQuery<string>(query).ToList();
            if (data.Count == 1)
            {
                if (data[0] == pageName)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public static void SetAccess(string roleId, int pageId)
        {
            var context = new ApplicationDbContext();

            //Checking if access entry already exists so don't insert else insert.
            string query1 = string.Format(@"select Role_Id from RolePages
                                           where Role_Id = '{0}' and Page_Id = {1}", roleId, pageId);

            var data = context.Database.SqlQuery<string>(query1).ToList();
            if (data.Count == 0)
            {
                string query2 = string.Format(@"insert into RolePages (Role_Id,Page_Id) values('{0}',{1})", roleId, pageId);
                context.Database.ExecuteSqlCommand(query2);
            }
        }
        
        public static void DeleteAccess(string roleId, int pageId)
        {
            var context = new ApplicationDbContext();
            string query = string.Format(@"delete RolePages
                                           where Role_Id = '{0}' and Page_Id = {1}", roleId, pageId);
            context.Database.ExecuteSqlCommand(query);
        }
    }
}