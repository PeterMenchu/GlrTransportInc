using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GlrTransportInc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace GlrTransportInc.Controllers
{
    public class MainDataController : Controller
    {
        private readonly GlrTransportInc.Data.ApplicationDbContext _context;
        private IWebHostEnvironment _environment;

        public MainDataController(GlrTransportInc.Data.ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public static IList<FreightBill> AllBills { get; set; }
        public IList<UserModel> Users { get; set; }
        
        public async Task GetUsers()
        {
            Users = await _context.UserModel.ToListAsync();
        }
        
        public async Task GetBills()
        {
            AllBills = await _context.FreightBill.ToListAsync();
        }
        
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}