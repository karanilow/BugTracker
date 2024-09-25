using bugtracker.Data;
using bugtracker.Models;
using bugtracker.Models.BugtrackerViewModels;
using bugtracker.Models.CacheObjects;
using bugtracker.Models.Projects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;

namespace bugtracker.Controllers
{
    public class DashboardController : Controller
    {
        private readonly BugtrackerContext _context;
        private readonly ILogger<DashboardController> _logger;
        private readonly IMemoryCache _cache;

        public DashboardController(ILogger<DashboardController> logger, BugtrackerContext context, IMemoryCache cache)
        {
            _context = context;
            _logger = logger;
            _cache = cache;
        }

        // GET: Dashboard/Project/{id}
        public IActionResult Project(int id)
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}