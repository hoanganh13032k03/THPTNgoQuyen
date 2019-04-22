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
    public class NewsController : BaseController
    {
        // GET: Admin/Category
      
        public ActionResult Index()
        {
           NewsDao bdDao = new NewsDao();
            ViewBag.lstCate = GetClientCategoryViewModel();
            //TempData["AlertMessage"] = null;
            return View(bdDao.ToList());
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(long id)
        {
           NewsDao dbDAO = new NewsDao();
            ViewBag.lstCate = GetClientCategoryViewModel();
            News cat = null;
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
            PopulateParentIDDropDownList(null);

            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(FormCollection data)
        {
            ViewBag.UpTopNew = data["UpTopNew"].ToString();
            ViewBag.UpTopHot = data["UpTopHot"].ToString();
         
            PopulateParentIDDropDownList(HepperString.TolistLong(data.GetValues("CategoryID")));
            try
            {
                News objNews = new News();
               NewsDao bdDao = new NewsDao();

                UserLogin us = (UserLogin)Session[SystemConsts.USER_SESSION];
                

                objNews.Name = data["Name"].ToString();
                objNews.Title = data["Title"].ToString();
                objNews.MetaTite = data["MetaTite"].ToString();
                objNews.MetakeyWords = data["MetakeyWords"].ToString();
                objNews.MetaDescription = data["MetaDescription"].ToString();
                objNews.Description = data["Description"].ToString();
                objNews.ContentHtml = data["ContentHtml"].ToString();
                objNews.Image = data["Image"].ToString();
                objNews.UpTopNew =  Convert.ToDateTime(ViewBag.UpTopNew);
                objNews.UpTopHot = Convert.ToDateTime(ViewBag.UpTopHot);
                bool ShowShare = true;
                if (data.GetValues("ShowShare").Equals("false")) ShowShare = false;
                bool ShowConment = true;
                if (data.GetValues("ShowConment").Equals("false")) ShowConment = false;
                objNews.ShowShare = ShowShare;
                objNews.ShowConment = ShowConment;
                objNews.Source = data["Source"].ToString();
                objNews.Status = 0;
                objNews.CreateDate = Hepper.GetDateServer();
                objNews.CreateBy = us.UserName;
                objNews.ModifiedBy = us.UserName;
                objNews.Tags = data["Tags"].ToString(); 
                objNews.ModifiedDate = Hepper.GetDateServer();
                objNews.LanguageID = "vi";
                string[] cateIDs = data.GetValues("CategoryID");
                string sCatID = "";
                foreach (var sID in cateIDs)
                {
                    sCatID += sID + ",";
                }
                if(sCatID.Length>0)
                sCatID = sCatID.Remove(sCatID.Length-1,1);
                objNews.CategoryID = sCatID;
                //collection.CreateBy = us.UserName;
                //collection.ModifiedBy = us.UserName;
                if (bdDao.Insert(objNews) >0)
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
           NewsDao dbDAO = new NewsDao();
           News objNew = null;
            objNew = dbDAO.FindByID(id);
            List<string> cateID = HepperString.GetListByKey(objNew.CategoryID, ",");
            PopulateParentIDDropDownList(HepperString.TolistLong(cateID.ToArray()));
           
            return View(objNew);
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Publicer(long id)
        {
            NewsDao dbDAO = new NewsDao();
            News objNew = null;
            //SetParentIDViewBag();
            try
            {
                objNew = dbDAO.FindByID(id);
                List<string> cateID = HepperString.GetListByKey(objNew.CategoryID, ",");
                PopulateParentIDDropDownList(HepperString.TolistLong(cateID.ToArray()));
            }
            catch
            {

                ModelState.AddModelError("", Resources.ResourceAdmin.ErrorGetRecordMessage);
            }
            return View(objNew);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Publicer(FormCollection data)
        {
            
            try
            {
                NewsDao bdDao = new NewsDao();
                News bd = bdDao.FindByID(Convert.ToInt64(data["NewsID"].ToString()));


                UserLogin us = (UserLogin)Session[SystemConsts.USER_SESSION];
                
                bd.ModifiedBy = us.UserName;

                bd.ModifiedDate = Hepper.GetDateServer();
                bd.PublishedDate = Hepper.GetDateServer();
                int Status = Convert.ToInt32(data["Status"]);
                bd.Status = Status;
                bd.ContentHtml = data["ContentHtml"].ToString();
                if (bdDao.Update(bd) > 0)
                {
                    SetAlert(@Resources.ResourceAdmin.AdminEditRecordSucess, "success");
                    return RedirectToAction("Index");
                }
                else
                {
                    SetAlert(@Resources.ResourceAdmin.AdminEditRecordFailed, "danger");
                }


            }
            catch
            {

                ModelState.AddModelError("", Resources.ResourceAdmin.ErrorGetRecordMessage);
            }
            return View();
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(FormCollection data)
        {
            ViewBag.UpTopNew = data["UpTopNew"].ToString();
            ViewBag.UpTopHot = data["UpTopHot"].ToString();
            //SetParentIDViewBag(HepperString.TolistLong(data.GetValues("CategoryID")));
            PopulateParentIDDropDownList(HepperString.TolistLong(data.GetValues("CategoryID")));

            try
            {
                NewsDao bdDao = new NewsDao();
                News objNews = bdDao.FindByID(Convert.ToInt64(data["NewsID"].ToString()));
              

                UserLogin us = (UserLogin)Session[SystemConsts.USER_SESSION];

               
                objNews.Name = data["Name"].ToString();
                objNews.Title = data["Title"].ToString();
                objNews.MetaTite = data["MetaTite"].ToString();
                objNews.MetakeyWords = data["MetakeyWords"].ToString();
                objNews.MetaDescription = data["MetaDescription"].ToString();
                objNews.Description = data["Description"].ToString();
                objNews.ContentHtml = data["ContentHtml"].ToString();
                objNews.Image = data["Image"].ToString();
                objNews.UpTopNew = Convert.ToDateTime(ViewBag.UpTopNew);
                objNews.UpTopHot = Convert.ToDateTime(ViewBag.UpTopHot);
                bool ShowShare = true;
                if (data.GetValues("ShowShare").Equals("false")) ShowShare = false;
                bool ShowConment = true;
                if (data.GetValues("ShowConment").Equals("false")) ShowConment = false;
                objNews.ShowShare = ShowShare;
                objNews.ShowConment = ShowConment;
                objNews.Source = data["Source"].ToString();
                objNews.Status = 0;
                objNews.ModifiedBy = us.UserName;
                objNews.Tags = data["Tags"].ToString();
                objNews.ModifiedDate = Hepper.GetDateServer();
                objNews.LanguageID = "vi";
                string[] cateIDs = data.GetValues("CategoryID");
                string sCatID = "";
                foreach (var sID in cateIDs)
                {
                    sCatID += sID + ",";
                }
                if (sCatID.Length > 0)
                    sCatID = sCatID.Remove(sCatID.Length - 1, 1);
                objNews.CategoryID = sCatID;
                //collection.CreateBy = us.UserName;
                //collection.ModifiedBy = us.UserName;
                if (bdDao.Update(objNews) > 0)
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
                //Response.Write(e.Message);
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

               NewsDao bdDao = new NewsDao();
              
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
        private void PopulateParentIDDropDownList(long[] selectedParent = null)
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
