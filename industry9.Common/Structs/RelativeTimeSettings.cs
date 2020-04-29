using System;
using industry9.Common.Enums;

namespace industry9.Common.Structs
{
    public struct RelativeTimeSettings
    {
        public RelativeTimeMode Mode { get; set; }
        public TimeSpan Period { get; set; }
    }
}
