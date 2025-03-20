using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using auction_portal_ubb.Models;
using auction_portal_ubb.Features.User.Models.DTOs;
using auction_portal_ubb.Features.User.Services;

namespace auction_portal_ubb.Features.User.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        private readonly UserService _userService;

        public UserController(ILogger<UserController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }


        public IActionResult Index(int UserId)

        {

            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(UserRegisterDto userRegisterData)
        {

            if (ModelState.IsValid)
            {
                var newUser = _userService.RegisterUser(userRegisterData);
                return RedirectToAction("Index", new { UserId = newUser.Id });
            }

            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}