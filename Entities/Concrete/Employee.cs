using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Employee:IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeCardNo { get; set; }
        public string EmployeeGateNo { get; set; }
        public string EmployeeWorkingHour { get; set; }
        public string EmployeeWorkingFloor { get; set; }
        public string EmployeeSalary { get; set; }
        public int DepartmanID { get; set; }
    }
}
