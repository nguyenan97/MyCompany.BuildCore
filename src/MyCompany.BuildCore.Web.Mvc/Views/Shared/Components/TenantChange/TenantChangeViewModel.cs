using Abp.AutoMapper;
using MyCompany.BuildCore.Sessions.Dto;

namespace MyCompany.BuildCore.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
