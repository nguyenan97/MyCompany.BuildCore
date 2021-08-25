using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompany.BuildCore.Api_Internal.Student.Dto
{
    public class UpdateStudentDto
    {
        public Guid StudentId { get; set; }

        public string Name { get; set; }
    }
}
