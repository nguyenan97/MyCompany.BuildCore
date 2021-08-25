using Abp.Application.Services.Dto;
using MyCompany.BuildCore.Api_Internal.Student.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.BuildCore.Api_Internal.Student
{
    public interface IStudentAdminAppService
    {
        Task<StudentCmsDto> GetByIdAsync(Guid studentId);

        PagedResultDto<StudentSearchResultCmsDto> GetAll(SearchStudentRequestDto searchRequest);

        Task<Guid> CreateAsync(CreateStudentDto createDto);

        Task UpdateAsync(UpdateStudentDto editDto);

        Task DeleteAsync(Guid studentId);
    }
}
