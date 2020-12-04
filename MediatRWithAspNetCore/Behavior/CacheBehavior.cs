using MediatR;
using MediatRWithAspNetCore.Entities;
using MediatRWithAspNetCore.RequestType;
using Microsoft.Extensions.Caching.Memory;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRWithAspNetCore.Behavior
{
    public class CacheBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICacheRequest
    {
        private readonly IMemoryCache _cache;

        public CacheBehavior(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var contextName = GetContextRequest(typeof(TRequest).Name);
            var cachedResponse = _cache.Get(contextName);

            if (cachedResponse != null)
                return (TResponse)await Task.FromResult(cachedResponse);

            return await next();
        }

        private string GetContextRequest(string requestObjectName)
        {
            if (requestObjectName.Contains(typeof(Customer).Name))
            {
                return typeof(Customer).Name;
            }

            return string.Empty;
        }
    }
}
