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
    public class MenuController : BaseController
    {
        // GET: Admin/Menu
        [OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            MenuDao bdDao = new MenuDao();
            return View(bdDao.ToList());
        }

        // GET: Admin/Menu/Details/5
        public ActionResult Details(long id)
        {
            MenuDao bdDao = new MenuDao();
            return View(bdDao.FindByID(id));
        }

        // GET: Admin/Menu/Create
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            var items = GetClientMenuViewModel();
            var dbContext = new DBContext();
            ViewBag.ParentID = new SelectList(items, "ID", "Text");
            ViewBag.GroupID = new SelectList(dbContext.MenuTypes.ToList(), "ID", "Name");
            return View();
        }

        // POST: Admin/Menu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Menu collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here

                    MenuDao bdDao = new MenuDao();
                  
                        UserLogin us = (UserLogin)Session[SystemConsts.USER_SESSION];
                        collection.CreatedBy = us.UserName;
                        collection.CreatedDate = Hepper.GetDateServer();
                        collection.UpdatedBy = us.UserName;
                        collection.UpdatedDate = Hepper.GetDateServer();
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
                  
                   
                    
                }
                return View();
            }
            catch
            {
                SetAlert("Không thêm được", "danger");
                return View();
            }
        }

        // GET: Admin/Menu/Edit/5
        public ActionResult Edit(long id)
        {
            
            MenuDao dbMenu = new MenuDao();
            MenuTypeDao dbMenuType = new MenuTypeDao();
            Menu menu = null;
            try
            {

                menu = dbMenu.FindByID(id);
                var items = GetClientMenuViewModel();
                ViewBag.ParentID = new SelectList(items, "ID", "Text", menu.ParentID);
                ViewBag.GroupID = new SelectList(dbMenuType.ToList(), "ID", "Name");
            }
            catch 
            {
                ModelState.AddModelError("", Resources.ResourceAdmin.ErrorGetRecordMessage);
            }
            return View(menu);
        }

        // POST: Admin/Menu/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Menu collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here

                    MenuDao bdDao = new MenuDao();
                    UserLogin us = (UserLogin)Session[SystemConsts.USER_SESSION];
                
                    collection.UpdatedBy = us.UserName;
                    collection.UpdatedDate = Hepper.GetDateServer();
                    MenuDao dbMenu = new MenuDao();
                    MenuTypeDao dbMenuType = new MenuTypeDao();
                    var items = GetClientMenuViewModel();
                    ViewBag.ParentID = new SelectList(items, "ID", "Text");
                    ViewBag.GroupID = new SelectList(dbMenuType.ToList(), "ID", "Name");
                    if (bdDao.Update(collection))
                    {
                        SetAlert("Thêm thành công", "success");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        SetAlert("Không cập nhật được", "danger");
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

        // GET: Admin/Menu/Delete/5
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            try
            {
                // TODO: Add delete logic here

                MenuDao bdDao = new MenuDao();
                
                if (bdDao.FindChildMenu(id).Count > 0)
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
            var items = GetClientMenuViewModel();
            ViewBag.Parents = new SelectList(items, "ID", "Text", selectedParent);
        }
        private void PopulateGroupIDDropDownList(object selectedParent = null)
        {
            MenuTypeDao dbDao = new MenuTypeDao();
            ViewBag.Groups = new SelectList(dbDao.ToList(), "ID", "Name", selectedParent);
        }
        private List<ClientMenuViewModel> GetClientMenuViewModel()
        {
            var dbContext = new DBContext();
            List<ClientMenuViewModel> items = new List<ClientMenuViewModel>();

            //get all of them from DB
            IEnumerable<Menu> allMenus = dbContext.Menus.ToList();
            //get parent categories
            IEnumerable<Menu> parentMenus = allMenus.Where(c => c.ParentID == null).OrderBy(c => c.DisplayOrder);

            foreach (var cat in parentMenus)
            {
                //add the parent category to the item list
                items.Add(new ClientMenuViewModel
                {
                    ID = cat.MenuID,
                    Text = cat.Text,
                    Order = cat.DisplayOrder,
                    IsLocked = cat.IsActived,
                    CreatedDate = cat.CreatedDate
                });
                //now get all its children (separate Menu in case you need recursion)
                GetSubTree(allMenus.ToList(), cat, items);
            }
            return items;
        }
        private void GetSubTree(IList<Menu> allCats, Menu parent, IList<ClientMenuViewModel> items)
        {
            var subCats = allCats.Where(c => c.ParentID == parent.MenuID).OrderBy(x => x.DisplayOrder);
            foreach (var cat in subCats)
            {
                //add this category
                items.Add(new ClientMenuViewModel
                {
                    ID = cat.MenuID,
                    Text = parent.Text + " >> " + cat.Text,
                    Order = cat.DisplayOrder,
                    IsLocked = cat.IsActived,
                    CreatedDate = cat.CreatedDate
                });
                //recursive call in case your have a hierarchy more than 1 level deep
                GetSubTree(allCats, cat, items);
            }
        }
        #endregion

    }
}
