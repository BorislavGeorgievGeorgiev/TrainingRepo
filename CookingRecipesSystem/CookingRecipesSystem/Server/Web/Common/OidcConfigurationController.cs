﻿using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Mvc;

namespace CookingRecipesSystem.Server.Web.Common
{
  public class OidcConfigurationController : Controller
  {
    private readonly ILogger<OidcConfigurationController> _logger;

    public OidcConfigurationController(IClientRequestParametersProvider clientRequestParametersProvider, ILogger<OidcConfigurationController> logger)
    {
      this.ClientRequestParametersProvider = clientRequestParametersProvider;
      this._logger = logger;
    }

    public IClientRequestParametersProvider ClientRequestParametersProvider { get; }

    [HttpGet("_configuration/{clientId}")]
    public IActionResult GetClientRequestParameters([FromRoute] string clientId)
    {
      var parameters = this.ClientRequestParametersProvider.GetClientParameters(this.HttpContext, clientId);
      return this.Ok(parameters);
    }
  }
}
