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
    public class ShippingAddressesController : Controller
    {
        private MainApplicationDBContext db = new MainApplicationDBContext();

        // GET: ShippingAddresses
        public ActionResult Index()
        {
            return View("~/Views/Address/ShippingAddresses/Index.cshtml", db.ShippingAddresses.ToList());
        }

        // GET: ShippingAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingAddress shippingAddress = db.ShippingAddresses.Find(id);
            if (shippingAddress == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Address/ShippingAddresses/Details.cshtml", shippingAddress);
        }

        // GET: ShippingAddresses/Create
        public ActionResult Create()
        {
            AddressViewModel addressViewModel = new AddressViewModel
            {
                ContinentList = db.Continents.ToList(),
                CountryList = db.Countries.ToList(),
                StateList = db.States.ToList(),
                CityList = db.Cities.ToList(),
                StreetList = db.Streets.ToList()
            };
            return View("~/Views/Address/ShippingAddresses/Create.cshtml", addressViewModel);
        }

        // POST: ShippingAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AddedDate,IsActive")] ShippingAddress shippingAddress)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = db.Users.Find(User.Identity.GetUserId());
                shippingAddress.User = applicationUser;
                shippingAddress.AddedDate = DateTime.Now;
                shippingAddress.IsActive = true;

                db.ShippingAddresses.Add(shippingAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("~/Views/Address/ShippingAddresses/Create.cshtml", shippingAddress);
        }

        // GET: ShippingAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingAddress shippingAddress = db.ShippingAddresses.Find(id);
            if (shippingAddress == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Address/ShippingAddresses/Edit.cshtml", shippingAddress);
        }

        // POST: ShippingAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AddedDate,IsActive")] ShippingAddress shippingAddress)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = db.Users.Find(User.Identity.GetUserId());
                shippingAddress.User = applicationUser;
                shippingAddress.AddedDate = DateTime.Now;
                db.Entry(shippingAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("~/Views/Address/ShippingAddresses/Edit.cshtml", shippingAddress);
        }

        // GET: ShippingAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingAddress shippingAddress = db.ShippingAddresses.Find(id);
            if (shippingAddress == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Address/ShippingAddresses/Delete.cshtml", shippingAddress);
        }

        // POST: ShippingAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShippingAddress shippingAddress = db.ShippingAddresses.Find(id);
            db.ShippingAddresses.Remove(shippingAddress);
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
