using System;
using static Vee.Permutations;

namespace Vee
{
    internal static class KeccakPermutation
    {
        private static int l = 6;
        private static int Nr = 12 + 2 * l;

        internal static Span<ulong> Iterate(Span<ulong> state)
        {
            for (var roundIndex = 12 + 2 * l - Nr; roundIndex <= 12 + 2 * l - 1; roundIndex++) {
                state = Round(state, roundIndex);
            }

            return state;
        }

        internal static Span<ulong> Round(Span<ulong> state, int roundIndex)
            => Iota(Chi(Pi(Rho(Tetha(state)))), roundIndex);
    }
}