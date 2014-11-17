using ETimeLabor.Areas.Admin.Models;
using ETimeLabor.Models;
using ETimeLabor.Areas.Payroll.ViewModels;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETLDomain;


namespace ETimeLabor.Areas.Admin.Controllers
{
    public class PayrollAdminController : Controller
    {
        //
        // GET: /Admin/PayrollAdmin/

        private IGenericRepository<Activity> repository = null;

        MongoAdminContext context = new MongoAdminContext();

        public PayrollAdminController()
        {
            this.repository = new GenericRepository<Activity>();
        }

        public ActionResult Index()
        {
            //ActivityList aList = new ActivityList();
            //aList.Activities = context.GetActivities(string.Empty);
            //IEnumerable<Activity> activities = aList.Activities;

            IEnumerable<Activity> activities = repository.SelectAll();


            return View("Activity", activities);
        }
        [HttpGet]
        public ActionResult AddActivity()
        {
            return View("_ActivityUpdate", new Activity
            {
                DateModified = DateTime.Today,
                EffectiveDate = DateTime.Today,
                IsActive = true,
                UserModified = "WEBENTRY"
            });
        }

        [HttpPost]
        public ActionResult AddActivity(Activity activity)
        {
            //context.AddActivity(activity);

            this.repository.Insert(activity);
            return Index();
        }

        [HttpGet]
        public ActionResult EditActivity(ObjectId name)
        {

            return View("_ActivityUpdate");
        }

        
        [HttpPost]
        public JsonResult EditActivity(Activity activity)
        {
            //context.UpdateActivity(activity);
            if (ModelState.IsValid)
            {
                this.repository.Update(activity, activity.ID);
            }
            return Json(activity);
        }
    }
}
