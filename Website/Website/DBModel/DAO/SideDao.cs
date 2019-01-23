using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.ET;
using Common;
namespace DBModel.DAO
{
    public class SideDao
    {
        DBContext db = null;

        public SideDao()
        {

            db = new DBContext();
        }
        public List<Side> ToList()
        {
            return db.Sides.OrderBy(x=>x.DisplayOrder).ToList<Side>();
        }
        public List<Side> ToListActive()
        {
            return db.Sides.Where(x=>x.Status==true).OrderBy(x => x.DisplayOrder).ToList<Side>();
        }
       
        public bool Insert(Side mode)
        {
            try
            {
               
                db.Sides.Add(mode);
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
                var bd = db.Sides.SingleOrDefault(a => a.SideID == ID);
                db.Sides.Remove(bd);
                db.SaveChanges();
                return true;

            }

            catch
            {
                return false;
            }
           
          
        }
        public Side FindByID(long ID)
        {

            return db.Sides.Where(a => a.SideID == ID).SingleOrDefault();
        }
        public List<Side> FindBySideType(string  GroupID)
        {

            return db.Sides.Where(a => a.GroupID == GroupID).ToList<Side>();
        }
     
        public bool Update(Side mode)
        {
            try
            {
                var bd = db.Sides.Find(mode.SideID);
               
                // bd.SideID = mode.SideID;
                //bd.CreateBy = mode.CreateBy;
                //bd.CreateDate = mode.CreateDate;
                bd.Description = mode.Description;
                bd.DisplayOrder = mode.DisplayOrder;
                bd.Image = mode.Image;
               
                bd.LanguageID = mode.LanguageID;
           
                bd.ModifiedBy = mode.ModifiedBy;
                bd.ModifiedDate = mode.ModifiedDate;
              
                bd.GroupID = mode.GroupID;
             
                bd.Link = mode.Link;
                bd.Status = mode.Status;
                bd.Target = mode.Target;

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
