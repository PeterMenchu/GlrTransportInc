using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GlrTransportInc.Data;
using GlrTransportInc.Models;
using GlrTransportInc.Controllers;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//****Code Not in Use****

//Home Controller for MVC Application using Full Calendar
namespace GlrTransportInc.Pages.Calendar
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Calendar()
        {
            List<Models.FreightBill> list = new List<Models.FreightBill>();

            //DataTable dt = new DataTable();

            return Calendar();
        }

        
    }
}
