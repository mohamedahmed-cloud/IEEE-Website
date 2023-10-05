using IEEEWebsite.Context;
using IEEEWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace IEEEWebsite.Controllers
{
    public class ManageController : Controller
    {

        IEEEContext IEEEContext = new IEEEContext();
        public IActionResult Index()
        {
            return View();
        }
        /*Handle All Thing Related To User In System*/
        #region user
            /*View All User in System*/
            public IActionResult HandleUser()
            {
                var user = IEEEContext.Users.ToList();
            user.Reverse();
                return View(user);
            }
            /*Add New User*/

            public IActionResult AddNewUser()
            {

                ViewBag.AllCategory = IEEEContext.Categories.ToList();
                return View();
            }
            public IActionResult SaveNewUser(User usr)
            {
                var users = IEEEContext.Users;
                usr.SignInDate = DateTime.Now;
                users.Add(usr);
                IEEEContext.SaveChanges();
                return RedirectToAction("HandleUser");
            }
            /*Delete User*/
            public IActionResult DeleteUser(int id)
            {
                var usr = IEEEContext.Users.FirstOrDefault(x => x.Id == id);
                IEEEContext.Remove(usr);
                IEEEContext.SaveChanges();
                return RedirectToAction("HandleUser");
            }

            /*Update User*/
            public IActionResult UpdateUser(int id)
        {
            ViewBag.AllCategory = IEEEContext.Categories.ToList();
            var usr = IEEEContext.Users.FirstOrDefault(user => user.Id == id);
            
            return View("AddNewUser", usr);
        }
        public IActionResult SaveUpdatedUser(User usr)
        {
            var selectedUsr = IEEEContext.Users.FirstOrDefault(curusr => curusr.Id == usr.Id);
            selectedUsr.FName = usr.FName;
            selectedUsr.LName = usr.LName;
            selectedUsr.Email = usr.Email;
            selectedUsr.Password = usr.Password;
            selectedUsr.Role = usr.Role;
            selectedUsr.CategoryName = usr.CategoryName;
            selectedUsr.TotalScore = usr.TotalScore;

            IEEEContext.SaveChanges();



            return RedirectToAction("HandleUser");
        }
        #endregion


        /*Add New Category*/
        #region Category
            /*Complete*/
            public IActionResult ViewCategory()
            {
                var category = IEEEContext.Categories.ToList();
            category.Reverse();
                return View(category);
            }
            /*Complete*/
            public IActionResult AddCategory()
            {
                return View();
            }
            /*Complete*/
            public IActionResult SaveCategory(Category newCategory)
            {
                var category = IEEEContext.Categories;
                category.Add(newCategory);
                IEEEContext.SaveChanges();
                return RedirectToAction("ViewCategory");
            }

            public IActionResult DeleteCategory(int id)
            {
                var category = IEEEContext.Categories;
                var currCategory = category.FirstOrDefault(category => category.Id == id);
                if (currCategory != null)
                {
                    category.Remove(currCategory);
                    IEEEContext.SaveChanges();
                }
                return RedirectToAction("ViewCategory");

            }
        public IActionResult UpdateCategory(int id)
        {

            var currCategory = IEEEContext.Categories.FirstOrDefault(category => category.Id == id);
            ViewBag.Category = currCategory;
            return View("AddCategory");
        }
        public IActionResult SaveUpdateCategory(Category category)
        {
            /*Get Specific Categroy*/
            var selectedCategory = IEEEContext.Categories.FirstOrDefault(cat => cat.Id == category.Id);
            selectedCategory.Name = category.Name;
            IEEEContext.SaveChanges();
            return RedirectToAction("ViewCategory");
        }

        #endregion


        #region Task
        public IActionResult ViewTask()
        {
            var task = IEEEContext.Tasks.ToList();
            task.Reverse();
            return View(task);
        }
        /*Add Task*/
        public IActionResult AddNewTask()
        {
            ViewBag.AllCategory = IEEEContext.Categories;
            return View();
        }
        public IActionResult SaveNewTask(Models.Task  newTask)
        {
            newTask.CreatedDate = DateTime.Now;
            IEEEContext.Tasks.Add(newTask);
            IEEEContext.SaveChanges();
            return RedirectToAction("ViewTask");
        }
            /*Delete Task*/
        public IActionResult DeleteTask(int id)
        {
            var currTask = IEEEContext.Tasks.FirstOrDefault(task => task.Id == id);
            if (currTask != null)
            {
                IEEEContext.Remove(currTask);
                IEEEContext.SaveChanges();

            }
            return RedirectToAction("ViewTask");
        }
        #endregion
    }
}
