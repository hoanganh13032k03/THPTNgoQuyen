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
    public class MathStudentController : BaseController
    {
        // GET: Admin/MathStudent
        public ActionResult Index()
        {
            GroupMathDao bdDao = new GroupMathDao();
            ViewBag.lstGroupMath = bdDao.ToList();
            MathStudentDao db = new MathStudentDao();
            return View(db.ToList());
        }

        // GET: Admin/MathStudent/Details/5
        public ActionResult Details(long id)
        {

            MathStudentDao db = new MathStudentDao();
            return View(db.FindByID(id));
        }

        // GET: Admin/MathStudent/Create
        public ActionResult Create()
        {
            GroupMathDropDownList();
            return View();
        }

        // POST: Admin/MathStudent/Create
        [HttpPost]
        public ActionResult Create(MathStudent collection)
        {
            GroupMathDropDownList(collection.GroupMathsID);
            try
            {

                MathStudentDao bdDao = new MathStudentDao();

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

        // GET: Admin/MathStudent/Edit/5
        public ActionResult Edit(long id)
        {
            MathStudentDao db = new MathStudentDao();
            MathStudent mathStudent = db.FindByID(id);
            GroupMathDropDownList(mathStudent.GroupMathsID);
            return View(mathStudent);
        }

        // POST: Admin/MathStudent/Edit/5
        [HttpPost]
        public ActionResult Edit(MathStudent collection)
        {
            MathStudentDao bdDao = new MathStudentDao();
            GroupMathDropDownList(collection.GroupMathsID);
            try
            {
                UserLogin us = (UserLogin)Session[SystemConsts.USER_SESSION];

                collection.ModifiedBy = us.UserName;
                collection.ModifiedDate = Hepper.GetDateServer();
               // ConvertExcelToXml convertXML = new ConvertExcelToXml();
                //string xml = convertXML.GetXML(collection.Sources);
                int i = 0;
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

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            try
            {
                // TODO: Add delete logic here

                MathStudentDao bdDao = new MathStudentDao();

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
        private void GroupMathDropDownList(object selectedParent = null)
        {
            GroupMathDao bdDao = new GroupMathDao();
            var items = bdDao.ToList(); 
            ViewBag.Parents = new SelectList(items, "GroupMathsID", "Name", selectedParent);
        }
        #endregion
    }
}
