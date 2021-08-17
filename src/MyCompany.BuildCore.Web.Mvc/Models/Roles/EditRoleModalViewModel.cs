using Abp.AutoMapper;
using MyCompany.BuildCore.Roles.Dto;
using MyCompany.BuildCore.Web.Models.Common;

namespace MyCompany.BuildCore.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
