using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GlrTransportInc.Data;
using GlrTransportInc.Models;

namespace GlrTransportInc
{
    public class DetailsModel3 : PageModel
    {
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;

        public DetailsModel3(GlrTransportInc.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Timesheet Timesheet { get; set; }
        public IList<UserModel> Users { get; set; }
        public static string Name;
        public static string Position;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Timesheet = await _context.Timesheet.FirstOrDefaultAsync(m => m.ID == id);
            Users = await _context.UserModel.ToListAsync();
            foreach (var item in Users)
            {
                if ((item.Email) == User.Identity.Name)
                {
                    Name = item.Name;
                    Position = item.Position;
                }
            }

            if (Timesheet == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
