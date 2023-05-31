namespace PayrollData.Models
{
    public class PayrollComponent: BaseEntity
    {
        PayrollComponentType PayrollComponentType { get; set; }
        public Earning Earning { get; set; }
        public string EarningId { get; set; }
        public Deduction Deduction { get; set; }
        public string DeducutionId { get; set; }
    }
}