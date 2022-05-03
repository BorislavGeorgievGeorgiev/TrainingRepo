using CookingRecipesSystem.Server.Application.Common.Interfaces;

using MediatR.Pipeline;

namespace Server.Application.Common.Behaviours
{
  public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    where TRequest : notnull
  {
    private readonly ILogger logger;
    private readonly ICurrentUserService currentUserService;
    private readonly IUserManagerService userManagerService;

    public RequestLogger(ILogger<TRequest> logger,
      ICurrentUserService currentUserService,
      IUserManagerService userManagerService)
    {
      this.logger = logger;
      this.currentUserService = currentUserService;
      this.userManagerService = userManagerService;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
      var requestName = typeof(TRequest).Name;
      var userId = this.currentUserService.GetUserId;
      var userName = await this.userManagerService.GetUserName(userId);

      this.logger.LogInformation(
                "CookingRecipesSystem Request: {Name} {@UserId} {@UserName} {@Request}",
                requestName,
                userId,
                userName ?? "Anonymous",
                request);
    }
  }
}