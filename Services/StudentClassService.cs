using BusinessObjects.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StudentClassService : IStudentClassService
    {
        private readonly IStudentClassRepository iStudentClassRepository;
        public StudentClassService()
        {
            iStudentClassRepository = new StudentClassRepository();
        }
        public IEnumerable<StudentClass> GetAllStudentClasses()
        {
            return iStudentClassRepository.GetAllStudentClasses();
        }

        public void CreateStudentClass(StudentClass student)
        {
            iStudentClassRepository.CreateStudentClass(student);
        }
        public void UpdateStudentClass(StudentClass student)
        {
            iStudentClassRepository.UpdateStudentClass(student);
        }
        public void DeleteStudentClass(StudentClass studentId)
        {
            iStudentClassRepository.DeleteStudentClass(studentId);
        }
        public IEnumerable<Student> GetStudentsByClass(Class cl)
        {
            return iStudentClassRepository.GetStudentsByClass(cl);
        }
    }
}
