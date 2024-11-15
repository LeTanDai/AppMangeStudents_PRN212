using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ITeacherSubjectRepository
    {
        void CreateTeacherSubject(TeacherSubject teacherSubject);
        void UpdateTeacherSubject(TeacherSubject teacherSubject);
        void DeleteTeacherSubject(TeacherSubject teacherSubject);
        List<TeacherSubject> GetAllTeachers();
        TeacherSubject GetTeacherSubjectById(string teacherId, string subjectId);
    }
}
