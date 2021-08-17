using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyCompany.BuildCore.MultiTenancy;

namespace MyCompany.BuildCore.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
