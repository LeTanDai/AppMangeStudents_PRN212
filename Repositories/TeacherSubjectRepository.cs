using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class TeacherSubjectRepository : ITeacherSubjectRepository
    {
        public void CreateTeacherSubject(TeacherSubject teacherSubject) => TeacherSubjectDAO.Instance.CreateTeacherSubject(teacherSubject);
        public void UpdateTeacherSubject(TeacherSubject teacherSubject) => TeacherSubjectDAO.Instance.UpdateTeacherSubject(teacherSubject);
        public void DeleteTeacherSubject(TeacherSubject teacherSubject) => TeacherSubjectDAO.Instance.DeleteTeacherSubject(teacherSubject);
        public List<TeacherSubject> GetAllTeachers() => TeacherSubjectDAO.Instance.GetAll();
        public TeacherSubject GetTeacherSubjectById(string teacherId, string subjectId) => TeacherSubjectDAO.Instance.GetTeacherSubjectById(teacherId, subjectId);
    }
}
