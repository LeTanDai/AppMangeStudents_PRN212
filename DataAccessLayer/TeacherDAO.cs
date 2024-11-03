using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TeacherDAO
    {
        private static TeacherDAO instance = null;
        private static readonly object instanceLock = new object();
        public static TeacherDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TeacherDAO();
                    }
                    return instance;
                }
            }
        }

        public void CreateTeacher(Teacher teacher)
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                try
                {
                    db.Teachers.Add(teacher);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void UpdateTeacher(Teacher teacher)
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                try
                {
                    db.Entry<Teacher>(teacher).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void DeleteTeacher(Teacher teacher)
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                try
                {
                    var existingTeacher = db.Teachers.FirstOrDefault(x => x.Idteacher == teacher.Idteacher);
                    if (existingTeacher != null)
                    {
                        db.Teachers.Remove(existingTeacher);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public Teacher GetTeacherByID(string id)
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                return db.Teachers.FirstOrDefault(b => b.Idteacher.Equals(id));
            }
        }
    }
}
