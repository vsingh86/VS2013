using ETimeLabor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETimeLabor.Areas.Payroll.Controllers
{
    public class TimeclockController : Controller
    {
        //
        // GET: /Payroll/Timeclock/

        public ActionResult Index()
        {
            List<ShiftPunch> list = new List<ShiftPunch>();
            list.Add(new ShiftPunch
            {
                EarnCode = "001",
                ActivityCode = "11100",
                InDateTime = DateTime.Now.AddHours(-5),
                OutDateTime = DateTime.Now
            });
            return View("Index",list);
        }

    }
}
