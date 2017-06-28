using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace WebApi.Models
{
    public class DetailsController : ApiController
    {
        private passwordEntities db = new passwordEntities();

        // GET: details
        public IEnumerable<detail> Get()
        {
            return db.details.ToList();
        }

        public IEnumerable<detail> Get(int ID)
        {
            return db.details.Where(x => x.ID.Equals(ID)).ToList();
        }

        public void Post(detail record)
        {
            record.date_modified = DateTime.UtcNow;

            db.details.Add(record);
            db.SaveChanges();
        }

        public void Put(detail record)
        {
            detail updRecord = db.details.Find(record.ID);
            updRecord.pass = record.pass;
            updRecord.app = record.app;
            updRecord.username = record.username;
            updRecord.date_modified = DateTime.UtcNow;

            db.SaveChanges();
        }

        public void Delete(detail record)
        {
            detail delRecord = db.details.Find(record.ID);
            db.details.Remove(delRecord);
            db.SaveChanges();
        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
