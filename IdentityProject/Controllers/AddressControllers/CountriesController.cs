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
    public class CountriesController : Controller
    {
        private MainApplicationDBContext db = new MainApplicationDBContext();

        // GET: Countries
        public ActionResult Index()
        {
            return View("~/Views/Address/Countries/Index.cshtml", db.Countries.ToList());
        }

        // GET: Countries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Address/Countries/Details.cshtml", country);
        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            AddressViewModel addressViewModel = new AddressViewModel
            {
                ContinentList = db.Continents.ToList()
            };
            return View("~/Views/Address/Countries/Create.cshtml", addressViewModel);
        }

        // POST: Countries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Country country)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = db.Users.Find(User.Identity.GetUserId());
                country.Added_User = applicationUser;
                country.IsActive = true;
                country.AddedDate = DateTime.Now;
                db.Countries.Add(country);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("~/Views/Address/Countries/Create.cshtml", country);
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Address/Countries/Edit.cshtml", country);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,AddedDate,IsActive")] Country country)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = db.Users.Find(User.Identity.GetUserId());
                country.Added_User = applicationUser;
                country.AddedDate = DateTime.Now;
                var userId= User.Identity.GetUserId().ToString();
                //country.Added_User = 
                //db.Entry(country).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/Views/Address/Countries/Edit.cshtml", country);
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Address/Countries/Delete.cshtml", country);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Country country = db.Countries.Find(id);
            db.Countries.Remove(country);
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
