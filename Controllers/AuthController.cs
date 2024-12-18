using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UM_System.Controllers
{
    public class AuthController : Controller
    {


        /* public class AuthController : Controller*/

        // Mock user database
        private static readonly List<(string Username, string Password, string Role)> Users = new()
        {
            ("admin", "bipl1234", "Admin"),
            ("superadmin", "superadmin123", "Super Admin"),
            ("user", "user123", "User")
        };

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View("Login");
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != default)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role) // Dynamically assign role
                };
                /* if (username == "admin" && password == "bipl1234")
                 {
                     var claims = new List<Claim>
                     {
                         new Claim(ClaimTypes.Name, username),
                         new Claim(ClaimTypes.Role, "Admin") 
                     };*/

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true // Keep the user logged in
                };

                await HttpContext.SignInAsync(
                   CookieAuthenticationDefaults.AuthenticationScheme,
                   new ClaimsPrincipal(claimsIdentity),
                   new AuthenticationProperties { IsPersistent = true }
                   );
                /* return RedirectToAction("Index", "Home");*/

                   // Redirect user based on their role
                if (user.Role == "Admin")
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (user.Role == "User")
                {
                    return RedirectToAction("Index", "Home");
                }
                /*else if (user.Role == "User")
                {
                    return RedirectToAction("Index", "Users");
                }*/


            }


            ViewBag.Error = "Invalid credentials!";
            return View();
        }

        // Logout Action
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }

        /* [Authorize]
         public IActionResult RedirectToRolePage()
         {
             if (User.IsInRole("Admin"))
             {
                 return RedirectToAction("AdminDashboard", "Home");
             }
             else if (User.IsInRole("Super Admin"))
             {
                 return RedirectToAction("SuperAdminDashboard", "Home");
             }
             else if (User.IsInRole("User"))
             {
                 return RedirectToAction("Index", "User"); // Correct redirection for 'User' role
             }

             return RedirectToAction("AccessDenied");
         }*/


        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }
    }
}

