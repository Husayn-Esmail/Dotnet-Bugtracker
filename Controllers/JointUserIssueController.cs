using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bugtracker.Models;

namespace bugtracker.Controllers
{
    public class JointUserIssueController : Controller
    {
        private readonly JointUserIssueContext _context;

        public JointUserIssueController(JointUserIssueContext context)
        {
            _context = context;
        }

        // GET: JointUserIssue
        public async Task<IActionResult> Index()
        {
              return _context.JointUserIssue != null ? 
                          View(await _context.JointUserIssue.ToListAsync()) :
                          Problem("Entity set 'JointUserIssueContext.JointUserIssue'  is null.");
        }

        // GET: JointUserIssue/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.JointUserIssue == null)
            {
                return NotFound();
            }

            var jointUserIssue = await _context.JointUserIssue
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jointUserIssue == null)
            {
                return NotFound();
            }

            return View(jointUserIssue);
        }

        // GET: JointUserIssue/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JointUserIssue/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,IssueId")] JointUserIssue jointUserIssue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jointUserIssue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jointUserIssue);
        }

        // GET: JointUserIssue/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.JointUserIssue == null)
            {
                return NotFound();
            }

            var jointUserIssue = await _context.JointUserIssue.FindAsync(id);
            if (jointUserIssue == null)
            {
                return NotFound();
            }
            return View(jointUserIssue);
        }

        // POST: JointUserIssue/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,IssueId")] JointUserIssue jointUserIssue)
        {
            if (id != jointUserIssue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jointUserIssue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JointUserIssueExists(jointUserIssue.Id))
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
            return View(jointUserIssue);
        }

        // GET: JointUserIssue/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.JointUserIssue == null)
            {
                return NotFound();
            }

            var jointUserIssue = await _context.JointUserIssue
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jointUserIssue == null)
            {
                return NotFound();
            }

            return View(jointUserIssue);
        }

        // POST: JointUserIssue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.JointUserIssue == null)
            {
                return Problem("Entity set 'JointUserIssueContext.JointUserIssue'  is null.");
            }
            var jointUserIssue = await _context.JointUserIssue.FindAsync(id);
            if (jointUserIssue != null)
            {
                _context.JointUserIssue.Remove(jointUserIssue);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JointUserIssueExists(int id)
        {
          return (_context.JointUserIssue?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
