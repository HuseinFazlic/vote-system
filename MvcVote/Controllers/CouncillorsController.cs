using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcVote.Data;
using MvcVote.Models;
/*
 * This class was created by scaffolding (MVC Controller with views using Entity Framework)
 */
namespace MvcVote.Controllers
{
    public class CouncillorsController : Controller
    {
        private readonly MvcVoteContext _context;

        public CouncillorsController(MvcVoteContext context)
        {
            _context = context;
        }

        // GET: Councillors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Councillor.ToListAsync());
        }

        // GET: Councillors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var councillor = await _context.Councillor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (councillor == null)
            {
                return NotFound();
            }

            return View(councillor);
        }

        // GET: Councillors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Councillors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Municipality,Party,Position,VoteCount")] Councillor councillor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(councillor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(councillor);
        }

        // GET: Councillors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var councillor = await _context.Councillor.FindAsync(id);
            if (councillor == null)
            {
                return NotFound();
            }
            return View(councillor);
        }

        // POST: Councillors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Surname,Municipality,Party,Position,VoteCount")] Councillor councillor)
        {
            if (id != councillor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(councillor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CouncillorExists(councillor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(councillor);
        }

        // GET: Councillors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var councillor = await _context.Councillor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (councillor == null)
            {
                return NotFound();
            }

            return View(councillor);
        }

        // POST: Councillors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var councillor = await _context.Councillor.FindAsync(id);
            _context.Councillor.Remove(councillor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CouncillorExists(string id)
        {
            return _context.Councillor.Any(e => e.Id == id);
        }
    }
}
