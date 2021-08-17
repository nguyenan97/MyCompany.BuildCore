using System.Collections.Generic;
using MyCompany.BuildCore.Roles.Dto;

namespace MyCompany.BuildCore.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
