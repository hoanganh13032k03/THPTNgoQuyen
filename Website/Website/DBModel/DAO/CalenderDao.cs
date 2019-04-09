using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.ET;
using Common;
namespace DBModel.DAO
{
    public class CalenderDao
    {
        DBContext db = null;

        public CalenderDao()
        {

            db = new DBContext();
        }
        public List<Calender> ToList()
        {
            return db.Calenders.OrderByDescending(x=>x.ModifiedDate).ToList<Calender>();
        }
        public List<Calender> ToListActive()
        {
            return db.Calenders.Where(x=>x.Active==true).OrderByDescending(x => x.ModifiedDate).ToList<Calender>();
        }
        public List<Calender> ToListActiveWeekYear()
        {
            return db.Calenders.Where(x => x.Active == true).OrderByDescending(x => x.ModifiedDate).ToList<Calender>();
        }

        public bool Insert(Calender mode)
        {
            try
            {
               
                db.Calenders.Add(mode);
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
                var bd = db.Calenders.SingleOrDefault(a => a.CalenderID == ID);
                db.Calenders.Remove(bd);
                db.SaveChanges();
                return true;

            }

            catch
            {
                return false;
            }
           
          
        }
        public Calender FindByID(long ID)
        {

            return db.Calenders.Where(a => a.CalenderID == ID).SingleOrDefault();
        }
        public List<Calender> FindByCalenderType(long  GroupID)
        {

            return db.Calenders.Where(a => a.GroupID == GroupID).ToList<Calender>();
        }
     
        public bool Update(Calender mode)
        {
            try
            {
                var bd = db.Calenders.Find(mode.CalenderID);
               
                // bd.CalenderID = mode.CalenderID;
                //bd.CreateBy = mode.CreateBy;
                //bd.CreateDate = mode.CreateDate;
                bd.Active = mode.Active;
                bd.ActiveDate = mode.ActiveDate;
                bd.Image = mode.Image;
                bd.Date_End = mode.Date_End;
                bd.Date_Start = mode.Date_Start;
                bd.Detail = mode.Detail;
                bd.Files = mode.Files;
                bd.GroupID = mode.GroupID;
                bd.Hour_End = mode.Hour_End;
                bd.Hour_Start = mode.Hour_Start;
                bd.MetaDescription = mode.MetaDescription;
                bd.MetakeyWords = mode.MetakeyWords;
                bd.Minutes_End = mode.Minutes_End;
                bd.Minutes_Start = mode.Minutes_Start;
                bd.Options = mode.Options;
                bd.Organization = mode.Organization;
                bd.Place = mode.Place;
                bd.Prepared = mode.Prepared;
                bd.Publish = mode.Publish;
                bd.PublishDate = mode.PublishDate;
                bd.ShowOnHome = mode.ShowOnHome;
                bd.Status_End = mode.Status_End;
                bd.Status_Start = mode.Status_Start;
                bd.Tite = mode.Tite;

                bd.LanguageID = mode.LanguageID;
           
                bd.ModifiedBy = mode.ModifiedBy;
                bd.ModifiedDate = mode.ModifiedDate;
              
                bd.GroupID = mode.GroupID;

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
