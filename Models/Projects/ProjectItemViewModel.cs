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
            Id = p.Id;
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

    }
}
