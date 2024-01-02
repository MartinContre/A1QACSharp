using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace Userinyerface.Utilis
{
    public class SettingFileUtils
    {
        private static readonly string ConfigDataFileName = "config_data.json";
        private static readonly string TestDataFileName = "test_data.json";

        public static ISettingsFile GetConfigData()
        {
            return new JsonSettingsFile(ConfigDataFileName);
        }

        public static ISettingsFile GetTestData()
        {
            return new JsonSettingsFile(TestDataFileName);
        }
    }
}
