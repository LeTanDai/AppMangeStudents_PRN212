using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ITeacherRepository
    {
        void CreateTeacher(Teacher teacher);
        void UpdateTeacher(Teacher teacher);
        void DeleteTeacher(Teacher teacher);
        Teacher GetTeacherByID(string id);
        List<Teacher> GetAllTeachers();
    }
}
