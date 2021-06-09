using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IDeviceDal:IEntityRepository<Device>
    {
        List<DeviceDetailDto> GetDeviceDetails();
        List<DeviceDetailDto> GetDeviceDetailsByEmployee(int employeeID);
    }
}
