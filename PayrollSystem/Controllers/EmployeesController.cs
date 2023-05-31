using Microsoft.AspNetCore.Mvc;
using PayrollData.DTO;
using PayrollData.Models;
using PayrollData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IPayRollRepo _payRollRepo;

        private readonly List<Employee> _employees;

        public EmployeesController()
        {
            // Initialize with sample data
            _employees = new List<Employee>
            {
                new Employee { Id = "1", Name = "John Doe", CadreLevelId = "1", PositionId = "1" },
                new Employee { Id = "2", Name = "Jane Smith", CadreLevelId = "2", PositionId = "2" }
            };
        }
        public EmployeesController(IPayRollRepo payRollRepo)
        {
            _payRollRepo = payRollRepo;
        }

        [HttpPost]
        public async Task<ActionResult<AddEmployeeDTO>> CreateEmployee([FromBody] AddEmployeeDTO employee)
        {
           if(employee == null)
            {
                throw new ArgumentNullException("Null referenceException");
            }
           var newEmployee = _payRollRepo.AddEmployee(employee);
            return Ok(newEmployee);
        }

        [HttpGet("{employeeID}")]
        public ActionResult<Employee> GetEmployeeDetails(string employeeID)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == employeeID);
            if (employee == null)
                return NotFound();

            return employee;
        }

        [HttpGet]
        public ActionResult<List<Employee>> GetAllEmployees()
        {
            return _employees;
        }

        [HttpPut("{employeeID}")]
        public ActionResult UpdateEmployeeDetails(string employeeID, Employee updatedEmployee)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == employeeID);
            if (employee == null)
                return NotFound();

            employee.Name = updatedEmployee.Name;
            employee.CadreLevelId = updatedEmployee.CadreLevelId;
            employee.PositionId = updatedEmployee.PositionId;

            return NoContent();
        }

        [HttpDelete("{employeeID}")]
        public ActionResult DeleteEmployee(string employeeID)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == employeeID);
            if (employee == null)
                return NotFound();

            _employees.Remove(employee);

            return NoContent();
        }
    }
}
