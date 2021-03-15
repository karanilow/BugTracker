using System;

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
        public int TicketInfoID { get; set; }
        public int ProjectID { get; set; }
        public string Title { get; set; }
        public TicketStatus Status { get; set; }
        public TicketPriority Priority { get; set; }

        public Project Project { get; set; }
        public TicketHistory TicketHistory { get; set; }
        public TicketInfo TicketInfo { get; set; }

    }
}