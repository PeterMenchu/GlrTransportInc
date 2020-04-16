using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GlrTransportInc.Models;
using Microsoft.EntityFrameworkCore;

namespace GlrTransportInc.Pages.Manage_Users
{
    public class IndexModel : PageModel
    {
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;

        public IndexModel(GlrTransportInc.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<UserModel> UserModel { get; set; }
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
            UserModel = await _context.UserModel.OrderBy(a => a.Name).ToListAsync();
        }
    }
}
