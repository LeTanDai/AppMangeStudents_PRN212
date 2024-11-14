using BusinessObjects.Models;
using DataAccessLayer;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository iClassRepository;
        public ClassService()
        {
            iClassRepository = new ClassRepository();
        }

        public IEnumerable<Class> GetClasses()
        {
            return iClassRepository.GetClasses();
        }
        public void CreateClass(Class cl)
        {
            iClassRepository.CreateClass(cl);
        }
        public void UpdateClass(Class cl)
        {
            iClassRepository.UpdateClass(cl);
        }
        public void DeleteClass(Class cl)
        {
            iClassRepository.DeleteClass(cl);
        }
        public Class GetClass(string clName, string schoolY)
        {
            return iClassRepository.GetClass(clName, schoolY);
        }
    }
}
