namespace PrintsControl.Domain.Entities;
public sealed class User : BaseEntity
{
    private string _email;
    private string _password;
        public List<Transaction> Transactions { get; private set; }

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
        SetEmail(email);
        SetPassword(password);
        Transactions = new List<Transaction>();
    }
    public void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("O email é obrigatório.", nameof(email));
        
        _email = email;
    }

    public void SetPassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("A senha é obrigatorio.", nameof(password));
        
        
        _password = password;
    }

    public override string ToString()
    {
        return $"Email : {_email} | Senha: {_password}";
    }
}