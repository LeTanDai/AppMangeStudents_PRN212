using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IClassRepository
    {
        IEnumerable<Class> GetClasses();
        void CreateClass(Class cl);
        void UpdateClass(Class cl);
        void DeleteClass(Class cl);
        Class GetClass(string clName, string schoolY);
    }
}
