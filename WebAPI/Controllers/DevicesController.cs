using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        //IOC ---Inversion on control(kontrolun tersine cevrilmesi)
        IDeviceService _deviceService;
        public DevicesController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _deviceService.GetAll();
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _deviceService.GetById(id);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
        [HttpGet("getdevicedetail")]
        public IActionResult GetDeviceDetail(int employeeId)
        {
            var result = _deviceService.GetDeviceDetailsByEmployee(employeeId);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Device device)
        {
            var result = _deviceService.Add(device);
            if (result.Succsess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
