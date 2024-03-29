using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public int BillId;
        public int FileNum;
        // file variables that hold the data
        public IFormFile Upload { get; set; }
        public IFormFile Upload2 { get; set; }
        public IFormFile Upload3 { get; set; }
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
            FileNum = 0;
            Upload = null;
            Upload2 = null;
            Upload3 = null;
            FreightBill = await _context.FreightBill.FirstOrDefaultAsync(m => m.ID == id);
            Filename1 = FreightBill.Permit;
            Filename2 = FreightBill.File2;
            Filename3 = FreightBill.file3;
            BillId = FreightBill.ID;    
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string name;
            if (Upload != null)
            {
                name = Upload.FileName;
                
                FreightBill.Permit = $"{name}";
                var file = Path.Combine(_environment.ContentRootPath, "wwwroot/Permits/", $"{name}");
                
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await Upload.CopyToAsync(fileStream);
                }

                _context.Attach(FreightBill).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            if (Upload2 != null)
            {
                name = Upload2.FileName;
                FreightBill.File2 = $"{name}";
                var file = Path.Combine(_environment.ContentRootPath, "wwwroot/Permits/", $"{name}");
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await Upload2.CopyToAsync(fileStream);
                }

                _context.Attach(FreightBill).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            if (Upload3 != null)
            {
                name = Upload3.FileName;
                /* FIX "file3" NAME :( */
                FreightBill.file3 = $"{name}";
                var file = Path.Combine(_environment.ContentRootPath, "wwwroot/Permits/", $"{name}");
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await Upload3.CopyToAsync(fileStream);
                }

                _context.Attach(FreightBill).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            
            FileNum = 0;
            return RedirectToPage("./Files", new {id = FreightBill.ID });
        }
    }
}