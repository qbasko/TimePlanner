using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using Repository.IRepo;
using Repository.Models;

namespace TimePlanner.Controllers
{
    [RouteArea("Admin")]
    public class EventsController : Controller
    {
        private readonly IEventRepo _eventRepository;
        private readonly ILocationRepo _locationRepository;
        private readonly IEventTypeRepo _eventTypeRepository;
        private readonly IUserRepo _userRepo;

        public EventsController(IEventRepo eventRepository, ILocationRepo locationRepository, IEventTypeRepo eventTypeRepository, IUserRepo userRepo)
        {
            _eventRepository = eventRepository;
            _locationRepository = locationRepository;
            _eventTypeRepository = eventTypeRepository;
            _userRepo = userRepo;
        }

        // GET: Events
        [Route("{Events}")]
        public ActionResult Index()
        {
            var events = _eventRepository.GetEvents();
            return View(events);
        }

        [Route("{Events}/{id}")]
        // GET: Events/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _eventRepository.GetEventById(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.LocationId = new SelectList(_locationRepository.GetLocations().OrderBy(l => l.Name), "Id", "Name");
            ViewBag.TypeId = new SelectList(_eventTypeRepository.GetEventTypes().OrderBy(et => et.Name), "Id", "Name");
            return View("Create");
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,StartDate,StartTime,EndDate,EndTime,LocationId,TypeId,Objective,NumberOfAttendees")] Event @event)
        {
            if (ModelState.IsValid)
            {
                @event.Id = Guid.NewGuid().ToString();
                @event.CreationDate = DateTime.Now.ToUniversalTime();
                @event.AuthorId = User.Identity.GetUserId();

                try
                {
                    _eventRepository.Add(@event);
                    _eventRepository.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(@event);
                }
            }

            ViewBag.LocationId = new SelectList(_locationRepository.GetLocations().OrderBy(l => l.Name), "Id", "Name");
            ViewBag.TypeId = new SelectList(_eventTypeRepository.GetEventTypes().OrderBy(et => et.Name), "Id", "Name");
            return View(@event);
        }

        // GET: Events/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _eventRepository.GetEventById(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationId = new SelectList(_locationRepository.GetLocations().OrderBy(l => l.Name), "Id", "Name");
            ViewBag.TypeId = new SelectList(_eventTypeRepository.GetEventTypes().OrderBy(et => et.Name), "Id", "Name");
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event @event)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _eventRepository.Update(@event);
                    _eventRepository.SaveChanges();
                }
                catch (Exception ex)
                {
                    ViewBag.Error = true;
                    return View(@event);
                }
            }
            ViewBag.LocationId = new SelectList(_locationRepository.GetLocations().OrderBy(l => l.Name), "Id", "Name");
            ViewBag.TypeId = new SelectList(_eventTypeRepository.GetEventTypes().OrderBy(et => et.Name), "Id", "Name");
            ViewBag.Error = false;
            return View(@event);
        }

        // GET: Events/Delete/5
        [Authorize]
        public ActionResult Delete(string id, bool? error)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _eventRepository.GetEventById(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            if (error.HasValue)
                ViewBag.Error = true;
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                _eventRepository.Delete(id);
                _eventRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Delete", new { id = id, error = true });
            }
            return RedirectToAction("Index");
        }

        public ActionResult Partial()
        {
            var events = _eventRepository.GetEvents();
            return PartialView("Index", events);
        }

        public ActionResult EmptyResult()
        {
            return new EmptyResult();
        }

        public ActionResult AssignToEvent(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _eventRepository.GetEventById(id);
            if (@event == null)
            {
                return HttpNotFound();
            }

            var user = _userRepo.GetUserById(User.Identity.GetUserId());
            @event.Attendees.Add(user);
            return View("Details", @event);
        }

        public ActionResult CancelAssignment(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _eventRepository.GetEventById(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            var user = _userRepo.GetUserById(User.Identity.GetUserId());
            var participant = @event.Attendees.SingleOrDefault(a => a.Id == User.Identity.GetUserId());
            if (participant != null)
                @event.Attendees.Remove(participant);
            return View("Details", @event);
        }
    }
}
