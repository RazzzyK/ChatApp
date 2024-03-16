using ChatApp.Models;
using ChatApp.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Windows;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly YourDbContext _context;
        private readonly IConfiguration _configuration; //remove

        public ChatController(YourDbContext context, IConfiguration configuration) {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetUserName()
        {
            User user1 = new User(); 
            
            user1.Username = "JLai";
            user1.Password = "password";

            return Ok(user1);
        }

        [HttpPost]
        public IActionResult Register(User u) {

            Console.Write(u.Username);  
            
            _context.Users.Add(u);
            _context.SaveChanges();

            return Ok("User Saved Sucessfully");
        }
    }
}
