using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class DeviceValidator:AbstractValidator<Device>
    {
        public DeviceValidator()
        {
            RuleFor(p => p.DeviceName).NotEmpty();
            RuleFor(p => p.DeviceName).MinimumLength(2);
            RuleFor(p => p.DeviceAddress).NotEmpty();
            RuleFor(p => p.DeviceAddress).MinimumLength(2);

        }
    }
}
