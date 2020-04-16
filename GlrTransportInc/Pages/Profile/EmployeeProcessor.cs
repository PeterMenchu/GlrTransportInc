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
        public static int addName(string email, string name, string currentName)
        {
            UserModel data = new UserModel
            {
                Email = email,
                Name = name
            };

            Announcement data2 = new Announcement
            {
                Author = name,
                Post = currentName
            };

            FreightBill data3 = new FreightBill
            {
                Driver = name,
                Comments =  currentName
            };

            string sql2 = @"UPDATE dbo.Announcement
                          SET Author = @Author
                          WHERE Author=@Post;";
            string sql3 = @"UPDATE dbo.FreightBill
                            SET Driver = @Driver
                            WHERE Driver=@Comments;";
            string sql = @"UPDATE dbo.AspNetUsers 
                            SET Name = @name 
                            WHERE UserName=@Email;";
            SqlDataController.SaveData(sql2, data2);
            SqlDataController.SaveData(sql3, data3);
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