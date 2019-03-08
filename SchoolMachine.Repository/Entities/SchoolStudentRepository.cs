using SchoolMachine.Contracts.EntityRepositories;
using SchoolMachine.DataAccess.Entities;
using SchoolMachine.DataAccess.Entities.Models.SchoolData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMachine.Repository.Entities
{
    public class SchoolStudentRepository : RepositoryBase<SchoolStudent>, ISchoolStudentRepository
    {
        #region Constructors

        public SchoolStudentRepository(SchoolMachineContext repositoryContext)
            : base(repositoryContext)
        {
        }

        #endregion Constructors

        #region Public Methods

        public async Task<IEnumerable<SchoolStudent>> GetAllSchoolStudents()
        {
            return await FindAll();
        }

        public async Task<SchoolStudent> GetSchoolStudentById(Guid schoolStudentId)
        {
            return (await FindByCondition(schooltudent => schooltudent.Id.Equals(schoolStudentId)))
                    .DefaultIfEmpty(new SchoolStudent())
                    .FirstOrDefault();
        }

        public async Task<IEnumerable<SchoolStudent>> SchoolStudentsBySchool(Guid schoolId)
        {
            return await FindByCondition(a => a.SchoolId.Equals(schoolId));
        }

        public async Task<IEnumerable<Student>> StudentsBySchool(Guid schoolId)
        {
            await Task.Delay(0);
            var students = from schoolStudent in RepositoryContext.SchoolStudents
                           join student in RepositoryContext.Students on schoolStudent.StudentId equals student.Id
                           where (schoolStudent.SchoolId == schoolId)
                           select student;
            return students;
        }

        public async Task<IEnumerable<SchoolStudent>> SchoolStudentsByStudent(Guid studentId)
        {
            return await FindByCondition(a => a.StudentId.Equals(studentId));
        }

        public async Task CreateSchoolStudent(SchoolStudent schoolStudent)
        {
            schoolStudent.Id = Guid.NewGuid();
            await Create(schoolStudent);
            await Save();
        }

        public async Task UpdateSchoolStudent(SchoolStudent dbSchoolStudent, SchoolStudent schoolStudent)
        {
            dbSchoolStudent.GradeLevel = schoolStudent.GradeLevel;
            dbSchoolStudent.RegistrationDate = schoolStudent.RegistrationDate;
            dbSchoolStudent.SchoolId = schoolStudent.SchoolId;
            dbSchoolStudent.StudentId = schoolStudent.StudentId;
            await Update(dbSchoolStudent);
            await Save();
        }

        public async Task DeleteSchoolStudent(SchoolStudent schoolStudent)
        {
            await Delete(schoolStudent);
            await Save();
        }

        #endregion Public Methods
    }
}
