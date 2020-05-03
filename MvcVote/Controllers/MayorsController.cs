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
    public class MayorsController : Controller
    {
        private readonly MvcVoteContext _context;

        public MayorsController(MvcVoteContext context)
        {
            _context = context;
        }

        // GET: Mayors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mayor.ToListAsync());
        }

        // GET: Mayors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mayor = await _context.Mayor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mayor == null)
            {
                return NotFound();
            }

            return View(mayor);
        }

        // GET: Mayors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mayors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Municipality,Party,VoteCount")] Mayor mayor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mayor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mayor);
        }

        // GET: Mayors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mayor = await _context.Mayor.FindAsync(id);
            if (mayor == null)
            {
                return NotFound();
            }
            return View(mayor);
        }

        // POST: Mayors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Surname,Municipality,Party,VoteCount")] Mayor mayor)
        {
            if (id != mayor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mayor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MayorExists(mayor.Id))
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
            return View(mayor);
        }

        // GET: Mayors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mayor = await _context.Mayor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mayor == null)
            {
                return NotFound();
            }

            return View(mayor);
        }

        // POST: Mayors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mayor = await _context.Mayor.FindAsync(id);
            _context.Mayor.Remove(mayor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MayorExists(string id)
        {
            return _context.Mayor.Any(e => e.Id == id);
        }
    }
}
