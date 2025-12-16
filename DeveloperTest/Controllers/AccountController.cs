using Application.Users.Authentification;
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
		try
		{
			var token = await mediator.Send(new GetSecurityTokenCommand(request));
			return Ok(token);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}