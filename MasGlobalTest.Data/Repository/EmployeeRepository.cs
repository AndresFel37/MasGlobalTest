using System.Collections.Generic;
using System.Threading.Tasks;
using MasGlobalTest.Data.Entity;
using MasGlobalTest.Data.Shared;
using MasGlobalTest.Data.Shared.Constant;
using Newtonsoft.Json;

namespace MasGlobalTest.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<IEnumerable<Employee>> GetAll()
        {
            var apiResult = await ApiUtility.GetApiResponse(Constant.ApiURL);

            return JsonConvert.DeserializeObject<IEnumerable<Employee>>(apiResult);
        }
    }
}
