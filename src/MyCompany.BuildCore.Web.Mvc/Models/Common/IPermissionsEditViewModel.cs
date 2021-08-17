using System.Collections.Generic;
using MyCompany.BuildCore.Roles.Dto;

namespace MyCompany.BuildCore.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}