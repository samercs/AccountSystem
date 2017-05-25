using System;
using Humanizer;
using Microsoft.AccountSystem.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Identity = AccountSystem.Core.Identity;

namespace AccountSystem.Web.Features.Admin.UserManagement.Models
{
    public class IndexViewModel
    {
        public string Search { get; set; }
        public string Role { get; set; }
        public DateTime DateTime { get; set; }

        public IEnumerable<SelectListItem> RoleList
        {
            get
            {
                var roles = new[]
                {
                    Identity.Role.Administrator
                };

                return roles.Select(i => new SelectListItem
                {
                    Value = i,
                    Text = i.Humanize(),
                    Selected = i.Equals(Role)
                });
            }
        }
    }
}
