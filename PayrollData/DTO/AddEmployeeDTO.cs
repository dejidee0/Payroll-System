using PayrollData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollData.DTO
{
     public class AddEmployeeDTO 
    {   
        public string Name { get; set; }
        public int PositionId { get; set; }
        public int CadreLevelId { get; set; }
        public int EmployeePayrollId { get; set; }
        public int PayrollStructureId { get; set; }

    }
}
