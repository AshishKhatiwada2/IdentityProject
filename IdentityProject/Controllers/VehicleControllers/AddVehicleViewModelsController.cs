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
using IdentityProject.ViewModels;

namespace IdentityProject.Controllers.VehicleControllers
{
    public class AddVehicleViewModelsController : Controller
    {
        private MainApplicationDBContext db = new MainApplicationDBContext();

        // GET: AddVehicleViewModels
        public async Task<ActionResult> Index()
        {
            AddVehicleViewModel addVehicleViewModel = new AddVehicleViewModel
            {
                ColorList = await db.Colors.ToListAsync(),
                ManufacturerList = await db.Manufacturers.ToListAsync(),
                VehicleTypeList = await db.VehicleTypes.ToListAsync(),
                VehicleModelList=await db.VehicleModel.ToListAsync()

            };
            return View(addVehicleViewModel);
        }

        // GET: AddVehicleViewModels/Details/5
       

        // GET: AddVehicleViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

      
        
    }
}
