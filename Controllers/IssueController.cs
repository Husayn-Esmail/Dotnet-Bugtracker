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
    public class IssueController : Controller
    {
        private readonly IssueContext _context;
    

        public IssueController(IssueContext context)
        {
            _context = context;
        }

        // Get: Issue
        public async Task<IActionResult> Index()
        {
            return _context.Issue != null ?
                View(await _context.Issue.ToListAsync()) :
                Problem("Entity set 'IssueContext.Issue' is null.");
        }

        // GET: Issue/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Issue == null)
            {
                return NotFound();
            }
            var issue = await _context.Issue
                .FirstOrDefaultAsync(m => m.Id == id);
            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        // GET: Issue/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Issue/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status,Title,Description,Priority,IssueType,DateTimeCreated,DateTimeModified,LastModifiedBy")] Issue issue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(issue);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(issue);
        }

        // GET: Issue/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Issue == null)
            {
                return  NotFound();
            }

            var issue = await _context.Issue.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }
            return View(issue);
        }

        // POST: Issue/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status,Title,Description,Priority,IssueType,DateTimeCreated,DateTimeModified,LastModifiedBy")] Issue issue)
        {
            if (id != issue.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(issue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IssueExists(issue.Id))
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
            return View(issue);
        }

        // GET: Bugtracker/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Issue == null)
            {
                return NotFound();
            }

            var issue = await _context.Issue
                .FirstOrDefaultAsync(m => m.Id == id);
            if (issue == null)
            {
                return NotFound();
            }

            return View(issue);
        }

        // POST: Bugtracker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Issue == null)
            {
                return Problem("Entity set 'IssueContext.Issue' is null.");
            }
            var issue = await _context.Issue.FindAsync(id);
            if (issue != null)
            {
                _context.Issue.Remove(issue);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IssueExists(int id)
        {
            return (_context.Issue?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}