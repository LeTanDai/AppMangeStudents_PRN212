using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public void CreateStudent(Student student) => StudentDAO.Instance.CreateStudent(student);
        public void DeleteStudent(Student student) => StudentDAO.Instance.DeleteStudent(student);
        public void UpdateStudent(Student student) => StudentDAO.Instance.UpdateStudent(student);
        public Student GetStudentByID(string id) => StudentDAO.Instance.GetStudentByID(id);
    }
}
