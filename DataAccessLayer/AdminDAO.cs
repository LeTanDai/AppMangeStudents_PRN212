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
        public void CreateAdmin(Admin Admin)
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                try
                {
                    db.Admins.Add(Admin);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void UpdateAdmin(Admin Admin)
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                try
                {
                    db.Entry<Admin>(Admin).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void DeleteAdmin(Admin Admin)
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                try
                {
                    var existingAdmin = db.Admins.FirstOrDefault(x => x.Id == Admin.Id);
                    if (existingAdmin != null)
                    {
                        db.Admins.Remove(existingAdmin);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
