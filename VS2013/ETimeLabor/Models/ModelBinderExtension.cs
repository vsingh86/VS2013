using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETimeLabor.Models
{
    public class EmployeeBinder : DefaultModelBinder
    {

        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, System.ComponentModel.PropertyDescriptor propertyDescriptor)
        {
            if (propertyDescriptor.Name == "Address")
            {
                Address add = new Address();
                add.Street1 = controllerContext.HttpContext.Request.Form["Street1"];
                add.Street2 = controllerContext.HttpContext.Request.Form["Street2"];
                add.Street3 = controllerContext.HttpContext.Request.Form["Street3"];
                add.City = controllerContext.HttpContext.Request.Form["City"];
                add.State = controllerContext.HttpContext.Request.Form["State"];
                add.Country = controllerContext.HttpContext.Request.Form["Country"];
                add.Zip = controllerContext.HttpContext.Request.Form["Zip"];

                propertyDescriptor.SetValue(bindingContext.Model, add);
                //return;
            }
            base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
        }


        /*
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(Address))
            {
                HttpRequestBase request = controllerContext.HttpContext.Request;

                return new Address
                {
                    Street1 = request.Form["Street1"],
                    Street2 = request.Form["Street1"],
                    Street3 = request.Form["Street1"],
                    City = request.Form["City"],
                    State = request.Form["State"],
                    Country = request.Form["Country"],
                    Zip = request.Form["Zip"]
                };
            }
            else
            {
                return base.BindModel(controllerContext, bindingContext);
            }
        }
         */
    }

    public class ObjectIdBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (result == null)
                return null;

            return new ObjectId(result.AttemptedValue);
        }
    }

}