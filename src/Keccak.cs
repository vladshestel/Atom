using System;
using static Vee.Permutations;

namespace Vee
{
    internal static class Keccak
    {
        internal static byte[] Hash(ReadOnlySpan<byte> input, int digestBytes, int rateBytes)
        {
            var digestWords = digestBytes >> 3;

            Span<ulong> state = stackalloc ulong[Sponge.StateWords];

            var (blocksCount, lastBlockBytes) = Sponge.CountBlocks(input, rateBytes);

            // absorb input
            for (var blockIndex = 0; blockIndex < blocksCount; blockIndex++) {
                var block = input.Slice(blockIndex * rateBytes, rateBytes);

                Sponge.AbsorbBlock(state, block);
                KeccakRounds.Iterate(state);
            }

            // absorb last block 
            var lastBlock = input.Slice(blocksCount * rateBytes, lastBlockBytes);
            Sponge.AbsorbPadded(state, lastBlock, rateBytes);
            KeccakRounds.Iterate(state);

            // squeezing
            var result = new byte[digestBytes];
            
            var hashPortion = state.Slice(0, digestWords);
            BitHacker.ToPlainState(hashPortion).CopyTo(result);

            return result;
        }

        internal static Span<ulong> Apply(Span<ulong> state)
        {
            for (var roundIndex = 12 + 2 * 6 - 24; roundIndex <= 12 + 2 * 6 - 1; roundIndex++) {
                state = Round(state, roundIndex);
            }

            return state;
        }

        internal static Span<ulong> Round(Span<ulong> state, int roundIndex)
            => Iota(Chi(Pi(Rho(Tetha(state)))), roundIndex);
    }
}