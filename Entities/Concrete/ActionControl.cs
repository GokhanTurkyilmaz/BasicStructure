using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ActionControl:IEntity
    {
        public int ID { get; set; }
        public int DeviceID { get; set; }
        public int PerID { get; set; }
        public DateTime ActionTime { get; set; }
        public string TotalSalary { get; set; }
    }
}
