using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.ET;
namespace DBModel.DAO
{
    public class FooterDao
    {
        DBContext db = null;

        public FooterDao()
        {

            db = new DBContext();
        }
        public List<Footer> ToList()
        {
            return db.Footers.ToList<Footer>();
        }
        public bool Insert(Footer mode)
        {
            try
            {
               
                db.Footers.Add(mode);
                db.SaveChanges();
                return true;

            }

            catch
            {
                return false;
            }


        }
        public bool Delete(string ID)
        {
            try
            {
                var bd = db.Footers.SingleOrDefault(a => a.ID == ID);
                db.Footers.Remove(bd);
                db.SaveChanges();
                return true;

            }

            catch
            {
                return false;
            }
           
          
        }
        public Footer FindByID(string ID)
        {

            return db.Footers.Where(a => a.ID == ID).SingleOrDefault();
        }
        
        public bool Update(Footer mode)
        {
            try
            {
                var bd = db.Footers.Find(mode.ID);
               // bd.ID = buider.GroupID;
                bd.LanguageID = mode.LanguageID;
                bd.Status = mode.Status;
                bd.Detail = mode.Detail;
               
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }


        }
    }
}
