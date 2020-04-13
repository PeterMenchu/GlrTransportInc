using System.Collections.Generic;
using GlrTransportInc.Controllers;
using Microsoft.AspNetCore.Mvc;
using GlrTransportInc.Models;
using System.Data;
using System.Data.SqlClient;
namespace GlrTransportInc.Pages.Profile
{
    public class EmployeeProcessor : Controller
    {
        public static int addName(string email, string name)
        {
            UserModel data = new UserModel
            {
                Email = email,
                Name = name
            };
            string sql = @"UPDATE dbo.AspNetUsers 
                            SET Name = @name 
                            WHERE UserName=@Email;";
            return SqlDataController.SaveData(sql, data);
        }
        // Next is some code for user directory
        // List<UserModel>
        public static List<UserModel> LoadUser()
        {
            string sql = @"SELECT *
                            FROM dbo.AspNetUsers
                            WHERE Email = email;";
            return SqlDataController.LoadData<UserModel>(sql);
        }
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}