using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace EuroNewsTest.Utils
{
    public class SettingsFilesUtils
    {
        private static readonly string ConfigDataFileName = "config_data.json";
        private static readonly string CredentialFileName = "credentials.json";
        private static readonly string EndPointFileName = "end_points.json";

        public static ISettingsFile GetConfigData()
        {
            return new JsonSettingsFile(ConfigDataFileName);
        }

        public static ISettingsFile GetCredentialData()
        {
            return new JsonSettingsFile(CredentialFileName);
        }

        public static ISettingsFile GetEndPointData()
        {
            return new JsonSettingsFile(EndPointFileName);
        }

    }
}