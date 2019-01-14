using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.ET;
namespace DBModel.DAO
{
    public class CategoryDao
    {
        DBContext db = null;

        public CategoryDao()
        {

            db = new DBContext();
        }
        public List<Category> ToList()
        {
            return db.Categories.ToList<Category>();
        }
        public bool Insert(Category mode)
        {
            try
            {
               
                db.Categories.Add(mode);
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
                var bd = db.Categories.SingleOrDefault(a => a.CategoryID == ID);
                db.Categories.Remove(bd);
                db.SaveChanges();
                return true;

            }

            catch
            {
                return false;
            }
           
          
        }
        public Category FindByID(long ID)
        {

            return db.Categories.Where(a => a.CategoryID == ID).SingleOrDefault();
        }
        public List<Category> FindByCategoryType(byte  Position)
        {

            return db.Categories.Where(a => a.Position == Position).ToList<Category>();
        }
        public List<Category> FindChildCategory(long CategoryID)
        {

            return db.Categories.Where(a => a.ParentID == CategoryID).ToList<Category>();
        }
        public bool Update(Category mode)
        {
            try
            {
                var bd = db.Categories.Find(mode.CategoryID);
          
               // bd.CategoryID = mode.CategoryID;
                //bd.CreateBy = mode.CreateBy;
                //bd.CreateDate = mode.CreateDate;
                bd.Description = mode.Description;
                bd.DisplayOrder = mode.DisplayOrder;
                bd.Image = mode.Image;
                bd.IsIntroduced = mode.IsIntroduced;
                bd.LanguageID = mode.LanguageID;
                bd.MetaDescription = mode.MetaDescription;
                bd.MetakeyWords = mode.MetakeyWords;
                bd.MetaTite = mode.MetaTite;
                bd.ModifiedBy = mode.ModifiedBy;
                bd.ModifiedDate = mode.ModifiedDate;
                bd.ParentID = mode.ParentID;
                bd.Position = mode.Position;
                bd.SeoTite = mode.SeoTite;
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
