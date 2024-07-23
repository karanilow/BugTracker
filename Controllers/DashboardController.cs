using bugtracker.Data;
using bugtracker.Models;
using bugtracker.Models.BugtrackerViewModels;
using bugtracker.Models.CacheObjects;
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

        public IActionResult Index()
        {
            var viewModel = new DashboardIndexData();

            var statusCount = _context.Tickets
                    .AsNoTracking().GroupBy(p => p.Status).Select(g => new { Status = g.Key, count = g.Count() }).ToList();


            viewModel.TicketsInProgressCount = statusCount.First(t => t.Status == TicketStatus.InProgress).count;
            viewModel.TicketsStuckCount = statusCount.First(t => t.Status == TicketStatus.Stuck).count;
            viewModel.TicketsWaitingCount = statusCount.First(t => t.Status == TicketStatus.Waiting).count;
            viewModel.TicketsFinishedCount = statusCount.First(t => t.Status == TicketStatus.Finished).count;

            viewModel.ImportantTicketsOverdueCount = _context.Tickets.AsNoTracking().Where(t => t.Priority == TicketPriority.High && t.DueOn < DateTime.Today).Count();


            ViewBag.ProjectList = new SelectList(CacheObjects.GetProjectList(_context, _cache), "Id", "Title", null);

            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}