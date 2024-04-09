using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using bugtracker.Data;
using bugtracker.Models;
using bugtracker.Models.BugtrackerViewModels;

namespace bugtracker.Controllers
{
    public class DashboardController : Controller
    {
        private readonly BugtrackerContext _context;
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(ILogger<DashboardController> logger, BugtrackerContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new DashboardIndexData();

            viewModel.TicketsInProgressCount = _context.Tickets.AsNoTracking().Where(t => t.Status == TicketStatus.InProgress).Count();
            viewModel.TicketsStuckCount = _context.Tickets.AsNoTracking().Where(t => t.Status == TicketStatus.Stuck).Count();
            viewModel.TicketsOverdueCount = _context.Tickets.AsNoTracking().Where(t => t.DueOn < DateTime.Now).Count();

            var overdueTickets = await _context.Tickets.Where(t => t.DueOn < DateTime.Now).OrderByDescending(t=> t.DueOn).Take(20).ToListAsync();

            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}