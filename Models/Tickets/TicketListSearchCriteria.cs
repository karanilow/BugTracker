namespace bugtracker.Models.Tickets
{
    public class TicketListSearchCriteria
    {
        public int ProjectId { get; set; }

        public TicketDeliveryStatus DeliveryStatus { get; set; }

        public TicketPriority Priority { get; set; }

    }
}