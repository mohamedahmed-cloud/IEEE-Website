using IEEEWebsite.Context;
using Microsoft.AspNetCore.Mvc;

namespace IEEEWebsite.Models
{
    public class UserEventController : Controller
    {
        IEEEContext IEEEContext = new IEEEContext();
        public IActionResult Index()
        {
            var events = IEEEContext.Events.ToList();
            events.Reverse();
            return View(events);
        }
    }
}
