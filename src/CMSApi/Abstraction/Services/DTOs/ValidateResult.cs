namespace CMSApi.Abstraction.Services.DTOs
{
    public class ValidateResult
    {
        public bool IsValid { get; set; } = false;

        public List<string> Errors { get; set; } = new List<string>();
    }
}
