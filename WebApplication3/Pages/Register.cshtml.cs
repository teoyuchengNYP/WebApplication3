using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AceJobAgency.ViewModels;

namespace AceJobAgency.Pages
{
    public class RegisterModel : PageModel
    {

        private UserManager<IdentityUser> userManager { get; }
        private SignInManager<IdentityUser> signInManager { get; }

        [BindProperty]
        public Register RModel { get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }



        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // Check if the email address is already in use
                var existingUser = await userManager.FindByEmailAsync(RModel.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Email address is already in use.");
                    return Page();
                }

                var user = new IdentityUser()
                {
                    UserName = RModel.Email,
                    Email = RModel.Email
                };
                var result = await userManager.CreateAsync(user, RModel.Password);

                // Hash the password before storing it
                //var hashedPassword = userManager.PasswordHasher.HashPassword(user, RModel.Password);
                //user.PasswordHash = hashedPassword;

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    //Redirect to home page
                    return RedirectToPage("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return Page();
        }







    }
}
