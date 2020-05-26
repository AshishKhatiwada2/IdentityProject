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

namespace IdentityProject.Controllers.VehicleControllers
{
    public class EngineEmissionsController : Controller
    {
        private MainApplicationDBContext db = new MainApplicationDBContext();

        // GET: EngineEmissions
        public async Task<ActionResult> Index()
        {
            return View("~/Views/Vehicle/EngineEmissions/Index.cshtml", await db.EngineEmissions.ToListAsync());
        }

        // GET: EngineEmissions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngineEmission engineEmission = await db.EngineEmissions.FindAsync(id);
            if (engineEmission == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Vehicle/EngineEmissions/Details.cshtml", engineEmission);
        }

        // GET: EngineEmissions/Create
        public ActionResult Create()
        {
            return View("~/Views/Vehicle/EngineEmissions/Create.cshtml");
        }

        // POST: EngineEmissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,AddedDate,EffectiveDate,IsActive")] EngineEmission engineEmission)
        {
            if (ModelState.IsValid)
            {
                db.EngineEmissions.Add(engineEmission);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View("~/Views/Vehicle/EngineEmissions/Create.cshtml", engineEmission);
        }

        // GET: EngineEmissions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngineEmission engineEmission = await db.EngineEmissions.FindAsync(id);
            if (engineEmission == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Vehicle/EngineEmissions/Edit.cshtml", engineEmission);
        }

        // POST: EngineEmissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,AddedDate,EffectiveDate,IsActive")] EngineEmission engineEmission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(engineEmission).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("~/Views/Vehicle/EngineEmissions/Edit.cshtml", engineEmission);
        }

        // GET: EngineEmissions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EngineEmission engineEmission = await db.EngineEmissions.FindAsync(id);
            if (engineEmission == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Vehicle/EngineEmissions/Delete.cshtml", engineEmission);
        }

        // POST: EngineEmissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EngineEmission engineEmission = await db.EngineEmissions.FindAsync(id);
            db.EngineEmissions.Remove(engineEmission);
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
