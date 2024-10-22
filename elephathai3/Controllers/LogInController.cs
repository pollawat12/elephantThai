using System;
using System.Web.Mvc;

namespace elephathai3.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Userlogin()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        // GET: LogIn/Details/5
        public ActionResult Details(int id)
        {
            // You would typically fetch details based on the id here
            return View();
        }

        // GET: LogIn/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LogIn/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Process the login creation logic here

                    // Redirect to Index or another action after success
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Log the exception (consider using a logging framework)
                    ModelState.AddModelError("", "Unable to create login: " + ex.Message);
                }
            }
            return View(model); // Return the model with validation errors
        }

        // GET: LogIn/Edit/5
        public ActionResult Edit(int id)
        {
            // Fetch the login details to edit based on the id
            return View();
        }

        // POST: LogIn/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Process the edit logic here

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Unable to edit login: " + ex.Message);
                }
            }
            return View(model);
        }

        // GET: LogIn/Delete/5
        public ActionResult Delete(int id)
        {
            // Fetch the login details to confirm deletion
            return View();
        }

        // POST: LogIn/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // Process the delete logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to delete login: " + ex.Message);
                return View(); // Return the delete view if there's an error
            }
        }




        [HttpPost]
        public JsonResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Example: Replace this with your actual user validation logic
                bool isValidUser = ValidateUser(model.Username, model.Password);

                if (isValidUser)
                {
                    // Create a successful response
                    return Json(new { success = true, message = "Login successful!", data = model });
                }
                else
                {
                    // Invalid credentials response
                    return Json(new { success = false, message = "Invalid username or password." });
                }
            }

            // Model state is invalid
            return Json(new { success = false, message = "Please provide valid username and password." , data = model });
        }


        // Example user validation method (replace this with actual validation logic)
        private bool ValidateUser(string username, string password)
        {
            // For demonstration purposes, we'll use hardcoded values.
            // You should replace this with your actual user verification logic (e.g., database query).
            return username == "admin" && password == "password"; // Example: change this logic
        }

    }



    // Example LoginViewModel for strong typing
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        // Add other properties as necessary
    }
}
