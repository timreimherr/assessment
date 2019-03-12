using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Assessment.DataAccess.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a First Name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a Last Name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter a Phone Number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        [Required(ErrorMessage = "Please enter a Work Email")]
        [Display(Name = "Work Email")]
        public string WorkEmail { get; set; }
        [Display(Name = "Home Email")]
        public string HomeEmail { get; set; }
        [Display(Name = "Cell Phone Number")]
        public string CellPhoneNumber { get; set; }
        public string Department { get; set; }
        [Display(Name = "Name")]
        public string FullName => FirstName + " " + LastName;
        [Display(Name = "Project")]
        public string ProjectIds { get; set; }

    }
}
