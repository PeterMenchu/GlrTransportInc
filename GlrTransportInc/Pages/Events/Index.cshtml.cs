using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GlrTransportInc.Data;
using GlrTransportInc.Models;

namespace GlrTransportInc.Pages.Events
{
    public class EventsModel : PageModel
    {
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;

        public EventsModel(GlrTransportInc.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Announcement> Announcement { get;set; }
        public IList<UserModel> Users { get; set; }
        public static string Name;
        public static string Position;
        public async Task OnGetAsync()
        {
            Announcement = await _context.Announcement.OrderByDescending(a => a.ID).ToListAsync();
            Users = await _context.UserModel.ToListAsync();
            foreach (var item in Users)
            {
                if ((item.Email) == User.Identity.Name)
                {
                    Name = item.Name;
                    Position = item.Position;
                }
            }
        }
    }
}