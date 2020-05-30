using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentityProject.Models;
using IdentityProject.Models.Address;
using IdentityProject.ViewModels;
using Microsoft.AspNet.Identity;

namespace IdentityProject.Controllers.AddressControllers
{
    public class StreetsController : Controller
    {
        private MainApplicationDBContext db = new MainApplicationDBContext();

        // GET: Streets
        public ActionResult Index()
        {
            return View("~/Views/Address/Streets/Index.cshtml", db.Streets.ToList());
        }

        // GET: Streets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Street street = db.Streets.Find(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Address/Streets/Details.cshtml", street);
        }

        // GET: Streets/Create
        public ActionResult Create()
        {
            AddressViewModel addressViewModel = new AddressViewModel
            {
                ContinentList = db.Continents.ToList(),
                CountryList = db.Countries.ToList(),
                StateList = db.States.ToList(),
                CityList=db.Cities.ToList()
            };
            return View("~/Views/Address/Streets/Create.cshtml", addressViewModel);
        }

        // POST: Streets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,AddedDate,IsActive,StreetNumber")] Street street)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = db.Users.Find(User.Identity.GetUserId());
                street.Added_User = applicationUser;
                street.AddedDate = DateTime.Now;
                street.IsActive = true;
                db.Streets.Add(street);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("~/Views/Address/Streets/Create.cshtml", street);
        }

        // GET: Streets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Street street = db.Streets.Find(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Address/Streets/Edit.cshtml", street);
        }

        // POST: Streets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,AddedDate,IsActive,StreetNumber")] Street street)
        {
            if (ModelState.IsValid)
            {

                ApplicationUser applicationUser = db.Users.Find(User.Identity.GetUserId());
                street.Added_User = applicationUser;
                street.AddedDate = DateTime.Now;
                db.Entry(street).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/Views/Address/Streets/Edit.cshtml", street);
        }

        // GET: Streets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Street street = db.Streets.Find(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Address/Streets/Delete.cshtml", street);
        }

        // POST: Streets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Street street = db.Streets.Find(id);
            db.Streets.Remove(street);
            db.SaveChanges();
            return RedirectToAction("Index");
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
