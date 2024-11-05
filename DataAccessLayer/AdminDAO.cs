using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AdminDAO
    {
        private static AdminDAO instance = null;
        private static readonly object instanceLock = new object();
        public static AdminDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AdminDAO();
                    }
                    return instance;
                }
            }
        }

        public Admin GetAdminByID(string id)
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                return db.Admins.FirstOrDefault(b => b.Id.Equals(id));
            }
        }
    }
}
