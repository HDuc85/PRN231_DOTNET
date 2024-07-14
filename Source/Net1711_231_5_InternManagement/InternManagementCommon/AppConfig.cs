namespace InternManagementCommon
{
    public class AppConfig
    {
        public static GoogleSetting GoogleSetting { get; set; } = null!;
    }
    public class GoogleSetting
    {
        public string ClientId { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
        public string CredentialFile { get; set; } = string.Empty;
        public string StorageBucket { get; set; } = string.Empty;
    }
}
