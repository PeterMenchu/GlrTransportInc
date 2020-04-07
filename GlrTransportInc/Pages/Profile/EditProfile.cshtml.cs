using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GlrTransportInc.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Differencing;
using static GlrTransportInc.Pages.Profile.EmployeeProcessor;
using System.Collections.Generic;

namespace GlrTransportInc.Pages.Profile
{
    public class EditProfileModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly RoleManager<IdentityUser> _roleManager;
        public EditProfileModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
            //RoleManager<IdentityUser> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_roleManager = roleManager;
        }

        public static string Username { get; set; }
        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            public string Fullname { get; set; }
            
            
            
        }

        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            //var position = await _roleManager.GetRoleNameAsync(user);
            Username = userName;
            //UserPosition = position;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber
                
            };
            
            
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }
            
            int set = addName(EditProfileModel.Username, Input.Fullname);
            
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}