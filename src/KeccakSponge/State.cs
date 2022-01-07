using System;

namespace Vee
{
    internal static class State
    {
        internal static (int blocksCount, int lastBlockBytes) CountBlocks(ReadOnlySpan<byte> input, int rate)
        {
            var count = input.Length / rate;
            var orphainBytes = input.Length % rate;

            return (
                blocksCount: count,
                lastBlockBytes: orphainBytes
            );
        }

        internal static void Absorb(Span<ulong> state, ReadOnlySpan<byte> block)
        {
            for (var i = 0; i < (block.Length / Sponge.BytesInLane); i++) {
                state[i] ^= BitHacker.ToState(block.Slice(i * Sponge.BytesInLane, Sponge.BytesInLane));
            }
        }

        internal static void AbsorbPadded(Span<ulong> state, ReadOnlySpan<byte> input, int rate, byte padding)
        {
            var lanesCount = (input.Length / Sponge.BytesInLane);

            for (var i = 0; i < lanesCount; i++) {
                state[i] ^= BitHacker.ToState(input.Slice(i * Sponge.BytesInLane, Sponge.BytesInLane));
            }

            Span<byte> lastInputLane = stackalloc byte[8];

            var remainingBytes = input.Slice(lanesCount * Sponge.BytesInLane);
            remainingBytes.CopyTo(lastInputLane);
            lastInputLane[remainingBytes.Length] ^= padding;

            state[lanesCount] ^= BitHacker.ToState(lastInputLane);

            var byted = BitHacker.ToPlainState(state);
            byted[rate - 1] ^= 0x80;
        }
    }
}