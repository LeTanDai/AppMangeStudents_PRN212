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
        public Admin GetAdminByID(string id)
        {
            return iAdminRepository.GetAdminByID(id);
        }
    }
}
