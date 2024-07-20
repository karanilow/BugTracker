using System;

namespace bugtracker.Models.Projects
{
    public class ProjectItemViewModel
    {
        public ProjectItemViewModel(Project p)
        {
            ArgumentNullException.ThrowIfNull(p);

            Title = p.Title;
            Description = p.Description;
        }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
