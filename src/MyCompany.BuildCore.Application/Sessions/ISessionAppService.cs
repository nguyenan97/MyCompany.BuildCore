using System.Threading.Tasks;
using Abp.Application.Services;
using MyCompany.BuildCore.Sessions.Dto;

namespace MyCompany.BuildCore.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
