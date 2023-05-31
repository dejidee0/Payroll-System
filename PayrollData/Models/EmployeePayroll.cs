using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollData.Models
{
    public class EmployeePayroll : BaseEntity
    {
        [ForeignKey("Employee")]
        public int EmployeeRefId { get; set; } // Replace EmployeeId with EmployeeRefId or any appropriate name

        public Employee Employee { get; set; }
        public string PayrollStructureId { get; set; }
        public Earning Earning { get; set; }
        public string EarningId { get; set; }
        public Deduction Deduction { get; set; }
        public string DeductionId { get; set; }
        public string EarningId2 { get; set; }
        public string EarningId1 { get; set; }
    }

    public class EmployeePayrollConfiguration : IEntityTypeConfiguration<EmployeePayroll>
    {
        public void Configure(EntityTypeBuilder<EmployeePayroll> builder)
        {
            builder.HasOne(ep => ep.Employee)
                .WithOne(e => e.EmployeePayroll)
                .HasForeignKey<EmployeePayroll>(ep => ep.EmployeeRefId); // Use EmployeeRefId instead of EmployeeId
        }
    }
}
