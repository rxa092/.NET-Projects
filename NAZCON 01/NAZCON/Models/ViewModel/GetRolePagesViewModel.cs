using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAZCON.Models.ViewModel
{
    public class GetRolePagesViewModel
    {
        public String SelectedRole { get; set; }
        public List<RolePageEditorTemplateViewModel> RolePages { get; set; }
    }
}