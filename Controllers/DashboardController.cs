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
            viewModel.Tickets = await _context.Tickets.AsNoTracking().ToListAsync();
            viewModel.TicketsInProgress = CountTickets(TicketStatus.InProgress, viewModel.Tickets);
            viewModel.TicketsStuck = CountTickets(TicketStatus.Stuck, viewModel.Tickets);
            return View(viewModel);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private int CountTickets(TicketStatus ticketStatus, IEnumerable<Ticket> tickets)
        {
            var TicketsQuery = (from t in tickets
                                where t.Status == ticketStatus
                                select t).Count();
            return TicketsQuery;
        }

    }
}