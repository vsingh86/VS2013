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
using ETLWebApi.Models;


namespace ETLWebApi.Models
{
    public class GenericRepository<T>:IGenericRepository<T> where T:class 
    {
        
        private readonly MongoHelper<T> table;

        public GenericRepository()
        {        
            table = new MongoHelper<T>();
        }

        public IEnumerable<T> SelectAll()
        {
            var list = (from s in table.Collection.AsQueryable<T>()
                          select s).ToList();
            return list;
        }

        public T SelectByID(string id)
        {

            return table.Collection.Find(Query.EQ("_id", ObjectId.Parse(id))).Single();
        }
        public IEnumerable<T> SelectByMongoQuery(IMongoQuery query)
        {
            return table.Collection.Find(query);
        }

        public T Insert(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(typeof(T).ToString());
            }
            table.Collection.Insert(obj);
            return obj;
        }

        public bool Update(T obj, string id)
        {
            if (obj == null || id == null)
            {
                throw new ArgumentNullException(typeof(T).ToString());
            }
            table.Collection.Update(
                Query.EQ("_id", ObjectId.Parse(id)), MongoDB.Driver.Builders.Update.Replace(obj)
                    );
            return true;
        }

        public bool Delete(string  id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }
            T existing = table.Collection.Find(Query.EQ("_id", ObjectId.Parse(id))).Single();
            table.Collection.Remove(Query.EQ("_id", ObjectId.Parse(id)));
            return true;
        }

        public bool Save(T obj)
        {
            table.Collection.Save(obj);
            return true;
        }

    }
}