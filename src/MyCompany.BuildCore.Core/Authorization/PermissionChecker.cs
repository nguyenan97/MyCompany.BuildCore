using Abp.Authorization;
using MyCompany.BuildCore.Authorization.Roles;
using MyCompany.BuildCore.Authorization.Users;

namespace MyCompany.BuildCore.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
