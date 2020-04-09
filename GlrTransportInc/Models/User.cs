using Microsoft.AspNetCore.Identity;
using System;


namespace GlrTransportInc.Models
{
    public class UserModel : IdentityUser
    {
        public string EmployeeId { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
    }
}