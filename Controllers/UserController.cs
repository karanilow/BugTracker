using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bugtracker.Data;
using bugtracker.Models;
using bugtracker.Models.BugtrackerViewModels;
using Microsoft.Extensions.Caching.Memory;
using bugtracker.Models.CacheObjects;

namespace bugtracker.Controllers
{
    public class UserController : Controller
    {
        private readonly BugtrackerContext _context;

        private readonly IMemoryCache _cache;

        public UserController(BugtrackerContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            ViewBag.ProjectList = new SelectList(CacheObjects.GetProjectList(_context, _cache), "Id", "Title", null);
            return View(await _context.Users.ToListAsync());
        }

        // GET: User/Roles
        public async Task<IActionResult> Roles()
        {
            var users = _context.Users
                .Include(u => u.ProjectAssignments)
                    .ThenInclude(u => u.Project)
                .AsNoTracking();
            ViewBag.ProjectList = new SelectList(CacheObjects.GetProjectList(_context, _cache), "Id", "Title", null);
            return View(await users.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var viewModel = new UserDetailsData();
            viewModel.User = await _context.Users
                .Include(i => i.ProjectAssignments)
                    .ThenInclude(i => i.Project)
                .Include(i => i.TicketAssignments)
                    .ThenInclude(i => i.Ticket)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (viewModel.User == null)
            {
                return NotFound();
            }

            viewModel.Projects = viewModel.User.ProjectAssignments.Select(s => s.Project);
            viewModel.Tickets = viewModel.User.TicketAssignments.Select(s => s.Ticket);

            return View(viewModel);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserName,Email,Password,Role,Type")] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                                            "Try again, and if the problem persists " +
                                            "see your system administrator." +
                                            ex);
            }
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Email,Password,Role,Type")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
