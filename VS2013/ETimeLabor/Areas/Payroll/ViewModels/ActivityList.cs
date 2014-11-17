using ETimeLabor.Models;
using ETLDomain;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETimeLabor.Areas.Payroll.ViewModels
{
    public class ActivityList
    {
        public IEnumerable<Activity> Activities { get; set; }
        public ObjectId IdInEdit { get; set; }
        public Activity AddActivity()
        {
            Activity act = new Activity();
            Activities.ToList().Add(act);
            return act;
        }
    }
}