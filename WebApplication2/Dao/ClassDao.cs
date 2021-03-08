using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;
using WebApplication2.Controllers;
using PagedList;

namespace WebApplication2.Dao
{
    public class ClassDao
    {
        managerteacher db = null;

        public ClassDao()
        {
            db = new managerteacher();
        }
        public IEnumerable<Class> Listpg(int page, int pageSize)
        {
            return db.Classes.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public List<Class> ListAll()
        {
            return db.Classes.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Classes.Find(id);
                db.Classes.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public Class GetClassById(long id)
        {
            return db.Classes.Find(id);
        }
    }
}