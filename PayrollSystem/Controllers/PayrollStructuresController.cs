using Microsoft.AspNetCore.Mvc;
using PayrollData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollStructuresController : ControllerBase
    {
        private readonly List<PayrollStructure> _payrollStructures;

        public PayrollStructuresController()
        {
            //Initialize with sample data
            _payrollStructures = new List<PayrollStructure>
            {
                new PayrollStructure { Id = "1", Name = "Structure A" },
                new PayrollStructure { Id = "2", Name = "Structure B" }
            };
        }

        [HttpPost]
        public ActionResult<PayrollStructure> CreatePayrollStructure(PayrollStructure payrollStructure)
        {
            // Generate a unique ID for the new payroll structure
            payrollStructure.Id = Guid.NewGuid().ToString();

            // Save the new payroll structure
            _payrollStructures.Add(payrollStructure);

            return CreatedAtAction(nameof(GetPayrollStructureDetails), new { payrollStructureID = payrollStructure.Id }, payrollStructure);
        }

        [HttpGet("{payrollStructureID}")]
        public ActionResult<PayrollStructure> GetPayrollStructureDetails(string payrollStructureID)
        {
            var payrollStructure = _payrollStructures.FirstOrDefault(ps => ps.Id == payrollStructureID);
            if (payrollStructure == null)
                return NotFound();

            return payrollStructure;
        }

        [HttpGet]
        public ActionResult<List<PayrollStructure>> GetAllPayrollStructures()
        {
            return _payrollStructures;
        }

        [HttpPut("{payrollStructureID}")]
        public ActionResult UpdatePayrollStructureDetails(string payrollStructureID, PayrollStructure updatedPayrollStructure)
        {
            var payrollStructure = _payrollStructures.FirstOrDefault(ps => ps.Id == payrollStructureID);
            if (payrollStructure == null)
                return NotFound();

            payrollStructure.Name = updatedPayrollStructure.Name;

            return NoContent();
        }

        [HttpDelete("{payrollStructureID}")]
        public ActionResult DeletePayrollStructure(string payrollStructureID)
        {
            var payrollStructure = _payrollStructures.FirstOrDefault(ps => ps.Id == payrollStructureID);
            if (payrollStructure == null)
                return NotFound();

            _payrollStructures.Remove(payrollStructure);

            return NoContent();
        }
    }
}
