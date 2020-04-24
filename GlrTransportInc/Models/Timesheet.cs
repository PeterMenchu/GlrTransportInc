using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace GlrTransportInc.Models
{
    public class Timesheet
    {
        public int ID { get; set; }
        public string Email { get; set; } //Author name, we don't need their email. Didn't bother to change it in the database.
        public DateTime Week { get; set; }
        public float Hours1 { get; set; }
        public float Hours2 { get; set; }
        public float Hours3 { get; set; }
        public float Hours4 { get; set; }
        public float Hours5 { get; set; }
        public int Jobs1 { get; set; }
        public int Jobs2 { get; set; }
        public int Jobs3 { get; set; }
        public int Jobs4 { get; set; }
        public int Jobs5 { get; set; }
        public string Comments1 { get; set; }
        public string Comments2 { get; set; }
        public string Comments3 { get; set; }
        public string Comments4 { get; set; }
        public string Comments5 { get; set; }
        public float TotalHours { get; set; }
        public float PerHour { get; set; }
        public float Over40PerHour { get; set; }
        // **office use
        public int Total { get; set; }
        public DateTime PayDate { get; set; }
        public float NetPay { get; set; }
        public int DaysOff { get; set; }
    }
}