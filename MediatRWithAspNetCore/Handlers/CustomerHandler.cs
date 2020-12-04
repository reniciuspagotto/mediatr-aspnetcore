using MediatR;
using MediatRWithAspNetCore.Dto;
using MediatRWithAspNetCore.Entities;
using MediatRWithAspNetCore.Notifications;
using MediatRWithAspNetCore.Repository;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRWithAspNetCore.Handlers
{
    public class CustomerHandler :
        IRequestHandler<CreateCustomerCommand, Result>,
        IRequestHandler<GetCustomerQuery, Result>
    {
        private readonly IMediator _mediator;
        private readonly IMemoryCache _cache;
        private readonly EntityRepository _repository;

        public CustomerHandler(IMediator mediator, IMemoryCache cache, EntityRepository repository)
        {
            _mediator = mediator;
            _cache = cache;
            _repository = repository;
        }

        public async Task<Result> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer(request.FirstName, request.LastName, request.CellPhone, request.Email);
            _repository.Customers.Add(customer);

            _cache.Set(typeof(Customer).Name, _repository.Customers, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromSeconds(60)
            });

            var notification = new CreateCustomerNotification
            {
                FullName = $"{request.FirstName} {request.LastName}",
                CellPhone = request.CellPhone,
                Email = request.Email
            };

            await _mediator.Publish(notification);

            return new Result();
        }

        public Task<Result> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            if (_repository.Customers.Count > 0)
            {
                _cache.Set(typeof(Customer).Name, _repository.Customers, new MemoryCacheEntryOptions
                {
                    SlidingExpiration = TimeSpan.FromSeconds(30)
                });
            }

            return Task.FromResult(new Result { Data = _repository.Customers });
        }
    }
}
