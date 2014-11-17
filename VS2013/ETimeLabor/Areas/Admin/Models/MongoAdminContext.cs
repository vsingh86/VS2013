using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using MongoDB.Driver.Linq;
using ETimeLabor.Models;
using ETLDomain;



namespace ETimeLabor.Areas.Admin.Models
{
    public class MongoAdminContext:DbContext
    {
        public MongoAdminContext()
        {
        }

        public void AddActivity(Activity activity)
        {
            MongoHelper<Activity> context = new MongoHelper<Activity>();
            context.Collection.Save(activity);
        }
        public void UpdateActivity(Activity activity)
        {
            MongoHelper<Activity> context = new MongoHelper<Activity>();
            context.Collection.Update(
                Query.EQ("_id", activity.ID), Update.Replace(activity)
                    );
        }
        public List<Activity> GetActivities(string searchText)
        {
            MongoHelper<Activity> context = new MongoHelper<Activity>();
            if (searchText == null)
            {
                var actvities = (from a in context.Collection.AsQueryable<Activity>()
                             select a).ToList();
                return actvities;
            }   
            else 
            {
                searchText = searchText.ToUpper();
                var actvities = (from a in context.Collection.AsQueryable<Activity>()
                             where a.Description.ToUpper().Contains(searchText) || a.Description.ToUpper().Contains(searchText)
                             select a).ToList();
                return actvities;
            }
        }
        public Activity GetActivity(ObjectId id)
        {
            MongoHelper<Activity> context = new MongoHelper<Activity>();
            var activity = context.Collection.Find(Query.EQ("_id", id)).Single();
            return activity;
        }
    }
}