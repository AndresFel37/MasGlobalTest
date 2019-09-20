using AutoMapper;
using MasGlobalTest.Data.Dto;
using MasGlobalTest.Data.Entity;

namespace MasGlobalTest.Data.Configuration
{
    public class AutoMapperConfiguration: Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
