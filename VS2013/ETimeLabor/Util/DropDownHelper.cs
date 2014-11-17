using ETimeLabor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETimeLabor.Util
{
    public static class DropDownHelper
    {
         public static IEnumerable<SelectListItem> GetAllActivities()
        {
            MongoHelper<Activity> context = new MongoHelper<Activity>();
            var activities = context.Collection.FindAll().ToList();            
            return activities.Select(x => new SelectListItem { Text = x.Description, Value = x.Code});
        }
    }
}