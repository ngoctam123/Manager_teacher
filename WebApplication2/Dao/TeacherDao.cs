using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;
using PagedList;

namespace WebApplication2.Dao
{
    public class TeacherDao
    {
        managerteacher db = null;

        public TeacherDao()
        {
            db = new managerteacher();
        }
        public IEnumerable<Teacher> Listpg(int page, int pageSize)
        {
            return db.Teachers.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public List<Teacher> ListAll()
        {
            return db.Teachers.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Teachers.Find(id);
                db.Teachers.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public Teacher ViewDetails(long id)
        {
            return db.Teachers.Find(id);
        }
        public List<Teacher> GetListTeacherByScienceID(long idScience)
        {
            return db.Teachers.Where(x => x.SicenceID == idScience).OrderByDescending(y => y.CreatedDate).ToList();
        }
    }
}