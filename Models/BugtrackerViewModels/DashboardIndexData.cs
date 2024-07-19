namespace bugtracker.Models.BugtrackerViewModels
{
    public class DashboardIndexData
    {
        public int TicketsInProgressCount { get; set; }
        public int TicketsStuckCount { get; set; }
        public int ImportantTicketsOverdueCount { get; internal set; }
        public int TicketsWaitingCount { get; internal set; }
        public int TicketsFinishedCount { get; internal set; }
    }
}
