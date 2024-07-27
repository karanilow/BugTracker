using bugtracker.Data;
using bugtracker.Models;
using bugtracker.Models.CacheObjects;
using bugtracker.Models.Projects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace bugtracker.Controllers
{
    public class ProjectController : Controller
    {
        private readonly BugtrackerContext _context;

        private readonly IMemoryCache _cache;

        public ProjectController(BugtrackerContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        // GET: Project
        public async Task<IActionResult> Index()
        {
            ViewBag.ProjectList = new SelectList(CacheObjects.GetProjectList(_context, _cache), "Id", "Title", null);
            return View(await _context.Projects.ToListAsync());
        }

        // GET: Project/Dashboard/{id}
        public IActionResult Dashboard(int id)
        {
            var project = _context.Projects
                                .Include(t => t.Tickets)
                                .AsNoTracking()
                                .FirstOrDefault(m => m.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            var viewModel = new ProjectDashboardViewModel(project);

            var statusCount = project.Tickets.GroupBy(p => p.Status).Select(g => new { Status = g.Key, count = g.Count() });

            viewModel.TicketsInProgressCount = statusCount.FirstOrDefault(t => t.Status == TicketStatus.InProgress)?.count ?? 0;
            viewModel.TicketsStuckCount = statusCount.FirstOrDefault(t => t.Status == TicketStatus.Stuck)?.count ?? 0;
            viewModel.TicketsWaitingCount = statusCount.FirstOrDefault(t => t.Status == TicketStatus.Waiting)?.count ?? 0;
            viewModel.TicketsFinishedCount = statusCount.FirstOrDefault(t => t.Status == TicketStatus.Finished)?.count ?? 0;

            viewModel.ImportantTicketsOverdueCount = project.Tickets.Where(t => t.Priority == TicketPriority.High && t.DueOn < DateTime.Today).Count();


            ViewBag.ProjectList = new SelectList(CacheObjects.GetProjectList(_context, _cache), "Id", "Title", id);

            return View(viewModel);
        }

        // GET: Project/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                                .Include(t => t.Tickets)
                                .AsNoTracking()
                                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Project/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
        [Bind("Title,Description")] Project project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(project);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(project);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var projectToUpdate = await _context.Projects.FindAsync(id);
            if (await TryUpdateModelAsync<Project>(
                projectToUpdate,
                "",
                s => s.Title, s => s.Description))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(projectToUpdate);
        }

        // GET: Project/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
