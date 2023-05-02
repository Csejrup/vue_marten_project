using Application.Services.ServiceInterfaces;
using Domain.Aggregates.Comments;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentsController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet]
    public async Task<IEnumerable<Comment>> GetAllComments()
    {
        return await _commentService.GetAllCommentsAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Comment>> GetComment(Guid id)
    {
        var comment = await _commentService.GetCommentByIdAsync(id);

        if (comment == null)
        {
            return NotFound();
        }

        return comment;
    }

    [HttpPost]
    public async Task<ActionResult<Comment>> CreateComment([FromBody] string content)
    {
        var comment = await _commentService.CreateCommentAsync(content);
        return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateComment(Guid id, [FromBody] string content)
    {
        await _commentService.UpdateCommentAsync(id, content);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteComment(Guid id)
    {
        await _commentService.DeleteCommentAsync(id);
        return NoContent();
    }
}