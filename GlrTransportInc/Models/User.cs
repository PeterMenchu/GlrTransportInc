using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GlrTransportInc.Models
{
    public class UserModel : IdentityUser
    {
        public string EmployeeId { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
    }

    public class MyUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<UserModel>
    {
        public MyUserClaimsPrincipalFactory(
            UserManager<UserModel> userManager,
            IOptions<IdentityOptions> optionsAccessor)
                : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(UserModel user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("Name", user.Name));
            identity.AddClaim(new Claim("Position", user.Position));
            return identity;
        }
    }
}