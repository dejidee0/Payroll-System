namespace PayrollData.Models
{
    public class PayrollStructure : BaseEntity
    {
        public List<Employee> Employees { get; set; }
        public List<CadreLevel> CadreLevels { get; set; }
        public PayrollComponent PayrollComponent { get; set; }
        public string PayrollComponentId { get; set; }
        public string EmployeePayrollId { get; set; }
        public EmployeePayroll EmployeePayroll { get; set; }

        public List<EmployeePayroll> EmployeePayrolls { get; set; }
    }
}
