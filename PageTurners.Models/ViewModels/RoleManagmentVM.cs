using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PageTurners.Models.ViewModels
{
	public class RoleManagmentVM
	{
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<SelectListItem> RoleList { get; set; }
        public IEnumerable<SelectListItem> CompanyList { get; set; }
    }
}

