using Microsoft.AspNetCore.Mvc.RazorPages;
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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
namespace GlrTransportInc.Pages.Freight_Bills
{
    public class Files : PageModel
    {
        public string Filename1;
        public string Filename2;
        public string Filename3;
        public IFormFile Upload { get; set; }
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;
        private IWebHostEnvironment _environment;
        public static FreightBill FreightBill { get; set; }
        public Files(GlrTransportInc.Data.ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            FreightBill = await _context.FreightBill.FirstOrDefaultAsync(m => m.ID == id);
            Filename1 = FreightBill.Permit;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            if (Upload != null)
            {
                FreightBill.Permit = $"/Permits/{FreightBill.ID}{Path.GetExtension(Upload.FileName)}";

                var file = Path.Combine(_environment.ContentRootPath, "wwwroot/permits", $"{FreightBill.ID}{Path.GetExtension(Upload.FileName)}");
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await Upload.CopyToAsync(fileStream);
                }

                _context.Attach(FreightBill).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}