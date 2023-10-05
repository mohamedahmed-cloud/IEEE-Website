using IEEEWebsite.Context;
using IEEEWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace IEEEWebsite.Controllers
{
    public class WarningController : Controller
    {
        IEEEContext IEEEContext = new IEEEContext();
        public IActionResult ViewWarning()
        {
            var Warning = IEEEContext.Warnings.ToList();
            return View(Warning);
        }

        public IActionResult AddWarning()
        {
            var users = IEEEContext.Users.ToList();
            ViewBag.warning = users;
            return View();
        }
        public IActionResult SaveWarning(Warning newWarning)
        {
            var warning = IEEEContext.Warnings;
            warning.Add(newWarning);
            IEEEContext.SaveChanges();
            return RedirectToAction("ViewWarning");
        }

        /*Delete Warning*/
        public IActionResult DeleteWarning(int id)
        {
            var warnings = IEEEContext.Warnings.FirstOrDefault(x => x.Id == id);
            if (warnings != null)
            {
                IEEEContext.Warnings.Remove(warnings);
                IEEEContext.SaveChanges();
            }
            return RedirectToAction("ViewWarning");
        }
        public IActionResult UpdateWarning(int Id)
        {
            var currWarning = IEEEContext.Warnings.FirstOrDefault(x => x.Id == Id);
            var users = IEEEContext.Users.ToList();
            ViewBag.warning = users;
            return View("AddWarning", currWarning);

        }
        public IActionResult SaveUpdateWarning(Warning newWanring)
        {
            var currWarning = IEEEContext.Warnings.FirstOrDefault(x => x.Id == newWanring.Id);
            if (currWarning != null)
            {
                currWarning.WarningName = newWanring.WarningName;
                currWarning.WarningReason = newWanring.WarningReason;
                currWarning.UserName = newWanring.UserName;
                IEEEContext.SaveChanges();
            }
            return RedirectToAction("ViewWarning");
        }
    }
}
