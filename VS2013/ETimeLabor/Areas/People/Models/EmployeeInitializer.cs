using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;
using ETimeLabor.Areas.People.Models;

namespace ETimeLabor.Models
{
    /*
    public class EmployeeInitializer: DropCreateDatabaseAlways<EmployeeContext>
    {
        protected override void Seed(EmployeeContext context)
        {
            var empls = new List<Employee>{
                new Employee{FirstName ="Vikrant", LastName="Singh", BirthPlace ="New Delhi", EmployeeNumber ="0001",
                 DOB =DateTime.Today,  Gender =  Gender.Male, SSN ="555-55-5555",  DateModified = DateTime.Today,
                 PassportExpDate=DateTime.Today.ToString(), VisaExpireDate=DateTime.Today,
                 Address=new Address{Street1 ="111 114th Street SE", City="Everett", State ="WA", Zip ="98208", Country="US" }},
                  
                 new Employee{FirstName ="Harpreet", LastName="Singh", BirthPlace ="New Delhi", EmployeeNumber ="0002",
                 DOB =DateTime.Today,  Gender =  Gender.Male, SSN ="555-55-6666",  DateModified = DateTime.Today,
                 PassportExpDate=DateTime.Today.ToString(), VisaExpireDate=DateTime.Today,
                 Address=new Address{Street1 ="111 114th Street SE", City="Everett", State ="WA", Zip ="98208", Country="US" }},
                  new Employee{FirstName ="Gurjeet", LastName="Kaur", BirthPlace ="New Delhi", EmployeeNumber ="0003",
                 DOB =DateTime.Today,  Gender =  Gender.Male, SSN ="555-55-7777",  DateModified = DateTime.Today,
                 PassportExpDate=DateTime.Today.ToString(), VisaExpireDate=DateTime.Today,
                 Address=new Address{Street1 ="111 114th Street SE", City="Everett", State ="WA", Zip ="98208", Country="US" }},
                  new Employee{FirstName ="Deepi", LastName="Kaur", BirthPlace ="New Delhi", EmployeeNumber ="0004",
                 DOB =DateTime.Today,  Gender =  Gender.Male, SSN ="555-55-8888",  DateModified = DateTime.Today,
                 PassportExpDate=DateTime.Today.ToString(), VisaExpireDate=DateTime.Today,
                 Address=new Address{Street1 ="111 114th Street SE", City="Everett", State ="WA", Zip ="98208", Country="US" }}
                   
            };

            empls.ForEach(e => context.Employees.Add(e));
            context.SaveChanges();
        }

    }
     * */
}