using MasGlobalTest.Data.Dto;
using MasGlobalTest.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MasGlobalTest.Api.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="employeeId">The employee identifier.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetById")]
        // GET: /Employee/GetById?Id="12345"
        public async Task<IActionResult> GetById([FromQuery]GetEmployeeByIdPayload employeeId)
        {
            try
            {
                var result = await _employeeService.GetByIdAsync(employeeId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        // GET: /Employee/GetAll
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _employeeService.GetAllAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}