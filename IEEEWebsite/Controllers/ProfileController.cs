using IEEEWebsite.Context;
using IEEEWebsite.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IEEEWebsite.Controllers
{
    public class ProfileController : Controller
    {
        IEEEContext IEEEContext = new IEEEContext();
        public IActionResult Index()
        {
            var claims = User.Claims;
            var Id = int.Parse(claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value);
            var usr = IEEEContext.Users.FirstOrDefault(u => u.Id == Id);
            return View(usr);
        }

        public IActionResult EditProfile(int Id)
        {
            var usr = IEEEContext.Users.FirstOrDefault(x => x.Id == Id);
            Console.WriteLine(Id);

            return View(usr);
        }
        public IActionResult SaveChanging(User usr)
        {
            var selectedUsr = IEEEContext.Users.FirstOrDefault(curusr => curusr.Id == usr.Id);
            selectedUsr.FName = usr.FName;
            selectedUsr.LName = usr.LName;
            selectedUsr.Email = usr.Email;
            selectedUsr.Password = usr.Password;
            selectedUsr.TotalScore = usr.TotalScore;
            /*Update User*/
         

            IEEEContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
