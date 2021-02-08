namespace Infrastructure.Service.Model
{
    public class ValidationResult
    {
        public bool IsValid { get; set; } = true;
        public string Message { get; set; }
    }
}