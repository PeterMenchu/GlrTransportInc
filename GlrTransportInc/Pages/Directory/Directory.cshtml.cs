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
        // note, this is used for all directory pages, so all of them will be sorted
        public async Task OnGetAsync()
        {
            UserModel = await _context.UserModel.ToListAsync();
            // sort by first name
            IQueryable<UserModel> sortedUsers = from toSort in _context.UserModel
                select toSort;
            sortedUsers = sortedUsers.OrderBy(toSort => toSort.Name);
            // set sorted version of model
            UserModel = await sortedUsers.AsNoTracking().ToListAsync();
        }
    }
}

