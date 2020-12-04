using MediatR;

namespace MediatRWithAspNetCore.Dto
{
    public class CreateCustomerCommand : IRequest<Result>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
    }
}
