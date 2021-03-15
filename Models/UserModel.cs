using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace bugtracker.Models
{
    public enum UserRole
    {
        DEV, PM, ADMIN
    }
    public enum UserType
    {
        Regular, Demo
    }
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public UserType Type { get; set; }


        [NotMapped]
        public ICollection<TicketInfo> AssignedTickets { get; set; }

        [NotMapped]
        public ICollection<TicketInfo> TicketsSubmitted { get; set; }

    }
}