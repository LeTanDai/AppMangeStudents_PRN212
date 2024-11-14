using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class StudentDAO
    {
        private static StudentDAO instance = null;
        private static readonly object instanceLock = new object();
        public static StudentDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new StudentDAO();
                    }
                    return instance;
                }
            }
        }

        public void CreateStudent(Student student)
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                try
                {
                    db.Students.Add(student);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void UpdateStudent(Student student)
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                try
                {
                    db.Entry<Student>(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void DeleteStudent(Student student)
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                try
                {
                    var existingStudent = db.Students.FirstOrDefault(x => x.Idstudent == student.Idstudent);
                    if (existingStudent != null)
                    {
                        db.Students.Remove(existingStudent);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public Student GetStudentByID(string id)
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                return db.Students.FirstOrDefault(b => b.Idstudent.Equals(id));
            }
        }
    }
}
