using System;

namespace Vee
{
    internal class Sponge
    {
        private const int BytesInLane = 8;

        public static void AbsorbPadded(Span<ulong> state, ReadOnlySpan<byte> input, int rate)
        {
            var lanesCount = (input.Length / BytesInLane);

            for (var i = 0; i < lanesCount; i++) {
                state[i] ^= BitHacker.ToState(input.Slice(i * BytesInLane, BytesInLane));
            }

            Span<byte> lastInputLane = stackalloc byte[8];

            var remainingBytes = input.Slice(lanesCount * BytesInLane);
            remainingBytes.CopyTo(lastInputLane);

            lastInputLane[remainingBytes.Length] ^= 0x06;
            state[lanesCount] ^= BitHacker.ToState(lastInputLane);

            lastInputLane.Clear();
            lastInputLane[BytesInLane - 1] = 0x80;

            state[rate / 8 - 1] ^= BitHacker.ToState(lastInputLane);
        }
    }
}