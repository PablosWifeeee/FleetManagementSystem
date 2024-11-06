using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FleetManagementSystem.Models
{
    public class FleetDbContext:DbContext
    {
        public FleetDbContext() : base("FleetDeliverySystem") { }
        public DbSet<Delivery> deliverries { get; set; }
        public DbSet<Driver> drivers { get; set; }
        public DbSet<Truck> trucks { get; set; }
        public DbSet<DriverPerformanceViewModel> driverPerformanceViewModels { get; set; }

    }
}