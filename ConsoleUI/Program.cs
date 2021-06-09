using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
       
        static void Main(string[] args)
        {
            // EmployeeTest();
            DeviceManager deviceManager =new DeviceManager(new EfDeviceDal(),new EmployeeManager(new EfEmployeeDal()));
            var result = deviceManager.GetAll();
            if (result.Succsess==true)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.DeviceName);
                }
               
            }

            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private  void EmployeeTest()
        {
            EmployeeManager employee = new EmployeeManager(new EfEmployeeDal());
            foreach (var item in employee.GetAllEmployee().Data)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
