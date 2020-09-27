using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GlrTransportInc.Data;
using GlrTransportInc.Models;

namespace GlrTransportInc.Pages.Events
{
    public class DeleteEvent : PageModel
    {
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;

        public DeleteEvent(GlrTransportInc.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Announcement Announcement { get; set; }
        public IList<UserModel> Users { get; set; }
        public static string Name;
        public static string Position;
        public async Task<IActionResult> OnGetAsync(int? id)
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

            Announcement = await _context.Announcement.FirstOrDefaultAsync(m => m.ID == id);

            if (Announcement == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Announcement = await _context.Announcement.FindAsync(id);

            if (Announcement != null)
            {
                _context.Announcement.Remove(Announcement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}