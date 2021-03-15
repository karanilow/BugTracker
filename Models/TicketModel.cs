using System;

namespace bugtracker.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }

        public Project Project { get; set; }
        public TicketHistory TicketHistory { get; set; }
        public TicketInfo TicketInfo { get; set; }

    }
}