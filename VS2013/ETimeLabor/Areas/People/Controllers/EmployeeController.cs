using ETimeLabor.Areas.People.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETimeLabor.Models;
using ETLDomain;


namespace ETimeLabor.Areas.People.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        //EmployeeContext context = new EmployeeContext();
        MongoEmployeeContext context = new MongoEmployeeContext();
        public ActionResult Index(string SearchText)
        {
            var empls = context.GetEmployees(SearchText);
            return View(empls);
        }

        public ActionResult Find(string SearchText)
        {
            var empls = context.GetEmployees(SearchText);
            return View("Index", empls);
        }

        //
        // GET: /Employee/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }



        //
        // GET: /Employee/Create

        public ActionResult Create()
        {
            Employee emp = new Employee{
                Address = new Address{
                     City = "Everett",
                      State = "WA",
                       Street1 = "5304 114th ST SE",
                        Country = "US",
                         Zip = "98208"
                },

                BirthPlace = "New Delhi",
                CitizenshipCountry = "US",
                CitizenshipCountry2 = "India",
                CompHistory = new List<Compensation>(),
                DateModified = DateTime.Today,                
                DOB = DateTime.Today.AddYears(-30),
                EmployeeNumber = "1000000",
                EthnicGroup = "Indian",
                EffectiveDate = DateTime.Today,
                FirstName = "Vikrant",
                Gender = Gender.Male,
                HighestEducationLevel = "4 Years",
                IsDisabled = false,
                IsDisabledVet = false,
                IsFullTimeStudent = false,
                IsUSWorkEligible = true,
                LastName = "Singh",
                MaritalStatus = MaritalStatus.Married,
                SSN = "333224444",
                UserModified = "SYSTEM"

            };
            
            return View(emp);
        }

     

        //
        // POST: /Employee/Create

        [HttpPost]
        public ActionResult Create([ModelBinder(typeof(EmployeeBinder))]Employee emp)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    context.AddEmployee(emp);
                    //context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(emp);
            }
            catch
            {
                return View();
            }
        }

        public PartialViewResult _AddressPartial()
        {
            //Address ad = new Address();
            //ad.City = "Everett";
            return PartialView("_AddressPartial");
        }

        //
        // GET: /Employee/Edit/5
        [HttpGet]
        public ActionResult Edit(ObjectId id)
        {
            Employee emp = context.GetEmployee(id);

            return View(emp);
        }

        //-
        // POST: /Employee/Edit/5

        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                context.UpdateEmployee(emp);
                return RedirectToAction("Index");
            }

            return View(emp);
        }

        //
        // GET: /Employee/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Employee/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
