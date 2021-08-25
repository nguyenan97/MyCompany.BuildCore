using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyCompany.BuildCore.Entities
{
    public class Student : FullAuditedEntity
    {
        [Key]
        public Guid StudentId { get; set; }

        [StringLength(256)]
        public string Name { get; set; }
    }
}
