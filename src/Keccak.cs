using System;

namespace Vee
{
    internal static class Keccak
    {
        internal static byte[] Hash(ReadOnlySpan<byte> input, int digestBytes, int rateBytes, byte padding)
        {
            var result = new byte[digestBytes];

            Hash(input, digestBytes, rateBytes, padding, result);

            return result;
        }

        internal static void Hash(ReadOnlySpan<byte> input, int digestBytes, int rateBytes, byte padding, Span<byte> result)
        {
            Span<ulong> state = stackalloc ulong[Sponge.StateWords];

            var (blocksCount, lastBlockBytes) = State.CountBlocks(input, rateBytes);

            // absorb input
            for (var blockIndex = 0; blockIndex < blocksCount; blockIndex++) {
                var block = input.Slice(blockIndex * rateBytes, rateBytes);

                Sponge.AbsorbBlock(state, block);
            }

            // absorb last block 
            var lastBlock = input.Slice(blocksCount * rateBytes, lastBlockBytes);
            Sponge.AbsorbPadded(state, lastBlock, rateBytes, padding);

            // squeezing
            Sponge.Squeeze(state, result, rateBytes, digestBytes);
        }
    }
}