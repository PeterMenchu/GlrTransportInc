using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GlrTransportInc.Data;
using GlrTransportInc.Models;

namespace GlrTransportInc
{
    public class DetailsModel : PageModel
    {
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;

        public DetailsModel(GlrTransportInc.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public FreightBill FreightBill { get; set; }
        public IList<UserModel> Users { get; set; }
        public static string Name;
        public static string Position;
        // for signature .png file
        public static string filename;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Users = await _context.UserModel.ToListAsync();
            // set signature image file's name
           
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
            //filename = FreightBill.ID.ToString();
            //filename += ".png";
            filename = FreightBill.ReceivedBy;
            return Page();
        }
    }
}
