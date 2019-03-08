using SchoolMachine.Contracts.EntityRepositories;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using SchoolMachine.DataAccess.Entities.Models.SchoolData.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMachine.Repository.Entities
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        #region Constructors

        public StudentRepository(SchoolMachineContext repositoryContext)
            : base(repositoryContext)
        {
        }

        #endregion Constructors

        #region Public Methods

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            return (await FindAll()).OrderBy(ow => ow.LastName);
        }

        public async Task<Student> GetStudentById(Guid studentId)
        {
            return (await FindByCondition(student => student.Id.Equals(studentId)))
                    .DefaultIfEmpty(new Student())
                    .FirstOrDefault();
        }

        public async Task<IQueryable<School>> GetSchoolsByStudentId(Guid studentId)
        {
            await Task.Delay(0);
            var schools = from schoolStudent in RepositoryContext.SchoolStudents
                           join school in RepositoryContext.Schools on schoolStudent.SchoolId equals school.Id
                           where (schoolStudent.StudentId == studentId)
                           select school;
            return schools;
        }

        public async Task<IQueryable<Student>> GetStudentsBySchoolId(Guid schoolId)
        {
            await Task.Delay(0);
            var students = from schoolStudent in RepositoryContext.SchoolStudents
                           join student in RepositoryContext.Students on schoolStudent.StudentId equals student.Id
                           where (schoolStudent.SchoolId == schoolId)
                           select student;
            return students;
        }

        public async Task CreateStudent(Student student)
        {
            student.Id = Guid.NewGuid();
            await Create(student);
            await Save();
        }

        public async Task UpdateStudent(Student dbStudent, Student student)
        {
            dbStudent.Map(student);
            await Update(dbStudent);
            await Save();
        }

        public async Task DeleteStudent(Student student)
        {
            await Delete(student);
            await Save();
        }

        #endregion Public Methods
    }
}
