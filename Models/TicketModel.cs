using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace bugtracker.Models
{
    public enum TicketStatus
    {
        Waiting, InProgress, Stuck, Finished
    }
    public enum TicketPriority
    {
        High, Medium, Low, None
    }
    public class Ticket
    {
        public int Id { get; set; }
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketStatus Status { get; set; }
        public TicketPriority Priority { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public DateTime? FinishedOn { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Due on")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DueOn { get; set; }

        [Display(Name = "Part Of")]
        public Project Project { get; set; }
        public ICollection<TicketAssignment> TicketAssignments { get; set; }
        public TicketHistory TicketHistory { get; set; }
    }
}