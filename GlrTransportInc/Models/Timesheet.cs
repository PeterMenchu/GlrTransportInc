using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace GlrTransportInc.Models
{
    public class Timesheet
    {
        public string Email { get; set; }
        public DateTime Week { get; set; }
        public List<float> Hours { get; set; }
        public List<int> Jobs { get; set; }
        public List<string> Comments { get; set; }
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