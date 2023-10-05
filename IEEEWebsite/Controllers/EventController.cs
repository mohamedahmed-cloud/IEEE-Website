using IEEEWebsite.Context;
using IEEEWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace IEEEWebsite.Controllers
{
    public class EventController : Controller
    {
        private readonly IWebHostEnvironment _env;
        IEEEContext IEEEContext = new IEEEContext();
        public EventController(IWebHostEnvironment newenv)
        {
            _env = newenv;

        }

        public IActionResult ViewEvents()
        {
            var Events = IEEEContext.Events.ToList();
            return View(Events);
        }
        /*Add Event*/
        public IActionResult AddEvent()
        {
            return View();
        }
        public async Task<IActionResult> SaveEvent(Event newEvent)
        {
            if (newEvent.formFile != null)
            {
                string folder = "DatabaseImage/events/";
                folder += Guid.NewGuid().ToString() + "_" + newEvent.formFile.FileName;
                string serverFolder = Path.Combine(_env.WebRootPath, folder);
                newEvent.ImagePath = folder;
                using (var fileStream = new FileStream(serverFolder, FileMode.Create))
                {
                    await newEvent.formFile.CopyToAsync(fileStream);
                }
                IEEEContext.Events.Add(newEvent);
                IEEEContext.SaveChanges();
            }

            return RedirectToAction("ViewEvents");

        }


        /* Delete Events */
        public IActionResult DeleteEvent(int id)
        {
            var events = IEEEContext.Events.FirstOrDefault(currEvent => currEvent.Id == id);
            /*Delet Image From Database*/
            var imagePathToDelete = Path.Combine(_env.WebRootPath, events.ImagePath);
        
            if (events != null)
            {
                IEEEContext.Events.Remove(events);
                IEEEContext.SaveChanges();
            }
            /*Complet Delete Operation*/
            
            if (System.IO.File.Exists(imagePathToDelete))
            {
                try
                {
                    System.IO.File.Delete(imagePathToDelete);
                }
                catch (IOException)
                {
                    Console.WriteLine("Can't Delete");
                }
            }



            return RedirectToAction("ViewEvents");
        }

        /*Update Events*/
        public IActionResult UpdateEvent(int id)
        {
            var post = IEEEContext.Events.FirstOrDefault(currEvent => id == currEvent.Id);
            if (post != null)
            {
                return View("AddEvent", post);
            }
            return RedirectToAction("ViewEvents");
        }
        public async Task<IActionResult> SaveUpdateEvent(Event newEvent)
        {
            var currEvent = IEEEContext.Events.FirstOrDefault(currEvent => currEvent.Id == newEvent.Id);

            /*Delete Events Image When Make Update*/
            var imagePathToDelete = Path.Combine(_env.WebRootPath, currEvent.ImagePath);
          

            if (newEvent.formFile != null)
            {
                string folder = "DatabaseImage/events/";
                folder += Guid.NewGuid().ToString() + "_" + newEvent.formFile.FileName;
                string serverFolder = Path.Combine(_env.WebRootPath, folder);
                newEvent.ImagePath = folder;
                await newEvent.formFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                currEvent.ImagePath = folder;
            }
            currEvent.Name = newEvent.Name;
            currEvent.Description = newEvent.Description;

            IEEEContext.SaveChanges();


            /*Complete Delete Operation*/
            if (System.IO.File.Exists(imagePathToDelete))
            {
                try
                {
                    System.IO.File.Delete(imagePathToDelete);
                }
                catch (IOException)
                {
                    Console.WriteLine("Can't Delete");
                }
            }
            return RedirectToAction("ViewEvents");

        }




    }
}
