using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GlrTransportInc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
namespace GlrTransportInc.Pages.Freight_Bills
{
    public class AddSignature : PageModel
    {
        public string data;
        public int? billID;
        public string bill;
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;
        private IWebHostEnvironment _environment;
        public static FreightBill FreightBill { get; set; }
        public AddSignature(GlrTransportInc.Data.ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            FreightBill = await _context.FreightBill.FirstOrDefaultAsync(m => m.ID == id);
            bill = FreightBill.Customer;
            billID = id;
            return Page();
        }
        public async Task<IActionResult> OnPost(string image)
        {
            
            if (image != null)
            {
                FreightBill.ReceivedBy = image;
                _context.Attach(FreightBill).State = EntityState.Modified;
                await _context.SaveChangesAsync(); 
            }
            return RedirectToPage("./Index");
        }
    }
}