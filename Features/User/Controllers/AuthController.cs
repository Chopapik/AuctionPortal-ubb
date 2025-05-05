using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using auction_portal_ubb.Features.User.Repositories;
using auction_portal_ubb.Features.User.Models.DTOs;

namespace auction_portal_ubb.Features.User.Controllers
{
    public class AuthController : Controller
    {

        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
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
        public async Task<IActionResult> Register(UserRegisterDto userRegisterData)
        {
            if (ModelState.IsValid)
            {
                var newUser = await _authRepository.RegisterUser(userRegisterData);
                if (newUser == null)
                {
                    // Można dodać obsługę komunikatu o błędzie
                    return View(userRegisterData);
                }
                return RedirectToAction("Index", "User", new { userId = newUser.Id });
            }
            return View();
        }

        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}