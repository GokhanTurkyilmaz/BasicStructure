using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Device:IEntity
    {
        public int ID { get; set; }
        public string DeviceAddress { get; set; }
        public string DeviceName { get; set; }
        public string DeviceTopicName { get; set; }
        public string DeviceSubscribeName { get; set; }
        public string DeviceIPAdd { get; set; }
        public string DevicePortNo { get; set; }
        public int EmployeeId { get; set; }
    }
}
