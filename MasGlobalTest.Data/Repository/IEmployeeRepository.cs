using MasGlobalTest.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobalTest.Data.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
    }
}
