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
    public class DeletePermitModel : PageModel
    {
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;
        private IWebHostEnvironment _environment;
        public DeletePermitModel(GlrTransportInc.Data.ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public FreightBill FreightBill { get; set; }
        public IList<UserModel> Users { get; set; }
        public static string Name;
        public static string Position;
        public async Task<IActionResult> OnGetAsync(int? id, int? fileNum)
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

        public async Task<IActionResult> OnPostAsync(int? id, int? fileNum)
        {
            if (id == null)
            {
                return NotFound();
            }
            FreightBill = await _context.FreightBill.FindAsync(id);

            if (FreightBill != null)
            {
                if (FreightBill.Permit != null && fileNum == 1)
                {
                    var file = Path.Combine(_environment.ContentRootPath, "wwwroot/Permits/", FreightBill.Permit);
                    System.IO.File.Delete(file);
                    FreightBill.Permit = null;
                }
                if (FreightBill.File2 != null && fileNum == 2)
                {
                    var file = Path.Combine(_environment.ContentRootPath, "wwwroot/Permits/", FreightBill.File2);
                    System.IO.File.Delete(file);
                    FreightBill.File2 = null;
                }
                if (FreightBill.file3 != null && fileNum == 3)
                {
                    var file = Path.Combine(_environment.ContentRootPath, "wwwroot/Permits/", FreightBill.file3);
                    System.IO.File.Delete(file);
                    FreightBill.file3 = null;
                }
                
            }

            _context.Attach(FreightBill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FreightBillExists(FreightBill.ID))
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

        private bool FreightBillExists(int id)
        {
            return _context.FreightBill.Any(e => e.ID == id);
        }
    }
}