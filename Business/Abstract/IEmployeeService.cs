using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        public IDataResult<List<Employee>> GetAllEmployee();

        public IDataResult<Employee> GetById(int employeeId);
    }
}
