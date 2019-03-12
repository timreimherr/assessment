using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.DataAccess.Models;
using Assessment.DataAccess.Repositories;
using Assessment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ProjectRepository _projectRepository;
        private readonly EmployeeRepository _employeeRepository;

        public ProjectController(ProjectRepository projectRepository, EmployeeRepository employeeRepository)
        {
            _projectRepository = projectRepository;
            _employeeRepository = employeeRepository;
        }

        public ActionResult Index()
        {
            List<Project> projects = _projectRepository.GetProjects();

            return View(projects);
        }

        public ActionResult Details(int id)
        {
            Project project = _projectRepository.GetProject(id);
     
            return View(project);
        }

        public ActionResult Create()
        {
            ProjectVeiwModel project =
                UIHelper.CreatProjectVeiwModel(new Project(), _employeeRepository.GetEmployees());

            return View("CreateEdit",project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit(ProjectVeiwModel project)
        {
            if (ModelState.IsValid)
            {
                if (project.ProjectItem.Id <= 0)
                {
                    var employee = _employeeRepository.GetEmployee(project.ProjectItem.EmployeeId);
                    project.ProjectItem.ContactName = employee.FullName;
                    _projectRepository.AddProject(project.ProjectItem);
                }
                else
                {
                    _projectRepository.UpdateProject(project.ProjectItem);
                }

                return RedirectToAction("Index");
            }

            return View(project);
        }

        public ActionResult Edit(int id)
        {
            var orgiginalProjectroject = _projectRepository.GetProject(id);
            ProjectVeiwModel project =
                UIHelper.CreatProjectVeiwModel(orgiginalProjectroject, _employeeRepository.GetEmployees());

            return View("CreateEdit",project);
        }

        public ActionResult Delete(int id)
        {
            var project = _projectRepository.GetProject(id);
            _projectRepository.DeleteProject(project);

            return RedirectToAction("Index");
        }
    }
}