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
    public class HomeController : Controller
    {
        // GET: Home
       
        public ActionResult Index()
        {
            AboutDao dbCat = new AboutDao();
            ViewBag.About = dbCat.ToActive();

            StatsInfoDao stiDB = new StatsInfoDao();
            ViewBag.StatsInfo = stiDB.ToListActive();
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult MenuPartial()

        {
            CategoryDao dbCat = new CategoryDao();
            List<Category> menusource = dbCat.ToListActiveHome(); // get your menus here
            ViewBag.Menus = CreateVM(null, menusource);  // transform it into the ViewModel
            return PartialView(ViewBag.Menus);
        }
        [ChildActionOnly]
        public PartialViewResult SidesPartial()

        {
            SideDao sdDao = new SideDao();
          
            return PartialView(sdDao.ToListActive());
        }
        [ChildActionOnly]
        public PartialViewResult HeaderPartial()

        {
           AboutDao dbCat = new AboutDao();
            return PartialView(dbCat.ToActive());
        }
        [ChildActionOnly]
        public PartialViewResult FooterPartial()

        {
            FooterDao dbCat = new FooterDao();
            AboutDao abDao = new AboutDao();
            ViewBag.About = abDao.ToActive();
            return PartialView(dbCat.ToActive());
        }
        [ChildActionOnly]
        public PartialViewResult TagsPartial()

        {
            NewsDao dbDao = new NewsDao();

            return PartialView(dbDao.ListTag());
        }
        [ChildActionOnly]
        public PartialViewResult EventsPartial()

        {
            NewsDao dbDao = new NewsDao();

            return PartialView(dbDao.ListTag());
        }
        [ChildActionOnly]
        public PartialViewResult CategoryPartial()

        {
            CategoryDao dbCat = new CategoryDao();
            List<Category> menusource = dbCat.ToListActiveNotTopHome(); // get your menus here
            ViewBag.Menus = CreateVM(null, menusource);  // transform it into the ViewModel
            return PartialView(ViewBag.Menus);
        }

        
        public List<CategoryViewModel> CreateVM(long? CategoryID, List<Category> source) {

            return (from cat in source
                   where cat.ParentID == CategoryID
                    select new CategoryViewModel()
                   {
                       CategoryID = cat.CategoryID,
                       Name = cat.Name,
                       MetaTite = cat.MetaTite,
                       ParentID = cat.ParentID,
                       Image = cat.Image,
                       Description = cat.Description,
                       DisplayOrder = cat.DisplayOrder,
                       SeoTite = cat.SeoTite,
                       MetakeyWords = cat.MetakeyWords,
                       MetaDescription = cat.MetaDescription,
                       Status = cat.Status,
                       ShowOnHome = cat.ShowOnHome,
                       Position = cat.Position,
                       LanguageID = cat.LanguageID,
                       Children = CreateVM(cat.CategoryID, source)
                   }).ToList();
        }
        public JsonResult ListName(string q)
        {
            var data = new NewsDao().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}