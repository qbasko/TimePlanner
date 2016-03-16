using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repository.IRepo;
using Repository.Models;
using Repository.Repo;

namespace TimePlanner.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ILocationRepo _repository;

        public LocationsController(ILocationRepo repository)
        {
            _repository = repository;
        }

        // GET: Locations
        public ActionResult Index()
        {
            var locations = _repository.GetLocations();
            return View(locations);
        }

        //// GET: Locations/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Location location = _db.Locations.Find(id);
        //    if (location == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(location);
        //}

        //// GET: Locations/Create
        //public ActionResult Create()
        //{
        //    //ViewBag.AuthorId = new SelectList(_db.ApplicationUsers, "Id", "Email");
        //    return View();
        //}

        //// POST: Locations/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,Description,District,City,Country,Latitude,Longtitude")] Location location)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        location.Id = Guid.NewGuid().ToString();
        //        location.CreationDate = DateTime.Now.ToUniversalTime();
        //        location.Author = _db.ApplicationUsers.SingleOrDefault(u => u.UserName == User.Identity.Name);
        //        _db.Locations.Add(location);
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //   // ViewBag.AuthorId = new SelectList(_db.Users, "Id", "Email", location.AuthorId);
        //    return View(location);
        //}

        //// GET: Locations/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Location location = _db.Locations.Find(id);
        //    if (location == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(location);
        //}

        //// POST: Locations/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Name,Description,District,City,Country,Latitude,Longtitude")] Location location)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Entry(location).State = EntityState.Modified;
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(location);
        //}

        //// GET: Locations/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Location location = _db.Locations.Find(id);
        //    if (location == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(location);
        //}

        //// POST: Locations/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    Location location = _db.Locations.Find(id);
        //    _db.Locations.Remove(location);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
