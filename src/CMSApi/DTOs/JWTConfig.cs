namespace CMSApi.DTOs
{
    public class JWTConfig
    {
        public string Issuer { get; set; } = string.Empty;

        public string Audience { get; set; } = string.Empty;

        public string Key { get; set; } = string.Empty;
    }

    public static class AppSettingsSections
    {
        public const string JWT = "JWT";
    }
    public static class CustomizedUserClaimTypes
    {
        public const string Status = "user_status";
    }

}