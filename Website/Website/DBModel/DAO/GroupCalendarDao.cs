using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBModel.ET;
namespace DBModel.DAO
{
    public class GroupCalendarDao
    {
        DBContext db = null;

        public GroupCalendarDao()
        {

            db = new DBContext();
        }
        public List<GroupCalendar> ToList()
        {
            return db.GroupCalendars.ToList<GroupCalendar>();
        }
        public bool Insert(GroupCalendar buider)
        {
            try
            {
                
                db.GroupCalendars.Add(buider);
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
                var bd = db.GroupCalendars.SingleOrDefault(a => a.GroupID == ID);
                db.GroupCalendars.Remove(bd);
                db.SaveChanges();
                return true;

            }

            catch
            {
                return false;
            }


        }
        public GroupCalendar FindByID(long ID)
        {

            return db.GroupCalendars.Where(a => a.GroupID == ID).SingleOrDefault();
        }
        public bool Update(GroupCalendar buider)
        {
            try
            {
                var bd = db.GroupCalendars.Find(buider.GroupID);
              
                bd.Name = buider.Name;
                bd.Note = buider.Note;
                bd.Status = buider.Status;
                bd.DisplayOrder = buider.DisplayOrder;
             
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
