using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;
using PagedList;

namespace WebApplication2.Dao
{
    public class TypeCalendarDao
    {
        managerteacher db = null;

        public TypeCalendarDao()
        {
            db = new managerteacher();
        }
        public IEnumerable<TypeCalendar> Listpg(int page, int pageSize)
        {
            return db.TypeCalendars.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }
        public List<TypeCalendar> ListAll()
        {
            return db.TypeCalendars.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.TypeCalendars.Find(id);
                db.TypeCalendars.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public TypeCalendar ViewDetailTypeCalendar(long id)
        {
            return db.TypeCalendars.Find(id);
        }
    }
}