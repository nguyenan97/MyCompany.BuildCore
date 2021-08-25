using Abp.Application.Services.Dto;
using MyCompany.BuildCore.Api_Internal.Student.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.BuildCore.Web.Models.Student
{
    public class SearchStudentListModel : SearchModel
    {
        public string Keyword { get; set; }
    }

    public class SearchStudentListResultModel : SearchModel
    {
        public PagedResultDto<StudentSearchResultCmsDto> StudentDtoList { get; set; }
    }
}
