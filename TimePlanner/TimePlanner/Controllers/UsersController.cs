using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Repository.IRepo;
using Repository.Models;

namespace TimePlanner.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepo _userRepo;

        public UsersController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        // GET: Users
        public ActionResult Index()
        {
            var users = _userRepo.GetUsers();
            return View(users);
        }

        public ActionResult GetCurrentUserDetails()
        {
            var user = _userRepo.GetUserById(User.Identity.GetUserId());
            return View("Details", user);
        }

        // GET: Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userRepo.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userRepo.GetUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,EmailConfirmed,PhoneNumber,PhoneNumberConfirmed,UserName,Name,LastName,Age")] User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userRepo.Update(user);
                    _userRepo.SaveChanges();
                }
                catch (Exception ex)
                {
                    ViewBag.Error = true;
                    return View(user);
                }
            }
            return View(user);
        }
    }
}
