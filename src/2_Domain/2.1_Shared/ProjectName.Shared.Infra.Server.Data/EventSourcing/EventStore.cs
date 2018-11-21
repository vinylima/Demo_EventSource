
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

using ProjectName.Shared.Bus.Abstractions;

namespace ProjectName.Shared.Infra.Server.Data.EventSourcing
{
    public class EventStore : IEventStore
    {
        private readonly ConcurrentQueue<Task> _jobs;
        private readonly SemaphoreSlim _signal;
        private CancellationToken _cancellationToken;

        public EventStore()
        {
            this._jobs = new ConcurrentQueue<Task>();
            this._signal = new SemaphoreSlim(0, 10);

            Task.Run(InitializeAsync);
        }

        public Task Queue(Task task)
        {
            this._jobs.Enqueue(task);
            this._signal.Release();

            return Task.CompletedTask;
        }

        public Task<bool> Store(IEvent @event)
        {
            return Task.FromResult(true);
        }

        public async Task InitializeAsync()
        {
            while(!this._cancellationToken.IsCancellationRequested)
            {
                if (this._jobs.IsEmpty)
                {
                    Thread.Sleep(new TimeSpan(0, 0, 1));
                    continue;
                }

                await this._signal.WaitAsync(this._cancellationToken);
                this._jobs.TryDequeue(out var workItem);
            }
        }

        public void Dispose()
        {
            this._cancellationToken = new CancellationToken(true);
            GC.SuppressFinalize(this);
        }
    }
}
