﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using PW.Ncels.Database.DataModel;
using PW.Ncels.Database.Helpers;

namespace PW.Prism.Controllers
{
    public class NotificationController : Controller
    {
        private NcelsEntities _db = new NcelsEntities();

        public ActionResult Index()
        {
            return PartialView(Guid.NewGuid());
        }

        [HttpGet]
        public ActionResult NotificationsCount()
        {
            var unreadedCount = 0;
            var readedCount = 0;
            try
            {
                var currentEmployeeId = UserHelper.GetCurrentEmployee().Id.ToString();
                unreadedCount = _db.Notifications.Count(e => !e.IsRead && e.EmployeesId == currentEmployeeId);
                readedCount = _db.Notifications.Count(e => e.IsRead && e.EmployeesId == currentEmployeeId);
            }
            catch (Exception e)
            {
                
                
            }
            return Json(new{unreadedCount, readedCount}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NotificationList([DataSourceRequest] DataSourceRequest request)
        {
            var currentEmployeeId = UserHelper.GetCurrentEmployee().Id.ToString();
            var query = _db.Notifications.Where(e => e.EmployeesId == currentEmployeeId);
            return Json(query.ToDataSourceResult(request, n => new
            {
                n.Id,
                n.IsRead,
                n.CreatedDate,
                n.ModifiedUser,
                n.Note
            }));
        }

        public ActionResult MarkAsReaded(long[] ids)
        {
            _db.Database.ExecuteSqlCommand(string.Format("update Notification set IsRead=1 where IsRead=0 and Id in ({0})", string.Join(", ",ids.Select(e=>e.ToString()))));
            return Json("OK", JsonRequestBehavior.AllowGet);
        }
        public ActionResult MarkAllAsReaded()
        {
            var currentEmployeeId = UserHelper.GetCurrentEmployee().Id.ToString();
            _db.Database.ExecuteSqlCommand("update Notification set IsRead=1 where IsRead=0 and EmployeesId=@p0", currentEmployeeId);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }
    }
}