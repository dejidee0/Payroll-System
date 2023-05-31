using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollData.Models
{
    public class Employee : BaseEntity
    {
        public string CadreLevelId { get; set; }
        public CadreLevel CadreLevel { get; set; }
        public string PositionId { get; set; }
        public Position Position { get; set; }
        public string PayrollStructureId { get; set; }
        public PayrollStructure PayrollStructure { get; set; }
        public string? EmployeePayrollId { get; set; }
        public EmployeePayroll EmployeePayroll { get; set; }
    }
}