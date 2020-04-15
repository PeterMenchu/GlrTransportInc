using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlrTransportInc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;


namespace GlrTransportInc.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Data.ApplicationDbContext _context;
        public IndexModel(Data.ApplicationDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IList<Announcement> Announcement { get;set; }
        public async Task OnGetAsync()
        {
            Announcement = await _context.Announcement.OrderByDescending(a => a.ID).ToListAsync();
        }
    }
}
