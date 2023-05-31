using Microsoft.AspNetCore.Mvc;
using PayrollData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollComponentsController : ControllerBase
    {
        private readonly List<PayrollComponent> _payrollComponents;

        public PayrollComponentsController()
        {
            //Initialize with sample data
            _payrollComponents = new List<PayrollComponent>
            {
                new PayrollComponent { Id = "1", Name = "Bonus", /*PayrollStructureIds = new List<string> { "1" }*/ },
                new PayrollComponent { Id = "2", Name = "Tax", /*PayrollStructureIds = new List<string> { "1", "2" }*/ }
            };
        }

        [HttpPost]
        public ActionResult<PayrollComponent> CreatePayrollComponent(PayrollComponent payrollComponent)
        {
            // Generate a unique ID for the new payroll component
            payrollComponent.Id = Guid.NewGuid().ToString();

            // Save the new payroll component
            _payrollComponents.Add(payrollComponent);

            return CreatedAtAction(nameof(GetPayrollComponentDetails), new { payrollComponentID = payrollComponent.Id }, payrollComponent);
        }

        [HttpGet("{payrollComponentID}")]
        public ActionResult<PayrollComponent> GetPayrollComponentDetails(string payrollComponentID)
        {
            var payrollComponent = _payrollComponents.FirstOrDefault(pc => pc.Id == payrollComponentID);
            if (payrollComponent == null)
                return NotFound();

            return payrollComponent;
        }

        [HttpGet]
        public ActionResult<List<PayrollComponent>> GetAllPayrollComponents()
        {
            return _payrollComponents;
        }

        [HttpPut("{payrollComponentID}")]
        public ActionResult UpdatePayrollComponentDetails(string payrollComponentID, PayrollComponent updatedPayrollComponent)
        {
            var payrollComponent = _payrollComponents.FirstOrDefault(pc => pc.Id == payrollComponentID);
            if (payrollComponent == null)
                return NotFound();

            //payrollComponent.Name = updatedPayrollComponent.Name;
            //payrollComponent.Type = updatedPayrollComponent.Type;
            //payrollComponent.PayrollStructureIds = updatedPayrollComponent.PayrollStructureIds;

            return NoContent();
        }

        [HttpDelete("{payrollComponentID}")]
        public ActionResult DeletePayrollComponent(string payrollComponentID)
        {
            var payrollComponent = _payrollComponents.FirstOrDefault(pc => pc.Id == payrollComponentID);
            if (payrollComponent == null)
                return NotFound();

            _payrollComponents.Remove(payrollComponent);

            return NoContent();
        }
    }
}
