using System;

namespace Vee
{
    internal class Sponge
    {
        internal const int StateBits = 1600;
        internal const int StateBytes = StateBits / 8;
        internal const int StateWords = StateBytes / 8;
        internal const int ShaPadding = 0x06;
        internal const int ShakePadding = 0x1f;
        
        private const int BytesInLane = 8;

        public static (int blocksCount, int lastBlockBytes) CountBlocks(ReadOnlySpan<byte> input, int width)
        {
            var count = input.Length / width;
            var orphainBytes = input.Length % width;

            return (
                blocksCount: count,
                lastBlockBytes: orphainBytes
            );
        }

        public static void AbsorbBlock(Span<ulong> state, ReadOnlySpan<byte> block)
        {
            for (var i = 0; i < (block.Length / BytesInLane); i++) {
                state[i] ^= BitHacker.ToState(block.Slice(i * BytesInLane, BytesInLane));
            }
        }

        public static void AbsorbPadded(Span<ulong> state, ReadOnlySpan<byte> input, int rate, byte padding)
        {
            var lanesCount = (input.Length / BytesInLane);

            for (var i = 0; i < lanesCount; i++) {
                state[i] ^= BitHacker.ToState(input.Slice(i * BytesInLane, BytesInLane));
            }

            Span<byte> lastInputLane = stackalloc byte[8];

            var remainingBytes = input.Slice(lanesCount * BytesInLane);
            remainingBytes.CopyTo(lastInputLane);
            lastInputLane[remainingBytes.Length] ^= padding;

            state[lanesCount] ^= BitHacker.ToState(lastInputLane);

            var byted = BitHacker.ToPlainState(state);
            byted[rate - 1] ^= 0x80;
        }
    }
}