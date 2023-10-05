using IEEEWebsite.Context;
using IEEEWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace IEEEWebsite.Controllers
{

    public class PostController : Controller
    {
        private readonly IWebHostEnvironment _env;
        IEEEContext IEEEContext = new IEEEContext();
        public PostController(IWebHostEnvironment newenv)
        {
            _env = newenv;
           
        }
        public IActionResult ViewPost()
        {
            var post = IEEEContext.Posts.ToList();
            post.Reverse();
            return View(post);
        }
        /*Add Post*/
        public IActionResult AddPost()
        {
            return View();
        }
        
        public async Task<IActionResult> SavePost(Post newPost)
        {
            if (newPost.formFile != null)
            {
                string folder = "DatabaseImage/posts/";
                folder += Guid.NewGuid().ToString() + "_" + newPost.formFile.FileName;
                string serverFolder = Path.Combine(_env.WebRootPath, folder);

                using (var fileStream = new FileStream(serverFolder, FileMode.Create))
                {
                    await newPost.formFile.CopyToAsync(fileStream);
                }
                newPost.ImagePath = folder;
              
                

                IEEEContext.Posts.Add(newPost);
                IEEEContext.SaveChanges();
            }


            return RedirectToAction("ViewPost"); 
        }
        /*Delete Post*/
        public IActionResult DeletePost(int id)
        {
            var post = IEEEContext.Posts.FirstOrDefault(currPost => currPost.Id == id);
            /*Delete Events Image When Make Delete*/
            var imagePathToDelete = "";

            if (post != null)
            {
                IEEEContext.Posts.Remove(post);
                IEEEContext.SaveChanges();
                imagePathToDelete = Path.Combine(_env.WebRootPath, post.ImagePath);

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




            return RedirectToAction("ViewPost");
        }

        /*Update Post*/
        public IActionResult UpdatePost(int id)
        {
            var post = IEEEContext.Posts.FirstOrDefault(currPost => id == currPost.Id);
            if (post != null)
            {
                return View("AddPost", post);
            }
            return RedirectToAction("ViewPost");
        }
        public async Task<IActionResult> SaveUpdatePost(Post newPost)
        {
            var currPost = IEEEContext.Posts.FirstOrDefault(currPost => currPost.Id == newPost.Id);


            /*Delete Events Image When Update*/
            var imagePathToDelete = Path.Combine(_env.WebRootPath, currPost.ImagePath);
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


            if (newPost.formFile != null)
            {
                string folder = "DatabaseImage/posts/";
                folder += Guid.NewGuid().ToString() + "_" + newPost.formFile.FileName;
                string serverFolder = Path.Combine(_env.WebRootPath, folder);
                newPost.ImagePath = folder;
                await newPost.formFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                currPost.ImagePath = folder;
            }
            currPost.Name = newPost.Name;
            currPost.Description = newPost.Description;

            IEEEContext.SaveChanges();


            
            return RedirectToAction("ViewPost");

        }


       
    }
}
