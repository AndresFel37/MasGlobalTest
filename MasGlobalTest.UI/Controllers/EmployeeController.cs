using MasGlobalTest.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MasGlobalTest.UI.Controllers
{
    public class EmployeeController : Controller
    {
        public async Task<IActionResult> Index(string id)
        {            
            if (string.IsNullOrEmpty(id))
            {
                var employeeData = new EmployeeData();
                var model = await employeeData.GetAll();
                return View(model);
            }
            else
            {
                var employeeData = new EmployeeData();
                var model = await employeeData.GetById(id);
                return View(model);
            }
        }        
    }
}