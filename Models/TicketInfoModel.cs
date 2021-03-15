using System;
using System.Collections.Generic;

namespace bugtracker.Models
{
    public class TicketInfo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime FinishedOn { get; set; }
        public DateTime DueOn { get; set; }

        public Ticket Ticket { get; set; }
        public User SubmittedBy { get; set; }
        public User CreatedBy { get; set; }

    }
}