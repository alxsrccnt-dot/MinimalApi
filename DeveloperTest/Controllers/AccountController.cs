using Application.Users.Authentification;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperTest.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController(IMediator mediator) : Controller
{
	[AllowAnonymous]
	[HttpPost("login")]
	public async Task<IActionResult> Login(AuthenticationRequest request)
	{
		var token = await mediator.Send(new GetSecurityTokenCommand(request));
		return Ok(token);
	}
}