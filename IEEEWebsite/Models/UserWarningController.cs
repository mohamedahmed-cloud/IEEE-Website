using IEEEWebsite.Context;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IEEEWebsite.Models
{
    public class UserWarningController : Controller
    {
        IEEEContext IEEEContext = new IEEEContext();
        public IActionResult Index()
        {
            var claims = User.Claims;
            var Id = int.Parse(claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value);
            var user = IEEEContext.Users.FirstOrDefault(u => u.Id == Id);
            var fullName = user.FName + " " + user.LName;
            var Warning = IEEEContext.Warnings.Where(warn => warn.UserName == fullName).ToList();

            return View(Warning);
        }
       
    }
}
