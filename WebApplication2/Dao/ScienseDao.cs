using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;
using PagedList;

namespace WebApplication2.Dao
{
    public class ScienseDao
    {
        managerteacher db = null;

        public ScienseDao()
        {
            db = new managerteacher();
        }
        public IEnumerable<Science> Listpg(int page, int pageSize)
        {
            return db.Sciences.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public List<Science> ListAll()
        {
            return db.Sciences.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Sciences.Find(id);
                db.Sciences.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public Science GetScienceById(long id)
        {
            return db.Sciences.Find(id);
        }
    }
}