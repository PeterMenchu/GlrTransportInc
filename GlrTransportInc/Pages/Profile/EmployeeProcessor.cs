using System.Collections.Generic;
using GlrTransportInc.Controllers;
using Microsoft.AspNetCore.Mvc;
using GlrTransportInc.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace GlrTransportInc.Pages.Profile
{
    public class EmployeeProcessor : Controller
    {
        public static int updateNames(string name, string currentName, int flag, int flag2, int flag3)
        {
            
            if (flag == 1)
            {
                FreightBill data3 = new FreightBill
                {
                    Driver = name,
                    Comments = currentName
                };
                
                string sql3 = @"UPDATE dbo.FreightBill
                            SET Driver = @Driver
                            WHERE Driver=@Comments;";
                
                return SqlDataController.SaveData(sql3, data3);
            }
            if (flag2 == 1)
            {
                Announcement data2 = new Announcement
                {
                    Author = name,
                    Post = currentName
                };
                

                string sql2 = @"UPDATE dbo.Announcement
                          SET Author = @Author
                          WHERE Author=@Post;";
                
                return SqlDataController.SaveData(sql2, data2);
            }
            if (flag3 == 1)
            {
                Timesheet data4 = new Timesheet
                {
                    Email = name,
                    Comments1 = currentName
                };

                string sql4 = @"UPDATE dbo.TimeSheet
                                SET Email = @Email
                                WHERE EMAIL=@Comments1;";
                return SqlDataController.SaveData(sql4, data4);
            }

            return 0;
        }
        public static int addName(string email, string name, string currentName, int flag, int flag2, int flag3)
        {
            
            UserModel data = new UserModel
            {
                Email = email,
                Name = name
            };
            if (flag == 1)
            {
                FreightBill data3 = new FreightBill
                {
                    Driver = name,
                    Comments = currentName
                };
                
                string sql3 = @"UPDATE dbo.FreightBill
                            SET Driver = @Driver
                            WHERE Driver=@Comments;";
                
                SqlDataController.SaveData(sql3, data3);
            }
            if (flag2 == 1)
            {
                Announcement data2 = new Announcement
                {
                    Author = name,
                    Post = currentName
                };
                

                string sql2 = @"UPDATE dbo.Announcement
                          SET Author = @Author
                          WHERE Author=@Post;";
                
                SqlDataController.SaveData(sql2, data2);
            }
            if (flag3 ==1)
            {
                Timesheet data4 = new Timesheet
                {
                    Email = name,
                    Comments1 = currentName
                };

                string sql4 = @"UPDATE dbo.TimeSheet
                                SET Email = @Email
                                WHERE EMAIL=@Comments1;";

                SqlDataController.SaveData(sql4, data4);
            }

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