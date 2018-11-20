
using System.Collections.Generic;
using System.Reflection;

using MediatR;
using Microsoft.Extensions.DependencyInjection;

using ProjectName.Shared.Bus.Abstractions;
using ProjectName.Shared.Bus.Abstractions.ValueObjects;
using ProjectName.Shared.Bus.Core;
using ProjectName.Shared.Bus.Core.Handlers;
using ProjectName.Shared.Bus.Core.Store;

namespace ProjectName.Shared.Infra.IoC
{
    public static class ServiceBusBootStrapper
    {
        public static void AddServiceBusModule<TStartup>(this IServiceCollection services)
        {
            services.AddScoped<List<Notification>>();
            services.AddScoped<List<Warning>>();
            services.AddScoped<List<SystemError>>();

            services.AddMediatR(typeof(TStartup).GetTypeInfo().Assembly);

            // Add Service Bus Core Service
            services.AddScoped<IServiceBus, ServiceBus>();

            // Add Notification Store of Domain Notifications, Warnings and System Errors.
            services.AddScoped<INotificationStore, NotificationStore>();
            services.AddScoped<INotificationHandler<Notification>, NotificationHandler>();
        }
    }
}