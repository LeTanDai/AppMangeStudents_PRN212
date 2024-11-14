using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class StudentClassDAO
    {
        StudentDAO studentDAO = new StudentDAO();
        private static StudentClassDAO instance = null;
        private static readonly object instanceLock = new object();
        public static StudentClassDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new StudentClassDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<StudentClass> GetAllStudentClasses()
        {
            using var _context = new Prn212ManageStudentsContext();
            return _context.StudentClasses.ToList();
        }
        public void CreateStudentClass(StudentClass studentClass)
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                try
                {
                    Student student = studentDAO.GetStudentByID(studentClass.Idstudent);
                    if (student != null)
                    {
                        db.StudentClasses.Add(studentClass);
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Not have student with this StudentID!");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void UpdateStudentClass(StudentClass studentClass)
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                try
                {
                    db.Entry<StudentClass>(studentClass).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void DeleteStudentClass(StudentClass studentClass)
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                try
                {
                    var existingStudentClass = db.StudentClasses.FirstOrDefault(x => x.Idstudent == studentClass.Idstudent && x.NameClass == studentClass.NameClass);
                    if (existingStudentClass != null)
                    {
                        db.StudentClasses.Remove(existingStudentClass);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public IEnumerable<Student> GetStudentsByClass(Class cl)
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                try
                {
                    return db.StudentClasses
                             .Include(sc => sc.Class)
                             .Include(sc => sc.IdstudentNavigation)
                             .Where(sc => sc.Class.NameClass == cl.NameClass) // Filter by nameClass
                             .Select(sc => sc.IdstudentNavigation) // Select the Student entity
                             .ToList(); // Execute the query and return the list
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        
    }
}
