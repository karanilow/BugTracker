using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bugtracker.Models
{
    public class ProjectAssignment
    {
        public int ProjectID { get; set; }
        public int UserID { get; set; }
        public Project Project { get; set; }
        public User User { get; set; }
    }
}