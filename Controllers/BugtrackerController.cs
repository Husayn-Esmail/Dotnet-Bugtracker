using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bugtracker.Models;
/* this controller should call the functions of Issue and JointUserIssue
 controllers */

namespace bugtracker.Controllers
{
    public class BugtrackerController : Controller
    {
        private readonly BugtrackerContext _context;
        public BugtrackerController(BugtrackerContext context)
        {
            _context = context;
        }
        
        // GET: Issue
        public async Task<IActionResult> Index(string searchString)
        {
            var issues = from i in _context.Issue select i;
            if (!String.IsNullOrEmpty(searchString))
            {
                issues = issues.Where(i => i.Title!.Contains(searchString));
            }
            return View(await issues.ToListAsync());
        }

        // GET: Issue/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Issue/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status,Title,Description,Priority,IssueType,LastModifiedBy")] Issue issue)
        {
            if (ModelState.IsValid)
            {
                issue.DateTimeCreated = DateTime.Now;
                issue.DateTimeModified = issue.DateTimeCreated;
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
                return NotFound();
            }

            var issue = await _context.Issue.FindAsync(id);
            if (issue == null)
            {
                return NotFound();
            }
            return View(issue);
        }
        
        // POST: Issue/Edit/5
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
                    issue.UpdateTimeModified();
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

       // GET: Issue/Delete/5
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

        // POST: Issue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Issue == null)
            {
                return Problem("Entity set 'BugtrackerContext.Issue'  is null.");
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
