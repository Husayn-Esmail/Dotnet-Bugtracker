using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bugtracker.Models;
using bugtracker.ViewModels;
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
        public async Task<IActionResult> Index()
        {
            return _context.Issue != null ?
                View(await _context.Issue.ToListAsync()) :
                Problem("Entity set 'BugtrackerContext.Issue' is null.");
        }

        // GET: Issue/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult OnGetPartial() =>
            PartialView("test");

        // POST: Issue/Create
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
    }
}
