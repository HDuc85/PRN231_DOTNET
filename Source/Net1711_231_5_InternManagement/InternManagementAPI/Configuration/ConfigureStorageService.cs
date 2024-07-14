using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using InternManagementCommon;

namespace InternManagementWebAPI.Configuration
{
    public static class ConfigureStorageServices
    {
        public static IServiceCollection RegisterStorageService(this IServiceCollection services)
        {
            services.AddSingleton(_ =>
            {
                var googleCredential = GoogleCredential.FromFile(AppConfig.GoogleSetting.CredentialFile);
                var storage = StorageClient.Create(googleCredential);
                return storage;
            });
            return services;
        }
    }
}
