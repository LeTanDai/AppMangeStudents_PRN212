using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TeacherSubjectDAO
    {
        private static TeacherSubjectDAO instance;
        private static readonly object instanceLock = new object();
        public static TeacherSubjectDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TeacherSubjectDAO();
                }
                return instance;
            }
        }
        public List<TeacherSubject> GetAll()
        {
            List<TeacherSubject> teacherSubjects = new List<TeacherSubject>();
            try
            {
                var db = new Prn212ManageStudentsContext();
                teacherSubjects = db.TeacherSubjects.Include(t => t.IdteacherNavigation).Include(t => t.IdsubjectNavigation).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return teacherSubjects;
        }
        public void CreateTeacherSubject(TeacherSubject teacherSubject)
        {
            try
            {
                var db = new Prn212ManageStudentsContext();
                db.TeacherSubjects.Add(teacherSubject);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateTeacherSubject(TeacherSubject teacherSubject)
        {
            try
            {
                var db = new Prn212ManageStudentsContext();
                db.Entry<TeacherSubject>(teacherSubject).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteTeacherSubject(TeacherSubject teacherSubject)
        {
            try
            {
                var db = new Prn212ManageStudentsContext();
                db.TeacherSubjects.Remove(teacherSubject);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public TeacherSubject GetTeacherSubjectById(string teacherId, string subjectId)
        {
            try
            {
                var db = new Prn212ManageStudentsContext();
                return db.TeacherSubjects.FirstOrDefault(t => t.Idteacher.Equals(teacherId) && t.Idsubject.Equals(subjectId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
