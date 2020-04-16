using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GlrTransportInc.Data;
using GlrTransportInc.Models;

namespace GlrTransportInc.Pages.Directory
{
    public class DirectoryModel : PageModel
    {
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;

        public DirectoryModel(GlrTransportInc.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<UserModel> UserModel { get; set; }

        public async Task OnGetAsync()
        {
            UserModel = await _context.UserModel.ToListAsync();
        }
    }
}

