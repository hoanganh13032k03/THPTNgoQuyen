using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.ET;
namespace DBModel.DAO
{
    public class MenuDao
    {
        DBContext db = null;

        public MenuDao()
        {

            db = new DBContext();
        }
        public List<Menu> ToList()
        {
            return db.Menus.ToList<Menu>();
        }
        public bool Insert(Menu mode)
        {
            try
            {
               
                db.Menus.Add(mode);
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
                var bd = db.Menus.SingleOrDefault(a => a.MenuID == ID);
                db.Menus.Remove(bd);
                db.SaveChanges();
                return true;

            }

            catch
            {
                return false;
            }
           
          
        }
        public Menu FindByID(long ID)
        {

            return db.Menus.Where(a => a.MenuID == ID).SingleOrDefault();
        }
        public List<Menu> FindByMenuType(string  MenuTypeID)
        {

            return db.Menus.Where(a => a.GroupID == MenuTypeID).ToList<Menu>();
        }
        public List<Menu> FindChildMenu(long MenuID)
        {

            return db.Menus.Where(a => a.ParentID == MenuID).ToList<Menu>();
        }
        public bool Update(Menu mode)
        {
            try
            {
                var bd = db.Menus.Find(mode.MenuID);
               // bd.ID = buider.GroupID;
                bd.Name = mode.Name;
                bd.IsActived = mode.IsActived;
                bd.IsDeleted = mode.IsDeleted;
                bd.UpdatedBy = mode.UpdatedBy;
                bd.UpdatedDate = mode.UpdatedDate;
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
