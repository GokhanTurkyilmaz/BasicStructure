using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDeviceService
    {
        IDataResult<List<Device>> GetAll();
        IDataResult<Device> GetById(int deviceId);
        IDataResult<List<DeviceDetailDto>> GetDeviceDetails();
        IDataResult<List<DeviceDetailDto>> GetDeviceDetailsByEmployee(int employeeId);
        IResult Add(Device device);
        IResult AddTransactioanalTest(Device device);
    }
}
