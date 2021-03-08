using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Dao;
using WebApplication2.Models;
using WebApplication2.ViewModel;
using PagedList;

namespace WebApplication2.Dao
{
    public class CalendarWorkingDao
    {
        managerteacher db = null;

        public CalendarWorkingDao()
        {
            db = new managerteacher();
        }
        public IEnumerable<CalendarWorking> Listpg(int page, int pageSize)
        {
            return db.CalendarWorkings.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public List<CalendarWorking> ListAll()
        {
            return db.CalendarWorkings.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.CalendarWorkings.Find(id);
                db.CalendarWorkings.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public CalendarWorking ViewDetails(int id)
        {
            return db.CalendarWorkings.Find(id);
        }
    }
}