
using BusinessObjects.Models;
using System;
using System.Collections.Generic;

namespace Repository
{
    public interface IMarkRepository
    {
        void Updatemark(Mark mark);
        IEnumerable<Mark> GetallMarks();
        IEnumerable<Mark> GetMarksByClass(string className);
        IEnumerable<Mark> GetMarksBySubject(string subjectId);
        IEnumerable<Mark> GetMarksBySemester(string semester);
        string GetSchoolYearById(string idStudent);
        string GetSemById(string idStudent);
        IEnumerable<Mark> GetMarksByStudent(string idStudent);
    }
}
