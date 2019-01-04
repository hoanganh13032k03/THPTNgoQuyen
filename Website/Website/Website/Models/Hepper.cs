using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Security.Cryptography;
using DBModel;
using DBModel.ET;

namespace Models
{
  
    public static class Hepper
    {
        public static DBContext db = new DBContext();
        public static DateTime GetDateServer()
        {
            return db.Database.SqlQuery<DateTime>("spGetSystemDate").SingleOrDefault();
        }





    }
}