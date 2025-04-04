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
using auction_portal_ubb.Features.User.Repositories;

namespace auction_portal_ubb.Features.User.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index(int userId)
        {
            var user = await _userRepository.GetUser(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateData)
        {
            if (ModelState.IsValid)
            {
                var updatedUser = await _userRepository.UpdateUser(userUpdateData);
                return RedirectToAction("Index", new { userId = updatedUser.Id });
            }
            return View();
        }

        public async Task<IActionResult> Delete(int userId)
        {
            await _userRepository.DeleteUser(userId);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterData)
        {
            if (ModelState.IsValid)
            {
                var newUser = await _userRepository.RegisterUser(userRegisterData);
                if (newUser == null)
                {
                    // Można dodać obsługę komunikatu o błędzie
                    return View(userRegisterData);
                }
                return RedirectToAction("Index", new { userId = newUser.Id });
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