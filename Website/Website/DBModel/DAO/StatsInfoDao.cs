using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.ET;
using Common;
namespace DBModel.DAO
{
    public class StatsInfoDao
    {
        DBContext db = null;

        public StatsInfoDao()
        {

            db = new DBContext();
        }
        public List<StatsInfo> ToList()
        {
            return db.StatsInfoes.OrderBy(x=>x.DisplayOrder).ToList<StatsInfo>();
        }
        public List<StatsInfo> ToListActive()
        {
            return db.StatsInfoes.Where(x=>x.Status==true).OrderBy(x => x.DisplayOrder).ToList<StatsInfo>();
        }
       
        public bool Insert(StatsInfo mode)
        {
            try
            {
               
                db.StatsInfoes.Add(mode);
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
                var bd = db.StatsInfoes.SingleOrDefault(a => a.StasInfoID == ID);
                db.StatsInfoes.Remove(bd);
                db.SaveChanges();
                return true;

            }

            catch
            {
                return false;
            }
           
          
        }
        public StatsInfo FindByID(long ID)
        {

            return db.StatsInfoes.Where(a => a.StasInfoID == ID).SingleOrDefault();
        }
      
        public bool Update(StatsInfo mode)
        {
            try
            {
                var bd = db.StatsInfoes.Find(mode.StasInfoID);
               
                // bd.StatsInfoID = mode.StatsInfoID;
                //bd.CreateBy = mode.CreateBy;
                //bd.CreateDate = mode.CreateDate;
                bd.Description = mode.Description;
                bd.DisplayOrder = mode.DisplayOrder;
               
               
                bd.LanguageID = mode.LanguageID;
           
                bd.ModifiedBy = mode.ModifiedBy;
                bd.ModifiedDate = mode.ModifiedDate;
              
              
                bd.Number = mode.Number;
                bd.Speed = mode.Speed;
               
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
