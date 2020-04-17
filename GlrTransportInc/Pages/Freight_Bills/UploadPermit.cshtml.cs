using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GlrTransportInc.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GlrTransportInc.Pages.Freight_Bills
{
    public class UploadPermitModel : PageModel
    {
        private IWebHostEnvironment _environment;
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;
        public UploadPermitModel(IWebHostEnvironment environment, GlrTransportInc.Data.ApplicationDbContext context)
        {
            _environment = environment;
            _context = context;
        }
        [BindProperty]
        public IFormFile Upload { get; set; }
        public FreightBill FreightBill { get; set; }
        public IList<UserModel> UserModel { get; set; }
        public static string Name;
        public static string Position;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UserModel = await _context.UserModel.ToListAsync();
            foreach (var item in UserModel)
            {
                if ((item.Email) == User.Identity.Name)
                {
                    Name = item.Name;
                    Position = item.Position;
                }
            }
            FreightBill = await _context.FreightBill.FirstOrDefaultAsync(m => m.ID == id);
            if (FreightBill == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var file = Path.Combine(_environment.ContentRootPath, "wwwroot/permits", Upload.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);
            }
            //Probably want to update it here <---------- I tried FreightBill.Permit = Upload.FileName; but it doesn't work.
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