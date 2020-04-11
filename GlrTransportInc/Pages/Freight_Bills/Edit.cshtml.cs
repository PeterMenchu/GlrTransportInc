using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GlrTransportInc.Data;
using GlrTransportInc.Models;

namespace GlrTransportInc
{
    public class EditModel : PageModel
    {
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;

        public EditModel(GlrTransportInc.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FreightBill FreightBill { get; set; }
        public IList<UserModel> UserModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FreightBill = await _context.FreightBill.FirstOrDefaultAsync(m => m.ID == id);

            if (FreightBill == null)
            {
                return NotFound();
            }
            UserModel = await _context.UserModel.ToListAsync();
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
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
