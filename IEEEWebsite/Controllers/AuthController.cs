using IEEEWebsite.Context;
using IEEEWebsite.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace IEEEWebsite.Controllers
{
    public class AuthController : Controller
    {
        IEEEContext IEEEContext = new IEEEContext();
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> CheckLogin(Login login)
        {
            var user = IEEEContext.Users.FirstOrDefault(u =>( u.Password == login.Password && 
                                                        u.Email == login.Email));
            if (user == null)
            {
                ViewBag.LoggedError = "Uncorrect Email or Password";
                return View("Login");
            }
            /*First Step*/
            var ClaimIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            
            /*ClaimIdentity.AddClaim(new Claim(ClaimTypes, $"{user.TotalScore}"));*/

            /*Authization*/
            ClaimIdentity.AddClaim(new Claim(ClaimTypes.Sid, $"{user.Id}"));
            ClaimIdentity.AddClaim(new Claim(ClaimTypes.Role, $"{user.Role}"));
            /*Second Step*/
            var claimPrincipal = new ClaimsPrincipal(ClaimIdentity);
            /*Thrid Step*/

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties()
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddDays(12),
            });


            return RedirectToAction("Index", "Home");
        
        }

        /*Not Test Yet*/
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
