namespace PFC.Domain.Entities;

public class User : TrackableEntity<Guid>
{
    public string Name { get; set; }  = string.Empty;
    public string Email { get; set; }   = string.Empty;
    public string PasswordHash { get; set; }  = string.Empty;
    public string PasswordSalt { get; set; }   = string.Empty;
    public short PasswordIterations { get; set; }
    public List<Account> Accounts { get; set; } = [];
    public List<Transaction> Transactions { get; set; } = [];
}