﻿using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
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
        public Prn212ManageStudentsContext _context;
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
        public IEnumerable<Student> GetAllStudent()
        {
            using var _context = new Prn212ManageStudentsContext();

            return _context.Students
                           .Include(s => s.StudentClasses)
                           .ThenInclude(sc => sc.Class)
                           .ToList();
        }

        public void CreateStudent(Student student)
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                try
                {
                    var lastStudent = db.Students.OrderByDescending(s => s.Idstudent).FirstOrDefault();
                    if (lastStudent != null)
                    {
                        string lastId = lastStudent.Idstudent;
                        int lastNumber = int.Parse(lastId.Substring(2));
                        student.Idstudent = "ST" + (lastNumber + 1).ToString("D3");
                    }
                    else
                    {
                        student.Idstudent = "ST001";
                    }
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
                    var existingStudent = db.Students
                                            .Include(s => s.StudentClasses)
                                            .FirstOrDefault(x => x.Idstudent == student.Idstudent);

                    if (existingStudent != null)
                    {
                        db.StudentClasses.RemoveRange(existingStudent.StudentClasses);
                        db.Students.Remove(existingStudent);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error while deleting student and related records: " + ex.Message);
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

        public void Register(string id, string password)
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                try
                {
                    Student student = new Student()
                    {
                        Idstudent = id,
                        PassWord = password,
                        Name = null,
                        Gender = null,
                        Email = null,
                        Phone = null,
                        BirthDay = null,
                        IsActive = null
                    };
                    db.Students.Add(student);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
       
    }
    }

