using System;

namespace Vee
{
    public static class Sha
    {
        public static ReadOnlySpan<byte> Hash256(ReadOnlySpan<byte> input)
        {
            // absorb input
            // apply padding
            return Array.Empty<byte>();
        }

        public static ReadOnlySpan<byte> Hash512(ReadOnlySpan<byte> input)
        {
            return Array.Empty<byte>();
        }
    }
}