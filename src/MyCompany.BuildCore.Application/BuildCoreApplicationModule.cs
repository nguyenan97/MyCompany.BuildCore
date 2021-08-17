using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyCompany.BuildCore.Authorization;

namespace MyCompany.BuildCore
{
    [DependsOn(
        typeof(BuildCoreCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BuildCoreApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BuildCoreAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BuildCoreApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
