using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ETLWebApi.Models
{
    public class MongoHelper<T> where T : class 
    {
        public MongoCollection<T> Collection { get; private set; }

        public MongoHelper()
        {
            var con = new MongoConnectionStringBuilder(ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString);
            MongoClient client = new MongoClient(con.ToString());

            var server = client.GetServer();
            var db = server.GetDatabase(con.DatabaseName);
            Collection = db.GetCollection<T>(typeof(T).Name.ToLower());
        }
    }
}