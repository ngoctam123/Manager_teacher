using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Common
{
    [Serializable]
    public class UserLogin
    {
        public int ID { set; get; }
        public string UserName { set; get; }
        public string Name { set; get; }
        public string GroupID { set; get; }
    }
}