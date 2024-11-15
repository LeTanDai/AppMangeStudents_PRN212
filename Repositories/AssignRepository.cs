using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AssignRepository : IAssignRepository
    {
        public void CreateAssign(Assign assign) => AssignDAO.Instance.CreateAssign(assign);
        public void DeleteAssign(Assign assign) => AssignDAO.Instance.DeleteAssign(assign);
        public void UpdateAssign(Assign assign) => AssignDAO.Instance.UpdateAssign(assign);
        public List<Assign> GetAllAssigns() => AssignDAO.Instance.GetAll();
        public List<Assign> GetAssignByTeacherId(string teacherId) => AssignDAO.Instance.GetAssignByTeacherId(teacherId);
    }
}
