using IEEEWebsite.Context;
using IEEEWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IEEEWebsite.Controllers
{
    public class HomeController : Controller
    {
        IEEEContext IEEEContext = new IEEEContext();
        public IActionResult Index()
        {
            var posts = IEEEContext.Posts.ToList();
            posts.Reverse();
            var NewPost = posts.Take(3).ToList();

              
            return View(NewPost);
        }
    }

}