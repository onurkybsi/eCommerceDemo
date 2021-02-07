namespace Infrastructure.Service.Model
{
    public interface IUser
    {
        string Id { get; set; }
        string NameIdentifier { get; set; }
        string HashedPassword { get; set; }
        string Token { get; set; }
    }
}