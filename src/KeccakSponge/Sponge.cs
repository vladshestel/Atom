using System;

namespace Vee
{
    internal class Sponge : ISponge
    {
        internal const int StateBits = 1600;
        internal const int StateBytes = StateBits / 8;
        internal const int StateWords = StateBytes / 8;
        internal const int ShaPadding = 0x06;
        internal const int ShakePadding = 0x1f;
        
        internal const int BytesInLane = 8;

        private readonly ulong[] _state;
        private readonly byte[] _queue;

        private readonly int _digestBytes;
        private readonly int _rateBytes;
        private readonly byte _padding;
        
        private int _queueLength;

        public Sponge(int digestBytes, int rateBytes,  byte padding)
        {
            _state = new ulong[Sponge.StateWords];
            _queue = new byte[rateBytes];

            _digestBytes = digestBytes;
            _rateBytes = rateBytes;
            _padding = padding;

            _queueLength = 0;
        }

        internal static void AbsorbBlock(Span<ulong> state, ReadOnlySpan<byte> block)
        {
            State.Absorb(state, block);
            KeccakPermutation.Iterate(state);
        }

        internal static void AbsorbPadded(Span<ulong> state, ReadOnlySpan<byte> input, int rate, byte padding)
        {
            State.AbsorbPadded(state, input, rate, padding);
            KeccakPermutation.Iterate(state);
        }

        internal static void Squeeze(Span<ulong> state, Span<byte> result, int rateBytes, int digestBytes)
        {
            var bytedState = BitHacker.ToPlainState(state);

            var minimal = Math.Min(rateBytes, digestBytes);
            
            var hashPortion = bytedState.Slice(0, minimal);
            hashPortion.CopyTo(result);
        }

        public void Absorb(ReadOnlySpan<byte> input)
        {
            if (input.Length + _queueLength >= _rateBytes) {
                if (_queue.Length == 0) {
                    AbsorbToState(input);
                } else {
                    var enqueueSize = _rateBytes - _queueLength;
                    var partForQueue = input.Slice(0, enqueueSize);
                    Enqueue(partForQueue);

                    var remainingInput = input.Slice(enqueueSize);
                    AbsorbToState(remainingInput);
                }
            } else {
                Enqueue(input);
            }
        }

        private void AbsorbToState(ReadOnlySpan<byte> input)
        {
            var queuedSize = 0;
            var remainingData = input.Length;

            while (remainingData >= _rateBytes) {
                var block = input.Slice(queuedSize, _rateBytes);

                Sponge.AbsorbBlock(_state, block);

                queuedSize += _rateBytes;
                remainingData -= _rateBytes;
            }

            if (remainingData != 0) {
                var block = input.Slice(queuedSize);
                Enqueue(block);
            }
        }

        private void Enqueue(ReadOnlySpan<byte> input)
        {
            var destination = _queue.AsSpan().Slice(_queueLength, input.Length);
            input.CopyTo(destination);

            _queueLength += input.Length;

            if (_queueLength == _rateBytes) {
                FlushQueue();
            }
        }

        private void FlushQueue()
        {
            Sponge.AbsorbBlock(_state, _queue);

            _queueLength = 0;
        }

        public byte[] Hash()
        {
            var lastBlock = _queue.AsSpan().Slice(0, _queueLength);
            Sponge.AbsorbPadded(_state, lastBlock, _rateBytes, _padding);
            
            var result = new byte[_digestBytes];

            Sponge.Squeeze(_state, result, _rateBytes, _digestBytes);

            return result;
        }
    }
}