using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using GlrTransportInc.Models;
using Microsoft.EntityFrameworkCore;

namespace GlrTransportInc.Pages.Profile
{
    public class MyProfileModel : PageModel
    {
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;

        public MyProfileModel(GlrTransportInc.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<UserModel> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _context.UserModel.ToListAsync();
        }
    }
}
