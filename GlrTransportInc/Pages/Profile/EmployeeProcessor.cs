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
                EmailAddress = email,
                FullName = name
            };
            string sql = @"INSERT INTO dbo.AspNetUsers (Fullname) 
                            VALUES (@FullName) 
                            WHERE UserName=@EmailAddress;";
            return SqlDataController.SaveData(sql, data);
        }
        // Next is some code for user directory
        public static List<UserModel> LoadEmployees()
        {
            string sql = @"SELECT UserName, Position
                            FROM dbo.AspNetUsers;";
            return SqlDataController.LoadData<UserModel>(sql);
        }
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}