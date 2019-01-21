using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.ET;
using Common;
namespace DBModel.DAO
{
    public class AboutDao
    {
        DBContext db = null;

        public AboutDao()
        {

            db = new DBContext();
        }
        public List<About> ToList()
        {
            return db.Abouts.OrderBy(x=>x.ModifiedDate).ToList<About>();
        }
        public List<About> ToListActive()
        {
            return db.Abouts.Where(x=>x.Status==true).OrderBy(x => x.ModifiedDate).ToList<About>();
        }

        public About ToActive()
        {
            return db.Abouts.Where(x => x.Status == true).OrderBy(x => x.ModifiedDate).SingleOrDefault();
        }
        public bool Insert(About mode)
        {
            try
            {
                if (string.IsNullOrEmpty(mode.MetaTite))
                {
                    
                    mode.MetaTite = HepperString.ToUnsignString(mode.Name);
                }
               
                db.Abouts.Add(mode);
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
                var bd = db.Abouts.SingleOrDefault(a => a.AboutID == ID);
                db.Abouts.Remove(bd);
                db.SaveChanges();
                return true;

            }

            catch
            {
                return false;
            }
           
          
        }
        public About FindByID(long ID)
        {

            return db.Abouts.Where(a => a.AboutID == ID).SingleOrDefault();
        }
       
        public bool Update(About mode)
        {
            try
            {
                var bd = db.Abouts.Find(mode.AboutID);
                if (string.IsNullOrEmpty(mode.MetaTite))
                {

                    bd.MetaTite = HepperString.ToUnsignString(mode.Name);
                }
                else
                {
                    bd.MetaTite = mode.MetaTite;
                }
             
                // bd.AboutID = mode.AboutID;
                //bd.CreateBy = mode.CreateBy;
                //bd.CreateDate = mode.CreateDate;
                bd.Description = mode.Description;
                bd.Phone = mode.Phone;
                bd.Twitter = mode.Twitter;
                bd.Video = mode.Video;
                bd.Address = mode.Address;
                bd.Detail = mode.Detail;
                bd.Email = mode.Email;
                bd.Facebook = mode.Facebook;
                bd.Googleplus = mode.Googleplus;
               
                bd.Image = mode.Image;
               
                bd.LanguageID = mode.LanguageID;
                bd.MetaDescription = mode.MetaDescription;
                bd.MetakeyWords = mode.MetakeyWords;
            
                bd.ModifiedBy = mode.ModifiedBy;
                bd.ModifiedDate = mode.ModifiedDate;
               
                bd.Status = mode.Status;
                bd.Name = mode.Name;


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
