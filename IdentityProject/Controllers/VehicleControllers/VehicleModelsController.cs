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
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityProject.Controllers.VehicleControllers
{
    public class VehicleModelsController : Controller
    {
        private MainApplicationDBContext db = new MainApplicationDBContext();
        
        // GET: VehicleModels
        public async Task<ActionResult> Index()
        {
            return View("~/Views/Vehicle/VehicleModels/Index.cshtml",await db.VehicleModel.ToListAsync());
        }

        // GET: VehicleModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = await db.VehicleModel.FindAsync(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Vehicle/VehicleModels/Details.cshtml", vehicleModel);
        }

        // GET: VehicleModels/Create
        public ActionResult Create()
        {
            return View("~/Views/Vehicle/VehicleModels/Create.cshtml");
        }

        // POST: VehicleModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Model_Name,Popularity,AddedDate,IsActive,User_Rating")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                vehicleModel.AddedDate = DateTime.Now;
                ApplicationUser applicationUser =db.Users.Find( User.Identity.GetUserId());
                
                //This Code will check if Database contains currently logged in user this may require more time to execute
                // This code will no longer support Identity 3
                //var currentMUser = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                //var CurrentUser = db.Users.Find(currentMUser.UserId);
                //vehicleModel.Added_User = CurrentUser;
                
                vehicleModel.Added_User = applicationUser;
                db.VehicleModel.Add(vehicleModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View("~/Views/Vehicle/VehicleModels/Create.cshtml", vehicleModel);
        }

        // GET: VehicleModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = await db.VehicleModel.FindAsync(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Vehicle/VehicleModels/Edit.cshtml", vehicleModel);
        }

        // POST: VehicleModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Model_Name,Popularity,AddedDate,IsActive,User_Rating")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("~/Views/Vehicle/VehicleModels/Edit.cshtml", vehicleModel);
        }

        // GET: VehicleModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleModel vehicleModel = await db.VehicleModel.FindAsync(id);
            if (vehicleModel == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Vehicle/VehicleModels/Delete.cshtml", vehicleModel);
        }

        // POST: VehicleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VehicleModel vehicleModel = await db.VehicleModel.FindAsync(id);
            db.VehicleModel.Remove(vehicleModel);
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
