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
    public async Task<ActionResult<User>> RegisterUser([FromBody] CreateUserModel createUserModel)
    {
        var user = await _userService.RegisterUserAsync(createUserModel.Name, createUserModel.Email);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser([FromBody] CreateUserModel createUserModel)
    {
        await _userService.UpdateUserAsync(createUserModel.Id, createUserModel.Name, createUserModel.Email);
        return NoContent();
    }
}

public class CreateUserModel
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public string Email { get; set; }
}