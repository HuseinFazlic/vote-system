using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcVote.Models;

namespace MvcVote.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(SignIn obj)
        {
            if (ModelState.IsValid)
            {
                var result = signinManager.PasswordSignInAsync
                (obj.UserName, obj.Password,
                    obj.RememberMe, false).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("List", "EmployeeManager");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid user details");
                }
            }
            return View(obj);
        }
        */
    }
}
