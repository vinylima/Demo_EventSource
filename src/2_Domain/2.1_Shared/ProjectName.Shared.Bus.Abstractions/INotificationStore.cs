
using System.Collections.Generic;

using ProjectName.Shared.Bus.Abstractions.ValueObjects;

namespace ProjectName.Shared.Bus.Abstractions
{
    public interface INotificationStore
    {
        IEnumerable<Notification> GetNotifications();

        IEnumerable<Warning> GetWarnings();

        IEnumerable<SystemError> GetSystemErrors();
        
        bool HasNotifications(bool includeNotifications = true, bool includeWarnings = false, bool includeSystemErros = true);
    }
}