
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjectName.Shared.Abstractions.Application
{
    public abstract class BaseViewModel<TViewModel> : IBaseViewModel where TViewModel : IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            return true;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}