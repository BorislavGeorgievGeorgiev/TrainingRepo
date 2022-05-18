using System.Diagnostics;

using CookingRecipesSystem.Server.Application.Common.Interfaces;

using MediatR;

namespace CookingRecipesSystem.Server.Application.Common.Behaviours
{
  public class RequestPerformanceBehaviour<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
  {
    private readonly Stopwatch _timer;
    private readonly ILogger<TRequest> _logger;
    private readonly ICurrentUserService _currentUserService;
    private readonly IUserManagerService _userManagerService;

    public RequestPerformanceBehaviour(ILogger<TRequest> logger,
      ICurrentUserService currentUserService, IUserManagerService userManagerService)
    {
      this._timer = new Stopwatch();

      this._logger = logger;
      this._currentUserService = currentUserService;
      this._userManagerService = userManagerService;
    }

    public async Task<TResponse> Handle(TRequest request,
      CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
      this._timer.Start();

      var response = await next();

      this._timer.Stop();

      var elapsedMilliseconds = this._timer.ElapsedMilliseconds;

      if (elapsedMilliseconds <= 500)
      {
        return response;
      }

      var requestName = typeof(TRequest).Name;
      var userId = this._currentUserService.GetUserId;
      var userName = await this._userManagerService.GetUserName(userId);

      this._logger.LogWarning(
          "CookingRecipesSystem Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@Request}",
          requestName,
          elapsedMilliseconds,
          userId,
          userName ?? "Anonymous",
          request);

      return response;
    }
  }
}