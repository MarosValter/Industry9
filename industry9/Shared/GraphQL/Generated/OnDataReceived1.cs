using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class OnDataReceived1
        : IOnDataReceived
    {
        public OnDataReceived1(
            global::industry9.Shared.ISensorData onDataReceived)
        {
            OnDataReceived = onDataReceived;
        }

        public global::industry9.Shared.ISensorData OnDataReceived { get; }
    }
}
