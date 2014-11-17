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



namespace ETimeLabor.Models
{
    public class MongoTimeTrackerContext
    {
        private readonly MongoHelper<Shift> context;

        public MongoTimeTrackerContext()
        {
            context = new MongoHelper<Shift>();
        }

        public void Create(Shift shift)
        {
            if (shift.Punches == null)
                shift.Punches = new List<ShiftPunch>();

            context.Collection.Save(shift);
        }

        public void Edit(Shift shift)
        {

            context.Collection.Update(
                Query.EQ("_id", shift.ID), Update.Replace(shift)
                    );
        }

        public void Delete(ObjectId postId)
        {
            context.Collection.Remove(Query.EQ("_id", postId));
        }

        public IList<Shift> GetShifts()
        {
                var shifts = (from s in context.Collection.AsQueryable<Shift>()
                              select s).ToList();
                return shifts;
        }


        public Shift GetShift(ObjectId id)
        {
            var shift = context.Collection.Find(Query.EQ("_id", id)).Single();
            return shift;
        }

        
    }
}