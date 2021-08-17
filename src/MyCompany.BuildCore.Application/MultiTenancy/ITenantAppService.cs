using Abp.Application.Services;
using MyCompany.BuildCore.MultiTenancy.Dto;

namespace MyCompany.BuildCore.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

