namespace Domain.Entities;
/*
 * User: This entity represents a user in the system.
 * It contains attributes such as the user's unique identifier, username, email address, first and last name,
 * and role (e.g., admin, regular user). In the context of the Task Management System,
 * the User entity is responsible for managing user profiles and authentication information.
 */
public class User
{
    public User(string userId)
    {
        UserId = userId;
    }

    public string UserId { get; init; }
    public string Username { get; init; }
    public string Email { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string UserRole { get; init; }
    
}