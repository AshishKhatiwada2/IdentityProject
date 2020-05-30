using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentityProject.Models;
using IdentityProject.Models.Vehicle;
using Microsoft.AspNet.Identity;

namespace IdentityProject.Controllers.VehicleControllers
{
    public class UserRatingsController : Controller
    {
        private MainApplicationDBContext db = new MainApplicationDBContext();

        // GET: UserRatings
        public async Task<ActionResult> Index()
        {
            return View("~/Views/Vehicle/UserRatings/Index.cshtml",await db.UserRatings.ToListAsync());
        }

        // GET: UserRatings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRating userRating = await db.UserRatings.FindAsync(id);
            if (userRating == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Vehicle/UserRatings/Details.cshtml", userRating);
        }

        // GET: UserRatings/Create
        public ActionResult Create()
        {
            return View("~/Views/Vehicle/UserRatings/Create.cshtml");
        }

        // POST: UserRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserComment,Date,ViewNumber")] UserRating userRating)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = db.Users.Find(User.Identity.GetUserId());
                userRating.Date = DateTime.Now;
                userRating.Added_User = applicationUser;

                db.UserRatings.Add(userRating);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View("~/Views/Vehicle/UserRatings/Create.cshtml", userRating);
        }

        // GET: UserRatings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRating userRating = await db.UserRatings.FindAsync(id);
            if (userRating == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Vehicle/UserRatings/Edit.cshtml", userRating);
        }

        // POST: UserRatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserComment,Date,ViewNumber")] UserRating userRating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRating).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("~/Views/Vehicle/UserRatings/Edit.cshtml", userRating);
        }

        // GET: UserRatings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRating userRating = await db.UserRatings.FindAsync(id);
            if (userRating == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Vehicle/UserRatings/Delete.cshtml", userRating);
        }

        // POST: UserRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserRating userRating = await db.UserRatings.FindAsync(id);
            db.UserRatings.Remove(userRating);
            await db.SaveChangesAsync();
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
