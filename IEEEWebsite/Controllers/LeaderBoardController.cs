using IEEEWebsite.Context;
using Microsoft.AspNetCore.Mvc;

namespace IEEEWebsite.Controllers
{
    public class LeaderBoardController : Controller
    {
        IEEEContext IEEEContext = new IEEEContext();
        public IActionResult Index()
        {
            var user = IEEEContext.Users;
            var finalUser = user.GroupBy(user => user.CategoryName)
            .Select(group => group.OrderByDescending(user => user.TotalScore).First());

            var fuser = finalUser.ToList();

            return View(fuser);
        }
    }
}
