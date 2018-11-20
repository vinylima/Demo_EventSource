
using System;

using ProjectName.Shared.Bus.Abstractions.Enums;

namespace ProjectName.Shared.Bus.Abstractions.ValueObjects
{
    public class Warning : Notification
    {
        #region Constructors

        public Warning(Guid eventId, string code, string value, NotificationType notificationType)
            : base(eventId, code, value, notificationType)
        {

        }

        public Warning(string code, string value, NotificationType notificationType)
            : base(code, value, notificationType)
        {

        }

        public Warning(string value, NotificationType notificationType)
            : base(value, notificationType)
        {

        }

        #endregion
    }
}