using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IAdminRepository
    {
        Admin GetAdminByID(string id);
        List<Admin> GetAllAdmins();
        void CreateAdmin(Admin Admin);
        void UpdateAdmin(Admin Admin);
        void DeleteAdmin(Admin Admin);
    }

}
