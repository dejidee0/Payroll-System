using Microsoft.AspNetCore.Mvc;
using PayrollData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeductionsController : ControllerBase
    {
        private readonly List<Deduction> _deductions;

        public DeductionsController()
        {
            //Initialize with sample data
            _deductions = new List<Deduction>
            {
                new Deduction { Id = "1", EmployeePayrollId = "1", ComponentId = "2", Amount = 50000 },
                new Deduction { Id = "2", EmployeePayrollId = "2", ComponentId = "2", Amount = 100000 }
            };
        }

        [HttpPost]
        public ActionResult<Deduction> CreateDeduction(Deduction deduction)
        {
            // Generate a unique ID for the new deduction
            deduction.Id = Guid.NewGuid().ToString();

            // Save the new deduction
            _deductions.Add(deduction);

            return CreatedAtAction(nameof(GetDeductionDetails), new { deductionID = deduction.Id }, deduction);
        }

        [HttpGet("{deductionID}")]
        public ActionResult<Deduction> GetDeductionDetails(string deductionID)
        {
            var deduction = _deductions.FirstOrDefault(d => d.Id == deductionID);
            if (deduction == null)
                return NotFound();

            return deduction;
        }

        [HttpGet]
        public ActionResult<List<Deduction>> GetAllDeductions()
        {
            return _deductions;
        }

        [HttpPut("{deductionID}")]
        public ActionResult UpdateDeductionDetails(string deductionID, Deduction updatedDeduction)
        {
            var deduction = _deductions.FirstOrDefault(d => d.Id == deductionID);
            if (deduction == null)
                return NotFound();

            deduction.EmployeePayrollId = updatedDeduction.EmployeePayrollId;
            deduction.ComponentId = updatedDeduction.ComponentId;
            deduction.Amount = updatedDeduction.Amount;

            return NoContent();
        }

        [HttpDelete("{deductionID}")]
        public ActionResult DeleteDeduction(string deductionID)
        {
            var deduction = _deductions.FirstOrDefault(d => d.Id == deductionID);
            if (deduction == null)
                return NotFound();

            _deductions.Remove(deduction);

            return NoContent();
        }
    }
}
