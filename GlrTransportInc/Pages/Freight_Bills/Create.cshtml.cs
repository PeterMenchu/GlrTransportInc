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

namespace GlrTransportInc.Pages.Freight_Bills
{
    public class CreateModel : PageModel
    {
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;

        public CreateModel(GlrTransportInc.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<UserModel> UserModel { get; set; }
        public static string Name;
        public static string Position;
        public async Task<IActionResult> OnGetAsync()
        {
            UserModel = await _context.UserModel.ToListAsync();
            foreach (var item in UserModel)
            {
                if ((item.Email) == User.Identity.Name)
                {
                    Name = item.Name;
                    Position = item.Position;
                }
            }
            UserModel = await _context.UserModel.ToListAsync();
            return Page();
        }

        [BindProperty]
        public FreightBill FreightBill { get; set; }
        

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FreightBill.Add(FreightBill);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
