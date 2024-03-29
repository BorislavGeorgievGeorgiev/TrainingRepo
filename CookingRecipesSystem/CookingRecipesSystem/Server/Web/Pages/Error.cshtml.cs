﻿using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookingRecipesSystem.Server.Web.Pages
{
  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  [IgnoreAntiforgeryToken]
  public class ErrorModel : PageModel
  {
    private readonly ILogger<ErrorModel> _logger;

    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);


    public ErrorModel(ILogger<ErrorModel> logger)
    {
      this._logger = logger;
    }

    public void OnGet()
    {
      this.RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier;
    }
  }
}