using System.ComponentModel;

namespace Validators.DataStructs
{
    public enum StringValidatorDispatcher
    {
        [Description("Not_Set")]
        Unset,
        NullOrEmpty,
        NullOrWhiteSpace,
        [Description("All_Items")]
        All
    }
}