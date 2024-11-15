using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IAssignRepository
    {
        void CreateAssign(Assign assign);
        void UpdateAssign(Assign assign);
        void DeleteAssign(Assign assign);
        List<Assign> GetAllAssigns();
        List<Assign> GetAssignByTeacherId(string teacherId);
    }
}
