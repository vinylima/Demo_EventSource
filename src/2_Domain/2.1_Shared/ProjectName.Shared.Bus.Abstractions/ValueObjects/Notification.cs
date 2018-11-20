
using System;

using ProjectName.Shared.Bus.Abstractions.Enums;

namespace ProjectName.Shared.Bus.Abstractions.ValueObjects
{
    public class Notification : Event
    {
        public string Code { get; private set; }
        public string Value { get; private set; }
        public NotificationType NotificationType { get; private set; }

        #region Constructors

        public Notification(Guid eventId, string code, string value, NotificationType notificationType)
            : base(eventId, EventType.Domain_Notification)
        {
            this.Code = code;
            this.Value = value;
            this.NotificationType = notificationType;
        }

        public Notification(string code, string value, NotificationType notificationType)
            : base(EventType.Domain_Notification)
        {
            this.Code = code;
            this.Value = value;
            this.NotificationType = notificationType;
        }

        public Notification(string value, NotificationType notificationType)
            : base(EventType.Domain_Notification)
        {
            this.Code = "";
            this.Value = value;
            this.NotificationType = notificationType;
        }

        public Notification(string code, string value)
            : base(EventType.Domain_Notification)
        {
            this.Code = code;
            this.Value = value;
            this.NotificationType = NotificationType.Notification;
        }

        #endregion
    }
}