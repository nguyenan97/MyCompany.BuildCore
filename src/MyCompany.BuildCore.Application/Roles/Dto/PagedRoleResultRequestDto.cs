using Abp.Application.Services.Dto;

namespace MyCompany.BuildCore.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

