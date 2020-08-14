using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TenmoServer.DAO;
using TenmoServer.Models;

namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserDAO userDAO;

        public UsersController(IUserDAO _userDAO)
        {
            userDAO = _userDAO;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            List<User> users = userDAO.GetUsers();

            foreach (User u in users)
            {
                u.PasswordHash = null;
                u.Salt = null;
            }

            return Ok(users);
        }
    }
}
