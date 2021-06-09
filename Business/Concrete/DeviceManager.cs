using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Caching;
using Core.Aspects.AutoFac.Performance;
using Core.Aspects.AutoFac.Transaction;
using Core.Aspects.AutoFac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Bussiness;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class DeviceManager : IDeviceService
    {
        IDeviceDal _deviceDal;
        IEmployeeService _employeeService;
        public DeviceManager(IDeviceDal deviceDal,IEmployeeService employeeService)
        {
            _deviceDal = deviceDal;
            _employeeService = employeeService;
        }
        [SecuredOperation("devices.add,admin")]
        [CacheRemoveAspect("IDeviceService.GetAll")]
        [ValidationAspect(typeof(DeviceValidator))]
        public IResult Add(Device device)
        {
          
            IResult result = BussinessRules.Run(CheckIfDeviceAddressExists(device.DeviceAddress), CheckIfEmployeeCount());
            if (result!=null)
            {
                return result;
            }
            _deviceDal.Add(device);
            return new SuccessResult(Messages.DeviceAdded);
        }

        [TransactionScopeAspect]
        public IResult AddTransactioanalTest(Device device)
        {
            Add(device);
            if (device.DeviceAddress.Length<2)
            {
                throw new Exception("");
            }
            Add(device);
            return null;
        }

        [CacheAspect]
        public IDataResult<List<Device>> GetAll()
        {
            //if (DateTime.Now.Hour == 9)
            //{
            //    return new ErrorDataResult<List<Device>>(Messages.MaintenanceTime);
            //}
          
            return new SuccessDataResult<List<Device>>(_deviceDal.GetAll(),Messages.DevicesListed);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Device> GetById(int deviceId)
        {
            return new SuccessDataResult<Device>(_deviceDal.Get(c => c.ID == deviceId));
        }

        public IDataResult<List<DeviceDetailDto>> GetDeviceDetails()
        {
            return new SuccessDataResult<List<DeviceDetailDto>>(_deviceDal.GetDeviceDetails());
        }
        public IDataResult<List<DeviceDetailDto>> GetDeviceDetailsByEmployee(int employeeId)
        {
            return new SuccessDataResult<List<DeviceDetailDto>>(_deviceDal.GetDeviceDetailsByEmployee(employeeId));
        }

        private IResult CheckIfDeviceAddressExists(string deviceAddres)
        {
            var result = _deviceDal.GetAll(d => d.DeviceAddress == deviceAddres).Any();
            if (result)
            {
                return new ErrorResult(Messages.DeviceAddressAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfEmployeeCount()
        {
            var result = _employeeService.GetAllEmployee();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.EmployeeLimitExceted);
            }
            return new SuccessResult();
        }

        IDataResult<List<DeviceDetailDto>> IDeviceService.GetDeviceDetailsByEmployee(int employeeId)
        {
            return new SuccessDataResult<List<DeviceDetailDto>>(_deviceDal.GetDeviceDetailsByEmployee(employeeId));
        }
    }
}
