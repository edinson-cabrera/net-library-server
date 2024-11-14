namespace library_server.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string DNI { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Email { get; private set; }
    
    private User() { }

    public User(string firstName, string lastName, string dni, string phoneNumber, string email)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        DNI = dni;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}