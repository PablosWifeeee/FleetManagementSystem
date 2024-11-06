using FleetManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FleetManagementSystem.Controllers
{
    public class FleetManagementController : Controller
    {
        // GET: FleetManagement
        public ActionResult Index()
        {
            List<DriverPerformanceViewModel> DPVM = new List<DriverPerformanceViewModel>();
            var DriverList = (from d in db.drivers
                              join ver in db.driver on d.DriverId equals ver.DriverId
                              join ery in db.deliveries on ver.deliveryId equals ery.DeliveryId
                              select new { d.Name, d.LisenceType , ery.DeliveryEarnings, ery.Rating });
            (foreach var driver in DriverList)
            {
                DriverPerformanceViewModel dpVm =new DriverPerformanceViewModel();
                dpVm.Name = driver.Name;
                dpVm.LisenceType=driver.LisenceType;
                dpVm.DelievryEarnngs = driver.DeliveryEarnings;
                dpVm.DeliveryRatings = driver.Ratings;
                dpVm.Add(DPVM);
            }
            return View(DPVM);
        }
    }
}