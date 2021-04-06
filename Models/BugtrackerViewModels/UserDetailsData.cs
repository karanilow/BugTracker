using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bugtracker.Models.BugtrackerViewModels
{
    public class UserDetailsData
    {
        public User User { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
        public IEnumerable<Project> Projects { get; set; }
    }
}