using bugtracker.Data;
using bugtracker.Models;
using bugtracker.Models.CacheObjects;
using bugtracker.Models.Tickets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using System.Threading.Tasks;

namespace bugtracker.Controllers
{
    public class TicketController : Controller
    {
        private readonly BugtrackerContext _context;

        private readonly IMemoryCache _cache;

        public TicketController(BugtrackerContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        // GET: Ticket
        public IActionResult Index([FromQuery] TicketListSearchCriteria searchCriteria)
        {
            ViewBag.ProjectList = new SelectList(CacheObjects.GetProjectList(_context, _cache), "Id", "Title", searchCriteria?.ProjectId);
            TicketManager manager = new TicketManager(_context);
            return View("Index", manager.GetTickets(searchCriteria));
        }

        // GET Ticket/Project/{id}
        public IActionResult Project(int id)
        {
            var project = _context.Projects.Where(p => p.Id == id).FirstOrDefault();
            if (project == null)
            {
                return NotFound();
            }

            return Index(new TicketListSearchCriteria() { ProjectId = id });
        }

        // GET: Ticket/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .Include(t => t.Project)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Ticket/Create
        public IActionResult Create()
        {
            PopulateProjectsDropDownList();
            return View();
        }

        // POST: Ticket/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectID,Title,Status,Priority,DueOn,Description")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateProjectsDropDownList(ticket.ProjectID);
            return View(ticket);
        }

        // GET: Ticket/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ticket = await _context.Tickets.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            PopulateProjectsDropDownList();
            return View(ticket);
        }

        // POST: Ticket/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ticket = await _context.Tickets.FindAsync(id);
            if (await TryUpdateModelAsync<Ticket>(
                ticket,
                "",
                s => s.Title, s => s.Status, s => s.Priority, s => s.ProjectID, s => s.DueOn, s => s.Description))
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
            PopulateProjectsDropDownList(ticket.ProjectID);
            return View(ticket);
        }

        // GET: Ticket/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .Include(t => t.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        private void PopulateProjectsDropDownList(object selectedProject = null)
        {
            var ProjectQuery = from p in _context.Projects
                               orderby p.Title
                               select p;
            ViewBag.ProjectID = new SelectList(ProjectQuery.AsNoTracking(), "Id", "Title", selectedProject);
        }

        // POST: Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}
