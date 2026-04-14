namespace PrintsControl.Domain.Entities;
public sealed class User : BaseEntity
{

    public string Email { get; private set; }
    public string Password { get; private set; }
    
    
    public User(string email, string password)
    {
        SetEmail(email);
        SetPassword(password);

        Email = email;
        Password = password;
    }
    public void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("O email é obrigatório.", nameof(email));
        
        Email = email;
    }

    public void SetPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("A senha é obrigatorio.", nameof(password));
        
        Password = password;
    }

}