namespace Domain.Entities;
/*
 * User: This DTO represents a user in the system.
 * It contains attributes such as the user's unique identifier, username, email address, first and last name,
 * and role (e.g., admin, regular user). In the context of the Task Management System,
 * the User entity is responsible for managing user profiles and authentication information.
 */
public class UserDto
{
    public UserDto(string userId, string username, string email, string firstName, string lastName, string userRole)
    {
        UserId = userId;
        Username = username;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        UserRole = userRole;
    }

    public string UserId { get; init; }
    public string Username { get; init; }
    public string Email { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string UserRole { get; init; }
    
}