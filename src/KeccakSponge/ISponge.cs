using System;

namespace Vee
{
    public interface ISponge
    {
        void Absorb(ReadOnlySpan<byte> input);
        byte[] Hash();
    }
}