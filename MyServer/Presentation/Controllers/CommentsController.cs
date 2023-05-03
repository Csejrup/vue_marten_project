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
    public async Task<ActionResult<Comment>> CreateComment([FromBody] CommentCreateModel commentCreateModel)
    {
        var comment = await _commentService.CreateCommentAsync(commentCreateModel.Content);
        return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateComment([FromBody] CommentCreateModel commentCreateModel)
    {
        await _commentService.UpdateCommentAsync(commentCreateModel.Id, commentCreateModel.Content);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteComment(Guid id)
    {
        await _commentService.DeleteCommentAsync(id);
        return NoContent();
    }
}

public class CommentCreateModel
{
    public Guid Id { get; private set; }
    public string Content { get; set; }
}