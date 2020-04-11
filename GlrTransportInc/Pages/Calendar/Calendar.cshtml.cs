using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GlrTransportInc.Models;
using Microsoft.EntityFrameworkCore;


namespace GlrTransportInc.Pages.Calendar
{
    public class CalendarModel : PageModel
    {
        // variables for the calendar 
        public static List<string> BillName = new List<string>();
        public static List<DateTime> StartDate = new List<DateTime>();
        public static List<DateTime> DueDate = new List<DateTime>();
        // _context is for grabbing bill data
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;
        public CalendarModel(GlrTransportInc.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        // declare instance of the bill model so data can be grabbed
        public IList<FreightBill> FreightBill { get;set; }
        // OnGetAsync is called when page is loaded, sets needed values from freight table
        public async Task OnGetAsync()
        {
            // enable data retrieval from DB to bill model
            FreightBill = await _context.FreightBill.ToListAsync();
            // loop through each freight, set needed values
            foreach (var item in FreightBill)
            {
                BillName.Add(item.Customer);
                StartDate.Add(item.ScheduledDate);
                DueDate.Add(item.DueDate);
            }
        }
    }
}
