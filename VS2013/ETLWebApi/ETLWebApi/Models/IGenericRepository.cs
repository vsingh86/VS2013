using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETLWebApi.Models
{
    public interface IGenericRepository<T> where T:class
    {
        IEnumerable<T> SelectAll();
        T SelectByID(string id);
        IEnumerable<T> SelectByMongoQuery(IMongoQuery query);
        T Insert(T obj);
        bool Update(T obj, string id);
        bool Delete(string id);
        bool Save(T obj);
    }
}