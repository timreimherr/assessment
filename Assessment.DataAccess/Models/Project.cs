using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Assessment.DataAccess.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a Start Date")]
        [Display(Name = "Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Planned End Date")]
        public DateTime PlannedEndDate { get; set; }
        [Display(Name = "Actual End Date")]
        public DateTime ActualEndDate { get; set; }
        [Display(Name = "Contact")]
        public string ContactName { get; set; }
        public int EmployeeId { get; set; }
    }
}
