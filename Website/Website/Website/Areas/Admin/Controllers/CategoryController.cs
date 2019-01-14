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
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        [OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            CategoryDao bdDao = new CategoryDao();
            return View(bdDao.ToList());
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            var items = GetClientMenuViewModel();
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
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

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #region Private Method
        private void PopulateParentIDDropDownList(object selectedParent = null)
        {
            var items = GetClientMenuViewModel();
            ViewBag.Parents = new SelectList(items, "ID", "Text", selectedParent);
        }
       
        private List<ClientMenuViewModel> GetClientMenuViewModel()
        {
            var dbContext = new DBContext();
            List<ClientMenuViewModel> items = new List<ClientMenuViewModel>();

            //get all of them from DB
            IEnumerable<Category> allMenus = dbContext.Categories.ToList();
            //get parent categories
            IEnumerable<Category> parentMenus = allMenus.Where(c => c.ParentID == null).OrderBy(c => c.DisplayOrder);

            foreach (var cat in parentMenus)
            {
                //add the parent category to the item list
                items.Add(new ClientMenuViewModel
                {
                    ID = cat.CategoryID,
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
        private void GetSubTree(IList<Category> allCats, Category parent, IList<ClientMenuViewModel> items)
        {
            var subCats = allCats.Where(c => c.ParentID == parent.CategoryID).OrderBy(x => x.DisplayOrder);
            foreach (var cat in subCats)
            {
                //add this category
                items.Add(new ClientMenuViewModel
                {
                    ID = cat.CategoryID,
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
