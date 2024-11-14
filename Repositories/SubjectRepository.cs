
using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        public IEnumerable<Subject> GetAllSubjects() => SubjectDAO.Instance.GetallSubject();
    }
}
