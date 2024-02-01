//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AceJobAgency.ViewModels;
using IdentityUser = Microsoft.AspNetCore.Identity.IdentityUser;

namespace AceJobAgency.Pages
{
    public class LoginModel : PageModel
    {
		[BindProperty]
		public Login LModel { get; set; }

		private readonly SignInManager<IdentityUser> signInManager;
		public LoginModel(SignInManager<IdentityUser> signInManager)
		{
			this.signInManager = signInManager;
		}
		public void OnGet()
        {
        }

		public async Task<IActionResult> OnPostAsync()
		{
			if (ModelState.IsValid)
			{
				var identityResult = await signInManager.PasswordSignInAsync(LModel.Email, LModel.Password,
			   LModel.RememberMe, false);
				if (identityResult.Succeeded)
				{
					return RedirectToPage("Index", "Home");
				}
				//ModelState.AddModelError("", "Username or Password incorrect");
			}
			else
			{
                ModelState.AddModelError("", "Username or Password incorrect");
            }

			return Page();
		}
	}
}
