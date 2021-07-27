using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BantrAPI.Models;
using BantrAPI.Services;
using BantrAPI.Types;

namespace BantrAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public List<User> Get() =>
            _userService.Get();

        [HttpGet("login/{key}")]
        public User Login(string key) =>
            _userService.Login(key);

        [HttpPost("signup")]
        public User SignUp([FromBody] TUser user)
        {
            User thisUser = new User(user);
            return _userService.Create(thisUser);

        }

    }
}