using MediatR;

namespace MediatRWithAspNetCore.Notifications
{
    public class CreateCustomerNotification : INotification
    {
        public string FullName { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
    }
}
