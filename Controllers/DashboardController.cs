using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
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

            var tickets = await _context.Tickets.AsNoTracking().ToListAsync();

            viewModel.TicketsInProgressCount = tickets.Where(t => t.Status == TicketStatus.InProgress).Count();
            viewModel.TicketsStuckCount = tickets.Where(t=>t.Status == TicketStatus.Stuck).Count();
            viewModel.TicketsOverdueCount = tickets.Where(t=>t.DueOn < DateTime.Now).Count();
            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}