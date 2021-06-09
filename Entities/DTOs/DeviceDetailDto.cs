using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class DeviceDetailDto:IDto
    {
        public int DeviceID { get; set; }
        public string DeviceName { get; set; }
        public int PerID { get; set; }
        public string TotalSalary { get; set; }
        public string DeviceIpAddress { get; set; }
        public string DevicePortNo { get; set; }
        public int EmployeeId { get; set; }
    }
}
