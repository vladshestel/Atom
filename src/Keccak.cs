using System;
using static Vee.Permutations;

namespace Vee
{
    internal static class Keccak
    {
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