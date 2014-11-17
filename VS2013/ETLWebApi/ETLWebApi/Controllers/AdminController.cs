using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ETLWebApi.Models;
using ETLDomain;
using Newtonsoft.Json.Linq;

namespace ETLWebApi.Controllers
{
    public class AdminController : ApiController
    {

        static readonly ETLContext context = new ETLContext();
     

        #region Activity
        
        public IEnumerable<Activity> GetAllActivities()
        {
            var activities = from r in context.Activities
                             select r;
            return activities;
        }
        //public Activity GetActivity(string Code)
        //{
        //    var activity = (from r in context.Activities
        //                                  where r. == Code 
        //                                  select r).SingleOrDefault();
        //    return activity;
        //}

        
        //[Route("api/admin/PostActivity/{activity}")]
        [HttpPost]        
        public HttpResponseMessage PostActivity([FromBody]Activity activity)
        {

            if (ModelState.IsValid)
            {
                var obj = (Activity)activity;
                context.Activities.Add(obj);
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, " saved");
            }
            return Request.CreateResponse(HttpStatusCode.OK, " saved");
        }
        //public Activity PutActivity(int id, Activity activity)
        //{
        //    if (!ModelState.IsValid)
        //        throw new Exception("Model not valid.");

        //    var obj = (from a in context.Activities
        //                                  where a.ID == id 
        //                                  select a).SingleOrDefault();
        //    obj = activity;
        //    if ( context.SaveChanges() == 0)
        //    {
        //        throw new Exception("Failed to update.");
        //    }

        //    return obj;

        //}
        //public int DeleteActivity(int id)
        //{
        //    var obj = (from a in context.Activities
        //                                  where a.ID == id 
        //                                  select a).SingleOrDefault();
            
        //    if (obj == null)
        //    {
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }
        //    context.Activities.Remove(obj);
        //   return context.SaveChanges();
        //}
        
        #endregion

        /*
        #region Project

        public IEnumerable<Project> GetAllProjects()
        {
            return projectRepository.SelectAll();
        }
        public Project GetProject(string id)
        {
            Project obj = projectRepository.SelectByID(id);
            if (obj == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return obj;
        }
        
        
        [HttpPost]
        public HttpResponseMessage PostProject(Project obj)
        {
           // if (ModelState.IsValid)
            //{
            projectRepository.Insert(obj);
            //}

            var response = Request.CreateResponse<Project>(HttpStatusCode.Created, obj);

            string uri = Url.Link("DefaultApi", new { id = obj.ID });
            response.Headers.Location = new Uri(uri);
            return response;

        }
        public void PutProject(Project obj)
        {
            if (!projectRepository.Update(obj, obj.ID.ToString()))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        public void DeleteProject(string id)
        {
            Project obj = projectRepository.SelectByID(id);
            if (obj == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            projectRepository.Delete(id);
        }

        #endregion
         * */
    }
}
