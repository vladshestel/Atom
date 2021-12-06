using System;
using System.Numerics;

namespace Vee
{
    internal static partial class Permutations
    {
        internal static Span<ulong> Tetha(Span<ulong> input)
        {
            // todo check that the cpu vector length equals to 4
            // calculate first 4 columns sets
            var vector = new Vector<ulong>(
                input.Slice(0, 4)
            );

            for (var i = 1; i < 5; i++)
            {
                var multiplier = new Vector<ulong>(
                    input.Slice(start: i * 5, length: 4)
                );

                vector = Vector.Xor<ulong>(vector, multiplier);
            }

            // calculate last column set
            var lastColumns = input[4] ^ input[9] ^ input[14] ^ input[19] ^ input[24];

            // calculate parities of two columns sets
            Span<ulong> columnsParities = stackalloc ulong[]
            {
                lastColumns ^ ((vector[1] << 1) | (vector[1] >> 63)),     // d[0] = c[4] ^ c[1].rol()
                vector[0]   ^ ((vector[2] << 1) | (vector[2] >> 63)),     // d[1] = c[0] ^ c[2].rol()
                vector[1]   ^ ((vector[3] << 1) | (vector[3] >> 63)),     // d[2] = c[1] ^ c[3].rol()
                vector[2]   ^ ((lastColumns << 1) | (lastColumns >> 63)), // d[3] = c[2] ^ c[4].rol()
                vector[3]   ^ ((vector[0] << 1) | (vector[0] >> 63))      // d[4] = c[3] ^ c[0].rol()
            };

            // calculate result state
            for (var x = 0; x < 5; x++) {
                for (var y = 0; y < 5; y++) {
                    input[x + y * 5] = input[x + y * 5] ^ columnsParities[x];
                }
            }
            
            return input;
        }
    }
}