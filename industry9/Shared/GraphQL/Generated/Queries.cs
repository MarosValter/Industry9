using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace industry9.Shared
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class Queries
        : global::StrawberryShake.IDocument
    {
        private readonly byte[] _hashName = new byte[]
        {
            109,
            100,
            53,
            72,
            97,
            115,
            104
        };
        private readonly byte[] _hash = new byte[]
        {
            55,
            50,
            101,
            100,
            57,
            55,
            99,
            54,
            98,
            97,
            102,
            50,
            98,
            51,
            57,
            54,
            48,
            55,
            50,
            50,
            54,
            57,
            98,
            97,
            101,
            102,
            98,
            50,
            48,
            53,
            53,
            53
        };
        private readonly byte[] _content = new byte[]
        {
            113,
            117,
            101,
            114,
            121,
            32,
            103,
            101,
            116,
            68,
            97,
            115,
            104,
            98,
            111,
            97,
            114,
            100,
            40,
            36,
            105,
            100,
            58,
            32,
            79,
            98,
            106,
            101,
            99,
            116,
            73,
            100,
            33,
            41,
            32,
            123,
            32,
            100,
            97,
            115,
            104,
            98,
            111,
            97,
            114,
            100,
            40,
            105,
            100,
            58,
            32,
            36,
            105,
            100,
            41,
            32,
            123,
            32,
            95,
            95,
            116,
            121,
            112,
            101,
            110,
            97,
            109,
            101,
            32,
            110,
            97,
            109,
            101,
            32,
            125,
            32,
            125
        };

        public ReadOnlySpan<byte> HashName => _hashName;

        public ReadOnlySpan<byte> Hash => _hash;

        public ReadOnlySpan<byte> Content => _content;

        public static Queries Default { get; } = new Queries();

        public override string ToString() => 
            @"query getDashboard($id: ObjectId!) {
              dashboard(id: $id) {
                name
              }
            }";
    }
}
