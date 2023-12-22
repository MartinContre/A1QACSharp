using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Configurations;
using EuroNewsTest.Utils;

namespace EuronewsBDD.StepDefinitions
{
    [Binding]
    public class BaseSteps
    {
        protected readonly Browser browser;
        protected readonly ISettingsFile configData;

        public BaseSteps()
        {
            browser = AqualityServices.Browser;
            configData = SettingsFilesUtils.GetConfigData();
        }
    }
}
