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
    public class MenuTypeController : BaseController
    {
        // GET: Admin/MenuType
        public ActionResult Index()
        {
            MenuTypeDao bdDao = new MenuTypeDao();
            return View(bdDao.ToList());
        }

        // GET: Admin/MenuType/Details/5
        public ActionResult Details(string id)
        {
            MenuTypeDao bdDao = new MenuTypeDao();
            return View(bdDao.FindByID(id));
        }

        // GET: Admin/MenuType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MenuType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuType collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here

                    MenuTypeDao bdDao = new MenuTypeDao();
                    if (bdDao.FindByID(collection.ID) == null)
                    {
                        UserLogin us = (UserLogin)Session[SystemConsts.USER_SESSION];
                        collection.CreatedBy = us.UserName;
                        collection.CreatedDate = Hepper.GetDateServer();
                        collection.ModifiedBy = us.UserName;
                        collection.ModifiedDate = Hepper.GetDateServer();
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
                    else
                    {
                        ModelState.AddModelError("", "Mã nhóm menu đã tồn tại");
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

        // GET: Admin/MenuType/Edit/5
        public ActionResult Edit(string id)
        {
            MenuTypeDao bdDao = new MenuTypeDao();
            return View(bdDao.FindByID(id));
        }

        // POST: Admin/MenuType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MenuType collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here

                    MenuTypeDao bdDao = new MenuTypeDao();
                    UserLogin us = (UserLogin)Session[SystemConsts.USER_SESSION];
                  //  collection.CreatedBy = us.UserName;
                   // collection.CreatedDate = Hepper.GetDateServer();
                    collection.ModifiedBy = us.UserName;
                    collection.ModifiedDate = Hepper.GetDateServer();
                   
                    if (bdDao.Update(collection))
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

        // GET: Admin/MenuType/Delete/5
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            try
            {
                // TODO: Add delete logic here

                MenuTypeDao bdDao = new MenuTypeDao();
                MenuDao mnDao = new MenuDao();
                if (mnDao.FindByMenuType(id).Count > 0)
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
