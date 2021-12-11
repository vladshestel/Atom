using System;
using System.Numerics;

namespace Vee
{
    internal static partial class Permutations
    {
        internal static Span<ulong> Pi(Span<ulong> input)
        {
            var indexes = new int[] { 1, 6, 9, 22, 14, 20, 2, 12, 13, 19, 23, 15, 4, 24, 21, 8, 16, 5, 3, 18, 17, 11, 7, 10 };
            var buffer = input[1];

            for (var i = 0; i < indexes.Length - 1; i++) {
                input[indexes[i]] = input[indexes[i + 1]];
            }

            input[10] = buffer;

            return input;
        }
    }
}