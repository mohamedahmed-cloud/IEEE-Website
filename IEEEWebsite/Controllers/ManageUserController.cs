using IEEEWebsite.Context;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IEEEWebsite.Controllers
{
    public class ManageUserController : Controller
    {
        IEEEContext IEEEContext = new IEEEContext();
        public IActionResult Index()
        {
            
            var claims = User.Claims;
            var Id = int.Parse(claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value);
            Console.WriteLine(Id);
            var currUser = IEEEContext.Users.FirstOrDefault(u => u.Id == Id);
            var category = currUser?.CategoryName;
            Console.WriteLine(category);

            var tasks = IEEEContext.Tasks.Where(u => u.CategoryName == category).ToList();
            tasks.Reverse();
            return View(tasks);
        }

    }
}
