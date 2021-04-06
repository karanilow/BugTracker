using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required, StringLength(50), Display(Name = "Name")]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public UserRole Role { get; set; }
        [Display(Name = "Account Type")]
        public UserType Type { get; set; }

        [Display(Name = "Assigned to")]
        public ICollection<TicketAssignment> TicketAssignments { get; set; }
        [Display(Name = "Involve in")]
        public ICollection<ProjectAssignment> ProjectAssignments { get; set; }

    }
}