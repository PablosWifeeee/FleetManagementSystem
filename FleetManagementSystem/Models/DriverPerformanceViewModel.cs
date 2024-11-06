using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FleetManagementSystem.Models
{
    public class DriverPerformanceViewModel
    {
        public string Name { get; set; }
        public string LisenceType { get; set; }
        public double PointsEarned { get; set; }
        public double totalEarnings { get; set; }
        public double DeliveryRatings { get; set; }
 
    }
}