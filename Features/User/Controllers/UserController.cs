using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using auction_portal_ubb.Features.User.Models.DTOs;
using auction_portal_ubb.Features.User.Services;

namespace auction_portal_ubb.Features.User.Controllers
{
    public class UserController : Controller
    {

        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index(int userId)
        {
            var user = await _userService.GetAccountData(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return View(user);
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
                var updatedUser = await _userService.UpdateAccountData(userUpdateData);
                return RedirectToAction("Index", new { userId = updatedUser.Id });
            }
            return View();
        }
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}