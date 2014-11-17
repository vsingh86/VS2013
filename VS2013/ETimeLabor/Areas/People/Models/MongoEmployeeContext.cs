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



namespace ETimeLabor.Areas.People.Models
{
    public class MongoEmployeeContext : DbContext
    {
        private readonly MongoHelper<Employee> context;
      
        public MongoEmployeeContext()
        {
            context = new MongoHelper<Employee>();
        }

        public void AddEmployee(Employee emp)
        {
            if (emp.Address == null)
                emp.Address = new Address();

            emp.CompHistory = new List<Compensation>();
            context.Collection.Save(emp);
        }

        public void UpdateEmployee(Employee emp)
        {
            
            
            context.Collection.Update(
                Query.EQ("_id", emp.ID), Update.Replace(emp)
                    );
        }

        public void DeleteEmployee(ObjectId postId)
        {
            context.Collection.Remove(Query.EQ("_id", postId));            
        }

        public IList<Employee> GetEmployees(string searchText)
        {
            if (searchText == null)
            {
                
                //return context.Collection.FindAll().SetFields(Fields.Exclude("CompHistory", "Address")).SetSortOrder(SortBy.Descending("EffectiveDate")).ToList();
                var empls = (from e in context.Collection.AsQueryable<Employee>()
                             select new Employee
                             {
                                 ID = e.ID,
                                 FirstName = e.FirstName,
                                 LastName = e.LastName
                             }).ToList();
                return empls;
            }   
            else 
            {
                //var query = Query.Matches("FirstName", new MongoDB.Bson.BsonRegularExpression(searchText, "i"));
                //return context.Collection.Find(query).ToList();

                searchText = searchText.ToUpper();
                var empls = (from e in context.Collection.AsQueryable<Employee>()
                             where e.FirstName.ToUpper().Contains(searchText) || e.LastName.ToUpper().Contains(searchText)
                             select new Employee
                             {
                                 ID = e.ID,
                                 FirstName = e.FirstName,
                                 LastName = e.LastName
                             }).ToList();
                return empls;
            }
        }


        public Employee GetEmployee(ObjectId id)
        {
            var empl = context.Collection.Find(Query.EQ("_id", id)).Single();            
            return empl;
        }
    }
}