using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.ET;
namespace DBModel.DAO
{
    public class MenuTypeDao
    {
        DBContext db = null;

        public MenuTypeDao()
        {

            db = new DBContext();
        }
        public List<MenuType> ToList()
        {
            return db.MenuTypes.ToList<MenuType>();
        }
        public bool Insert(MenuType mode)
        {
            try
            {
               
                db.MenuTypes.Add(mode);
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
                var bd = db.MenuTypes.SingleOrDefault(a => a.ID == ID);
                db.MenuTypes.Remove(bd);
                db.SaveChanges();
                return true;

            }

            catch
            {
                return false;
            }
           
          
        }
        public MenuType FindByID(string ID)
        {

            return db.MenuTypes.Where(a => a.ID == ID).SingleOrDefault();
        }
        public bool Update(MenuType mode)
        {
            try
            {
                var bd = db.MenuTypes.Find(mode.ID);
               // bd.ID = buider.GroupID;
                bd.Name = mode.Name;
                bd.IsActived = mode.IsActived;
                bd.IsDeleted = mode.IsDeleted;
                bd.ModifiedBy = mode.ModifiedBy;
                bd.ModifiedDate = mode.ModifiedDate;
                bd.Description = mode.Description;
                //bd.CreateBy = buider.CreateBy;
                //bd.CreateDate = buider.CreateDate;
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
