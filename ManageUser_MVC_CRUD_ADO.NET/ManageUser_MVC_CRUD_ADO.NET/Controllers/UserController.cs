using ManageUser_MVC_CRUD_ADO.NET.Models;
using ManageUser_MVC_CRUD_ADO.NET.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ManageUser_MVC_CRUD_ADO.NET.Controllers
{
  
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }
        [HttpGet()]
        public IActionResult UserList()
        {
            List<User> userList = new();
            var result = _userRepository.GetAllUsers().ToList();
            //user.Qualifications = GetQualifications(null); // Get all qualifications initially
            return View(result);
        }

        [HttpGet()]
        public IActionResult Edit(int id)
        {
                
                User result = _userRepository.GetUserById(id);
                return View(result);
            
          
        }
        [HttpGet]
        public IActionResult GetUserById(int userId)
        {
            User user = new();
            return Json(user); // Return user data as JSON for view
        }

        [HttpGet]
        public IActionResult GetUser(int userId)
        {
            User user = new();
            //User user = GetUserFromDatabase(userId);
            //user.Qualifications = GetQualifications(userId);
            return Json(user); // Return user data as JSON for view
        }

        [HttpDelete]
        public IActionResult DeleteUser(int userId)
        {
            //DeleteUserFromDatabase(userId);
            return Ok(); // Return success message (optional)
        }

        [HttpPost]
        public IActionResult AddQualification(Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                //AddQualificationToDatabase(qualification);
                return Ok(); // Return success message (optional)
            }
            return BadRequest("Failed to add qualification"); // Return error message
        }

        [HttpDelete]
        public IActionResult DeleteQualification(int qualificationId)
        {
            //DeleteQualificationFromDatabase(qualificationId);
            return Ok(); // Return success message (optional)
        }

        // Implement methods for interacting with the database using ADO.net
        // ... (GetUserFromDatabase, SaveUserToDatabase, GetQualifications, etc.)
    }
}
