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
    public class DetailsModel2 : PageModel
    {
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;

        public DetailsModel2(GlrTransportInc.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Announcement Announcement { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Announcement = await _context.Announcement.FirstOrDefaultAsync(m => m.ID == id);

            if (Announcement == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
