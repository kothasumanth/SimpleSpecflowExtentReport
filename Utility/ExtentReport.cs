using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V105.SystemInfo;

namespace SimpleSpecflowExtentReport.Utility
{
    public class ExtentReport
    {
        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");
        private static ExtentReports extent;
        private static ExtentTest feature;
        private static ExtentTest scenario;
        private static ExtentTest step;

        public static void ExtentReportInit()
        {
            var htmlReporter = new ExtentSparkReporter(testResultPath + "test.html");
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Standard;

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Browser", "Edge");
            extent.AddSystemInfo("OS", "Windows 10");
        }

        public static void AddFeature(FeatureContext featureContext)
        {
            feature = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        public static void AddScenario(ScenarioContext scenarioContext)
        {
            
            scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        public static void AddStep(ScenarioContext scenarioContext)
        {
            if (scenarioContext.StepContext.StepInfo.StepDefinitionType == TechTalk.SpecFlow.Bindings.StepDefinitionType.Given)
            {
                step = scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
            }
            else if (scenarioContext.StepContext.StepInfo.StepDefinitionType == TechTalk.SpecFlow.Bindings.StepDefinitionType.When)
            {
                step = scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
            }
            else if (scenarioContext.StepContext.StepInfo.StepDefinitionType == TechTalk.SpecFlow.Bindings.StepDefinitionType.Then)
            {
                step = scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);
            }
        }

        public static void LogScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            step.AddScreenCaptureFromPath(addScreenshot(driver, scenarioContext));
        }

        public static void Flush()
        {
            extent.Flush();
        }

        public static string addScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(testResultPath, scenarioContext.ScenarioInfo.Title + ".png");
            screenshot.SaveAsFile(screenshotLocation, ScreenshotImageFormat.Png);
            return screenshotLocation;
        }

        public static void LogStepInfo(string statusType, string status)
        {
            string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string Message = $"{timeStamp} - {statusType.ToUpper().Trim()} - {status}";
            switch (statusType.ToLower().Trim())
            {
                case "info":
                    step.Log(Status.Info, MarkupHelper.CreateLabel(Message, ExtentColor.Blue));
                    break;
                case "pass":
                    step.Log(Status.Pass, MarkupHelper.CreateLabel(Message, ExtentColor.Green));
                    break;
                case "fail":
                    step.Log(Status.Fail, MarkupHelper.CreateLabel(Message, ExtentColor.Red));
                    break;
                case "warning":
                    step.Log(Status.Warning, MarkupHelper.CreateLabel(Message, ExtentColor.Yellow));
                    break;
            }
        }
    }
}