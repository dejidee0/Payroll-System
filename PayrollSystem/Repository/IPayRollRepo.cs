using PayrollData.DTO;
using PayrollData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollData.Repository
{
     public interface IPayRollRepo
    {
        Task<bool> AddEmployee(AddEmployeeDTO employee);
    }
}
