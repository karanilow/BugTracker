using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bugtracker.Models.BugtrackerViewModels
{
    public class DashboardIndexData
    {
        public int TicketsInProgressCount { get; set; }
        public int TicketsStuckCount { get; set; }
        public int TicketsOverdueCount { get; internal set; }
    }
}
