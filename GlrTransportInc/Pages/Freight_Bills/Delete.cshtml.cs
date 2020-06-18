using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GlrTransportInc.Data;
using GlrTransportInc.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace GlrTransportInc
{
    public class DeleteModel : PageModel
    {
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;
        private IWebHostEnvironment _environment;
        public DeleteModel(GlrTransportInc.Data.ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public FreightBill FreightBill { get; set; }
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

            FreightBill = await _context.FreightBill.FirstOrDefaultAsync(m => m.ID == id);

            if (FreightBill == null)
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

            FreightBill = await _context.FreightBill.FindAsync(id);

            if (FreightBill != null)
            {
                if (FreightBill.Permit != null)
                {
                    var file = Path.Combine(_environment.ContentRootPath, "wwwroot/permits", FreightBill.Permit.Substring(8));
                    System.IO.File.Delete(file);
                }
                if (FreightBill.File2 != null)
                {
                    var file = Path.Combine(_environment.ContentRootPath, "wwwroot/permits", FreightBill.File2.Substring(8));
                    System.IO.File.Delete(file);
                }
                /* neeed to change "file3" name later */
                if (FreightBill.file3 != null)
                {
                    var file = Path.Combine(_environment.ContentRootPath, "wwwroot/permits", FreightBill.file3.Substring(8));
                    System.IO.File.Delete(file);
                }
                _context.FreightBill.Remove(FreightBill);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
