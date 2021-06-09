using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDeviceDal : EfEntityRepositoryBase<Device, DBContext>, IDeviceDal
    {
        public List<DeviceDetailDto> GetDeviceDetails()
        {
            using (DBContext context=new DBContext())
            {
                var result = from p in context.Devices
                             join c in context.ActionControl
                             on p.ID equals c.DeviceID
                             select new DeviceDetailDto { DeviceID = p.ID, DeviceName = p.DeviceName, PerID = c.PerID, TotalSalary = c.TotalSalary };
                return result.ToList();
            }
        }

        public List<DeviceDetailDto> GetDeviceDetailsByEmployee(int employeeId)
        {
            using (DBContext context = new DBContext())
            {
                var result = from p in context.Employees
                             join c in context.Devices
                             on p.ID equals c.EmployeeId
                             select new DeviceDetailDto { DeviceID = c.ID, DeviceName = c.DeviceName, DeviceIpAddress = c.DeviceIPAdd, DevicePortNo = c.DevicePortNo,EmployeeId=p.ID};
                var result2 = result.Where(c => c.EmployeeId==employeeId).ToList();
                return result2.ToList();
            }
        }
    }
}
