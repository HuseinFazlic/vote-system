using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcVote.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcVote.Controllers
{
    public class VoteController : Controller
    {
        private readonly MvcVoteContext _context;

        public VoteController(MvcVoteContext context)
        {
            _context = context;
        }

        // GET: Mayors
        public async Task<IActionResult> Načelnik()
        {
            return View(await _context.Mayor.ToListAsync());
        }
        // GET: /<controller>/
        public IActionResult Vijeće()
        {
            return View();
        }
    }
}
