using System;
using System.Runtime.CompilerServices;

namespace Vee
{
    internal static class BitHacker
    {
        public unsafe static Span<ulong> ToStateArray(ReadOnlySpan<byte> input)
        {
            fixed (byte* pointer = input)
            {
                return new Span<ulong>(pointer, input.Length / 8);
            }
        }

        public unsafe static Span<byte> ToPlainState(Span<ulong> input)
        {
            fixed (ulong* pointer = input)
            {
                return new Span<byte>(pointer, input.Length * 8);
            }
        }

        public unsafe static ulong ToState(ReadOnlySpan<byte> input) {
            fixed (byte* pointer = input) {
                var longed = (ulong*) pointer;

                return *longed;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong RotateLeft(ulong input, int spins)
            => (input << spins) | (input >> 64 - spins);
    }
}