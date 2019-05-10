using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.ET;
using Common;
using PagedList;
namespace DBModel.DAO
{
    public class VideosDao
    {
        DBContext db = null;
       


        /// <summary>
        /// List all content for client
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Videos> ListAllPaging(ref int totallPage,int page=1, int pageSize=5)
        {
            totallPage = ToList().Count();
            List<Videos> model = ToList().ToPagedList(page, pageSize).ToList();
            return model;
        }
        /// <summary>
        /// List all content for client
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Videos> ListActivePaging(ref int totallPage, int page=1, int pageSize=5)
        {
            totallPage = ToListActive().Count();
            List<Videos> model = ToListActive().ToPagedList(page, pageSize).ToList();
            return model;
        }
        public VideosDao()
        {

            db = new DBContext();
        }
        public List<Videos> ToList()
        {
            return db.Videos.OrderBy(x=>x.DisplayOrder).ToList<Videos>();
        }
        public List<Videos> ToListActive()
        {
            return db.Videos.Where(x=>x.Status==true).OrderBy(x => x.DisplayOrder).ToList<Videos>();
        }
       
        public bool Insert(Videos mode)
        {
            try
            {
               
                db.Videos.Add(mode);
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
                var bd = db.Videos.SingleOrDefault(a => a.VideosID == ID);
                db.Videos.Remove(bd);
                db.SaveChanges();
                return true;

            }

            catch
            {
                return false;
            }
           
          
        }
        public Videos FindByID(long ID)
        {

            return db.Videos.Where(a => a.VideosID == ID).SingleOrDefault();
        }
        public bool Update(Videos mode)
        {
            try
            {
                var bd = db.Videos.Find(mode.VideosID);
               
                // bd.VideosID = mode.VideosID;
                //bd.CreateBy = mode.CreateBy;
                //bd.CreateDate = mode.CreateDate;
                bd.Description = mode.Description;
                bd.DisplayOrder = mode.DisplayOrder;
                bd.Image = mode.Image;
               
             //   bd.LanguageID = mode.LanguageID;
           
                bd.ModifiedBy = mode.ModifiedBy;
                bd.ModifiedDate = mode.ModifiedDate;

                bd.Name = mode.Name;

                bd.Link = mode.Link;
                bd.ShowOnHome = mode.ShowOnHome;
                bd.Status = mode.Status;
                bd.Target = mode.Target;
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
