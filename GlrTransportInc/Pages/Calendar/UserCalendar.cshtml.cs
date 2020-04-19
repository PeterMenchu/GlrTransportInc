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
    public class UserCalendarModel : PageModel
    {
        // variables for the calendar 
        public static List<int> Id = new List<int>();
        public static List<string> BillName = new List<string>();
        public static List<DateTime> StartDate = new List<DateTime>();
        public static List<FbStatus> Status = new List<FbStatus>();
        public IList<UserModel> Users { get; set; }

        public static string DriverName;
        // _context is for grabbing bill data
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;
        public UserCalendarModel(GlrTransportInc.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        // declare instance of the bill model so data can be grabbed
        public static IList<FreightBill> FreightBill { get;set; }
        // OnGetAsync is called when page is loaded, sets needed values from freight table
        public async Task OnGetAsync()
        {
            //Data Cleared so data isn't kept after each call (each item kept getting added on each get call for this page)
            Id.Clear();
            BillName.Clear();
            StartDate.Clear();
            //DueDate.Clear();
            Status.Clear();

            // enable data retrieval from DB to bill model
            FreightBill = await _context.FreightBill.ToListAsync();
            // Find current users full name to link it with the bill
            // Since email never changes, it is safest to use it as the index to determine this
            Users = await _context.UserModel.ToListAsync();
            foreach (var user in Users)
            {
                if (user.Email == User.Identity.Name)
                {
                    DriverName = user.Name;
                    break;
                }
            }
            // loop through each freight, set needed values
            foreach (var item in FreightBill)
            {
                // checks if logged in user is assigned this freight
                if (item.Driver == DriverName)
                {
                    Id.Add(item.ID);
                    BillName.Add(item.Customer);
                    StartDate.Add(item.ScheduledDate);
                    Status.Add(item.Status);
                }
            }
        }
    }
}