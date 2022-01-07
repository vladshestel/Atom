using System;

namespace Vee
{
    public static class Sha
    {
        public static byte[] Hash224(ReadOnlySpan<byte> input)
        {
            const int digestBits = 224;

            // prepare all parameters compile-time
            const int digestBytes = digestBits / 8;
            const int capacityBytes = digestBytes * 2;
            const int rateBytes = Sponge.StateBytes - capacityBytes;

            return Keccak.Hash(input, digestBytes, rateBytes, Sponge.ShaPadding);
        }

        public static byte[] Hash256(ReadOnlySpan<byte> input)
        {
            const int digestBits = 256;

            // prepare all parameters compile-time
            const int digestBytes = digestBits / 8;
            const int capacityBytes = digestBytes * 2;
            const int rateBytes = Sponge.StateBytes - capacityBytes;

            return Keccak.Hash(input, digestBytes, rateBytes, Sponge.ShaPadding);
        }

        public static ISponge CreateSha256Sponge()
        {
            const int digestBits = 256;

            // prepare all parameters compile-time
            const int digestBytes = digestBits / 8;
            const int capacityBytes = digestBytes * 2;
            const int rateBytes = Sponge.StateBytes - capacityBytes;

            return new Sponge(digestBytes, rateBytes, Sponge.ShaPadding);
        }

        public static byte[] Hash384(ReadOnlySpan<byte> input)
        {
            const int digestBits = 384;

            // prepare all parameters compile-time
            const int digestBytes = digestBits / 8;
            const int capacityBytes = digestBytes * 2;
            const int rateBytes = Sponge.StateBytes - capacityBytes;

            return Keccak.Hash(input, digestBytes, rateBytes, Sponge.ShaPadding);
        }

        public static byte[] Hash512(ReadOnlySpan<byte> input)
        {
            const int digestBits = 512;

            // prepare all parameters compile-time
            const int digestBytes = digestBits / 8;
            const int capacityBytes = digestBytes * 2;
            const int rateBytes = Sponge.StateBytes - capacityBytes;

            return Keccak.Hash(input, digestBytes, rateBytes, Sponge.ShaPadding);
        }

        public static byte[] ExtendableHash(ReadOnlySpan<byte> input, int outputBytes)
        {
            // todo assert output bytes length

            const int capacityBits = 256;
            const int capacityBytes = capacityBits / 8;
            const int rateBytes = Sponge.StateBytes - capacityBytes;

            return Keccak.Hash(input, outputBytes, rateBytes, Sponge.ShakePadding);
        }

        public static byte[] ExtendableHashStrong(ReadOnlySpan<byte> input, int outputBytes)
        {
            // todo assert output bytes length

            const int capacityBits = 512;
            const int capacityBytes = capacityBits / 8;
            const int rateBytes = Sponge.StateBytes - capacityBytes;

            return Keccak.Hash(input, outputBytes, rateBytes, Sponge.ShakePadding);
        }
    }
}