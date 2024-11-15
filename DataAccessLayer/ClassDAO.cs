using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ClassDAO
    {
        private static ClassDAO instance = null;
        private static readonly object instanceLock = new object();
        public static ClassDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ClassDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Class> GetClasses()
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                try
                {
                    return db.Classes.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void CreateClass(Class cl)
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                try
                {
                    db.Classes.Add(cl);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void UpdateClass(Class cl)
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                try
                {
                    db.Entry<Class>(cl).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public void DeleteClass(Class cl)
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                try
                {
                    var existingClass = db.Classes.FirstOrDefault(x => x.NameClass == cl.NameClass && x.SchoolYear == cl.SchoolYear);
                    if (existingClass != null)
                    {
                        db.Classes.Remove(existingClass);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public Class GetClass(string clName, string schoolY)
        {
            using (var db = new Prn212ManageStudentsContext())
            {
                return db.Classes.FirstOrDefault(b => b.NameClass == clName && b.SchoolYear == schoolY);
            }
        }
    }

}
