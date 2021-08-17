using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyCompany.BuildCore.Configuration;

namespace MyCompany.BuildCore.Web.Host.Startup
{
    [DependsOn(
       typeof(BuildCoreWebCoreModule))]
    public class BuildCoreWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BuildCoreWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BuildCoreWebHostModule).GetAssembly());
        }
    }
}
