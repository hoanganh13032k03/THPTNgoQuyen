using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.ET;
using Common;
namespace DBModel.DAO
{
    public class AdvertiseDao
    {
        DBContext db = null;

        public AdvertiseDao()
        {

            db = new DBContext();
        }
        public List<Advertise> ToList()
        {
            return db.Advertises.OrderBy(x=>x.DisplayOrder).ToList<Advertise>();
        }
        public List<Advertise> ToListActive()
        {
            return db.Advertises.Where(x=>x.Status==true).OrderBy(x => x.DisplayOrder).ToList<Advertise>();
        }
       
        public bool Insert(Advertise mode)
        {
            try
            {
               
                db.Advertises.Add(mode);
                db.SaveChanges();
                return true;

            }

            catch
            {
                return false;
            }


        }
        public bool Delete(long ID)
        {
            try
            {
                var bd = db.Advertises.SingleOrDefault(a => a.AdvertiseID == ID);
                db.Advertises.Remove(bd);
                db.SaveChanges();
                return true;

            }

            catch
            {
                return false;
            }
           
          
        }
        public Advertise FindByID(long ID)
        {

            return db.Advertises.Where(a => a.AdvertiseID == ID).SingleOrDefault();
        }
        public bool Update(Advertise mode)
        {
            try
            {
                var bd = db.Advertises.Find(mode.AdvertiseID);
               
                // bd.AdvertiseID = mode.AdvertiseID;
                //bd.CreateBy = mode.CreateBy;
                //bd.CreateDate = mode.CreateDate;
                bd.Description = mode.Description;
                bd.DisplayOrder = mode.DisplayOrder;
                bd.Image = mode.Image;
               
                bd.LanguageID = mode.LanguageID;
           
                bd.ModifiedBy = mode.ModifiedBy;
                bd.ModifiedDate = mode.ModifiedDate;

                bd.Name = mode.Name;

                bd.Link = mode.Link;
                bd.Status = mode.Status;
                bd.Target = mode.Target;

                bd.Heigt = mode.Heigt;
                bd.Wide = mode.Wide;
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
