using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace MyCompany.BuildCore.Web.Views
{
    public abstract class BuildCoreRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected BuildCoreRazorPage()
        {
            LocalizationSourceName = BuildCoreConsts.LocalizationSourceName;
        }
    }
}
