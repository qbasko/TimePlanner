using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Repository.IRepo;
using Repository.Models;
using Repository.Repo;
using Services;

namespace TimePlanner.Controllers
{
    [Authorize]
    public class LocationsController : Controller
    {
        //private readonly ILocationRepo _repository;
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        // GET: Locations
        public ActionResult Index()
        {
            var locations = _locationService.GetLocations();
            return View(locations);
        }

        // GET: Locations/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = _locationService.GetLocationById(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // GET: Locations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,District,City,Country,Latitude,Longtitude")] Location location)
        {
            if (ModelState.IsValid)
            {
                location.Id = Guid.NewGuid().ToString();
                location.CreationDate = DateTime.Now.ToUniversalTime();
                location.AuthorId = User.Identity.GetUserId();
                try
                {
                    _locationService.Add(location);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(location);
                }
            }
            return View(location);
        }

        // GET: Locations/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = _locationService.GetLocationById(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AuthorId,CreationDate,Name,Description,District,City,Country,Latitude,Longtitude")] Location location)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _locationService.Update(location);
                }
                catch (Exception ex)
                {
                    ViewBag.Error = true;
                    return View(location);
                }
            }
            ViewBag.Error = false;
            return View(location);
        }

        // GET: Locations/Delete/5
        public ActionResult Delete(string id, bool? error)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = _locationService.GetLocationById(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            if (error.HasValue)
                ViewBag.Error = true;

            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                _locationService.Delete(id);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Delete", new { id = id, error = true });
            }

            return RedirectToAction("Index");
        }

        public ActionResult Partial()
        {
            var locations = _locationService.GetLocations();
            return PartialView("Index", locations);
        }
    }
}
