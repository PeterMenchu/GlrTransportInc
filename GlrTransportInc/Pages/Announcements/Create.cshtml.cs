using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GlrTransportInc.Data;
using GlrTransportInc.Models;

namespace GlrTransportInc
{
    public class CreateModel2 : PageModel
    {
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;

        public CreateModel2(GlrTransportInc.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Announcement Announcement { get; set; }
        /*get
        {
            return Announcement;
        }
        set
        {
            Announcement.DatePosted = DateTime.Now;
            Announcement.Author = User.FindFirst("Name").Value;
        } */

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var post = new Announcement { Title = Announcement.Title, Post = Announcement.Post, Author = User.FindFirst("Name").Value, DatePosted = DateTime.Now };
            _context.Announcement.Add(post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
