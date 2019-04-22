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
    [AuthorizeBusiness]
    public class GroupMathController : BaseController
    {
        // GET: Admin/GroupMath
        public ActionResult Index()
        {
            GroupMathDao bdDao = new GroupMathDao();
            ViewBag.lstCate = bdDao.ToList();
            //TempData["AlertMessage"] = null;
            return View(ViewBag.lstCate);
        }
        // GET: Admin/GroupMath/Details/5
        public ActionResult Details(long id)
        {
            GroupMathDao dbDAO = new GroupMathDao();
            GroupMath cat = null;
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
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
           
            // ViewBag.GroupID = new SelectList(dbContext..ToList(), "ID", "Name");
            return View();
        }

        // POST: Admin/GroupMath/Create
        [HttpPost]
        public ActionResult Create(GroupMath collection)
        {
            try
            {

                GroupMathDao bdDao = new GroupMathDao();

                UserLogin us = (UserLogin)Session[SystemConsts.USER_SESSION];
                collection.CreateBy = us.UserName;
                collection.CreateDate = Hepper.GetDateServer();
                collection.ModifiedBy = us.UserName;
                collection.ModifiedDate = Hepper.GetDateServer();
                collection.LanguageID = "vi";
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
        // GET: Admin/GroupMath/Edit/5
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(long id)
        {
            GroupMathDao dbDAO = new GroupMathDao();
            GroupMath cat = null;
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

        // POST: Admin/GroupMath/Edit/5
        [HttpPost]
        public ActionResult Edit(GroupMath collection)
        {
            GroupMathDao bdDao = new GroupMathDao();

            try
            {
                UserLogin us = (UserLogin)Session[SystemConsts.USER_SESSION];

                collection.ModifiedBy = us.UserName;
                collection.ModifiedDate = Hepper.GetDateServer();


                if (bdDao.Update(collection))
                {
                    SetAlert(@Resources.ResourceAdmin.AdminEditRecordSucess, "success");
                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert(@Resources.ResourceAdmin.AdminEditRecordFailed, "danger");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                SetAlert(@Resources.ResourceAdmin.AdminEditRecordFailed, "danger");
                return View();

            }
        }
        // POST: Admin/GroupMath/Delete/5
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            try
            {
                // TODO: Add delete logic here

                GroupMathDao bdDao = new GroupMathDao();
                MathStudentDao dbNewDao = new MathStudentDao();

               
                if (dbNewDao.ToListByGroupID(id).Count > 0)
                {

                    SetAlert("Đang sử dụng không được phép xóa", SystemConsts.ALERT_DANGER);
                    return RedirectToAction("Index");
                }
                bdDao.Delete(id);
                // SetAlert("Xóa thành công", "success");
                return RedirectToAction("Index");
            }
            catch
            {
                // SetAlert("Không xóa được", "danger");
                return View();
            }
        }
    }
}