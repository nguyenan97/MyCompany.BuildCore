using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompany.BuildCore.Api_Internal.Student.Dto
{
    public class SearchStudentRequestDto : PagedResultRequestDto
    {
        /// <summary> Keyword</summary>
        public string Keyword { get; set; }

        /// <summary> SortBy</summary>
        public string SortBy { get; set; }

        /// <summary> SortDirection</summary>
        public string SortDirection { get; set; }
    }
}
