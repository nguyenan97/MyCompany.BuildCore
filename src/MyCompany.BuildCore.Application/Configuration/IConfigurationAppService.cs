using System.Threading.Tasks;
using MyCompany.BuildCore.Configuration.Dto;

namespace MyCompany.BuildCore.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
