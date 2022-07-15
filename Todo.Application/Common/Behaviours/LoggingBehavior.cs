using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Todo.Application.Common.Interfaces;

namespace Todo.Application.Common.Behaviours
{
    public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest> where TRequest : class
    {
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;
        private readonly IIdentityService _identityService;

        public LoggingBehavior(ILogger<TRequest> logger, ICurrentUserService currentUserService, IIdentityService identityService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUserService.UserId;
            var userName = string.Empty;

            if(!string.IsNullOrEmpty(userId))
            {
                userName = await _identityService.GetUsernameAsync(userId);
            }

            _logger.LogInformation("Todo Request: {Name} {@UserId} {@UserName} {@Request}", requestName, userId, userName, request);
        }
    }
}
