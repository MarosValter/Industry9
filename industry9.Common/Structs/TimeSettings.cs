namespace industry9.Common.Structs
{
    public struct TimeSettings
    {
        public bool Inherited { get; set; }
        public RelativeTimeSettings? Relative { get; set; }
        public AbsoluteTimeSettings? Absolute { get; set; }
    }
}
