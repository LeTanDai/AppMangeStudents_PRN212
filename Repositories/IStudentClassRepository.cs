﻿using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IStudentClassRepository
    {
        void CreateStudentClass(StudentClass student);
        void UpdateStudentClass(StudentClass student);
        void DeleteStudentClass(StudentClass studentId);
        IEnumerable<Student> GetStudentsByClass(Class cl);
    }
}
