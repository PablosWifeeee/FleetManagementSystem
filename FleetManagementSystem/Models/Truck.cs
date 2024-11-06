using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FleetManagementSystem.Models
{
    public class Truck
    {
        [Key]
        public string truckId { get; set; }
        public string TruckType { get; set; }
        public double MaxCapacity { get; set; }
        public double CurrentMileage { get; set; }
        public double RatePerLoad { get; set; }

    }
}