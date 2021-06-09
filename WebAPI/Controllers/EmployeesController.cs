using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _employeeService.GetAllEmployee();
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
