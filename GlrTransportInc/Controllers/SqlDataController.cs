using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace GlrTransportInc.Controllers
{
    public class SqlDataController : Controller
    {
        public static string GetConnectionString()
        {
            return "Server=tcp:glr.database.windows.net,1433;Initial Catalog=glr;Persist Security Info=False;User ID=glrAdmin;Password=HolaHola2000;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection conn = new SqlConnection(GetConnectionString())) { 
                return conn.Query<T>(sql).ToList();
            }
        }
        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection conn = new SqlConnection(GetConnectionString()))
            {
                return conn.Execute(sql, data);// should return 1 on proper execution
            }
        }
        /*
        // GET
        public IActionResult Index()
        {
            return View();
        }
        */
    }
}