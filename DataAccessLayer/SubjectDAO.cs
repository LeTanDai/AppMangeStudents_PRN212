
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SubjectDAO
    {
        private static SubjectDAO instance = null;
        private static readonly object instanceLock = new object();
        public Prn212ManageStudentsContext _context;
        public static SubjectDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SubjectDAO();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Subject> GetallSubject()
        {
            _context = new();
            return _context.Subjects.ToList();
        }

        public void AddSubject(Subject subject)
        {
            try
            {
                _context = new();
                _context.Subjects.Add(subject);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpgradeSubject(Subject subject)
        {
            try
            {
                _context = new();
                _context.Entry<Subject>(subject).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Subject GetSubjectById(string id)
        {
            try
            {
                _context = new();
                return _context.Subjects.FirstOrDefault(s => s.Idsubject.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
