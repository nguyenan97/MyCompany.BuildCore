using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.BuildCore.Student
{
    public class StudentDomainService : DomainService, IStudentDomainService
    {
        private readonly IRepository<Entities.Student> _studentRepository;
        public StudentDomainService(IRepository<Entities.Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IQueryable<Entities.Student> ApplySort(IQueryable<Entities.Student> query, string sortColumn, string sortOrder)
        {
            return (sortColumn?.ToLower()) switch
            {
                "id" => "desc" == sortOrder ? query.OrderByDescending(x => x.Id) : query.OrderBy(x => x.Id),
                "name" => "desc" == sortOrder ? query.OrderByDescending(x => x.Name) : query.OrderBy(x => x.Name),
                _ => query.OrderByDescending(x => x.CreationTime),
            };
        }

        public IQueryable<Entities.Student> BuildGetStudentQuery(Expression<Func<Entities.Student, bool>> conditions = null, params Expression<Func<Entities.Student, object>>[] includingModels)
        {
            if (conditions != null)
            {
                return _studentRepository.GetAllIncluding(includingModels).Where(conditions);
            }

            return _studentRepository.GetAllIncluding(includingModels);
        }

        public async Task<Entities.Student> CreateAsync(Entities.Student studentEntity)
        {
            return await _studentRepository.InsertAsync(studentEntity);
        }

        public async Task DeleteAsync(Guid studentId)
        {
            await _studentRepository.DeleteAsync(c => c.StudentId == studentId);
        }

        public Task<Entities.Student> GetByStudentIdAsync(Guid studentID)
        {
            throw new NotImplementedException();
        }

        public async Task<Entities.Student> UpdateAsync(Entities.Student studentEntity)
        {
            return await _studentRepository.UpdateAsync(studentEntity);
        }
    }
}
