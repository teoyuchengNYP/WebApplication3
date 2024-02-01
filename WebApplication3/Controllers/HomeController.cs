using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AceJobAgency.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public HomeController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            // Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                // Store user information in the session upon successful login
                HttpContext.Session.SetString("UserId", User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value);
            }
            else
            {
                // Redirect to login page if the user is not authenticated
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        public IActionResult Logout()
        {
            // Clear the session and sign out the user
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
