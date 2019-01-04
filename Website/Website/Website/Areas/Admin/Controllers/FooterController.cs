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
    public class FooterController : BaseController
    {
        // GET: Admin/Footer
        public ActionResult Index()
        {
            FooterDao bdDao = new FooterDao();
            return View(bdDao.ToList());
        }

        // GET: Admin/Footer/Details/5
        public ActionResult Details(string id)
        {
            FooterDao bdDao = new FooterDao();
            return View(bdDao.FindByID(id));
        }

        // GET: Admin/Footer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Footer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Footer collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here

                    FooterDao bdDao = new FooterDao();
                    if (bdDao.FindByID(collection.ID) == null)
                    {
                        UserLogin us = (UserLogin)Session[SystemConsts.USER_SESSION];
                        collection.LanguageID = "vi";
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
                        ModelState.AddModelError("", "Mã Footer đã tồn tại");
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

        // GET: Admin/Footer/Edit/5
        public ActionResult Edit(string id)
        {
            FooterDao bdDao = new FooterDao();
            return View(bdDao.FindByID(id));
        }

        // POST: Admin/Footer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Footer collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here

                    FooterDao bdDao = new FooterDao();
                    UserLogin us = (UserLogin)Session[SystemConsts.USER_SESSION];
                  
                   
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

        // GET: Admin/Footer/Delete/5
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            try
            {
                // TODO: Add delete logic here

                FooterDao bdDao = new FooterDao();
                MenuDao mnDao = new MenuDao();
               
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
