using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using angularjs_crud_sample.Models;

namespace angularjs_crud_sample.Controllers
{
    public class NewsItemController : ApiController
    {
        private NewsItemsContext db = new NewsItemsContext();
        // GET api/<controller>
        [HttpGet]
        public IEnumerable<NewsItem> Get()
        {
            return db.NewsItems.AsEnumerable();
        }

        // GET api/<controller>/5
        public NewsItem Get(int id)
        {
            NewsItem newsItem = db.NewsItems.Find(id);
            if (newsItem == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return newsItem;
        }

        // POST api/<controller>
        public HttpResponseMessage Post(NewsItem newsItem)
        {
            if (ModelState.IsValid)
            {
                db.NewsItems.Add(newsItem);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, newsItem);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = newsItem.NewsItemId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(NewsItem newsItem)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            db.Entry(newsItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            NewsItem newsItem = db.NewsItems.Find(id);
            if (newsItem == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.NewsItems.Remove(newsItem);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, newsItem);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}