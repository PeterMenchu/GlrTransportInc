using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GlrTransportInc.Data;
using GlrTransportInc.Models;

namespace GlrTransportInc.Pages.Freight_Bills
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<FreightBill> FreightBill { get;set; }
        public IList<UserModel> Users { get; set; }
        public string Current;
        public static string Name;
        public static string Position;
        // Search function is below, this declaration will be used with ALL directory pages
        
        public async Task OnGetAsync(string input)
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
            //FreightBill = await _context.FreightBill.ToListAsync();
            IQueryable<FreightBill> indexBills = from index in _context.FreightBill
                select index;
            if (!String.IsNullOrEmpty(input))
            {
                Current = input;
                indexBills = indexBills.Where(index => index.Customer.Contains(input)
                                                   || index.Comments.Contains(input)
                                                   || index.FreightBillNumber.Contains(input)
                                                   || index.FromName.Contains(input)
                                                   || index.ToName.Contains(input)
                                                   || index.Labor1.Contains(input)
                                                   || index.BranchAndDescription.Contains(input)
                                                   || index.PoNumber.Contains(input)
                                                   || index.Unit.Contains(input)
                                                   || index.DocJob.Contains(input)
                                                   || index.Labor2.Contains(input)
                                                   || index.Labor3.Contains(input)
                                                   || index.Labor4.Contains(input)
                                                   || index.Labor5.Contains(input)
                                                   || index.Labor6.Contains(input)
                                                   || index.Labor7.Contains(input)
                                                   || index.Labor8.Contains(input)
                                                   || index.Labor9.Contains(input)
                                                   || index.TruckNumber.Contains(input)
                                                   || index.Driver.Contains(input)
                                                   || index.ReceivedBy.Contains(input)
                                                   || index.SiteName.Contains(input)
                                                   || index.SitePhoneNumber.Contains(input)
                                                   || index.EmailAddress.Contains(input)
                                                   || index.ToLocation.Contains(input)
                                                   || index.FromLocation.Contains(input)); 
            }
            FreightBill = await indexBills.AsNoTracking().ToListAsync();
        }
    }
}
