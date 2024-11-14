using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllStudent();

        void CreateStudent(Student student);
        void DeleteStudent(Student student);
        void UpdateStudent(Student student);
        Student GetStudentByID(string id);
        void Register(string id, string password);
    }
}
