using MediatR;
using MediatRWithAspNetCore.RequestType;

namespace MediatRWithAspNetCore.Dto
{
    public class GetCustomerQuery : IRequest<Result>, ICacheRequest
    {
        public int Id { get; set; }
    }
}
