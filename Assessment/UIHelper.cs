using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.DataAccess.Models;
using Assessment.Models;

namespace Assessment
{
    public static class UIHelper
    {
        public static ProjectVeiwModel CreatProjectVeiwModel(Project project, List<Employee> employees)
        {
            ProjectVeiwModel model = new ProjectVeiwModel
            {
                ProjectItem = project,
                Employees = CreateSelectListItemList(employees)
            };

            return model;
        }
        private static List<SelectListItem> CreateSelectListItemList(List<Employee> allEmployees)
        {
            List<SelectListItem> employeeSelectListItemList = new List<SelectListItem>();
            foreach (var employee in allEmployees)
            {
                SelectListItem employeeSelectItem = new SelectListItem()
                {
                    Text = employee.FullName,
                    Value = employee.Id.ToString()
                };
                employeeSelectListItemList.Add(employeeSelectItem);
            }
            return employeeSelectListItemList;
        }

        public static EmployeeVeiwModel CreateEmployeeVeiwModel(Employee employee, List<Project> allProjects)
        {
            EmployeeVeiwModel model = new EmployeeVeiwModel();
            model.EmployeeItem = employee;

            if (!string.IsNullOrEmpty(employee.ProjectIds))
            {
                model.EmployeeProjectIds = employee.ProjectIds.Split(',').Select(x => int.Parse(x)).ToList();
                foreach (var projectId in model.EmployeeProjectIds)
                {
                    var project = allProjects.SingleOrDefault(x => x.Id == projectId);
                    SelectListItem projectSelectListItem = new SelectListItem()
                    {
                        Text = project.Name,
                        Value = project.Id.ToString()
                    };

                    model.AllProjects.Add(projectSelectListItem);
                }
            }

            return model;
        }
    }
}
