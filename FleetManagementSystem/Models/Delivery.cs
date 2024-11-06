using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using Microsoft.Ajax.Utilities;

namespace FleetManagementSystem.Models
{
    public class Delivery
    {
        [Key]
        public string DeliveryId { get; set; }
        public string truckId { get; set; }
        public virtual Truck Truck { get; set; }
        public string DriverId { get; set; }
        public virtual Driver Driverf { get; set; }
        public DateTime DelievryDate { get; set; }
        public double LoadWeight { get; set; }
        public double DeliveryEarnings { get; set; }
        public string IsCompleted { get; set; }
        public int Rating { get; set; }

            public int PullDriverPoints()
        {
            FleetDbContext db = new FleetDbContext();
            var dp=(from d in db.drivers
                    where d.DriverId==DriverId
                    select d.DriverPoints).Single ();
            return dp;
        }

        public double AddDelievryPoints()
        {
           
            int points = PullDriverPoints();
            if (IsCompleted=="Yes")
            {
                points = 50;

            }
            else if (IsCompleted=="No")
            {
                points = 0;
            }
            return points;
        }
         
        public double CalcDriverEarnings()
        {
            double earnings = 0.00;
            int points = PullDriverPoints();
            if(points>1000)
            {
                earnings += 500;
            }
            else
            {
                earnings = 0.00;
            }
            return earnings;

        }

        public double PullRatePerLoad()
        {
            FleetDbContext db = new FleetDbContext();
            var rpl = (from l in db.trucks
                       where l.truckId == truckId
                       select l.RatePerLoad).Single();
            return rpl;
        }
        public double CalcDeliveryEarnings()
        {
            double rateperloads = PullRatePerLoad();
            return LoadWeight * rateperloads;



        }


        public double ApplyRatingPenaltyOrReward()
        {
            int points = PullDriverPoints();
            double POR = 0.00;
            if (Rating >= 1 && Rating <= 3)
            {
                POR = CalcDriverEarnings() - 0.05;
            }
            else if(Rating>=4 && Rating<=5)
            {
                POR = points + 50;
            }
            return POR;
        }

        public double CalcTotalEarnings()
        {
            return CalcDriverEarnings() + CalcDeliveryEarnings() + AddDelievryPoints() + ApplyRatingPenaltyOrReward();
        }


        
    }
}