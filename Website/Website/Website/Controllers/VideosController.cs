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
    public class VideosController : Controller
    {
        // GET: Videos
        public ActionResult Index()
        {
            // int page = 1, int pageSize = 10
            //int totalRecord = 0;
            //var model = new VideosDao().ListActivePaging(ref  totalRecord, page, pageSize);
            var model = new VideosDao().ToListActive();
            //ViewBag.Page = page;

            //int maxPage = 5;
            //int totalPage = 0;

            //totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize)) + 1;
            //ViewBag.TotalPage = totalPage;
            //ViewBag.MaxPage = maxPage;
            //ViewBag.First = 1;
            //ViewBag.Last = totalPage;
            //ViewBag.Next = page + 1;
            //ViewBag.Prev = page - 1;
           
            return View(model);
        }
    }
}