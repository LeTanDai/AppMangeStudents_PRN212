using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
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
