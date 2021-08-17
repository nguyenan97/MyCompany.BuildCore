using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyCompany.BuildCore.EntityFrameworkCore;
using MyCompany.BuildCore.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MyCompany.BuildCore.Web.Tests
{
    [DependsOn(
        typeof(BuildCoreWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class BuildCoreWebTestModule : AbpModule
    {
        public BuildCoreWebTestModule(BuildCoreEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BuildCoreWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(BuildCoreWebMvcModule).Assembly);
        }
    }
}