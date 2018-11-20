
using System;
using System.Runtime.CompilerServices;

namespace ProjectName.Shared.Abstractions.Application
{
    public interface IBaseViewModel : IDisposable
    {
        bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null);
    }
}