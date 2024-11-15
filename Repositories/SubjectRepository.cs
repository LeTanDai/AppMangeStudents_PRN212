
using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reppositories
{
    public class SubjectRepository : ISubjectRepository
    {
        public IEnumerable<Subject> GetAllSubjects() => SubjectDAO.Instance.GetallSubject();
        public void AddSubject(Subject subject) => SubjectDAO.Instance.AddSubject(subject);
        public void UpdateSubject(Subject subject) => SubjectDAO.Instance.UpgradeSubject(subject);
        public Subject GetSubject(string id) => SubjectDAO.Instance.GetSubjectById(id);
    }
}
