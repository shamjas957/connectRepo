using Azure.Identity;

namespace Microsoft.Extensions.Configuration
{
    public static class ConfigurationExtensions
    {
        public static ConfigurationManager AddAppConfigurationKeyVault(this ConfigurationManager configuration)
        {
            configuration.AddAzureKeyVault(new Uri($"{configuration["KeyVaultUri"]}"), new DefaultAzureCredential(new DefaultAzureCredentialOptions() {
                ManagedIdentityClientId = configuration["ManagedIdentityClientId"]}));

            configuration.AddAzureAppConfiguration(configuration["AppConfigConnectionString"]);

            return configuration;
        }
    }
}
