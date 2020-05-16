using System;
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
//using static GlrTransportInc.Pages.Freight_Bills.PermitProcessor;

namespace GlrTransportInc.Pages.Freight_Bills
{
    public class EditModel : PageModel
    {
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;
        private IWebHostEnvironment _environment;
        public EditModel(GlrTransportInc.Data.ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public static IList<FreightBill> AllBills { get; set; }
        [BindProperty]
        public FreightBill FreightBill { get; set; }
        public IList<UserModel> UserModel { get; set; }
        public static string Name;
        public static string Position;
        [BindProperty]
        public IFormFile Upload { get; set; }
        /*
        public async Task OnSubmitPermit()
        {
            var file = Path.Combine(_environment.ContentRootPath, "wwwroot/permits", Upload.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);
            }
        }
        */
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Upload = null;
            UserModel = await _context.UserModel.ToListAsync();
            foreach (var item in UserModel)
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
            AllBills = await _context.FreightBill.ToListAsync();
            if (FreightBill == null)
            {
                return NotFound();
            }
            UserModel = await _context.UserModel.ToListAsync();
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        
        // public async Task<IActionResult> OnSubmitEdit()
        public async Task<IActionResult> OnPostAsync(string command)
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
            }
            if (FreightBill.FreightBillNumber != null)
            {
                foreach (var bill in AllBills)
                {
                    if (bill.FreightBillNumber == FreightBill.FreightBillNumber && FreightBill.ID != bill.ID)
                    {
                        FreightBill.FreightBillNumber = "000"; // set 000 as default flag
                    }
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




