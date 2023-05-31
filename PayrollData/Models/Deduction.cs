namespace PayrollData.Models
{
    public class Deduction : BaseEntity
    {
        public string EmployeePayrollId { get; set; }
        public string ComponentId { get; set; }
        public double Amount { get; set; }

        public EmployeePayroll EmployeePayroll { get; set; }
    }
}
