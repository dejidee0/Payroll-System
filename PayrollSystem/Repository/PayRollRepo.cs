using PayrollData.DTO;
using PayrollData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollData.Repository
{
     public class PayRollRepo : IPayRollRepo
    {
        private readonly PayRollDBContext _payRollDBContext;

        public PayRollRepo( PayRollDBContext payRollDBContext)
        {
            
            _payRollDBContext = payRollDBContext;
        }

        public async Task<bool> AddEmployee(AddEmployeeDTO employee)
        {
            //var newemployee = new Employee()
            //{   
            //    Name = employee.Name,
            //    CadreLevelId = employee.CadreLevelId,
            //    PositionId = employee.PositionId,
            //};

            //var result = await  _payRollDBContext.Employees.AddAsync(newemployee);
             var status = await _payRollDBContext.SaveChangesAsync();
            if(status > 0)
            {
                return true;
            }
            return false;
        }
    }
}
