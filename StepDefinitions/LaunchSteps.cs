using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using SimpleSpecflowExtentReport.PagesObjectModels;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public sealed class LaunchSteps
    {
       private IWebDriver driver;
       LaunchPage launchPage ;
       public LaunchSteps(IWebDriver driver)
       {
           this.driver = driver;
           launchPage = new LaunchPage(driver);
       }
        [Given(@"Login to the webpage")]
        public void GivenINavigateToTheApplication()
        {
            Console.WriteLine("Im here");
            launchPage.LoginToWebApplication();
        }

        [When(@"i navigate to some page")]
        public void WhenINavigateToSomePage()
        {
            launchPage.LoginToWebApplication();
        }

        [Then(@"element should have this")]
        public void ThenElementShouldHaveThis()
        {
            launchPage.LoginToWebApplication();
        }
    }
}