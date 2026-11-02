namespace Books.Application
{
    public class ValidationResponse
    {
        public bool IsValid { get; set; } = true;
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
    }
}
