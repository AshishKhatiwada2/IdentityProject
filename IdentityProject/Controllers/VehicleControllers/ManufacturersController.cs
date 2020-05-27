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
    public class ManufacturersController : Controller
    {
        private MainApplicationDBContext db = new MainApplicationDBContext();

        // GET: Manufacturers
        public async Task<ActionResult> Index()
        {
            return View("~/Views/Vehicle/Manufacturers/Index.cshtml",await db.Manufacturers.ToListAsync());
        }

        // GET: Manufacturers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = await db.Manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Vehicle/Manufacturers/Details.cshtml", manufacturer);
        }

        // GET: Manufacturers/Create
        public ActionResult Create()
        {
            return View("~/Views/Vehicle/Manufacturers/Create.cshtml");
        }

        // POST: Manufacturers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FullName,ShortName,OriginCountry,BusinessNumber,AddedDate,IsActive")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = db.Users.Find(User.Identity.GetUserId());
                manufacturer.AddedDate = DateTime.Now;
                //manufacturer.Added_User = applicationUser;
                db.Manufacturers.Add(manufacturer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View("~/Views/Vehicle/Manufacturers/Create.cshtml", manufacturer);
        }

        // GET: Manufacturers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = await db.Manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Vehicle/Manufacturers/Edit.cshtml", manufacturer);
        }

        // POST: Manufacturers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FullName,ShortName,OriginCountry,BusinessNumber,AddedDate,IsActive")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manufacturer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("~/Views/Vehicle/Manufacturers/Edit.cshtml", manufacturer);
        }

        // GET: Manufacturers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = await db.Manufacturers.FindAsync(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Vehicle/Manufacturers/Delete.cshtml", manufacturer);
        }

        // POST: Manufacturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Manufacturer manufacturer = await db.Manufacturers.FindAsync(id);
            db.Manufacturers.Remove(manufacturer);
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
