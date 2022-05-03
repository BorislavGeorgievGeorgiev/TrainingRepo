using System.Diagnostics;

using CookingRecipesSystem.Server.Application.Common.Interfaces;

using MediatR;

namespace Server.Application.Common.Behaviours
{
  public class RequestPerformanceBehaviour<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
  {
    private readonly Stopwatch timer;
    private readonly ILogger<TRequest> logger;
    private readonly ICurrentUserService currentUserService;
    private readonly IUserManagerService userManagerService;

    public RequestPerformanceBehaviour(ILogger<TRequest> logger,
      ICurrentUserService currentUserService, IUserManagerService userManagerService)
    {
      this.timer = new Stopwatch();

      this.logger = logger;
      this.currentUserService = currentUserService;
      this.userManagerService = userManagerService;
    }

    public async Task<TResponse> Handle(TRequest request,
      CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
      this.timer.Start();

      var response = await next();

      this.timer.Stop();

      var elapsedMilliseconds = this.timer.ElapsedMilliseconds;

      if (elapsedMilliseconds <= 500)
      {
        return response;
      }

      var requestName = typeof(TRequest).Name;
      var userId = this.currentUserService.GetUserId;
      var userName = await this.userManagerService.GetUserName(userId);

      this.logger.LogWarning(
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