
using System;

using ProjectName.Shared.Bus.Abstractions.Enums;

namespace ProjectName.Shared.Bus.Abstractions.ValueObjects
{
    public class SystemError : Notification
    {
        #region Constructors

        public SystemError(Guid eventId, string code, string value, NotificationType notificationType)
            : base(eventId, code, value, notificationType)
        {
            
        }

        public SystemError(string code, string value, NotificationType notificationType)
            : base(code, value, notificationType)
        {
            
        }

        public SystemError(string value, NotificationType notificationType)
            : base(value, notificationType)
        {
            
        }

        #endregion
    }
}