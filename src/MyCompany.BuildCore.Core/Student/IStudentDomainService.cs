using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.BuildCore.Student
{
    public interface IStudentDomainService
    {
        Task<Entities.Student> GetByStudentIdAsync(Guid studentID);

        IQueryable<Entities.Student> BuildGetStudentQuery(Expression<Func<Entities.Student, bool>> conditions = null, params Expression<Func<Entities.Student, object>>[] includingModels);

        IQueryable<Entities.Student> ApplySort(IQueryable<Entities.Student> query, string sortColumn, string sortOrder);

        Task<Entities.Student> CreateAsync(Entities.Student studentEntity);

        Task<Entities.Student> UpdateAsync(Entities.Student studentEntity);

        Task DeleteAsync(Guid studentId);
    }
}
