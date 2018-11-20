
using System;

namespace ProjectName.Shared.Domain.Abstractions
{
    public interface IModel : IDisposable
    {
        Guid Id { get; }
        Guid GetId();
    }
}