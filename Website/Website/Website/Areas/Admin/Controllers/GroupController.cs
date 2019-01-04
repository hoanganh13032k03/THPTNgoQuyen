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
    public class GroupController : BaseController
    {
        public ActionResult Index()
        {
            GroupDao bdDao = new GroupDao();
            return View(bdDao.ToList());
        }

        // GET: Group/Details/5
        public ActionResult Details(Guid id)
        {
            GroupDao bdDao = new GroupDao();
            var sl = bdDao.FindByID(id);

            return View(sl);
        }

        // GET: Group/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Group/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Group collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here

                    GroupDao bdDao = new GroupDao();
                    UserLogin us = (UserLogin)Session[SystemConsts.USER_SESSION];
                   collection.CreatedBy = us.UserName;
                    collection.CreateDate = Hepper.GetDateServer();
                    //collection.CreateBy = us.UserName;
                    //collection.ModifiedBy = us.UserName;
                    if (bdDao.Insert(collection))
                    {
                        SetAlert("Thêm thành công", "success");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        SetAlert("Không thêm được", "danger");
                    }
                }
                return View();
            }
            catch
            {
                SetAlert("Không thêm được", "danger");
                return View();
            }
        }

        // GET: Group/Edit/5
        public ActionResult Edit(Guid id)
        {
            GroupDao bdDao = new GroupDao();
            var sl = bdDao.FindByID(id);
            //if (sl.Status == true) { ViewBag.Status = "Kích hoạt"; }
            //else { ViewBag.Status = "Khóa"; }
            return View(sl);
        }

        // POST: Group/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Group collection)
        {
            try
            {
                //TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    GroupDao bdDao = new GroupDao();
                    UserLogin us = (UserLogin)Session[SystemConsts.USER_SESSION];


                    if (bdDao.Update(collection))
                    {
                        SetAlert("Sửa thành công", "success");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        SetAlert("Không sửa được", "danger");
                    }
                }
                return View();

            }
            catch
            {
                SetAlert("Không sửa được", "danger");
                return View();
            }
        }



        // POST: Group/Delete/5
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            try
            {
                // TODO: Add delete logic here

                GroupDao bdDao = new GroupDao();
                GroupUserDao prDao = new GroupUserDao();
                if (prDao.FindByGroupID(id).Count > 0)
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