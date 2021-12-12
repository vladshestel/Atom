using System;

namespace Vee
{
    internal static partial class Permutations
    {
        internal static Span<ulong> Chi(Span<ulong> input)
        {
            for (var y = 0; y < 5; y++) {
                Span<ulong> buffer = stackalloc ulong[5];

                for (var x = 0; x < 5; x++) {
                    buffer[x] = input[x + 5 * y] ^ ((~input[(x + 1) % 5 + 5 * y]) & input[(x + 2) % 5 + 5 * y]);
                }

                buffer.CopyTo(
                    input.Slice(5 * y, 5)
                );
            }

            return input;
        }
    }
}