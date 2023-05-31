using Microsoft.EntityFrameworkCore;
using PayrollData.Models;
using System.Collections.Generic;

namespace PayrollData
{
    public class PayRollDBContext : DbContext
    {
        public DbSet<CadreLevel> CadreLevels { get; set; }
        public DbSet<Deduction> Deductions { get; set; }
        public DbSet<Earning> Earnings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePayroll> EmployeePayrolls { get; set; }
        public DbSet<PayrollComponent> PayrollComponents { get; set; }
        public DbSet<PayrollStructure> PayrollStructures { get; set; }
        public DbSet<Position> Positions { get; set; }

        public PayRollDBContext(DbContextOptions<PayRollDBContext> options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Employee>()
        //        .HasOne(e => e.EmployeePayroll)
        //        .WithOne(ep => ep.Employee)
        //        .HasForeignKey<EmployeePayroll>(ep => ep.EmployeeRefId);

        //    modelBuilder.Entity<PayrollStructure>()
        //        .HasMany(ps => ps.EmployeePayrolls)
        //        .WithOne(ep => ep.PayrollStructure)
        //        .HasForeignKey(ep => ep.PayrollStructureId);

        //    modelBuilder.Entity<Earning>()
        //        .HasMany(e => e.EmployeePayrolls)
        //        .WithOne(ep => ep.Earning)
        //        .HasForeignKey(ep => ep.EarningId);

        //    modelBuilder.Entity<Deduction>()
        //        .HasMany(d => d.EmployeePayrolls)
        //        .WithOne(ep => ep.Deduction)
        //        .HasForeignKey(ep => ep.DeductionId);

        //    // Seed Position entities
        //    modelBuilder.Entity<Position>().HasData(
        //        new Position { Id = 1, Name = "Po1" },
        //        new Position { Id = 2, Name = "Bonus" }
        //        // ... add more Position entities
        //    );

        //    // Seed CadreLevel entities
        //    modelBuilder.Entity<CadreLevel>().HasData(
        //        new CadreLevel { Id = 1, Name = "Junior" },
        //        new CadreLevel { Id = 2, Name = "Senior" }
        //        // ... add more CadreLevel entities
        //    );

        //    // Seed PayrollComponent entities
        //    modelBuilder.Entity<PayrollComponent>().HasData(
        //        new PayrollComponent { Id = 1, Name = "Bonus" },
        //        new PayrollComponent { Id = 2, Name = "Bonus2" }
        //        // ... add more PayrollComponent entities
        //    );

        //    // Seed Earning entities
        //    modelBuilder.Entity<Earning>().HasData(
        //        new Earning { Id = 1, ComponentId = 1, Amount = 100.0, Name = "Bonus" },
        //        new Earning { Id = 2, ComponentId = 2, Amount = 200.0, Name = "Salary" }
        //        // ... add more Earning entities
        //    );

        //    // Seed Deduction entities
        //    modelBuilder.Entity<Deduction>().HasData(
        //        new Deduction { Id = 1, ComponentId = 2, Amount = 50.0, Name = "Bonus" },
        //        new Deduction { Id = 2, ComponentId = 1, Amount = 25.0, Name = "Salary" }
        //        // ... add more Deduction entities
        //    );

        //    // Seed Employee entities
        //    modelBuilder.Entity<Employee>().HasData(
        //        new Employee { Id = 1, CadreLevelId = 1, PositionId = 1, Name = "John Doe" },
        //        new Employee { Id = 2, CadreLevelId = 2, PositionId = 2, Name = "Jane Smith" }
        //        // ... add more Employee entities
        //    );

        //    // Seed PayrollStructure entities
        //    modelBuilder.Entity<PayrollStructure>().HasData(
        //        new PayrollStructure { Id = 1, Name = "Structure 1" },
        //        new PayrollStructure { Id = 2, Name = "Structure 2" }
        //        // ... add more PayrollStructure entities
        //    );

        //    // Seed EmployeePayroll entities
        //    modelBuilder.Entity<EmployeePayroll>().HasData(
        //        new EmployeePayroll { Id = 1, EmployeeRefId = 1, PayrollStructureId = 1, EarningId = 1, DeductionId = 1 },
        //        new EmployeePayroll { Id = 2, EmployeeRefId = 2, PayrollStructureId = 2, EarningId = 2, DeductionId = 2 }
        //        // ... add more EmployeePayroll entities
        //    );
        //}
    }
}
