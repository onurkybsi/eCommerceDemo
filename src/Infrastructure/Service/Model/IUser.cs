namespace Infrastructure.Service.Model
{
    public interface IUser
    {
        string Id { get; set; }
        string Email { get; set; }
        string HashedPassword { get; set; }
        string Token { get; set; }
    }
}