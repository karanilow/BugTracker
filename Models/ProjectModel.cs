using System;
using System.Collections.Generic;

namespace bugtracker.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Ticket> Tickets { get; set; }

    }
}