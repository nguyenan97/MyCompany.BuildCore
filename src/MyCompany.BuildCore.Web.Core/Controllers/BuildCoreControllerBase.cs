using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MyCompany.BuildCore.Controllers
{
    public abstract class BuildCoreControllerBase: AbpController
    {
        protected BuildCoreControllerBase()
        {
            LocalizationSourceName = BuildCoreConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
