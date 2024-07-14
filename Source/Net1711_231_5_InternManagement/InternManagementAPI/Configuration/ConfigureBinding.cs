using InternManagementCommon;

namespace InternManagementWebAPI.Configuration
{
    public static class ConfigureBinding
    {
        public static void SettingsBinding(this IConfiguration configuration)
        {

            AppConfig.GoogleSetting = new GoogleSetting();

            configuration.Bind("GoogleSetting", AppConfig.GoogleSetting);
        } 
    }
}
