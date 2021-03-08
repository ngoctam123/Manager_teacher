using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;
using PagedList;

namespace WebApplication2.Dao
{
    public class WorkDao
    {
        managerteacher db = null;

        public WorkDao()
        {
            db = new managerteacher();
        }
        public IEnumerable<Work> Listpg(int page, int pageSize)
        {
            return db.Works.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public List<Work> ListAll()
        {
            return db.Works.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Works.Find(id);
                db.Works.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public Work ViewDetailsWork(long id)
        {
            return db.Works.Find(id);
        }
    }
}