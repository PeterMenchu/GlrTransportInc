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
    public class IndexModel2 : PageModel
    {
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;

        public IndexModel2(GlrTransportInc.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Announcement> Announcement { get;set; }
        public IList<UserModel> Users { get; set; }
        public async Task OnGetAsync()
        {
            Announcement = await _context.Announcement.OrderByDescending(a => a.ID).ToListAsync();
            Users = await _context.UserModel.ToListAsync();
        }
    }
}
