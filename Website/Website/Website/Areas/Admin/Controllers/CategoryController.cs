﻿using System;
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
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
      
        public ActionResult Index()
        {
            CategoryDao bdDao = new CategoryDao();
            ViewBag.lstCate =bdDao.ToList();
            //TempData["AlertMessage"] = null;
            return View(ViewBag.lstCate);
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(long id)
        {
            CategoryDao dbDAO = new CategoryDao();
            Category cat = null;
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
            var items = GetClientCategoryViewModel();
            var dbContext = new DBContext();
            ViewBag.ParentID = new SelectList(items, "ID", "Text");
            // ViewBag.GroupID = new SelectList(dbContext..ToList(), "ID", "Name");
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        public ActionResult Create(Category collection)
        {
            try
            {

                CategoryDao bdDao = new CategoryDao();

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

        // GET: Admin/Category/Edit/5
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(long id)
        {
            CategoryDao dbDAO = new CategoryDao();
            Category cat = null;
            try
            {
                cat = dbDAO.FindByID(id);
                var items = GetClientCategoryViewModel();

                var objite =items.Find(x => x.ID == cat.CategoryID);
                items.Remove(objite);
                var dbContext = new DBContext();
                ViewBag.ParentID = new SelectList(items, "ID", "Text");
                // ViewBag.GroupID = new SelectList(dbContext..ToList(), "ID", "Name");
            }
            catch
            {

                ModelState.AddModelError("", Resources.ResourceAdmin.ErrorGetRecordMessage);
            }
            return View(cat);
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category collection)
        {
            CategoryDao bdDao = new CategoryDao();

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



        // POST: Admin/Category/Delete/5
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            try
            {
                // TODO: Add delete logic here

                CategoryDao bdDao = new CategoryDao();
                NewsDao dbNewDao = new NewsDao();

                if (bdDao.FindChildCategory(id).Count > 0)
                {

                    SetAlert("Đang sử dụng không được phép xóa", SystemConsts.ALERT_DANGER);
                    return RedirectToAction("Index");
                }
                if (dbNewDao.ToActiveByCateID(id).Count > 0)
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

        #region Private Method
        private void PopulateParentIDDropDownList(object selectedParent = null)
        {
            var items = GetClientCategoryViewModel();
            ViewBag.Parents = new SelectList(items, "ID", "Text", selectedParent);
        }

        private List<ClientCategoryViewModel> GetClientCategoryViewModel()
        {
            var dbContext = new DBContext();
            List<ClientCategoryViewModel> items = new List<ClientCategoryViewModel>();

            //get all of them from DB
            IEnumerable<Category> allMenus = dbContext.Categories.ToList();
            //get parent categories
            IEnumerable<Category> parentMenus = allMenus.Where(c => c.ParentID == null).OrderBy(c => c.DisplayOrder);

            foreach (var cat in parentMenus)
            {
                //add the parent category to the item list
                items.Add(new ClientCategoryViewModel
                {
                    ID = cat.CategoryID,
                    Decription = cat.Description,
                    Text = cat.Name,
                    Order = cat.DisplayOrder,
                    IsLocked = cat.Status,
                    CreatedDate = cat.CreateDate
                });
                //now get all its children (separate Menu in case you need recursion)
                GetSubTree(allMenus.ToList(), cat, items);
            }
            return items;
        }
        private void GetSubTree(IList<Category> allCats, Category parent, IList<ClientCategoryViewModel> items)
        {
            var subCats = allCats.Where(c => c.ParentID == parent.CategoryID).OrderBy(x => x.DisplayOrder);
            foreach (var cat in subCats)
            {
                //add this category
                items.Add(new ClientCategoryViewModel
                {
                    ID = cat.CategoryID,
                    Decription = cat.Description,
                    Text = parent.Name + " >> " + cat.Name,
                    Order = cat.DisplayOrder,
                    IsLocked = cat.Status,
                    CreatedDate = cat.CreateDate
                });
                //recursive call in case your have a hierarchy more than 1 level deep
                GetSubTree(allCats, cat, items);
            }
        }
        #endregion
    }
}
