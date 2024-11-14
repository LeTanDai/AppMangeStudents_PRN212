using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MarkDAO
    {
        private static MarkDAO instance = null;
        private static readonly object instanceLock = new object();
        public  Prn212ManageStudentsContext _context;

        public static MarkDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MarkDAO();
                    }
                    return instance;
                }
            }
        }

            


        public void Updatemark(Mark mark)
        {
            _context = new Prn212ManageStudentsContext();

            // Assuming Mark has a composite key: Idstudent, Idsubject, and Semester
            var existingMark = _context.Marks
                                        .FirstOrDefault(m => m.Idstudent == mark.Idstudent
                                                          && m.Idsubject == mark.Idsubject
                                                          && m.Semester == mark.Semester);

            if (existingMark != null)
            {
                // If the record exists, update its fields
                existingMark.NameClass = mark.NameClass;
                existingMark.ProgressTest1 = mark.ProgressTest1;
                existingMark.ProgressTest2 = mark.ProgressTest2;
                existingMark.Lab1 = mark.Lab1;
                existingMark.Lab2 = mark.Lab2;
                existingMark.FinalExam = mark.FinalExam;
                existingMark.PracticalExam = mark.PracticalExam;
                existingMark.Total = mark.Total;
                existingMark.SchoolYear = mark.SchoolYear;

                // Save changes
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("The mark record you are trying to update does not exist.");
            }
        }


        public IEnumerable<Mark> GetallMarks()
        {
            _context = new();
            return _context.Marks.ToList();
        }


        public IEnumerable<Mark> GetMarksByClass(string className)
        {
            return GetallMarks()
                  .Where(m => m.NameClass == className)
                  .OrderBy(m => m.Idstudent)
                  .ToList();
        }
        
        public IEnumerable<Mark> GetMarksBySubject(string subjectId)
        {

            return GetallMarks()
                  .Where(m => m.Idsubject == subjectId)
                  .OrderBy(m => m.Idstudent)
                  .ToList();
        }

        public IEnumerable<Mark> GetMarksBySemester(string semester)
        {
            return GetallMarks()
                   .Where(m => m.Semester == semester)
                   .OrderBy(m => m.Idstudent)
                   .ToList();
        }
        public string GetSchoolYearById(string idstudent)
        {
            _context = new();

            var mark = _context.Marks
                               .FirstOrDefault(m => m.Idstudent == idstudent);

            return mark?.SchoolYear;
        }

        public string GetSemById(string idstudent)
        {
            _context = new();

            var mark = _context.Marks
                               .FirstOrDefault(m => m.Idstudent == idstudent);

            return mark?.Semester;
        }
        public IEnumerable<Mark> GetMarksByStudent(string idstudent)
        {
            _context = new Prn212ManageStudentsContext();

            return _context.Marks
                           .Where(m => m.Idstudent == idstudent)
                           
                           .ToList();
        }




    }
}
