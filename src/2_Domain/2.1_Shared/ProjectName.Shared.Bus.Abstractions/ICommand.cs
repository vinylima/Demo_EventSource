
using MediatR;

namespace ProjectName.Shared.Bus.Abstractions
{
    public interface ICommand : ICommand<bool>
    {

    }

    public interface ICommand<TResponse> : IRequest<TResponse>
    {

    }
}
