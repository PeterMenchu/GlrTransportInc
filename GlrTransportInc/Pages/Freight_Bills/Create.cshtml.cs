﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GlrTransportInc.Data;
using GlrTransportInc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace GlrTransportInc.Pages.Freight_Bills
{
    public class CreateModel : PageModel
    {
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;
        private IWebHostEnvironment _environment;

        public CreateModel(GlrTransportInc.Data.ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IList<UserModel> UserModel { get; set; }
        public static string Name;
        public static string Position;
        [BindProperty]
        public IFormFile Upload { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            UserModel = await _context.UserModel.ToListAsync();
            foreach (var item in UserModel)
            {
                if ((item.Email) == User.Identity.Name)
                {
                    Name = item.Name;
                    Position = item.Position;
                }
            }
            UserModel = await _context.UserModel.ToListAsync();
            return Page();
        }

        [BindProperty]
        public FreightBill FreightBill { get; set; }
        

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FreightBill.Add(FreightBill);
            await _context.SaveChangesAsync();
            if (Upload != null)
            {
                FreightBill.Permit = $"/Permits/{FreightBill.ID}{Path.GetExtension(Upload.FileName)}";

                var file = Path.Combine(_environment.ContentRootPath, "wwwroot/permits", $"{FreightBill.ID}{Path.GetExtension(Upload.FileName)}");
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await Upload.CopyToAsync(fileStream);
                }

                _context.Attach(FreightBill).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
