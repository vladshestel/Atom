using System;

namespace Vee
{
    public static class Sha
    {
        public static byte[] Hash256(ReadOnlySpan<byte> input)
        {
            const int digestBits = 256;

            // prepare all parameters compile-time
            const int digestBytes = digestBits / 8;
            const int capacityBytes = digestBytes * 2;
            const int rateBytes = Sponge.StateBytes - capacityBytes;

            return Keccak.Hash(input, digestBytes, rateBytes);
        }

        public static byte[] Hash384(ReadOnlySpan<byte> input)
        {
            const int digestBits = 384;

            // prepare all parameters compile-time
            const int digestBytes = digestBits / 8;
            const int capacityBytes = digestBytes * 2;
            const int rateBytes = Sponge.StateBytes - capacityBytes;

            return Keccak.Hash(input, digestBytes, rateBytes);
        }

        public static byte[] Hash512(ReadOnlySpan<byte> input)
        {
            const int digestBits = 512;

            // prepare all parameters compile-time
            const int digestBytes = digestBits / 8;
            const int capacityBytes = digestBytes * 2;
            const int rateBytes = Sponge.StateBytes - capacityBytes;

            return Keccak.Hash(input, digestBytes, rateBytes);
        }
    }
}