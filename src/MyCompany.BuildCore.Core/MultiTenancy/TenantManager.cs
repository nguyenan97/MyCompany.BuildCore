using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using MyCompany.BuildCore.Authorization.Users;
using MyCompany.BuildCore.Editions;

namespace MyCompany.BuildCore.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
