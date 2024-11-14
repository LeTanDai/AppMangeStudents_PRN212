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
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository iAdminRepository;
        public AdminService()
        {
            iAdminRepository = new AdminRepository();
        }

        public void CreateAdmin(Admin Admin)
        {
            iAdminRepository.CreateAdmin(Admin);
        }

        public void DeleteAdmin(Admin Admin)
        {
            iAdminRepository.DeleteAdmin(Admin);
        }

        public Admin GetAdminByID(string id)
        {
            return iAdminRepository.GetAdminByID(id);
        }

        public List<Admin> GetAllAdmins()
        {
            return iAdminRepository.GetAllAdmins();
        }

        public void UpdateAdmin(Admin Admin)
        {
            iAdminRepository.UpdateAdmin(Admin);
        }
    }
}
