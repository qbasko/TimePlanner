using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.Models;

namespace TimePlanner.Controllers
{
    public class EventsController : Controller
    {
        private TimePlannerContext _db = new TimePlannerContext();

        // GET: Events
        public ActionResult Index()
        {
            _db.Database.Log = message => Trace.WriteLine(message);
            var events = _db.Events.AsNoTracking(); //lazy loading, read only data 
            //_db.Events.Include(@e => @e.Location).Include(@e => @e.Type).Include(@e => @e.User);
            return View(events.ToList());
        }

        // GET: Events/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.LocationId = new SelectList(_db.Locations, "Id", "Name");
            ViewBag.TypeId = new SelectList(_db.EventTypes, "Id", "Name");
            ViewBag.UserId = new SelectList(_db.Users, "Id", "Email");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,StartDateTime,EndDateTime,LocationId,TypeId,Objective,NumberOfAttendees,UserId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _db.Events.Add(@event);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationId = new SelectList(_db.Locations, "Id", "Name", @event.LocationId);
            ViewBag.TypeId = new SelectList(_db.EventTypes, "Id", "Name", @event.TypeId);
            ViewBag.UserId = new SelectList(_db.Users, "Id", "Email", @event.UserId);
            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationId = new SelectList(_db.Locations, "Id", "Name", @event.LocationId);
            ViewBag.TypeId = new SelectList(_db.EventTypes, "Id", "Name", @event.TypeId);
            ViewBag.UserId = new SelectList(_db.Users, "Id", "Email", @event.UserId);
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,StartDateTime,EndDateTime,LocationId,TypeId,Objective,NumberOfAttendees,UserId")] Event @event)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(@event).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationId = new SelectList(_db.Locations, "Id", "Name", @event.LocationId);
            ViewBag.TypeId = new SelectList(_db.EventTypes, "Id", "Name", @event.TypeId);
            ViewBag.UserId = new SelectList(_db.Users, "Id", "Email", @event.UserId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Event @event = _db.Events.Find(id);
            _db.Events.Remove(@event);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
