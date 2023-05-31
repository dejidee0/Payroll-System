using Microsoft.AspNetCore.Mvc;
using PayrollData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePayrollsController : ControllerBase
    {
        private readonly List<EmployeePayroll> _employeePayrolls;

        public EmployeePayrollsController()
        {
             //Initialize with sample data
            _employeePayrolls = new List<EmployeePayroll>
            {
                new EmployeePayroll { Id = "1", PayrollStructureId = "1" },
                new EmployeePayroll { Id = "2", PayrollStructureId = "2" }
            };
        }

        [HttpPost]
        public ActionResult<EmployeePayroll> CreateEmployeePayroll(EmployeePayroll employeePayroll)
        {
            // Generate a unique ID for the new employee payroll
            employeePayroll.Id = Guid.NewGuid().ToString();

            // Save the new employee payroll
            _employeePayrolls.Add(employeePayroll);

            return CreatedAtAction(nameof(GetEmployeePayrollDetails), new { employeePayrollID = employeePayroll.Id }, employeePayroll);
        }

        [HttpGet("{employeePayrollID}")]
        public ActionResult<EmployeePayroll> GetEmployeePayrollDetails(string employeePayrollID)
        {
            var employeePayroll = _employeePayrolls.FirstOrDefault(ep => ep.Id == employeePayrollID);
            if (employeePayroll == null)
                return NotFound();

            return employeePayroll;
        }

        [HttpGet]
        public ActionResult<List<EmployeePayroll>> GetAllEmployeePayrolls()
        {
            return _employeePayrolls;
        }

        [HttpPut("{employeePayrollID}")]
        public ActionResult UpdateEmployeePayrollDetails(string employeePayrollID, EmployeePayroll updatedEmployeePayroll)
        {
            var employeePayroll = _employeePayrolls.FirstOrDefault(ep => ep.Id == employeePayrollID);
            if (employeePayroll == null)
                return NotFound();

            //employeePayroll.EmployeeId = updatedEmployeePayroll.EmployeeId;
            employeePayroll.PayrollStructureId = updatedEmployeePayroll.PayrollStructureId;

            return NoContent();
        }

        [HttpDelete("{employeePayrollID}")]
        public ActionResult DeleteEmployeePayroll(string employeePayrollID)
        {
            var employeePayroll = _employeePayrolls.FirstOrDefault(ep => ep.Id == employeePayrollID);
            if (employeePayroll == null)
                return NotFound();

            _employeePayrolls.Remove(employeePayroll);

            return NoContent();
        }
    }
}
