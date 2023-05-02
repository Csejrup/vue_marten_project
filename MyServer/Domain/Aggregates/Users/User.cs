using Domain.Base;

namespace Domain.Aggregates.Users;

public class User : BaseAggregate
{
    public string? Email { get; private set; }
    public string? Name { get; private set; }

    public User(UserRegistered @event)
    {
        Apply(@event);
    }
/*
      public void Update(string name, string email)
    {
        var @event = new UserUpdated { Id = Id, Name = name, Email = email };
        RaiseEvent(@event);
        Apply(@event);
    }
  */  
    public void Apply(UserRegistered @event)
    {
        Id = @event.Id;
        Email = @event.Email;
        Name = @event.Name;
    }
}