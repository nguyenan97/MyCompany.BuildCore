using Abp.AspNetCore.Mvc.ViewComponents;

namespace MyCompany.BuildCore.Web.Views
{
    public abstract class BuildCoreViewComponent : AbpViewComponent
    {
        protected BuildCoreViewComponent()
        {
            LocalizationSourceName = BuildCoreConsts.LocalizationSourceName;
        }
    }
}
