using System;
using System.Numerics;

namespace Vee
{
    internal static partial class Permutations
    {
        internal static Span<ulong> Rho(Span<ulong> input)
        {
            var rotations = new [] { 
                0, 1, 190, 28, 91,
                36, 300, 6, 55, 276,
                3, 10, 171, 153, 231,
                105, 45, 15, 21, 136,
                210, 66, 253, 120, 78
            };

            for (var y = 0; y < 5; y++) {
                for (var x = 0; x < 5; x++) {
                    var spins = rotations[x + y * 5];
                    var lane = input[x + 5 * y];

                    input[x + 5 * y] = ((lane << spins) | (lane >> 64 - spins));
                }
            }
            return input;
        }
    }
}