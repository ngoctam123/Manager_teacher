using WebApplication2.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApplication2.Dao
{
    public class UserDao
    {
        managerteacher db = null;
        public UserDao()
        {
            db = new managerteacher();

        }
        public IEnumerable<User> Listpg(int page, int pageSize)
        {
            return db.Users.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public List<User> ListAll()
        {
            return db.Users.ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                var users = db.Users.Find(id);
                db.Users.Remove(users);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public List<string> GetListCredential(string userName)
        {
            var user = db.Users.Single(x => x.UserName == userName);
            var data = (from a in db.Credentials
                        join b in db.GroupUsers on a.UserGroupID equals b.ID
                        join c in db.Roles on a.RoleID equals c.ID
                        where b.ID == user.GroupID
                        select new
                        {
                            RoleID = a.RoleID,
                            UserGroupID = a.UserGroupID
                        }).AsEnumerable().Select(x => new Credential()
                        {
                            RoleID = x.RoleID,
                            UserGroupID = x.UserGroupID
                        });
            return data.Select(x => x.RoleID).ToList();

        }
        public User Get(string username)
        {
            return db.Users.SingleOrDefault(x => x.UserName == username);
        }
        public int Login(string username, string password, bool isLoginAdmin = false)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == username);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.GroupID == WebApplication2.CommonConstants.ADMIN_GROUP || result.GroupID == WebApplication2.CommonConstants.MEMBER_GROUP)
                    {
                        if (result.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.Password == password)
                                return 1;
                            else
                                return -2;
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {
                    if (result.Status == false)
                    {
                        return -1;
                    }
                    else
                    {
                        if (result.Password == password)
                            return 1;
                        else
                            return -2;
                    }
                }
            }

        }
    }

}
