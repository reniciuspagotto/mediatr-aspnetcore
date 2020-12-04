using MediatR;
using MediatRWithAspNetCore.Notifications;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRWithAspNetCore.EventHandler
{
    public class CustomerEmailEventHandler : INotificationHandler<CreateCustomerNotification>
    {
        public Task Handle(CreateCustomerNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Email enviado para {notification.FullName} responsável pelo email {notification.Email}");
            return Task.FromResult(0);
        }
    }
}
