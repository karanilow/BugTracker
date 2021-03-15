using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace bugtracker.Models
{
    public class TicketInfo
    {
        public int Id { get; set; }
        public int SubmittedByUserID { get; set; }
        public int AssignedToUserID { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? FinishedOn { get; set; }
        public DateTime? DueOn { get; set; }

        public Ticket Ticket { get; set; }

        [NotMapped]
        public User SubmittedBy { get; set; }

        [NotMapped]
        public User AssignedTo { get; set; }

    }
}