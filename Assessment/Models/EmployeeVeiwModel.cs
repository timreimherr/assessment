using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.DataAccess.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assessment.Models
{
    public class EmployeeVeiwModel
    {
        public Employee EmployeeItem { get; set; }
        public List<SelectListItem> AllProjects { get; set; }
        public List<int> EmployeeProjectIds { get; set; }

        public EmployeeVeiwModel()
        {
            AllProjects = new List<SelectListItem>();
            EmployeeProjectIds = new List<int>();
        }
    }
}
