using Application.Authentification;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperTest.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController(IMediator mediator) : Controller
{
	[HttpPost("login")]
	public async Task<IActionResult> Login(AuthenticationRequest request)
	{
		string token = await mediator.Send(new GetSecurityTokenCommand(request));

		return string.IsNullOrEmpty(token) ? Ok(token) : BadRequest();
	}
}