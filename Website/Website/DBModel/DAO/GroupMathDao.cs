using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.ET;
using Common;
namespace DBModel.DAO
{
    public class GroupMathDao
    {
        DBContext db = null;

        public GroupMathDao()
        {

            db = new DBContext();
        }
        public List<GroupMath> ToList()
        {
             return db.GroupMaths.OrderBy(x=>x.DisplayOrder).ToList<GroupMath>();
        }
      
       
        public bool Insert(GroupMath mode)
        {
            try
            {
                if (string.IsNullOrEmpty(mode.MetaTite))
                {
                    
                    mode.MetaTite = HepperString.ToUnsignString(mode.Name);
                }
                if (string.IsNullOrEmpty(mode.SeoTite))
                {

                    mode.SeoTite =mode.Name;
                }
                db.GroupMaths.Add(mode);
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
                var bd = db.GroupMaths.SingleOrDefault(a => a.GroupMathsID == ID);
                db.GroupMaths.Remove(bd);
                db.SaveChanges();
                return true;

            }

            catch
            {
                return false;
            }
           
          
        }
        public GroupMath FindByID(long ID)
        {

            return db.GroupMaths.Where(a => a.GroupMathsID == ID).SingleOrDefault();
        }
      
        public bool Update(GroupMath mode)
        {
            try
            {
                var bd = db.GroupMaths.Find(mode.GroupMathsID);
                if (string.IsNullOrEmpty(mode.MetaTite))
                {

                    bd.MetaTite = HepperString.ToUnsignString(mode.Name);
                }
                else
                {
                    bd.MetaTite = mode.MetaTite;
                }
                if (string.IsNullOrEmpty(mode.SeoTite))
                {

                    bd.SeoTite = mode.Name;
                }
                else
                {
                    bd.SeoTite = mode.SeoTite;
                }
                // bd.GroupMathID = mode.GroupMathID;
                //bd.CreateBy = mode.CreateBy;
                //bd.CreateDate = mode.CreateDate;
                bd.Description = mode.Description;
                bd.DisplayOrder = mode.DisplayOrder;
              
               
               // bd.LanguageID = mode.LanguageID;
                bd.MetaDescription = mode.MetaDescription;
                bd.MetakeyWords = mode.MetakeyWords;
            
                bd.ModifiedBy = mode.ModifiedBy;
                bd.ModifiedDate = mode.ModifiedDate;
               
             
                bd.ShowOnHome = mode.ShowOnHome;
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
