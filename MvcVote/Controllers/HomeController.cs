using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcVote.Models;
/*
 * This class was written by Husein Fazlić
 */
namespace MvcVote.Controllers
{
    public class HomeController : Controller
    {
        /*
         * Written by Husein Fazlić
         */
        public IActionResult Index()
        {
            return View();
        }
    }
}
