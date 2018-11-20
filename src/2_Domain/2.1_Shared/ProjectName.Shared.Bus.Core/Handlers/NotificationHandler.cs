
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using ProjectName.Shared.Bus.Abstractions;
using ProjectName.Shared.Bus.Abstractions.Enums;
using ProjectName.Shared.Bus.Abstractions.ValueObjects;

namespace ProjectName.Shared.Bus.Core.Handlers
{
    public class NotificationHandler : IEventHandler<Notification>
    {
        private readonly List<Notification> _notifications;
        private readonly List<Warning> _warnings;
        private readonly List<SystemError> _systemErros;

        public NotificationHandler(List<Notification> notifications, List<Warning> warnings,
            List<SystemError> systemErrors)
        {
            this._notifications = notifications;
            this._warnings = warnings;
            this._systemErros = systemErrors;
        }

        public Task Handle(Notification notification, CancellationToken cancellationToken)
        {
            switch (notification.NotificationType)
            {
                case NotificationType.Notification:
                    this._notifications.Add(notification);
                    break;

                case NotificationType.Warning:
                    this._warnings.Add(notification as Warning);
                    break;

                case NotificationType.SystemError:
                    this._systemErros.Add(notification as SystemError);
                    break;
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}