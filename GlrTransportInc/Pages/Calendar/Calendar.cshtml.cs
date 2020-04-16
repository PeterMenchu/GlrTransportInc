using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GlrTransportInc.Models;
using Microsoft.EntityFrameworkCore;


namespace GlrTransportInc
{
    public class CalendarModel : PageModel
    {
        // variables for the calendar 
        public static List<int> Id = new List<int>();
        public static List<string> BillName = new List<string>();
        public static List<DateTime> StartDate = new List<DateTime>();
        //public static List<DateTime> DueDate = new List<DateTime>();
        public static List<FbStatus> Status = new List<FbStatus>();
        // _context is for grabbing bill data
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;
        public CalendarModel(GlrTransportInc.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        // declare instance of the bill model so data can be grabbed
        public static IList<FreightBill> FreightBill { get;set; }
        // OnGetAsync is called when page is loaded, sets needed values from freight table
        public async Task OnGetAsync()
        {
            //Data Cleared so data isn't kept after each call
            Id.Clear();
            BillName.Clear();
            StartDate.Clear();
            //DueDate.Clear();
            Status.Clear();

            // enable data retrieval from DB to bill model
            FreightBill = await _context.FreightBill.ToListAsync();
            // loop through each freight, set needed values
            foreach (var item in FreightBill)
            {
                Id.Add(item.ID);
                BillName.Add(item.Customer);
                StartDate.Add(item.ScheduledDate);
                //DueDate.Add(item.DueDate);
                Status.Add(item.Status);
            }
        }
    }
}
