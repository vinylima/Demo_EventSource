
using System;

namespace ProjectName.Shared.Bus.Abstractions.ValueObjects
{
    public abstract class Command : ICommand
    {
        public Guid CommandId { get; private set; }
        public Guid AggregateId { get; protected set; }
        public DateTime Time { get; private set; }
        public Type ResourceName { get; private set; }

        protected Command()
        {
            this.CommandId = Guid.NewGuid();
            this.Time = DateTime.Now;
            this.ResourceName = this.GetType();
        }

        public Command(Guid aggregateId)
            : this()
        {
            this.AggregateId = aggregateId;
        }
    }

    public abstract class Command<TResponse> : ICommand<TResponse>
    {
        public Guid CommandId { get; private set; }
        public Guid AggregateId { get; private set; }
        public DateTime Time { get; private set; }
        public Type ResourceName { get; private set; }

        public TResponse Response { get; private set; }

        protected Command()
        {
            this.CommandId = Guid.NewGuid();
            this.Time = DateTime.Now;
            this.ResourceName = this.GetType();
        }

        public Command(Guid aggregateId)
            : this()
        {
            this.AggregateId = aggregateId;
        }

        public Command(TResponse response)
            : this()
        {
            this.Response = response;
        }

        public Command(Guid aggregateId, TResponse response)
            : this()
        {
            this.AggregateId = aggregateId;
            this.Response = response;
        }

        public void DefineResponse(TResponse response)
        {
            this.Response = response;
        }
    }
}
