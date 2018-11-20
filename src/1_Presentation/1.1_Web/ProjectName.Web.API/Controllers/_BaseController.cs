
using System;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using ProjectName.Shared.Bus.Abstractions;

namespace ProjectName.Web.API.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IServiceBus ServiceBus;
        protected readonly INotificationStore NotificationStore;

        public BaseController(IServiceProvider serviceProvider)
        {
            this.ServiceBus = serviceProvider.GetService<IServiceBus>();
            this.NotificationStore = serviceProvider.GetService<INotificationStore>();
        }

        protected virtual bool ResultIsValid(bool includeNotifications = true, bool includeWarnings = false,
            bool includeSystemErros = true)
        {
            bool isValid;

            isValid = !this.NotificationStore.HasNotifications(includeNotifications, includeWarnings,
                includeSystemErros);

            return isValid;
        }

        new public IActionResult Response(object response = null)
        {
            if (this.ResultIsValid())
            {
                return Ok(new
                {
                    success = true,
                    response,
                    warnings = this.NotificationStore.GetWarnings().Select(e => new
                    {
                        e.EventId,
                        e.Code,
                        e.Value,
                        e.EventType,
                        e.NotificationType,
                        e.Time,
                    }),
                });
            }

            return BadRequest(new
            {
                success = false,

                error_codes = this.NotificationStore.GetSystemErrors()
                    .Select(e => e.Code),

                errors = this.NotificationStore.GetNotifications().Select(e => new
                {
                    e.EventId,
                    e.Code,
                    e.Value,
                    e.EventType,
                    e.NotificationType,
                    e.Time,
                }),

                warnings = this.NotificationStore.GetWarnings().Select(e => new
                {
                    e.EventId,
                    e.Code,
                    e.Value,
                    e.EventType,
                    e.NotificationType,
                    e.Time,
                }),
            });
        }

        new public IActionResult Response(TimeSpan executionTime ,object response = null)
        {
            if (this.ResultIsValid())
            {
                return Ok(new
                {
                    success = true,
                    response,
                    warnings = this.NotificationStore.GetWarnings().Select(e => new
                    {
                        e.EventId,
                        e.Code,
                        e.Value,
                        e.EventType,
                        e.NotificationType,
                        e.Time,
                    }),
                    time = string.Format("{0} ms", executionTime.TotalMilliseconds),
                });
            }

            return BadRequest(new
            {
                success = false,

                error_codes = this.NotificationStore.GetSystemErrors()
                    .Select(e => e.Code),

                errors = this.NotificationStore.GetNotifications().Select(e => new
                {
                    e.EventId,
                    e.Code,
                    e.Value,
                    e.EventType,
                    e.NotificationType,
                    e.Time,
                }),

                warnings = this.NotificationStore.GetWarnings().Select(e => new
                {
                    e.EventId,
                    e.Code,
                    e.Value,
                    e.EventType,
                    e.NotificationType,
                    e.Time,
                }),

                time = string.Format("{0} ms", executionTime.TotalMilliseconds),
            });
        }
    }
}