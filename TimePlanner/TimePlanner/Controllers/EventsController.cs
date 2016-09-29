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
using Services;

namespace TimePlanner.Controllers
{
    [RouteArea("Admin")]
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ILocationService _locationService;
        private readonly IEventTypeService _eventTypeService;
        private readonly IUserService _userService;

        //private readonly IEventTypeService

        public EventsController(IEventService eventService, ILocationService locationService, IEventTypeService eventTypeService, IUserService userService)
        {
            _eventService = eventService;
            _locationService = locationService;
            _eventTypeService = eventTypeService;
            _userService = userService;
        }

        // GET: Events
        [Route("{Events}")]
        public ActionResult Index()
        {
            var events = _eventService.GetAllEvents();
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
            Event @event = _eventService.GetEventById(id);
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
            ViewBag.LocationId = new SelectList(_locationService.GetLocations().OrderBy(l => l.Name), "Id", "Name");
            ViewBag.TypeId = new SelectList(_eventTypeService.GetEventTypes().OrderBy(et => et.Name), "Id", "Name");
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
                    _eventService.Add(@event);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(@event);
                }
            }

            ViewBag.LocationId = new SelectList(_locationService.GetLocations().OrderBy(l => l.Name), "Id", "Name");
            ViewBag.TypeId = new SelectList(_eventTypeService.GetEventTypes().OrderBy(et => et.Name), "Id", "Name");
            return View(@event);
        }

        //// GET: Events/Edit/5
        [Authorize]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _eventService.GetEventById(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationId = new SelectList(_locationService.GetLocations().OrderBy(l => l.Name), "Id", "Name");
            ViewBag.TypeId = new SelectList(_eventTypeService.GetEventTypes().OrderBy(et => et.Name), "Id", "Name");
            return View(@event);
        }

        //// POST: Events/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event @event)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _eventService.Update(@event);
                }
                catch (Exception ex) //TODO log ex
                {
                    ViewBag.Error = true;
                    return View(@event);
                }
            }
            ViewBag.LocationId = new SelectList(_locationService.GetLocations().OrderBy(l => l.Name), "Id", "Name");
            ViewBag.TypeId = new SelectList(_eventTypeService.GetEventTypes().OrderBy(et => et.Name), "Id", "Name");
            ViewBag.Error = false;
            return View(@event);
        }

        //// GET: Events/Delete/5
        [Authorize]
        public ActionResult Delete(string id, bool? error)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _eventService.GetEventById(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            if (error.HasValue)
                ViewBag.Error = true;
            return View(@event);
        }

        //// POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                _eventService.Delete(id);                
            }
            catch (Exception ex)
            {
                return RedirectToAction("Delete", new { id = id, error = true });
            }
            return RedirectToAction("Index");
        }


        public ActionResult AssignToEvent(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _eventService.GetEventById(id);
            if (@event == null)
            {
                return HttpNotFound();
            }

            var user = _userService.GetUserById(User.Identity.GetUserId());

            if (!@event.EventUsers.Any(eu => eu.EventId == id && eu.UserId == user.Id))
            {
                EventUser evUsr = new EventUser
                {
                    Event = @event,
                    User = user,
                    Id = Guid.NewGuid().ToString(),
                    EventId = @event.Id,
                    UserId = user.Id,
                    CreationDate = DateTime.UtcNow
                };

                @event.EventUsers.Add(evUsr);
            }

            return View("Details", @event);
        }

        public ActionResult CancelAssignment(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _eventService.GetEventById(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            var user = _userService.GetUserById(User.Identity.GetUserId());
            var evUsr = @event.EventUsers.SingleOrDefault(e => e.UserId == User.Identity.GetUserId() && e.EventId == id);
            if (evUsr != null)
            {
                @event.EventUsers.Remove(evUsr);
                _eventService.Update(@event);
                user.EventUsers.Remove(evUsr);
                _userService.Update(user);
            }
            return View("Details", @event);
        }
    }
}
