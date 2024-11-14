using BusinessObjects.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AdminRepository : IAdminRepository
    {
        public Admin GetAdminByID(string id) => AdminDAO.Instance.GetAdminByID(id);
    }
}
