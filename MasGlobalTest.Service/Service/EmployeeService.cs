using AutoMapper;
using MasGlobalTest.Data.Dto;
using MasGlobalTest.Data.Entity;
using MasGlobalTest.Data.Shared.Enum;
using MasGlobalTest.Data.Repository;
using MasGlobalTest.Service.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasGlobalTest.Service.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            return GetEmployeesFactory();
        }

        public async Task<EmployeeDto> GetByIdAsync(GetEmployeeByIdPayload employeePayload)
        {
            var employees = await GetEmployeesFactory();

            return employees.FirstOrDefault(t => t.Id == employeePayload.Id);
        }

        private async Task<IEnumerable<EmployeeDto>> GetEmployeesFactory()
        {
            var employees = await _employeeRepository.GetAll();
            var employeesDto = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);

            foreach (var employee in employeesDto)
            {
                if (employee.ContractTypeName == ContractTypeEnum.HourlySalaryEmployee.ToString())
                {
                    employee.AnnualSalary = new HourlyEmployee().CalculateAnualSalary(employee.HourlySalary);
                }
                else if (employee.ContractTypeName == ContractTypeEnum.MonthlySalaryEmployee.ToString())
                {
                    employee.AnnualSalary = new MonthlyEmployee().CalculateAnualSalary(employee.MonthlySalary);
                }
            }

            return employeesDto;
        }
    }
}
