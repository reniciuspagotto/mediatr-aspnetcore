using MediatR;
using MediatRWithAspNetCore.Notifications;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRWithAspNetCore.EventHandler
{
    public class CustomerSmsEventHandler : INotificationHandler<CreateCustomerNotification>
    {
        public Task Handle(CreateCustomerNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"SMS enviado para {notification.FullName} responsável pelo número {notification.CellPhone}");
            return Task.FromResult(0);
        }
    }
}
