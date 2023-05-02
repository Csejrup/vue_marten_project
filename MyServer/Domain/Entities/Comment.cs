using System.ComponentModel.DataAnnotations;
using Marten.Events;

namespace Domain.Entities;
/*
 * Comment: This entity represents a comment added to a task.
 * It contains attributes such as the comment's unique identifier,
 * the associated task's identifier, the author's user identifier,
 * the comment's content, and the creation date. 
 */

 
public class Comment
    {
        public Guid Id { get; private set; }
        public Guid TaskId { get; private set; }
        public Guid AuthorUserId { get; private set; }
        public string Content { get; private set; }
        public DateTime CreationDate { get; private set; }

        // Private constructor for Marten
        private Comment() { }

        // Apply method for handling CommentCreated events
        public void Apply(CommentCreated e)
        {
            Id = e.Id;
            TaskId = e.TaskId;
            AuthorUserId = e.AuthorUserId;
            Content = e.Content;
            CreationDate = e.CreationDate;
        }

        // Apply method for handling CommentUpdated events
        private void Apply(CommentUpdated e)
        {
            Content = e.Content;
        }

        // Static method for creating a new Comment with a CommentCreated event
        public static Comment Create(Guid taskId, Guid authorUserId, string content)
        {
            var comment = new Comment();
            comment.Apply(new CommentCreated
            {
                Id = Guid.NewGuid(),
                TaskId = taskId,
                AuthorUserId = authorUserId,
                Content = content ?? throw new ArgumentNullException(nameof(content)),
                CreationDate = DateTime.UtcNow
            });

            return comment;
        }

        // Method for updating the content of the Comment with a CommentUpdated event
        public void UpdateContent(string newContent)
        {
            if (string.IsNullOrWhiteSpace(newContent))
            {
                throw new ArgumentException("Content cannot be null or empty.", nameof(newContent));
            }

            Apply(new CommentUpdated { Content = newContent });
        }

        // CommentCreated event class
        public class CommentCreated
        {
            public Guid Id { get; set; }
            public Guid TaskId { get; set; }
            public Guid AuthorUserId { get; set; }
            public string Content { get; set; }
            public DateTime CreationDate { get; set; }
        }

        // CommentUpdated event class
        public class CommentUpdated
        {
            public string Content { get; set; }
        }
    }
    