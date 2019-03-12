using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.DataAccess.Models;
using Assessment.DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly ProjectRepository _projecctRepository;

        public EmployeeController(EmployeeRepository repository, ProjectRepository projecctRepository)
        {
            _employeeRepository = repository;
            _projecctRepository = projecctRepository;
        }
        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> employees = _employeeRepository.GetEmployees();
            return View(employees);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var employee = _employeeRepository.GetEmployee(id);
            var model = UIHelper.CreateEmployeeVeiwModel(employee, _projecctRepository.GetProjects());

            return View(model);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View("CreateEdit",employee);
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEdit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.Id <= 0)
                {
                    _employeeRepository.AddEmployee(employee);
                }
                else
                {
                    _employeeRepository.UpdateEmployee(employee);
                }

                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            var employee = _employeeRepository.GetEmployee(id);
            var model = UIHelper.CreateEmployeeVeiwModel(employee, _projecctRepository.GetProjects());

            return View("CreateEdit", employee);
        }


        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = _employeeRepository.GetEmployee(id);
            _employeeRepository.DeleteEmployee(employee);
            return RedirectToAction("Index");
        }
    }
}