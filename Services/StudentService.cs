using BusinessObjects.Models;
using DataAccessLayer;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository iStudentRepository;
        public StudentService()
        {
            iStudentRepository = new StudentRepository();
        }
        public IEnumerable<Student> GetAllStudent()
        {
            return iStudentRepository.GetAllStudent();
        }

        public void CreateStudent(Student student)
        {
            iStudentRepository.CreateStudent(student);
        }
        public void DeleteStudent(Student student)
        {
            iStudentRepository.DeleteStudent(student);
        }
        public void UpdateStudent(Student student)
        {
            iStudentRepository.UpdateStudent(student);
        }
        public Student GetStudentByID(string id)
        {
            return iStudentRepository.GetStudentByID(id);
        }
        public void Register(string id, string password)
        {
            iStudentRepository.Register(id, password);
        }
    }
}
