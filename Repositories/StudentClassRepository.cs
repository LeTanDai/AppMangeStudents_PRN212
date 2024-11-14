using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class StudentClassRepository : IStudentClassRepository
    {
        public IEnumerable<StudentClass> GetAllStudentClasses() => StudentClassDAO.Instance.GetAllStudentClasses();
        public void CreateStudentClass(StudentClass student) => StudentClassDAO.Instance.CreateStudentClass(student);
        public void UpdateStudentClass(StudentClass student) => StudentClassDAO.Instance.UpdateStudentClass(student);
        public void DeleteStudentClass(StudentClass student) => StudentClassDAO.Instance.DeleteStudentClass(student);
        public IEnumerable<Student> GetStudentsByClass(Class cl) => StudentClassDAO.Instance.GetStudentsByClass(cl);
    }
}
