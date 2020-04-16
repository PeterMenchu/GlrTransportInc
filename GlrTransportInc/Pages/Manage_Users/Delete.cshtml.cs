using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlrTransportInc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GlrTransportInc.Pages.Manage_Users
{
    public class DeleteModel : PageModel
    {
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;

        public DeleteModel(GlrTransportInc.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserModel UserModel { get; set; }
        public IList<UserModel> Users { get; set; }
        public static string Name;
        public static string Position;
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserModel = await _context.UserModel.FirstOrDefaultAsync(m => m.Id == id);
            Users = await _context.UserModel.ToListAsync();
            foreach (var item in Users)
            {
                if ((item.Email) == User.Identity.Name)
                {
                    Name = item.Name;
                    Position = item.Position;
                }
            }

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserModel = await _context.UserModel.FindAsync(id);

            if (UserModel != null)
            {
                _context.UserModel.Remove(UserModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
