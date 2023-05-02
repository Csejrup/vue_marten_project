using Application.Services.ServiceInterfaces;
using Domain.Aggregates.Users;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _userService.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(Guid id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPost]
    public async Task<ActionResult<User>> RegisterUser([FromBody] string name, [FromBody] string email)
    {
        var user = await _userService.RegisterUserAsync(name, email);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] string name, [FromBody] string email)
    {
        await _userService.UpdateUserAsync(id, name, email);
        return NoContent();
    }
}