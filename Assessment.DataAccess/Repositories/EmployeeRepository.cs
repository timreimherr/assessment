using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assessment.DataAccess.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace Assessment.DataAccess.Repositories
{
    public class EmployeeRepository
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;

            if (!_context.Employees.Any())
            {
                _context.Employees.AddRange(
                    new Employee()
                    {
                        Department = "AIA",
                        WorkEmail = "John@twgi.com",
                        HomeEmail = "John@email.com",
                        Fax = "612-555-4321",
                        FirstName = "John",
                        LastName = "Smith",
                        Id = 1,
                        PhoneNumber = "612-555-1234",
                        ProjectIds = "1"
                    },
                    new Employee()
                    {
                        Department = "CIC",
                        WorkEmail = "Monique@txgi.com",
                        Fax = "612-555-5321",
                        FirstName = "Monique",
                        LastName = "Unique",
                        Id = 2,
                        PhoneNumber = "612-555-1235",
                        CellPhoneNumber = "612-555-9900",
                        ProjectIds = "2"
                    },
                    new Employee()
                    {
                        Department = "CPCU",
                        WorkEmail = "Frank@twgi.com",
                        Fax = "555-555-5555",
                        FirstName = "Frank",
                        LastName = "Smith",
                        Id = 3,
                        PhoneNumber = "612-555-1236"
                    }

                );
                _context.SaveChanges();
            }
        }

        public List<Employee> GetEmployees()
        {
            return Enumerable.ToList(_context.Employees);
        }

        public void AddEmployee(Employee newEmployee)
        {
            newEmployee.Id = _context.Employees.Select(x => x.Id).Max() + 1;
            _context.Employees.Add(newEmployee);
            _context.SaveChanges();
        }

        public void UpdateEmployee(Employee editEmployee)
        {
            var originalEmployee = _context.Employees.SingleOrDefault(x =>x.Id == editEmployee.Id);
            if (originalEmployee == null)
            {
                return;
            }

            _context.Entry(originalEmployee).CurrentValues.SetValues(editEmployee);
            _context.SaveChanges();
        }

        public Employee GetEmployee(int id)
        {
            return _context.Employees.SingleOrDefault(x => x.Id == id);
        }

        public void DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
    }
}
