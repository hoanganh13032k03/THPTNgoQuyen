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

namespace Website.Controllers
{
    public class NewsDTController : Controller
    {
        // GET: NewsDT
        public ActionResult Search(string keyword, int page = 1, int pageSize = 10)
        {
            ViewBag.keyword = keyword;
            int totalRecord = 0;
            NewsDao nsDao = new NewsDao();
            var model = nsDao.Search(keyword, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize))+1;
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
        public ActionResult Category(long cateId, int page = 1, int pageSize = 10)
        {
            CategoryDao ctDao = new CategoryDao();
         
            ViewBag.Cate = ctDao.FindByID(cateId);
            var items = GetClientCategoryViewModel();
            ViewBag.CatePare = items.Find(x => x.ID == cateId);

            var model = new NewsDao().ListtiveByCateIDPaging(cateId,page, pageSize);
            int totalRecord = new NewsDao().ToActiveByCateID(cateId).Count();

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize))+1;
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
        public ActionResult Tag(string tagId, int page = 1, int pageSize = 10)
        {
            ViewBag.Tags = tagId;
            //CategoryDao ctDao = new CategoryDao();

            //ViewBag.Cate = ctDao.FindByID(cateId);
            //var items = GetClientCategoryViewModel();
            //ViewBag.CatePare = items.Find(x => x.ID == cateId);

            var model = new NewsDao().ListAllByTag(tagId, page, pageSize);
            int totalRecord = new NewsDao().ListAllByTagCount(tagId);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize))+1;
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
        public ActionResult Detail(long ID)
        {
            ViewBag.Tags = Session["tag"];
            ViewBag.Cate = null;
            if (Session["tag"] == null)
            {
                var catID = Convert.ToInt64(Session["CategoryID"]);

                CategoryDao ctDao = new CategoryDao();
                ViewBag.Cate = ctDao.FindByID(catID);
                var items = GetClientCategoryViewModel();
                ViewBag.CatePare = items.Find(x => x.ID == catID);
            }
            else
            {
                ViewBag.Tags = Session["tag"];
            }


            NewsDao nDao = new NewsDao();
            News objNew = nDao.FindByID(ID);
            objNew.ViewCount = objNew.ViewCount + 1;
            nDao.Update(objNew);
            return View(objNew);
        }
        public ActionResult DetailTag(long id, string tagId)
        {
           
            ViewBag.Tags = tagId;
            NewsDao nDao = new NewsDao();
            News objNew = nDao.FindByID(id);
            objNew.ViewCount = objNew.ViewCount + 1;
            nDao.Update(objNew);
            return View(objNew);
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