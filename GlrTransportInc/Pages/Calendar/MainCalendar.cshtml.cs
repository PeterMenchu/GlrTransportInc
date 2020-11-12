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
    public class MainCalendarModel : PageModel
    {
        // variables for the calendar 
        public static List<int> Id = new List<int>();
        public static List<string> BillName = new List<string>();
        public static List<DateTime?> StartDate = new List<DateTime?>();
        private DateTime _check = new DateTime(2020, 01, 01, 0, 00, 00);
        //public static List<DateTime> DueDate = new List<DateTime>();
        public static List<FbStatus> Status = new List<FbStatus>();
        public string SelectedName;
        private string _name;
        private string _init;
        public static List<string> DriverInit = new List<string>();
        public static List<string> NameList = new List<string>();
        public CalendarSelection Selection { get;set; }
        public FbStatus Placeholder { get; set; }
        public IList<UserModel> Users { get; set; }
        // _context is for grabbing bill data
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;
        public MainCalendarModel(GlrTransportInc.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        // declare instance of the bill model so data can be grabbed
        public static IList<FreightBill> FreightBill { get;set; }
        public IList<Announcement> Announcement { get;set; }
        // OnGetAsync is called when page is loaded, sets needed values from freight table
        public async Task OnGetAsync()
        {
            //Data Cleared so data isn't kept after each call
            Id.Clear();
            BillName.Clear();
            StartDate.Clear();
            //DueDate.Clear();
            Status.Clear();
            // Clear name and initials
            NameList.Clear();
            DriverInit.Clear();
            // get current user data for all employees
            Users = await _context.UserModel.ToListAsync();
            // enable data retrieval from DB to bill model
            FreightBill = await _context.FreightBill.ToListAsync();
            Announcement = await _context.Announcement.ToListAsync();
            // loop through each freight, set needed values
            foreach (var item in FreightBill)
            {
                if (item.ScheduledDate != null)
                {
                    Id.Add(item.ID);
                    BillName.Add(item.Customer);
                    StartDate.Add(item.ScheduledDate);
                    Status.Add(item.Status);
                    _name = item.Driver;
                    NameList.Add(item.Driver);
                    if (_name != "Unassigned" && _name != null)
                    {
                        for (int i = 0; i < _name.Length; i++)
                        {
                            if (i == 0)
                            {
                                _init += _name[i];
                            }
                            if (i > 0 && _name[i-1]== ' ' && _name[i] != ' ')
                            {
                                _init += _name[i];
                            }
                        }
                        _init += ": ";
                    }
                    else
                    {
                        _init = "";
                    }
                    DriverInit.Add(_init);
                    _init = null;
                }
            }
            // find events, can add announcements if needed
            foreach (var e in Announcement)
            {
                if (e.eventFlag == 1)
                {
                    if (e.DatePosted != null)
                    {
                        Id.Add(e.ID);
                        BillName.Add(e.Title);
                        StartDate.Add(e.DatePosted);
                        //Status.Add(Placeholder);
                        _name = "Unassigned";
                        NameList.Add(null);
                        if (_name != "Unassigned" && _name != null)
                        {
                            for (int i = 0; i < _name.Length; i++)
                            {
                                if (i == 0)
                                {
                                    _init += _name[i];
                                }

                                if (i > 0 && _name[i - 1] == ' ' && _name[i] != ' ')
                                {
                                    _init += _name[i];
                                }
                            }

                            _init += ": ";
                        }
                        else
                        {
                            _init = "";
                        }

                        DriverInit.Add(_init);
                        _init = null;
                    }
                }
            }
        }
        
        public void setName(string name)
        {
            CalendarSelection.Selection = name;
        }
        public IActionResult OnPost()
        {
            SelectedName = Request.Form["SelectedName"];
            if (SelectedName == "all" || SelectedName == null)
            {
                return RedirectToPage("./MainCalendar");
            }
            else
            {
                setName(SelectedName);
                return RedirectToPage("./SelectCalendar");
            }
        }
    }
}
