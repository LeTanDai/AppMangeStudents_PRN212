using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AssignDAO
    {
        private static AssignDAO instance = new AssignDAO();
        private static readonly object instanceLock = new object();
        public static AssignDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AssignDAO();
                }
                return instance;
            }
        }
        public List<Assign> GetAll()
        {
            List<Assign> list = new List<Assign>();
            try
            {
                var db = new Prn212ManageStudentsContext();
                list = db.Assigns.Include(a => a.Class).Include(a => a.TeacherSubject).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
        public void CreateAssign(Assign assign)
        {
            try
            {
                var db = new Prn212ManageStudentsContext();
                db.Assigns.Add(assign);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateAssign(Assign assign)
        {
            try
            {
                var db = new Prn212ManageStudentsContext();
                db.Entry(assign).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteAssign(Assign assign)
        {
            try
            {
                var db = new Prn212ManageStudentsContext();
                db.Assigns.Remove(assign);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Assign> GetAssignByTeacherId(string teacherId)
        {
            List<Assign> list = new List<Assign>();
            try
            {
                var db = new Prn212ManageStudentsContext();
                list = db.Assigns.Where(a => a.Idteacher.Equals(teacherId)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
    }
}
