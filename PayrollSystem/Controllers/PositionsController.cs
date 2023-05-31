using Microsoft.AspNetCore.Mvc;
using PayrollData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PayrollSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private List<Position> _positions;

        public PositionsController()
        {
            // Initialize the list of positions (sample data)
            _positions = new List<Position>
            {
                new Position { Id = "1", Name = "Manager" },
                new Position { Id = "2", Name = "Developer" },
                new Position { Id = "3", Name = "Accountant" }
            };
        }

        [HttpPost]
        public ActionResult<Position> CreatePosition(Position position)
        {
            position.Id = Guid.NewGuid().ToString(); // Generate a unique ID for the position
            _positions.Add(position);
            return CreatedAtAction(nameof(GetPositionDetails), new { positionID = position.Id }, position);
        }

        [HttpGet("{positionID}")]
        public ActionResult<Position> GetPositionDetails(string positionID)
        {
            var position = _positions.FirstOrDefault(p => p.Id == positionID);
            if (position == null)
                return NotFound();

            return position;
        }

        [HttpGet]
        public ActionResult<List<Position>> GetAllPositions()
        {
            return _positions;
        }

        [HttpPut("{positionID}")]
        public ActionResult UpdatePositionDetails(string positionID, Position updatedPosition)
        {
            var position = _positions.FirstOrDefault(p => p.Id == positionID);
            if (position == null)
                return NotFound();

            position.Name = updatedPosition.Name;

            return NoContent();
        }

        [HttpDelete("{positionID}")]
        public ActionResult DeletePosition(string positionID)
        {
            var position = _positions.FirstOrDefault(p => p.Id == positionID);
            if (position == null)
                return NotFound();

            _positions.Remove(position);

            return NoContent();
        }
    }
}
