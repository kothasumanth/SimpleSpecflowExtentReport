using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow;

[Binding]
public class Hooks
{
    public static String dir = AppDomain.CurrentDomain.BaseDirectory;
    public static String testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");
    private static ExtentReports extent;
    private static ExtentTest feature;
    private static ExtentTest scenario;
    private static ExtentTest step;

    [BeforeTestRun]
    public static void ExtentReportInit()
    {
        var htmlReporter = new ExtentSparkReporter(testResultPath + "test.html");
        htmlReporter.Config.ReportName = "Automation Status Report";
        htmlReporter.Config.DocumentTitle = "Automation Status Report";
        htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;

        extent = new ExtentReports();
        extent.AttachReporter(htmlReporter);
    }

    [BeforeFeature]
    public static void CreateFeature(FeatureContext featureContext)
    {
        feature = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
    }

    [BeforeScenario]
    public static void CreateScenario(ScenarioContext scenarioContext)
    {
        scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
    }

    [BeforeStep]
    public void BeforeStep(ScenarioContext scenarioContext)
    {
        if (scenarioContext.StepContext.StepInfo.StepDefinitionType == TechTalk.SpecFlow.Bindings.StepDefinitionType.Given)
            step = scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
        else if (scenarioContext.StepContext.StepInfo.StepDefinitionType == TechTalk.SpecFlow.Bindings.StepDefinitionType.When)
            step = scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
        else if (scenarioContext.StepContext.StepInfo.StepDefinitionType == TechTalk.SpecFlow.Bindings.StepDefinitionType.Then)
            step = scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);

    }

    [AfterStep]
    public void AfterStep(ScenarioContext scenarioContext)
    {
        if (scenarioContext.TestError != null)
        {
            Console.WriteLine("Error: " + scenarioContext.TestError.Message);
            step.Log(Status.Fail, MarkupHelper.CreateLabel(scenarioContext.TestError.Message, ExtentColor.Red));
        }
        // else
        // {
        //     step.Log(Status.Pass, MarkupHelper.CreateLabel(scenarioContext.StepContext.StepInfo.Text, ExtentColor.Green));
        // }
    }

    public static void LogStepInfo(string info, string status)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        string message = $"{timestamp} : {info}";

        switch (status.ToLower())
        {
            case "info":
                step.Log(Status.Info, MarkupHelper.CreateLabel(message, ExtentColor.Green));
                break;
            case "warning":
                step.Log(Status.Warning, MarkupHelper.CreateLabel(message, ExtentColor.Orange));
                break;
                case "fail":
                step.Log(Status.Warning, MarkupHelper.CreateLabel(message, ExtentColor.Red));
                break;
            default:
                step.Log(Status.Info, message);
                break;
        }
    }

    [AfterTestRun]
    public static void FlushReport()
    {
        extent.Flush();
    }
}