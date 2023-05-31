using Microsoft.AspNetCore.Mvc;
using PayrollData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EarningsController : ControllerBase
    {
        private readonly List<Earning> _earnings;

        public EarningsController()
        {
            // Initialize with sample data
            _earnings = new List<Earning>
            {
                new Earning { Id = "1", EmployeePayrollId = "1", ComponentId = "1", Amount = 35000 },
                new Earning { Id = "2", EmployeePayrollId = "2", ComponentId = "1", Amount = 40000 }
            };
        }

        [HttpPost]
        public ActionResult<Earning> CreateEarning(Earning earning)
        {
            // Generate a unique ID for the new earning
            earning.Id = Guid.NewGuid().ToString();

            // Save the new earning
            _earnings.Add(earning);

            return CreatedAtAction(nameof(GetEarningDetails), new { earningID = earning.Id }, earning);
        }

        [HttpGet("{earningID}")]
        public ActionResult<Earning> GetEarningDetails(string earningID)
        {
            var earning = _earnings.FirstOrDefault(e => e.Id == earningID);
            if (earning == null)
                return NotFound();

            return earning;
        }

        [HttpGet]
        public ActionResult<List<Earning>> GetAllEarnings()
        {
            return _earnings;
        }

        [HttpPut("{earningID}")]
        public ActionResult UpdateEarningDetails(string earningID, Earning updatedEarning)
        {
            var earning = _earnings.FirstOrDefault(e => e.Id == earningID);
            if (earning == null)
                return NotFound();

            earning.EmployeePayrollId = updatedEarning.EmployeePayrollId;
            earning.ComponentId = updatedEarning.ComponentId;
            earning.Amount = updatedEarning.Amount;

            return NoContent();
        }

        [HttpDelete("{earningID}")]
        public ActionResult DeleteEarning(string earningID)
        {
            var earning = _earnings.FirstOrDefault(e => e.Id == earningID);
            if (earning == null)
                return NotFound();

            _earnings.Remove(earning);

            return NoContent();
        }
    }
}
