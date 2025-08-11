namespace PrintsControl.Domain.Entities;
public sealed class User : BaseEntity
{
    private string _email;
    private string _password;
    
    public List<Transaction> Transactions { get; set; }

    public string Email
    {
        get => _email;
        set => _email = value;
    }

    public string Password
    {
        get => _password;
        set => _password = value;
    }

    public User(string email, string password)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("O email é obrigatório.", nameof(email));

        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("A senha é obrigatorio.", nameof(password));
        
        _email = email;
        _password = password;
        Transactions = new List<Transaction>();
    }

    public override string ToString()
    {
        return $"Email : {_email} | Senha: {_password}";
    }
}