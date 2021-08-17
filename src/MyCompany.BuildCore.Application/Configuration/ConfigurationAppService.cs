using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MyCompany.BuildCore.Configuration.Dto;

namespace MyCompany.BuildCore.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BuildCoreAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
