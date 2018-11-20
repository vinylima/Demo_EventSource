
using System.Collections.Generic;

using ProjectName.Shared.Bus.Abstractions;
using ProjectName.Shared.Bus.Abstractions.ValueObjects;

namespace ProjectName.Shared.Bus.Core.Store
{
    public class NotificationStore : INotificationStore
    {
        private readonly List<Notification> _notifications;
        private readonly List<Warning> _warnings;
        private readonly List<SystemError> _systemErros;

        public NotificationStore(List<Notification> notifications, List<Warning> warnings,
            List<SystemError> systemErrors)
        {
            this._notifications = notifications;
            this._warnings = warnings;
            this._systemErros = systemErrors;
        }

        public IEnumerable<Notification> GetNotifications() => this._notifications;

        public IEnumerable<Warning> GetWarnings() => this._warnings;

        public IEnumerable<SystemError> GetSystemErrors() => this._systemErros;
        
        public bool HasNotifications(bool includeNotifications = true, bool includeWarnings = false, bool includeSystemErros = true)
        {
            bool hasNotifications = false;

            if (includeNotifications && !hasNotifications)
                hasNotifications = this._notifications?.Count > 0;

            if (includeWarnings && !hasNotifications)
                hasNotifications = this._warnings?.Count > 0;

            if (includeSystemErros && !hasNotifications)
                hasNotifications = this._systemErros?.Count > 0;
            
            return hasNotifications;
        }
    }
}