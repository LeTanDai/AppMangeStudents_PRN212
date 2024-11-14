using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class MarkRepository : IMarkRepository   
    {
        public void Updatemark(Mark mark) => MarkDAO.Instance.Updatemark(mark);


        public IEnumerable<Mark> GetallMarks() => MarkDAO.Instance.GetallMarks();


        public IEnumerable<Mark> GetMarksByClass(string className) => MarkDAO.Instance.GetMarksByClass(className);


        public IEnumerable<Mark> GetMarksBySubject(string subjectId) => MarkDAO.Instance.GetMarksBySubject(subjectId);


        public IEnumerable<Mark> GetMarksBySemester(string semester) => MarkDAO.Instance.GetMarksBySemester(semester);
        public string GetSchoolYearById(string idStudent) => MarkDAO.Instance.GetSchoolYearById(idStudent);
        public string GetSemById(string idStudent) => MarkDAO.Instance.GetSemById(idStudent);
        public IEnumerable<Mark> GetMarksByStudent(string idStudent) => MarkDAO.Instance.GetMarksByStudent(idStudent);

    }
}
