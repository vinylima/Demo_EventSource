
using System;

namespace ProjectName.Shared.Abstractions.Domain
{
    public interface IModel : IDisposable
    {
        Guid Id { get; }
        Guid GetId();
    }
}