using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models;
using PagedList;

namespace WebApplication2.Dao
{
    public class StudentDao
    {
         managerteacher db = null;

        public StudentDao()
        {
            db = new managerteacher();
        }
        public IEnumerable<Student> Listpg(int page, int pageSize)
        {
            return db.Students.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public List<Student> ListAll()
        {
            return db.Students.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Students.Find(id);
                db.Students.Remove(user);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<Student> GetListStudentByClassId(long idClass)
        {
            return db.Students.Where(x => x.ClassID == idClass).OrderBy(x => x.Name_Student).ToList();
        }
        public Student GetStudentById(int id)
        {
            return db.Students.Find(id);
        }
    }
}