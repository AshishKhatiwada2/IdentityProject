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
    public class VariantsController : Controller
    {
        private MainApplicationDBContext db = new MainApplicationDBContext();

        // GET: Variants
        public async Task<ActionResult> Index()
        {
            return View("~/Views/Vehicle/Variants/Index.cshtml",await db.Variants.ToListAsync());
        }

        // GET: Variants/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Variant variant = await db.Variants.FindAsync(id);
            if (variant == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Vehicle/Variants/Details.cshtml",variant);
        }

        // GET: Variants/Create
        public ActionResult Create()
        {
            return View("~/Views/Vehicle/Variants/Create.cshtml");
        }

        // POST: Variants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Ex_ShowroomPrice,On_Road_Price,Mileage,Engine_DisplacementCC,Engine_Type,Number_Of_Cylinder,Max_Power,Max_Torque,Front_Brake,Rear_Brake,Total_Rating,Fuel_Tank_Capacity,Body_Type,Emi_Starts,Insurance,Cooling_System,Valve_Per_Cylinder,Drive_Type,Ignition,Fuel_Supply,Clutch_Type,Engine_Start,Transmission,Gear_Box,Bore,Stroke,Emission_Type,ABS,Console,Clock,Quick_Shifter,Additional_Features,Stepup_Seat,Seat_Height_mm,Maximum_Height_mm,Maximum_Length_mm,Side_View_Mirror,Side_View_Mirror_Width_mm,Passenger_Footrest,Chassis,Front_Suspension,Rear_Suspention,Body_Graphics,Saddle_Height,Ground_Clearance,Wheelbase,Dry_Weight,Headlight,Tail_Light,Turn_Signal_Lamp,Led_Tail_Lights,Front_Tyre_Size,Rear_Tyre_Size,Tyre_Type,Front_Wheel_Size,Rear_Wheel_Size,Wheel_Type,Front_Brake_Diameter,Rear_Brake_Diameter,Kerb_Weight,Front_Track,Rear_Track,Minimum_Turning_Radius,Number_Of_Doors,Seat_Capacity,Number_Gears,Mileage_City,Mileage_Highway,Steering_Type,Acceleration_From_0_to_100,Acceleration_From_0_to_60,Max_Speed,LaunchDate,Model_Year,Popularity,AddedDate,IsActive,User_Rating")] Variant variant)
        {
            if (ModelState.IsValid)
            {
                db.Variants.Add(variant);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View("~/Views/Vehicle/Variants/Create.cshtml",variant);
        }

        // GET: Variants/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Variant variant = await db.Variants.FindAsync(id);
            if (variant == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Vehicle/Variants/Edit.cshtml",variant);
        }

        // POST: Variants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Ex_ShowroomPrice,On_Road_Price,Mileage,Engine_DisplacementCC,Engine_Type,Number_Of_Cylinder,Max_Power,Max_Torque,Front_Brake,Rear_Brake,Total_Rating,Fuel_Tank_Capacity,Body_Type,Emi_Starts,Insurance,Cooling_System,Valve_Per_Cylinder,Drive_Type,Ignition,Fuel_Supply,Clutch_Type,Engine_Start,Transmission,Gear_Box,Bore,Stroke,Emission_Type,ABS,Console,Clock,Quick_Shifter,Additional_Features,Stepup_Seat,Seat_Height_mm,Maximum_Height_mm,Maximum_Length_mm,Side_View_Mirror,Side_View_Mirror_Width_mm,Passenger_Footrest,Chassis,Front_Suspension,Rear_Suspention,Body_Graphics,Saddle_Height,Ground_Clearance,Wheelbase,Dry_Weight,Headlight,Tail_Light,Turn_Signal_Lamp,Led_Tail_Lights,Front_Tyre_Size,Rear_Tyre_Size,Tyre_Type,Front_Wheel_Size,Rear_Wheel_Size,Wheel_Type,Front_Brake_Diameter,Rear_Brake_Diameter,Kerb_Weight,Front_Track,Rear_Track,Minimum_Turning_Radius,Number_Of_Doors,Seat_Capacity,Number_Gears,Mileage_City,Mileage_Highway,Steering_Type,Acceleration_From_0_to_100,Acceleration_From_0_to_60,Max_Speed,LaunchDate,Model_Year,Popularity,AddedDate,IsActive,User_Rating")] Variant variant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(variant).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("~/Views/Vehicle/Variants/Edit.cshtml",variant);
        }

        // GET: Variants/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Variant variant = await db.Variants.FindAsync(id);
            if (variant == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Vehicle/Variants/Delete.cshtml",variant);
        }

        // POST: Variants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Variant variant = await db.Variants.FindAsync(id);
            db.Variants.Remove(variant);
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
