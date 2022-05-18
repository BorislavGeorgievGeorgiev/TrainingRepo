using CookingRecipesSystem.Server.Application.Common.Interfaces;

using MediatR.Pipeline;

namespace CookingRecipesSystem.Server.Application.Common.Behaviours
{
  public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    where TRequest : notnull
  {
    private readonly ILogger _logger;
    private readonly ICurrentUserService _currentUserService;
    private readonly IUserManagerService _userManagerService;

    public RequestLogger(ILogger<TRequest> logger,
      ICurrentUserService currentUserService,
      IUserManagerService userManagerService)
    {
      this._logger = logger;
      this._currentUserService = currentUserService;
      this._userManagerService = userManagerService;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
      var requestName = typeof(TRequest).Name;
      var userId = this._currentUserService.GetUserId;
      var userName = await this._userManagerService.GetUserName(userId);

      this._logger.LogInformation(
                "CookingRecipesSystem Request: {Name} {@UserId} {@UserName} {@Request}",
                requestName,
                userId,
                userName ?? "Anonymous",
                request);
    }
  }
}