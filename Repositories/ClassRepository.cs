using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ClassRepository : IClassRepository
    {
        public IEnumerable<Class> GetClasses() => ClassDAO.Instance.GetClasses();
        public void CreateClass(Class cl) => ClassDAO.Instance.CreateClass(cl);
        public void UpdateClass(Class cl)=> ClassDAO.Instance.UpdateClass(cl);
        public void DeleteClass(Class cl)=> ClassDAO.Instance.DeleteClass(cl);
        public Class GetClass(string clName, string schoolY) => ClassDAO.Instance.GetClass(clName, schoolY);
    }
}
