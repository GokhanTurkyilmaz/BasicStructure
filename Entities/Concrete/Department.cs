using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Department:IEntity
    {
        public int ID { get; set; }
        public string DepartmanName { get; set; }
    }
}
