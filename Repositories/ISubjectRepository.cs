
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reppositories
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAllSubjects();
        void AddSubject(Subject subject);
        void UpdateSubject(Subject subject);
        Subject GetSubject(string id);
    }
}
