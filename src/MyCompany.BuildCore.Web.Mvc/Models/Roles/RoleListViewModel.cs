using System.Collections.Generic;
using MyCompany.BuildCore.Roles.Dto;

namespace MyCompany.BuildCore.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
