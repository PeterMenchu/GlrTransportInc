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
using Microsoft.EntityFrameworkCore;

namespace GlrTransportInc.Pages.Profile
{
    public class EditProfileModel : PageModel
    {
        // these are used to load data relevant to this page
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly ApplicationDbContext _context;
        public IList<Announcement> AnnouncementCheck { get;set; }
        public static IList<FreightBill> FreightBillCheck { get;set; }
        // setter value for name
        private string _name;
        // flag for checking if user has bills or announcements, checked for editing the name
        private int _billFlag;
        private int _annFlag;
        
        public EditProfileModel(
            UserManager<UserModel> userManager,
            SignInManager<UserModel> signInManager,
            Data.ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
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
            [StringLength(16, MinimumLength = 10)]
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
                FreightBillCheck = await _context.FreightBill.ToListAsync();
                AnnouncementCheck = await _context.Announcement.ToListAsync();
                var curr_user = await _userManager.GetUserAsync(User);
                _name = curr_user.Name;
                if (curr_user == null)
                {
                    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
                }
                foreach (var bill in FreightBillCheck)
                {
                    if (bill.Driver == _name)
                    {
                        _billFlag = 1;
                    }
                }
                foreach (var post in AnnouncementCheck)
                {
                    if (post.Author == _name)
                    {
                        _annFlag = 1;
                    }
                }
                int set = addName(User.Identity.Name, Input.Fullname, user.Name, _billFlag, _annFlag);
            }
            // finish update
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}