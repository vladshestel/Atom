using System;

namespace Vee
{
    public static class Sha
    {
        public static byte[] Hash256(ReadOnlySpan<byte> input)
        {
            Span<ulong> state = stackalloc ulong[25];

            var rate = (1600 - 512) / 8;
            var (blocksCount, lastBlockBytes) = Sponge.CountBlocks(input, rate);

            // absorb input
            for (var blockIndex = 0; blockIndex < blocksCount; blockIndex++) {
                var block = input.Slice(blockIndex * rate, rate);

                Sponge.AbsorbBlock(state, block);
                KeccakRounds.Iterate(state);
            }

            // absorb last block 
            var lastBlock = input.Slice(blocksCount * rate, lastBlockBytes);
            Sponge.AbsorbPadded(state, lastBlock, rate);
            KeccakRounds.Iterate(state);

            // squeezing
            var result = new byte[256 / 8];
            
            var hashPortion = state.Slice(0, 256 / 8 / 8);
            BitHacker.ToPlainState(hashPortion).CopyTo(result);
            
            return result;
        }
    }
}