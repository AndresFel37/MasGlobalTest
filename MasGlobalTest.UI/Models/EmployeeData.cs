using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasGlobalTest.UI.Models
{
    public class EmployeeData
    {
        public async Task<IEnumerable<EmployeeViewModel>> GetAll()
        {
            List<EmployeeViewModel> GetEmployeesResponse;
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:52312/GetAll");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            GetEmployeesResponse = JsonConvert.DeserializeObject<IEnumerable<EmployeeViewModel>>(content).ToList();
            return GetEmployeesResponse;
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetById(string id)
        {            
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"http://localhost:52312/GetById?Id={id}");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<EmployeeViewModel>(content);
            var getEmployeesResponse = new List<EmployeeViewModel> { data };
            return getEmployeesResponse;
        }
    }
}
