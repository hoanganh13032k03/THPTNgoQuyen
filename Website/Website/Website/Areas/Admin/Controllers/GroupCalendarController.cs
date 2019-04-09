using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Common;
using Resources;
using DBModel.DAO;
using DBModel.ET;
using Website.Areas.Models;
using Website.Areas.Controllers;
using Models;

namespace Website.Areas.Admin.Controllers
{
    public class GroupCalendarController : BaseController
    {
        // GET: Admin/GroupCalendar
        public ActionResult Index()
        {
            GroupCalendarDao db = new GroupCalendarDao();
            return View(db.ToList());
        }

        // GET: Admin/GroupCalendar/Details/5
        public ActionResult Details(long id)
        {
            GroupCalendarDao dbDAO = new GroupCalendarDao();
            GroupCalendar cat = null;
            try
            {
                cat = dbDAO.FindByID(id);
            }
            catch
            {

                ModelState.AddModelError("", Resources.ResourceAdmin.ErrorGetRecordMessage);
            }
            return View(cat);
        }

        // GET: Admin/GroupCalendar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/GroupCalendar/Create
        [HttpPost]
        public ActionResult Create(GroupCalendar collection)
        {
            try
            {

                GroupCalendarDao  bdDao = new GroupCalendarDao();

                UserLogin us = (UserLogin)Session[SystemConsts.USER_SESSION];
                collection.CreatedBy = us.UserName;
                collection.CreateDate = Hepper.GetDateServer();
                
                //collection.CreateBy = us.UserName;
                //collection.ModifiedBy = us.UserName;
                if (bdDao.Insert(collection))
                {
                    SetAlert(@Resources.ResourceAdmin.AdminCreateRecordSuccess, "success");
                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert(@Resources.ResourceAdmin.AdminCreateRecordFailed, "danger");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                SetAlert(@Resources.ResourceAdmin.AdminCreateRecordFailed, "danger");
                return View();

            }
        }

        // GET: Admin/GroupCalendar/Edit/5
        public ActionResult Edit(long id)
        {
            GroupCalendarDao dbDAO = new GroupCalendarDao();
            GroupCalendar cat = null;
            try
            {
                cat = dbDAO.FindByID(id);
                // ViewBag.GroupID = new SelectList(dbContext..ToList(), "ID", "Name");
            }
            catch
            {

                ModelState.AddModelError("", Resources.ResourceAdmin.ErrorGetRecordMessage);
            }
            return View(cat);
        }

        // POST: Admin/GroupCalendar/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GroupCalendar collection)
        {
            try
            {
                //TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    GroupCalendarDao bdDao = new GroupCalendarDao();
                   


                    if (bdDao.Update(collection))
                    {
                        SetAlert(@Resources.ResourceAdmin.AdminEditRecordSucess, "success");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        SetAlert(@Resources.ResourceAdmin.AdminEditRecordFailed, "danger");
                    }
                }
                return View();

            }
            catch
            {
                SetAlert(@Resources.ResourceAdmin.AdminEditRecordFailed, "danger");
                return View();
            }
        }



        // POST: Admin/GroupCalendar/Delete/5
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            try
            {
                GroupCalendarDao db = new GroupCalendarDao();
                db.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
