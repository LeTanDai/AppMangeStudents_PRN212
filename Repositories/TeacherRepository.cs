﻿using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        public IEnumerable<Teacher> GetTeachers() => TeacherDAO.Instance.GetTeachers();
        public void CreateTeacher(Teacher teacher) => TeacherDAO.Instance.CreateTeacher(teacher);
        public void UpdateTeacher(Teacher teacher) => TeacherDAO.Instance.UpdateTeacher(teacher);
        public void DeleteTeacher(Teacher teacher) => TeacherDAO.Instance.DeleteTeacher(teacher);
        public Teacher GetTeacherByID(string id) => TeacherDAO.Instance.GetTeacherByID(id);
        public void Register(string id, string password) => TeacherDAO.Instance.Register(id, password);
    }
}
