using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcVote.Data;
using MvcVote.Models;

namespace MvcVote.Controllers
{
    public class VotersController : Controller
    {
        private readonly MvcVoteContext _context;

        public VotersController(MvcVoteContext context)
        {
            _context = context;
        }

        // GET: Voters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Voter.ToListAsync());
        }

        // GET: Voters/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voter = await _context.Voter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voter == null)
            {
                return NotFound();
            }

            return View(voter);
        }

        // GET: Voters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Voters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Municipality,didVote")] Voter voter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voter);
        }

        // GET: Voters/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voter = await _context.Voter.FindAsync(id);
            if (voter == null)
            {
                return NotFound();
            }
            return View(voter);
        }

        // POST: Voters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Surname,Municipality,didVote")] Voter voter)
        {
            if (id != voter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoterExists(voter.Id))
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
            return View(voter);
        }

        // GET: Voters/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voter = await _context.Voter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voter == null)
            {
                return NotFound();
            }

            return View(voter);
        }

        // POST: Voters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var voter = await _context.Voter.FindAsync(id);
            _context.Voter.Remove(voter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoterExists(long id)
        {
            return _context.Voter.Any(e => e.Id == id);
        }
    }
}
