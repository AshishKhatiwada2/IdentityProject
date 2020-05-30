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
    public class VehicleMediasController : Controller
    {
        private MainApplicationDBContext db = new MainApplicationDBContext();

        // GET: VehicleMedias
        public async Task<ActionResult> Index()
        {
            return View("~/Views/Vehicle/VehicleMedias/Index.cshtml",await db.VehicleMedias.ToListAsync());
        }

        // GET: VehicleMedias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMedia vehicleMedia = await db.VehicleMedias.FindAsync(id);
            if (vehicleMedia == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Vehicle/VehicleMedias/Details.cshtml", vehicleMedia);
        }

        // GET: VehicleMedias/Create
        public ActionResult Create()
        {
            return View("~/Views/Vehicle/VehicleMedias/Create.cshtml");
        }

        // POST: VehicleMedias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Path")] VehicleMedia vehicleMedia)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = db.Users.Find(User.Identity.GetUserId());
                vehicleMedia.Added_User = applicationUser;
                vehicleMedia.IsActive = true;
                db.VehicleMedias.Add(vehicleMedia);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View("~/Views/Vehicle/VehicleMedias/Create.cshtml", vehicleMedia);
        }

        // GET: VehicleMedias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMedia vehicleMedia = await db.VehicleMedias.FindAsync(id);
            if (vehicleMedia == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Vehicle/VehicleMedias/Edit.cshtml", vehicleMedia);
        }

        // POST: VehicleMedias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Path")] VehicleMedia vehicleMedia)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = db.Users.Find(User.Identity.GetUserId());
                vehicleMedia.Added_User = applicationUser;
                db.Entry(vehicleMedia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("~/Views/Vehicle/VehicleMedias/Edit.cshtml", vehicleMedia);
        }

        // GET: VehicleMedias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMedia vehicleMedia = await db.VehicleMedias.FindAsync(id);
            if (vehicleMedia == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Vehicle/VehicleMedias/Delete.cshtml", vehicleMedia);
        }

        // POST: VehicleMedias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VehicleMedia vehicleMedia = await db.VehicleMedias.FindAsync(id);
            db.VehicleMedias.Remove(vehicleMedia);
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
