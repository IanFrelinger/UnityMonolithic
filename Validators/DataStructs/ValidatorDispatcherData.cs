using System;
using System.Collections.Generic;
using Validators.Interfaces.Generic;

namespace Validators.DataStructs
{
    public class ValidatorDispatcherData<TInputType, TDispatchEnum> where TDispatchEnum : Enum
    {
        public Dictionary<TDispatchEnum, IValidator<TInputType>> Validators = new();
    }
}