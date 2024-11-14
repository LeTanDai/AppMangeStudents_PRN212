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

    }
}
