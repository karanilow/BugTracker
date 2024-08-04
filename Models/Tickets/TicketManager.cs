using bugtracker.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bugtracker.Models.Tickets
{
    public class TicketManager
    {
        private BugtrackerContext _context;
        public TicketManager(BugtrackerContext context)
        {
            _context = context;
        }

        public List<Ticket> GetTickets(TicketListSearchCriteria searchCriteria)
        {
            var query = _context.Tickets.Include(t => t.Project).AsNoTracking().AsQueryable();

            if (searchCriteria == null)
            {
                return query.ToList();
            }

            if (searchCriteria.ProjectId != 0)
            {
                query = query.Where(t => t.ProjectID == searchCriteria.ProjectId);
            }

            switch (searchCriteria.DeliveryStatus)
            {
                case TicketDeliveryStatus.OnTime:
                    query = query.Where(t => t.DueOn >= DateTime.Today);
                    break;
                case TicketDeliveryStatus.Overdue:
                    query = query.Where(t => t.DueOn < DateTime.Today);
                    break;
                case TicketDeliveryStatus.Any:
                default:
                    break;
            }

            if (searchCriteria.Priority != TicketPriority.None) 
            {
                query = query.Where(t => t.Priority == searchCriteria.Priority);
            }

            return query.ToList();
        }
    }
}
