using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bugtracker.Models.BugtrackerViewModels
{
    public class DashboardIndexData
    {
        public int TicketsInProgress { get; set; }
        public int TicketsStuck { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
    }
}
