using MasGlobalTest.Data.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobalTest.Service.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto> GetByIdAsync(GetEmployeeByIdPayload employeePayload);
    }
}
