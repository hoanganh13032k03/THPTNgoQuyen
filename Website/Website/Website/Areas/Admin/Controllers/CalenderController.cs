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
using System.Globalization;

namespace Website.Areas.Admin.Controllers
{
    public class CalenderController : BaseController
    {
        public ActionResult Index()
        {
            CalenderDao db = new CalenderDao();
            return View(db.ToList());
        }

        // GET: Admin/Calender/Details/5
        public ActionResult Details(long id)
        {

            CalenderDao db = new CalenderDao();
            return View(db.FindByID(id));
        }

        // GET: Admin/Calender/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Calender/Create
        [HttpPost]
        public ActionResult Create(FormCollection data)
        {
            

            try
            {
                if (ModelState.IsValid)
                {


                    string sTite = data["Tite"].ToString();
                    string sMetakeyWords = data["MetakeyWords"].ToString();
                    string sMetaDescription = data["MetaDescription"].ToString();
                    string sPrepared = data["Prepared"].ToString();
                    string sOrganization = data["Organization"].ToString();
                    string sPlace = data["Place"].ToString();
                    string sDetail = data["Detail"].ToString();
                    string sImage = data["Image"].ToString();
                    string sFiles = data["Files"].ToString();
                    string sOptions = data["Options"].ToString();
                    string sShowOnHome = data["ShowOnHome"].ToString();
                    string sStatus_End = data["Status_End"].ToString();
                    string sDateRate = data["Date_Start"].ToString();
                    string sDate_Start = sDateRate.Substring(0, sDateRate.IndexOf("-") - 1);
                    string sDate_End = sDateRate.Substring(sDateRate.IndexOf("-") + 1, sDateRate.Length - (sDate_Start.Length + 2));
                    DateTime Date_Start = Convert.ToDateTime(sDate_Start);
                    DateTime Date_End = Convert.ToDateTime(sDate_End);

 

                  

                    Calender objCalender = new Calender();
                    CalenderDao bdDao = new CalenderDao();

                    UserLogin us = (UserLogin)Session[SystemConsts.USER_SESSION];
                    objCalender.CreateBy = us.UserName;
                    objCalender.CreateDate = Hepper.GetDateServer();
                    objCalender.ModifiedBy = us.UserName;
                    objCalender.ModifiedDate = Hepper.GetDateServer();
                    objCalender.PublishDate = Hepper.GetDateServer();
                    objCalender.Publish = true;
                    objCalender.LanguageID = "vi";
                    objCalender.GroupID =1;
                    objCalender.Tite = sTite;
                    objCalender.Place = sPlace;
                    objCalender.Prepared = sPrepared;
                    objCalender.Organization= sOrganization;
                    objCalender.Detail = sDetail;
                    objCalender.MetaDescription = sMetaDescription;
                    objCalender.MetakeyWords = sMetakeyWords;
                    objCalender.Image = sImage;
                    objCalender.Files = sFiles;
                    objCalender.Date_Start = Date_Start;
                    objCalender.Date_End = Date_End;
                    objCalender.Hour_End = Date_End.Hour;
                    objCalender.Minutes_End= Date_End.Minute;
                    objCalender.Hour_Start = Date_Start.Hour;
                    objCalender.Minutes_Start = Date_Start.Minute;
                    objCalender.Options = Convert.ToByte(sOptions);
                    objCalender.ShowOnHome = Convert.ToBoolean(sShowOnHome);
                    objCalender.Status_End = Convert.ToInt32(sStatus_End);
                    objCalender.Status_Start = 0;
                    objCalender.ActiveDate = Hepper.GetDateServer();
                    objCalender.Active = false;
                    //collection.CreateBy = us.UserName;
                    //collection.ModifiedBy = us.UserName;
                    if (bdDao.Insert(objCalender))
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
                SetAlert(@Resources.ResourceAdmin.AdminCreateRecordFailed, "danger");
                return View();

            }
        }

        // GET: Admin/Calender/Edit/5
        public ActionResult Edit(long id)
        {
            CalenderDao db = new CalenderDao();
            return View(db.FindByID(id));
        }

        // POST: Admin/Calender/Edit/5
        [HttpPost]
        public ActionResult Edit(Calender collection)
        {
            CalenderDao bdDao = new CalenderDao();
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

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            try
            {
                // TODO: Add delete logic here

                CalenderDao bdDao = new CalenderDao();

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