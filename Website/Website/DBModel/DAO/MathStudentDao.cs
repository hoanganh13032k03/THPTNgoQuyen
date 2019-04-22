using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.ET;
using Common;
namespace DBModel.DAO
{
    public class MathStudentDao
    {
        DBContext db = null;

        public MathStudentDao()
        {

            db = new DBContext();
        }
        public List<MathStudent> ToList()
        {
            return db.MathStudents.OrderBy(x=>x.DisplayOrder).ToList<MathStudent>();
        }
        public List<MathStudent> ToListActive()
        {
            return db.MathStudents.Where(x=>x.Status==true).OrderBy(x => x.DisplayOrder).ToList<MathStudent>();
        }
        public List<MathStudent> ToListActiveHome()
        {
            return db.MathStudents.Where(x => x.Status == true &&  x.DisplayOrder==1 ).OrderBy(x => x.DisplayOrder).ToList<MathStudent>();
        }
        public List<MathStudent> ToListByGroupID( long id)
        {
            return db.MathStudents.Where(x => x.GroupMathsID == id ).OrderBy(x => x.DisplayOrder).ToList<MathStudent>();
        }

        public bool Insert(MathStudent mode)
        {
            try
            {
               
                db.MathStudents.Add(mode);
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
                var bd = db.MathStudents.SingleOrDefault(a => a.MathsID == ID);
                db.MathStudents.Remove(bd);
                db.SaveChanges();
                return true;

            }

            catch
            {
                return false;
            }
           
          
        }
        public MathStudent FindByID(long ID)
        {

            return db.MathStudents.Where(a => a.MathsID== ID).SingleOrDefault();
        }
        public bool Update(MathStudent mode)
        {
            try
            {
                var bd = db.MathStudents.Find(mode.MathsID);
               
                // bd.MathStudentID = mode.MathStudentID;
                //bd.CreateBy = mode.CreateBy;
                //bd.CreateDate = mode.CreateDate;
                bd.Description = mode.Description;
                bd.DisplayOrder = mode.DisplayOrder;
                bd.Image = mode.Image;
                bd.GroupMathsID = mode.GroupMathsID;
                bd.LanguageID = mode.LanguageID;
           
                bd.ModifiedBy = mode.ModifiedBy;
                bd.ModifiedDate = mode.ModifiedDate;

                bd.Name = mode.Name;

                bd.Sources = mode.Sources;
                bd.Status = mode.Status;

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
