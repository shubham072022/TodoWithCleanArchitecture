using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Todo.Application.Common.Interfaces;

namespace Todo.Application.Common.Behaviours
{
    public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;

        public PerformanceBehavior(ILogger<TRequest> logger, ICurrentUserService currentUserService, IIdentityService identityService)
        {
            _timer = new Stopwatch();

            _logger = logger;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var ellapsedMilliseconds = _timer.ElapsedMilliseconds;

            if(ellapsedMilliseconds > 500)
            {
                var requestName = typeof(TRequest).Name;
                var userId = _currentUserService.UserId;
                var userName = string.Empty;

                if(!string.IsNullOrEmpty(userId))
                {
                    userName = await _identityService.GetUsernameAsync(userId);
                }

                _logger.LogWarning("Todo Long Running Request: {Name} ({EllapsedMilliseconds} milliseconds) {@UserId} {@UserName} {@Request}"
                    , requestName, ellapsedMilliseconds, userId, userName, request);
            }
            return response;
        }
    }
}
