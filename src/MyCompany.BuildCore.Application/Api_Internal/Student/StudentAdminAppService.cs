using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using MyCompany.BuildCore.Api_Internal.Student.Dto;
using MyCompany.BuildCore.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.BuildCore.Api_Internal.Student
{
    [AbpAuthorize]
    [Route("api/admin/student")]
    public class StudentAdminAppService : ApplicationService, IStudentAdminAppService
    {
        private readonly IStudentDomainService _studentDomainService;

        public StudentAdminAppService(IStudentDomainService studentDomainService)
        {
            _studentDomainService = studentDomainService;
        }

        [HttpPost("Create")]
        public async Task<Guid> CreateAsync(CreateStudentDto createDto)
        {
            var sudentEntity = await _studentDomainService.CreateAsync(new Entities.Student()
            {
                StudentId = Guid.NewGuid(),
                Name = createDto.Name
            });

            return sudentEntity.StudentId;
        }

        [HttpPost("Delete")]
        public async Task DeleteAsync(Guid studentId)
        {
            await _studentDomainService.DeleteAsync(studentId);
        }

        [HttpGet("GetAll")]
        public PagedResultDto<StudentSearchResultCmsDto> GetAll(SearchStudentRequestDto searchRequest)
        {
            var studentQuery = _studentDomainService.BuildGetStudentQuery();

            studentQuery = _studentDomainService.ApplySort(studentQuery, searchRequest.SortBy, searchRequest.SortDirection);

            //count rows
            int countRow = studentQuery.Count();

            // pagination
            var pageResult = studentQuery.Skip(searchRequest.SkipCount)
                .Take(searchRequest.MaxResultCount).Select(x => new StudentSearchResultCmsDto()
                {
                    StudentId = x.StudentId,
                    Name = x.Name
                }).ToList();

            return new PagedResultDto<StudentSearchResultCmsDto>()
            {
                Items = pageResult,
                TotalCount = countRow
            };
        }

        [HttpGet("GetById")]
        public async Task<StudentCmsDto> GetByIdAsync(Guid studentId)
        {
            var studentEntity = await _studentDomainService.GetByStudentIdAsync(studentId);
            return new StudentCmsDto()
            {
                Name = studentEntity?.Name,
                StudentId = studentEntity?.StudentId ?? Guid.Empty
            };
        }

        [HttpPost("Update")]
        public async Task UpdateAsync(UpdateStudentDto editDto)
        {
            var studentEntity = await _studentDomainService.GetByStudentIdAsync(editDto.StudentId);
            if(studentEntity == default)
            {
                throw new UserFriendlyException("EventId not found");
            }
            studentEntity.Name = editDto.Name;

            await _studentDomainService.UpdateAsync(studentEntity);
        }
    }
}
