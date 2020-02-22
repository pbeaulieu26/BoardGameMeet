using System;
using System.Threading;
using System.Threading.Tasks;

namespace BoardGameMeet.Helpers
{
    /// <summary>
    /// This class allows the execution of a single task at a time, cancelling the previous running task if specified.
    /// </summary>

    public class UniqueExecutionTaskQueue
    {
        private readonly SemaphoreSlim _executionLock;
        private readonly SemaphoreSlim _cancellationLock;
        private int _queuedTaskCounter;

        private CancellationTokenSource _cancellationTokenSource;

        public UniqueExecutionTaskQueue()
        {
            _executionLock = new SemaphoreSlim(1, 1);
            _cancellationLock = new SemaphoreSlim(1, 1);
            _cancellationTokenSource = new CancellationTokenSource();
            _queuedTaskCounter = 0;
        }

        public async Task ExecuteAsync(Func<CancellationToken, Task> scheduleFunc)
        {
            Interlocked.Increment(ref _queuedTaskCounter);

            try
            {
                var cancellationTokenSource = new CancellationTokenSource();

                await _cancellationLock.WaitAsync();

                try
                {
                    _cancellationTokenSource.Cancel();
                    _cancellationTokenSource = cancellationTokenSource;
                }
                finally
                {
                    _cancellationLock.Release();
                }

                await _executionLock.WaitAsync(cancellationTokenSource.Token);

                try
                {
                    await (scheduleFunc?.Invoke(cancellationTokenSource.Token) ?? Task.FromResult(0));
                }
                finally
                {
                    _executionLock.Release();
                }
            }
            finally
            {
                Interlocked.Decrement(ref _queuedTaskCounter);
            }
        }

        public async Task CancelAsync()
        {
            await _cancellationLock.WaitAsync();

            try
            {
                _cancellationTokenSource.Cancel();
            }
            finally
            {
                _cancellationLock.Release();
            }
        }

        public bool IsExecuting()
        {
            return _queuedTaskCounter > 0;
        }
    }
}
