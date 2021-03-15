using System;
using System.Collections.Generic;

namespace bugtracker.Models
{
    public class TicketHistory
    {
        public int Id { get; set; }
        public string PropertyFeild { get; set; }
        public DateTime Date { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }

        public Ticket Ticket { get; set; }
    }
}