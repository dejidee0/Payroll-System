namespace PayrollData.Models
{
    public class Position :BaseEntity
    {
        public List<Employee> Employees { get; set; }

    }
}