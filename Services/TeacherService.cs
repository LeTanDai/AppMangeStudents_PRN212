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
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository iTeacherRepository;
        public TeacherService()
        {
            iTeacherRepository = new TeacherRepository();
        }
        public IEnumerable<Teacher> GetTeachers()
        {
            return iTeacherRepository.GetTeachers();
        }

        public void CreateTeacher(Teacher teacher)
        {
            iTeacherRepository.CreateTeacher(teacher);
        }
        public void UpdateTeacher(Teacher teacher)
        {
            iTeacherRepository.UpdateTeacher(teacher);
        }
        public void DeleteTeacher(Teacher teacher)
        {
            iTeacherRepository.DeleteTeacher(teacher);
        }
        public Teacher GetTeacherByID(string id)
        {
            return iTeacherRepository.GetTeacherByID(id);
        }

        public void Register(string id, string password)
        {
            iTeacherRepository.Register(id, password);
        }

    }
}
