using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FleetManagementSystem.Models
{
    public class Driver
    {
        [Key]
        public string DriverId { get; set; }
        public string Name { get; set; }
        public string LicenseType { get; set; }
        public string AssignedTruckId { get; set; }
        public int DriverPoints { get; set; }
        public double DriverEarnings { get; set; }

    }
}