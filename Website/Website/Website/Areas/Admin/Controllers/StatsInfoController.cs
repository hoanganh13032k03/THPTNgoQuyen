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
    public class StatsInfoController : BaseController
    {
        // GET: Admin/StatsInfo
        public ActionResult Index()
        {
            StatsInfoDao db = new StatsInfoDao();
            return View(db.ToList());
        }

        // GET: Admin/StatsInfo/Details/5
        public ActionResult Details(long id)
        {

            StatsInfoDao db = new StatsInfoDao();
            return View(db.FindByID(id));
        }

        // GET: Admin/StatsInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/StatsInfo/Create
        [HttpPost]
        public ActionResult Create(StatsInfo collection)
        {
            try
            {

                StatsInfoDao bdDao = new StatsInfoDao();

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

        // GET: Admin/StatsInfo/Edit/5
        public ActionResult Edit(long id)
        {
            StatsInfoDao db = new StatsInfoDao();
            return View(db.FindByID(id));
        }

        // POST: Admin/StatsInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(StatsInfo collection)
        {
            StatsInfoDao bdDao = new StatsInfoDao();
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

                StatsInfoDao bdDao = new StatsInfoDao();

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
