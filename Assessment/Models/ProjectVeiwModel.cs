using System;
using System.Collections.Generic;
using Assessment.DataAccess.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assessment.Models
{
    public class ProjectVeiwModel
    {
        public Project ProjectItem { get; set; }
        public List<SelectListItem> Employees { get; set; }
    }
}
