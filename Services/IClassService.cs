using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IClassService
    {
        IEnumerable<Class> GetClasses();
        void CreateClass(Class cl);
        void UpdateClass(Class cl);
        void DeleteClass(Class cl);
        Class GetClass(string clName, string schoolY);
    }
}
