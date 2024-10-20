using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using BC = BCrypt.Net.BCrypt;
using SbAdmin.Models;
using SbAdmin.Services;
using System.Threading.Tasks;



namespace SbAdmin.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;  // Declare the UserService
                // Inject UserService into the controller
        public UserController(UserService userService)
        {
            _userService = userService;  // Assign the injected service to the field
        }

        // GET: /User/userItemList
        public ActionResult userItemList()
        {
            return View();  // Render the userItemList view
        }

        // GET: /User/itemdetail/5
        public ActionResult userItemDetail(int id)
        {
            // You might want to fetch item details by id here.
            return View();
        }

        // GET: /User/itemcreate
        public ActionResult userItemCreate()
        {
            return View();
        }

        // POST: /User/itemcreate
        [HttpPost("insertUser")]
        //[ValidateAntiForgeryToken] // Ensure CSRF protection
        public async Task<IActionResult> userItemCreate([FromBody] FactoryUserModel.Register user)
        {
            Console.WriteLine("call api");

            IActionResult response = Unauthorized();
            response = Ok(new { status = "User successfully created", user = user });

            //return response;

            if (user == null || string.IsNullOrEmpty(user.factory_email) || string.IsNullOrEmpty(user.factory_password))
            {
                // Return error if validation fails
                return BadRequest(new { status = "Validation failed: email and password are required" });
            }

            // Assuming user creation logic goes here (e.g., saving to a database)
            bool userAdded = await _userService.AddUser(user);

            return Ok(new { status = "User successfully created", user = user });
        }

        [HttpPost("insertUser2")]
        // [ValidateAntiForgeryToken]
        public IActionResult userItemCreate2([FromBody] FactoryUserModel.Register user)
        {
            Console.WriteLine("22222");

            IActionResult response = Unauthorized();
            FactoryUserModel insertData = new FactoryUserModel();
            response = Ok(new { FromBody = user});
            return response;

            if (string.IsNullOrEmpty(user.factory_email) && string.IsNullOrEmpty(user.factory_password))
            {
                response = Ok(new { status = "Validation" });
                return response;
            }

            return response;
        }


    }
}
