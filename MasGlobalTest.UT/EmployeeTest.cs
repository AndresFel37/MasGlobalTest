using AutoMapper;
using FluentAssertions;
using MasGlobalTest.Data.Configuration;
using MasGlobalTest.Data.Entity;
using MasGlobalTest.Data.Repository;
using MasGlobalTest.Service.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace MasGlobalTest.UT
{
    [TestClass]
    public class EmployeeTest
    {
        private Mock<IEmployeeRepository> _employeeRepository;
        private Mock<IMapper> _mapper;
        private List<Employee> _employeeDto;
        private IEmployeeService service;

        [TestInitialize]
        public void Init()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();
            _mapper = new Mock<IMapper>();
            

            _employeeDto = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name ="Andres",
                    RoleId = 1,
                    ContractTypeName ="HourlySalaryEmployee",
                    HourlySalary = 50000,
                    MonthlySalary = 7500000,
                    RoleName ="Sw Developer"
                },

                new Employee
                {
                    Id = 1,
                    Name ="Edna",
                    RoleId = 1,
                    ContractTypeName ="MonthlySalaryEmployee",
                    HourlySalary = 3000,
                    MonthlySalary = 576000,
                    RoleName ="QA Automation"
                }
            };

            _employeeRepository.Setup(t => t.GetAll()).ReturnsAsync(_employeeDto);            

            var myProfile = new AutoMapperConfiguration();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);

            service = new EmployeeService(_employeeRepository.Object, mapper);
        }


        [TestMethod]
        public void Employee_Service_Must_Two_Employees()
        {            
            var result = service.GetAllAsync().Result;
            result.Should().HaveCount(2);
        }
    }
}
