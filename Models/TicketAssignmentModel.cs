using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bugtracker.Models
{
    public class TicketAssignment
    {
        public int UserID { get; set; }
        public int TicketID { get; set; }
        public User User { get; set; }
        public Ticket Ticket { get; set; }
    }
}