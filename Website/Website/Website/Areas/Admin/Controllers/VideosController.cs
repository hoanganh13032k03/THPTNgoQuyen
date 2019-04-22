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
    public class VideosController : BaseController
    {
        // GET: Admin/Video
        public ActionResult Index()
        {
            VideosDao db = new VideosDao();
            return View(db.ToList());
        }

        // GET: Admin/Video/Details/5
        public ActionResult Details(long id)
        {

            VideosDao db = new VideosDao();
            return View(db.FindByID(id));
        }

        // GET: Admin/Video/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Video/Create
        [HttpPost]
        public ActionResult Create(Videos collection)
        {
            try
            {

                VideosDao bdDao = new VideosDao();

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

        // GET: Admin/Video/Edit/5
        public ActionResult Edit(long id)
        {
            VideosDao db = new VideosDao();
            return View(db.FindByID(id));
        }

        // POST: Admin/Video/Edit/5
        [HttpPost]
        public ActionResult Edit(Videos collection)
        {
            VideosDao bdDao = new VideosDao();
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

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            try
            {
                // TODO: Add delete logic here

                VideosDao bdDao = new VideosDao();

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