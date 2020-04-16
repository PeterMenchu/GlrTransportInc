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
    public class IndexModel : PageModel
    {
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;

        public IndexModel(GlrTransportInc.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<FreightBill> FreightBill { get;set; }
        public IList<UserModel> Users { get; set; }
        public static string Name;
        public static string Position;
        public async Task OnGetAsync()
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
            FreightBill = await _context.FreightBill.ToListAsync();
        }
    }
}
