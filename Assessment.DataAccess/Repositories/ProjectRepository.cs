using Assessment.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessment.DataAccess.Repositories
{
    public class ProjectRepository
    {
        private readonly ProjectContext _context;

        public ProjectRepository(ProjectContext context)
        {
            _context = context;

            if (!_context.Projects.Any())
            {
                _context.Projects.AddRange(
                    new Project()
                    {
                        Name = "Nike",
                        StartDate = DateTime.Now,
                        PlannedEndDate = new DateTime(2020, 05, 05),
                        ContactName = "John Smith",
                        EmployeeId = 1
                    },
                    new Project()
                    {
                        Name = "Honda",
                        StartDate = DateTime.Now,
                        PlannedEndDate = new DateTime(2025, 03, 05),
                        ContactName = "Monique Unique",
                        EmployeeId = 2
                        //AssignedEmployee = new Employee()
                        //{
                        //    Department = "CIC",
                        //    WorkEmail = "Monique@txgi.com",
                        //    Fax = "612-555-5321",
                        //    FirstName = "Monique",
                        //    LastName = "Unique",
                        //    Id = 2,
                        //    PhoneNumber = "612-555-1235",
                        //    CellPhoneNumber = "612-555-9900"
                        //}
                    }
                );
                _context.SaveChanges();
            }
        }

        public List<Project> GetProjects()
        {
            return Enumerable.ToList(_context.Projects);
        }

        public void AddProject(Project newProject)
        {
            newProject.Id = _context.Projects.Select(x => x.Id).Max() + 1;
            _context.Projects.Add(newProject);
            _context.SaveChanges();
        }

        public void UpdateProject(Project editProject)
        {
            var originalProject = _context.Projects.SingleOrDefault(x => x.Id == editProject.Id);
            if (originalProject == null)
            {
                return;
            }

            _context.Entry(originalProject).CurrentValues.SetValues(editProject);
            _context.SaveChanges();
        }

        public Project GetProject(int id)
        {
            return _context.Projects.SingleOrDefault(x => x.Id == id);
        }

        public void DeleteProject(Project project)
        {
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }
    }
}

