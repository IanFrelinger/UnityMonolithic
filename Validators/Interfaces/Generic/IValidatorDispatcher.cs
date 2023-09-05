using System;
using System.Collections.Generic;

namespace Validators.Interfaces.Generic
{
    public interface IValidatorDispatcher<in TInputType, in TDispatchEnum> where TDispatchEnum : Enum
    {
        bool IsValid(TInputType item, TDispatchEnum dispatch);
        IEnumerable<string> GetValidationErrors(TInputType item, TDispatchEnum dispatch);
    }
}