using Microsoft.AspNetCore.Mvc;
using PayrollData.Models;
using System.Collections.Generic;
using System.Linq;

namespace PayrollSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadreLevelsController : ControllerBase
    {
        private readonly List<CadreLevel> _cadreLevels;

        public CadreLevelsController()
        {
            // Initialize with sample data
            _cadreLevels = new List<CadreLevel>
            {
                new CadreLevel { Id = "1", Name = "Junior Staff Cadre" },
                new CadreLevel { Id = "2", Name = "Clerical Cadre" },
                new CadreLevel { Id = "3", Name = "Executive Cadre" },
                new CadreLevel { Id = "4", Name = "Senior Executive     Cadre" },
                new CadreLevel { Id = "5", Name = "Directorate Cadre" }
            };
        }

        [HttpGet]
        public ActionResult<IEnumerable<CadreLevel>> GetCadreLevels()
        {
            return _cadreLevels;
        }

        [HttpPost]
        public ActionResult<CadreLevel> CreateCadreLevel(CadreLevel cadreLevel)
        {
            cadreLevel.Id = Guid.NewGuid().ToString(); // Generate a unique ID for the cadre level
            _cadreLevels.Add(cadreLevel);
            return CreatedAtAction(nameof(GetCadreLevel), new { cadreLevelId = cadreLevel.Id }, cadreLevel);
        }

        [HttpGet("{cadreLevelId}")]
        public ActionResult<CadreLevel> GetCadreLevel(string cadreLevelId)
        {
            var cadreLevel = _cadreLevels.FirstOrDefault(c => c.Id == cadreLevelId);
            if (cadreLevel == null)
                return NotFound();

            return cadreLevel;
        }

        [HttpPut("{cadreLevelId}")]
        public ActionResult UpdateCadreLevel(string cadreLevelId, CadreLevel updatedCadreLevel)
        {
            var cadreLevel = _cadreLevels.FirstOrDefault(c => c.Id == cadreLevelId);
            if (cadreLevel == null)
                return NotFound();

            cadreLevel.Name = updatedCadreLevel.Name;
            // Update other properties as needed

            return NoContent();
        }

        [HttpDelete("{cadreLevelId}")]
        public ActionResult DeleteCadreLevel(string cadreLevelId)
        {
            var cadreLevel = _cadreLevels.FirstOrDefault(c => c.Id == cadreLevelId);
            if (cadreLevel == null)
                return NotFound();

            _cadreLevels.Remove(cadreLevel);

            return NoContent();
        }
    }
}
