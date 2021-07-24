using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BantrAPI.Models;
using BantrAPI.Services;

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
    }
}