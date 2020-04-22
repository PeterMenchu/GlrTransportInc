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
using GlrTransportInc.Models;
using GlrTransportInc.Data;

namespace GlrTransportInc.Pages.Profile
{
    public class EditProfileModel : PageModel
    {
        // these are used to load data relevant to this page
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        // setter value for 
        private string _name;
        
        public EditProfileModel(
            UserManager<UserModel> userManager,
            SignInManager<UserModel> signInManager
            )
            //RoleManager<UserModel> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        // status message declaration
        [TempData]
        public string StatusMessage { get; set; }
        // declare instance of input model for storing input data, defined below
        [BindProperty]
        public InputModel Input { get; set; }
        // InputModel definition, defines the phone# and name variables that store user input which also 
        // display current values as placeholders
        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number:")]
            public string PhoneNumber { get; set; }
            public string Fullname { get; set; }
        }
        // function for setting current values for display
        private async Task LoadAsync(UserModel user)
        {
            // handles setting current values
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            // sets placeholder values
            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Fullname = _name
            };
        }
        // function for loading user table data
        public async Task<IActionResult> OnGetAsync()
        {
            // load user data context 
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            // to avoid problems with static/non-static variables, using Name as setter for Fullname/input variable
            _name = user.Name;
            // calls function that handles setting the input/placeholders
            await LoadAsync(user);
            return Page();
        }
        // once save is clicked perform Post
        public async Task<IActionResult> OnPostAsync()
        {
            // ensure user info is current via reloading data
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
            // check input with current data, first for phonenumber
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
            // then check for edited name
            if (Input.Fullname != user.Name && Input.Fullname != null) 
            {
                int set = addName(User.Identity.Name, Input.Fullname, user.Name);
            }
            // finish update
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}