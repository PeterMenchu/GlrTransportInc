using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GlrTransportInc.Data;
using GlrTransportInc.Models;
using Microsoft.EntityFrameworkCore;

namespace GlrTransportInc.Pages.Timesheets
{
    public class CreateModel : PageModel
    {
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;

        public CreateModel(GlrTransportInc.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Timesheet Timesheet { get; set; }
        public IList<UserModel> Users { get; set; }
        public static string Name;
        public static string Position;

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Users = await _context.UserModel.ToListAsync();
            foreach (var item in Users)
            {
                if ((item.Email) == User.Identity.Name)
                {
                    Name = item.Name;
                    Position = item.Position;
                }
            }
            Timesheet.Email = Name;
            Timesheet.End = Timesheet.Week.AddDays(6);
            _context.Timesheet.Add(Timesheet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./MyIndex");
        }
    }
}
