using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Configuration;


namespace GlrTransportInc.Pages
{
    public class LoginModel : PageModel
    {
        protected void OnPageLoad(object sender, EventArgs e)
        {
           
        }
        protected void LoginButtonClicked(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"CONNECTIONSTRING");
            conn.Open();
            string sqlEmailCheck = "This will be the query";
        }
    }
}
