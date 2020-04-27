using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlrTransportInc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static GlrTransportInc.Pages.Profile.EmployeeProcessor;

namespace GlrTransportInc.Pages.Manage_Users
{
    public class EditModel : PageModel
    {
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;

        public EditModel(GlrTransportInc.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserModel UserModel { get; set; }
        public IList<UserModel> Users { get; set; }
        public static string Name;
        public static string Position;
        public static string currentName;
        private int _billFlag;
        private int _annFlag;
        private int _timeFlag;
        public IList<Announcement> AnnouncementCheck { get;set; }
        public static IList<FreightBill> FreightBillCheck { get;set; }
        public IList<Timesheet> TimesheetCheck { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            Users = await _context.UserModel.ToListAsync();
            foreach (var item in Users)
            {
                if ((item.Email) == User.Identity.Name)
                {
                    Name = item.Name;
                    Position = item.Position;
                }
            }
            if (id == null)
            {
                return NotFound();
            }

            UserModel = await _context.UserModel.FirstOrDefaultAsync(m => m.Id == id);

            if (UserModel == null)
            {
                return NotFound();
            }
            currentName = UserModel.Name;
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(UserModel.Position == "Driver")
            {
                UserModel.CanDrive = "true";
            }

            if (UserModel.Name != currentName && UserModel.Name != null)
            {
                FreightBillCheck = await _context.FreightBill.ToListAsync();
                AnnouncementCheck = await _context.Announcement.ToListAsync();
                TimesheetCheck = await _context.Timesheet.ToListAsync();
                foreach (var bill in FreightBillCheck)
                {
                    if (bill.Driver == currentName)
                    {
                        _billFlag = 1;
                        updateNames(UserModel.Name, currentName, _billFlag, _annFlag, _timeFlag);
                        _billFlag = 0;
                    }
                }

                foreach (var post in AnnouncementCheck)
                {
                    if (post.Author == currentName)
                    {
                        _annFlag = 1;
                        updateNames(UserModel.Name, currentName, _billFlag, _annFlag, _timeFlag);
                        _annFlag = 0;
                    }
                }

                foreach (var timesheet in TimesheetCheck)
                {
                    if (timesheet.Email == currentName)
                    {
                        _timeFlag = 1;
                        updateNames(UserModel.Name, currentName, _billFlag, _annFlag, _timeFlag);
                        _timeFlag = 0;
                    }
                }
            }
            _context.Attach(UserModel).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserModelExists(UserModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UserModelExists(string id)
        {
            return _context.UserModel.Any(e => e.Id == id);
        }
    }
}