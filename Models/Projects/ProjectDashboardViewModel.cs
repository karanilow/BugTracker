namespace bugtracker.Models.Projects
{
    public class ProjectDashboardViewModel
    {
        public ProjectDashboardViewModel(Project project)
        {
            Project = new ProjectItemViewModel(project);
        }

        public ProjectItemViewModel Project { get; set; }

        public int TicketsInProgressCount { get; set; }
        public int TicketsStuckCount { get; set; }
        public int ImportantTicketsOverdueCount { get; internal set; }
        public int TicketsWaitingCount { get; internal set; }
        public int TicketsFinishedCount { get; internal set; }

    }
}
