using System;
using Logic.Managers;
using Microsoft.AspNetCore.Mvc;

namespace PracticeThree.Controllers
{/*
    [Route("user-management")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserManager _userManager;
        public UsersController(UserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("users")]
        public IActionResult GetUsers() 
        {
            return Ok(_userManager.GetUsers());
        }

        [HttpGet]
        [Route("id-number")]
        public IActionResult GetIdNumber()
        {
            return Ok(_userManager.GetSSN());
        }

        [HttpPost]
        [Route("users")]
        public IActionResult CreateUser([FromBody]Logic.Models.User user)
        {
            return Ok(_userManager.CreateUser(user));
        }

        [HttpPut]
        [Route("users")]
        public IActionResult UpdateUser([FromBody]Logic.Models.User user)
        {
            return Ok(_userManager.UpdateUser(user));
        }
    }*/
}